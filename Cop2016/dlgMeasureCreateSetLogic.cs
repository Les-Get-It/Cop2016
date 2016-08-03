using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Drawing;
using static COP2001.RadDropBinder;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Diagnostics;

namespace COP2001
{
    public partial class dlgMeasureCreateSetLogic : Telerik.WinControls.UI.RadForm
    {
        public int il_MeasureCriteriaSetID;
        private int il_MeasureSet;
        private int il_IndicatorID;
        private int il_MeasureStep;
        private int il_measureStepID;
        public DataSet rdcMeasureSet = new DataSet();
        public const string rdcMeasureSetTable = "tbl_Setup_MeasureCriteria";

        public dlgMeasureCreateSetLogic()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int li_cnt = 0;
            string ls_ReplacementCrit = null;
            int ll_SetCnt = 0;
            int ll_CritCnt = 0;
            string ls_JoinOperator = null;
            const string sqlTableName1 = "tbl_Setup_MeasureCriteriaSet";
            const string sqlTableName2 = "tbl_Setup_MeasureCriteriaCopy";


            try
            {
                if (lstDDID.SelectedItems.Count == 0)
                {
                    //LDW RadMessageBox.Show("Please select a field to replace");

                    DialogResult ds1 = RadMessageBox.Show(this, "Please select a field to replace", "Create Set Logic", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds1.ToString();
                    return;
                }

                lstReplacements.Items.Clear();


                modGlobal.gv_sql = "";
                if (OptNewCrit.IsChecked)
                {
                    if (lstReplacements.Items.Count == 0)
                        lstReplacements.Items.Add(string.Format("Step {0}:", il_MeasureStep));

                    modGlobal.gv_sql = "SELECT JoinOperator FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureCriteriaSetID = " + il_MeasureCriteriaSetID;

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                    //LDW if (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                    {
                        //LDW ls_JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
                        ls_JoinOperator = myRow1.Field<string>("JoinOperator");
                    }
                    //LDW modGlobal.gv_rs.Close();
                    modGlobal.gv_rs.Dispose();

                    for (li_cnt = 0; li_cnt <= lstDDID.Items.Count - 1; li_cnt++)
                    {
                        //LDW if (lstDDID.GetSelected(li_cnt))
                        if (lstDDID.SelectedIndex == li_cnt)
                        {
                            ls_ReplacementCrit = Strings.Replace(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["CriteriaTitle"].ToString(), txtDDID.Text, Support.GetItemString(lstDDID, li_cnt));

                            modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureCriteriaCopy (MeasureID, MeasureStepID, MeasureCriteriaSetID, CriteriaTitle, DDID1, DDID2," +
                                "ValueOperator, FieldValue, DestDDID, LookupID, FieldOperator, DateUnit, JoinOperator, LookupTableID, MeasureCriteriaSetJoinOperator) ";
                            modGlobal.gv_sql = string.Format("{0} VALUES ({1}, {2}, {3}, ", modGlobal.gv_sql, il_IndicatorID, il_measureStepID, il_MeasureCriteriaSetID);

                            modGlobal.gv_sql = modGlobal.gv_sql + "'" + ls_ReplacementCrit + "', " + (OptDDID1.IsChecked ? Support.GetItemData(lstDDID, li_cnt).ToString()
                                : (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DDID1"]) ? "Null" : rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DDID1"].ToString())) +
                                ", " + (OptDDID2.IsChecked & !Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["ddid2"]) ?
                                Support.GetItemData(lstDDID, li_cnt).ToString() : (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["ddid2"])
                                ? "Null" : rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["ddid2"].ToString())) + ", ";

                            modGlobal.gv_sql = modGlobal.gv_sql + (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["ValueOperator"]) ? "NULL" : "'" +
                                rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["ValueOperator"].ToString() + "'") + ", " +
                                (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["FIELDVALUE"]) ? "Null" : "'" +
                                rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["FIELDVALUE"].ToString() + "'") + ", ";

