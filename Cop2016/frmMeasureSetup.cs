using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using Telerik.WinControls.UI;
using System.Data.SqlClient;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmMeasureSetup : RadForm
    {
        //LDW private bool blnDragging;
        RadTreeNode gnodDragNode = new RadTreeNode();
        readonly Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag static_sstabMeasureList_SelectedIndexChanged_PreviousTab_Init = new Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag();
        int static_sstabMeasureList_SelectedIndexChanged_PreviousTab;


        public frmMeasureSetup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                MoveField((false));
                SaveChanges();
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

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                MoveField((true));
                SaveChanges();
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

        private void MoveField(bool Up)
        {
            int li_cnt = 0;
            int li_temp_val;
            int li_prev = 0;
            string ls_temp_field = null;
            int li_start;
            int li_end;
            int li_step = 0;

            try
            {
                if (lstSelectedFieldList.SelectedItems.Count > 0)
                {
                    if (Up)
                    {
                        li_start = 0;
                        li_end = lstSelectedFieldList.Items.Count - 1;
                        li_step = 1;
                    }
                    else
                    {
                        li_start = lstSelectedFieldList.Items.Count - 1;
                        li_end = 0;
                        li_step = -1;
                    }

                    for (li_cnt = li_start; li_cnt <= li_end; li_cnt += li_step)
                    {
                        if (lstSelectedFieldList.SelectedIndex == li_cnt == true & ((Up == true & li_cnt > 0) | (Up == false & li_cnt < lstSelectedFieldList.Items.Count - 1)))
                        {
                            if (Up)
                            {
                                li_prev = li_cnt - 1;
                            }
                            else
                            {
                                li_prev = li_cnt + 1;
                            }

                            ls_temp_field = Support.GetItemString(lstSelectedFieldList, li_prev);
                            li_temp_val = Support.GetItemData(lstSelectedFieldList, li_prev);

                            Support.SetItemString(lstSelectedFieldList, li_prev, Support.GetItemString(lstSelectedFieldList, li_cnt));
                            Support.SetItemData(lstSelectedFieldList, li_prev, Support.GetItemData(lstSelectedFieldList, li_cnt));

                            Support.SetItemString(lstSelectedFieldList, li_cnt, ls_temp_field);
                            Support.SetItemData(lstSelectedFieldList, li_cnt, li_temp_val);

                            /*LDW lstSelectedFieldList.SetSelected(li_cnt, false);
                            lstSelectedFieldList.SetSelected(li_prev, true);*/
                            lstSelectedFieldList.SelectedIndex = li_cnt;
                            lstSelectedFieldList.SelectedItem.Active = false;
                            lstSelectedFieldList.SelectedIndex = li_prev;
                            lstSelectedFieldList.SelectedItem.Active = true;
                        }
                    }

                    ReNumberSelected();
                }
                else
                {
                    RadMessageBox.Show("Please select a field to move", "No Field Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
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

        private void cboMeasure_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                modGlobal.gv_sql = string.Format("SELECT * FROM tbl_Setup_FieldMeasureSet fm, tbl_Setup_DataDef dd  WHERE dd.DDID = fm.DDID AND fm.MeasureSetID " +
                    "= {0} AND fm.RecordStatus = '{1}' ORDER BY fm.OrderID", Support.GetItemData(cboMeasure, cboMeasure.SelectedIndex), modGlobal.gv_status);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_Setup_FieldMeasureSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                lstSelectedFieldList.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    lstSelectedFieldList.Items.Add(new ListBoxItem((Convert.ToInt16(myRow1.Field<string>("OrderID")) + 3) + ". " +
                        myRow1.Field<string>("FieldName"), myRow1.Field<int>("DDID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                modGlobal.gv_rs.Dispose();
                RefreshFieldList();

                return;
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
            //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void cmdAddField_Click(object sender, EventArgs e)
        {
            int li_cnt;
            int li_list = 0;

            try
            {
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

                        if ((lstAvailableFieldList.SelectedIndex == li_cnt) == true)
                        {
                            lstSelectedFieldList.Items.Add(new ListBoxItem(lstSelectedFieldList.Items.Count + 1 + ". " +
                                Support.GetItemString(lstAvailableFieldList, li_cnt), Support.GetItemData(lstAvailableFieldList, li_cnt)).ToString());

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

        private void ReNumberSelected()
        {
            int li_cnt = 0;
            string ls_field = null;

            try
            {
                for (li_cnt = 0; li_cnt <= lstSelectedFieldList.Items.Count - 1; li_cnt++)
                {
                    ls_field = Support.GetItemString(lstSelectedFieldList, li_cnt);
                    ls_field = Strings.Trim(Strings.Right(ls_field, Strings.Len(ls_field) - Strings.InStr(ls_field, ".")));

                    Support.SetItemString(lstSelectedFieldList, li_cnt, (li_cnt + 3) + ". " + ls_field);
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

        private void cmdAddRelated_Click(object sender, EventArgs e)
        {
            int li_cnt = 0;
            RadTreeNode nodTarget = new RadTreeNode();
            int li_FieldGroupID = 0;
            RadTreeNode nodNode = new RadTreeNode();


            try
            {
                // ERROR: Not supported in C#: OnErrorStatement


                if ((trvGroupedFields.SelectedNode != null))
                {

                    nodTarget = trvGroupedFields.SelectedNode;

                    li_FieldGroupID = ((Strings.InStr(1, nodTarget.Name, "FGID") + 4) > 0 ? Convert.ToInt32(Strings.Mid(nodTarget.Name,
                        Strings.InStr(1, nodTarget.Name, "FGID")) + 4, Strings.Len(nodTarget.Name)) : 0);

                    if (li_FieldGroupID > 0)
                    {
                        for (li_cnt = 0; li_cnt <= lstRelatedFields.Items.Count - 1; li_cnt++)
                        {
                            if (lstRelatedFields.SelectedIndex == li_cnt)
                            {
                                //LDW nodNode = trvGroupedFields.Nodes.Find(nodTarget.Name, true)[0].Nodes.Add("DDID" + Support.GetItemData(lstRelatedFields, li_cnt), Support.GetItemString(lstRelatedFields, li_cnt));
                                nodNode = trvGroupedFields.Nodes.TreeView.Find(nodTarget.Name).Nodes.Add("DDID" + Support.GetItemData(lstRelatedFields, li_cnt), Support.GetItemString(lstRelatedFields, li_cnt));
                                nodNode.EnsureVisible();

                                modGlobal.gv_sql = "INSERT INTO tbl_Setup_DDIDFieldGroup (DDID, FieldGroupID) ";
                                modGlobal.gv_sql = string.Format("{0} VALUES ({1}, {2})", modGlobal.gv_sql, Support.GetItemData(lstRelatedFields, li_cnt), li_FieldGroupID);

                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                            }
                        }
                    }
                    else
                    {
                        RadMessageBox.Show("Please choose the group and not the item to add to", "Item Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }

                }
                else
                {
                    RadMessageBox.Show("Select a group to add the fields to.", "No Field Group Selected", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                return;
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
            //LDW ErrHandler:

            //LDW modGlobal.CheckForErrors();
        }

        private void cmdAddSimilarFields_Click(object sender, EventArgs e)
        {
            int li_cnt = 0;
            RadTreeNode nodTarget = new RadTreeNode();
            int li_FieldGroupID = 0;
            RadTreeNode nodNode = new RadTreeNode();


            try
            {
                if ((trvRelatedFields.SelectedNode != null))
                {
                    nodTarget = trvRelatedFields.SelectedNode;

                    li_FieldGroupID = ((Strings.InStr(1, nodTarget.Name, "FGID") + 4) > 0 ? Convert.ToInt32(Strings.Mid(nodTarget.Name,
                        Strings.InStr(1, nodTarget.Name, "FGID")) + 4, Strings.Len(nodTarget.Name)) : 0);

                    if (li_FieldGroupID > 0)
                    {
                        for (li_cnt = 0; li_cnt <= lstRelatedGroupFields.Items.Count - 1; li_cnt++)
                        {
                            if (lstRelatedGroupFields.SelectedIndex == li_cnt)
                            {
                                nodNode = trvRelatedFields.Nodes.TreeView.Find(nodTarget.Name).Nodes.Add("DDID" +
                                    Support.GetItemData(lstRelatedGroupFields, li_cnt), Support.GetItemString(lstRelatedGroupFields, li_cnt));
                                nodNode.EnsureVisible();


                                modGlobal.gv_sql = "INSERT INTO tbl_Setup_DDIDRelatedFieldGroup (DDID, RelatedFieldGroupID) ";
                                modGlobal.gv_sql = string.Format("{0} VALUES ({1}, {2})", modGlobal.gv_sql, Support.GetItemData(lstRelatedGroupFields, li_cnt), li_FieldGroupID);

                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                            }
                        }
                    }
                    else
                    {
                        RadMessageBox.Show("Please choose the group and not the item to add to", "Item Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
                else
                {
                    RadMessageBox.Show("Select a group to add the fields to.", "No Field Group Selected", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                return;
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
            //LDW ErrHandler:

            //LDW modGlobal.CheckForErrors();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (RadMessageBox.Show("Are you sure you want to delete all these items?", "Confirm Delete?", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    lstSelectedFieldList.Items.Clear();
                    SaveChanges();
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

        private void cmdCreateGroup_Click(object sender, EventArgs e)
        {
            SqlCommand ps = new SqlCommand();

            try
            {

                if (!string.IsNullOrEmpty(txtNewGroup.Text))
                {
                    modGlobal.gv_sql = "{ ? = call CreateFieldGroup(?) }";
                    /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                    ps.rdoParameters[0].Direction = RDO.DirectionConstants.rdParamReturnValue;
                    ps.rdoParameters[1].Direction = RDO.DirectionConstants.rdParamInput;
                    ps.rdoParameters[1) = txtNewGroup.Text;

                    ps.Execute();
                    ps.Close();*/
                    ps.Connection = modGlobal.gv_cn;
                    ps.CommandType = CommandType.StoredProcedure;
                    ps.CommandText = "CreateFieldGroup";
                    var inParam1 = new SqlParameter("@FieldGroupName", txtNewGroup.Text);
                    inParam1.Direction = ParameterDirection.Input;
                    inParam1.DbType = DbType.String;
                    ps.Parameters.Add(inParam1);
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

                    RadMessageBox.Show("Group Successfully Created");
                    txtNewGroup.Text = "";

                    RefreshGroupFields();
                }
                else
                {
                    RadMessageBox.Show("Please enter a name for the group");
                }
                return;
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
            //LDW ErrHandler:

            //LDW modGlobal.CheckForErrors();
        }


        private void cmdCreateRelatedGroup_Click(object sender, EventArgs e)
        {
            SqlCommand ps = new SqlCommand();

            try
            {
                if (!string.IsNullOrEmpty(txtNewRelatedGroup.Text))
                {
                    modGlobal.gv_sql = "{ ? = call CreateRelatedFieldGroup(?) }";
                    /* LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                    ps.rdoParameters[0].Direction = RDO.DirectionConstants.rdParamReturnValue;
                    ps.rdoParameters[1].Direction = RDO.DirectionConstants.rdParamInput;
                    ps.rdoParameters[1) = txtNewRelatedGroup.Text;

                    ps.Execute();
                    ps.Close();*/
                    ps.Connection = modGlobal.gv_cn;
                    ps.CommandType = CommandType.StoredProcedure;
                    ps.CommandText = "CreateRelatedFieldGroup";
                    var inParam1 = new SqlParameter("@FieldGroupName", txtNewRelatedGroup.Text);
                    inParam1.Direction = ParameterDirection.Input;
                    inParam1.DbType = DbType.String;
                    ps.Parameters.Add(inParam1);
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

                    RadMessageBox.Show("Group Successfully Created");
                    txtNewRelatedGroup.Text = "";

                    RefreshRelatedGroupFields();
                }
                else
                {
                    RadMessageBox.Show("Please enter a name for the group");
                }
                return;
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
            //LDW ErrHandler:

            //LDW modGlobal.CheckForErrors();
        }

        private void cmdRemoveField_Click(object sender, EventArgs e)
        {
            string ls_field = null;
            int li_cnt;
            int li_list = 0;
            int counter = 0;


            try
            {
                if (lstSelectedFieldList.SelectedItems.Count > 0)
                {
                    li_list = lstSelectedFieldList.Items.Count - 1;

                    counter = li_list;
                    for (li_cnt = counter; li_cnt >= 0; li_cnt += -1)
                    {
                        if (li_cnt > li_list)
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }

                        if (lstSelectedFieldList.SelectedIndex == li_cnt == true)
                        {
                            ls_field = Support.GetItemString(lstSelectedFieldList, li_cnt);
                            ls_field = Strings.Trim(Strings.Right(ls_field, Strings.Len(ls_field) - Strings.InStr(ls_field, ".")));

                            lstAvailableFieldList.Items.Add(new ListBoxItem(ls_field, Support.GetItemData(lstSelectedFieldList, li_cnt)).ToString());
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
            //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void frmMeasureSetup_Load(object sender, EventArgs e)
        {
            try
            {
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

                //LDW sstabMeasureList.SelectedIndex = 0;
                sstabMeasureList.ActiveWindow = sstabMeasureList0;
                sstabMeasureList.Enabled = true;
                //LDW sstabMeasureSpec.SelectedIndex = 0;
                //LDW sstabMeasureSpec.Enabled = true;
                return;
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
            //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                SaveChanges();
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

        private void RefreshFieldList()
        {
            int ll_ind = -1;
            DataSet rs_group = new DataSet();


            try
            {
                // ERROR: Not supported in C#: OnErrorStatement
                //retrieve the list of patient table fields
                modGlobal.gv_sql = "Select * from tbl_setup_DataDef where BaseTableID = (SELECT BaseTableID FROM tbl_setup_TableDef " + " where BaseTable = 'PATIENT') ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and State = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldCategory desc, FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName7 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);
                lstAvailableFieldList.Items.Clear();
                trvAvailGroupFields.Nodes.Clear();

                var _with1 = trvAvailFields.Nodes;

                _with1.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow7 in modGlobal.gv_rs.Tables[sqlTableName7].Rows)
                {
                    ll_ind = ll_ind + 1;

                    lstAvailableFieldList.Items.Add(new ListBoxItem(myRow7.Field<string>("FieldName"), myRow7.Field<int>("DDID")).ToString());

                    modGlobal.gv_sql = "SELECT * FROM tbl_Setup_DDIDFieldGroup WHERE DDID = " + myRow7.Field<string>("DDID");
                    //LDW rs_group = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName8 = "tbl_Setup_DDIDFieldGroup";
                    rs_group = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, rs_group);

                    //LDW if (rs_group.EOF)
                    for (int itr = 0; itr < rs_group.Tables[sqlTableName8].Rows.Count; itr++)
                    {
                        var myRow8 = (DataRow)rs_group.Tables[sqlTableName8].Rows[itr];
                        int rowIndex8 = rs_group.Tables[sqlTableName8].Rows.IndexOf(myRow8);
                        if (rowIndex8 == rs_group.Tables[sqlTableName8].Rows.Count - 1)
                        {
                            _with1.Add(myRow7.Field<string>("FieldName"));
                            //LDW _with1.Items(_with1.Count).Name = "DDID" + Convert.ToString(myRow7.Field<string>("DDID"));
                            _with1.TreeView.Name = "DDID " + myRow7.Field<string>("DDID");

                            trvAvailGroupFields.Nodes.Add(myRow7.Field<string>("FieldName"));
                            trvAvailGroupFields.Nodes[_with1.Count].Name = "DDID" + Convert.ToString(myRow7.Field<string>("DDID"));
                        }
                    }
                    rs_group.Dispose();

                    //LDW modGlobal.gv_rs.MoveNext();
                }


                Application.DoEvents();
                modGlobal.gv_rs.Dispose();
                RemoveSelected();

                return;
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
            //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void lstAvailableFieldList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                cmdAddField_Click(cmdAddField, new EventArgs());
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

        private void SaveChanges()
        {
            int li_cnt = 0;

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (cboMeasure.SelectedIndex == -1)
                {
                    RadMessageBox.Show("You must select a Measure Set to Save", "No Measure Set Selected.", MessageBoxButtons.OK, RadMessageIcon.Error);
                    return;
                }

                modGlobal.gv_sql = "DELETE FROM tbl_Setup_FieldMeasureSet WHERE MeasureSetID = " + Support.GetItemData(cboMeasure, cboMeasure.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                for (li_cnt = 0; li_cnt <= lstSelectedFieldList.Items.Count - 1; li_cnt++)
                {
                    modGlobal.gv_sql = string.Format("INSERT INTO tbl_Setup_FieldMeasureSet (DDID, MeasureSetID, OrderID, RecordStatus) VALUES ({0}, {1}, {2}, '{3}')",
                        Support.GetItemData(lstSelectedFieldList, li_cnt), Support.GetItemData(cboMeasure, cboMeasure.SelectedIndex), li_cnt, modGlobal.gv_status);

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }

                RefreshFieldList();

                return;
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
            //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void RemoveSelected()
        {
            int li_cnt;
            int li_lst = 0;
            int li_found = 0;


            try
            {
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


        private void cmdEdit0_Click(object sender, EventArgs e)
        {
            //LDW int Index = cmdEdit.GetIndex(eventSender);
            int ThisSID;
            int i = 0;
            string EditSet = null;


            try
            {
                if (string.IsNullOrEmpty(cboMeasureSet.Text))
                {
                    RadMessageBox.Show("Please select a set from the list.");
                    return;
                }

                ThisSID = Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex);
                EditSet = RadInputBox.Show("Edit the Set Description.", "Edit Set", cboMeasureSet.Text);

                if (!string.IsNullOrEmpty(EditSet))
                {
                    modGlobal.gv_sql = string.Format("Update tbl_setup_measureset set MeasureSetDesc = '{0}'", EditSet);
                    modGlobal.gv_sql = string.Format("{0} where MeasureSetID = {1}", modGlobal.gv_sql, Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    RefreshMeasureSet();
                    cboMeasureSet.Text = EditSet;
                    //set the selected list item to the new one
                    for (i = 0; i <= cboMeasureSet.Items.Count - 1; i++)
                    {
                        if (Support.GetItemData(cboMeasureSet, i) == ThisSID)
                        {
                            cboMeasureSet.SelectedIndex = i;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
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

        private void cmdEdit1_Click(object sender, EventArgs e)
        {
            dlgCreateCat dlgCreateCatCopy = new dlgCreateCat();
            int li_cnt = 0;
            string ls_catID = null;


            try
            {
                if (lstMeasureCat.SelectedItems.Count == 1)
                {
                    for (li_cnt = 0; li_cnt <= lstMeasureCat.Items.Count - 1; li_cnt++)
                    {
                        if (lstMeasureCat.SelectedIndex == li_cnt)
                        {
                            ls_catID = Convert.ToString(Support.GetItemData(lstMeasureCat, li_cnt));
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                    dlgCreateCatCopy.Setii_CatID(ls_catID);
                    dlgCreateCatCopy.ShowDialog();

                    RefreshMeasureCat();
                }
                else
                {
                    RadMessageBox.Show("Please Choose a Category to Edit", "No Category Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
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

        private void cmdNew0_Click(object sender, EventArgs e)
        {
            string newset = null;

            try
            {
                newset = RadInputBox.Show("Please enter the description of the new Measure Set:", "Add New Set", "");
                if (string.IsNullOrEmpty(newset))
                {
                    return;
                }

                modGlobal.gv_sql = "Insert into  tbl_setup_MeasureSet (MeasureSetDesc, State, RecordStatus) ";
                modGlobal.gv_sql = string.Format("{0} Values ('{1}',", modGlobal.gv_sql, newset);
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshMeasureSet();
                RefreshMeasureSets();
                cboMeasureSet.SelectedIndex = -1;
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

        private void cmdNew1_Click(object sender, EventArgs e)
        {
            dlgCreateCat dlgCreateCatCopy = new dlgCreateCat();

            try
            {
                dlgCreateCatCopy.Setii_CatID("");
                dlgCreateCatCopy.ShowDialog();
                RefreshMeasureCat();
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

        private void cmdAddMeasureToSet_Click(object sender, EventArgs e)
        {
            frmMeasureAddToSet frmMeasureAddToSetCopy = new frmMeasureAddToSet();
            try
            {
                frmMeasureAddToSetCopy.ShowDialog();
                RefreshMeasureSets();
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

        private void cmdRemoveMeasureFromSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstMeasureSet.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "Delete tbl_setup_MeasureSetMapMeas ";
                modGlobal.gv_sql = string.Format("{0} Where MeaslinkID =  {1}", modGlobal.gv_sql, Support.GetItemData(lstMeasureSet, lstMeasureSet.SelectedIndex));

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshMeasureSetField();
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

        public void RefreshMeasureSetField()
        {
            try
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
                    modGlobal.gv_sql = string.Format("{0} and tbl_setup_MeasureSetMapMeas.MeasureSetID  = {1}", modGlobal.gv_sql, Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex));
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName5 = "tbl_setup_indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                lstMeasureSet.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow5 in modGlobal.gv_rs.Tables[sqlTableName5].Rows)
                {
                    lstMeasureSet.Items.Add(new ListBoxItem(myRow5.Field<string>("Description"), myRow5.Field<int>("measLinkID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();
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

        private void RefreshMeasureCat()
        {
            //LDW object Categories = null;
            //IList<CategoriesItems> Categories = new List<CategoriesItems>(); 
            int li_cnt = 0;
            int li_rows = 0;


            try
            {
                modGlobal.gv_sql = "SELECT * FROM tbl_MEASURE_CAT";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName6 = "tbl_MEASURE_CAT";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);
                string[] categoryItemsArray = new string[] { modGlobal.gv_rs.Tables[sqlTableName6].Rows[li_rows].ToString() };
                List<string> categoryItems = new List<string>(categoryItemsArray);

                //LDW if (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow6 in modGlobal.gv_rs.Tables[sqlTableName6].Rows)
                {
                    li_rows = modGlobal.gv_rs.Tables[sqlTableName6].Rows.Count;
                    //LDW Categories = modGlobal.gv_rs.GetRows(li_rows);
                    List<string> Categories = categoryItems;
                    modGlobal.gv_rs.Dispose();

                    lstMeasureCat.Items.Clear();

                    for (li_cnt = 0; li_cnt <= li_rows - 1; li_cnt++)
                    {
                        //LDW lstMeasureCat.Items.Add(new ListBoxItem(Categories(1, li_cnt) + " - " + Categories(2, li_cnt), Categories(0, li_cnt)));
                        lstMeasureCat.Items.Add(new ListBoxItem(Categories.GetRange(1, li_cnt) + " - " + Categories.GetRange(2, li_cnt), Convert.ToInt32(Categories.GetRange(0, li_cnt))).ToString());
                    }
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

        private void cboMeasureSet_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            RefreshMeasureSetField();
        }

        //LDW Work around for vb6 control arrays.  Make new button for each array item.
        private void cmdChangeStatus0_Click(object sender, EventArgs e)
        {
            string MoveToModule = null;
            DialogResult resp = default(DialogResult);


            try
            {
                if (cboMeasureSet.SelectedIndex < 0)
                {
                    return;
                }

                MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
                resp = RadMessageBox.Show("Are you sure you want this Measure set to the " + MoveToModule + " Module?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Update tbl_setup_measureset ";
                modGlobal.gv_sql = string.Format("{0}  Set RecordStatus =  {1}", modGlobal.gv_sql, modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                modGlobal.gv_sql = string.Format("{0} where MeasureSetID = {1}", modGlobal.gv_sql, Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshMeasureSet();
                RefreshMeasureSetField();
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

        private void cmdChangeStatus1_Click(object sender, EventArgs e)
        {
            string MoveToModule = null;
            DialogResult resp = default(DialogResult);

            try
            {
                if (cboMeasureSet.SelectedIndex < 0)
                {
                    return;
                }

                MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
                resp = RadMessageBox.Show("Are you sure you want this Measure set to the " + MoveToModule + " Module?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Update tbl_setup_measureset ";
                modGlobal.gv_sql = string.Format("{0}  Set RecordStatus =  {1}", modGlobal.gv_sql, modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                modGlobal.gv_sql = string.Format("{0} where MeasureSetID = {1}", modGlobal.gv_sql, Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshMeasureSet();
                RefreshMeasureSetField();
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

        private void cmdChangeStatus2_Click(object sender, EventArgs e)
        {
            string MoveToModule = null;
            DialogResult resp = default(DialogResult);


            try
            {
                if (cboMeasure.SelectedIndex < 0)
                {
                    return;
                }

                MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
                resp = RadMessageBox.Show("Are you sure you want this report to the " + MoveToModule + " Module?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Update tbl_Setup_FieldMeasureSet ";
                modGlobal.gv_sql = string.Format("{0}  Set RecordStatus =  {1}", modGlobal.gv_sql, modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                modGlobal.gv_sql = string.Format("{0} where MeasureSetID = {1}", modGlobal.gv_sql, Support.GetItemData(cboMeasure, cboMeasure.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //LDW sstabMeasureSpec.SelectedIndex = 0;
                //LDW sstabMeasureSpec.Enabled = false;
                sstabMeasureList.ActiveWindow = sstabMeasureList0;
                sstabMeasureList.Enabled = true;
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

        private void cmdDelete0_Click(object sender, EventArgs e)
        {
            int li_cnt = 0;
            DataSet rs_MeasureStep = new DataSet();


            try
            {
                if (cboMeasureSet.SelectedIndex < 0)
                {
                    return;
                }

                if (RadMessageBox.Show("Are you sure you'd like to delete this measure set and all it's data?", "Delete Measure Set?", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    //get measure id to delete from criteria tables
                    modGlobal.gv_sql = "SELECT * FROM tbl_setup_MeasureSetMapMeas ";
                    modGlobal.gv_sql = string.Format("{0}  where MeasureSetID = {1}", modGlobal.gv_sql, Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                    const string sqlTableName9 = "tbl_setup_MeasureSetMapMeas";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow9 in modGlobal.gv_rs.Tables[sqlTableName9].Rows)
                    {
                        string SQL = "SELECT * FROM tbl_Setup_MeasureStep WHERE MeasureID = " + myRow9.Field<int>("IndicatorID");
                        //LDW rs_MeasureStep = modGlobal.gv_cn.OpenResultset("SELECT * FROM tbl_Setup_MeasureStep WHERE MeasureID = " + myRow11.Field<string>("IndicatorID"), RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                        const string sqlTableName10 = "tbl_Setup_MeasureStep";
                        rs_MeasureStep = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, rs_MeasureStep);

                        //LDW while (!rs_MeasureStep.EOF)
                        foreach (DataRow myRow10 in modGlobal.gv_rs.Tables[sqlTableName10].Rows)
                        {
                            modGlobal.gv_sql = string.Format("DELETE FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaSetID in  (SELECT MeasureCriteriaSetID FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureStepID = {0})", myRow10.Field<int>("MeasureStepID"));
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            modGlobal.gv_sql = "DELETE from tbl_Setup_MeasureCriteriaSet WHERE MeasureStepID = " + myRow10.Field<int>("MeasureStepID");
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                            //LDW rs_MeasureStep.Delete();
                            rs_MeasureStep.Clear();
                            //LDW rs_MeasureStep.MoveNext();
                        }

                        rs_MeasureStep.Dispose();
                        //LDW modGlobal.gv_rs.Delete();
                        modGlobal.gv_rs.Clear();
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                    modGlobal.gv_rs.Dispose();

                    //delete measure set mappings
                    modGlobal.gv_sql = "Delete tbl_Setup_FieldMeasureSet WHERE MeasureSetID = " + Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //delete measure set
                    modGlobal.gv_sql = "Delete tbl_setup_measureset ";
                    modGlobal.gv_sql = string.Format("{0}  where MeasureSetID = {1}", modGlobal.gv_sql, Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshMeasureSet();
                    RefreshMeasureSets();
                    cboMeasureSet.SelectedIndex = -1;
                    RefreshMeasureSetField();
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
            //LDW modGlobal.CheckForErrors();
        }

        private void cmdDelete1_Click(object sender, EventArgs e)
        {
            int li_cnt = 0;
            string ls_catID = null;

            try
            {
                if (lstMeasureCat.SelectedItems.Count == 1)
                {
                    for (li_cnt = 0; li_cnt <= lstMeasureCat.Items.Count - 1; li_cnt++)
                    {
                        if (lstMeasureCat.SelectedIndex == li_cnt)
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
                    RadMessageBox.Show("Please Choose a Category to Edit", "No Category Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
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
            //LDW modGlobal.CheckForErrors();
        }

        public void RefreshMeasureSet()
        {
            string setdesc = null;

            try
            {
                modGlobal.gv_sql = "Select * from tbl_setup_measureset ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} Where State = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by MeasureSetDesc ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName11 = "tbl_setup_measureset";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);

                cboMeasureSet.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow11 in modGlobal.gv_rs.Tables[sqlTableName11].Rows)
                {
                    if (Information.IsDBNull(myRow11.Field<string>("EffDate")))
                    {
                        setdesc = myRow11.Field<string>("MeasureSetDesc");
                    }
                    else
                    {
                        setdesc = string.Format("{0} ({1})", myRow11.Field<string>("MeasureSetDesc"), myRow11.Field<string>("EffDate"));
                    }
                    cboMeasureSet.Items.Add(new ListBoxItem(setdesc, myRow11.Field<int>("MeasureSetID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                modGlobal.gv_rs.Dispose();
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

        private void RefreshMeasureSets()
        {
            int ll_ind = -1;


            try
            {
                // ERROR: Not supported in C#: OnErrorStatement

                //retrieve the list of Indicators
                modGlobal.gv_sql = "Select MeasureSetDesc, MeasureSetID from tbl_setup_MeasureSet ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} Where State = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by 1 ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName12 = "tbl_setup_MeasureSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);

                cboMeasure.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow12 in modGlobal.gv_rs.Tables[sqlTableName12].Rows)
                {
                    ll_ind = ll_ind + 1;

                    cboMeasure.Items.Add(myRow12.Field<string>("MeasureSetDesc"));

                    Support.SetItemData(cboMeasure, cboMeasure.Items.Count - 1, myRow12.Field<int>("MeasureSetID"));
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                modGlobal.gv_rs.Dispose();

                return;
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
            //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void RefreshRelatedGroupFields()
        {
            DataSet rs_DDIDFieldGroup = new DataSet();
            RadTreeNode nodParent = new RadTreeNode();


            try
            {
                var _with2 = trvRelatedFields.Nodes;

                _with2.Clear();

                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_RelatedFieldGroup ORDER BY RelatedGroupName";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName13 = "tbl_Setup_RelatedFieldGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow13 in modGlobal.gv_rs.Tables[sqlTableName13].Rows)
                {
                    nodParent = _with2.Add(myRow13.Field<string>("RelatedGroupName"));
                    nodParent.Name = "FGID" + Convert.ToString(myRow13.Field<string>("RelatedFieldGroupID"));

                    modGlobal.gv_sql = "SELECT dd.DDID, dd.FieldName FROM tbl_Setup_DDIDRelatedFieldGroup fg, tbl_Setup_DataDef dd WHERE dd.DDID = fg.DDID AND RelatedFieldGroupID = "
                        + myRow13.Field<string>("RelatedFieldGroupID");

                    //LDW rs_DDIDFieldGroup = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName14 = "tbl_Setup_DDIDRelatedFieldGroup";
                    rs_DDIDFieldGroup = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, rs_DDIDFieldGroup);
                    //LDW while (!rs_DDIDFieldGroup.EOF)
                    foreach (DataRow myRow14 in rs_DDIDFieldGroup.Tables[sqlTableName14].Rows)
                    {
                        //LDW _with2.Find(nodParent.Name, true)(0).Nodes.Add("DDID" + myRow15.Field<string>("DDID"), myRow15.Field<string>("FieldName"));
                        _with2.TreeView.Find(nodParent.Name).Nodes.Add("DDID" + myRow14.Field<string>("DDID"), myRow14.Field<string>("FieldName"));
                        //LDW rs_DDIDFieldGroup.MoveNext();
                    }
                    nodParent.EnsureVisible();

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                modGlobal.gv_rs.Dispose();
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

        private void RefreshGroupFields()
        {
            DataSet rs_DDIDFieldGroup = new DataSet();
            RadTreeNode nodParent = new RadTreeNode();


            try
            {
                var _with3 = trvGroupedFields.Nodes;
                _with3.Clear();

                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_FieldGroup ORDER BY FieldGroupName";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName15 = "tbl_Setup_FieldGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName15, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow15 in modGlobal.gv_rs.Tables[sqlTableName15].Rows)
                {
                    nodParent = _with3.Add(myRow15.Field<string>("FIELDGROUPNAME"));
                    nodParent.Name = "FGID" + Convert.ToString(myRow15.Field<string>("FIELDGroupID"));

                    modGlobal.gv_sql = "SELECT dd.DDID, dd.FieldName FROM tbl_Setup_DDIDFieldGroup fg, tbl_Setup_DataDef dd WHERE dd.DDID = fg.DDID AND FieldGroupID = " + myRow15.Field<string>("FIELDGroupID");

                    //LDW rs_DDIDFieldGroup = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName16 = "tbl_Setup_DDIDFieldGroup";
                    rs_DDIDFieldGroup = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName16, rs_DDIDFieldGroup);
                    //LDW while (!rs_DDIDFieldGroup.EOF)
                    foreach (DataRow myRow16 in modGlobal.gv_rs.Tables[sqlTableName16].Rows)
                    {
                        _with3.TreeView.Find(nodParent.Name).Nodes.Add("DDID" + myRow15.Field<string>("DDID"), myRow15.Field<string>("FieldName"));
                        //LDW rs_DDIDFieldGroup.MoveNext();
                    }
                    nodParent.EnsureVisible();

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                modGlobal.gv_rs.Dispose();
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

        private void RefreshChangeFieldList(string FieldName)
        {
            string[] ls_Parts = null;
            string ls_Part1 = null;
            string ls_Part2 = null;
            RadListControl lstControl = new RadListControl();


            try
            {
                ls_Parts = Strings.Split(FieldName + " ", " ");
                ls_Part1 = ls_Parts[0];

                //LDW if (sstabMeasureList.SelectedIndex == 3)
                if (sstabMeasureList.ActiveWindow == sstabMeasureList2)
                {
                    if (Information.UBound(ls_Parts) > 2)
                    {
                        ls_Part2 = ls_Parts[2];
                    }

                    lstControl = lstRelatedFields;
                    modGlobal.gv_sql = string.Format("SELECT DDID, FieldName FROM tbl_Setup_DataDef WHERE FieldName like '{0}%{1}%'  AND FieldType = " +
                        "(SELECT FieldType FROM tbl_Setup_DataDef WHERE FieldName = '{2}') ORDER BY FieldName", ls_Part1, ls_Part2, FieldName);
                }
                else
                {
                    if (Information.UBound(ls_Parts) > 1)
                    {
                        ls_Part2 = ls_Parts[1];
                    }

                    lstControl = lstRelatedGroupFields;
                    modGlobal.gv_sql = string.Format("SELECT DDID, FieldName FROM tbl_Setup_DataDef WHERE FieldName like '{0} {1}%'  ORDER BY FieldName", ls_Part1, ls_Part2);
                }


                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName16 = "tbl_Setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName16, modGlobal.gv_rs);

                var _with4 = lstControl;
                _with4.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow16 in modGlobal.gv_rs.Tables[sqlTableName16].Rows)
                {
                    _with4.Items.Add(new ListBoxItem(myRow16.Field<string>("FieldName"), myRow16.Field<int>("DDID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }


                lstControl = null;

                modGlobal.gv_rs.Dispose();
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



        private void sstabMeasureList_SelectedTabChanged(object sender, Telerik.WinControls.UI.Docking.SelectedTabChangedEventArgs e)
        {
            int indexInChildren = sstabMeasureList.ActiveWindow.DockTabStrip.SelectedIndex;
            try
            {
                lock (static_sstabMeasureList_SelectedIndexChanged_PreviousTab_Init)
                {
                    try
                    {
                        if (InitStaticVariableHelper(static_sstabMeasureList_SelectedIndexChanged_PreviousTab_Init))
                        {
                            static_sstabMeasureList_SelectedIndexChanged_PreviousTab = indexInChildren;
                        }
                    }
                    finally
                    {
                        static_sstabMeasureList_SelectedIndexChanged_PreviousTab_Init.State = 1;
                    }
                }

                gnodDragNode = null;

                static_sstabMeasureList_SelectedIndexChanged_PreviousTab = indexInChildren;
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

        private void trvAvailFields_Click(object sender, EventArgs e)
        {
            try
            {
                if ((trvAvailFields.SelectedNode != null))
                {
                    RefreshChangeFieldList((trvAvailFields.SelectedNode.Text));
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

        private void trvAvailFields_NodeMouseDown(object sender, RadTreeViewMouseEventArgs e)
        {
            try
            {
                /*LDW short Button = eventArgs.Button / 0x100000;
                short Shift = Control.ModifierKeys / 0x10000;
                float X = Support.PixelsToTwipsX(eventArgs.X);
                float Y = Support.PixelsToTwipsY(eventArgs.Y);*/
                int Button = Convert.ToInt32(e.OriginalEventArgs.Button) / 0x100000;
                int Shift = Convert.ToInt32(Control.ModifierKeys) / 0x10000;
                float X = Convert.ToInt64(Support.PixelsToTwipsX(e.OriginalEventArgs.X));
                float Y = Convert.ToInt64(Support.PixelsToTwipsY(e.OriginalEventArgs.Y));

                //// get the node we are over
                //LDW gnodDragNode = trvAvailFields.GetNodeAt(X, Y);
                gnodDragNode = trvAvailFields.GetNodeAt(Convert.ToInt32(X), Convert.ToInt32(Y));
                if (gnodDragNode == null)
                    return;
                //// no node

                //// ensure node is actually selected, just incase we start dragging.
                gnodDragNode.Selected = true;
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

        private void trvAvailGroupFields_Click(object sender, EventArgs e)
        {
            try
            {
                if ((trvAvailGroupFields.SelectedNode != null))
                {
                    RefreshChangeFieldList((trvAvailGroupFields.SelectedNode.Text));
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

        private void trvAvailGroupFields_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int Button = Convert.ToInt32(e.Button) / 0x100000;
                int Shift = Convert.ToInt32(Control.ModifierKeys) / 0x10000;
                float X = Convert.ToInt64(Support.PixelsToTwipsX(e.X));
                float Y = Convert.ToInt64(Support.PixelsToTwipsY(e.Y));
                //// get the node we are over
                gnodDragNode = trvAvailGroupFields.GetNodeAt(Convert.ToInt32(X), Convert.ToInt32(Y));
                if (gnodDragNode == null)
                    return;
                //// no node

                //// ensure node is actually selected, just incase we start dragging.
                gnodDragNode.Selected = true;
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

        private void trvGroupedFields_Click(object sender, EventArgs e)
        {
            try
            {
                if ((trvGroupedFields.SelectedNode != null))
                {
                    gnodDragNode = trvGroupedFields.SelectedNode;
                }
                else
                {
                    gnodDragNode = null;
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

        private void trvGroupedFields_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Keys Keycode = e.KeyCode;
                int Shift = Convert.ToInt32(e.KeyData) / 0x10000;
                int li_DDID = 0;
                int li_FGID = 0;

                // ERROR: Not supported in C#: OnErrorStatement


                if (Keycode == Keys.Delete)
                {
                    li_DDID = ((Strings.InStr(1, gnodDragNode.Name, "DDID") > 0) ? Convert.ToInt32(Strings.Mid(gnodDragNode.Name, Strings.InStr(1, gnodDragNode.Name, "DDID")) + 4, Strings.Len(gnodDragNode.Name)) : 0);
                    if (li_DDID > 0)
                    {
                        if (RadMessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete?", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
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
                        if (RadMessageBox.Show("Are you sure you want to delete this group and all the related items?", "Confirm Delete?", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
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

                        //LDW trvGroupedFields.Nodes.RemoveAt(gnodDragNode.Name);
                        trvGroupedFields.Nodes.RemoveAt(gnodDragNode.Index);
                    }
                }
                return;
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
            //LDW ErrHandler:

            //LDW modGlobal.CheckForErrors();
        }

        private void trvGroupedFields_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int Button = Convert.ToInt32(e.Button) / 0x100000;
                int Shift = Convert.ToInt32(Control.ModifierKeys) / 0x10000;
                float X = Convert.ToInt64(Support.PixelsToTwipsX(e.X));
                float Y = Convert.ToInt64(Support.PixelsToTwipsY(e.Y));
                gnodDragNode = trvGroupedFields.GetNodeAt(Convert.ToInt32(X), Convert.ToInt32(Y));
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

        private bool SaveGroupedFields(RadTreeNode nodTarget)
        {
            bool functionReturnValue = false;

            int li_FieldGroupID = Convert.ToInt32(Strings.Mid(nodTarget.Name, Strings.InStr(1, nodTarget.Name, "FGID") + 4, Strings.Len(nodTarget.Name)));
            int li_DDID = Convert.ToInt32(Strings.Mid(gnodDragNode.Name, Strings.InStr(1, gnodDragNode.Name, "DDID") + 4, Strings.Len(gnodDragNode.Name)));

            try
            {
                if (nodTarget.GetNodeCount(false) > 0)
                {
                    modGlobal.gv_sql = string.Format("SELECT count(*) as SameType FROM tbl_Setup_DataDef def, tbl_Setup_DDIDFieldGroup fg where " +
                        "fg.DDID = def.DDID AND FieldType = (SELECT FieldType FROM tbl_Setup_DataDef WHERE DDID = {0})", li_DDID);

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName17 = "tbl_Setup_DataDef";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName17, modGlobal.gv_rs);

                    //LDW if (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow17 in modGlobal.gv_rs.Tables[sqlTableName17].Rows)
                    {
                        if (myRow17.Field<int>("SameType") == 0)
                        {
                            RadMessageBox.Show("This field is not the same type as the other fields listed in this group.", "Field Not Saved", MessageBoxButtons.OK, RadMessageIcon.Error);
                            functionReturnValue = false;
                            return functionReturnValue;
                        }
                    }
                    modGlobal.gv_rs.Dispose();
                }

                modGlobal.gv_sql = "INSERT INTO tbl_Setup_DDIDFieldGroup (DDID, FieldGroupID) ";
                modGlobal.gv_sql = string.Format("{0} VALUES ({1}, {2})", modGlobal.gv_sql, li_DDID, li_FieldGroupID);

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
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
            return functionReturnValue;
        }

        private void SaveRelatedFields(RadTreeNode nodTarget)
        {
            try
            {
                int li_FieldGroupID = Convert.ToInt32(Strings.Mid(nodTarget.Name, Strings.InStr(1, nodTarget.Name, "FGID") + 4, Strings.Len(nodTarget.Name)));
                int li_DDID = 0;
                li_DDID = Convert.ToInt32(Strings.Mid(gnodDragNode.Name, Strings.InStr(1, gnodDragNode.Name, "DDID") + 4, Strings.Len(gnodDragNode.Name)));

                modGlobal.gv_sql = "INSERT INTO tbl_Setup_DDIDRelatedFieldGroup (DDID, RelatedFieldGroupID) ";
                modGlobal.gv_sql = string.Format("{0} VALUES ({1}, {2})", modGlobal.gv_sql, li_DDID, li_FieldGroupID);

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
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

        private void trvRelatedFields_Click(object sender, EventArgs e)
        {
            try
            {
                if ((trvRelatedFields.SelectedNode != null))
                {
                    gnodDragNode = trvRelatedFields.SelectedNode;
                }
                else
                {
                    gnodDragNode = null;
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

        private void trvRelatedFields_KeyDown(object sender, KeyEventArgs e)
        {
            Keys Keycode = e.KeyCode;
            int Shift = Convert.ToInt32(e.KeyData) / 0x10000;
            int li_DDID = 0;
            int li_FGID = 0;

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (Keycode == Keys.Delete)
                {
                    li_DDID = (Strings.InStr(1, gnodDragNode.Name, "DDID") > 0 ? Convert.ToInt32(Strings.Mid(gnodDragNode.Name, Strings.InStr(1, gnodDragNode.Name, "DDID")) + 4, Strings.Len(gnodDragNode.Name)) : 0);
                    if (li_DDID > 0)
                    {
                        if (RadMessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete?", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
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
                        if (RadMessageBox.Show("Are you sure you want to delete this group and all the related items?", "Confirm Delete?", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
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

                        trvRelatedFields.Nodes.RemoveAt(gnodDragNode.Index);
                    }
                }

                return;
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
            //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void trvRelatedFields_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int Button = Convert.ToInt32(e.Button) / 0x100000;
                int Shift = Convert.ToInt32(Control.ModifierKeys) / 0x10000;
                float X = Convert.ToInt64(Support.PixelsToTwipsX(e.X));
                float Y = Convert.ToInt64(Support.PixelsToTwipsY(e.Y));
                gnodDragNode = trvRelatedFields.GetNodeAt(Convert.ToInt32(X), Convert.ToInt32(Y));
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

        /*LDW Not used
        private void cmdSaveMap_Click()
        {
            SaveChanges();
        }
        
        private void trvAvailFields_OLEStartDrag(ref MSComctlLib.DataObject Data, ref int AllowedEffects)
        {
            //// Set the effect to move
            AllowedEffects = DragDropEffects.Move;
            //// Assign the selected item's key to the DataObject
            Data.SetData(gnodDragNode.Name);
            //// we are dragging from this control
            blnDragging = true;
        }

        private void trvAvailGroupFields_OLEStartDrag(ref MSComctlLib.DataObject Data, ref int AllowedEffects)
        {
            //// Set the effect to move
            AllowedEffects = DragDropEffects.Move;
            //// Assign the selected item's key to the DataObject
            Data.SetData(gnodDragNode.Name);
            //// we are dragging from this control
            blnDragging = true;
        }

        private void trvGroupedFields_OLECompleteDrag(ref int Effect)
        {
            //// cancel effect so that VB doesn't muck up your transfer
            Effect = DragDropEffects.None;

        }

                private void trvGroupedFields_OLEDragDrop(ref MSComctlLib.DataObject Data, ref int Effect, ref short Button, ref short Shift, ref float X, ref float Y)
        {
            string strSourceKey = null;
            RadTreeNode nodTarget = new RadTreeNode();
            RadTreeNode nodNode = new RadTreeNode();

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
            RadTreeNode nodNode = new RadTreeNode();
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
                 private void trvRelatedFields_OLECompleteDrag(ref int Effect)
        {
            //// cancel effect so that VB doesn't muck up your transfer
            Effect = DragDropEffects.None;
        }

        //UPGRADE_ISSUE: MSComctlLib.TreeView event trvRelatedFields.OLEDragDrop was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
        private void trvRelatedFields_OLEDragDrop(ref MSComctlLib.DataObject Data, ref int Effect, ref short Button, ref short Shift, ref float X, ref float Y)
        {
            string strSourceKey = null;
            RadTreeNode nodTarget = new RadTreeNode();
            RadTreeNode nodNode = new RadTreeNode();

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
            RadTreeNode nodNode = new RadTreeNode();
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
         */


    }
}
