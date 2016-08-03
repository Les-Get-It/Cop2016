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
namespace COP2001
{
    internal partial class OldfrmRiskAdjustment : Form
    {
        private bool bPopulating1;
        private bool bPopulating2;
        private bool bPopulating3;

        private void refreshPatRecSelections()
        {
            var i = 0;

            bPopulating1 = true;

            if (cmbFactor.SelectedIndex >= 0)
            {
                modGlobal.gv_sql = "select ddid from tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks where tab = 1 and coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                while (!modGlobal.gv_rs.EOF)
                {
                    for (i = 0; i <= lstPatRecFields.Items.Count - 1; i++)
                    {
                        if (modGlobal.gv_rs.rdoColumns["DDID"].Value == Support.GetItemData(lstPatRecFields, i))
                        {
                            lstPatRecFields.SetItemChecked(i, true);
                        }
                    }
                    //LDW modGlobal.gv_rs.MoveNext();
                }
            }
            else
            {
                for (i = 0; i <= lstPatRecFields.Items.Count - 1; i++)
                {
                    lstPatRecFields.SetItemChecked(i, false);
                }
            }

            bPopulating1 = false;

        }

        private void refreshPatRecSelections2()
        {
            var i = 0;

            bPopulating2 = true;

            if (cmbFactor.SelectedIndex >= 0)
            {
                modGlobal.gv_sql = "select ddid from tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks where tab = 2 and coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                while (!modGlobal.gv_rs.EOF)
                {
                    for (i = 0; i <= lstPatRecFields2.Items.Count - 1; i++)
                    {
                        if (modGlobal.gv_rs.rdoColumns["DDID"].Value == Support.GetItemData(lstPatRecFields2, i))
                        {
                            lstPatRecFields2.SetItemChecked(i, true);
                        }
                    }
                    //LDW modGlobal.gv_rs.MoveNext();
                }
            }
            else
            {
                for (i = 0; i <= lstPatRecFields2.Items.Count - 1; i++)
                {
                    lstPatRecFields2.SetItemChecked(i, false);
                }
            }

            bPopulating2 = false;

        }

        private void refreshPatRecSelections3()
        {
            var i = 0;

            bPopulating3 = true;

            if (cmbFactor.SelectedIndex >= 0)
            {
                modGlobal.gv_sql = "select factorid from tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks where coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                while (!modGlobal.gv_rs.EOF)
                {
                    for (i = 0; i <= lstPatRecFields3.Items.Count - 1; i++)
                    {
                        if (modGlobal.gv_rs.rdoColumns["FactorID"].Value == Support.GetItemData(lstPatRecFields3, i))
                        {
                            lstPatRecFields3.SetItemChecked(i, true);
                        }
                    }
                    //LDW modGlobal.gv_rs.MoveNext();
                }
            }
            else
            {
                for (i = 0; i <= lstPatRecFields3.Items.Count - 1; i++)
                {
                    lstPatRecFields3.SetItemChecked(i, false);
                }
            }

            bPopulating3 = false;

        }

        private void refreshAllTriggerFields()
        {

            refreshTriggerFields();
            refreshTriggerFields2();
            refreshTriggerFields3();
        }


