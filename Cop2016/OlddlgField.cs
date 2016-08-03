using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace COP2001
{
	internal partial class OlddlgField : Form
	{
		object ii_MeasureCriteriaID;
		string is_PreviousDataType;
		string is_CriteriaTitle;

		public void SetMeasureCriteriaID(ref object MeasureCriteriaID)
		{
			ii_MeasureCriteriaID = MeasureCriteriaID;
		}

        private void CancelButton_Renamed_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void dlgField_Load(Object eventSender, EventArgs eventArgs)
        {
            var dalAccess = new DALcop();
            const string sqlTableName1 = "tbl_Setup_MeasureCriteria";
            modGlobal.gv_sql = string.Format("SELECT dd.DDID, dd.FieldName, dd.FieldType, mc.CriteriaTitle FROM  tbl_Setup_MeasureCriteria mc, tbl_Setup_DataDef dd WHERE  dd.DDID = mc.DDID1 AND mc.MeasureCriteriaID = {0}", ii_MeasureCriteriaID);
            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            modGlobal.gv_rs = dalAccess.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

            //LDW if (!modGlobal.gv_rs.EOF)
            foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
            {
                //LDW if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DDID"].Value))
                if (!Information.IsDBNull(myRow1.Field<string>("DDID")))
                {
                    /*LDW txtPreviousField.Text = modGlobal.gv_rs.rdoColumns["FieldName"].Value;
                    is_PreviousDataType = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
                    is_CriteriaTitle = modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value; */
                    txtPreviousField.Text = myRow1.Field<string>("FieldName");
                    is_PreviousDataType = myRow1.Field<string>("FieldType");
                    is_CriteriaTitle = myRow1.Field<string>("CriteriaTitle");

                    RefreshFields();
                    OKButton.Enabled = true;
                }
                else
                {
                    Interaction.MsgBox("This criteria can not be modified");
                    OKButton.Enabled = false;
                }
                if (Information.IsDBNull(myRow1.Field<string>("DDID")))
                {
                    Interaction.MsgBox("This criteria can not be modified");
                    OKButton.Enabled = false;
                }
            }
            /*LDW else
            {
                Interaction.MsgBox("This criteria can not be modified");
                OKButton.Enabled = false;
            } */
        }

        private void OKButton_Click(Object eventSender, EventArgs eventArgs)
        {
            if (cboField.SelectedIndex > -1)
            {
                if (!string.IsNullOrEmpty(txtPreviousField.Text))
                {
                    is_CriteriaTitle = Strings.Replace(is_CriteriaTitle, txtPreviousField.Text, Strings.Trim(cboField.Text));

                    modGlobal.gv_sql = string.Format("UPDATE tbl_Setup_MeasureCriteria SET DDID1 = {0}, CriteriaTitle = '{1}'  WHERE MeasureCriteriaID = {2}", Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboField, cboField.SelectedIndex), is_CriteriaTitle, ii_MeasureCriteriaID);
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
                else
                {
                    Interaction.MsgBox("This can not be saved");
                }

                this.Close();
            }
            else
            {
                Interaction.MsgBox("Please select a field to modify to");
            }
            return;
            ErrHandler:
            modGlobal.CheckForErrors();
        }

        private void RefreshFields()
		{
            var dalAccess = new DALcop();
            const string sqlTableName2 = "tbl_Setup_DataDef";
            modGlobal.gv_sql = string.Format("SELECT * FROM tbl_Setup_DataDef WHERE FieldType = '{0}' AND (ParentDDID IS NULL OR ParentDDID = DDID) ORDER BY FIELDNAME", is_PreviousDataType);
            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            modGlobal.gv_rs = dalAccess.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

            cboField.Items.Clear();
			//LDW while (!modGlobal.gv_rs.EOF)
            foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
            {
                //LDW cboField.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                cboField.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(myRow2.Field<string>("FieldName"), myRow2.Field<int>("DDID")));
                //LDW modGlobal.gv_rs.MoveNext();
			}
		}
	}
}
