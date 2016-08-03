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
	internal partial class OldfrmExportSetup : System.Windows.Forms.Form
	{
		object JCVersion;
		object FileNum;
		private void cmdAddImportLayout_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstAvailableImportLayouts.SelectedIndex < 0) {
				return;
			}

			lstSelectedImportLayouts.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(lstAvailableImportLayouts.Text, Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstAvailableImportLayouts, lstAvailableImportLayouts.SelectedIndex)));
			RefreshImportLayout();

		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}
		public string TableValidationCriteria(ref object mainJoinOperator, ref object TableValidationMessageID)
		{
			string functionReturnValue = null;
			object DateFieldDDID2 = null;
			object DateFieldDDID1 = null;
			object stophere = null;
			object thiscriteria = null;
			object DataType = null;
			object thissetcriteria = null;
			object SetJoinOperator = null;
			object thisfieldname = null;
			object msgCriteria = null;
			System.Data.DataSet  critrs = null;
			System.Data.DataSet  setrs = null;
			System.Data.DataSet  thisrs = null;

			//-build the criteria
			//-group criteria by set and then join them by the main operator
			modGlobal.gv_sql = "Select criteriaset, joinoperator  From tbl_Setup_TableValidation ";
			//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationMessageID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where TableValidationMessageID = " + TableValidationMessageID;
			modGlobal.gv_sql = modGlobal.gv_sql + " Group by criteriaset, joinoperator ";
			setrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object msgCriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			msgCriteria = "";

			//get the fieldname from the first validation
			//UPGRADE_WARNING: Couldn't resolve default property of object thisfieldname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			thisfieldname = "";

			while (!setrs.EOF) {
				modGlobal.gv_sql = "Select  tv.* ";
				modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_Setup_TableValidation as tv ";
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationMessageID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where tv.TableValidationMessageID = " + TableValidationMessageID;
				modGlobal.gv_sql = modGlobal.gv_sql + " and tv.criteriaset = " + setrs.rdoColumns["CriteriaSet"].Value;

				critrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				if (critrs.RowCount > 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object SetJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					SetJoinOperator = critrs.rdoColumns["JoinOperator"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object thissetcriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				thissetcriteria = "";

				//for each set find the criteria, and build this section
				while (!critrs.EOF) {
					modGlobal.gv_sql = "Select * From tbl_Setup_DataDef ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + critrs.rdoColumns["SourceDDID1"].Value;
					thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					//UPGRADE_WARNING: Couldn't resolve default property of object DataType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DataType = thisrs.rdoColumns["FieldType"].Value;

					//A field can be compared to:
					// blank
					// a value
					// another field
					// a lookup value
					// a value after added or subtracted from another field

					//compare to blank
					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					if (Information.IsDBNull(critrs.rdoColumns["SourceDDID2"].Value) & Information.IsDBNull(critrs.rdoColumns["LookupID"].Value) & critrs.rdoColumns["Value"].Value == "Null") {
						//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						thiscriteria = " (";
						//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						thiscriteria = thiscriteria + "([" + critrs.rdoColumns["SourceDDID1"].Value + "] " + (critrs.rdoColumns["ValueOperator"].Value == "=" ? " is " : " is not ") + " null) ";
						//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						thiscriteria = thiscriteria + (critrs.rdoColumns["ValueOperator"].Value == "=" ? " Or " : " And ");
						//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						thiscriteria = thiscriteria + " [" + critrs.rdoColumns["SourceDDID1"].Value + "] " + critrs.rdoColumns["ValueOperator"].Value + " ''";
						//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						thiscriteria = thiscriteria + " )";

						//compare to a value, (or a lookup value), or a lookup table
						//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					} else if (Information.IsDBNull(critrs.rdoColumns["SourceDDID2"].Value) & Information.IsDBNull(critrs.rdoColumns["DestDDID"].Value)) {

						//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						if (Information.IsDBNull(critrs.rdoColumns["LookupTableID"].Value)) {
							//the field has been compared to a value
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = " (";
							//UPGRADE_WARNING: Couldn't resolve default property of object DataType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (DataType == "Date") {
								if (Strings.UCase(critrs.rdoColumns["ValueOperator"].Value) == "IN" & Strings.UCase(critrs.rdoColumns["DateUnit"].Value) == "M") {
									//4.22.05 - check that date falls within range of months
									//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									thiscriteria = thiscriteria + " iif(isnull([" + critrs.rdoColumns["SourceDDID1"].Value + "]) or [" + critrs.rdoColumns["SourceDDID1"].Value + "] = '', false, Month( Cdate([" + critrs.rdoColumns["SourceDDID1"].Value + "])) " + critrs.rdoColumns["ValueOperator"].Value + " " + critrs.rdoColumns["Value"].Value + ")";
								} else {
									//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									thiscriteria = thiscriteria + " iif(isnull([" + critrs.rdoColumns["SourceDDID1"].Value + "]) or [" + critrs.rdoColumns["SourceDDID1"].Value + "] = '', false, Cdate([" + critrs.rdoColumns["SourceDDID1"].Value + "]) " + critrs.rdoColumns["ValueOperator"].Value + " #" + critrs.rdoColumns["Value"].Value + "#)";
								}
								//UPGRADE_WARNING: Couldn't resolve default property of object DataType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							} else if (DataType == "Number") {
								//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								thiscriteria = thiscriteria + " iif(isnull([" + critrs.rdoColumns["SourceDDID1"].Value + "]) or [" + critrs.rdoColumns["SourceDDID1"].Value + "] = '', false, cdbl([" + critrs.rdoColumns["SourceDDID1"].Value + "]) " + critrs.rdoColumns["ValueOperator"].Value + " cdbl(" + critrs.rdoColumns["Value"].Value + "))";
							} else {
								//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								thiscriteria = thiscriteria + " [" + critrs.rdoColumns["SourceDDID1"].Value + "] " + critrs.rdoColumns["ValueOperator"].Value + " '" + critrs.rdoColumns["Value"].Value + "'";
							}
							if (critrs.rdoColumns["ValueOperator"].Value == "<>") {
								//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								thiscriteria = thiscriteria + " or [" + critrs.rdoColumns["SourceDDID1"].Value + "] is null ";
							}
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " )";

						} else {

							//the field has been compared to a lookup table
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = "iif ([" + critrs.rdoColumns["SourceDDID1"].Value + "] is not null and [" + critrs.rdoColumns["SourceDDID1"].Value + "] <> '',";
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " [" + critrs.rdoColumns["SourceDDID1"].Value + "] " + critrs.rdoColumns["ValueOperator"].Value;
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " (select iif(td.CompareToDesc = Yes, [lk.FieldValue], [lk.ID]) as lkvalue";
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " from tbl_Sys_MISCLOOKUPLIST as lk ";
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " inner join tbl_Sys_TableDef as td ";
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " on lk.basetableid = td.basetableid ";
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " where lk.basetableid = " + critrs.rdoColumns["LookupTableID"].Value + ")";
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + ", false) ";

						}

						//compare to another field
						//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					} else if (!Information.IsDBNull(critrs.rdoColumns["DestDDID"].Value)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						thiscriteria = " (";
						//UPGRADE_WARNING: Couldn't resolve default property of object DataType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (DataType == "Date") {
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " iif(isnull([" + critrs.rdoColumns["SourceDDID1"].Value + "]), Null, Cdate([" + critrs.rdoColumns["SourceDDID1"].Value + "]) " + critrs.rdoColumns["ValueOperator"].Value + " iif(isnull([" + critrs.rdoColumns["DestDDID"].Value + "]), Null, Cdate([" + critrs.rdoColumns["DestDDID"].Value + "])))";
							//UPGRADE_WARNING: Couldn't resolve default property of object DataType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						} else if (DataType == "Number") {
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " iif(isnull([" + critrs.rdoColumns["SourceDDID1"].Value + "]), Null, cdbl([" + critrs.rdoColumns["SourceDDID1"].Value + "]) " + critrs.rdoColumns["ValueOperator"].Value + " iif(isnull([" + critrs.rdoColumns["DestDDID"].Value + "]), Null, cdbl([" + critrs.rdoColumns["DestDDID"].Value + "])))";
							//UPGRADE_WARNING: Couldn't resolve default property of object DataType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						} else if (DataType == "Time") {
							if (critrs.rdoColumns["SourceDDID1"].Value == 289) {
								//UPGRADE_WARNING: Couldn't resolve default property of object stophere. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								stophere = true;
							}
							//find the related date field
							modGlobal.gv_sql = "select Datefieldddid from tbl_Setup_datadef ";
							modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + critrs.rdoColumns["SourceDDID1"].Value;
							thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
							//UPGRADE_WARNING: Couldn't resolve default property of object DateFieldDDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							DateFieldDDID1 = thisrs.rdoColumns["DateFieldDDID"].Value;
							thisrs.Close();

							modGlobal.gv_sql = "select Datefieldddid from tbl_Setup_datadef ";
							modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + critrs.rdoColumns["DestDDID"].Value;
							thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
							//UPGRADE_WARNING: Couldn't resolve default property of object DateFieldDDID2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							DateFieldDDID2 = thisrs.rdoColumns["DateFieldDDID"].Value;
							thisrs.Close();

							//UPGRADE_WARNING: Couldn't resolve default property of object DateFieldDDID2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object DateFieldDDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + "  iif ([" + critrs.rdoColumns["SourceDDID1"].Value + "] is not null and [" + critrs.rdoColumns["SourceDDID1"].Value + "] <> '' and [" + critrs.rdoColumns["DestDDID"].Value + "] is not null and [" + critrs.rdoColumns["DestDDID"].Value + "] <> '' and [" + DateFieldDDID1 + "] is not null and [" + DateFieldDDID1 + "] <> '' and [" + DateFieldDDID2 + "] is not null and [" + DateFieldDDID2 + "] <> '' , ";
							//UPGRADE_WARNING: Couldn't resolve default property of object DateFieldDDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " cdate([" + DateFieldDDID1 + "] &  ' ' & [" + critrs.rdoColumns["SourceDDID1"].Value + "]) ";
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + critrs.rdoColumns["ValueOperator"].Value;
							//UPGRADE_WARNING: Couldn't resolve default property of object DateFieldDDID2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " cdate([" + DateFieldDDID2 + "] &  ' ' & [" + critrs.rdoColumns["DestDDID"].Value + "]) ";
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + ", false) ";
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " iif(isnull([" + critrs.rdoColumns["SourceDDID1"].Value + "]), Null, [" + critrs.rdoColumns["SourceDDID1"].Value + "] " + critrs.rdoColumns["ValueOperator"].Value + " iif(isnull([" + critrs.rdoColumns["DestDDID"].Value + "]), Null, [" + critrs.rdoColumns["DestDDID"].Value + "]))";
						}
						//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						thiscriteria = thiscriteria + " )";

						//resp = InputBox("", "", thiscriteria)
						// a value after added or subtracted from another field
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						thiscriteria = " (";
						//UPGRADE_WARNING: Couldn't resolve default property of object DataType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (DataType == "Date") {
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " iif(isnull([" + critrs.rdoColumns["SourceDDID1"].Value + "]) or isnull([" + critrs.rdoColumns["SourceDDID2"].Value + "]), false, datediff('" + critrs.rdoColumns["DateUnit"].Value + "', Cdate([" + critrs.rdoColumns["SourceDDID1"].Value + "]), Cdate([" + critrs.rdoColumns["SourceDDID2"].Value + "])) " + critrs.rdoColumns["ValueOperator"].Value + " " + critrs.rdoColumns["Value"].Value + ")";

							//UPGRADE_WARNING: Couldn't resolve default property of object DataType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						} else if (DataType == "Time") {
							//find the related date field
							modGlobal.gv_sql = "select Datefieldddid from tbl_Setup_datadef ";
							modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + critrs.rdoColumns["SourceDDID1"].Value;
							thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
							//UPGRADE_WARNING: Couldn't resolve default property of object DateFieldDDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							DateFieldDDID1 = thisrs.rdoColumns["DateFieldDDID"].Value;
							thisrs.Close();

							modGlobal.gv_sql = "select Datefieldddid from tbl_Setup_datadef ";
							modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + critrs.rdoColumns["SourceDDID2"].Value;
							thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
							//UPGRADE_WARNING: Couldn't resolve default property of object DateFieldDDID2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							DateFieldDDID2 = thisrs.rdoColumns["DateFieldDDID"].Value;
							thisrs.Close();

							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = " (";
							//UPGRADE_WARNING: Couldn't resolve default property of object DateFieldDDID2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object DateFieldDDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " iif ([" + critrs.rdoColumns["SourceDDID1"].Value + "] is not null and [" + critrs.rdoColumns["SourceDDID1"].Value + "] <> '' and [" + critrs.rdoColumns["SourceDDID2"].Value + "] is not null and [" + critrs.rdoColumns["SourceDDID2"].Value + "] <> '' and [" + DateFieldDDID1 + "] is not null and [" + DateFieldDDID1 + "] <> '' and [" + DateFieldDDID2 + "] is not null and [" + DateFieldDDID2 + "] <> '' , ";
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " DateDiff('n', ";
							//UPGRADE_WARNING: Couldn't resolve default property of object DateFieldDDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " cdate([" + DateFieldDDID1 + "] &  ' ' & [" + critrs.rdoColumns["SourceDDID1"].Value + "]), ";
							//UPGRADE_WARNING: Couldn't resolve default property of object DateFieldDDID2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " cdate([" + DateFieldDDID2 + "] &  ' ' & [" + critrs.rdoColumns["SourceDDID2"].Value + "]) ";
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " )";
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + critrs.rdoColumns["ValueOperator"].Value + " " + critrs.rdoColumns["Value"].Value;
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + ", false) ";
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + ") ";

							//UPGRADE_WARNING: Couldn't resolve default property of object DataType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						} else if (DataType == "Number") {
							//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							thiscriteria = thiscriteria + " iif(isnull([" + critrs.rdoColumns["SourceDDID1"].Value + "]) or isnull([" + critrs.rdoColumns["SourceDDID2"].Value + "]), false, cdbl([" + critrs.rdoColumns["SourceDDID1"].Value + "]) " + critrs.rdoColumns["FieldOperator"].Value + " cdbl([" + critrs.rdoColumns["SourceDDID2"].Value + "]) " + critrs.rdoColumns["ValueOperator"].Value + " " + critrs.rdoColumns["Value"].Value;
						}
						//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						thiscriteria = thiscriteria + " )";
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object thissetcriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (!string.IsNullOrEmpty(thissetcriteria)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object SetJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object thissetcriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						thissetcriteria = thissetcriteria + " " + SetJoinOperator + " " + thiscriteria;
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object thiscriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object thissetcriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						thissetcriteria = thiscriteria;
					}


					critrs.MoveNext();
				}
				critrs.Close();

				//UPGRADE_WARNING: Couldn't resolve default property of object msgCriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (!string.IsNullOrEmpty(msgCriteria)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object thissetcriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object mainJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object msgCriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					msgCriteria = msgCriteria + " " + mainJoinOperator + " (" + thissetcriteria + ")";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object thissetcriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object msgCriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					msgCriteria = " (" + thissetcriteria + ") ";
				}

				setrs.MoveNext();
			}
			setrs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object msgCriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (!string.IsNullOrEmpty(msgCriteria)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object msgCriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				functionReturnValue = msgCriteria;
			}
			return functionReturnValue;

		}

		private void cmdExport_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object msg = null;
			object MeasLinkID = null;
			object MeasureSetDesc = null;
			object MeasureSetID = null;
			object ICDPopDDID = null;
			object NumberOfCasesDDID = null;
			object measure_catid = null;
			object submitSubgroupCategoryID = null;
			object SUBMITCLEANUPRECORDID = null;
			object CriteriaDesc = null;
			object SubmitCleanupCritID = null;
			object CleanupDesc = null;
			object SubmitCleanupID = null;
			object SubmitValSetG2ID = null;
			object SourceTable = null;
			object fieldid = null;
			object SubmitValSetG1ID = null;
			object GroupsOp = null;
			object Group2Op = null;
			object Group1Op = null;
			object submitvalsetid = null;
			object submitvalid = null;
			object ddid2 = null;
			object DDID1 = null;
			object SubmitCriteriaID = null;
			object AggregateFieldID = null;
			object submitSubgroupFieldID = null;
			object CalcValue = null;
			object AggregateFunction = null;
			object SubGroupID = null;
			object Title = null;
			object grouprowID = null;
			object ShowTotal = null;
			object ShowOnReport = null;
			object ShowGroupHeader = null;
			object GroupName = null;
			object FieldTypeVal = null;
			object ValidationTitle = null;
			object ValidID = null;
			object ValidationCount = null;
			object msgid = null;
			object OrderNumber = null;
			object ImportFieldID = null;
			object methodnumber = null;
			object ImportSetupID = null;
			object ImportListID = null;
			object MeasureID = null;
			object criteriaID = null;
			object OrderID = null;
			object FieldCaption = null;
			object ReportName = null;
			object ReportID = null;
			object ValType = null;
			//UPGRADE_NOTE: Operator was upgraded to Operator_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			object Operator_Renamed = null;
			object Display = null;
			object HospStatGroupID2 = null;
			object HospStatGroupID1 = null;
			object HospStatValidID = null;
			object GroupOrder = null;
			object groupid = null;
			object IndLinkID = null;
			object IndicatorSetDesc = null;
			object IndicatorSetID = null;
			object IndicatorParentID = null;
			object IndicatorDepID = null;
			object IndicatorDDID = null;
			object IndicatorGroupsetID = null;
			object AppCare = null;
			object JCCode = null;
			object EndDateTimeFieldID = null;
			object StartDateTimeFieldID = null;
			object PatientType = null;
			object MeasureSet = null;
			object CMSCode = null;
			object CMSSampleFieldDDID = null;
			object MeasureDataUsage = null;
			object BaseType = null;
			object StatewidePageOrientation = null;
			object RiskAdjustSGID = null;
			object ContinuousSGID = null;
			object IndScale = null;
			object BreakoutType = null;
			object BestPractice = null;
			object MeasureTimeBy = null;
			object EndTimeFieldID = null;
			object EndDateFieldID = null;
			object StartTimeFieldID = null;
			object StartDateFieldID = null;
			object RiskAdjusted = null;
			object CalcType = null;
			object IndicatorType = null;
			object JCAHOID = null;
			object lastupdatedate = null;
			object Description = null;
			object IndicatorID = null;
			object TableValidationAfterFieldUpdateID = null;
			object setvalue = null;
			object TableValidationActionID = null;
			object CriteriaSet = null;
			object DateUnit = null;
			object FieldOperator = null;
			object Value = null;
			object ValueOperator = null;
			object DestDDID = null;
			object SourceDDID2 = null;
			object SourceDDID1 = null;
			object CriteriaTitle = null;
			object ValidationType = null;
			object TableValidationID = null;
			object msgCriteria = null;
			object UserAction = null;
			object EffDate = null;
			object JoinOperator = null;
			object MessageType = null;
			object message = null;
			object TableValidationMessageID = null;
			object Datadefactionid = null;
			object ActionCode = null;
			object ActionDesc = null;
			object Dataentryactionid = null;
			var i = 0;
			object InActive = null;
			object IsPhysician = null;
			object AllowUTD = null;
			object ParentDDID = null;
			object DateFieldDDID = null;
			object OldFieldName = null;
			object Required_EffDate = null;
			object Required = null;
			object help = null;
			object LookupTableID = null;
			object FieldCategory = null;
			object fieldorder = null;
			object FieldSize = null;
			object FieldType = null;
			object FieldName = null;
			object DDID = null;
			object DisplayOrder = null;
			object GroupDescription = null;
			object indicatorgroupid = null;
			object SortOrder = null;
			object FIELDVALUE = null;
			object OldID = null;
			object Id = null;
			object LookupID = null;
			object RecordStatus = null;
			object state = null;
			object CompareToDesc = null;
			object OldTableName = null;
			object TableType = null;
			object BaseTable = null;
			object basetableid = null;
			object StateVersion = null;
			object ps = null;
			object UpdateFile = null;
			object VersionStartDate = null;
			//every setup record in all of the tables will be imported to a text file
			//first line of each table will be tablename in [], followed by the records in the table
			// in a comma delimited format
			//resp = MsgBox("Please make sure that a diskette is inserted before creating an update. Continue?", vbOKCancel, "Create an update for Access database.")
			//If resp = vbNo Then
			//    Exit Sub
			//End If
			//UPGRADE_WARNING: Couldn't resolve default property of object VersionStartDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			VersionStartDate = "";
			if (OptForHospitals.Checked == true & modGlobal.gv_selecteddatabase != "Current") {
				if (string.IsNullOrEmpty(cboStartQuarter.Text) | string.IsNullOrEmpty(cboStartYear.Text)) {
					Interaction.MsgBox("The Setup start date has to be defined.");
					return;
				} else {
					if (cboStartQuarter.Text == "1") {
						//UPGRADE_WARNING: Couldn't resolve default property of object VersionStartDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						VersionStartDate = "1/1/" + cboStartYear.Text;
					} else if (cboStartQuarter.Text == "2") {
						//UPGRADE_WARNING: Couldn't resolve default property of object VersionStartDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						VersionStartDate = "4/1/" + cboStartYear.Text;
					} else if (cboStartQuarter.Text == "3") {
						//UPGRADE_WARNING: Couldn't resolve default property of object VersionStartDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						VersionStartDate = "7/1/" + cboStartYear.Text;
					} else if (cboStartQuarter.Text == "4") {
						//UPGRADE_WARNING: Couldn't resolve default property of object VersionStartDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						VersionStartDate = "10/1/" + cboStartYear.Text;
					}
				}
			}

			//UpdateFile = "F:\Dev\IHA\Hosp\Hosp00\COPUpdate.txt"
			if (lstSelectedImportLayouts.Items.Count == 0) {
				Interaction.MsgBox("Please select at least one import layout, before exporting the setup.");
				return;
			}

			My.MyProject.Forms.FileFind.Text = "Specify the destination directory for COPUpdat.txt";
			My.MyProject.Forms.FileFind.ShowDialog();
			if (!string.IsNullOrEmpty(modGlobal.gv_SelectedDirectory)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object UpdateFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				UpdateFile = modGlobal.gv_SelectedDirectory + (Strings.Mid(modGlobal.gv_SelectedDirectory, Strings.Len(modGlobal.gv_SelectedDirectory), 1) == "\\" ? "COPUpdat.txt" : "\\COPUpdat.txt");
			} else {
				return;
			}

			//On Error GoTo UpdateErr

			//UpdateFile = "A:\COPUpdat.txt"


			this.Refresh();


			modGlobal.gv_sql = "{ call UpdateSavedGroupCriteriaLogic }";
			ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
			//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps.Execute();
			//UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps.Close();

			modGlobal.gv_sql = "{ call UpdateMeasureCriteriaMultSelLogic }";
			ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
			//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps.Execute();
			//UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileNum = FreeFile();
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object UpdateFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.FileOpen(FileNum, UpdateFile, OpenMode.Output);

			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			//if the setup is created for a specific State, the JC Version does not change
			// but the state version changes.
			//If gv_State <> "" Then
			//
			//     gv_sql = "Select max(versionNumber) as JCVersion from tbl_setup_Version"
			//     Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
			//     JCVersion = gv_rs!JCVersion
			//End If

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[VERSION]");
			if (OptForHospitals.Checked == true) {
				if (modGlobal.gv_selecteddatabase == "Current" | modGlobal.gv_selecteddatabase == "COPWebSetup") {
					//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FileSystem.PrintLine(FileNum, "\"" + txtNextVersionNumber.Text + "\"");
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object JCVersion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FileSystem.PrintLine(FileNum, "\"" + JCVersion + "\"");
				}

			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + "" + "\"");
			}

			if (!string.IsNullOrEmpty(cboStartQuarter.Text)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "[VERSIONSTARTDATE]");
				if (Convert.ToDouble(cboStartQuarter.Text) == 1) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FileSystem.PrintLine(FileNum, "\"" + "1/1/" + cboStartYear.Text + "\"");
				} else if (Convert.ToDouble(cboStartQuarter.Text) == 2) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FileSystem.PrintLine(FileNum, "\"" + "4/1/" + cboStartYear.Text + "\"");
				} else if (Convert.ToDouble(cboStartQuarter.Text) == 3) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FileSystem.PrintLine(FileNum, "\"" + "7/1/" + cboStartYear.Text + "\"");
				} else if (Convert.ToDouble(cboStartQuarter.Text) == 4) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FileSystem.PrintLine(FileNum, "\"" + "10/1/" + cboStartYear.Text + "\"");
				}

			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[STATEVERSION]");
			//UPGRADE_WARNING: Couldn't resolve default property of object StateVersion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (!string.IsNullOrEmpty(StateVersion)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object StateVersion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_State + "\"" + "," + "\"" + StateVersion + "\"");
			}


			//8 - 3 - 06 SR Un-necessary
			//Print #FileNum, "[TABLESTRUCTURE]"

			//OutputTableStructure

			//
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[TABLEDEF]");
			modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY BASETABLE";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				basetableid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object BaseTable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				BaseTable = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object TableType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TableType = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object OldTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OldTableName = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CompareToDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CompareToDesc = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				state = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RecordStatus = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				basetableid = modGlobal.gv_rs.rdoColumns["basetableid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object BaseTable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				BaseTable = modGlobal.gv_rs.rdoColumns["BaseTable"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["TableType"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object TableType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					TableType = modGlobal.gv_rs.rdoColumns["TableType"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OldTableName"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object OldTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					OldTableName = modGlobal.gv_rs.rdoColumns["OldTableName"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["CompareToDesc"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object CompareToDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CompareToDesc = modGlobal.gv_rs.rdoColumns["CompareToDesc"].Value;
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object CompareToDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CompareToDesc = 0;
				}
				if (modGlobal.gv_rs.rdoColumns["state"].Value == modGlobal.gv_State) {
					//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					state = modGlobal.gv_rs.rdoColumns["state"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["RecordStatus"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RecordStatus = modGlobal.gv_rs.rdoColumns["RecordStatus"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object CompareToDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object OldTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object TableType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object BaseTable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + basetableid + "\"" + "," + "\"" + BaseTable + "\"" + "," + "\"" + TableType + "\"" + "," + "\"" + OldTableName + "\"" + "," + "\"" + CompareToDesc + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");

				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[MISCLOOKUPLIST]");
			modGlobal.gv_sql = "Select tbl_setup_MISCLOOKUPLIST.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_MISCLOOKUPLIST, tbl_setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_MISCLOOKUPLIST.BaseTableID = tbl_setup_TableDef.BaseTableID ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_TableDef.State is null or rtrim(tbl_setup_TableDef.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_TableDef.State is null or tbl_setup_TableDef.State = '" + modGlobal.gv_State + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY tbl_setup_TableDef.basetableid";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				basetableid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Id = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object OldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OldID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FIELDVALUE = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object SortOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SortOrder = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupID = modGlobal.gv_rs.rdoColumns["LookupID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				basetableid = modGlobal.gv_rs.rdoColumns["basetableid"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Id"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Id = modGlobal.gv_rs.rdoColumns["Id"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OldID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object OldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					OldID = modGlobal.gv_rs.rdoColumns["OldID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FIELDVALUE = modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["SortOrder"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object SortOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					SortOrder = modGlobal.gv_rs.rdoColumns["SortOrder"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object SortOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object OldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + LookupID + "\"" + "," + "\"" + basetableid + "\"" + "," + "\"" + Id + "\"" + "," + "\"" + OldID + "\"" + "," + "\"" + FIELDVALUE + "\"" + "," + "\"" + SortOrder + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[INDICATORGROUP]");
			modGlobal.gv_sql = "Select * from tbl_setup_INDICATORGROUP";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY indicatorgroupid";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object indicatorgroupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				indicatorgroupid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object GroupDescription. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				GroupDescription = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				basetableid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DisplayOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DisplayOrder = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				state = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RecordStatus = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object indicatorgroupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				indicatorgroupid = modGlobal.gv_rs.rdoColumns["indicatorgroupid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object GroupDescription. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				GroupDescription = modGlobal.gv_rs.rdoColumns["GroupDescription"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				basetableid = modGlobal.gv_rs.rdoColumns["basetableid"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DisplayOrder"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object DisplayOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DisplayOrder = modGlobal.gv_rs.rdoColumns["DisplayOrder"].Value;
				}
				if (modGlobal.gv_rs.rdoColumns["state"].Value == modGlobal.gv_State) {
					//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					state = modGlobal.gv_rs.rdoColumns["state"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["RecordStatus"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RecordStatus = modGlobal.gv_rs.rdoColumns["RecordStatus"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DisplayOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object GroupDescription. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object indicatorgroupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + indicatorgroupid + "\"" + "," + "\"" + GroupDescription + "\"" + "," + "\"" + basetableid + "\"" + "," + "\"" + DisplayOrder + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");

				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[DATADEF]");
			//txtMemoField.DataField = "Help"
			//UPGRADE_WARNING: Couldn't resolve default property of object dbgMemoField.Columns().DataField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dbgMemoField.get_Columns(0).DataField = "Message";
			modGlobal.gv_sql = "Select * from tbl_setup_DataDef";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where State is null or State = '" + modGlobal.gv_State + "'";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY FieldName";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				basetableid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldName = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldType = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldSize = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldorder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldorder = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldCategory. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldCategory = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object indicatorgroupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				indicatorgroupid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupTableID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				help = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Required. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Required = "";
				//
				//UPGRADE_WARNING: Couldn't resolve default property of object Required_EffDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Required_EffDate = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OldFieldName = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object SortOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SortOrder = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DateFieldDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DateFieldDDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				state = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RecordStatus = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ParentDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ParentDDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object AllowUTD. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				AllowUTD = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object IsPhysician. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IsPhysician = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object InActive. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				InActive = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				basetableid = modGlobal.gv_rs.rdoColumns["basetableid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldName = modGlobal.gv_rs.rdoColumns["FieldName"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FieldType"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FieldType = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FieldSize"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FieldSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FieldSize = modGlobal.gv_rs.rdoColumns["FieldSize"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FieldCategory"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FieldCategory. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FieldCategory = modGlobal.gv_rs.rdoColumns["FieldCategory"].Value;
				}
				if (modGlobal.gv_rs.rdoColumns["state"].Value == modGlobal.gv_State) {
					//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					state = modGlobal.gv_rs.rdoColumns["state"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["RecordStatus"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RecordStatus = modGlobal.gv_rs.rdoColumns["RecordStatus"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ParentDDID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ParentDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ParentDDID = modGlobal.gv_rs.rdoColumns["ParentDDID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["AllowUTD"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object AllowUTD. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					AllowUTD = modGlobal.gv_rs.rdoColumns["AllowUTD"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["IsPhysician"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object IsPhysician. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					IsPhysician = (modGlobal.gv_rs.rdoColumns["IsPhysician"].Value ? 1 : 0);
				}

				//If DDID = 57 Then
				//    test = 2
				//End If

				modGlobal.gv_sql = "Select Help as Message from tbl_setup_DataDef";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + DDID;
				rdcMemoField.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				rdcMemoField.CtlRefresh();
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				dbgMemoField.CtlRefresh();
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(dbgMemoField.get_Columns(0))) {
					//UPGRADE_WARNING: Couldn't resolve default property of object dbgMemoField.Columns(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					help = dbgMemoField.get_Columns(0);
					for (i = 1; i <= Strings.Len(help); i++) {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (Strings.Mid(help, i, 1) == Strings.Chr(13)) {
							//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Strings.Mid(help, i, 1) = "|";
							//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						} else if (Strings.Mid(help, i, 1) == Strings.Chr(183)) {
							//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Strings.Mid(help, i, 1) = "*";
							//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						} else if (Strings.Mid(help, i, 1) == Strings.Chr(146) | Strings.Mid(help, i, 1) == Strings.Chr(145)) {
							//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Strings.Mid(help, i, 1) = "'";
							//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						} else if (Strings.Mid(help, i, 1) == Strings.Chr(150)) {
							//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Strings.Mid(help, i, 1) = "-";
							//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						} else if (Strings.Mid(help, i, 1) == Strings.Chr(148) | Strings.Mid(help, i, 1) == Strings.Chr(147)) {
							//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Strings.Mid(help, i, 1) = "\"";
							//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						} else if (Strings.Asc(Strings.Mid(help, i, 1)) == 233) {
							//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Strings.Mid(help, i, 1) = Strings.Mid(help, i, 1);
							//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						} else if (Strings.Asc(Strings.Mid(help, i, 1)) > 126) {
							//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Strings.Mid(help, i, 1) = " ";
						}
					}
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				help = modGlobal.ConvertDoubleQuote(ref help);
				//If Not IsNull(gv_rs!Help) Then
				//    Help = gv_rs!Help
				//End If
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OldFieldName"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					OldFieldName = modGlobal.gv_rs.rdoColumns["OldFieldName"].Value;
				}

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["SortOrder"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object SortOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					SortOrder = modGlobal.gv_rs.rdoColumns["SortOrder"].Value;
				}

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DateFieldDDID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object DateFieldDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DateFieldDDID = modGlobal.gv_rs.rdoColumns["DateFieldDDID"].Value;
				}

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Required"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Required. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Required = modGlobal.gv_rs.rdoColumns["Required"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Required_EffDate"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Required_EffDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Required_EffDate = modGlobal.gv_rs.rdoColumns["Required_EffDate"].Value;
				}

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["InActive"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object InActive. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					InActive = 0;
				} else if (modGlobal.gv_rs.rdoColumns["InActive"].Value == "I") {
					//UPGRADE_WARNING: Couldn't resolve default property of object InActive. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					InActive = 1;
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object InActive. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					InActive = 0;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object InActive. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IsPhysician. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object AllowUTD. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ParentDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DateFieldDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SortOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Required_EffDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Required. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object help. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldCategory. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + DDID + "\"" + "," + "\"" + basetableid + "\"" + "," + "\"" + FieldName + "\"" + "," + "\"" + FieldType + "\"" + "," + "\"" + FieldSize + "\"" + "," + "\"" + FieldCategory + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + help + "\"" + "," + "\"" + Required + "\"" + "," + "\"" + Required_EffDate + "\"" + "," + "\"" + OldFieldName + "\"" + "," + "\"" + SortOrder + "\"" + "," + "\"" + DateFieldDDID + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"" + "," + "\"" + ParentDDID + "\"" + "," + "\"" + AllowUTD + "\"" + "," + "\"" + IsPhysician + "\"" + "," + "\"" + InActive + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//not used for Member
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[DATAENTRYACTIONS]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_dataentryactions  ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object Dataentryactionid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Dataentryactionid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ActionDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ActionDesc = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ActionCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ActionCode = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object Dataentryactionid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Dataentryactionid = modGlobal.gv_rs.rdoColumns["Dataentryactionid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ActionDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ActionDesc = modGlobal.gv_rs.rdoColumns["ActionDesc"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ActionCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ActionCode = modGlobal.gv_rs.rdoColumns["ActionCode"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object ActionCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ActionDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Dataentryactionid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + Dataentryactionid + "\"" + "," + "\"" + ActionDesc + "\"" + "," + "\"" + ActionCode + "\"");
				modGlobal.gv_rs.MoveNext();
			}


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[DATADEFACTIONS]");
			modGlobal.gv_sql = "Select dda.*, dea.ActionDesc, dea.ActionCode ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_DataDefactions as dda ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_datadef as dd ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on dda.ddid = dd.ddid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_dataentryactions as dea ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on dda.dataentryactionid = dea.dataentryactionid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (dd.State is null or rtrim(dd.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where dd.State is null or dd.State = '" + modGlobal.gv_State + "'";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.RecordStatus = '' or dd.Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY dd.DDID";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object Datadefactionid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Datadefactionid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Dataentryactionid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Dataentryactionid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ActionDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ActionDesc = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ActionCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ActionCode = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object Datadefactionid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Datadefactionid = modGlobal.gv_rs.rdoColumns["Datadefactionid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object Dataentryactionid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Dataentryactionid = modGlobal.gv_rs.rdoColumns["Dataentryactionid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ActionDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ActionDesc = modGlobal.gv_rs.rdoColumns["ActionDesc"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ActionCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ActionCode = modGlobal.gv_rs.rdoColumns["ActionCode"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object Dataentryactionid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ActionCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ActionDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Datadefactionid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + Datadefactionid + "\"" + "," + "\"" + DDID + "\"" + "," + "\"" + ActionDesc + "\"" + "," + "\"" + ActionCode + "\"" + "," + "\"" + Dataentryactionid + "\"");
				modGlobal.gv_rs.MoveNext();

			}


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[TABLEVALIDATIONMESSAGE]");
			//UPGRADE_WARNING: Couldn't resolve default property of object dbgMemoField.Columns().DataField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dbgMemoField.get_Columns(0).DataField = "Message";
			modGlobal.gv_sql = "Select * from TBL_SETUP_TableValidationMessage";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " and TableValidationMessageid not in  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select tv.TableValidationMessageid  ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  from TBL_SETUP_TableValidation as tv ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  where tv.Sourceddid1 not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + "  or (tv.SourceDDID2 is not null and tv.SourceDDID2 not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  or (tv.DestDDID is not null and tv.DestDDID not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
			modGlobal.gv_sql = modGlobal.gv_sql + ")  ORDER BY basetableid";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationMessageID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TableValidationMessageID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				basetableid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				message = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MessageType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MessageType = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				state = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RecordStatus = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object EffDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				EffDate = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object UserAction. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				UserAction = "";


				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationMessageID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TableValidationMessageID = modGlobal.gv_rs.rdoColumns["TableValidationMessageID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				basetableid = modGlobal.gv_rs.rdoColumns["basetableid"].Value;

				modGlobal.gv_sql = "Select Message from TBL_SETUP_TableValidationMessage";
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationMessageID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where TableValidationMessageID = " + TableValidationMessageID;

				rdcMemoField.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				rdcMemoField.CtlRefresh();
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				dbgMemoField.CtlRefresh();
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(dbgMemoField.get_Columns(0))) {
					//UPGRADE_WARNING: Couldn't resolve default property of object dbgMemoField.Columns(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					message = dbgMemoField.get_Columns(0);
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				message = modGlobal.ConvertDoubleQuote(ref message);
				//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				message = modGlobal.RemoveCrLfFromString(message);

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["MessageType"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object MessageType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					MessageType = modGlobal.gv_rs.rdoColumns["MessageType"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["state"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					state = modGlobal.gv_rs.rdoColumns["state"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["EffDate"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object EffDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					EffDate = modGlobal.gv_rs.rdoColumns["EffDate"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["UserAction"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object UserAction. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					UserAction = modGlobal.gv_rs.rdoColumns["UserAction"].Value;
				}
				if (modGlobal.gv_rs.rdoColumns["state"].Value == modGlobal.gv_State) {
					//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					state = modGlobal.gv_rs.rdoColumns["state"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["RecordStatus"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RecordStatus = modGlobal.gv_rs.rdoColumns["RecordStatus"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object msgCriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgCriteria = TableValidationCriteria(ref JoinOperator, ref TableValidationMessageID);
				//UPGRADE_WARNING: Couldn't resolve default property of object msgCriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgCriteria = Strings.Replace(msgCriteria, "'", "|");
				//UPGRADE_WARNING: Couldn't resolve default property of object msgCriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgCriteria = modGlobal.ConvertDoubleQuote(ref msgCriteria);

				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object msgCriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object UserAction. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object EffDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MessageType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationMessageID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + TableValidationMessageID + "\"" + "," + "\"" + basetableid + "\"" + "," + "\"" + message + "\"" + "," + "\"" + MessageType + "\"" + "," + "\"" + state + "\"" + "," + "\"" + EffDate + "\"" + "," + "\"" + UserAction + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + msgCriteria + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");
				modGlobal.gv_rs.MoveNext();
			}


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[TABLEVALIDATION]");
			modGlobal.gv_sql = "Select tv.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  TBL_SETUP_TableValidation as tv ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  inner join TBL_SETUP_TableValidationMessage as tvm ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  on tv.TableValidationMessageid = tvm.TableValidationMessageid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (tvm.State is null or rtrim(tvm.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (tvm.State is null or tvm.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tvm.RecordStatus = '' or tvm.Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  and tv.Sourceddid1 in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + "  and (tv.SourceDDID2 is null or tv.SourceDDID2 in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  and (tv.DestDDID is null or tv.DestDDID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
			modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY tablevalidationid";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TableValidationID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationMessageID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TableValidationMessageID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValidationType = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaTitle = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object SourceDDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SourceDDID1 = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object SourceDDID2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SourceDDID2 = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DestDDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValueOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Value = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupTableID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DateUnit = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaSet = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TableValidationID = modGlobal.gv_rs.rdoColumns["TableValidationID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationMessageID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TableValidationMessageID = modGlobal.gv_rs.rdoColumns["TableValidationMessageID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValidationType = modGlobal.gv_rs.rdoColumns["ValidationType"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaTitle = modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object SourceDDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SourceDDID1 = modGlobal.gv_rs.rdoColumns["SourceDDID1"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["SourceDDID2"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object SourceDDID2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					SourceDDID2 = modGlobal.gv_rs.rdoColumns["SourceDDID2"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DestDDID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DestDDID = modGlobal.gv_rs.rdoColumns["DestDDID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ValueOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ValueOperator = modGlobal.gv_rs.rdoColumns["ValueOperator"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Value"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Value = modGlobal.gv_rs.rdoColumns["Value"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LookupID = modGlobal.gv_rs.rdoColumns["LookupID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FieldOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FieldOperator = modGlobal.gv_rs.rdoColumns["FieldOperator"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DateUnit"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DateUnit = modGlobal.gv_rs.rdoColumns["DateUnit"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaSet = modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SourceDDID2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SourceDDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationMessageID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + TableValidationID + "\"" + "," + "\"" + TableValidationMessageID + "\"" + "," + "\"" + ValidationType + "\"" + "," + "\"" + CriteriaTitle + "\"" + "," + "\"" + SourceDDID1 + "\"" + "," + "\"" + SourceDDID2 + "\"" + "," + "\"" + DestDDID + "\"" + "," + "\"" + ValueOperator + "\"" + "," + "\"" + Value + "\"" + "," + "\"" + LookupID + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + FieldOperator + "\"" + "," + "\"" + DateUnit + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + CriteriaSet + "\"");
				modGlobal.gv_rs.MoveNext();
			}


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[TABLEVALIDATIONACTION]");
			modGlobal.gv_sql = "Select tva.* from TBL_SETUP_TableValidationAction as tva ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  inner join TBL_SETUP_TableValidationMessage as tvm ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  on tva.TableValidationMessageid = tvm.TableValidationMessageid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (tvm.State is null or rtrim(tvm.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (tvm.State is null or tvm.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tvm.RecordStatus = '' or tvm.Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  and tva.ddid in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY DDID";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationActionID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TableValidationActionID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationMessageID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TableValidationMessageID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object setvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				setvalue = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationActionID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TableValidationActionID = modGlobal.gv_rs.rdoColumns["TableValidationActionID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationMessageID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TableValidationMessageID = modGlobal.gv_rs.rdoColumns["TableValidationMessageID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object setvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				setvalue = modGlobal.gv_rs.rdoColumns["setvalue"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object setvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationMessageID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationActionID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + TableValidationActionID + "\"" + "," + "\"" + TableValidationMessageID + "\"" + "," + "\"" + DDID + "\"" + "," + "\"" + setvalue + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[TABLEVALIDATIONAFTERFIELDUPDATE]");
			modGlobal.gv_sql = "Select tvafu.* from TBL_SETUP_TableValidationAfterfieldupdate as tvafu ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  inner join TBL_SETUP_TableValidationMessage as tvm ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  on tvafu.TableValidationMessageid = tvm.TableValidationMessageid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (tvm.State is null or rtrim(tvm.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (tvm.State is null or tvm.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tvm.RecordStatus = '' or tvm.Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY DDID";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationAfterFieldUpdateID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TableValidationAfterFieldUpdateID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationMessageID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TableValidationMessageID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationAfterFieldUpdateID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TableValidationAfterFieldUpdateID = modGlobal.gv_rs.rdoColumns["TableValidationAfterFieldUpdateID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationMessageID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TableValidationMessageID = modGlobal.gv_rs.rdoColumns["TableValidationMessageID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationMessageID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationAfterFieldUpdateID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + TableValidationAfterFieldUpdateID + "\"" + "," + "\"" + TableValidationMessageID + "\"" + "," + "\"" + DDID + "\"");
				modGlobal.gv_rs.MoveNext();
			}


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[INDICATOR]");
			modGlobal.gv_sql = "Select i.*, MeasureSetDesc  = (SELECT TOP 1 ms.MeasureSetDesc " + " FROM tbl_setup_MeasureSet ms, tbl_setup_measureSetMapmeas mm " + " Where ms.MeasureSetID = mm.MeasureSetID " + " and mm.IndicatorID = i.IndicatorID ) " + " from tbl_setup_INDICATOR i WHERE 1=1 ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (i.State is null or rtrim(i.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and i.State is null or i.State = '" + modGlobal.gv_State + "'";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (i.RecordStatus = '' or i.Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY i.Description";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			string line = null;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Description = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OldFieldName = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				state = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RecordStatus = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object lastupdatedate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lastupdatedate = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JCAHOID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JCAHOID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorType = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CalcType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CalcType = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object RiskAdjusted. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RiskAdjusted = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object StartDateFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				StartDateFieldID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object StartTimeFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				StartTimeFieldID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object EndDateFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				EndDateFieldID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object EndTimeFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				EndTimeFieldID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureTimeBy. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureTimeBy = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object BestPractice. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				BestPractice = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object BreakoutType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				BreakoutType = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object IndScale. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndScale = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ContinuousSGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ContinuousSGID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object RiskAdjustSGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RiskAdjustSGID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object StatewidePageOrientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				StatewidePageOrientation = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object BaseType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				BaseType = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureDataUsage. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureDataUsage = "";
				//1.19.2005 - SampleFieldDDID
				//UPGRADE_WARNING: Couldn't resolve default property of object CMSSampleFieldDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CMSSampleFieldDDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CMSCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CMSCode = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureSet = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object PatientType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				PatientType = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object StartDateTimeFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				StartDateTimeFieldID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object EndDateTimeFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				EndDateTimeFieldID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JCCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JCCode = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object AppCare. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				AppCare = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = modGlobal.gv_rs.rdoColumns["IndicatorID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Description = modGlobal.gv_rs.rdoColumns["Description"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OldFieldName = modGlobal.gv_rs.rdoColumns["OldFieldName"].Value;


				if (modGlobal.gv_rs.rdoColumns["state"].Value == modGlobal.gv_State) {
					//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					state = modGlobal.gv_rs.rdoColumns["state"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["RecordStatus"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RecordStatus = modGlobal.gv_rs.rdoColumns["RecordStatus"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["lastupdatedate"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object lastupdatedate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lastupdatedate = modGlobal.gv_rs.rdoColumns["lastupdatedate"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JCAHOID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JCAHOID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JCAHOID = modGlobal.gv_rs.rdoColumns["JCAHOID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["IndicatorType"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					IndicatorType = modGlobal.gv_rs.rdoColumns["IndicatorType"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["CalcType"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object CalcType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CalcType = modGlobal.gv_rs.rdoColumns["CalcType"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["RiskAdjusted"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RiskAdjusted. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RiskAdjusted = modGlobal.gv_rs.rdoColumns["RiskAdjusted"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["StartDateFieldID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object StartDateFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					StartDateFieldID = modGlobal.gv_rs.rdoColumns["StartDateFieldID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["StartTimeFieldID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object StartTimeFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					StartTimeFieldID = modGlobal.gv_rs.rdoColumns["StartTimeFieldID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["EndDateFieldID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object EndDateFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					EndDateFieldID = modGlobal.gv_rs.rdoColumns["EndDateFieldID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["EndTimeFieldID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object EndTimeFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					EndTimeFieldID = modGlobal.gv_rs.rdoColumns["EndTimeFieldID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["EndTimeFieldID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object EndTimeFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					EndTimeFieldID = modGlobal.gv_rs.rdoColumns["EndTimeFieldID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["MeasureTimeBy"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object MeasureTimeBy. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					MeasureTimeBy = modGlobal.gv_rs.rdoColumns["MeasureTimeBy"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["BestPractice"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object BestPractice. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					BestPractice = modGlobal.gv_rs.rdoColumns["BestPractice"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["BreakoutType"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object BreakoutType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					BreakoutType = modGlobal.gv_rs.rdoColumns["BreakoutType"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Scale"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object IndScale. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					IndScale = modGlobal.gv_rs.rdoColumns["Scale"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ContinuousSGID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ContinuousSGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ContinuousSGID = modGlobal.gv_rs.rdoColumns["ContinuousSGID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["RiskAdjustSGID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RiskAdjustSGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RiskAdjustSGID = modGlobal.gv_rs.rdoColumns["RiskAdjustSGID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["StatewidePageOrientation"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object StatewidePageOrientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					StatewidePageOrientation = modGlobal.gv_rs.rdoColumns["StatewidePageOrientation"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["BaseType"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object BaseType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					BaseType = modGlobal.gv_rs.rdoColumns["BaseType"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["MeasureDataUsage"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object MeasureDataUsage. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					MeasureDataUsage = modGlobal.gv_rs.rdoColumns["MeasureDataUsage"].Value;
				}

				//1.20.05 - added cmscode
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["CMSSampleFieldDDID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object CMSSampleFieldDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CMSSampleFieldDDID = modGlobal.gv_rs.rdoColumns["CMSSampleFieldDDID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["CMSCode"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object CMSCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CMSCode = modGlobal.gv_rs.rdoColumns["CMSCode"].Value;
				}

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["MeasureSetDesc"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object MeasureSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					MeasureSet = modGlobal.gv_rs.rdoColumns["MeasureSetDesc"].Value;

					//UPGRADE_WARNING: Couldn't resolve default property of object MeasureSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.InStr(MeasureSet, "Non-Core") > 0) {
						//UPGRADE_WARNING: Couldn't resolve default property of object MeasureSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						MeasureSet = "Non-Core";
					}

				}

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["PatientType"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object PatientType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					PatientType = modGlobal.gv_rs.rdoColumns["PatientType"].Value;
				}

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["StartDateTimeFieldID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object StartDateTimeFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					StartDateTimeFieldID = modGlobal.gv_rs.rdoColumns["StartDateTimeFieldID"].Value;
				}

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["EndDateTimeFieldID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object EndDateTimeFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					EndDateTimeFieldID = modGlobal.gv_rs.rdoColumns["EndDateTimeFieldID"].Value;
				}

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JCCode"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JCCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JCCode = modGlobal.gv_rs.rdoColumns["JCCode"].Value;
				}

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["AppCare"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object AppCare. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					AppCare = (modGlobal.gv_rs.rdoColumns["AppCare"].Value ? 1 : 0);
				}



				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object CMSCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object CMSSampleFieldDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureDataUsage. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object BaseType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object StatewidePageOrientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object RiskAdjustSGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ContinuousSGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndScale. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object BreakoutType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object BestPractice. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureTimeBy. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object EndTimeFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object EndDateFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object StartTimeFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object StartDateFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object RiskAdjusted. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object CalcType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object JCAHOID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object lastupdatedate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				line = "\"" + IndicatorID + "\"" + "," + "\"" + Description + "\"" + "," + "\"" + OldFieldName + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"" + "," + "\"" + lastupdatedate + "\"" + "," + "\"" + JCAHOID + "\"" + "," + "\"" + IndicatorType + "\"" + "," + "\"" + CalcType + "\"" + "," + "\"" + RiskAdjusted + "\"" + "," + "\"" + StartDateFieldID + "\"" + "," + "\"" + StartTimeFieldID + "\"" + "," + "\"" + EndDateFieldID + "\"" + "," + "\"" + EndTimeFieldID + "\"" + "," + "\"" + MeasureTimeBy + "\"" + "," + "\"" + BestPractice + "\"" + "," + "\"" + BreakoutType + "\"" + "," + "\"" + IndScale + "\"" + "," + "\"" + ContinuousSGID + "\"" + "," + "\"" + RiskAdjustSGID + "\"" + "," + "\"" + StatewidePageOrientation + "\"" + "," + "\"" + BaseType + "\"" + "," + "\"" + MeasureDataUsage + "\"" + "," + "\"" + CMSSampleFieldDDID + "\"" + "," + "\"" + CMSCode + "\"" + "," + "\"" + MeasureSet + "\"";
				//UPGRADE_WARNING: Couldn't resolve default property of object PatientType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				line = line + "," + "\"" + PatientType + "\"";
				//UPGRADE_WARNING: Couldn't resolve default property of object StartDateTimeFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				line = line + "," + "\"" + StartDateTimeFieldID + "\"";
				//UPGRADE_WARNING: Couldn't resolve default property of object EndDateTimeFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				line = line + "," + "\"" + EndDateTimeFieldID + "\"";
				//UPGRADE_WARNING: Couldn't resolve default property of object JCCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				line = line + "," + "\"" + JCCode + "\"";
				//UPGRADE_WARNING: Couldn't resolve default property of object AppCare. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				line = line + "," + "\"" + AppCare + "\"";

				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, line);


				modGlobal.gv_rs.MoveNext();
			}


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[INDICATORGROUPSET]");
			modGlobal.gv_sql = "Select igs.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_INDICATORGroupSet as igs ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_indicatorgroup as ig ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on igs.indicatorgroupid = ig.indicatorgroupid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_DataDef as dd ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on igs.DDID = dd.DDID ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or rtrim(ig.state) = '') ";
				modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State is null or rtrim(dd.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or ig.State = '" + modGlobal.gv_State + "')";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State is null or dd.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (ig.RecordStatus = '' or ig.Recordstatus is null) ";
				modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.RecordStatus = '' or dd.Recordstatus is null) ";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorGroupsetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorGroupsetID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object indicatorgroupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				indicatorgroupid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldorder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldorder = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorGroupsetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorGroupsetID = modGlobal.gv_rs.rdoColumns["IndicatorGroupsetID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object indicatorgroupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				indicatorgroupid = modGlobal.gv_rs.rdoColumns["indicatorgroupid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldorder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldorder = modGlobal.gv_rs.rdoColumns["fieldorder"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object fieldorder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object indicatorgroupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorGroupsetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + IndicatorGroupsetID + "\"" + "," + "\"" + indicatorgroupid + "\"" + "," + "\"" + DDID + "\"" + "," + "\"" + fieldorder + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[DATAREQ]");
			modGlobal.gv_sql = "Select dr.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_DataReq as dr ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_Indicator as i ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on dr.IndicatorID = i.IndicatorID) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_DataDef as dd ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on dr.DDID = dd.DDID ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (i.State is null or rtrim(i.state) = '') ";
				modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State is null or rtrim(dd.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (i.State is null or i.State = '" + modGlobal.gv_State + "')";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State is null or dd.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (i.RecordStatus = '' or i.Recordstatus is null) ";
				modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.RecordStatus = '' or dd.Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY dd.DDID";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorDDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorDDID = modGlobal.gv_rs.rdoColumns["IndicatorDDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = modGlobal.gv_rs.rdoColumns["IndicatorID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + IndicatorDDID + "\"" + "," + "\"" + IndicatorID + "\"" + "," + "\"" + DDID + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[INDICATORDEP]");
			modGlobal.gv_sql = "Select idep.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_IndicatorDep as idep ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_Indicator as i ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on idep.IndicatorParentID =  i.IndicatorID ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (i.State is null or rtrim(i.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (i.State is null or i.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (i.RecordStatus = '' or i.Recordstatus is null) ";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorDepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorDepID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorParentID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorParentID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorDepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorDepID = modGlobal.gv_rs.rdoColumns["IndicatorDepID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorParentID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorParentID = modGlobal.gv_rs.rdoColumns["IndicatorParentID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = modGlobal.gv_rs.rdoColumns["IndicatorID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorParentID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorDepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + IndicatorDepID + "\"" + "," + "\"" + IndicatorParentID + "\"" + "," + "\"" + IndicatorID + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[INDICATORSET]");
			modGlobal.gv_sql = "Select * from tbl_setup_IndicatorSet";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where State is null or State = '" + modGlobal.gv_State + "'";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorSetID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorSetDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorSetDesc = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				state = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RecordStatus = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorSetID = modGlobal.gv_rs.rdoColumns["IndicatorSetID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorSetDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorSetDesc = modGlobal.gv_rs.rdoColumns["IndicatorSetDesc"].Value;
				if (modGlobal.gv_rs.rdoColumns["state"].Value == modGlobal.gv_State) {
					//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					state = modGlobal.gv_rs.rdoColumns["state"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["RecordStatus"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RecordStatus = modGlobal.gv_rs.rdoColumns["RecordStatus"].Value;
				}


				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorSetDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + IndicatorSetID + "\"" + "," + "\"" + IndicatorSetDesc + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[INDICATORSETFIELD]");
			modGlobal.gv_sql = "Select indsf.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_IndicatorSetFIELD as indsf ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_IndicatorSet as inds ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on indsf.indicatorsetid = inds.indicatorsetid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_Indicator as ind ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on indsf.indicatorid = ind.indicatorid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (inds.State is null or rtrim(inds.state) = '') ";
				modGlobal.gv_sql = modGlobal.gv_sql + " and (ind.State is null or rtrim(ind.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (inds.State is null or inds.State = '" + modGlobal.gv_State + "')";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (ind.State is null or ind.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (inds.RecordStatus = '' or inds.Recordstatus is null) ";
				modGlobal.gv_sql = modGlobal.gv_sql + " and (ind.RecordStatus = '' or ind.Recordstatus is null) ";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object IndLinkID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndLinkID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorSetID = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object IndLinkID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndLinkID = modGlobal.gv_rs.rdoColumns["IndLinkID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = modGlobal.gv_rs.rdoColumns["IndicatorID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorSetID = modGlobal.gv_rs.rdoColumns["IndicatorSetID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndLinkID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + IndLinkID + "\"" + "," + "\"" + IndicatorID + "\"" + "," + "\"" + IndicatorSetID + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[HOSPSTATGROUP]");
			modGlobal.gv_sql = "Select hsp.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroup hsp ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_IndicatorGroup as ig ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on hsp.indicatorgroupid = ig.indicatorgroupid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or rtrim(ig.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or ig.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (ig.RecordStatus = '' or ig.Recordstatus is null) ";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object groupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				groupid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object indicatorgroupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				indicatorgroupid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object GroupDescription. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				GroupDescription = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object GroupOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				GroupOrder = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object groupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				groupid = modGlobal.gv_rs.rdoColumns["HospStatGroupID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object indicatorgroupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				indicatorgroupid = modGlobal.gv_rs.rdoColumns["indicatorgroupid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object GroupDescription. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				GroupDescription = modGlobal.gv_rs.rdoColumns["GroupDescription"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object GroupDescription. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object indicatorgroupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object groupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + groupid + "\"" + "," + "\"" + indicatorgroupid + "\"" + "," + "\"" + GroupDescription + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[HOSPSTATGROUPINDICATOR]");
			modGlobal.gv_sql = "Select hgi.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_HospStatGroupIndicator as hgi";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join  tbl_setup_HospStatGroup as hsg ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on hgi.HospStatGroupID = hsg.HospStatGroupID) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join  tbl_setup_IndicatorGroup as ig ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on hsg.indicatorgroupid = ig.indicatorgroupid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or rtrim(ig.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or ig.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (ig.RecordStatus = '' or ig.Recordstatus is null) ";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object groupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				groupid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object groupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				groupid = modGlobal.gv_rs.rdoColumns["HospStatGroupID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = modGlobal.gv_rs.rdoColumns["IndicatorID"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object groupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + groupid + "\"" + "," + "\"" + IndicatorID + "\"");
				modGlobal.gv_rs.MoveNext();
			}


			//hosp stat group validation
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[HOSPSTATVAL]");
			//UPGRADE_WARNING: Couldn't resolve default property of object dbgMemoField.Columns().DataField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dbgMemoField.get_Columns(0).DataField = "Message";

			modGlobal.gv_sql = " Select hsv.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatVal as hsv";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where";
			modGlobal.gv_sql = modGlobal.gv_sql + " hsv.HospStatGroupID1 in";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select hsg.HospStatGroupID";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroup as hsg";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_IndicatorGroup as ig";
			modGlobal.gv_sql = modGlobal.gv_sql + " on hsg.indicatorgroupid = ig.indicatorgroupid";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or rtrim(ig.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or ig.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (ig.RecordStatus = '' or ig.Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " )";
			modGlobal.gv_sql = modGlobal.gv_sql + " and hsv.HospStatGroupID2 in";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select hsg.HospStatGroupID";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroup as hsg";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_IndicatorGroup as ig";
			modGlobal.gv_sql = modGlobal.gv_sql + " on hsg.indicatorgroupid = ig.indicatorgroupid";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or rtrim(ig.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or ig.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (ig.RecordStatus = '' or ig.Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " )";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object HospStatValidID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				HospStatValidID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object HospStatGroupID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				HospStatGroupID1 = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object HospStatGroupID2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				HospStatGroupID2 = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Display. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Display = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Operator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Operator_Renamed = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				message = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValType = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object EffDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				EffDate = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object HospStatValidID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				HospStatValidID = modGlobal.gv_rs.rdoColumns["HospStatValidID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object HospStatGroupID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				HospStatGroupID1 = modGlobal.gv_rs.rdoColumns["HospStatGroupID1"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object HospStatGroupID2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				HospStatGroupID2 = modGlobal.gv_rs.rdoColumns["HospStatGroupID2"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ValType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValType = modGlobal.gv_rs.rdoColumns["Type"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object Display. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Display = modGlobal.gv_rs.rdoColumns["Display"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object Operator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Operator_Renamed = modGlobal.gv_rs.rdoColumns["Operator"].Value;

				modGlobal.gv_sql = "Select Message from tbl_setup_HospStatVal";
				//UPGRADE_WARNING: Couldn't resolve default property of object HospStatValidID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where HospStatValidID = " + HospStatValidID;
				rdcMemoField.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				rdcMemoField.CtlRefresh();
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				dbgMemoField.CtlRefresh();
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(dbgMemoField.get_Columns(0))) {
					//UPGRADE_WARNING: Couldn't resolve default property of object dbgMemoField.Columns(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					message = dbgMemoField.get_Columns(0);
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				message = modGlobal.ConvertDoubleQuote(ref message);

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["EffDate"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object EffDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					EffDate = modGlobal.gv_rs.rdoColumns["EffDate"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object ValType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object EffDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Operator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Display. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object HospStatGroupID2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object HospStatGroupID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object HospStatValidID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + HospStatValidID + "\"" + "," + "\"" + HospStatGroupID1 + "\"" + "," + "\"" + HospStatGroupID2 + "\"" + "," + "\"" + Display + "\"" + "," + "\"" + Operator_Renamed + "\"" + "," + "\"" + message + "\"" + "," + "\"" + EffDate + "\"" + "," + "\"" + ValType + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[HOSPSTATGROUPFIELDS]");
			modGlobal.gv_sql = "Select hsgf.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_HospStatGroupFields as hsgf ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join  tbl_setup_HospStatGroup as hsg ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on hsgf.HospStatGroupID = hsg.HospStatGroupID) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join  tbl_setup_IndicatorGroup as ig ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on hsg.indicatorgroupid = ig.indicatorgroupid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or rtrim(ig.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or ig.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (ig.RecordStatus = '' or ig.Recordstatus is null) ";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object groupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				groupid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldorder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldorder = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object groupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				groupid = modGlobal.gv_rs.rdoColumns["HospStatGroupID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldorder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldorder = modGlobal.gv_rs.rdoColumns["fieldorder"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object fieldorder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object groupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + groupid + "\"" + "," + "\"" + DDID + "\"" + "," + "\"" + fieldorder + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SAVEDADHOCREPORTS]");
			modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReports";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY Report_Name";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ReportID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ReportName = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				basetableid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				state = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RecordStatus = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ReportID = modGlobal.gv_rs.rdoColumns["Report_ID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ReportName = modGlobal.gv_rs.rdoColumns["Report_name"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				basetableid = modGlobal.gv_rs.rdoColumns["basetableid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				if (modGlobal.gv_rs.rdoColumns["state"].Value == modGlobal.gv_State) {
					//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					state = modGlobal.gv_rs.rdoColumns["state"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["RecordStatus"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RecordStatus = modGlobal.gv_rs.rdoColumns["RecordStatus"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + ReportID + "\"" + "," + "\"" + ReportName + "\"" + "," + "\"" + basetableid + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + "Y" + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SAVEDADHOCREPORTFIELDS]");
			modGlobal.gv_sql = "Select arf.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SavedAdhocReportFields as arf ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_SavedAdhocReports as ar ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on arf.Report_ID = ar.Report_ID ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ar.State is null or rtrim(ar.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ar.State is null or ar.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (ar.RecordStatus = '' or ar.Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  and arf.ddid in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";


			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ReportID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldCaption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldCaption = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object OrderID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OrderID = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ReportID = modGlobal.gv_rs.rdoColumns["Report_ID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldCaption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldCaption = modGlobal.gv_rs.rdoColumns["FieldCaption"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object OrderID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OrderID = modGlobal.gv_rs.rdoColumns["OrderID"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object OrderID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldCaption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + ReportID + "\"" + "," + "\"" + DDID + "\"" + "," + "\"" + FieldCaption + "\"" + "," + "\"" + OrderID + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SAVEDADHOCREPORTCRITERIA]");
			modGlobal.gv_sql = "Select arc.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SavedAdhocReportCriteria as arc ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_SavedAdhocReports as ar ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on arc.Report_ID = ar.Report_ID ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ar.State is null or rtrim(ar.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ar.State is null or ar.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (ar.RecordStatus = '' or ar.Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  and arc.Sourceddid1 in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + "  and (arc.SourceDDID2 is null or arc.SourceDDID2 in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  and (arc.DestDDID is null or arc.DestDDID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + ")  ";


			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object criteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				criteriaID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ReportID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaTitle = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object SourceDDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SourceDDID1 = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object SourceDDID2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SourceDDID2 = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DestDDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValueOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Value = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupTableID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DateUnit = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaSet = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object criteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				criteriaID = modGlobal.gv_rs.rdoColumns["criteriaID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ReportID = modGlobal.gv_rs.rdoColumns["Report_ID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaTitle = modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object SourceDDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SourceDDID1 = modGlobal.gv_rs.rdoColumns["SourceDDID1"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["SourceDDID2"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object SourceDDID2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					SourceDDID2 = modGlobal.gv_rs.rdoColumns["SourceDDID2"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DestDDID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DestDDID = modGlobal.gv_rs.rdoColumns["DestDDID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ValueOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ValueOperator = modGlobal.gv_rs.rdoColumns["ValueOperator"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Value"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Value = modGlobal.gv_rs.rdoColumns["Value"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LookupID = modGlobal.gv_rs.rdoColumns["LookupID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FieldOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FieldOperator = modGlobal.gv_rs.rdoColumns["FieldOperator"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DateUnit"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DateUnit = modGlobal.gv_rs.rdoColumns["DateUnit"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaSet = modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SourceDDID2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SourceDDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object criteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + criteriaID + "\"" + "," + "\"" + ReportID + "\"" + "," + "\"" + CriteriaTitle + "\"" + "," + "\"" + SourceDDID1 + "\"" + "," + "\"" + SourceDDID2 + "\"" + "," + "\"" + DestDDID + "\"" + "," + "\"" + ValueOperator + "\"" + "," + "\"" + Value + "\"" + "," + "\"" + LookupID + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + FieldOperator + "\"" + "," + "\"" + DateUnit + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + CriteriaSet + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SAVEDADHOCREPORTSUMCRITERIA]");
			modGlobal.gv_sql = "Select arc.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SavedAdhocReportSumCriteria as arc ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_SavedAdhocReports as ar ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on arc.Report_ID = ar.Report_ID ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ar.State is null or rtrim(ar.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ar.State is null or ar.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (ar.RecordStatus = '' or ar.Recordstatus is null) ";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object criteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				criteriaID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ReportID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaTitle = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Operator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Operator_Renamed = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaSet = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object criteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				criteriaID = modGlobal.gv_rs.rdoColumns["criteriaID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ReportID = modGlobal.gv_rs.rdoColumns["Report_ID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaTitle = modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = modGlobal.gv_rs.rdoColumns["IndicatorID"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Operator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Operator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Operator_Renamed = modGlobal.gv_rs.rdoColumns["Operator"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["MeasureID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					MeasureID = modGlobal.gv_rs.rdoColumns["MeasureID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaSet = modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Operator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object criteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + criteriaID + "\"" + "," + "\"" + ReportID + "\"" + "," + "\"" + CriteriaTitle + "\"" + "," + "\"" + IndicatorID + "\"" + "," + "\"" + Operator_Renamed + "\"" + "," + "\"" + MeasureID + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + CriteriaSet + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object ImportListID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ImportListID = "";
			for (i = 0; i <= lstSelectedImportLayouts.Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportListID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(ImportListID)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ImportListID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ImportListID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSelectedImportLayouts, i);
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object ImportListID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ImportListID = ImportListID + "," + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSelectedImportLayouts, i);
				}
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object ImportListID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ImportListID = "(" + ImportListID + ")";


			//Not for Member
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[IMPORTALLSETUP]");
			modGlobal.gv_sql = "Select * from TBL_SETUP_IMPORTSetup ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportSetupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ImportSetupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object methodnumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				methodnumber = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Description = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				state = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RecordStatus = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object ImportSetupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ImportSetupID = modGlobal.gv_rs.rdoColumns["ImportSetupID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object methodnumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				methodnumber = modGlobal.gv_rs.rdoColumns["methodnumber"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Description = modGlobal.gv_rs.rdoColumns["Description"].Value;
				if (modGlobal.gv_rs.rdoColumns["state"].Value == modGlobal.gv_State) {
					//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					state = modGlobal.gv_rs.rdoColumns["state"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["RecordStatus"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RecordStatus = modGlobal.gv_rs.rdoColumns["RecordStatus"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object methodnumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportSetupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + ImportSetupID + "\"" + "," + "\"" + methodnumber + "\"" + "," + "\"" + Description + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//Not for member
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[IMPORTALLFIELDS]");
			modGlobal.gv_sql = "Select imf.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from TBL_SETUP_IMPORTFIELDS as imf ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTSetup as ims ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on imf.importsetupid = ims.importsetupid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or rtrim(ims.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or ims.State = '" + modGlobal.gv_State + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  and imf.DDID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";


			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ImportFieldID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportSetupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ImportSetupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OrderNumber = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object ImportSetupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ImportSetupID = modGlobal.gv_rs.rdoColumns["ImportSetupID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OrderNumber = modGlobal.gv_rs.rdoColumns["OrderNumber"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ImportFieldID = modGlobal.gv_rs.rdoColumns["ImportFieldID"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object ImportFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportSetupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + ImportSetupID + "\"" + "," + "\"" + DDID + "\"" + "," + "\"" + OrderNumber + "\"" + "," + "\"" + ImportFieldID + "\"");

				modGlobal.gv_rs.MoveNext();
			}

			//Not for Member
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[IMPORTALLVALIDATIONMESSAGE]");
			//UPGRADE_WARNING: Couldn't resolve default property of object dbgMemoField.Columns().DataField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dbgMemoField.get_Columns(0).DataField = "Message";
			modGlobal.gv_sql = "Select imvm.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from (TBL_SETUP_IMPORTValidationMessage as imvm ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTFIELDS as imf ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on imvm.importfieldid = imf.importfieldid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTSetup as ims ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on imf.importsetupid = ims.importsetupid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or rtrim(ims.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or ims.State = '" + modGlobal.gv_State + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  and imvm.DDID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";


			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				message = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValidationCount = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValidationType = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ImportFieldID = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgid = modGlobal.gv_rs.rdoColumns["msgid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ImportFieldID = modGlobal.gv_rs.rdoColumns["ImportFieldID"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ValidationCount"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ValidationCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ValidationCount = modGlobal.gv_rs.rdoColumns["ValidationCount"].Value;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValidationType = modGlobal.gv_rs.rdoColumns["ValidationType"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}

				modGlobal.gv_sql = "Select Message from tbl_setup_ImportValidationMessage";
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where MSGID = " + msgid;
				rdcMemoField.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				rdcMemoField.CtlRefresh();
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				dbgMemoField.CtlRefresh();
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(dbgMemoField.get_Columns(0))) {
					//UPGRADE_WARNING: Couldn't resolve default property of object dbgMemoField.Columns(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					message = dbgMemoField.get_Columns(0);
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				message = modGlobal.ConvertDoubleQuote(ref message);

				//UPGRADE_WARNING: Couldn't resolve default property of object ImportFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + DDID + "\"" + "," + "\"" + msgid + "\"" + "," + "\"" + message + "\"" + "," + "\"" + ValidationCount + "\"" + "," + "\"" + ValidationType + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + ImportFieldID + "\"");

				modGlobal.gv_rs.MoveNext();
			}

			//Not for Member
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[IMPORTALLVALIDATION]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from ((TBL_SETUP_IMPORTValidation as imv ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTValidationMessage as imvm ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on imv.msgid = imvm.msgid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTFIELDS as imf ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on imvm.importfieldid = imf.importfieldid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTSetup as ims ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on imf.importsetupid = ims.importsetupid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or rtrim(ims.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or ims.State = '" + modGlobal.gv_State + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  and imv.DDID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";


			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValidID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupTableID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValidationTitle = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldTypeVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldTypeVal = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Operator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Operator_Renamed = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FIELDVALUE = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldType = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object ValidID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValidID = modGlobal.gv_rs.rdoColumns["ValidID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValidationTitle = modGlobal.gv_rs.rdoColumns["ValidationTitle"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgid = modGlobal.gv_rs.rdoColumns["msgid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldTypeVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldTypeVal = modGlobal.gv_rs.rdoColumns["FieldTypeVal"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object Operator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Operator_Renamed = modGlobal.gv_rs.rdoColumns["Operator"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FIELDVALUE = modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldType = modGlobal.gv_rs.rdoColumns["FieldType"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Operator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldTypeVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + ValidID + "\"" + "," + "\"" + DDID + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + ValidationTitle + "\"" + "," + "\"" + msgid + "\"" + "," + "\"" + FieldTypeVal + "\"" + "," + "\"" + Operator_Renamed + "\"" + "," + "\"" + FIELDVALUE + "\"" + "," + "\"" + FieldType + "\"");

				modGlobal.gv_rs.MoveNext();
			}


			//Patient Import Specs
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[IMPORTSETUP]");
			modGlobal.gv_sql = "Select * from TBL_SETUP_IMPORTSetup ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object ImportListID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " and importsetupid in " + ImportListID;

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportSetupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ImportSetupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object methodnumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				methodnumber = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Description = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				state = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RecordStatus = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object ImportSetupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ImportSetupID = modGlobal.gv_rs.rdoColumns["ImportSetupID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object methodnumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				methodnumber = modGlobal.gv_rs.rdoColumns["methodnumber"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Description = modGlobal.gv_rs.rdoColumns["Description"].Value;
				if (modGlobal.gv_rs.rdoColumns["state"].Value == modGlobal.gv_State) {
					//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					state = modGlobal.gv_rs.rdoColumns["state"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["RecordStatus"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RecordStatus = modGlobal.gv_rs.rdoColumns["RecordStatus"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object methodnumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportSetupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + ImportSetupID + "\"" + "," + "\"" + methodnumber + "\"" + "," + "\"" + Description + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[IMPORTFIELDS]");
			modGlobal.gv_sql = "Select imf.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from TBL_SETUP_IMPORTFIELDS as imf ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTSetup as ims ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on imf.importsetupid = ims.importsetupid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or rtrim(ims.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or ims.State = '" + modGlobal.gv_State + "')";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object ImportListID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " and ims.importsetupid in " + ImportListID;
			modGlobal.gv_sql = modGlobal.gv_sql + "  and imf.DDID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ImportFieldID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportSetupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ImportSetupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OrderNumber = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object ImportSetupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ImportSetupID = modGlobal.gv_rs.rdoColumns["ImportSetupID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OrderNumber = modGlobal.gv_rs.rdoColumns["OrderNumber"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ImportFieldID = modGlobal.gv_rs.rdoColumns["ImportFieldID"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object ImportFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportSetupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + ImportSetupID + "\"" + "," + "\"" + DDID + "\"" + "," + "\"" + OrderNumber + "\"" + "," + "\"" + ImportFieldID + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[IMPORTVALIDATIONMESSAGE]");
			//UPGRADE_WARNING: Couldn't resolve default property of object dbgMemoField.Columns().DataField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dbgMemoField.get_Columns(0).DataField = "Message";
			modGlobal.gv_sql = "Select imvm.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from (TBL_SETUP_IMPORTValidationMessage as imvm ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTFIELDS as imf ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on imvm.importfieldid = imf.importfieldid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTSetup as ims ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on imf.importsetupid = ims.importsetupid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or rtrim(ims.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or ims.State = '" + modGlobal.gv_State + "')";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object ImportListID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " and ims.importsetupid in " + ImportListID;
			modGlobal.gv_sql = modGlobal.gv_sql + " and imvm.DDID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";

			//g = InputBox("", "", gv_sql)
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				message = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValidationCount = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValidationType = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ImportFieldID = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgid = modGlobal.gv_rs.rdoColumns["msgid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ImportFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ImportFieldID = modGlobal.gv_rs.rdoColumns["ImportFieldID"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ValidationCount"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ValidationCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ValidationCount = modGlobal.gv_rs.rdoColumns["ValidationCount"].Value;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValidationType = modGlobal.gv_rs.rdoColumns["ValidationType"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}

				modGlobal.gv_sql = "Select Message from tbl_setup_ImportValidationMessage";
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where MSGID = " + msgid;
				rdcMemoField.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				rdcMemoField.CtlRefresh();
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				dbgMemoField.CtlRefresh();
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(dbgMemoField.get_Columns(0))) {
					//UPGRADE_WARNING: Couldn't resolve default property of object dbgMemoField.Columns(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					message = dbgMemoField.get_Columns(0);
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				message = modGlobal.ConvertDoubleQuote(ref message);

				//UPGRADE_WARNING: Couldn't resolve default property of object ImportFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + DDID + "\"" + "," + "\"" + msgid + "\"" + "," + "\"" + message + "\"" + "," + "\"" + ValidationCount + "\"" + "," + "\"" + ValidationType + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + ImportFieldID + "\"");

				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[IMPORTVALIDATION]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from ((TBL_SETUP_IMPORTValidation as imv ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTValidationMessage as imvm ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on imv.msgid = imvm.msgid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTFIELDS as imf ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on imvm.importfieldid = imf.importfieldid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTSetup as ims ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on imf.importsetupid = ims.importsetupid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or rtrim(ims.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or ims.State = '" + modGlobal.gv_State + "')";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object ImportListID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " and ims.importsetupid in " + ImportListID;
			modGlobal.gv_sql = modGlobal.gv_sql + "  and imv.DDID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValidID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupTableID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValidationTitle = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldTypeVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldTypeVal = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Operator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Operator_Renamed = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FIELDVALUE = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldType = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object ValidID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValidID = modGlobal.gv_rs.rdoColumns["ValidID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValidationTitle = modGlobal.gv_rs.rdoColumns["ValidationTitle"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgid = modGlobal.gv_rs.rdoColumns["msgid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldTypeVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldTypeVal = modGlobal.gv_rs.rdoColumns["FieldTypeVal"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object Operator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Operator_Renamed = modGlobal.gv_rs.rdoColumns["Operator"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FIELDVALUE = modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldType = modGlobal.gv_rs.rdoColumns["FieldType"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Operator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldTypeVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidationTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValidID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + ValidID + "\"" + "," + "\"" + DDID + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + ValidationTitle + "\"" + "," + "\"" + msgid + "\"" + "," + "\"" + FieldTypeVal + "\"" + "," + "\"" + Operator_Renamed + "\"" + "," + "\"" + FIELDVALUE + "\"" + "," + "\"" + FieldType + "\"");

				modGlobal.gv_rs.MoveNext();
			}


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SUBMITGROUP]");
			modGlobal.gv_sql = "Select * from TBL_SETUP_SubmitGroup";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object groupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				groupid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object GroupName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				GroupName = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ShowGroupHeader. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ShowGroupHeader = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OrderNumber = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ShowOnReport. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ShowOnReport = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				state = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RecordStatus = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ShowTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ShowTotal = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object groupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				groupid = modGlobal.gv_rs.rdoColumns["groupid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object GroupName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				GroupName = modGlobal.gv_rs.rdoColumns["GroupName"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ShowGroupHeader"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ShowGroupHeader. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ShowGroupHeader = modGlobal.gv_rs.rdoColumns["ShowGroupHeader"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OrderNumber"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					OrderNumber = modGlobal.gv_rs.rdoColumns["OrderNumber"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ShowOnReport"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ShowOnReport. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ShowOnReport = modGlobal.gv_rs.rdoColumns["ShowOnReport"].Value;
				}
				if (modGlobal.gv_rs.rdoColumns["state"].Value == modGlobal.gv_State) {
					//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					state = modGlobal.gv_rs.rdoColumns["state"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["RecordStatus"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RecordStatus = modGlobal.gv_rs.rdoColumns["RecordStatus"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ShowTotal"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ShowTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ShowTotal = modGlobal.gv_rs.rdoColumns["ShowTotal"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ShowTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ShowOnReport. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ShowGroupHeader. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object GroupName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object groupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + groupid + "\"" + "," + "\"" + GroupName + "\"" + "," + "\"" + ShowGroupHeader + "\"" + "," + "\"" + OrderNumber + "\"" + "," + "\"" + ShowOnReport + "\"" + "," + "\"" + ShowTotal + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");

				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SUBMITGROUPROW]");
			modGlobal.gv_sql = "Select sgr.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from TBL_SETUP_SubmitGroupRow as sgr ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_submitgroup as sg ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on sgr.groupid  = sg.groupid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sg.State is null or rtrim(sg.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sg.State is null or sg.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (sg.RecordStatus = '' or sg.Recordstatus is null) ";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object grouprowID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				grouprowID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object groupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				groupid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Title. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Title = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OrderNumber = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ShowOnReport. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ShowOnReport = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object grouprowID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				grouprowID = modGlobal.gv_rs.rdoColumns["grouprowID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object groupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				groupid = modGlobal.gv_rs.rdoColumns["groupid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object Title. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Title = modGlobal.gv_rs.rdoColumns["Title"].Value;

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OrderNumber"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					OrderNumber = modGlobal.gv_rs.rdoColumns["OrderNumber"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ShowOnReport"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ShowOnReport. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ShowOnReport = modGlobal.gv_rs.rdoColumns["ShowOnReport"].Value;
				}


				//UPGRADE_WARNING: Couldn't resolve default property of object ShowOnReport. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Title. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object groupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object grouprowID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + grouprowID + "\"" + "," + "\"" + groupid + "\"" + "," + "\"" + Title + "\"" + "," + "\"" + OrderNumber + "\"" + "," + "\"" + ShowOnReport + "\"");

				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SUBMITSUBGROUP]");
			modGlobal.gv_sql = "Select ssg.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from (TBL_SETUP_SubmitSubGroup as ssg ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_SubmitGroupRow as sgr ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on ssg.grouprowid = sgr.grouprowid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_submitgroup as sg ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on sgr.groupid  = sg.groupid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sg.State is null or rtrim(sg.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sg.State is null or sg.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (sg.RecordStatus = '' or sg.Recordstatus is null) ";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubGroupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object grouprowID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				grouprowID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Title. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Title = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object AggregateFunction. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				AggregateFunction = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CalcValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CalcValue = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OrderNumber = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ShowOnReport. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ShowOnReport = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubGroupID = modGlobal.gv_rs.rdoColumns["SubGroupID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object grouprowID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				grouprowID = modGlobal.gv_rs.rdoColumns["grouprowID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object Title. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Title = modGlobal.gv_rs.rdoColumns["Title"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = modGlobal.gv_rs.rdoColumns["IndicatorID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object AggregateFunction. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				AggregateFunction = modGlobal.gv_rs.rdoColumns["AggregateFunction"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object CalcValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CalcValue = modGlobal.gv_rs.rdoColumns["CalcValue"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OrderNumber"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					OrderNumber = modGlobal.gv_rs.rdoColumns["OrderNumber"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ShowOnReport"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ShowOnReport. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ShowOnReport = modGlobal.gv_rs.rdoColumns["ShowOnReport"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JoinOperator = "And";
				}


				//UPGRADE_WARNING: Couldn't resolve default property of object ShowOnReport. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object AggregateFunction. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Title. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object grouprowID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + SubGroupID + "\"" + "," + "\"" + grouprowID + "\"" + "," + "\"" + Title + "\"" + "," + "\"" + IndicatorID + "\"" + "," + "\"" + AggregateFunction + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + OrderNumber + "\"" + "," + "\"" + ShowOnReport + "\"");

				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SUBMITSUBGROUPFIELDS]");
			modGlobal.gv_sql = "Select ssgf.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from ((TBL_SETUP_SubmitSubGroupFields as ssgf ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_SubmitSubGroup as ssg ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on ssgf.subgroupid = ssg.subgroupid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_SubmitGroupRow as sgr ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on ssg.grouprowid = sgr.grouprowid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_submitgroup as sg ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on sgr.groupid  = sg.groupid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sg.State is null or rtrim(sg.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sg.State is null or sg.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (sg.RecordStatus = '' or sg.Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  and ssgf.AggregateFieldID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";


			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object submitSubgroupFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				submitSubgroupFieldID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubGroupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object AggregateFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				AggregateFieldID = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object submitSubgroupFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				submitSubgroupFieldID = modGlobal.gv_rs.rdoColumns["submitSubgroupFieldID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubGroupID = modGlobal.gv_rs.rdoColumns["SubGroupID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object AggregateFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				AggregateFieldID = modGlobal.gv_rs.rdoColumns["AggregateFieldID"].Value;


				//UPGRADE_WARNING: Couldn't resolve default property of object AggregateFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object submitSubgroupFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + submitSubgroupFieldID + "\"" + "," + "\"" + SubGroupID + "\"" + "," + "\"" + AggregateFieldID + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SUBMITCRITERIA]");
			modGlobal.gv_sql = "Select sc.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from ((TBL_SETUP_SubmitCriteria as sc ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_SubmitSubGroup as ssg ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on sc.subgroupid = ssg.subgroupid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_SubmitGroupRow as sgr ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on ssg.grouprowid = sgr.grouprowid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_submitgroup as sg ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on sgr.groupid  = sg.groupid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sg.State is null or rtrim(sg.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sg.State is null or sg.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (sg.RecordStatus = '' or sg.Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  and ";
			modGlobal.gv_sql = modGlobal.gv_sql + "(sc.DDID1 is null or sc.DDID1 in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  and";
			modGlobal.gv_sql = modGlobal.gv_sql + "(sc.DDID2 is null or sc.DDID2 in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  and ";
			modGlobal.gv_sql = modGlobal.gv_sql + "(sc.DestDDID is null or sc.DestDDID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + ")";


			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubmitCriteriaID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubGroupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaTitle = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID1 = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ddid2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ddid2 = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DestDDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValueOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Value = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupTableID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DateUnit = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaSet = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubmitCriteriaID = modGlobal.gv_rs.rdoColumns["SubmitCriteriaID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubGroupID = modGlobal.gv_rs.rdoColumns["SubGroupID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaTitle = modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID1 = modGlobal.gv_rs.rdoColumns["DDID1"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ddid2"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ddid2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ddid2 = modGlobal.gv_rs.rdoColumns["ddid2"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DestDDID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DestDDID = modGlobal.gv_rs.rdoColumns["DestDDID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ValueOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ValueOperator = modGlobal.gv_rs.rdoColumns["ValueOperator"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Value"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Value = modGlobal.gv_rs.rdoColumns["Value"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LookupID = modGlobal.gv_rs.rdoColumns["LookupID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FieldOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FieldOperator = modGlobal.gv_rs.rdoColumns["FieldOperator"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DateUnit"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DateUnit = modGlobal.gv_rs.rdoColumns["DateUnit"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaSet = modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ddid2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + SubmitCriteriaID + "\"" + "," + "\"" + SubGroupID + "\"" + "," + "\"" + CriteriaTitle + "\"" + "," + "\"" + DDID1 + "\"" + "," + "\"" + ddid2 + "\"" + "," + "\"" + DestDDID + "\"" + "," + "\"" + ValueOperator + "\"" + "," + "\"" + Value + "\"" + "," + "\"" + LookupID + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + FieldOperator + "\"" + "," + "\"" + DateUnit + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + CriteriaSet + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//remove any validation that is defined for a non-existing indicator
			modGlobal.gv_sql = " Delete from TBL_SETUP_SubmitValSetGroup1 ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where submitvalsetid in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (Select svs.submitvalsetid ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     from  ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     TBL_SETUP_SubmitValSet as svs ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     inner join TBL_SETUP_SubmitValidation as sv ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     on svs.submitvalid = sv.submitvalid ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     where indicatorid not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     (select indicatorid from tbl_setup_indicator) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " ) ";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			modGlobal.gv_sql = " Delete from TBL_SETUP_SubmitValSetGroup2 ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where submitvalsetid in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (Select svs.submitvalsetid ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     from  ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     TBL_SETUP_SubmitValSet as svs ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     inner join TBL_SETUP_SubmitValidation as sv ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     on svs.submitvalid = sv.submitvalid ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     where indicatorid not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     (select indicatorid from tbl_setup_indicator) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " ) ";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			modGlobal.gv_sql = " Delete from TBL_SETUP_SubmitValSet ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where submitvalid in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (Select submitvalid ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     from  ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     TBL_SETUP_SubmitValidation ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     where indicatorid not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     (select indicatorid from tbl_setup_indicator) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " ) ";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//corrective action
			//Value and ValueOperator were switched when all the fields where
			// in the same group (from the same table), and compared to a value
			modGlobal.gv_sql = " Update TBL_SETUP_SubmitValSet ";
			modGlobal.gv_sql = modGlobal.gv_sql + " set [Value] = ValueOperator, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator = [Value]  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where [Value] is not null  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and isnumeric([Value]) = 0 ";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);


			modGlobal.gv_sql = " Delete TBL_SETUP_SubmitValidation ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     where indicatorid not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "     (select indicatorid from tbl_setup_indicator) ";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SUBMITVALIDATION]");
			//UPGRADE_WARNING: Couldn't resolve default property of object dbgMemoField.Columns().DataField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dbgMemoField.get_Columns(0).DataField = "Message";
			modGlobal.gv_sql = "Select * from TBL_SETUP_SubmitValidation";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				submitvalid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				message = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValType = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				state = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RecordStatus = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				submitvalid = modGlobal.gv_rs.rdoColumns["submitvalid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = modGlobal.gv_rs.rdoColumns["IndicatorID"].Value;

				modGlobal.gv_sql = "Select Message from TBL_SETUP_SubmitValidation";
				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID = " + submitvalid;
				rdcMemoField.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				rdcMemoField.CtlRefresh();
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				dbgMemoField.CtlRefresh();
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(dbgMemoField.get_Columns(0))) {
					//UPGRADE_WARNING: Couldn't resolve default property of object dbgMemoField.Columns(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					message = dbgMemoField.get_Columns(0);
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				message = modGlobal.ConvertDoubleQuote(ref message);

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ValType"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ValType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ValType = modGlobal.gv_rs.rdoColumns["ValType"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}
				if (modGlobal.gv_rs.rdoColumns["state"].Value == modGlobal.gv_State) {
					//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					state = modGlobal.gv_rs.rdoColumns["state"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["RecordStatus"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RecordStatus = modGlobal.gv_rs.rdoColumns["RecordStatus"].Value;
				}


				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + submitvalid + "\"" + "," + "\"" + IndicatorID + "\"" + "," + "\"" + message + "\"" + "," + "\"" + ValType + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SUBMITVALSET]");
			//UPGRADE_WARNING: Couldn't resolve default property of object dbgMemoField.Columns().DataField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dbgMemoField.get_Columns(0).DataField = "Message";
			modGlobal.gv_sql = "Select svs.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from TBL_SETUP_SubmitValSet as svs ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join  TBL_SETUP_SubmitValidation as sv ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on svs.submitvalid = sv.submitvalid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sv.State is null or rtrim(sv.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sv.State is null or sv.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (sv.RecordStatus = '' or sv.Recordstatus is null) ";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalsetid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				submitvalsetid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				submitvalid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Description = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Group1Op. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Group1Op = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Group2Op. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Group2Op = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object GroupsOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				GroupsOp = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Value = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValueOperator = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalsetid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				submitvalsetid = modGlobal.gv_rs.rdoColumns["submitvalsetid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				submitvalid = modGlobal.gv_rs.rdoColumns["submitvalid"].Value;

				modGlobal.gv_sql = "Select Description as Message from TBL_SETUP_SubmitValSet ";
				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalsetid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValSetID = " + submitvalsetid;
				rdcMemoField.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				rdcMemoField.CtlRefresh();
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				dbgMemoField.CtlRefresh();
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(dbgMemoField.get_Columns(0))) {
					//UPGRADE_WARNING: Couldn't resolve default property of object dbgMemoField.Columns(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Description = dbgMemoField.get_Columns(0);
				}

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Group1Op"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Group1Op. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Group1Op = modGlobal.gv_rs.rdoColumns["Group1Op"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Group2Op"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Group2Op. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Group2Op = modGlobal.gv_rs.rdoColumns["Group2Op"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["GroupsOp"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object GroupsOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					GroupsOp = modGlobal.gv_rs.rdoColumns["GroupsOp"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Value"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Value = modGlobal.gv_rs.rdoColumns["Value"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ValueOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ValueOperator = modGlobal.gv_rs.rdoColumns["ValueOperator"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object GroupsOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Group2Op. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Group1Op. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalsetid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + submitvalsetid + "\"" + "," + "\"" + submitvalid + "\"" + "," + "\"" + Description + "\"" + "," + "\"" + Group1Op + "\"" + "," + "\"" + Group2Op + "\"" + "," + "\"" + GroupsOp + "\"" + "," + "\"" + Value + "\"" + "," + "\"" + ValueOperator + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SUBMITVALSETGROUP1]");
			modGlobal.gv_sql = "Select svsg1.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from (TBL_SETUP_SubmitValSetGroup1 as svsg1 ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_SubmitValSet as svs ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on svsg1.submitvalsetid = svs.submitvalsetid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join  TBL_SETUP_SubmitValidation as sv ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on svs.submitvalid = sv.submitvalid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sv.State is null or rtrim(sv.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sv.State is null or sv.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (sv.RecordStatus = '' or sv.Recordstatus is null) ";
			}
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitValSetG1ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubmitValSetG1ID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalsetid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				submitvalsetid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object SourceTable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SourceTable = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitValSetG1ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubmitValSetG1ID = modGlobal.gv_rs.rdoColumns["SubmitValSetG1ID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalsetid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				submitvalsetid = modGlobal.gv_rs.rdoColumns["submitvalsetid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldid = modGlobal.gv_rs.rdoColumns["fieldid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object SourceTable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SourceTable = modGlobal.gv_rs.rdoColumns["SourceTable"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object SourceTable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalsetid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitValSetG1ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + SubmitValSetG1ID + "\"" + "," + "\"" + submitvalsetid + "\"" + "," + "\"" + fieldid + "\"" + "," + "\"" + SourceTable + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SUBMITVALSETGROUP2]");
			modGlobal.gv_sql = "Select svsg2.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from (TBL_SETUP_SubmitValSetGroup2 as svsg2 ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_SubmitValSet as svs ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on svsg2.submitvalsetid = svs.submitvalsetid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join  TBL_SETUP_SubmitValidation as sv ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on svs.submitvalid = sv.submitvalid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sv.State is null or rtrim(sv.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sv.State is null or sv.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (sv.RecordStatus = '' or sv.Recordstatus is null) ";
			}
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitValSetG2ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubmitValSetG2ID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalsetid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				submitvalsetid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object SourceTable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SourceTable = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitValSetG2ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubmitValSetG2ID = modGlobal.gv_rs.rdoColumns["SubmitValSetG2ID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalsetid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				submitvalsetid = modGlobal.gv_rs.rdoColumns["submitvalsetid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldid = modGlobal.gv_rs.rdoColumns["fieldid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object SourceTable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SourceTable = modGlobal.gv_rs.rdoColumns["SourceTable"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object SourceTable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object submitvalsetid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitValSetG2ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + SubmitValSetG2ID + "\"" + "," + "\"" + submitvalsetid + "\"" + "," + "\"" + fieldid + "\"" + "," + "\"" + SourceTable + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SUBMITCLEANUPITEMS]");
			modGlobal.gv_sql = " select sci.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from TBL_SETUP_SubmitCleanupItems as sci ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sci.State is null or rtrim(sci.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sci.State is null or sci.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (sci.RecordStatus = '' or sci.Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  and sci.DDID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitCleanupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubmitCleanupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CleanupDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CleanupDesc = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				state = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RecordStatus = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitCleanupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubmitCleanupID = modGlobal.gv_rs.rdoColumns["SubmitCleanupID"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["CleanupDesc"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object CleanupDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CleanupDesc = modGlobal.gv_rs.rdoColumns["CleanupDesc"].Value;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				if (modGlobal.gv_rs.rdoColumns["state"].Value == modGlobal.gv_State) {
					//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					state = modGlobal.gv_rs.rdoColumns["state"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["RecordStatus"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RecordStatus = modGlobal.gv_rs.rdoColumns["RecordStatus"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object CleanupDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitCleanupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + SubmitCleanupID + "\"" + "," + "\"" + CleanupDesc + "\"" + "," + "\"" + DDID + "\"" + ", " + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SUBMITCLEANUPCRIT]");
			//UPGRADE_WARNING: Couldn't resolve default property of object dbgMemoField.Columns().DataField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dbgMemoField.get_Columns(0).DataField = "Message";
			modGlobal.gv_sql = " select scc.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from TBL_SETUP_SubmitCleanupcrit as scc ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_SubmitCleanupItems as sci ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on scc.submitcleanupid = sci.submitcleanupid";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sci.State is null or rtrim(sci.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (sci.State is null or sci.State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (sci.RecordStatus = '' or sci.Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  and scc.DDID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";


			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitCleanupCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubmitCleanupCritID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitCleanupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubmitCleanupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FIELDVALUE = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Operator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Operator_Renamed = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupTableID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaDesc = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitCleanupCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubmitCleanupCritID = modGlobal.gv_rs.rdoColumns["SubmitCleanupCritID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitCleanupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubmitCleanupID = modGlobal.gv_rs.rdoColumns["SubmitCleanupID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FIELDVALUE = modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object Operator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Operator_Renamed = modGlobal.gv_rs.rdoColumns["Operator"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}

				modGlobal.gv_sql = "Select CriteriaDesc as Message from TBL_SETUP_SubmitCleanupCrit";
				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitCleanupCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCleanupCritID = " + SubmitCleanupCritID;
				rdcMemoField.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				rdcMemoField.CtlRefresh();
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				dbgMemoField.CtlRefresh();
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(dbgMemoField.get_Columns(0))) {
					//UPGRADE_WARNING: Couldn't resolve default property of object dbgMemoField.Columns(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CriteriaDesc = dbgMemoField.get_Columns(0);
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaDesc = modGlobal.ConvertDoubleQuote(ref CriteriaDesc);

				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Operator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitCleanupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SubmitCleanupCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + SubmitCleanupCritID + "\"" + "," + "\"" + SubmitCleanupID + "\"" + "," + "\"" + DDID + "\"" + "," + "\"" + FIELDVALUE + "\"" + "," + "\"" + Operator_Renamed + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + CriteriaDesc + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SUBMITCLEANUPRECORD]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from TBL_SETUP_Submitcleanuprecord ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = ''  or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  and DDID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object SUBMITCLEANUPRECORDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SUBMITCLEANUPRECORDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaTitle = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValueOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Value = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaSet = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				state = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RecordStatus = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object SUBMITCLEANUPRECORDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SUBMITCLEANUPRECORDID = modGlobal.gv_rs.rdoColumns["SUBMITCLEANUPRECORDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaTitle = modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValueOperator = modGlobal.gv_rs.rdoColumns["ValueOperator"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Value = modGlobal.gv_rs.rdoColumns["Value"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LookupID = modGlobal.gv_rs.rdoColumns["LookupID"].Value;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaSet = modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value;
				if (modGlobal.gv_rs.rdoColumns["state"].Value == modGlobal.gv_State) {
					//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					state = modGlobal.gv_rs.rdoColumns["state"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["RecordStatus"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RecordStatus = modGlobal.gv_rs.rdoColumns["RecordStatus"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object RecordStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object state. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SUBMITCLEANUPRECORDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + SUBMITCLEANUPRECORDID + "\"" + "," + "\"" + CriteriaTitle + "\"" + "," + "\"" + DDID + "\"" + "," + "\"" + ValueOperator + "\"" + "," + "\"" + Value + "\"" + "," + "\"" + LookupID + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + CriteriaSet + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");
				modGlobal.gv_rs.MoveNext();
			}


			//data from tbl_Setup_SubmitSubGroupCategory
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[SUBMITSUBGROUPCATEGORY]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SubmitSubGroupCategory ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object submitSubgroupCategoryID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				submitSubgroupCategoryID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubGroupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object measure_catid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measure_catid = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object submitSubgroupCategoryID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				submitSubgroupCategoryID = modGlobal.gv_rs.rdoColumns["submitSubgroupCategoryID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubGroupID = modGlobal.gv_rs.rdoColumns["SubGroupID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object measure_catid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measure_catid = modGlobal.gv_rs.rdoColumns["measure_catid"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object measure_catid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object submitSubgroupCategoryID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + submitSubgroupCategoryID + "\"" + "," + "\"" + SubGroupID + "\"" + "," + "\"" + measure_catid + "\"");

				modGlobal.gv_rs.MoveNext();

			}


			OutputMeasureVerificationTables();

			OutputIndicatorReportSetup();

			//data for Number of Cases (Used only in HOME)
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[INDICATORNUMBEROFCASES]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorNumberOfCases ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object NumberOfCasesDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				NumberOfCasesDDID = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = modGlobal.gv_rs.rdoColumns["IndicatorID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object NumberOfCasesDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				NumberOfCasesDDID = modGlobal.gv_rs.rdoColumns["NumberOfCasesDDID"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object NumberOfCasesDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + IndicatorID + "\"" + "," + "\"" + NumberOfCasesDDID + "\"");

				modGlobal.gv_rs.MoveNext();

			}

			OutputRelatedGroupLogic();

			//data for ICD Population (Used only in HOME)
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[INDICATORICDPOP]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorICDPOP ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ICDPopDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ICDPopDDID = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = modGlobal.gv_rs.rdoColumns["IndicatorID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object ICDPopDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ICDPopDDID = modGlobal.gv_rs.rdoColumns["ICDPopDDID"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object ICDPopDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + IndicatorID + "\"" + "," + "\"" + ICDPopDDID + "\"");

				modGlobal.gv_rs.MoveNext();

			}




			//data for Measure Set Linkagge 4.9.2009
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[MEASURESET]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureSet ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureSetID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureSetDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureSetDesc = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureSetID = modGlobal.gv_rs.rdoColumns["MeasureSetID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureSetDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureSetDesc = modGlobal.gv_rs.rdoColumns["MeasureSetDesc"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureSetDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + MeasureSetID + "\"" + "," + "\"" + MeasureSetDesc + "\"");

				modGlobal.gv_rs.MoveNext();

			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[MEASURESETMAPMEAS]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureSetMapMeas ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasLinkID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasLinkID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureSetID = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object MeasLinkID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasLinkID = modGlobal.gv_rs.rdoColumns["MeasLinkID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = modGlobal.gv_rs.rdoColumns["IndicatorID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureSetID = modGlobal.gv_rs.rdoColumns["MeasureSetID"].Value;


				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasLinkID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + MeasLinkID + "\"" + "," + "\"" + IndicatorID + "\"" + "," + "\"" + MeasureSetID + "\"");

				modGlobal.gv_rs.MoveNext();

			}


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.FileClose(FileNum);

			//insert the new version number in the version history
			if (optForTesting.Checked == false) {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(modGlobal.gv_State)) {
					modGlobal.gv_sql = "Insert into tbl_setup_version (VersionNumber, VersionDate, VersionStartDate, Notes)";
					modGlobal.gv_sql = modGlobal.gv_sql + " values (";
					if (modGlobal.gv_selecteddatabase == "Current") {
						modGlobal.gv_sql = modGlobal.gv_sql + txtNextVersionNumber.Text + ",";
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object JCVersion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + JCVersion + ",";
					}
					modGlobal.gv_sql = modGlobal.gv_sql + "'" + DateAndTime.Now + "',";
					//UPGRADE_WARNING: Couldn't resolve default property of object VersionStartDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (string.IsNullOrEmpty(VersionStartDate)) {
						modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object VersionStartDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " '" + VersionStartDate + "',";
					}
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + Strings.Replace(txtUserNotes.Text, "'", "''") + "')";
				} else {
					modGlobal.gv_sql = "Insert into tbl_setup_Stateversion (State, StateVersion, StateVersionDate, VersionStartDate, Notes)";
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " values ('" + modGlobal.gv_State + "',";
					if (modGlobal.gv_selecteddatabase == "Current") {
						modGlobal.gv_sql = modGlobal.gv_sql + txtNextVersionNumber.Text + ",";
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object StateVersion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + StateVersion + ",";
					}
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + DateAndTime.Now + "',";
					//UPGRADE_WARNING: Couldn't resolve default property of object VersionStartDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (string.IsNullOrEmpty(VersionStartDate)) {
						modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object VersionStartDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " '" + VersionStartDate + "',";
					}
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + Strings.Replace(txtUserNotes.Text, "'", "''") + "')";
				}

				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			}

			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

			//UPGRADE_WARNING: Couldn't resolve default property of object UpdateFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Interaction.MsgBox("The update file '" + UpdateFile + "' was successfully created.");

			return;
			UpdateErr:

			if (Err().Number == 71) {
				 // ERROR: Not supported in C#: OnErrorStatement

				//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				Interaction.MsgBox("The Destination directory does not exist. Please Check Again.");
				return;
			} else {

				//UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msg = "The following error occured in the process of creating an update for Access database: " + Strings.Chr(13) + Strings.Chr(10);
				//UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msg = msg + Err().Number + ": " + Err().Description;
				 // ERROR: Not supported in C#: OnErrorStatement

				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.FileClose(FileNum);
				//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				Interaction.MsgBox(msg);
				return;
			}

		}
		public void RefreshImportLayout()
		{
			var i = 0;
			object selectedlist = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object selectedlist. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedlist = "";
			for (i = 1; i <= lstSelectedImportLayouts.Items.Count; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object selectedlist. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(selectedlist)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedlist. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selectedlist = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSelectedImportLayouts, i - 1);
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedlist. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selectedlist = selectedlist + "," + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSelectedImportLayouts, i - 1);
				}
			}


			lstAvailableImportLayouts.Items.Clear();

			modGlobal.gv_sql = "select * from tbl_setup_ImportSetup ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (!string.IsNullOrEmpty(modGlobal.gv_State)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State = '" + modGlobal.gv_State + "' or State is null) ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null)";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object selectedlist. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (!string.IsNullOrEmpty(selectedlist)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object selectedlist. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and ImportSetupID not in (" + selectedlist + ") ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by recordstatus, description ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				lstAvailableImportLayouts.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["RecordStatus"].Value) | string.IsNullOrEmpty(modGlobal.gv_rs.rdoColumns["RecordStatus"].Value) ? "Active" : "Test   ") + " - " + modGlobal.gv_rs.rdoColumns["Description"].Value, modGlobal.gv_rs.rdoColumns["ImportSetupID"].Value));
				modGlobal.gv_rs.MoveNext();
			}

			modGlobal.gv_rs.Close();

		}

		private void cmdRemoveImportLayout_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstSelectedImportLayouts.SelectedIndex < 0) {
				return;
			}

			lstSelectedImportLayouts.Items.RemoveAt(lstSelectedImportLayouts.SelectedIndex);

			RefreshImportLayout();

		}

		private void frmExportSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			object StateVersion = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object JCVersion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JCVersion = modDBSetup.FindMaxRecID(ref "tbl_setup_Version", ref "VersionNumber");
				//UPGRADE_WARNING: Couldn't resolve default property of object JCVersion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				txtNextVersionNumber.Text = JCVersion;
				//UPGRADE_WARNING: Couldn't resolve default property of object JCVersion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				txtUserNotes.Text = JCVersion;
				//If txtUserNotes = "" Then
				//    Screen.MousePointer = 0
				//    MsgBox "Update file was not created."
				//    Exit Sub
				//End If
				//UPGRADE_WARNING: Couldn't resolve default property of object StateVersion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				StateVersion = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JCVersion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lblCurrentVersionNumber.Text = "JC Version#: " + JCVersion - 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object JCVersion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lblNextVersionNumber.Text = "JC Version#: " + JCVersion;
			} else {
				Interaction.MsgBox("This setup will not change the JC setup version, but will increment the State version number. The text file will include both the JC and the State specific setup definition.");
				//UPGRADE_WARNING: Couldn't resolve default property of object StateVersion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				StateVersion = modDBSetup.FindMaxRecID(ref "tbl_setup_StateVersion", ref "StateVersion");
				//UPGRADE_WARNING: Couldn't resolve default property of object StateVersion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				txtNextVersionNumber.Text = StateVersion;
				//UserNotes = InputBox("Please enter your notes for version " & NewVersion & " (for this State).", "New Setup Version", "No Notes.")
				//If UserNotes = "" Then
				//    Screen.MousePointer = 0
				//    MsgBox "Update file was not created."
				//    Exit Sub
				//End If
				modGlobal.gv_sql = "Select max(versionNumber) as JCVersion from tbl_setup_Version";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Couldn't resolve default property of object JCVersion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JCVersion = modGlobal.gv_rs.rdoColumns["JCVersion"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object StateVersion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lblCurrentVersionNumber.Text = "State Version#: " + StateVersion - 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object StateVersion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lblNextVersionNumber.Text = "State Version#: " + StateVersion;
			}
			if (modGlobal.gv_selecteddatabase == "Current") {
				txtNextVersionNumber.Top = lblNextVersionNumber.Top;
				lblNextVersionNumber.Visible = false;
				txtNextVersionNumber.Visible = true;
			} else {
				lblNextVersionNumber.Visible = true;
				txtNextVersionNumber.Visible = false;
			}

			RefreshImportLayout();
			RefreshSetupDateList();

		}

		private void Label7_Click()
		{

		}

		public void RefreshSetupDateList()
		{
			var i = 0;
			object thisyear = null;

			cboStartQuarter.Items.Clear();
			cboStartQuarter.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("1", 1));
			cboStartQuarter.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("2", 2));
			cboStartQuarter.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("3", 3));
			cboStartQuarter.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("4", 4));

			cboStartYear.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object thisyear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			thisyear = DateAndTime.Year(DateAndTime.Now) - 2;
			for (i = 1; i <= 5; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object thisyear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cboStartYear.Items.Add(thisyear);
				//UPGRADE_ISSUE: ComboBox property cboStartYear.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				//UPGRADE_WARNING: Couldn't resolve default property of object thisyear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(cboStartYear, cboStartYear.NewIndex, thisyear);
				//UPGRADE_WARNING: Couldn't resolve default property of object thisyear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				thisyear = thisyear + 1;
			}

		}

		private void ConvertTypeToAccessType()
		{

		}

		public void OutputTableStructure()
		{
			//Dim ll_cnt As Long
			//Dim oTable As rdoTable
			//Dim li_fields AS Long
			//Dim ls_TableName As String
			//
			//    For ll_cnt = 1 To gv_cn.rdoTables.Count
			//        Set oTable = gv_cn.rdoTables(ll_cnt)
			//        If Left(oTable.Name, 9) = "tbl_Setup" Then
			//        ls_TableName = mid(oTable.Name, 10, Len(oTable.Name))
			//
			//        'export the definition
			//            For li_fields = 1 To oTable.rdoColumns.Count
			//                Print #FileNum,"""" & ls_tablename & """" & "," & _
			//'                    iif(otable.rdoColumns(li_fields).Type
			//
			//            Next
			//        End If
			//    Next

			//fields for this table: tbl_Sys_SubmitSubGroupCategory
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_SubmitSubGroupCategory" + "\"" + "," + "\"" + "SubmitSubGroupCategoryID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_SubmitSubGroupCategory" + "\"" + "," + "\"" + "SubGroupID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_SubmitSubGroupCategory" + "\"" + "," + "\"" + "Measure_CATID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");

			//Print #FileNum, """" & "tbl_Sys_SubmitSubGroupCategory" & """" & "," & _
			//'                """" & "VersionNumber" & """" & "," & _
			//'                """" & "Integer" & """" & "," & _
			//'                """" & "0" & """"

			//PTP - added on 9/9/04
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "Tbl_Dat_IndicatorSubmit" + "\"" + "," + "\"" + "HFAP" + "\"" + "," + "\"" + "YesNo" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "Tbl_Dat_IndicatorSubmit" + "\"" + "," + "\"" + "QIO" + "\"" + "," + "\"" + "YesNo" + "\"" + "," + "\"" + "0" + "\"");
			//PTP - End of added on 9/9/04




			//fields for this table: tbl_Sys_MeasureCat
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCat" + "\"" + "," + "\"" + "MEASURE_CATID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCat" + "\"" + "," + "\"" + "Cat" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "1" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCat" + "\"" + "," + "\"" + "CAT_DESC" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCat" + "\"" + "," + "\"" + "CAT_Type" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "2" + "\"");

			//Print #FileNum, """" & "tbl_Sys_MeasureCat" & """" & "," & _
			//'                """" & "VersionNumber" & """" & "," & _
			//'                """" & "Integer" & """" & "," & _
			//'                """" & "0" & """"

			//fields for this table: tbl_Sys_MeasureCriteria
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "MeasureCriteriaID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "MeasureCriteriaSetID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "CriteriaTitle" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "200" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "DDID1" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "DDID2" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "ValueOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");

			//5.16.2005 - changed to 300 instead of 50
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "FieldValue" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "300" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "DestDDID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//3.11.2005 - changed to long integer
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "LookupID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "FieldOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "DateUnit" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "JoinOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "LookupTableID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "State" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "20" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "RecordStatus" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "20" + "\"");

			//Print #FileNum, """" & "tbl_Sys_MeasureCriteria" & """" & "," & _
			//'                """" & "VersionNumber" & """" & "," & _
			//'                """" & "Integer" & """" & "," & _
			//'                """" & "0" & """"


			//fields for this table: tbl_sys_MeasureCriteriaSet
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureCriteriaSet" + "\"" + "," + "\"" + "MeasureCriteriaSetID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureCriteriaSet" + "\"" + "," + "\"" + "MeasureCriteriaSet" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureCriteriaSet" + "\"" + "," + "\"" + "MeasureStepID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureCriteriaSet" + "\"" + "," + "\"" + "JoinOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "5" + "\"");

			//Print #FileNum, """" & "tbl_sys_MeasureCriteriaSet" & """" & "," & _
			//'                """" & "VersionNumber" & """" & "," & _
			//'                """" & "Integer" & """" & "," & _
			//'                """" & "0" & """"


			//fields for this table: tbl_sys_MeasureStepGroup
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStepGroup" + "\"" + "," + "\"" + "MeasureStepGroupID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStepGroup" + "\"" + "," + "\"" + "MeasureStepID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStepGroup" + "\"" + "," + "\"" + "MeasureStepGroup" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStepGroup" + "\"" + "," + "\"" + "JoinOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "5" + "\"");

			//fields for this table: tbl_sys_MeasureCriteriaSet
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStep" + "\"" + "," + "\"" + "MeasureStepID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStep" + "\"" + "," + "\"" + "MeasureID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStep" + "\"" + "," + "\"" + "MeasureStep" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStep" + "\"" + "," + "\"" + "Measure_CATID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


			//-SH modified 8.31.04 to include gotostep
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStep" + "\"" + "," + "\"" + "GoToStep" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			// - sh 6.14.05 to include isrisk field
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStep" + "\"" + "," + "\"" + "IsRisk" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_Indicator" + "\"" + "," + "\"" + "LastUpdateDate" + "\"" + "," + "\"" + "Date" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_submitgroup" + "\"" + "," + "\"" + "ShowTotal" + "\"" + "," + "\"" + "YesNo" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_submitcriteria" + "\"" + "," + "\"" + "DestDDID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_submitcriteria" + "\"" + "," + "\"" + "LookupTableID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Dat_savedAdhocReportCriteria" + "\"" + "," + "\"" + "LookupTableID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_TableValidationMessage" + "\"" + "," + "\"" + "mcriteria" + "\"" + "," + "\"" + "memo" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_TableValidation" + "\"" + "," + "\"" + "LookupTableID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_TableDef" + "\"" + "," + "\"" + "CompareToDesc" + "\"" + "," + "\"" + "YesNo" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_SubmitSubGroup" + "\"" + "," + "\"" + "JoinOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "10" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Dat_INDICATORSUBMIT" + "\"" + "," + "\"" + "CMS" + "\"" + "," + "\"" + "YesNo" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Dat_INDICATORSUBMIT" + "\"" + "," + "\"" + "PR" + "\"" + "," + "\"" + "YesNo" + "\"" + "," + "\"" + "0" + "\"");

			//    Print #FileNum, """" & "tbl_Sys_DATADEF" & """" & "," & _
			//'                    """" & "NumberFormat" & """" & "," & _
			//'                    """" & "Text" & """" & "," & _
			//'                    """" & "20" & """"
			//

			//AUTONUMBER SHOULD BE IMPLEMENTED IN MEMBER!
			//print #filenum, """" & "tbl_Sys_SAVEDADHOCREPORTSUMCRITERIA" & """" & "," & _
			//'                """" & "CRITERIAID" & """"" & "," & _
			//
			// 5.10.2005 - added new field & Setup tables for processing related & similar field groups
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "MeasureFieldGroupLogicID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_FieldGroup" + "\"" + "," + "\"" + "FieldGroupID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_FieldGroup" + "\"" + "," + "\"" + "FieldGroupName" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_FieldGroup" + "\"" + "," + "\"" + "VersionNumber" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_DDIDFieldGroup" + "\"" + "," + "\"" + "DDID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_DDIDFieldGroup" + "\"" + "," + "\"" + "FieldGroupID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_DDIDFieldGroup" + "\"" + "," + "\"" + "FieldGroupID" + "\"" + "," + "\"" + "VersionNumber" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_RelatedFieldGroup" + "\"" + "," + "\"" + "RelatedFieldGroupID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_RelatedFieldGroup" + "\"" + "," + "\"" + "RelatedFieldGroupName" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_RelatedFieldGroup" + "\"" + "," + "\"" + "VersionNumber" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_DDIDRelatedFieldGroup" + "\"" + "," + "\"" + "DDID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_DDIDRelatedFieldGroup" + "\"" + "," + "\"" + "RelatedFieldGroupID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_DDIDRelatedFieldGroup" + "\"" + "," + "\"" + "VersionNumber" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "MeasureFieldGroupLogicID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "CriteriaTitle" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "200" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "FieldID1" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "FieldID1IsGroup" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "FieldID2" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "FieldID2IsGroup" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "ValueOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "FieldValue" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "DestDDID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "DestDDIDIsGroup" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "LookupID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "FieldOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "DateUnit" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "JoinOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "LookupTableID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "OnlyProceedWithRelatedFieldGroup" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "OnlyProceedWithRelatedFieldGroup" + "\"" + "," + "\"" + "VersionNumber" + "\"" + "," + "\"" + "0" + "\"");

			//5.19.2005 - added for Is Between logic
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "FieldValueMax" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");

			//8.2.2005 - added for flowchart action table
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureStep" + "\"" + "," + "\"" + "FlowchartActionID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//8.2.2005 - added for flowchart action table
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFlowchartAction" + "\"" + "," + "\"" + "FlowchartActionID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFlowchartAction" + "\"" + "," + "\"" + "ActionDescription" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "255" + "\"");


		}

		public void OutputMeasureVerificationTables()
		{
			object actionDescription = null;
			object MeasureStepGroup = null;
			object MeasureStepGroupID = null;
			object multselany = null;
			object measurefieldgrouplogicid = null;
			object DateUnit = null;
			object FieldOperator = null;
			object LookupTableID = null;
			object LookupID = null;
			object FIELDVALUE = null;
			object ValueOperator = null;
			object DestDDID = null;
			object ddid2 = null;
			object DDID1 = null;
			object CriteriaTitle = null;
			object measureCriteriaID = null;
			object newid = null;
			object JoinOperator = null;
			object MeasureCriteriaSet = null;
			object MeasureCriteriaSetID = null;
			object flowchartactionid = null;
			object isrisk = null;
			object GoToStep = null;
			object measurestep = null;
			object MeasureID = null;
			object MeasureStepID = null;
			object CAT_TYPE = null;
			object CAT_DESC = null;
			object CAT = null;
			object measure_catid = null;
			//data from tbl_MeasureCat
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[MEASURECAT]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Measure_Cat ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object measure_catid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measure_catid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CAT. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CAT = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CAT_DESC. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CAT_DESC = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CAT_TYPE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CAT_TYPE = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object measure_catid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measure_catid = modGlobal.gv_rs.rdoColumns["measure_catid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object CAT. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CAT = modGlobal.gv_rs.rdoColumns["CAT"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["CAT_DESC"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object CAT_DESC. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CAT_DESC = modGlobal.gv_rs.rdoColumns["CAT_DESC"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["CAT_TYPE"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object CAT_TYPE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CAT_TYPE = modGlobal.gv_rs.rdoColumns["CAT_TYPE"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object CAT_TYPE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object CAT_DESC. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object CAT. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object measure_catid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + measure_catid + "\"" + "," + "\"" + CAT + "\"" + "," + "\"" + CAT_DESC + "\"" + "," + "\"" + CAT_TYPE + "\"");

				modGlobal.gv_rs.MoveNext();

			}

			//data from MeasureStep
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[MEASURESTEP]");
			modGlobal.gv_sql = "(Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from vuMeasureStepNonReplacement)";

			//add the replacement steps for summarization
			modGlobal.gv_sql = modGlobal.gv_sql + "UNION ALL (Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from vuMeasureStepReplacement)";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureStepID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object measurestep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measurestep = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object measure_catid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measure_catid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object GoToStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				GoToStep = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object isrisk. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				isrisk = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureStepID = modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureID = modGlobal.gv_rs.rdoColumns["MeasureID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object measurestep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measurestep = modGlobal.gv_rs.rdoColumns["measurestep"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object measure_catid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measure_catid = modGlobal.gv_rs.rdoColumns["measure_catid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object GoToStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				GoToStep = modGlobal.gv_rs.rdoColumns["GoToStep"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object isrisk. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				isrisk = modGlobal.gv_rs.rdoColumns["isrisk"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object flowchartactionid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				flowchartactionid = modGlobal.gv_rs.rdoColumns["flowchartactionid"].Value;


				//UPGRADE_WARNING: Couldn't resolve default property of object flowchartactionid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object isrisk. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object GoToStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object measure_catid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object measurestep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + MeasureStepID + "\"" + "," + "\"" + MeasureID + "\"" + "," + "\"" + measurestep + "\"" + "," + "\"" + measure_catid + "\"" + "," + "\"" + GoToStep + "\"" + "," + "\"" + isrisk + "\"" + "," + "\"" + flowchartactionid + "\"");

				modGlobal.gv_rs.MoveNext();

			}

			//    'add the replacement steps for summarization
			//    gv_sql = "Select * "
			//    gv_sql = gv_sql & " from tbl_Setup_MeasureStep "
			//    gv_sql = gv_sql & " where measureStepid in "
			//    gv_sql = gv_sql & " (select MeasureStepID from tbl_Setup_MeasureStepSubmitSubs)"
			//    gv_sql = gv_sql & "  AND measureid in (select indicatorid from tbl_Setup_indicator)"
			//
			//    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
			//    While Not gv_rs.EOF
			//        MeasureStepID = ""
			//        MeasureID = ""
			//        MeasureStep = ""
			//        Measure_CATID = ""
			//        GoToStep = ""
			//        IsRisk = ""
			//
			//        MeasureStepID = gv_rs!MeasureStepID
			//        MeasureID = gv_rs!MeasureID
			//        MeasureStep = gv_rs!MeasureStep
			//        Measure_CATID = gv_rs!Measure_CATID
			//        GoToStep = gv_rs!GoToStep
			//        IsRisk = gv_rs!IsRisk
			//
			//        Print #FileNum, """" & MeasureStepID & """" & "," & _
			//'                        """" & MeasureID & """" & "," & """" & MeasureStep & """" & "," & _
			//'                        """" & Measure_CATID & """" & "," & """" & GoToStep & """" & "," & """" & IsRisk & """" & "," & """" & flowchartactionid & """"
			//
			//        gv_rs.MoveNext
			//
			//     Wend
			//
			//data from MeasureCriteriaSet
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[MEASURECRITERIASET]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSet ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureStepID not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select MeasureStepID from tbl_Setup_MeasureStepSubmitSubs)";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureCriteriaSetID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureCriteriaSet = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureStepID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureCriteriaSetID = modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureCriteriaSet = modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureStepID = modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;


				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + MeasureCriteriaSetID + "\"" + "," + "\"" + MeasureCriteriaSet + "\"" + "," + "\"" + MeasureStepID + "\"" + "," + "\"" + JoinOperator + "\"");

				modGlobal.gv_rs.MoveNext();

			}


			//add the replacement sets for summarization
			//first create a unique id as compared to the ID's in tbl_Setup_MeasureCriteriaSet table
			modGlobal.gv_sql = "Select max(measureCriteriaSetID) as maxSetID  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSet ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			newid = modGlobal.gv_rs.rdoColumns["MaxSetID"].Value;
			modGlobal.gv_rs.Close();

			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSetSubmitSubs  ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				newid = newid + 1;

				//UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "update tbl_Setup_MeasureCriteriaSetSubmitSubs set ExportSetID = " + newid;
				modGlobal.gv_sql = modGlobal.gv_sql + " where measureCriteriaSetSubmitSubsID =  " + modGlobal.gv_rs.rdoColumns["measureCriteriaSetSubmitSubsID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				modGlobal.gv_rs.MoveNext();

			}
			modGlobal.gv_rs.Close();

			modGlobal.gv_sql = "Select mcsss.*, msss.MeasureStepID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSetSubmitSubs as mcsss ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_MeasureStepSubmitSubs as msss";
			modGlobal.gv_sql = modGlobal.gv_sql + " on mcsss.MeasureStepSubmitSubsID = msss.MeasureStepSubmitSubsID ";
			//g = InputBox("", "", gv_sql)
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureCriteriaSetID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureCriteriaSet = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureStepID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureCriteriaSetID = modGlobal.gv_rs.rdoColumns["ExportSetID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureCriteriaSet = modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureStepID = modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;


				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + MeasureCriteriaSetID + "\"" + "," + "\"" + MeasureCriteriaSet + "\"" + "," + "\"" + MeasureStepID + "\"" + "," + "\"" + JoinOperator + "\"");

				modGlobal.gv_rs.MoveNext();

			}

			//data from MeasureCriteria
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[MEASURECRITERIA]");
			modGlobal.gv_sql = "Select mc.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria  as mc ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where mc.measureCriteriaSetID not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select measureCriteriaSetID from ";
			modGlobal.gv_sql = modGlobal.gv_sql + " tbl_Setup_MeasureCriteriaSet as mcSets ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_MeasureStepSubmitSubs as ms ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on mcSets.MeasureStepID = ms.MeasureStepID";
			modGlobal.gv_sql = modGlobal.gv_sql + " )";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (mc.State is null or rtrim(mc.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (mc.State is null or mc.State = '" + modGlobal.gv_State + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  and ";
			modGlobal.gv_sql = modGlobal.gv_sql + "(mc.DDID1 is null or mc.DDID1 in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  and";
			modGlobal.gv_sql = modGlobal.gv_sql + "(mc.DDID2 is null or mc.DDID2 in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  and ";
			modGlobal.gv_sql = modGlobal.gv_sql + "(mc.DestDDID is null or mc.DestDDID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + ")";

			//Debug.Print gv_sql

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {


				//UPGRADE_WARNING: Couldn't resolve default property of object measureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measureCriteriaID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureCriteriaSetID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaTitle = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID1 = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ddid2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ddid2 = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DestDDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValueOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FIELDVALUE = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupTableID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DateUnit = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object measurefieldgrouplogicid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measurefieldgrouplogicid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object multselany. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				multselany = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object measureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measureCriteriaID = modGlobal.gv_rs.rdoColumns["measureCriteriaID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureCriteriaSetID = modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaTitle = modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID1 = modGlobal.gv_rs.rdoColumns["DDID1"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ddid2"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ddid2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ddid2 = modGlobal.gv_rs.rdoColumns["ddid2"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DestDDID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DestDDID = modGlobal.gv_rs.rdoColumns["DestDDID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ValueOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ValueOperator = modGlobal.gv_rs.rdoColumns["ValueOperator"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FIELDVALUE = modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LookupID = modGlobal.gv_rs.rdoColumns["LookupID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FieldOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FieldOperator = modGlobal.gv_rs.rdoColumns["FieldOperator"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DateUnit"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DateUnit = modGlobal.gv_rs.rdoColumns["DateUnit"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["measurefieldgrouplogicid"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object measurefieldgrouplogicid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					measurefieldgrouplogicid = modGlobal.gv_rs.rdoColumns["measurefieldgrouplogicid"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["multselany"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object multselany. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					multselany = (modGlobal.gv_rs.rdoColumns["multselany"].Value ? "1" : "0");
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object multselany. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object measurefieldgrouplogicid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ddid2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object measureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + measureCriteriaID + "\"" + "," + "\"" + MeasureCriteriaSetID + "\"" + "," + "\"" + CriteriaTitle + "\"" + "," + "\"" + DDID1 + "\"" + "," + "\"" + ddid2 + "\"" + "," + "\"" + DestDDID + "\"" + "," + "\"" + ValueOperator + "\"" + "," + "\"" + FIELDVALUE + "\"" + "," + "\"" + LookupID + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + FieldOperator + "\"" + "," + "\"" + DateUnit + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + measurefieldgrouplogicid + "\"" + "," + "\"" + multselany + "\"");
				modGlobal.gv_rs.MoveNext();
			}


			//add the replacement criteria for submission
			//first create a unique id as compared to the ID's in tbl_Setup_MeasureCriteriaSet table
			modGlobal.gv_sql = "Select max(measureCriteriaID) as maxCriteriaID  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			newid = modGlobal.gv_rs.rdoColumns["MaxCriteriaID"].Value;
			modGlobal.gv_rs.Close();

			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSubmitSubs  ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				newid = newid + 1;

				//UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "update tbl_Setup_MeasureCriteriaSubmitSubs set ExportCriteriaID = " + newid;
				modGlobal.gv_sql = modGlobal.gv_sql + " where measureCriteriaSubmitSubsID =  " + modGlobal.gv_rs.rdoColumns["measureCriteriaSubmitSubsID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				modGlobal.gv_rs.MoveNext();

			}
			modGlobal.gv_rs.Close();

			//update the exportsetid in the criteriatable
			modGlobal.gv_sql = "update tbl_Setup_MeasureCriteriaSubmitSubs  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " set tbl_Setup_MeasureCriteriaSubmitSubs.ExportSetID = tbl_Setup_MeasureCriteriaSetSubmitSubs.ExportSetID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSubmitSubs ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_MeasureCriteriaSetSubmitSubs ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_Setup_MeasureCriteriaSubmitSubs.MeasureCriteriaSetSubmitSubsID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " = tbl_Setup_MeasureCriteriaSetSubmitSubs.MeasureCriteriaSetSubmitSubsID ";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);


			modGlobal.gv_sql = "Select mc.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSubmitSubs as mc ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where 0 = 0 ";
			//mc.measureCriteriaSetID in "
			//gv_sql = gv_sql & " (select measureCriteriaSetID from "
			//gv_sql = gv_sql & " tbl_Setup_MeasureCriteriaSet as mcSets "
			//gv_sql = gv_sql & " inner join tbl_Setup_MeasureStepSubmitSubs as ms "
			//gv_sql = gv_sql & " on mcSets.MeasureStepID = ms.MeasureStepID"
			//gv_sql = gv_sql & " )"
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (mc.State is null or rtrim(mc.state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (mc.State is null or mc.State = '" + modGlobal.gv_State + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  and ";
			modGlobal.gv_sql = modGlobal.gv_sql + "(mc.DDID1 is null or mc.DDID1 in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  and";
			modGlobal.gv_sql = modGlobal.gv_sql + "(mc.DDID2 is null or mc.DDID2 in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  and ";
			modGlobal.gv_sql = modGlobal.gv_sql + "(mc.DestDDID is null or mc.DestDDID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
			}
			if (optActive.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "  )";
			modGlobal.gv_sql = modGlobal.gv_sql + ")";


			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {


				//UPGRADE_WARNING: Couldn't resolve default property of object measureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measureCriteriaID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureCriteriaSetID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaTitle = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID1 = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ddid2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ddid2 = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DestDDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValueOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FIELDVALUE = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupTableID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DateUnit = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object measurefieldgrouplogicid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measurefieldgrouplogicid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object multselany. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				multselany = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object measureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measureCriteriaID = modGlobal.gv_rs.rdoColumns["ExportCriteriaID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureCriteriaSetID = modGlobal.gv_rs.rdoColumns["ExportSetID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaTitle = modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID1 = modGlobal.gv_rs.rdoColumns["DDID1"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ddid2"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ddid2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ddid2 = modGlobal.gv_rs.rdoColumns["ddid2"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DestDDID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DestDDID = modGlobal.gv_rs.rdoColumns["DestDDID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ValueOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ValueOperator = modGlobal.gv_rs.rdoColumns["ValueOperator"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FIELDVALUE = modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LookupID = modGlobal.gv_rs.rdoColumns["LookupID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FieldOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FieldOperator = modGlobal.gv_rs.rdoColumns["FieldOperator"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DateUnit"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DateUnit = modGlobal.gv_rs.rdoColumns["DateUnit"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}




				//UPGRADE_WARNING: Couldn't resolve default property of object multselany. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object measurefieldgrouplogicid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ddid2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object measureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + measureCriteriaID + "\"" + "," + "\"" + MeasureCriteriaSetID + "\"" + "," + "\"" + CriteriaTitle + "\"" + "," + "\"" + DDID1 + "\"" + "," + "\"" + ddid2 + "\"" + "," + "\"" + DestDDID + "\"" + "," + "\"" + ValueOperator + "\"" + "," + "\"" + FIELDVALUE + "\"" + "," + "\"" + LookupID + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + FieldOperator + "\"" + "," + "\"" + DateUnit + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + measurefieldgrouplogicid + "\"" + "," + "\"" + multselany + "\"");
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[MEASURESTEPGROUP]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureStepGroup ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {

				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureStepGroupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureStepID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureCriteriaSetID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureStepGroup = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureStepGroupID = modGlobal.gv_rs.rdoColumns["MeasureStepGroupID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureStepID = modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureCriteriaSetID = modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureStepGroup = modGlobal.gv_rs.rdoColumns["MeasureStepGroup"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;


				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + MeasureStepGroupID + "\"" + "," + "\"" + MeasureStepID + "\"" + "," + "\"" + MeasureCriteriaSetID + "\"" + "," + "\"" + MeasureStepGroup + "\"" + "," + "\"" + JoinOperator + "\"");

				modGlobal.gv_rs.MoveNext();

			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[MEASUREFLOWCHARTACTION]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureFlowchartAction ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {

				//UPGRADE_WARNING: Couldn't resolve default property of object flowchartactionid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				flowchartactionid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object actionDescription. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				actionDescription = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object flowchartactionid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				flowchartactionid = modGlobal.gv_rs.rdoColumns["flowchartactionid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object actionDescription. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				actionDescription = modGlobal.gv_rs.rdoColumns["actionDescription"].Value;

				//UPGRADE_WARNING: Couldn't resolve default property of object actionDescription. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object flowchartactionid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + flowchartactionid + "\"" + "," + "\"" + actionDescription + "\"");

				modGlobal.gv_rs.MoveNext();

			}

		}

		private void OutputIndicatorReportSetup()
		{

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[INDICATORREPORTINCLUDES]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorReportIncludes ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["IncludeID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["IndicatorID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["SubGroupID"].Value + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["grouprowID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["grouprowID"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["SortOrder"].Value) ? "" : modGlobal.gv_rs.rdoColumns["SortOrder"].Value) + "\"");

				modGlobal.gv_rs.MoveNext();

			}
			modGlobal.gv_rs.Close();


			//    Print #FileNum, "[INDICATORREPORTNUMERATORS]"
			//    gv_sql = "Select * "
			//    gv_sql = gv_sql & " from tbl_Setup_IndicatorReportNumerators "
			//    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
			//    Do While Not gv_rs.EOF
			//
			//        Print #FileNum, """" & gv_rs!NumeratorID & """" & "," & _
			//'                        """" & gv_rs!IndicatorID & """" & "," & """" & gv_rs!HeadingText & """" & "," & _
			//'                        """" & gv_rs!FieldID & """"
			//
			//        gv_rs.MoveNext
			//
			//    Loop
			//    gv_rs.Close

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[INDICATORREPORTDENOMINATORS]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorReportDenominators ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {

				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["DenomFieldID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["SubGroupID"].Value + "\"" + "," + "\"" + Strings.Trim(modGlobal.gv_rs.rdoColumns["tName"].Value) + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["OpChar"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["fieldid"].Value + "\"");

				modGlobal.gv_rs.MoveNext();

			}
			modGlobal.gv_rs.Close();

		}

		private void OutputRelatedGroupLogic()
		{
			object CriteriaTitle = null;
			object fieldvaluemax = null;
			object onlyproceedwithrelatedfieldgroup = null;
			object LookupTableID = null;
			object JoinOperator = null;
			object DateUnit = null;
			object FieldOperator = null;
			object LookupID = null;
			object destddidisgroup = null;
			object DestDDID = null;
			object FIELDVALUE = null;
			object ValueOperator = null;
			object fieldid2isgroup = null;
			object fieldid2 = null;
			object fieldid1isgroup = null;
			object fieldid1 = null;
			object CRITERIATITILE = null;
			object measurefieldgrouplogicid = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[FIELDGROUP]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_FIELDGROUP ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {

				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["FIELDGroupID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["FIELDGROUPNAME"].Value + "\"");

				modGlobal.gv_rs.MoveNext();

			}
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[DDIDFIELDGROUP]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DDIDFIELDGROUP ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {

				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["DDID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["FIELDGroupID"].Value + "\"");

				modGlobal.gv_rs.MoveNext();

			}
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[RELATEDFIELDGROUP]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_RELATEDFIELDGROUP ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {

				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["RelatedFieldGroupID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["RelatedGroupName"].Value + "\"");

				modGlobal.gv_rs.MoveNext();

			}
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[DDIDRELATEDFIELDGROUP]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DDIDRELATEDFIELDGROUP ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {

				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["DDID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["RelatedFieldGroupID"].Value + "\"");

				modGlobal.gv_rs.MoveNext();

			}
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[MEASUREFIELDGROUPLOGIC]");
			modGlobal.gv_sql = "SELECT * FROM TBL_SETUP_MEASUREFIELDGROUPLOGIC";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {


				//UPGRADE_WARNING: Couldn't resolve default property of object measurefieldgrouplogicid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measurefieldgrouplogicid = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CRITERIATITILE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CRITERIATITILE = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldid1 = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid1isgroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldid1isgroup = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldid2 = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid2isgroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldid2isgroup = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValueOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FIELDVALUE = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DestDDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object destddidisgroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				destddidisgroup = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DateUnit = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupTableID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object onlyproceedwithrelatedfieldgroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				onlyproceedwithrelatedfieldgroup = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldvaluemax. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldvaluemax = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object measurefieldgrouplogicid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measurefieldgrouplogicid = modGlobal.gv_rs.rdoColumns["measurefieldgrouplogicid"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CriteriaTitle = modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["fieldid1"].Value))
					fieldid1 = modGlobal.gv_rs.rdoColumns["fieldid1"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid1isgroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldid1isgroup = modGlobal.gv_rs.rdoColumns["fieldid1isgroup"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["fieldid2"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object fieldid2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					fieldid2 = modGlobal.gv_rs.rdoColumns["fieldid2"].Value;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid2isgroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldid2isgroup = modGlobal.gv_rs.rdoColumns["fieldid2isgroup"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ValueOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ValueOperator = modGlobal.gv_rs.rdoColumns["ValueOperator"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FIELDVALUE = modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DestDDID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DestDDID = modGlobal.gv_rs.rdoColumns["DestDDID"].Value;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object destddidisgroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				destddidisgroup = modGlobal.gv_rs.rdoColumns["destddidisgroup"].Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LookupID = modGlobal.gv_rs.rdoColumns["LookupID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FieldOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FieldOperator = modGlobal.gv_rs.rdoColumns["FieldOperator"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DateUnit"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DateUnit = modGlobal.gv_rs.rdoColumns["DateUnit"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["onlyproceedwithrelatedfieldgroup"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object onlyproceedwithrelatedfieldgroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					onlyproceedwithrelatedfieldgroup = modGlobal.gv_rs.rdoColumns["onlyproceedwithrelatedfieldgroup"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["fieldvaluemax"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object fieldvaluemax. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					fieldvaluemax = modGlobal.gv_rs.rdoColumns["fieldvaluemax"].Value;
				}


				//UPGRADE_WARNING: Couldn't resolve default property of object fieldvaluemax. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object onlyproceedwithrelatedfieldgroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DateUnit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object destddidisgroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DestDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FIELDVALUE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ValueOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid2isgroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid1isgroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldid1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object CriteriaTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object measurefieldgrouplogicid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + measurefieldgrouplogicid + "\"" + "," + "\"" + CriteriaTitle + "\"" + "," + "\"" + fieldid1 + "\"" + "," + "\"" + fieldid1isgroup + "\"" + "," + "\"" + fieldid2 + "\"" + "," + "\"" + fieldid2isgroup + "\"" + "," + "\"" + ValueOperator + "\"" + "," + "\"" + FIELDVALUE + "\"" + "," + "\"" + DestDDID + "\"" + "," + "\"" + destddidisgroup + "\"" + "," + "\"" + LookupID + "\"" + "," + "\"" + FieldOperator + "\"" + "," + "\"" + DateUnit + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + onlyproceedwithrelatedfieldgroup + "\"" + "," + "\"" + fieldvaluemax + "\"");

				modGlobal.gv_rs.MoveNext();
			}
		}
	}
}