        private void refreshTriggerFields()
        {
            //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            Cursor.Current = Cursors.WaitCursor;
            if (cmbFactor.SelectedIndex > -1)
            {
                modGlobal.gv_sql = "select triggerBy from tbl_Setup_IndicatorRiskAdjustmentCoefficients where coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
            }
            else
            {
                modGlobal.gv_sql = "select triggerBy from tbl_Setup_IndicatorRiskAdjustmentCoefficients where coefID = " + -1;
            }
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            if (modGlobal.gv_rs.RowCount > 0)
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                cmbTrigger.Text = (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["TriggerBy"].Value) ? " " : modGlobal.gv_rs.rdoColumns["TriggerBy"].Value);
            }
            else
            {
                cmbTrigger.Text = " ";
            }
            //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            Cursor.Current = Cursors.Arrow;

        }
        private void refreshTriggerFields2()
        {

            //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            Cursor.Current = Cursors.WaitCursor;
            if (cmbFactor.SelectedIndex > -1)
            {
                modGlobal.gv_sql = "select triggerBy2 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
            }
            else
            {
                modGlobal.gv_sql = "select triggerBy2 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where coefID = " + -1;
            }
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            if (modGlobal.gv_rs.RowCount > 0)
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                cmbTrigger2.Text = (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["TriggerBy2"].Value) ? " " : modGlobal.gv_rs.rdoColumns["TriggerBy2"].Value);
            }
            else
            {
                cmbTrigger2.Text = " ";
            }
            //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            Cursor.Current = Cursors.Arrow;

        }
        private void refreshTriggerFields3()
        {

            //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            Cursor.Current = Cursors.WaitCursor;
            if (cmbFactor.SelectedIndex > -1)
            {
                modGlobal.gv_sql = "select factorOperator from tbl_Setup_IndicatorRiskAdjustmentCoefficients where coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
            }
            else
            {
                modGlobal.gv_sql = "select factorOperator from tbl_Setup_IndicatorRiskAdjustmentCoefficients where coefID = " + -1;
            }
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            if (modGlobal.gv_rs.RowCount > 0)
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                cmbTrigger3.Text = (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["factorOperator"].Value) ? " " : modGlobal.gv_rs.rdoColumns["factorOperator"].Value);
            }
            else
            {
                cmbTrigger3.Text = " ";
            }
            //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            Cursor.Current = Cursors.Arrow;

        }

        private void refreshAllPatRecFields()
        {

            refreshPatRecFields();
            refreshPatRecFields2();
            refreshPatRecFields3();
        }

        private void refreshPatRecFields()
        {

            //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            Cursor.Current = Cursors.WaitCursor;
            if (cmbFactor.SelectedIndex >= 0)
            {
                if (optFields0.IsChecked == true)
                {
                    modGlobal.gv_sql = "select ddid, fieldName from tbl_setup_datadef where baseTableID = 1 and ddid in (select ddid from tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks where tab = 1 and coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex) + ") order by fieldName";
                }
                else
                {
                    modGlobal.gv_sql = "select ddid, fieldName from tbl_setup_datadef where baseTableID = 1 order by fieldName";
                }

                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                lstPatRecFields.Items.Clear();
                while (!modGlobal.gv_rs.EOF)
                {
                    lstPatRecFields.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                    //LDW modGlobal.gv_rs.MoveNext();
                }
            }

            refreshPatRecSelections();

            //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            Cursor.Current = Cursors.Arrow;

        }

        private void refreshPatRecFields2()
        {

            //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            Cursor.Current = Cursors.WaitCursor;
            if (cmbFactor.SelectedIndex >= 0)
            {
                if (optFieldsTwo0.IsChecked == true)
                {
                    modGlobal.gv_sql = "select ddid, fieldName from tbl_setup_datadef where baseTableID = 1 and ddid in (select ddid from tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks where tab = 2 and coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex) + ") order by fieldName";
                }
                else
                {
                    modGlobal.gv_sql = "select ddid, fieldName from tbl_setup_datadef where baseTableID = 1 order by fieldName";
                }

                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                lstPatRecFields2.Items.Clear();
                while (!modGlobal.gv_rs.EOF)
                {
                    lstPatRecFields2.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                    //LDW modGlobal.gv_rs.MoveNext();
                }
            }

            refreshPatRecSelections2();

            //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            Cursor.Current = Cursors.Arrow;

        }
        private void refreshPatRecFields3()
        {

            //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            Cursor.Current = Cursors.WaitCursor;
            if (cmbFactor.SelectedIndex >= 0)
            {
                if (optFieldsThree0.IsChecked == true)
                {
                    modGlobal.gv_sql = "select * from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where measureID = (select jcahoID from tbl_Setup_Indicator ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "             where indicatorID = " + Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex) + ")";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and Quarter = '" + Support.GetItemData(lstPeriods, lstPeriods.SelectedIndex) + "'";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and coefID in (select factorid from tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks where coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex) + ")";
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by Description, FactorID";
                }
                else
                {
                    modGlobal.gv_sql = "select * from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where measureID = (select jcahoID from tbl_Setup_Indicator ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "             where indicatorID = " + Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex) + ")";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and Quarter = '" + Support.GetItemData(lstPeriods, lstPeriods.SelectedIndex) + "'";
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by Description, FactorID";
                }

                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                lstPatRecFields3.Items.Clear();
                while (!modGlobal.gv_rs.EOF)
                {
                    lstPatRecFields3.Items.Add(new ListBoxItem("(" + modGlobal.gv_rs.rdoColumns["Description"].Value + ") / " + modGlobal.gv_rs.rdoColumns["FactorID"].Value + ": " + modGlobal.gv_rs.rdoColumns["coefficient"].Value, modGlobal.gv_rs.rdoColumns["coefID"].Value));
                    //LDW modGlobal.gv_rs.MoveNext();
                }
            }

            refreshPatRecSelections3();

            //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            Cursor.Current = Cursors.Arrow;

        }

        private void refreshIndicators()
        {
            //
            //retrieve the list of Indicators
            //
            modGlobal.gv_sql = "select * from tbl_setup_indicator Where RiskAdjusted > 0 order by Description ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            cmbIndicators.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                cmbIndicators.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["Description"].Value, modGlobal.gv_rs.rdoColumns["IndicatorID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }

        }

        //UPGRADE_WARNING: Event cmbFactor.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cmbFactor_SelectedIndexChanged(System.Object sender, System.EventArgs eventArgs)
        {
            //
            //
            //
            refreshAllPatRecFields();
            //
            //
            //
            refreshAllTriggerFields();
            //
            //
            //
            refreshAllTriggerList();


        }

        //UPGRADE_WARNING: Event cmbIndicators.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cmbIndicators_SelectedIndexChanged(System.Object sender, System.EventArgs eventArgs)
        {

            if (fraFactors.Enabled == true & lstPeriods.SelectedIndex > -1)
            {
                RefreshRADetails();
            }

        }

        //UPGRADE_WARNING: Event cmbTrigger.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cmbTrigger_SelectedIndexChanged(System.Object sender, System.EventArgs eventArgs)
        {
            SqlCommand ps = null;
            string SQL = null;
            //
            //
            //
            if (cmbFactor.SelectedIndex >= 0)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SQL = "update tbl_Setup_IndicatorRiskAdjustmentCoefficients set triggerBy = '" + cmbTrigger.Text + "' where coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
                ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                //UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ps.Execute();
                //UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ps.Close();
            }

        }
        //UPGRADE_WARNING: Event cmbTrigger2.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cmbTrigger2_SelectedIndexChanged(System.Object sender, System.EventArgs eventArgs)
        {
            SqlCommand ps = null;
            string SQL = null;
            //
            //
            //
            if (cmbFactor.SelectedIndex >= 0)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SQL = "update tbl_Setup_IndicatorRiskAdjustmentCoefficients set triggerBy2 = '" + cmbTrigger2.Text + "' where coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
                ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                //UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ps.Execute();
                //UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ps.Close();
            }

        }
        //UPGRADE_WARNING: Event cmbTrigger3.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cmbTrigger3_SelectedIndexChanged(System.Object sender, System.EventArgs eventArgs)
        {
            SqlCommand ps = null;
            string SQL = null;
            //
            //
            //
            if (cmbFactor.SelectedIndex >= 0)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SQL = "update tbl_Setup_IndicatorRiskAdjustmentCoefficients set factorOperator = '" + cmbTrigger3.Text + "' where coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
                ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                //UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ps.Execute();
                //UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ps.Close();
            }

        }

        private void refreshAllTriggerList()
        {

            refreshTriggerList();
            refreshTriggerList2();
        }
        private void refreshTriggerList()
        {
            //
            //
            //sh changed order by trigger id for in between group logic
            if (cmbFactor.SelectedIndex >= 0)
            {
                //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                Cursor.Current = Cursors.WaitCursor;
                modGlobal.gv_sql = "select * from tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers Where tab = 1 and coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex) + " order by triggerID";
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //
                //
                //
                lstTriggers.Items.Clear();
                if (modGlobal.gv_rs.RowCount > 0)
                {
                    modGlobal.gv_rs.MoveFirst();
                    while (!modGlobal.gv_rs.EOF)
                    {
                        lstTriggers.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["TriggerValue"].Value, modGlobal.gv_rs.rdoColumns["triggerID"].Value));
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                }
                //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                Cursor.Current = Cursors.Arrow;
            }

        }
        private void refreshTriggerList2()
        {
            //
            //
            //sh changed order by trigger id for in between group logic
            if (cmbFactor.SelectedIndex >= 0)
            {
                //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                Cursor.Current = Cursors.WaitCursor;
                modGlobal.gv_sql = "select * from tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers Where tab = 2 and coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex) + " order by triggerID";
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //
                //
                //
                lstTriggers2.Items.Clear();
                if (modGlobal.gv_rs.RowCount > 0)
                {
                    modGlobal.gv_rs.MoveFirst();
                    while (!modGlobal.gv_rs.EOF)
                    {
                        lstTriggers2.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["TriggerValue"].Value, modGlobal.gv_rs.rdoColumns["triggerID"].Value));
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                }
                //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                Cursor.Current = Cursors.Arrow;
            }

        }

        private void cmdAdd_Click(System.Object sender, System.EventArgs eventArgs)
        {
            SqlCommand ps = null;
            string SQL = null;
            string resp = null;
            //
            //
            //
            if (cmbFactor.SelectedIndex >= 0)
            {
                resp = RadInputBox.Show("Enter The New Trigger Value", "Pat Rec Value For Risk Adjustment");
                if (!string.IsNullOrEmpty(resp))
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID,triggerValue,tab) values (" + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex) + ", '" + resp + "',1)";
                    ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                    //UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ps.Execute();
                    //UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ps.Close();
                    refreshTriggerList();
                }
            }

        }
        private void cmdAdd2_Click(System.Object sender, System.EventArgs eventArgs)
        {
            SqlCommand ps = null;
            string SQL = null;
            string resp = null;
            //
            //
            //
            if (cmbFactor.SelectedIndex >= 0)
            {
                resp = RadInputBox.Show("Enter The New Trigger Value", "Pat Rec Value For Risk Adjustment");
                if (!string.IsNullOrEmpty(resp))
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID,triggerValue,tab) values (" + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex) + ", '" + resp + "',2)";
                    ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                    //UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ps.Execute();
                    //UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ps.Close();
                    refreshTriggerList2();
                }
            }

        }

        private void cmdDelete_Click(System.Object sender, System.EventArgs eventArgs)
        {
            if (RadMessageBox.Show("Are you sure you want to delete this factor?", MessageBoxButtons.YesNo, "Delete?") == DialogResult.Yes)
            {
                DeleteFactor( Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex));

                RefreshRADetails();
            }
        }

        private void DeleteFactor( int coefID)
        {
            modGlobal.gv_sql = "DELETE from tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where coefID = " + coefID;
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
            

            modGlobal.gv_sql = "DELETE from tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where coefID = " + coefID;
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            modGlobal.gv_sql = "DELETE from tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where coefID = " + coefID;
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            modGlobal.gv_sql = "delete from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where coefid = " + coefID;
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
        }

        private void cmdDeletePeriod_Click(System.Object sender, System.EventArgs eventArgs)
        {
            DataSet rs_Temp = null;

            if (RadMessageBox.Show("Are you sure you want to delete data for the entire period?", MessageBoxButtons.YesNo, "Delete Period?") == DialogResult.Yes)
            {
                //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                Cursor.Current = Cursors.WaitCursor;

                modGlobal.gv_sql = "Select coefID from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Quarter = '" + Support.GetItemData(lstPeriods, lstPeriods.SelectedIndex) + "'";

                rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                while (!rs_Temp.EOF)
                {
                    DeleteFactor((rs_Temp.rdoColumns["coefID"].Value));
                   //LDW  rs_Temp.MoveNext();
                }

                rs_Temp.Close();
                //UPGRADE_NOTE: Object rs_Temp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                rs_Temp = null;

                refreshIndicators();
                RefreshPeriods();
                //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                Cursor.Current = Cursors.Default;
            }
        }

        private void cmdEdit_Click(System.Object sender, System.EventArgs eventArgs)
        {
            SqlCommand ps = null;
            string SQL = null;
            DialogResult resp;
            //
            //
            //
            if (lstTriggers.SelectedIndex > -1)
            {
                modGlobal.gv_sql = "Select triggerValue from tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tab = 1 and coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and triggerID = " + Support.GetItemData(lstTriggers, lstTriggers.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                if (!modGlobal.gv_rs.EOF)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    resp = RadInputBox.Show("Edit The Trigger Value", "Pat Rec Value For Risk Adjustment", modGlobal.gv_rs.rdoColumns["TriggerValue"].Value);
                    //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (!string.IsNullOrEmpty(resp))
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        SQL = "update tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers set triggerValue = " + resp + " where coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex) + " and tab = 1 and triggerID = " + Support.GetItemData(lstTriggers, lstTriggers.SelectedIndex);
                        ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                        //UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ps.Execute();
                        //UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ps.Close();
                        refreshTriggerList();
                    }
                }
            }
            else
            {
                RadMessageBox.Show("Please choose a trigger to edit", RadMessageIcon.Info);
            }
        }

        private void cmdEdit2_Click(System.Object sender, System.EventArgs eventArgs)
        {
            SqlCommand ps = null;
            string SQL = null;
            DialogResult resp;
            //
            //
            //
            if (lstTriggers2.SelectedIndex > -1)
            {
                modGlobal.gv_sql = "Select triggerValue from tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tab = 2 and coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and triggerID = " + Support.GetItemData(lstTriggers2, lstTriggers2.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                if (!modGlobal.gv_rs.EOF)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    resp = RadInputBox.Show("Edit The Trigger Value", "Pat Rec Value For Risk Adjustment", modGlobal.gv_rs.rdoColumns["TriggerValue"].Value);
                    //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (!string.IsNullOrEmpty(resp))
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        SQL = "update tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers set triggerValue = " + resp + " where coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex) + " and tab = 2 and triggerID = " + Support.GetItemData(lstTriggers2, lstTriggers2.SelectedIndex);
                        ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                        //UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ps.Execute();
                        //UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ps.Close();
                        refreshTriggerList2();
                    }
                }
            }
            else
            {
                RadMessageBox.Show("Please choose a trigger to edit", RadMessageIcon.Info);
            }
        }

        private void cmdRemove_Click(System.Object sender, System.EventArgs eventArgs)
        {
            SqlCommand ps = null;
            string SQL = null;
            //
            //
            //
            if (lstTriggers.SelectedIndex > -1)
            {
                if (RadMessageBox.Show("Delete " + lstTriggers.Text + " from trigger list?", MessageBoxButtons.YesNo, "Confirm Trigger Removal") == DialogResult.Yes)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    SQL = "delete tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers where tab = 1 and triggerID = " + Support.GetItemData(lstTriggers, lstTriggers.SelectedIndex);
                    ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                    //UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ps.Execute();
                    //UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ps.Close();
                    //
                    //
                    //
                    refreshTriggerList();
                }
            }
            else
            {
                RadMessageBox.Show("Please choose a trigger to delete", RadMessageIcon.Info);
            }
        }
        private void cmdRemove2_Click(System.Object sender, System.EventArgs eventArgs)
        {
            SqlCommand ps = null;
            string SQL = null;
            //
            //
            //
            if (lstTriggers2.SelectedIndex > -1)
            {
                if (RadMessageBox.Show("Delete " + lstTriggers2.Text + " from trigger list?", MessageBoxButtons.YesNo, "Confirm Trigger Removal") == DialogResult.Yes)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    SQL = "delete tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers where tab = 2 and triggerID = " + Support.GetItemData(lstTriggers2, lstTriggers2.SelectedIndex);
                    ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                    //UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ps.Execute();
                    //UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ps.Close();
                    //
                    //
                    //
                    refreshTriggerList2();
                }
            }
            else
            {
                RadMessageBox.Show("Please choose a trigger to delete", RadMessageIcon.Info);
            }
        }

        private void frmRiskAdjustment_Load(System.Object sender, System.EventArgs eventArgs)
        {

            this.Left = Support.TwipsToPixelsX((Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Support.TwipsToPixelsY((Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Support.PixelsToTwipsY(this.Height) / 2));

            //
            //
            //
            refreshIndicators();
            //
            RefreshPeriods();
            //
            //
            //
            refreshAllPatRecFields();



        }


        //UPGRADE_WARNING: ListBox event lstPatRecFields.ItemCheck has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        private void lstPatRecFields_ItemCheck(System.Object sender, ItemCheckEventArgs eventArgs)
        {
            SqlCommand ps = null;
            string SQL = null;
            // ERROR: Not supported in C#: OnErrorStatement


            if (!bPopulating1)
            {
                if (cmbFactor.SelectedIndex >= 0)
                {
                    if (lstPatRecFields.SelectedIndex == -1)
                    {
                        //
                        // just skip it
                        //
                    }
                    else if (lstPatRecFields.GetItemChecked(lstPatRecFields.SelectedIndex) == true)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID,DDID,tab) values (" + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex) + ", " + Support.GetItemData(lstPatRecFields, lstPatRecFields.SelectedIndex) + ",1)";
                        ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                        //UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ps.Execute();
                        //UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ps.Close();
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        SQL = "delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks where tab = 1 and coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex) + " and DDID = " + Support.GetItemData(lstPatRecFields, lstPatRecFields.SelectedIndex);
                        ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                        //UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ps.Execute();
                        //UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ps.Close();
                    }
                }
            }

            return;
            ErrHandler:

            modGlobal.CheckForErrors();
        }

        //UPGRADE_WARNING: ListBox event lstPatRecFields2.ItemCheck has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        private void lstPatRecFields2_ItemCheck(System.Object sender, ItemCheckEventArgs eventArgs)
        {
            SqlCommand ps = null;
            string SQL = null;
            // ERROR: Not supported in C#: OnErrorStatement

            //
            //
            //
            if (!bPopulating2)
            {
                if (cmbFactor.SelectedIndex >= 0)
                {
                    if (lstPatRecFields2.SelectedIndex == -1)
                    {
                        //
                        // just skip it
                        //
                    }
                    else if (lstPatRecFields2.GetItemChecked(lstPatRecFields2.SelectedIndex) == true)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID,DDID,tab) values (" + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex) + ", " + Support.GetItemData(lstPatRecFields2, lstPatRecFields2.SelectedIndex) + ",2)";
                        ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                        //UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ps.Execute();
                        //UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ps.Close();
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        SQL = "delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks where tab = 2 and coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex) + " and DDID = " + Support.GetItemData(lstPatRecFields2, lstPatRecFields2.SelectedIndex);
                        ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                        //UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ps.Execute();
                        //UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ps.Close();
                    }
                }
            }

            return;
            ErrHandler:

            modGlobal.CheckForErrors();

        }

        //UPGRADE_WARNING: ListBox event lstPatRecFields3.ItemCheck has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        private void lstPatRecFields3_ItemCheck(System.Object sender, ItemCheckEventArgs eventArgs)
        {
            SqlCommand ps = null;
            string SQL = null;
            // ERROR: Not supported in C#: OnErrorStatement

            //
            //
            //
            if (!bPopulating3)
            {
                if (cmbFactor.SelectedIndex >= 0)
                {
                    if (lstPatRecFields3.SelectedIndex == -1)
                    {
                        //
                        // just skip it
                        //
                    }
                    else if (lstPatRecFields3.GetItemChecked(lstPatRecFields3.SelectedIndex) == true)
                    {
                        //   get the factor text description
                        modGlobal.gv_sql = "Select factorid from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where coefid = " + Support.GetItemData(lstPatRecFields3, lstPatRecFields3.SelectedIndex);
                        modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        if (!modGlobal.gv_rs.EOF)
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks (coefID,factorTxt,factorID) values (" + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex) + ", '" + modGlobal.gv_rs.rdoColumns["FactorID"].Value + "', " + Support.GetItemData(lstPatRecFields3, lstPatRecFields3.SelectedIndex) + ")";
                            ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                            //UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            ps.Execute();
                            //UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            ps.Close();
                        }
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        SQL = "delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks where coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex) + " and factorid = " + Support.GetItemData(lstPatRecFields3, lstPatRecFields3.SelectedIndex);
                        ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                        //UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ps.Execute();
                        //UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ps.Close();
                    }
                }
            }

            return;
            ErrHandler:

            modGlobal.CheckForErrors();

        }

        //UPGRADE_WARNING: Event lstPeriods.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void lstPeriods_SelectedIndexChanged(System.Object sender, System.EventArgs eventArgs)
        {
            if (cmbIndicators.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select an indicator");
                return;
            }

            RefreshRADetails();

        }

        //UPGRADE_WARNING: Event optFields.IsCheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void optFields_CheckedChanged(System.Object sender, System.EventArgs eventArgs)
        {
            if (sender.IsChecked)
            {
                int Index = optFields.GetIndex(sender);
                //
                //
                //
                refreshPatRecFields();

            }
        }

        //UPGRADE_WARNING: Event optFieldsTwo.IsCheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void optFieldsTwo_CheckedChanged(System.Object sender, System.EventArgs eventArgs)
        {
            if (sender.IsChecked)
            {
                int Index = optFieldsTwo.GetIndex(sender);

                refreshPatRecFields2();

            }
        }

        //UPGRADE_WARNING: Event optFieldsThree.IsCheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void optFieldsThree_CheckedChanged(System.Object sender, System.EventArgs eventArgs)
        {
            if (sender.IsChecked)
            {
                int Index = optFieldsThree.GetIndex(sender);

                refreshPatRecFields3();

            }
        }

        public void RefreshPeriods()
        {
            //retrieve the list of periods
            modGlobal.gv_sql = "Select Quarter from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
            modGlobal.gv_sql = modGlobal.gv_sql + " group by quarter";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by quarter ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            lstPeriods.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                lstPeriods.Items.Add(new ListBoxItem(Strings.Mid(modGlobal.gv_rs.rdoColumns["Quarter"].Value, 5, 2) + " - " + Strings.Mid(modGlobal.gv_rs.rdoColumns["Quarter"].Value, 1, 4), modGlobal.gv_rs.rdoColumns["Quarter"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }

        }

        public void RefreshRADetails()
        {
            //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            Cursor.Current = Cursors.WaitCursor;
            modGlobal.gv_sql = "select * from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where measureID = (select jcahoID from tbl_Setup_Indicator ";
            modGlobal.gv_sql = modGlobal.gv_sql + "             where indicatorID = " + Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex) + ")";
            modGlobal.gv_sql = modGlobal.gv_sql + " and Quarter = '" + Support.GetItemData(lstPeriods, lstPeriods.SelectedIndex) + "'";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by Description, FactorID";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            cmbFactor.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                cmbFactor.Items.Add(new ListBoxItem("(" + modGlobal.gv_rs.rdoColumns["Description"].Value + ") / " + modGlobal.gv_rs.rdoColumns["FactorID"].Value + ": " + modGlobal.gv_rs.rdoColumns["coefficient"].Value, modGlobal.gv_rs.rdoColumns["coefID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
            //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            Cursor.Current = Cursors.Arrow;

            refreshAllTriggerFields();
            lstTriggers.Items.Clear();
            lstTriggers2.Items.Clear();
            lstPatRecFields.Items.Clear();
            lstPatRecFields2.Items.Clear();
            lstPatRecFields3.Items.Clear();
            refreshPatRecSelections();
            refreshPatRecSelections2();
            refreshPatRecSelections3();
            refreshAllPatRecFields();

            fraFactors.Enabled = true;

        }
    }
}
