using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace COP2001
{
	internal partial class OlddlgCreateCat : Form
	{
		string is_CatID;
        

		public void Setii_CatID(ref string val_Renamed)
		{
			is_CatID = val_Renamed;
		}

        private void CancelButton_Renamed_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void dlgCreateCat_Load(Object eventSender, EventArgs eventArgs)
        {
            var dalAccess = new DALcop();
            if (Information.IsNumeric(is_CatID))
            {
                modGlobal.gv_sql = "SELECT * FROM tbl_MEASURE_CAT WHERE MEASURE_CATID = " + is_CatID;
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_MEASURE_CAT";
                modGlobal.gv_rs = dalAccess.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                //LDW txtCatID.Text = modGlobal.gv_rs.rdoColumns["CAT"].Value;
                txtCatID.Text = modGlobal.gv_rs.Tables[sqlTableName1].Columns["CAT"].ToString();
                //LDW txtCatDesc.Text = modGlobal.gv_rs.rdoColumns["CAT_DESC"].Value;
                txtCatDesc.Text = modGlobal.gv_rs.Tables[sqlTableName1].Columns["CAT_DESC"].ToString();
                //LDW cboType.Text = modGlobal.gv_rs.rdoColumns["CAT_TYPE"].Value;
                cboType.Text = modGlobal.gv_rs.Tables[sqlTableName1].Columns["CAT_TYPE"].ToString();
            }

        }

        private void OKButton_Click(Object eventSender, EventArgs eventArgs)
        {
            if (!string.IsNullOrEmpty(cboType.Text) & !string.IsNullOrEmpty(txtCatID.Text) & !string.IsNullOrEmpty(txtCatDesc.Text))
            {
                if (Information.IsNumeric(is_CatID))
                {
                    modGlobal.gv_sql = string.Format("UPDATE tbl_MEASURE_CAT SET CAT = '{0}', CAT_DESC = '{1}', CAT_TYPE = '{2}' WHERE MEASURE_CATID = {3}", txtCatID.Text, txtCatDesc.Text, cboType.Text, is_CatID);
                }
                else
                {
                    //table has unique constraint setup on CAT field so duplicates will not be allowed
                    modGlobal.gv_sql = string.Format("INSERT INTO tbl_MEASURE_CAT (CAT, CAT_DESC, CAT_TYPE) VALUES ('{0}', '{1}', '{2}')", txtCatID.Text, txtCatDesc.Text, cboType.Text);
                }

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
                this.Close();
            }
            else
            {
                Interaction.MsgBox("Please fill in all the Information", MsgBoxStyle.Critical, "Information Incomplete");
            }
            return;
            ErrHandler:
            modGlobal.CheckForErrors();
        }
    }
}
