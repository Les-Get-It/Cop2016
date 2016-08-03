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
	internal partial class OldfrmValidationCopyCriteriaSet : System.Windows.Forms.Form
	{
		private int ii_TableValidationMessageID;
		private int ii_TableValidationID;
		private short ii_TableSet;

		public void SetTableValidationID(ref int tablevalidationid)
		{
			ii_TableValidationID = tablevalidationid;
		}



//UPGRADE_WARNING: Event cboCopyTo.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboCopyTo_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshValidationSet();
		}

		private void cmdCopy_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			short li_CritCount = 0;
			short li_Cnt = 0;
			short li_MaxID = 0;
			short li_MinID = 0;
			if (cboSet.SelectedIndex > -1 & cboCopyTo.SelectedIndex > -1) {

				modGlobal.gv_sql = "select count(*) as CritCount, min(tableValidationID) as MinID FROM tbl_setup_tableValidation " + " Where TableValidationMessageID = " + ii_TableValidationMessageID + " AND CriteriaSet = " + ii_TableSet;

				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (!modGlobal.gv_rs.EOF) {
					li_CritCount = modGlobal.gv_rs.rdoColumns["CritCount"].Value;
					li_MinID = modGlobal.gv_rs.rdoColumns["MinID"].Value;
				}
				modGlobal.gv_rs.Close();

				modGlobal.gv_sql = "select max(TableValidationID) as MaxID FROM tbl_setup_tableValidation ";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (!modGlobal.gv_rs.EOF) {
					li_MaxID = modGlobal.gv_rs.rdoColumns["MaxID"].Value;
				}
				modGlobal.gv_rs.Close();

				for (li_Cnt = 1; li_Cnt <= li_CritCount; li_Cnt++) {

					modGlobal.gv_sql = " Insert Into tbl_Setup_TableValidation " + " SELECT " + li_MaxID + li_Cnt + " ,  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboCopyTo, cboCopyTo.SelectedIndex) + " ,[ValidationType] " + " , " + cboSet.Text + " ,[CriteriaTitle] " + " ,[SourceDDID1] " + " ,[SourceDDID2] " + " ,[FieldOperator] " + " ,[DestDDID] " + " ,[LookupID] " + " ,[LookupTableID] " + " ,[ValueOperator] " + " ,[Value] " + " ,[DateUnit] " + " ,[JoinOperator] " + " From tbl_Setup_TableValidation " + " Where TableValidationMessageID = " + ii_TableValidationMessageID + " AND TableValidationID = " + li_MinID;

					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					modGlobal.gv_sql = "SELECT min(tableValidationID) as MinID " + " FROM tbl_setup_tableValidation WHERE TableValidationMessageID = " + ii_TableValidationMessageID + " AND TableValidationID > " + li_MinID + " AND CriteriaSet = " + ii_TableSet;

					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					if (!modGlobal.gv_rs.EOF) {
						//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						li_MinID = (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["MinID"].Value) ? 0 : modGlobal.gv_rs.rdoColumns["MinID"].Value);
					}
					modGlobal.gv_rs.Close();

				}

				Interaction.MsgBox("Save Success!");
			}


		}

		private void frmValidationCopyCriteriaSet_Load(System.Object eventSender, System.EventArgs eventArgs)
		{

			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));


			modGlobal.gv_sql = "select msg.TableValidationMessageID, Message, CriteriaSet from tbl_setup_tablevalidationmessage msg, tbl_setup_tableValidation tv " + " Where tv.TableValidationMessageID = msg.TableValidationMessageID AND TableValidationID = " + ii_TableValidationID;

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			lblCopyFrom.Text = "";
			if (!modGlobal.gv_rs.EOF) {
				ii_TableValidationMessageID = modGlobal.gv_rs.rdoColumns["TableValidationMessageID"].Value;
				ii_TableSet = modGlobal.gv_rs.rdoColumns["Criteriaset"].Value;
				lblCopyFrom.Text = modGlobal.gv_rs.rdoColumns["Message"].Value;
			}

			modGlobal.gv_rs.Close();

			RefreshValidationMessages();
		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}


		private void RefreshValidationMessages()
		{
			modGlobal.gv_sql = "select Message, TableValidationMessageID from tbl_setup_tablevalidationmessage ORDER BY convert(varchar(8000), MESSAGE)";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			cboCopyTo.Items.Clear();

			while (!modGlobal.gv_rs.EOF) {
				cboCopyTo.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["Message"].Value, modGlobal.gv_rs.rdoColumns["TableValidationMessageID"].Value));
				modGlobal.gv_rs.MoveNext();
			}

			modGlobal.gv_rs.Close();

		}

		private void RefreshValidationSet()
		{

			if (cboCopyTo.SelectedIndex > -1) {

				modGlobal.gv_sql = "select max(criteriaset) as CritSet " + " From tbl_setup_TableValidation " + " Where TableValidationMessageID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboCopyTo, cboCopyTo.SelectedIndex) + " Union " + " select max(criteriaset) + 1 as CritSet " + " From tbl_setup_TableValidation " + " Where TableValidationMessageID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboCopyTo, cboCopyTo.SelectedIndex) + " ORDER BY CRITSET";

				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				cboSet.Items.Clear();
				while (!modGlobal.gv_rs.EOF) {
					cboSet.Items.Add(modGlobal.gv_rs.rdoColumns["CritSet"].Value);
					modGlobal.gv_rs.MoveNext();
				}

				modGlobal.gv_rs.Close();
			}

		}

		private void frmValidationCopyCriteriaSet_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			ii_TableValidationMessageID = 0;
			ii_TableValidationID = 0;
		}
	}
}