                            modGlobal.gv_sql = modGlobal.gv_sql + (OptDDID2.IsChecked & !Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DestDDID"]) ?
                                Support.GetItemData(lstDDID, li_cnt).ToString() : (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DestDDID"]) ?
                                "Null" : rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DestDDID"].ToString())) + ", ";


                            //modGlobal.gv_sql = string.Format("{0}, {1}, {2}, {3}", modGlobal.gv_sql, Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["LookupID"].Value) ? "Null" : rdcMeasureSet.Resultset.rdoColumns["LookupID"].Value, Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["FieldOperator"].Value) ? "Null" : string.Format("'{0}'", rdcMeasureSet.Resultset.rdoColumns["FieldOperator"].Value), Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["DateUnit"].Value) ? "Null" : string.Format("'{0}'", rdcMeasureSet.Resultset.rdoColumns["DateUnit"].Value));
                            modGlobal.gv_sql = modGlobal.gv_sql + "" + (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["LookupID"]) ?
                                "Null" : rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["LookupID"].ToString());

                            modGlobal.gv_sql = modGlobal.gv_sql + ", " + (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["FieldOperator"]) ? "Null" : "'" +
                                rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["FieldOperator"] + "'") + ", " + (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DateUnit"]) ?
                                "Null" : "'" + rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DateUnit"] + "'");

                            modGlobal.gv_sql = modGlobal.gv_sql + ", " + (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["JoinOperator"]) ? "Null" : "'" + cboSetJoinOp.Text + "'") +
                                ", " + (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["LookupTableID"]) ? "Null" :
                                rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["LookupTableID"].ToString()) + ", '" + ls_JoinOperator + "')";

                            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        }
                    }

                    modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaCopy ORDER BY MeasureCriteriaSetID";
                }
                else if (OptNewSet.IsChecked)
                {
                    if (cboSetJoinOp.SelectedIndex == -1)
                    {
                        //LDW RadMessageBox.Show("Please choose a Join Operator for each set", MsgBoxStyle.Information, "No Join Operator Selected");

                        DialogResult ds2 = RadMessageBox.Show(this, "Please choose a Join Operator for each set", "Create Set Logic", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds2.ToString();
                        return;
                    }

                    if (lstReplacements.Items.Count == 0)
                        lstReplacements.Items.Add(string.Format("Step {0}:", il_MeasureStep));

                    modGlobal.gv_sql = "SELECT JoinOperator FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureCriteriaSetID = " + il_MeasureCriteriaSetID;

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                    //LDW if (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                    {
                        //LDW ls_JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
                        ls_JoinOperator = myRow2.Field<string>("JoinOperator");
                    }
                    //LDW modGlobal.gv_rs.Close();
                    modGlobal.gv_rs.Dispose();

                    modGlobal.gv_sql = "SELECT Max(MeasureCriteriaSet) as NewSet FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureStepID = " + il_measureStepID;
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                    //LDW ll_SetCnt = modGlobal.gv_rs.rdoColumns["newset"].Value;
                    ll_SetCnt = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["newset"]);
                    //LDW modGlobal.gv_rs.Close();
                    modGlobal.gv_rs.Dispose();

                    for (li_cnt = 0; li_cnt <= lstDDID.Items.Count - 1; li_cnt++)
                    {
                        if (lstDDID.SelectedIndex == li_cnt)
                        {
                            ll_SetCnt = ll_SetCnt + 1;

                            //LDW ls_ReplacementCrit = Strings.Replace(rdcMeasureSet.Resultset.rdoColumns["CriteriaTitle"].Value, txtDDID.Text, Support.GetItemString(lstDDID, li_cnt));
                            ls_ReplacementCrit = Strings.Replace(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["CriteriaTitle"].ToString(), txtDDID.Text, Support.GetItemString(lstDDID, li_cnt));

                            modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureCriteriaCopy (MeasureID, MeasureStepID, MeasureCriteriaSet, CriteriaTitle, DDID1, DDID2, ValueOperator, FieldValue, DestDDID, LookupID, FieldOperator, DateUnit, JoinOperator, LookupTableID, MeasureCriteriaSetJoinOperator) ";
                            modGlobal.gv_sql = string.Format("{0} VALUES ({1}, {2}, {3}, ", modGlobal.gv_sql, il_IndicatorID, il_measureStepID, ll_SetCnt);

                            modGlobal.gv_sql = modGlobal.gv_sql + "'" + ls_ReplacementCrit + "', " + (OptDDID1.IsChecked ? Support.GetItemData(lstDDID, li_cnt).ToString() :
                                (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DDID1"]) ? "Null" : rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DDID1"].ToString())) +
                                ", " + (OptDDID2.IsChecked & !Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["ddid2"]) ? Support.GetItemData(lstDDID, li_cnt).ToString() :
                                (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["ddid2"]) ? "Null" : rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["ddid2"].ToString())) + ", ";


                            modGlobal.gv_sql = modGlobal.gv_sql + (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["ValueOperator"]) ? "NULL" : "'" +
                                rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["ValueOperator"].ToString() + "'") + ", " + (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["FIELDVALUE"])
                                ? "Null" : "'" + rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["FIELDVALUE"] + "'") + ", ";


                            modGlobal.gv_sql = modGlobal.gv_sql + (OptDDID2.IsChecked & !Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DestDDID"]) ?
                                Support.GetItemData(lstDDID, li_cnt).ToString() : (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DestDDID"]) ?
                                "Null" : rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DestDDID"].ToString())) + ", ";


                            modGlobal.gv_sql = modGlobal.gv_sql + "" + (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["LookupID"]) ?
                                "Null" : rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["LookupID"].ToString());


                            modGlobal.gv_sql = modGlobal.gv_sql + ", " + (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["FieldOperator"]) ? "Null" : "'" +
                                rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["FieldOperator"] + "'") + ", " + (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DateUnit"]) ?
                                "Null" : "'" + rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DateUnit"] + "'");

                            modGlobal.gv_sql = modGlobal.gv_sql + ", " + (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["JoinOperator"]) ? "Null" : "'" +
                                cboSetJoinOp.Text + "'") + ", " + (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["LookupTableID"]) ? "Null" :
                                rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["LookupTableID"].ToString()) + ", '" + ls_JoinOperator + "')";
                            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        }
                    }

                    //display the set criteria by selecting from the table
                    modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaCopy ORDER BY MeasureCriteriaSet";
                }

                int ll_LastSet = 0;

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    ll_CritCnt = ll_CritCnt + 1;

                    //LDW if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value))
                    if (!Information.IsDBNull(myRow3.Field<string>("MeasureCriteriaSet")))
                    {
                        //LDW if (Strings.Len(modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value) > 0 & modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value != ll_LastSet)
                        if (Strings.Len(myRow3.Field<string>("MeasureCriteriaSet")) > 0 & myRow3.Field<int>("MeasureCriteriaSet") != ll_LastSet)
                        {
                            //LDW lstReplacements.Items.Add(" (" + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetJoinOperator"].Value + ") Set " + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value + ": ");
                            lstReplacements.Items.Add(string.Format(" ({0}) Set {1}: ", myRow3.Field<string>("MeasureCriteriaSetJoinOperator"), myRow3.Field<string>("MeasureCriteriaSet")));
                        }
                    }
                    else if (ll_CritCnt == 1)
                    {
                        //LDW lstReplacements.Items.Add(" (" + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetJoinOperator"].Value + ") Set " + il_MeasureSet + ": ");
                        lstReplacements.Items.Add(string.Format(" ({0}) Set {1}: ", myRow3.Field<string>("MeasureCriteriaSetJoinOperator"), il_MeasureSet));
                    }

                    //LDW lstReplacements.Items.Add("    " + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + "  (" + rdcMeasureSet.Resultset.rdoColumns["JoinOperator"].Value + ")");
                    lstReplacements.Items.Add(string.Format("    {0}  ({1})", myRow3.Field<string>("CriteriaTitle"), rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["JoinOperator"]));

                    //LDW ll_LastSet = (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value) ? 0 : modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value);
                    ll_LastSet = (Information.IsDBNull(myRow3.Field<int>("MeasureCriteriaSet")) ? 0 : myRow3.Field<int>("MeasureCriteriaSet"));
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //LDW modGlobal.gv_rs.Close();
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
            ////LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            try
            {
                DeleteMeasureCriteriaCopy();
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

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteMeasureCriteriaCopy();
                lstReplacements.Items.Clear();
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SqlCommand ps = new SqlCommand();
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                modGlobal.gv_sql = "{ call CreateDuplicateMeasureCriteriaLogic }";
                /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                //
                //run the stored procedure
                //
                ps.Execute();
                ps.Close();*/
                ps.Connection = modGlobal.gv_cn;
                ps.CommandType = CommandType.StoredProcedure;
                ps.CommandText = modGlobal.gv_sql;
                SqlParameter retParam1 = ps.Parameters.Add("return_value", SqlDbType.Int);
                retParam1.Direction = ParameterDirection.ReturnValue;
                try
                {
                    ps.Connection.Open();
                    ps.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //LDW MessageBox.Show("Error while opening connection: " + ex.Message);

                    DialogResult ds3 = RadMessageBox.Show(this, "Error while opening connection: " + ex.Message, "Execution Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds3.ToString();
                }
                finally
                {
                    ps.Dispose();
                }

                //LDW My.MyProject.Forms.frmMeasureCriteriaSetup.RefreshMeasureCriteria();
                Cursor.Current = Cursors.Default;

                //LDW RadMessageBox.Show("Duplicate was successful.", MsgBoxStyle.Information, "Success!");

                DialogResult ds4 = RadMessageBox.Show(this, "Duplicate was successful.", "Execution Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                this.Text = ds4.ToString();
                this.Close();

                return;
                //LDW ErrHandler:
                Cursor.Current = Cursors.Default;
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

        private void dbgMeasureSet_CurrentCellChanged(object sender, Telerik.WinControls.UI.CurrentCellChangedEventArgs e)
        {
            try
            {
                //LDW if ((!Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["DDID1"].Value) & OptDDID1.Checked) | (!Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["ddid2"].Value) & OptDDID2.Checked))
                if ((!Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DDID1"]) & OptDDID1.IsChecked) | (!Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["ddid2"]) & OptDDID2.IsChecked))
                {
                    lstDDID.Enabled = true;
                    DisplayFieldList();
                    RefreshChangeFieldList();
                }
                else
                {
                    lstDDID.Enabled = false;
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
            // gv_sql = gv_sql & " where MeasureCriteriaID = " & rdcMeasureSet.Resultset!measureCriteriaID
        }

        private void dlgMeasureCreateSetLogic_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshMeasureSetDetail();
                RefreshCaption();
                lstReplacements.Items.Clear();
                DeleteMeasureCriteriaCopy();
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

        private void DeleteMeasureCriteriaCopy()
        {
            try
            {
                modGlobal.gv_sql = "DELETE FROM tbl_Setup_MeasureCriteriaCopy";
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
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

        private void DisplayFieldList()
        {
            try
            {
                modGlobal.gv_sql = "SELECT FieldName FROM tbl_Setup_DataDef WHERE DDID = " + (OptDDID1.IsChecked ? rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DDID1"] :
                    (Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["ddid2"]) ? rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DestDDID"] :
                    rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["ddid2"]));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_Setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                //LDW if (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName4].Rows)
                {
                    txtDDID.Text = myRow3.Field<string>("FieldName");
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

        private void RefreshCaption()
        {
            string ls_Description = null;
            int ll_Set = 0;
            int ll_Step = 0;


            try
            {
                modGlobal.gv_sql = "SELECT Description, IndicatorID FROM tbl_Setup_Indicator WHERE IndicatorID = (" + "SELECT MeasureID FROM tbl_Setup_MeasureStep WHERE MeasureStepID" +
                    "= (SELECT MeasureStepID FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureCriteriaSetID = " + il_MeasureCriteriaSetID + "))";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName5 = "tbl_Setup_Indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                ls_Description = modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["Description"].ToString();
                il_IndicatorID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["IndicatorID"]);
                modGlobal.gv_rs.Dispose();

                modGlobal.gv_sql = "SELECT MeasureStep, MeasureStepID FROM tbl_Setup_MeasureStep WHERE MeasureStepID = (SELECT MeasureStepID FROM" +
                    "tbl_Setup_MeasureCriteriaSet WHERE MeasureCriteriaSetID = " + il_MeasureCriteriaSetID + ")";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName6 = "tbl_Setup_MeasureStep";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                ll_Step = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["measurestep"]);
                il_measureStepID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["MeasureStepID"]);
                modGlobal.gv_rs.Dispose();
                il_MeasureStep = ll_Step;

                modGlobal.gv_sql = "SELECT MeasureCriteriaSet FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureCriteriaSetID = " + il_MeasureCriteriaSetID;
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName7 = "tbl_Setup_MeasureCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                ll_Set = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["MeasureCriteriaSet"]);
                modGlobal.gv_rs.Dispose();
                il_MeasureSet = ll_Set;

                this.Text = this.Text + " - " + ls_Description + " Step " + ll_Step + " Set " + ll_Set;
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
            ////LDW ErrHandler:

            //LDW modGlobal.CheckForErrors();
        }

        private void RefreshChangeFieldList()
        {
            string[] ls_Parts = null;
            string ls_Part1 = null;
            string ls_Part2 = null;
            List<Item> itemslstDDID = new List<Item>();


            try
            {
                ls_Parts = Strings.Split(txtDDID.Text + " ", " ");
                ls_Part1 = ls_Parts[0];
                if (Information.UBound(ls_Parts) > 2)
                {
                    ls_Part2 = ls_Parts[2];
                }

                modGlobal.gv_sql = "SELECT DDID, FieldName FROM tbl_Setup_DataDef WHERE FieldName like '" + ls_Part1 + "%" + ls_Part2 + "%' " +
                    " AND FieldName <> '" + txtDDID.Text + "' AND (ParentDDID IS NULL OR ParentDDID = DDID) ORDER BY FieldName";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "tbl_Setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);

                lstDDID.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName8].Rows)
                {
                    itemslstDDID.Add(new Item(myRow4.Field<int>("DDID"), myRow4.Field<string>("FieldName")));

                    //lstDDID.Items.Add(new ListBoxItem(myRow4.Field<string>("FieldName"), myRow4.Field<int>("DDID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.lstDDID.DataSource = itemslstDDID;
                this.lstDDID.DisplayMember = "Description";
                this.lstDDID.ValueMember = "Id";

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


        private void RefreshMeasureSetDetail()
        {
            try
            {
                modGlobal.gv_sql = "Select MeasureCriteriaID, CriteriaTitle, [DDID1], [DDID2], [ValueOperator], [FieldValue], [DestDDID], [LookupID]," +
                    "[FieldOperator], [DateUnit], [JoinOperator], [LookupTableID] FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaSetID = " + il_MeasureCriteriaSetID;
                modGlobal.gv_sql = modGlobal.gv_sql + " order by MeasureCriteriaID";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcMeasureSetTable, modGlobal.gv_rs);
                //LDW if (modGlobal.gv_rs.RowCount == 0)
                if (modGlobal.gv_rs.Tables[rdcMeasureSetTable].Rows.Count == 0)
                {
                    //LDW RadMessageBox.Show("Please Create measure sets before using this form", MsgBoxStyle.Information, "No Measures Exist");

                    DialogResult dsn = RadMessageBox.Show(this, "Please Create measure sets before using this form", "Measure Set Detail", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = dsn.ToString();
                    return;
                }
                else
                {
                    rdcMeasureSet = modGlobal.gv_rs;
                    rdcMeasureSet.AcceptChanges();
                    dbgMeasureSet.Refresh();
                    //        RefreshMeasureCriteria
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
            ////LDW ErrHandler:

            //LDW modGlobal.CheckForErrors();
        }

        private void OptDDID1_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(OptDDID1.IsChecked))
                {
                    if ((!Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DDID1"]) & OptDDID1.IsChecked) |
                        (!Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["ddid2"]) & OptDDID2.IsChecked))
                    {
                        lstDDID.Enabled = true;
                        DisplayFieldList();
                        RefreshChangeFieldList();
                    }
                    else
                    {
                        lstDDID.Enabled = false;
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

        private void OptDDID2_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(OptDDID2.IsChecked))
                {
                    if ((!Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DDID1"]) & OptDDID1.IsChecked) |
                        (!Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["ddid2"]) & OptDDID2.IsChecked) |
                        (!Information.IsDBNull(rdcMeasureSet.Tables[rdcMeasureSetTable].Rows[0]["DestDDID"]) & OptDDID2.IsChecked))
                    {
                        lstDDID.Enabled = true;
                        DisplayFieldList();
                        RefreshChangeFieldList();
                    }
                    else
                    {
                        lstDDID.Enabled = false;
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

        private void OptNewCrit_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(OptNewCrit.IsChecked))
                {
                    OptNewSet.Enabled = false;
                    OptNewCrit.Enabled = false;
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

        private void OptNewSet_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(OptNewSet.IsChecked))
                {
                    OptNewCrit.Enabled = false;
                    OptNewSet.Enabled = false;
                    cboSetJoinOp.Enabled = true;
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
