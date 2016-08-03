using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.Compatibility.VB6;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Data.SqlClient;



// ERROR: Not supported in C#: OptionDeclaration
using VB = Microsoft.VisualBasic;
namespace COP2001
{
    internal partial class OldfrmMeasureSetup : Form
    {
        private bool blnDragging;
        RadTreeNode gnodDragNode;


        private void btnDown_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            MoveField((false));
            SaveChanges();
        }

        private void btnUp_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            MoveField((true));
            SaveChanges();
        }


        private void MoveField(bool Up)
        {
            object li_cnt = null;
            object li_temp_val = null;
            int li_prev = 0;
            string ls_temp_field = null;
            object li_start = null;
            object li_end = null;
            int li_step = 0;

            if (lstSelectedFieldList.SelectedItems.Count > 0)
            {
                if (Up)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object li_start. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    li_start = 0;
                    //UPGRADE_WARNING: Couldn't resolve default property of object li_end. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    li_end = lstSelectedFieldList.Items.Count - 1;
                    li_step = 1;
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object li_start. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    li_start = lstSelectedFieldList.Items.Count - 1;
                    //UPGRADE_WARNING: Couldn't resolve default property of object li_end. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    li_end = 0;
                    li_step = -1;
                }

                //UPGRADE_WARNING: Couldn't resolve default property of object li_end. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object li_start. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                for (li_cnt = li_start; li_cnt <= li_end; li_cnt += li_step)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object li_cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (lstSelectedFieldList.SelectedIndex == li_cnt == true & ((Up == true & li_cnt > 0) | (Up == false & li_cnt < lstSelectedFieldList.Items.Count - 1)))
                    {
                        if (Up)
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object li_cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            li_prev = li_cnt - 1;
                        }
                        else
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object li_cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            li_prev = li_cnt + 1;
                        }

                        ls_temp_field = Support.GetItemString(lstSelectedFieldList, li_prev);
                        //UPGRADE_WARNING: Couldn't resolve default property of object li_temp_val. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        li_temp_val = Support.GetItemData(lstSelectedFieldList, li_prev);

                        Support.SetItemString(lstSelectedFieldList, li_prev, Support.GetItemString(lstSelectedFieldList, li_cnt));
                        Support.SetItemData(lstSelectedFieldList, li_prev, Support.GetItemData(lstSelectedFieldList, li_cnt));

                        Support.SetItemString(lstSelectedFieldList, li_cnt, ls_temp_field);
                        //UPGRADE_WARNING: Couldn't resolve default property of object li_temp_val. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Support.SetItemData(lstSelectedFieldList, li_cnt, li_temp_val);

                        lstSelectedFieldList.SetSelected(li_cnt, false);
                        lstSelectedFieldList.SetSelected(li_prev, true);
                    }
                }

                ReNumberSelected();

            }
            else
            {
                RadMessageBox.Show("Please select a field to move", RadMessageIcon.Error, "No Field Selected");
            }

        }

        //UPGRADE_WARNING: Event cboMeasure.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboMeasure_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            // ERROR: Not supported in C#: OnErrorStatement


            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = "SELECT * FROM tbl_Setup_FieldMeasureSet fm, tbl_Setup_DataDef dd " + " WHERE dd.DDID = fm.DDID AND fm.MeasureSetID = " + Support.GetItemData(cboMeasure, cboMeasure.SelectedIndex) + " AND fm.RecordStatus = '" + modGlobal.gv_status + "' ORDER BY fm.OrderID";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            lstSelectedFieldList.Items.Clear();

            while (!modGlobal.gv_rs.EOF)
            {
                lstSelectedFieldList.Items.Add(new ListBoxItem((Convert.ToInt16(modGlobal.gv_rs.rdoColumns["OrderID"].Value) + 3) + ". " + modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }

            modGlobal.gv_rs.Dispose();
            RefreshFieldList();

            return;
            ErrHandler:
            modGlobal.CheckForErrors();
        }

        private void cmdAddField_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            object li_cnt = null;
            int li_list = 0;

            if (lstAvailableFieldList.SelectedItems.Count > 0)
            {

                li_list = lstAvailableFieldList.Items.Count - 1;

                //For li_cnt = li_list To 0 Step -1
                //    If li_cnt > li_list Then
                //        Exit For
                //    End If
                //
                //    If lstAvailableFieldList.Selected(li_cnt) = True Then
                //        lstSelectedFieldList.AddItem lstSelectedFieldList.ListCount + 1 & ". " & lstAvailableFieldList.List(li_cnt)
                //        lstSelectedFieldList.ItemData(lstSelectedFieldList.NewIndex) = lstAvailableFieldList.ItemData(li_cnt)
                //
                //        lstAvailableFieldList.RemoveItem li_cnt
                //        li_list = lstAvailableFieldList.ListCount - 1
                //    End If
                //Next

                for (li_cnt = 0; li_cnt <= li_list; li_cnt++)
                {
                    //If li_cnt > li_list Then
                    //    Exit For
                    //End If

                    if (lstAvailableFieldList.GetSelected(li_cnt) == true)
                    {
                        lstSelectedFieldList.Items.Add(new ListBoxItem(lstSelectedFieldList.Items.Count + 1 + ". " + Support.GetItemString(lstAvailableFieldList, li_cnt), Support.GetItemData(lstAvailableFieldList, li_cnt)));

                        //lstAvailableFieldList.RemoveItem li_cnt
                        //li_list = lstAvailableFieldList.ListCount - 1
                    }
                }

                ReNumberSelected();

                SaveChanges();
            }
            else
            {
                RadMessageBox.Show("Please select a field");
            }

        }

        private void ReNumberSelected()
        {
            int li_cnt = 0;
            string ls_field = null;

            for (li_cnt = 0; li_cnt <= lstSelectedFieldList.Items.Count - 1; li_cnt++)
            {
                ls_field = Support.GetItemString(lstSelectedFieldList, li_cnt);
                ls_field = Strings.Trim(Strings.Right(ls_field, Strings.Len(ls_field) - Strings.InStr(ls_field, ".")));

                Support.SetItemString(lstSelectedFieldList, li_cnt, (li_cnt + 3) + ". " + ls_field);
            }
        }


        private void cmdAddRelated_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int li_cnt = 0;
            RadTreeNode nodTarget = null;
            int li_FieldGroupID = 0;
            RadTreeNode nodNode = null;

            // ERROR: Not supported in C#: OnErrorStatement


            if ((trvGroupedFields.SelectedNode != null))
            {

                nodTarget = trvGroupedFields.SelectedNode;

                li_FieldGroupID = (Strings.InStr(1, nodTarget.Name, "FGID") + 4 > 0 ? Strings.Mid(nodTarget.Name, Strings.InStr(1, nodTarget.Name, "FGID") + 4, Strings.Len(nodTarget.Name)) : 0);

                if (li_FieldGroupID > 0)
                {
                    for (li_cnt = 0; li_cnt <= lstRelatedFields.Items.Count - 1; li_cnt++)
                    {
                        if (lstRelatedFields.GetSelected(li_cnt))
                        {

                            nodNode = trvGroupedFields.Nodes.Find(nodTarget.Name, true)[0].Nodes.Add("DDID" + Support.GetItemData(lstRelatedFields, li_cnt), Support.GetItemString(lstRelatedFields, li_cnt));
                            nodNode.EnsureVisible();

                            modGlobal.gv_sql = "INSERT INTO tbl_Setup_DDIDFieldGroup (DDID, FieldGroupID) ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " VALUES (" + Support.GetItemData(lstRelatedFields, li_cnt) + ", " + li_FieldGroupID + ")";

                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        }
                    }
                }
                else
                {
                    RadMessageBox.Show("Please choose the group and not the item to add to", RadMessageIcon.Error, "Item Selected");
                }

            }
            else
            {
                RadMessageBox.Show("Select a group to add the fields to.", MessageBoxButtons.Information, "No Field Group Selected");
            }
            return;
            ErrHandler:

            modGlobal.CheckForErrors();
        }

        private void cmdAddSimilarFields_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int li_cnt = 0;
            RadTreeNode nodTarget = null;
            int li_FieldGroupID = 0;
            RadTreeNode nodNode = null;

            // ERROR: Not supported in C#: OnErrorStatement


            if ((trvRelatedFields.SelectedNode != null))
            {

                nodTarget = trvRelatedFields.SelectedNode;

                li_FieldGroupID = (Strings.InStr(1, nodTarget.Name, "FGID") + 4 > 0 ? Strings.Mid(nodTarget.Name, Strings.InStr(1, nodTarget.Name, "FGID") + 4, Strings.Len(nodTarget.Name)) : 0);

                if (li_FieldGroupID > 0)
                {
                    for (li_cnt = 0; li_cnt <= lstRelatedGroupFields.Items.Count - 1; li_cnt++)
                    {
                        if (lstRelatedGroupFields.GetSelected(li_cnt))
                        {

                            nodNode = trvRelatedFields.Nodes.Find(nodTarget.Name, true)[0].Nodes.Add("DDID" + Support.GetItemData(lstRelatedGroupFields, li_cnt), Support.GetItemString(lstRelatedGroupFields, li_cnt));
                            nodNode.EnsureVisible();


                            modGlobal.gv_sql = "INSERT INTO tbl_Setup_DDIDRelatedFieldGroup (DDID, RelatedFieldGroupID) ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " VALUES (" + Support.GetItemData(lstRelatedGroupFields, li_cnt) + ", " + li_FieldGroupID + ")";

                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        }
                    }
                }
                else
                {
                    RadMessageBox.Show("Please choose the group and not the item to add to", RadMessageIcon.Error, "Item Selected");
                }

            }
            else
            {
                RadMessageBox.Show("Select a group to add the fields to.", MessageBoxButtons.Information, "No Field Group Selected");
            }
            return;
            ErrHandler:

            modGlobal.CheckForErrors();
        }

        private void cmdClear_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (RadMessageBox.Show("Are you sure you want to delete all these items?", MessageBoxButtons.YesNo, "Confirm Delete?") == DialogResult.Yes)
            {
                lstSelectedFieldList.Items.Clear();
                SaveChanges();
            }
        }

        private void cmdCreateGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            SqlCommand ps = null;

            // ERROR: Not supported in C#: OnErrorStatement


            if (!string.IsNullOrEmpty(txtNewGroup.Text))
            {

                modGlobal.gv_sql = "{ ? = call CreateFieldGroup(?) }";
                ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                ps.rdoParameters[0].Direction = RDO.DirectionConstants.rdParamReturnValue;
                ps.rdoParameters[1].Direction = RDO.DirectionConstants.rdParamInput;
                ps.rdoParameters[1].Value = txtNewGroup.Text;

                ps.Execute();
                ps.Close();

                RadMessageBox.Show("Group Successfully Created");
                txtNewGroup.Text = "";

                RefreshGroupFields();
            }
            else
            {

                RadMessageBox.Show("Please enter a name for the group");

            }
            return;
            ErrHandler:

            modGlobal.CheckForErrors();

        }

        private void cmdCreateRelatedGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            SqlCommand ps = null;

            // ERROR: Not supported in C#: OnErrorStatement


            if (!string.IsNullOrEmpty(txtNewRelatedGroup.Text))
            {

                modGlobal.gv_sql = "{ ? = call CreateRelatedFieldGroup(?) }";
                ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                ps.rdoParameters[0].Direction = RDO.DirectionConstants.rdParamReturnValue;
                ps.rdoParameters[1].Direction = RDO.DirectionConstants.rdParamInput;
                ps.rdoParameters[1].Value = txtNewRelatedGroup.Text;

                ps.Execute();
                ps.Close();

                RadMessageBox.Show("Group Successfully Created");
                txtNewRelatedGroup.Text = "";

                RefreshRelatedGroupFields();
            }
            else
            {

                RadMessageBox.Show("Please enter a name for the group");

            }
            return;
            ErrHandler:

            modGlobal.CheckForErrors();
        }

        private void cmdRemoveField_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string ls_field = null;
            object li_cnt = null;
            int li_list = 0;

            // ERROR: Not supported in C#: OnErrorStatement


            short counter = 0;
            if (lstSelectedFieldList.SelectedItems.Count > 0)
            {
                li_list = lstSelectedFieldList.Items.Count - 1;

                counter = li_list;
                for (li_cnt = counter; li_cnt >= 0; li_cnt += -1)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object li_cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (li_cnt > li_list)
                    {
                        break; // TODO: might not be correct. Was : Exit For
                    }

                    if (lstSelectedFieldList.SelectedIndex == li_cnt == true)
                    {
                        ls_field = Support.GetItemString(lstSelectedFieldList, li_cnt);
                        ls_field = Strings.Trim(Strings.Right(ls_field, Strings.Len(ls_field) - Strings.InStr(ls_field, ".")));

                        lstAvailableFieldList.Items.Add(new ListBoxItem(ls_field, Support.GetItemData(lstSelectedFieldList, li_cnt)));
                        //UPGRADE_WARNING: Couldn't resolve default property of object li_cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lstSelectedFieldList.Items.RemoveAt(li_cnt);

                        li_list = lstSelectedFieldList.Items.Count - 1;
                    }

                    ReNumberSelected();
                }

                SaveChanges();
            }
            else
            {
                RadMessageBox.Show("Please select a field");
            }
            return;
            ErrHandler:
            modGlobal.CheckForErrors();
        }


        private void cmdSaveMap_Click()
        {
            SaveChanges();
        }

        private void frmMeasureSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            // ERROR: Not supported in C#: OnErrorStatement


            this.Left = Support.TwipsToPixelsX((Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Support.TwipsToPixelsY((Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Support.PixelsToTwipsY(this.Height) / 2));

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_status == "TEST")
            {
                cmdChangeStatus0.Text = "Move to Active";
                cmdChangeStatus1.Text = "Move to Active";
                cmdChangeStatus2.Text = "Move to Active";
            }
            else
            {
                cmdChangeStatus0.Text = "Move to Test";
                cmdChangeStatus1.Text = "Move to Test";
                cmdChangeStatus2.Text = "Move to Test";
            }

            modGlobal.ClearErrors();

            RefreshMeasureSets();
            RefreshFieldList();
            RefreshMeasureSet();
            RefreshMeasureCat();
            RefreshGroupFields();
            RefreshRelatedGroupFields();

            sstabMeasureList.SelectedIndex = 0;
            sstabMeasureList.Enabled = true;
            sstabMeasureSpec.SelectedIndex = 0;
            sstabMeasureSpec.Enabled = true;
            return;
            ErrHandler:
            modGlobal.CheckForErrors();
        }

        private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            SaveChanges();

            this.Close();
        }


        private void RefreshFieldList()
        {
            int ll_ind = 0;
            DataSet rs_group = null;


            // ERROR: Not supported in C#: OnErrorStatement


            //retrieve the list of patient table fields
            modGlobal.gv_sql = "Select * from tbl_setup_DataDef where BaseTableID = (SELECT BaseTableID FROM tbl_setup_TableDef " + " where BaseTable = 'PATIENT') ";

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and State = '" + modGlobal.gv_State + "'";
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_status))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
            }

            modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldCategory desc, FieldName ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            lstAvailableFieldList.Items.Clear();
            trvAvailGroupFields.Nodes.Clear();

            var _with1 = trvAvailFields.Nodes;

            _with1.Clear();

            ll_ind = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                ll_ind = ll_ind + 1;

                lstAvailableFieldList.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));

                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_DDIDFieldGroup WHERE DDID = " + modGlobal.gv_rs.rdoColumns["DDID"].Value;
                rs_group = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                if (rs_group.EOF)
                {
                    _with1.Add(modGlobal.gv_rs.rdoColumns["FieldName"].Value);
                    //UPGRADE_WARNING: Lower bound of collection trvAvailFields.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                    _with1.Item(_with1.Count).Name = "DDID" + Convert.ToString(modGlobal.gv_rs.rdoColumns["DDID"].Value);

                    trvAvailGroupFields.Nodes.Add(modGlobal.gv_rs.rdoColumns["FieldName"].Value);
                    //UPGRADE_WARNING: Lower bound of collection trvAvailGroupFields.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                    trvAvailGroupFields.Nodes[_with1.Count].Name = "DDID" + Convert.ToString(modGlobal.gv_rs.rdoColumns["DDID"].Value);
                }
                rs_group.Close();

                //LDW modGlobal.gv_rs.MoveNext();
            }


            Application.DoEvents();
            modGlobal.gv_rs.Dispose();
            RemoveSelected();

            return;
            ErrHandler:
            modGlobal.CheckForErrors();
        }


        private void lstAvailableFieldList_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
        {
            cmdAddField_Click(cmdAddField, new System.EventArgs());
        }

        private void SaveChanges()
        {
            int li_cnt = 0;

            // ERROR: Not supported in C#: OnErrorStatement


            if (cboMeasure.SelectedIndex == -1)
            {
                RadMessageBox.Show("You must select a Measure Set to Save", RadMessageIcon.Error, "No Measure Set Selected.");
                return;
            }

            modGlobal.gv_sql = "DELETE FROM tbl_Setup_FieldMeasureSet WHERE MeasureSetID = " + Support.GetItemData(cboMeasure, cboMeasure.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            for (li_cnt = 0; li_cnt <= lstSelectedFieldList.Items.Count - 1; li_cnt++)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = "INSERT INTO tbl_Setup_FieldMeasureSet (DDID, MeasureSetID, OrderID, RecordStatus) VALUES (" + Support.GetItemData(lstSelectedFieldList, li_cnt) + ", " + Support.GetItemData(cboMeasure, cboMeasure.SelectedIndex) + ", " + li_cnt + ", '" + modGlobal.gv_status + "')";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
            }

            RefreshFieldList();

            return;
            ErrHandler:
            modGlobal.CheckForErrors();
        }

        private void RemoveSelected()
        {
            object li_cnt = null;
            int li_lst = 0;
            int li_found = 0;

            for (li_cnt = 0; li_cnt <= lstSelectedFieldList.Items.Count - 1; li_cnt++)
            {
                li_found = 999;
                for (li_lst = 0; li_lst <= lstAvailableFieldList.Items.Count - 1; li_lst++)
                {
                    if (Support.GetItemData(lstAvailableFieldList, li_lst) == Support.GetItemData(lstSelectedFieldList, li_cnt))
                    {
                        li_found = li_lst;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
                if (li_found != 999)
                {
                    lstAvailableFieldList.Items.RemoveAt((li_found));
                    lstAvailableFieldList.Refresh();
                }
            }

            Application.DoEvents();
        }


        //UPGRADE_WARNING: Event cboMeasureSet.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboMeasureSet_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            RefreshMeasureSetField();
        }


        private void cmdChangeStatus_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int Index = cmdChangeStatus.GetIndex(eventSender);
            string MoveToModule = null;
            DialogResult resp = default(DialogResult);


            switch (Index)
            {
                case 0:
                    if (cboMeasureSet.SelectedIndex < 0)
                    {
                        return;
                    }

                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
                    resp = RadMessageBox.Show("Are you sure you want this Measure set to the " + MoveToModule + " Module?", MessageBoxButtons.YesNo);
                    if (resp == DialogResult.No)
                    {
                        return;
                    }

                    modGlobal.gv_sql = "Update tbl_setup_measureset ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + "  Set RecordStatus =  " + (modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                    modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureSetID = " + Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshMeasureSet();
                    RefreshMeasureSetField();
                    break;
                case 2:


                    if (cboMeasure.SelectedIndex < 0)
                    {
                        return;
                    }

                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
                    resp = RadMessageBox.Show("Are you sure you want this report to the " + MoveToModule + " Module?", MessageBoxButtons.YesNo);
                    if (resp == DialogResult.No)
                    {
                        return;
                    }

                    modGlobal.gv_sql = "Update tbl_Setup_FieldMeasureSet ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + "  Set RecordStatus =  " + (modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                    modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureSetID = " + Support.GetItemData(cboMeasure, cboMeasure.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    sstabMeasureSpec.SelectedIndex = 0;
                    sstabMeasureSpec.Enabled = false;
                    break;
            }

        }

        private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int Index = cmdDelete.GetIndex(eventSender);
            int li_cnt = 0;
            DataSet rs_MeasureStep = null;

            // ERROR: Not supported in C#: OnErrorStatement


            string ls_catID = null;
            switch (Index)
            {
                case 0:
                    if (cboMeasureSet.SelectedIndex < 0)
                    {
                        return;
                    }

                    if (RadMessageBox.Show("Are you sure you'd like to delete this measure set and all it's data?", MessageBoxButtons.YesNo, "Delete Measure Set?") == DialogResult.Yes)
                    {
                        //get measure id to delete from criteria tables
                        modGlobal.gv_sql = "SELECT * FROM tbl_setup_MeasureSetMapMeas ";
                        modGlobal.gv_sql = modGlobal.gv_sql + "  where MeasureSetID = " + Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex);
                        modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                        while (!modGlobal.gv_rs.EOF)
                        {
                            rs_MeasureStep = modGlobal.gv_cn.OpenResultset("SELECT * FROM tbl_Setup_MeasureStep WHERE MeasureID = " + modGlobal.gv_rs.rdoColumns["IndicatorID"].Value, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                            while (!rs_MeasureStep.EOF)
                            {
                                modGlobal.gv_sql = "DELETE FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaSetID in " + " (SELECT MeasureCriteriaSetID FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureStepID = " + rs_MeasureStep.rdoColumns["MeasureStepID"].Value + ")";
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                modGlobal.gv_sql = "DELETE from tbl_Setup_MeasureCriteriaSet WHERE MeasureStepID = " + rs_MeasureStep.rdoColumns["MeasureStepID"].Value;
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                                rs_MeasureStep.Delete();
                                rs_MeasureStep.MoveNext();
                            }

                            rs_MeasureStep.Close();
                            modGlobal.gv_rs.Delete();
                            //LDW modGlobal.gv_rs.MoveNext();
                        }
                        modGlobal.gv_rs.Dispose();

                        //delete measure set mappings
                        modGlobal.gv_sql = "Delete tbl_Setup_FieldMeasureSet WHERE MeasureSetID = " + Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        //delete measure set
                        modGlobal.gv_sql = "Delete tbl_setup_measureset ";
                        modGlobal.gv_sql = modGlobal.gv_sql + "  where MeasureSetID = " + Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        RefreshMeasureSet();
                        RefreshMeasureSets();
                        cboMeasureSet.SelectedIndex = -1;
                        RefreshMeasureSetField();
                    }
                    break;
                case 1:

                    if (lstMeasureCat.SelectedItems.Count == 1)
                    {

                        for (li_cnt = 0; li_cnt <= lstMeasureCat.Items.Count - 1; li_cnt++)
                        {
                            if (lstMeasureCat.GetSelected(li_cnt))
                            {
                                ls_catID = Convert.ToString(Support.GetItemData(lstMeasureCat, li_cnt));
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }

                        //NOTE - deleting the categories without deleting the measurestep using them could be dangerous
                        modGlobal.gv_sql = "DELETE FROM tbl_MEASURE_CAT WHERE MEASURE_CATID = " + ls_catID;
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        RefreshMeasureCat();
                    }
                    else
                    {
                        RadMessageBox.Show("Please Choose a Category to Edit", MessageBoxButtons.Information, "No Category Selected");
                    }
                    break;
            }
            return;
            ErrHandler:

            modGlobal.CheckForErrors();

        }


        private void cmdEdit_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int Index = cmdEdit.GetIndex(eventSender);
            object ThisSID = null;
            int i = 0;
            string EditSet = null;
            int li_cnt = 0;

            string ls_catID = null;
            switch (Index)
            {
                case 0:
                    if (string.IsNullOrEmpty(cboMeasureSet.Text))
                    {
                        RadMessageBox.Show("Please select a set from the list.");
                        return;
                    }

                    //UPGRADE_WARNING: Couldn't resolve default property of object ThisSID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ThisSID = Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex);
                    EditSet =RadInputBox.Show("Edit the Set Description.", "Edit Set", cboMeasureSet.Text);
                    if (!string.IsNullOrEmpty(EditSet))
                    {
                        modGlobal.gv_sql = "Update tbl_setup_measureset set MeasureSetDesc = '" + EditSet + "'";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureSetID = " + Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        RefreshMeasureSet();
                        cboMeasureSet.Text = EditSet;
                        //set the selected list item to the new one
                        for (i = 0; i <= cboMeasureSet.Items.Count - 1; i++)
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object ThisSID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            if (Support.GetItemData(cboMeasureSet, i) == ThisSID)
                            {
                                cboMeasureSet.SelectedIndex = i;
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                    }
                    break;
                case 1:

                    if (lstMeasureCat.SelectedItems.Count == 1)
                    {
                        for (li_cnt = 0; li_cnt <= lstMeasureCat.Items.Count - 1; li_cnt++)
                        {
                            if (lstMeasureCat.GetSelected(li_cnt))
                            {
                                ls_catID = Convert.ToString(Support.GetItemData(lstMeasureCat, li_cnt));
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }

                        dlgCreateCat.Setii_CatID(ref ls_catID);
                        dlgCreateCat.ShowDialog();

                        RefreshMeasureCat();
                    }
                    else
                    {
                        RadMessageBox.Show("Please Choose a Category to Edit", MessageBoxButtons.Information, "No Category Selected");
                    }
                    break;
            }

        }


        private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int Index = cmdNew.GetIndex(eventSender);
            string NewMeasure = null;
            int NewIndID = 0;

            string newset = null;
            object NewIndSID = null;
            int i = 0;
            switch (Index)
            {
                case 0:

                    newset =RadInputBox.Show("Please enter the description of the new Measure Set:", "Add New Set", "");
                    if (string.IsNullOrEmpty(newset))
                    {
                        return;
                    }

                    modGlobal.gv_sql = "Insert into  tbl_setup_MeasureSet (MeasureSetDesc, State, RecordStatus) ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Values ('" + newset + "',";
                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_State + "',";
                    }
                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (string.IsNullOrEmpty(modGlobal.gv_status))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_status + "'";
                    }
                    modGlobal.gv_sql = modGlobal.gv_sql + ")";

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshMeasureSet();
                    RefreshMeasureSets();
                    cboMeasureSet.SelectedIndex = -1;
                    break;
                case 1:
                    dlgCreateCat.Setii_CatID(ref "");
                    dlgCreateCat.ShowDialog();
                    RefreshMeasureCat();
                    break;
            }

        }
        private void cmdAddMeasureToSet_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            frmMeasureAddToSet.ShowDialog();
            RefreshMeasureSets();
        }

        private void cmdRemoveMeasureFromSet_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (lstMeasureSet.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_sql = "Delete tbl_setup_MeasureSetMapMeas ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where MeaslinkID =  " + Support.GetItemData(lstMeasureSet, lstMeasureSet.SelectedIndex);

            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshMeasureSetField();

        }
        public void RefreshMeasureSetField()
        {
            modGlobal.gv_sql = "Select tbl_setup_indicator.Description, tbl_setup_MeasureSetMapMeas.*  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_indicator, tbl_setup_MeasureSetMapMeas ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_indicator.IndicatorID = tbl_setup_MeasureSetMapMeas.IndicatorID ";
            if (cboMeasureSet.SelectedIndex < 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_MeasureSetMapMeas.MeasureSetID  = 0 ";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_MeasureSetMapMeas.MeasureSetID  = " + Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex);
            }

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            lstMeasureSet.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                lstMeasureSet.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["Description"].Value, modGlobal.gv_rs.rdoColumns["measLinkID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

        }

        private void RefreshMeasureCat()
        {
            object Categories = null;
            int li_cnt = 0;
            int li_rows = 0;

            modGlobal.gv_sql = "SELECT * FROM tbl_MEASURE_CAT";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            if (!modGlobal.gv_rs.EOF)
            {
                li_rows = modGlobal.gv_rs.RowCount;
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_rs.GetRows(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object Categories. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Categories = modGlobal.gv_rs.GetRows(li_rows);
                modGlobal.gv_rs.Dispose();

                lstMeasureCat.Items.Clear();

                for (li_cnt = 0; li_cnt <= li_rows - 1; li_cnt++)
                {

                    //UPGRADE_WARNING: Couldn't resolve default property of object Categories(2, li_cnt). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object Categories(1, li_cnt). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    lstMeasureCat.Items.Add(new ListBoxItem(Categories(1, li_cnt) + " - " + Categories(2, li_cnt), Categories(0, li_cnt)));
                }
            }


        }


        public void RefreshMeasureSet()
        {
            string setdesc = null;

            modGlobal.gv_sql = "Select * from tbl_setup_measureset ";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " Where State = '" + modGlobal.gv_State + "'";
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_status))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by MeasureSetDesc ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            cboMeasureSet.Items.Clear();

            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["EffDate"].Value))
                {
                    setdesc = modGlobal.gv_rs.rdoColumns["MeasureSetDesc"].Value;
                }
                else
                {
                    setdesc = modGlobal.gv_rs.rdoColumns["MeasureSetDesc"].Value + " (" + modGlobal.gv_rs.rdoColumns["EffDate"].Value + ")";
                }
                cboMeasureSet.Items.Add(new ListBoxItem(setdesc, modGlobal.gv_rs.rdoColumns["MeasureSetID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }

            modGlobal.gv_rs.Dispose();
        }

        private void RefreshMeasureSets()
        {
            int ll_ind = 0;

            // ERROR: Not supported in C#: OnErrorStatement

            //retrieve the list of Indicators
            modGlobal.gv_sql = "Select MeasureSetDesc, MeasureSetID from tbl_setup_MeasureSet ";

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " Where State = '" + modGlobal.gv_State + "'";
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_status))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by 1 ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            cboMeasure.Items.Clear();
            ll_ind = -1;

            while (!modGlobal.gv_rs.EOF)
            {
                ll_ind = ll_ind + 1;

                cboMeasure.Items.Add(modGlobal.gv_rs.rdoColumns["MeasureSetDesc"].Value);

                //UPGRADE_ISSUE: ComboBox property cboMeasure.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                Support.SetItemData(cboMeasure, cboMeasure.NewIndex, modGlobal.gv_rs.rdoColumns["MeasureSetID"].Value);
                //LDW modGlobal.gv_rs.MoveNext();
            }

            modGlobal.gv_rs.Dispose();

            return;
            ErrHandler:
            modGlobal.CheckForErrors();
        }

        private void RefreshRelatedGroupFields()
        {
            DataSet rs_DDIDFieldGroup = null;
            RadTreeNode nodParent = null;

            var _with2 = trvRelatedFields.Nodes;
            _with2.Clear();

            modGlobal.gv_sql = "SELECT * FROM tbl_Setup_RelatedFieldGroup ORDER BY RelatedGroupName";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            while (!modGlobal.gv_rs.EOF)
            {
                nodParent = _with2.Add(modGlobal.gv_rs.rdoColumns["RelatedGroupName"].Value);
                nodParent.Name = "FGID" + Convert.ToString(modGlobal.gv_rs.rdoColumns["RelatedFieldGroupID"].Value);

                modGlobal.gv_sql = "SELECT dd.DDID, dd.FieldName FROM tbl_Setup_DDIDRelatedFieldGroup fg, tbl_Setup_DataDef dd WHERE dd.DDID = fg.DDID AND RelatedFieldGroupID = " + modGlobal.gv_rs.rdoColumns["RelatedFieldGroupID"].Value;
                rs_DDIDFieldGroup = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                while (!rs_DDIDFieldGroup.EOF)
                {
                    _with2.Find(nodParent.Name, true)(0).Nodes.Add("DDID" + rs_DDIDFieldGroup.rdoColumns["DDID"].Value, rs_DDIDFieldGroup.rdoColumns["FieldName"].Value);
                    rs_DDIDFieldGroup.MoveNext();
                }
                nodParent.EnsureVisible();

                //LDW modGlobal.gv_rs.MoveNext();
            }

            modGlobal.gv_rs.Dispose();


        }

        private void RefreshGroupFields()
        {
            DataSet rs_DDIDFieldGroup = null;
            RadTreeNode nodParent = null;

            var _with3 = trvGroupedFields.Nodes;
            _with3.Clear();

            modGlobal.gv_sql = "SELECT * FROM tbl_Setup_FieldGroup ORDER BY FieldGroupName";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            while (!modGlobal.gv_rs.EOF)
            {
                nodParent = _with3.Add(modGlobal.gv_rs.rdoColumns["FIELDGROUPNAME"].Value);
                nodParent.Name = "FGID" + Convert.ToString(modGlobal.gv_rs.rdoColumns["FIELDGroupID"].Value);

                modGlobal.gv_sql = "SELECT dd.DDID, dd.FieldName FROM tbl_Setup_DDIDFieldGroup fg, tbl_Setup_DataDef dd WHERE dd.DDID = fg.DDID AND FieldGroupID = " + modGlobal.gv_rs.rdoColumns["FIELDGroupID"].Value;
                rs_DDIDFieldGroup = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                while (!rs_DDIDFieldGroup.EOF)
                {
                    _with3.Find(nodParent.Name, true)(0).Nodes.Add("DDID" + rs_DDIDFieldGroup.rdoColumns["DDID"].Value, rs_DDIDFieldGroup.rdoColumns["FieldName"].Value);
                    rs_DDIDFieldGroup.MoveNext();
                }
                nodParent.EnsureVisible();

                //LDW modGlobal.gv_rs.MoveNext();
            }

            modGlobal.gv_rs.Dispose();


        }

        private void RefreshChangeFieldList( string FieldName)
        {
            string[] ls_Parts = null;
            string ls_Part1 = null;
            string ls_Part2 = null;
            ListBox lstControl = null;

            ls_Parts = Strings.Split(FieldName + " ", " ");
            ls_Part1 = ls_Parts[0];

            if (sstabMeasureList.SelectedIndex == 3)
            {
                if (Information.UBound(ls_Parts) > 2)
                {
                    ls_Part2 = ls_Parts[2];
                }

                lstControl = lstRelatedFields;
                modGlobal.gv_sql = "SELECT DDID, FieldName FROM tbl_Setup_DataDef WHERE FieldName like '" + ls_Part1 + "%" + ls_Part2 + "%' " + " AND FieldType = (SELECT FieldType FROM tbl_Setup_DataDef WHERE FieldName = '" + FieldName + "')" + " ORDER BY FieldName";
            }
            else
            {
                if (Information.UBound(ls_Parts) > 1)
                {
                    ls_Part2 = ls_Parts[1];
                }

                lstControl = lstRelatedGroupFields;
                modGlobal.gv_sql = "SELECT DDID, FieldName FROM tbl_Setup_DataDef WHERE FieldName like '" + ls_Part1 + " " + ls_Part2 + "%' " + " ORDER BY FieldName";
            }


            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            var _with4 = lstControl;
            _with4.Items.Clear();

            while (!modGlobal.gv_rs.EOF)
            {
                _with4.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }


            //UPGRADE_NOTE: Object lstControl may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            lstControl = null;

            modGlobal.gv_rs.Dispose();

        }
        readonly Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag static_sstabMeasureList_SelectedIndexChanged_PreviousTab_Init = new Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag();

        short static_sstabMeasureList_SelectedIndexChanged_PreviousTab;
        private void sstabMeasureList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            lock (static_sstabMeasureList_SelectedIndexChanged_PreviousTab_Init)
            {
                try
                {
                    if (InitStaticVariableHelper(static_sstabMeasureList_SelectedIndexChanged_PreviousTab_Init))
                    {
                        static_sstabMeasureList_SelectedIndexChanged_PreviousTab = sstabMeasureList.SelectedIndex();
                    }
                }
                finally
                {
                    static_sstabMeasureList_SelectedIndexChanged_PreviousTab_Init.State = 1;
                }
            }

            //UPGRADE_NOTE: Object gnodDragNode may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            gnodDragNode = null;

            static_sstabMeasureList_SelectedIndexChanged_PreviousTab = sstabMeasureList.SelectedIndex();
        }


        private void trvAvailFields_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if ((trvAvailFields.SelectedNode != null))
            {
                RefreshChangeFieldList( (trvAvailFields.SelectedNode.Text));
            }
        }

        private void trvAvailFields_MouseDown(System.Object eventSender, MouseEventArgs eventArgs)
        {
            short Button = eventArgs.Button / 0x100000;
            short Shift = Control.ModifierKeys / 0x10000;
            float X = Support.PixelsToTwipsX(eventArgs.X);
            float Y = Support.PixelsToTwipsY(eventArgs.Y);

            //// get the node we are over
            gnodDragNode = trvAvailFields.GetNodeAt(X, Y);
            if (gnodDragNode == null)
                return;
            //// no node

            //// ensure node is actually selected, just incase we start dragging.
            //UPGRADE_ISSUE: MSComctlLib.Node property gnodDragNode.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            gnodDragNode.Selected = true;

        }

        //UPGRADE_ISSUE: MSComctlLib.TreeView event trvAvailFields.OLEStartDrag was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
        private void trvAvailFields_OLEStartDrag(ref MSComctlLib.DataObject Data, ref int AllowedEffects)
        {
            //// Set the effect to move
            AllowedEffects = DragDropEffects.Move;
            //// Assign the selected item's key to the DataObject
            Data.SetData(gnodDragNode.Name);
            //// we are dragging from this control
            blnDragging = true;
        }



        private void trvAvailGroupFields_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if ((trvAvailGroupFields.SelectedNode != null))
            {
                RefreshChangeFieldList( (trvAvailGroupFields.SelectedNode.Text));
            }
        }

        private void trvAvailGroupFields_MouseDown(System.Object eventSender, MouseEventArgs eventArgs)
        {
            short Button = eventArgs.Button / 0x100000;
            short Shift = Control.ModifierKeys / 0x10000;
            float X = Support.PixelsToTwipsX(eventArgs.X);
            float Y = Support.PixelsToTwipsY(eventArgs.Y);
            //// get the node we are over
            gnodDragNode = trvAvailGroupFields.GetNodeAt(X, Y);
            if (gnodDragNode == null)
                return;
            //// no node

            //// ensure node is actually selected, just incase we start dragging.
            //UPGRADE_ISSUE: MSComctlLib.Node property gnodDragNode.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            gnodDragNode.Selected = true;
        }

        //UPGRADE_ISSUE: MSComctlLib.TreeView event trvAvailGroupFields.OLEStartDrag was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
        private void trvAvailGroupFields_OLEStartDrag(ref MSComctlLib.DataObject Data, ref int AllowedEffects)
        {
            //// Set the effect to move
            AllowedEffects = DragDropEffects.Move;
            //// Assign the selected item's key to the DataObject
            Data.SetData(gnodDragNode.Name);
            //// we are dragging from this control
            blnDragging = true;
        }

        private void trvGroupedFields_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if ((trvGroupedFields.SelectedNode != null))
            {
                gnodDragNode = trvGroupedFields.SelectedNode;
            }
            else
            {
                //UPGRADE_NOTE: Object gnodDragNode may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                gnodDragNode = null;
            }
        }

        private void trvGroupedFields_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
        {
            short Keycode = eventArgs.KeyCode;
            short Shift = eventArgs.KeyData / 0x10000;
            int li_DDID = 0;
            int li_FGID = 0;

            // ERROR: Not supported in C#: OnErrorStatement


            if (Keycode == Keys.Delete)
            {

                li_DDID = (Strings.InStr(1, gnodDragNode.Name, "DDID") > 0 ? Strings.Mid(gnodDragNode.Name, Strings.InStr(1, gnodDragNode.Name, "DDID") + 4, Strings.Len(gnodDragNode.Name)) : 0);
                if (li_DDID > 0)
                {
                    if (RadMessageBox.Show("Are you sure you want to delete this item?", MessageBoxButtons.YesNo, "Confirm Delete?") == DialogResult.Yes)
                    {
                        modGlobal.gv_sql = "DELETE FROM tbl_Setup_DDIDFieldGroup WHERE DDID = " + li_DDID;
                    }
                    else
                    {
                        modGlobal.gv_sql = "";
                    }
                }
                else
                {
                    li_FGID = Convert.ToInt32(Strings.Mid(gnodDragNode.Name, Strings.InStr(1, gnodDragNode.Name, "FGID") + 4, Strings.Len(gnodDragNode.Name)));
                    if (RadMessageBox.Show("Are you sure you want to delete this group and all the related items?", MessageBoxButtons.YesNo, "Confirm Delete?") == DialogResult.Yes)
                    {
                        modGlobal.gv_sql = "DELETE FROM tbl_Setup_FieldGroup WHERE FieldGroupID = " + li_FGID;
                    }
                    else
                    {
                        modGlobal.gv_sql = "";
                    }
                }

                if (!string.IsNullOrEmpty(modGlobal.gv_sql))
                {
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    if (li_FGID > 0)
                    {
                        modGlobal.gv_sql = "DELETE FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = " + li_FGID;
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }

                    //UPGRADE_WARNING: MSComctlLib.Nodes method trvGroupedFields.Nodes.Remove has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                    trvGroupedFields.Nodes.RemoveAt(gnodDragNode.Name);
                }

            }
            return;
            ErrHandler:

            modGlobal.CheckForErrors();
        }

        private void trvGroupedFields_MouseDown(System.Object eventSender, MouseEventArgs eventArgs)
        {
            short Button = eventArgs.Button / 0x100000;
            short Shift = Control.ModifierKeys / 0x10000;
            float X = Support.PixelsToTwipsX(eventArgs.X);
            float Y = Support.PixelsToTwipsY(eventArgs.Y);
            gnodDragNode = trvGroupedFields.GetNodeAt(X, Y);
        }

        //UPGRADE_ISSUE: MSComctlLib.TreeView event trvGroupedFields.OLECompleteDrag was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
        private void trvGroupedFields_OLECompleteDrag(ref int Effect)
        {
            //// cancel effect so that VB doesn't muck up your transfer
            Effect = DragDropEffects.None;

        }

        //UPGRADE_ISSUE: MSComctlLib.TreeView event trvGroupedFields.OLEDragDrop was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
        private void trvGroupedFields_OLEDragDrop(ref MSComctlLib.DataObject Data, ref int Effect, ref short Button, ref short Shift, ref float X, ref float Y)
        {
            string strSourceKey = null;
            RadTreeNode nodTarget = null;
            RadTreeNode nodNode = null;

            if (Effect != DragDropEffects.Move)
                return;

            if (gnodDragNode == null)
                return;

            //// get the carried data
            strSourceKey = gnodDragNode.Name;

            //// get the target node
            nodTarget = trvGroupedFields.GetNodeAt(X, Y);

            if (nodTarget == null)
                return;
            //// no node


            if (Strings.InStr(1, nodTarget.Name, "FGID") <= 0)
            {
                Effect = DragDropEffects.None;
                return;
            }

            //// ensure node is actually selected, just incase we start dragging.
            //UPGRADE_ISSUE: MSComctlLib.Node property nodTarget.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            nodTarget.Selected = true;

            // ERROR: Not supported in C#: OnErrorStatement

            //// move the source node to the target node

            nodNode = trvGroupedFields.Nodes.Find(nodTarget.Name, true)[0].Nodes.Add(gnodDragNode.Name, gnodDragNode.Text);

            if (Err().Number != 0)
                goto DupNode;
            //UPGRADE_ISSUE: MSComctlLib.Node property nodNode.Sorted was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            nodNode.Sorted = true;
            trvGroupedFields.SelectedNode = nodNode;
            nodNode.EnsureVisible();


            if (!SaveGroupedFields( nodTarget))
                return;

            //UPGRADE_NOTE: Object gnodDragNode may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            gnodDragNode = null;

            //// NOTE: You will also need to update the key to reflect the changes
            //// if you are using it
            //// we are not dragging from this control any more
            blnDragging = false;




            return;
            DupNode:
            RadMessageBox.Show("This field is already linked to the group.");
            blnDragging = false;
            Effect = DragDropEffects.None;
            //UPGRADE_NOTE: Object gnodDragNode may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            gnodDragNode = null;

            Err().Clear();

        }

        //UPGRADE_ISSUE: MSComctlLib.TreeView event trvGroupedFields.OLEDragOver was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
        private void trvGroupedFields_OLEDragOver(ref MSComctlLib.DataObject Data, ref int Effect, ref short Button, ref short Shift, ref float X, ref float Y, ref short state)
        {
            RadTreeNode nodNode = null;
            //// set the effect
            Effect = DragDropEffects.Move;
            //// get the node that the object is being dragged over
            nodNode = trvGroupedFields.GetNodeAt(X, Y);
            if (nodNode == null | blnDragging == false)
            {
                //// the dragged object is not over a node, invalid drop target
                //// or the object is not from this control.
                Effect = DragDropEffects.None;
            }
        }

        private bool SaveGroupedFields( RadTreeNode nodTarget)
        {
            bool functionReturnValue = false;

            int li_FieldGroupID = 0;
            int li_DDID = 0;

            li_FieldGroupID = Convert.ToInt32(Strings.Mid(nodTarget.Name, Strings.InStr(1, nodTarget.Name, "FGID") + 4, Strings.Len(nodTarget.Name)));
            li_DDID = Convert.ToInt32(Strings.Mid(gnodDragNode.Name, Strings.InStr(1, gnodDragNode.Name, "DDID") + 4, Strings.Len(gnodDragNode.Name)));

            if (nodTarget.GetNodeCount(false) > 0)
            {
                modGlobal.gv_sql = "SELECT count(*) as SameType FROM tbl_Setup_DataDef def, tbl_Setup_DDIDFieldGroup fg where " + " fg.DDID = def.DDID AND FieldType = (SELECT FieldType FROM tbl_Setup_DataDef WHERE DDID = " + li_DDID + ")";
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                if (!modGlobal.gv_rs.EOF)
                {
                    if (modGlobal.gv_rs.rdoColumns["SameType"].Value == 0)
                    {
                        RadMessageBox.Show("This field is not the same type as the other fields listed in this group.", RadMessageIcon.Error, "Field Not Saved");
                        functionReturnValue = false;
                        return functionReturnValue;

                    }
                }
                modGlobal.gv_rs.Dispose();

            }

            modGlobal.gv_sql = "INSERT INTO tbl_Setup_DDIDFieldGroup (DDID, FieldGroupID) ";
            modGlobal.gv_sql = modGlobal.gv_sql + " VALUES (" + li_DDID + ", " + li_FieldGroupID + ")";

            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
            return functionReturnValue;

        }

        private void SaveRelatedFields( RadTreeNode nodTarget)
        {
            int li_FieldGroupID = 0;
            int li_DDID = 0;

            li_FieldGroupID = Convert.ToInt32(Strings.Mid(nodTarget.Name, Strings.InStr(1, nodTarget.Name, "FGID") + 4, Strings.Len(nodTarget.Name)));
            li_DDID = Convert.ToInt32(Strings.Mid(gnodDragNode.Name, Strings.InStr(1, gnodDragNode.Name, "DDID") + 4, Strings.Len(gnodDragNode.Name)));

            modGlobal.gv_sql = "INSERT INTO tbl_Setup_DDIDRelatedFieldGroup (DDID, RelatedFieldGroupID) ";
            modGlobal.gv_sql = modGlobal.gv_sql + " VALUES (" + li_DDID + ", " + li_FieldGroupID + ")";

            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
        }


        private void trvRelatedFields_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if ((trvRelatedFields.SelectedNode != null))
            {
                gnodDragNode = trvRelatedFields.SelectedNode;
            }
            else
            {
                //UPGRADE_NOTE: Object gnodDragNode may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                gnodDragNode = null;
            }
        }

        private void trvRelatedFields_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
        {
            short Keycode = eventArgs.KeyCode;
            short Shift = eventArgs.KeyData / 0x10000;
            int li_DDID = 0;
            int li_FGID = 0;

            // ERROR: Not supported in C#: OnErrorStatement


            if (Keycode == Keys.Delete)
            {

                li_DDID = (Strings.InStr(1, gnodDragNode.Name, "DDID") > 0 ? Strings.Mid(gnodDragNode.Name, Strings.InStr(1, gnodDragNode.Name, "DDID") + 4, Strings.Len(gnodDragNode.Name)) : 0);
                if (li_DDID > 0)
                {
                    if (RadMessageBox.Show("Are you sure you want to delete this item?", MessageBoxButtons.YesNo, "Confirm Delete?") == DialogResult.Yes)
                    {
                        modGlobal.gv_sql = "DELETE FROM tbl_Setup_DDIDRelatedFieldGroup WHERE DDID = " + li_DDID;
                    }
                    else
                    {
                        modGlobal.gv_sql = "";
                    }
                }
                else
                {
                    li_FGID = Convert.ToInt32(Strings.Mid(gnodDragNode.Name, Strings.InStr(1, gnodDragNode.Name, "FGID") + 4, Strings.Len(gnodDragNode.Name)));
                    if (RadMessageBox.Show("Are you sure you want to delete this group and all the related items?", MessageBoxButtons.YesNo, "Confirm Delete?") == DialogResult.Yes)
                    {
                        modGlobal.gv_sql = "DELETE FROM tbl_Setup_RelatedFieldGroup WHERE RelatedFieldGroupID = " + li_FGID;
                    }
                    else
                    {
                        modGlobal.gv_sql = "";
                    }
                }

                if (!string.IsNullOrEmpty(modGlobal.gv_sql))
                {
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    if (li_FGID > 0)
                    {
                        modGlobal.gv_sql = "DELETE FROM tbl_Setup_DDIDRelatedFieldGroup WHERE RelatedFieldGroupID = " + li_FGID;
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }

                    //UPGRADE_WARNING: MSComctlLib.Nodes method trvRelatedFields.Nodes.Remove has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                    trvRelatedFields.Nodes.RemoveAt(gnodDragNode.Name);
                }

            }

            return;
            ErrHandler:
            modGlobal.CheckForErrors();
        }

        private void trvRelatedFields_MouseDown(System.Object eventSender, MouseEventArgs eventArgs)
        {
            short Button = eventArgs.Button / 0x100000;
            short Shift = Control.ModifierKeys / 0x10000;
            float X = Support.PixelsToTwipsX(eventArgs.X);
            float Y = Support.PixelsToTwipsY(eventArgs.Y);
            gnodDragNode = trvRelatedFields.GetNodeAt(X, Y);
        }

        //UPGRADE_ISSUE: MSComctlLib.TreeView event trvRelatedFields.OLECompleteDrag was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
        private void trvRelatedFields_OLECompleteDrag(ref int Effect)
        {
            //// cancel effect so that VB doesn't muck up your transfer
            Effect = DragDropEffects.None;
        }

        //UPGRADE_ISSUE: MSComctlLib.TreeView event trvRelatedFields.OLEDragDrop was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
        private void trvRelatedFields_OLEDragDrop(ref MSComctlLib.DataObject Data, ref int Effect, ref short Button, ref short Shift, ref float X, ref float Y)
        {
            string strSourceKey = null;
            RadTreeNode nodTarget = null;
            RadTreeNode nodNode = null;

            if (Effect != DragDropEffects.Move)
                return;

            if (gnodDragNode == null)
                return;

            //// get the carried data
            strSourceKey = gnodDragNode.Name;

            //// get the target node
            nodTarget = trvRelatedFields.GetNodeAt(X, Y);

            if (nodTarget == null)
                return;
            //// no node


            if (Strings.InStr(1, nodTarget.Name, "FGID") <= 0)
            {
                Effect = DragDropEffects.None;
                return;
            }

            //// ensure node is actually selected, just incase we start dragging.
            //UPGRADE_ISSUE: MSComctlLib.Node property nodTarget.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            nodTarget.Selected = true;

            // ERROR: Not supported in C#: OnErrorStatement

            //// move the source node to the target node

            nodNode = trvRelatedFields.Nodes.Find(nodTarget.Name, true)[0].Nodes.Add(gnodDragNode.Name, gnodDragNode.Text);

            if (Err().Number != 0)
                goto DupNode;
            //UPGRADE_ISSUE: MSComctlLib.Node property nodNode.Sorted was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            nodNode.Sorted = true;
            trvRelatedFields.SelectedNode = nodNode;
            nodNode.EnsureVisible();


            SaveRelatedFields( nodTarget);
            //UPGRADE_NOTE: Object gnodDragNode may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            gnodDragNode = null;

            //// NOTE: You will also need to update the key to reflect the changes
            //// if you are using it
            //// we are not dragging from this control any more
            blnDragging = false;




            return;
            DupNode:
            RadMessageBox.Show("This field is already linked to the group.");
            blnDragging = false;
            Effect = DragDropEffects.None;
            //UPGRADE_NOTE: Object gnodDragNode may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            gnodDragNode = null;

            Err().Clear();

        }

        //UPGRADE_ISSUE: MSComctlLib.TreeView event trvRelatedFields.OLEDragOver was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
        private void trvRelatedFields_OLEDragOver(ref MSComctlLib.DataObject Data, ref int Effect, ref short Button, ref short Shift, ref float X, ref float Y, ref short state)
        {
            RadTreeNode nodNode = null;
            //// set the effect
            Effect = DragDropEffects.Move;
            //// get the node that the object is being dragged over
            nodNode = trvRelatedFields.GetNodeAt(X, Y);
            if (nodNode == null | blnDragging == false)
            {
                //// the dragged object is not over a node, invalid drop target
                //// or the object is not from this control.
                Effect = DragDropEffects.None;
            }
        }
        static bool InitStaticVariableHelper(Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag flag)
        {
            if (flag.State == 0)
            {
                flag.State = 2;
                return true;
            }
            else if (flag.State == 2)
            {
                throw new Microsoft.VisualBasic.CompilerServices.IncompleteInitialization();
            }
            else
            {
                return false;
            }
        }
    }
}
