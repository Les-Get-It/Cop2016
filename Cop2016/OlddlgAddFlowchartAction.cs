using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace COP2001
{
	internal partial class OlddlgAddFlowchartAction : Form
	{
        const string sqlTableName1 = "tbl_Setup_MeasureFlowchartAction";
        const string sqlTableName2 = "vuMeasureFlowchartLogic";
		private int il_MeasureCriteriaID;

        private void CancelButton_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void dlgAddFlowchartAction_Load(Object eventSender, EventArgs eventArgs)
        {
            var dalAccess = new DALcop();

            modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureFlowchartAction";
            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            modGlobal.gv_rs = dalAccess.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
            cboAction.Items.Clear();

            //LDW while (!modGlobal.gv_rs.EOF) {
            foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
            {
                //LDW cboAction.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["ActionDescription"].Value, modGlobal.gv_rs.rdoColumns["FlowchartActionID"].Value));
                cboAction.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(myRow1.Field<string>("ActionDescription"), myRow1.Field<int>("FlowchartActionID")));
                //LDW modGlobal.gv_rs.MoveNext();
            }

            //LDW modGlobal.gv_rs.Close();
            modGlobal.gv_rs.Dispose();

            modGlobal.gv_sql = "select * from vuMeasureFlowchartLogic WHERE MeasureCriteriaID = " + il_MeasureCriteriaID;
            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            modGlobal.gv_rs = dalAccess.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

            //LDW txtStep.Text = modGlobal.gv_rs.rdoColumns["MeasureStep"].Value;
            txtStep.Text = modGlobal.gv_rs.Tables[sqlTableName2].Columns["MeasureStep"].ToString();
            //LDW txtStep.Tag = modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
            txtStep.Tag = modGlobal.gv_rs.Tables[sqlTableName2].Columns["MeasureStepID"].ToString();
            //LDW modGlobal.gv_rs.Close();
            modGlobal.gv_rs.Dispose();
        }

        public void SetMeasureCriteriaID(ref int MeasureCriteriaID)
		{
			il_MeasureCriteriaID = MeasureCriteriaID;
		}

        private void OkButton_Click(Object eventSender, EventArgs eventArgs)
        {
            if (cboAction.SelectedIndex > -1)
            {
                modGlobal.gv_sql = string.Format("UPDATE tbl_Setup_MeasureStep SET FlowchartActionID = {0} WHERE MeasureStepID = {1}", Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboAction, cboAction.SelectedIndex), txtStep.Tag);
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

                Interaction.MsgBox("Successfully Saved!");
                this.Close();
            }
            else
            {
                Interaction.MsgBox("Please choose an action to perform");
            }
        }
    }
}
