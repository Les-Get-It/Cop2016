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
	internal partial class OldfrmImportCopyValidation : System.Windows.Forms.Form
	{
		private void cmdCopy_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object ps = null;
			System.Data.DataSet  thisim = null;
			System.Data.DataSet  thisimv = null;
			if (lstImportLayout.SelectedIndex < 0) {
				return;
			}

			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			//    gv_sql = " select ifd.importfieldid as destimportfieldid, ivm.* "
			//    gv_sql = gv_sql & " from "
			//    gv_sql = gv_sql & " (tbl_setup_Importfields as ifs "
			//    gv_sql = gv_sql & " inner join tbl_Setup_importvalidationmessage as ivm "
			//    gv_sql = gv_sql & " on ifs.importfieldid = ivm.importfieldid) "
			//    gv_sql = gv_sql & " inner join tbl_setup_Importfields as ifd "
			//    gv_sql = gv_sql & " on ifs.ddid = ifd.ddid "
			//    gv_sql = gv_sql & " where ifd.importsetupid = " & gv_importsetupid
			//    gv_sql = gv_sql & " and ifs.importsetupid = " & lstImportLayout.ItemData(lstImportLayout.ListIndex)
			//
			//    Set thisim = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
			//
			//    While Not thisim.EOF
			//        msgid = FindMaxRecID("tbl_Setup_importvalidationmessage", "msgid")
			//
			//        gv_sql = "insert into tbl_setup_ImportvalidationMessage "
			//        gv_sql = gv_sql & " (MSGID, "
			//        gv_sql = gv_sql & " Message, "
			//        gv_sql = gv_sql & " DDID, "
			//        gv_sql = gv_sql & " ImportFieldid, "
			//        gv_sql = gv_sql & " ValidationCount, "
			//        gv_sql = gv_sql & " ValidationType, "
			//        gv_sql = gv_sql & " Joinoperator) "
			//        gv_sql = gv_sql & " values( "
			//        gv_sql = gv_sql & " " & msgid & ", "
			//        gv_sql = gv_sql & " '" & thisim!Message & "', "
			//        gv_sql = gv_sql & " " & thisim!DDID & ", "
			//        gv_sql = gv_sql & " " & thisim!destimportfieldid & ", "
			//        If IsNull(thisim!ValidationCount) Then
			//            gv_sql = gv_sql & " Null, "
			//        Else
			//            gv_sql = gv_sql & " " & thisim!ValidationCount & ", "
			//        End If
			//        gv_sql = gv_sql & " '" & thisim!ValidationType & "', "
			//        If IsNull(thisim!JoinOperator) Then
			//            gv_sql = gv_sql & " Null "
			//        Else
			//            gv_sql = gv_sql & " '" & thisim!JoinOperator & "' "
			//        End If
			//        gv_sql = gv_sql & ") "
			//        gv_cn.Execute gv_sql
			//
			//        gv_sql = " select iv.* "
			//        gv_sql = gv_sql & " from "
			//        gv_sql = gv_sql & " (tbl_setup_Importfields as ifs "
			//        gv_sql = gv_sql & " inner join tbl_setup_importvalidationmessage as ivm "
			//        gv_sql = gv_sql & " on ifs.importfieldid = ivm.importfieldid) "
			//        gv_sql = gv_sql & " inner join tbl_setup_Importvalidation as iv "
			//        gv_sql = gv_sql & " on iv.msgid = ivm.msgid "
			//        gv_sql = gv_sql & " where "
			//        gv_sql = gv_sql & " iv.msgid = " & thisim!msgid
			//
			//        Set thisimv = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
			//
			//
			//        While Not thisimv.EOF
			//            newid = FindMaxRecID("tbl_Setup_importvalidation", "validid")
			//
			//            gv_sql = "insert into tbl_setup_Importvalidation "
			//            gv_sql = gv_sql & " (Validid, "
			//            gv_sql = gv_sql & " Msgid,"
			//            gv_sql = gv_sql & " ddid,"
			//            gv_sql = gv_sql & " validationtitle,"
			//            gv_sql = gv_sql & " lookuptableid,"
			//            gv_sql = gv_sql & " fieldtypeval,"
			//            gv_sql = gv_sql & " operator,"
			//            gv_sql = gv_sql & " fieldvalue,"
			//            gv_sql = gv_sql & " fieldtype)"
			//            gv_sql = gv_sql & " values ("
			//            gv_sql = gv_sql & " " & newid & ", "
			//            gv_sql = gv_sql & " " & msgid & ","
			//            gv_sql = gv_sql & " " & thisimv!DDID & ","
			//            gv_sql = gv_sql & " '" & thisimv!ValidationTitle & "',"
			//            If IsNull(thisimv!LookupTableID) Then
			//                gv_sql = gv_sql & " Null, "
			//            Else
			//                gv_sql = gv_sql & " " & thisimv!LookupTableID & ","
			//            End If
			//            If IsNull(thisimv!FieldTypeVal) Then
			//                gv_sql = gv_sql & " Null, "
			//            Else
			//                gv_sql = gv_sql & " '" & thisimv!FieldTypeVal & "',"
			//            End If
			//            If IsNull(thisimv!Operator) Then
			//                gv_sql = gv_sql & " Null, "
			//            Else
			//                gv_sql = gv_sql & " '" & thisimv!Operator & "',"
			//            End If
			//            If IsNull(thisimv!FIELDVALUE) Then
			//                gv_sql = gv_sql & " Null, "
			//            Else
			//                gv_sql = gv_sql & " '" & thisimv!FIELDVALUE & "',"
			//            End If
			//            If IsNull(thisimv!FieldType) Then
			//                gv_sql = gv_sql & " Null "
			//            Else
			//                gv_sql = gv_sql & " '" & thisimv!FieldType & "'"
			//            End If
			//            gv_sql = gv_sql & " )"
			//
			//            gv_cn.Execute gv_sql
			//            thisimv.MoveNext
			//        Wend
			//        thisimv.Close
			//
			//        thisim.MoveNext
			//    Wend
			//    thisim.Close

			modGlobal.gv_sql = "{ ? = call CopyImportValidation(?,?) }";
			ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
			//UPGRADE_WARNING: Couldn't resolve default property of object ps().Direction. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps(0).Direction = RDO.DirectionConstants.rdParamReturnValue;
			//UPGRADE_WARNING: Couldn't resolve default property of object ps().Direction. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps(1).Direction = RDO.DirectionConstants.rdParamInput;
			//UPGRADE_WARNING: Couldn't resolve default property of object ps().Direction. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps(2).Direction = RDO.DirectionConstants.rdParamInput;
			//UPGRADE_WARNING: Couldn't resolve default property of object ps.rdoParameters. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps.rdoParameters(1) = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstImportLayout, lstImportLayout.SelectedIndex);
			// to
			//UPGRADE_WARNING: Couldn't resolve default property of object ps.rdoParameters. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps.rdoParameters(2) = modGlobal.gv_importsetupid;
			//from
			//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps.Execute();
			//UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps.Close();


			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

			this.Close();

		}

		private void frmImportCopyValidation_Load(System.Object eventSender, System.EventArgs eventArgs)
		{

			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			RefreshImportLayouts();
		}

		public void RefreshImportLayouts()
		{
			modGlobal.gv_sql = "select * from tbl_setup_ImportSetup ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where importsetupid <> " + modGlobal.gv_importsetupid;
			modGlobal.gv_sql = modGlobal.gv_sql + " order by methodnumber ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			lstImportLayout.Items.Clear();
			while (!modGlobal.gv_rs.EOF) {
				lstImportLayout.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["Description"].Value, modGlobal.gv_rs.rdoColumns["ImportSetupID"].Value));
				modGlobal.gv_rs.MoveNext();
			}


		}
	}
}
