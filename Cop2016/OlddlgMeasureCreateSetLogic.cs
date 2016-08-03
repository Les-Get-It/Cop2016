using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using MSDataGridLib;


namespace COP2001
{
	internal partial class OlddlgMeasureCreateSetLogic : Form
	{
		public int il_MeasureCriteriaSetID;
		private int il_MeasureSet;
		private int il_IndicatorID;
		private int il_MeasureStep;
		private int il_measureStepID;
        

        private void btnAdd_Click(Object eventSender, EventArgs eventArgs)
        {
            int li_cnt = 0;
            string ls_ReplacementCrit = null;
            int ll_SetCnt = 0;
            int ll_CritCnt = 0;
            string ls_JoinOperator = null;
            var dalAccess = new DALcop();
            const string sqlTableName1 = "tbl_Setup_MeasureCriteriaSet";
            const string sqlTableName2 = "tbl_Setup_MeasureCriteriaCopy";
            

            if (lstDDID.SelectedItems.Count == 0)
            {
                Interaction.MsgBox("Please select a field to replace");
                return;
            }

            lstReplacements.Items.Clear();


            modGlobal.gv_sql = "";
            if (OptNewCrit.Checked)
            {
                if (lstReplacements.Items.Count == 0)
                    lstReplacements.Items.Add(string.Format("Step {0}:", il_MeasureStep));

                modGlobal.gv_sql = "SELECT JoinOperator FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureCriteriaSetID = " + il_MeasureCriteriaSetID;

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                modGlobal.gv_rs = dalAccess.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

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
                    if (lstDDID.GetSelected(li_cnt))
                    {
                        ls_ReplacementCrit = Strings.Replace(rdcMeasureSet.Resultset.rdoColumns["CriteriaTitle"].Value, txtDDID.Text, Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstDDID, li_cnt));

                        modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureCriteriaCopy (MeasureID, MeasureStepID, MeasureCriteriaSetID, CriteriaTitle, DDID1, DDID2, ValueOperator, FieldValue, DestDDID, LookupID, FieldOperator, DateUnit, JoinOperator, LookupTableID, MeasureCriteriaSetJoinOperator) ";
                        modGlobal.gv_sql = string.Format("{0} VALUES ({1}, {2}, {3}, ", modGlobal.gv_sql, il_IndicatorID, il_measureStepID, il_MeasureCriteriaSetID);
                        modGlobal.gv_sql = string.Format("{0}'{1}', {2}, {3}, ", modGlobal.gv_sql, ls_ReplacementCrit, OptDDID1.Checked ? Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstDDID, li_cnt) : (Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["DDID1"].Value) ? "Null" : rdcMeasureSet.Resultset.rdoColumns["DDID1"].Value), OptDDID2.Checked & !Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["ddid2"].Value) ? Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstDDID, li_cnt) : (Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["ddid2"].Value) ? "Null" : rdcMeasureSet.Resultset.rdoColumns["ddid2"].Value));
                        modGlobal.gv_sql = string.Format("{0}{1}, {2}, {3}", modGlobal.gv_sql, Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["ValueOperator"].Value) ? "NULL" : string.Format("'{0}'", rdcMeasureSet.Resultset.rdoColumns["ValueOperator"].Value), Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["FIELDVALUE"].Value) ? "Null" : string.Format("'{0}'", rdcMeasureSet.Resultset.rdoColumns["FIELDVALUE"].Value), OptDDID2.Checked & !Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["DestDDID"].Value) ? Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstDDID, li_cnt) : (Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["DestDDID"].Value) ? "Null" : rdcMeasureSet.Resultset.rdoColumns["DestDDID"].Value));
                        modGlobal.gv_sql = string.Format("{0}, {1}, {2}, {3}", modGlobal.gv_sql, Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["LookupID"].Value) ? "Null" : rdcMeasureSet.Resultset.rdoColumns["LookupID"].Value, Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["FieldOperator"].Value) ? "Null" : string.Format("'{0}'", rdcMeasureSet.Resultset.rdoColumns["FieldOperator"].Value), Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["DateUnit"].Value) ? "Null" : string.Format("'{0}'", rdcMeasureSet.Resultset.rdoColumns["DateUnit"].Value));
                        modGlobal.gv_sql = string.Format("{0}, {1}, {2}, '{3}' )", modGlobal.gv_sql, Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["JoinOperator"].Value) ? "Null" : string.Format("'{0}'", rdcMeasureSet.Resultset.rdoColumns["JoinOperator"].Value), Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["LookupTableID"].Value) ? "Null" : rdcMeasureSet.Resultset.rdoColumns["LookupTableID"].Value, ls_JoinOperator);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        var command1 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
                        try
                        {
                            command1.Connection.Open();
                            command1.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while opening connection: " + ex.Message);
                        }
                        finally
                        {
                            command1.Dispose();
                            modGlobal.gv_cn.Close();
                        }
                    }
                }

                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaCopy ORDER BY MeasureCriteriaSetID";
            }
            else if (OptNewSet.Checked)
            {
                if (cboSetJoinOp.SelectedIndex == -1)
                {
                    Interaction.MsgBox("Please choose a Join Operator for each set", MsgBoxStyle.Information, "No Join Operator Selected");
                    return;
                }

                if (lstReplacements.Items.Count == 0)
                    lstReplacements.Items.Add(string.Format("Step {0}:", il_MeasureStep));

                modGlobal.gv_sql = "SELECT JoinOperator FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureCriteriaSetID = " + il_MeasureCriteriaSetID;

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                modGlobal.gv_rs = dalAccess.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

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
                modGlobal.gv_rs = dalAccess.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                //LDW ll_SetCnt = modGlobal.gv_rs.rdoColumns["newset"].Value;
                ll_SetCnt = Int32.Parse(modGlobal.gv_rs.Tables[sqlTableName1].Columns["newset"].ToString());
                //LDW modGlobal.gv_rs.Close();
                modGlobal.gv_rs.Dispose();

                for (li_cnt = 0; li_cnt <= lstDDID.Items.Count - 1; li_cnt++)
                {
                    if (lstDDID.GetSelected(li_cnt))
                    {
                        ll_SetCnt = ll_SetCnt + 1;

                        ls_ReplacementCrit = Strings.Replace(rdcMeasureSet.Resultset.rdoColumns["CriteriaTitle"].Value, txtDDID.Text, Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstDDID, li_cnt));

                        modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureCriteriaCopy (MeasureID, MeasureStepID, MeasureCriteriaSet, CriteriaTitle, DDID1, DDID2, ValueOperator, FieldValue, DestDDID, LookupID, FieldOperator, DateUnit, JoinOperator, LookupTableID, MeasureCriteriaSetJoinOperator) ";
                        modGlobal.gv_sql = string.Format("{0} VALUES ({1}, {2}, {3}, ", modGlobal.gv_sql, il_IndicatorID, il_measureStepID, ll_SetCnt);
                        modGlobal.gv_sql = string.Format("{0}'{1}', {2}, {3}, ", modGlobal.gv_sql, ls_ReplacementCrit, OptDDID1.Checked ? Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstDDID, li_cnt) : (Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["DDID1"].Value) ? "Null" : rdcMeasureSet.Resultset.rdoColumns["DDID1"].Value), OptDDID2.Checked & !Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["ddid2"].Value) ? Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstDDID, li_cnt) : (Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["ddid2"].Value) ? "Null" : rdcMeasureSet.Resultset.rdoColumns["ddid2"].Value));
                        modGlobal.gv_sql = string.Format("{0}{1}, {2}, ", modGlobal.gv_sql, Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["ValueOperator"].Value) ? "NULL" : string.Format("'{0}'", rdcMeasureSet.Resultset.rdoColumns["ValueOperator"].Value), Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["FIELDVALUE"].Value) ? "Null" : string.Format("'{0}'", rdcMeasureSet.Resultset.rdoColumns["FIELDVALUE"].Value));
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, OptDDID2.Checked & !Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["DestDDID"].Value) ? Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstDDID, li_cnt) : (Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["DestDDID"].Value) ? "Null" : rdcMeasureSet.Resultset.rdoColumns["DestDDID"].Value));
                        modGlobal.gv_sql = string.Format("{0}{1}", modGlobal.gv_sql, Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["LookupID"].Value) ? "Null" : rdcMeasureSet.Resultset.rdoColumns["LookupID"].Value);
                        modGlobal.gv_sql = string.Format("{0}, {1}, {2}", modGlobal.gv_sql, Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["FieldOperator"].Value) ? "Null" : string.Format("'{0}'", rdcMeasureSet.Resultset.rdoColumns["FieldOperator"].Value), Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["DateUnit"].Value) ? "Null" : string.Format("'{0}'", rdcMeasureSet.Resultset.rdoColumns["DateUnit"].Value));
                        modGlobal.gv_sql = string.Format("{0}, {1}, {2}, '{3}')", modGlobal.gv_sql, Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["JoinOperator"].Value) ? "Null" : string.Format("'{0}'", cboSetJoinOp.Text), Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["LookupTableID"].Value) ? "Null" : rdcMeasureSet.Resultset.rdoColumns["LookupTableID"].Value, ls_JoinOperator);

                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        var command2 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
                        try
                        {
                            command2.Connection.Open();
                            command2.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while opening connection: " + ex.Message);
                        }
                        finally
                        {
                            command2.Dispose();
                            modGlobal.gv_cn.Close();
                        }
                    }
                }

                //display the set criteria by selecting from the table
                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaCopy ORDER BY MeasureCriteriaSet";
            }

            int ll_LastSet = 0;
            ll_CritCnt = 0;

            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            modGlobal.gv_rs = dalAccess.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);
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
                lstReplacements.Items.Add(string.Format("    {0}  ({1})", myRow3.Field<string>("CriteriaTitle"), rdcMeasureSet.Resultset.rdoColumns["JoinOperator"].Value));

                //LDW ll_LastSet = (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value) ? 0 : modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value);
                ll_LastSet = (Information.IsDBNull(myRow3.Field<int>("MeasureCriteriaSet")) ? 0 : myRow3.Field<int>("MeasureCriteriaSet"));
                //LDW modGlobal.gv_rs.MoveNext();
            }

            //LDW modGlobal.gv_rs.Close();
            modGlobal.gv_rs.Dispose();
            return;
            ErrHandler:
            modGlobal.CheckForErrors();
        }

        private void CancelButton_Renamed_Click(Object eventSender, EventArgs eventArgs)
        {
            DeleteMeasureCriteriaCopy();
            this.Close();
        }


        private void cmdDelete_Click(Object eventSender, EventArgs eventArgs)
        {
            DeleteMeasureCriteriaCopy();
            lstReplacements.Items.Clear();
        }

        private void cmdSave_Click(Object eventSender, EventArgs eventArgs)
        {
            SqlCommand ps = null;
            Cursor.Current = Cursors.WaitCursor;

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
                ps.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                ps.Dispose();
            }

            //LDW My.MyProject.Forms.frmMeasureCriteriaSetup.RefreshMeasureCriteria();
            Cursor.Current = Cursors.Default;

            Interaction.MsgBox("Duplicate was successful.", MsgBoxStyle.Information, "Success!");
            this.Close();

            return;
            ErrHandler:
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            modGlobal.CheckForErrors();
        }


        //LDW private void dbgMeasureSet_RowColChange(Object eventSender, AxMSDBGrid.DBGridEvents_RowColChangeEvent eventArgs)
        private void dbgMeasureSet_RowColChange(Object eventSender, DataGridViewCellStateChangedEventHandler eventArgs)
        {
            //LDW if ((!Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["DDID1"].Value) & OptDDID1.Checked) | (!Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["ddid2"].Value) & OptDDID2.Checked))
            if ((!Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["DDID1"].Value) & OptDDID1.Checked) | (!Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["ddid2"].Value) & OptDDID2.Checked))
            {
                lstDDID.Enabled = true;
                DisplayFieldList();
                RefreshChangeFieldList();
            } 
            else
            {
                lstDDID.Enabled = false;
            }
            // gv_sql = gv_sql & " where MeasureCriteriaID = " & rdcMeasureSet.Resultset!measureCriteriaID
        }

        private void dlgMeasureCreateSetLogic_Load(Object eventSender, EventArgs eventArgs)
        {
            RefreshMeasureSetDetail();
            RefreshCaption();
            lstReplacements.Items.Clear();
            DeleteMeasureCriteriaCopy();

        }

        private void DeleteMeasureCriteriaCopy()
		{
			modGlobal.gv_sql = "DELETE FROM tbl_Setup_MeasureCriteriaCopy";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);
		}

		private void DisplayFieldList()
		{

			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			modGlobal.gv_sql = "SELECT FieldName FROM tbl_Setup_DataDef WHERE DDID = " + (OptDDID1.Checked ? rdcMeasureSet.Resultset.rdoColumns["DDID1"].Value : (Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["ddid2"].Value) ? rdcMeasureSet.Resultset.rdoColumns["DestDDID"].Value : rdcMeasureSet.Resultset.rdoColumns["ddid2"].Value));
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (!modGlobal.gv_rs.EOF) {
				txtDDID.Text = modGlobal.gv_rs.rdoColumns["FieldName"].Value;
			}
			modGlobal.gv_rs.Close();



		}

		private void RefreshCaption()
		{
			string ls_Description = null;
			int ll_Set = 0;
			int ll_Step = 0;
			 // ERROR: Not supported in C#: OnErrorStatement


			modGlobal.gv_sql = "SELECT Description, IndicatorID FROM tbl_Setup_Indicator WHERE IndicatorID = (" + "SELECT MeasureID FROM tbl_Setup_MeasureStep WHERE MeasureStepID = (SELECT MeasureStepID FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureCriteriaSetID = " + il_MeasureCriteriaSetID + "))";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			ls_Description = modGlobal.gv_rs.rdoColumns["Description"].Value;
			il_IndicatorID = modGlobal.gv_rs.rdoColumns["IndicatorID"].Value;
			modGlobal.gv_rs.Close();

			modGlobal.gv_sql = "SELECT MeasureStep, MeasureStepID FROM tbl_Setup_MeasureStep WHERE MeasureStepID = (SELECT MeasureStepID FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureCriteriaSetID = " + il_MeasureCriteriaSetID + ")";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			ll_Step = modGlobal.gv_rs.rdoColumns["measurestep"].Value;
			il_measureStepID = modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
			modGlobal.gv_rs.Close();
			il_MeasureStep = ll_Step;

			modGlobal.gv_sql = "SELECT MeasureCriteriaSet FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureCriteriaSetID = " + il_MeasureCriteriaSetID;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			ll_Set = modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value;
			modGlobal.gv_rs.Close();
			il_MeasureSet = ll_Set;

			this.Text = this.Text + " - " + ls_Description + " Step " + ll_Step + " Set " + ll_Set;
			return;
			ErrHandler:

			modGlobal.CheckForErrors();

		}

		private void RefreshChangeFieldList()
		{
			string[] ls_Parts = null;
			string ls_Part1 = null;
			string ls_Part2 = null;

			ls_Parts = Strings.Split(txtDDID.Text + " ", " ");
			ls_Part1 = ls_Parts[0];
			if (Information.UBound(ls_Parts) > 2) {
				ls_Part2 = ls_Parts[2];
			}

			modGlobal.gv_sql = "SELECT DDID, FieldName FROM tbl_Setup_DataDef WHERE FieldName like '" + ls_Part1 + "%" + ls_Part2 + "%' " + " AND FieldName <> '" + txtDDID.Text + "' AND (ParentDDID IS NULL OR ParentDDID = DDID) ORDER BY FieldName";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			lstDDID.Items.Clear();

			while (!modGlobal.gv_rs.EOF) {
				lstDDID.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				modGlobal.gv_rs.MoveNext();
			}

			modGlobal.gv_rs.Close();

		}

		private void RefreshMeasureSetDetail()
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			modGlobal.gv_sql = "Select MeasureCriteriaID, CriteriaTitle, [DDID1], [DDID2], [ValueOperator], [FieldValue], [DestDDID], [LookupID], [FieldOperator], [DateUnit], [JoinOperator], [LookupTableID] FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaSetID = " + il_MeasureCriteriaSetID;
			modGlobal.gv_sql = modGlobal.gv_sql + " order by MeasureCriteriaID";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount == 0) {
				Interaction.MsgBox("Please Create measure sets before using this form", MsgBoxStyle.Information, "No Measures Exist");

				return;

			} else {
				rdcMeasureSet.Resultset = modGlobal.gv_rs;
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				rdcMeasureSet.CtlRefresh();
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				dbgMeasureSet.CtlRefresh();

				//        RefreshMeasureCriteria
			}

			return;
			ErrHandler:

			modGlobal.CheckForErrors();
		}

		private void OKButton_Click()
		{
			this.Close();
		}



        //UPGRADE_WARNING: Event OptDDID1.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void OptDDID1_CheckedChanged(Object eventSender, EventArgs eventArgs)
        {
            if (eventSender.Checked)
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if ((!Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["DDID1"].Value) & OptDDID1.Checked) | (!Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["ddid2"].Value) & OptDDID2.Checked))
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

        //UPGRADE_WARNING: Event OptDDID2.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void OptDDID2_CheckedChanged(Object eventSender, EventArgs eventArgs)
        {
            if (eventSender.Checked)
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if ((!Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["DDID1"].Value) & OptDDID1.Checked) | (!Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["ddid2"].Value) & OptDDID2.Checked) | (!Information.IsDBNull(rdcMeasureSet.Resultset.rdoColumns["DestDDID"].Value) & OptDDID2.Checked))
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

        //UPGRADE_WARNING: Event OptNewCrit.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void OptNewCrit_CheckedChanged(Object eventSender, EventArgs eventArgs)
        {
            if (eventSender.Checked)
            {
                OptNewSet.Enabled = false;
                OptNewCrit.Enabled = false;
            }
        }

        //UPGRADE_WARNING: Event OptNewSet.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void OptNewSet_CheckedChanged(Object eventSender, EventArgs eventArgs)
        {
            if (eventSender.Checked)
            {
                OptNewCrit.Enabled = false;
                OptNewSet.Enabled = false;
                cboSetJoinOp.Enabled = true;

            }
        }
    }
}
