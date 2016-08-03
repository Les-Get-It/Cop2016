using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using static COP2001.RadDropBinder;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmExportCoef : Telerik.WinControls.UI.RadForm
    {
        int JCVersion;
        int FileNum;
        public frmExportCoef()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            string msg = null;
            string UpdateFile = null;
            //first line of each table will be tablename in [], followed by the records in the table
            try
            {

                //LDW FileFind.Text = "Specify the destination directory for RiskModel.txt";
                //LDW FileFind.ShowDialog();
                if (!string.IsNullOrEmpty(modGlobal.gv_SelectedDirectory))
                {
                    UpdateFile = modGlobal.gv_SelectedDirectory + (Strings.Mid(modGlobal.gv_SelectedDirectory,
                        Strings.Len(modGlobal.gv_SelectedDirectory), 1) == "\\" ? "RiskModel.txt" : "\\RiskModel.txt");
                }
                else
                {
                    return;
                }
                // ERROR: Not supported in C#: OnErrorStatement


                FileSystem.Kill(UpdateFile);
                // ERROR: Not supported in C#: OnErrorStatement


                this.Refresh();
                FileNum = FileSystem.FreeFile();
                FileSystem.FileOpen(FileNum, UpdateFile, OpenMode.Output);

                Cursor.Current = Cursors.WaitCursor;
                int li_cnt = 0;
                string ls_quarters = null;

                FileSystem.PrintLine(FileNum, "[PERIODS]");
                var _with1 = lstPeriods;

                for (li_cnt = 0; li_cnt <= _with1.Items.Count - 1; li_cnt++)
                {
                    //LDW if (_with1.GetSelected(li_cnt))
                    if (_with1.SelectedIndex == li_cnt)
                    {
                        FileSystem.PrintLine(FileNum, Strings.Trim(Convert.ToString(Support.GetItemData(lstPeriods, li_cnt))));
                        ls_quarters = string.Format("{0}'{1}',", ls_quarters, Strings.Trim(Convert.ToString(Support.GetItemData(lstPeriods, li_cnt))));
                    }
                }

                //take off the last comma
                ls_quarters = Strings.Mid(ls_quarters, 1, Strings.Len(ls_quarters) - 1);

                //    For li_cnt = 0 To lstPeriods.ListCount - 1
                //        Print #FileNum, Trim(lstPeriods.ItemData(li_cnt))
                //    Next

                OutputIndicatorRiskCoefficientTables(ls_quarters);

                FileSystem.FileClose(FileNum);

                Cursor.Current = Cursors.Default;


                DialogResult ds1a = RadMessageBox.Show(this, "The update file '" + UpdateFile + "' was successfully created.",
                    "Update File Success", MessageBoxButtons.OK, RadMessageIcon.Error);
                this.Text = ds1a.ToString();

                return;
                UpdateErr:

                //LDW if (Err().Number == 71)
                if (Information.Err().Number == 71)
                {
                    // ERROR: Not supported in C#: OnErrorStatement

                    Cursor.Current = Cursors.Default;

                    DialogResult ds1 = RadMessageBox.Show(this, "The Destination directory does not exist. Please Check Again.", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds1.ToString();

                    return;
                }
                else
                {

                    msg = string.Format("The following error occured in the process of creating an update for Access database: {0}{1}", Strings.Chr(13), Strings.Chr(10));
                    msg = string.Format("{0}{1}: {2}", msg, Information.Err().Number, Information.Err().Description);
                    // ERROR: Not supported in C#: OnErrorStatement

                    FileSystem.FileClose(FileNum);
                    Cursor.Current = Cursors.Default;
                    RadMessageBox.Show(msg);

                    DialogResult ds1 = RadMessageBox.Show(this, msg, "Update Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds1.ToString();
                    return;
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

        private void frmExportCoef_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshPeriods();
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

        private void OutputIndicatorRiskCoefficientTables(string Quarters)
        {
            string Method = null;
            string factortxt = null;
            string TriggerValue = null;
            string triggerID = null;
            string strtab = null;
            string DDID = null;
            string factorOperator = null;
            string TriggerBy2 = null;
            string TriggerBy = null;
            string coefficient = null;
            string Description = null;
            string FactorType = null;
            string FactorStatus = null;
            string FactorID = null;
            string EqType = null;
            string MeasureID = null;
            string Quarter = null;
            string coefID = null;

            try
            {
                FileSystem.PrintLine(FileNum, "[INDICATORRISKADJUSTMENTCOEFFICIENTS]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                modGlobal.gv_sql = string.Format("{0} WHERE Quarter in ({1}) ", modGlobal.gv_sql, Quarters);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    coefID = Strings.Trim((Information.IsDBNull(myRow1.Field<string>("coefID")) ? "" : myRow1.Field<string>("coefID")));
                    Quarter = Strings.Trim((Information.IsDBNull(myRow1.Field<string>("Quarter")) ? "" : myRow1.Field<string>("Quarter")));
                    MeasureID = Strings.Trim((Information.IsDBNull(myRow1.Field<string>("MeasureID")) ? "" : myRow1.Field<string>("MeasureID")));
                    EqType = Strings.Trim((Information.IsDBNull(myRow1.Field<string>("EqType")) ? "" : myRow1.Field<string>("EqType")));
                    FactorID = Strings.Trim((Information.IsDBNull(myRow1.Field<string>("FactorID")) ? "" : myRow1.Field<string>("FactorID")));
                    FactorStatus = Strings.Trim((Information.IsDBNull(myRow1.Field<string>("FactorStatus")) ? "" : myRow1.Field<string>("FactorStatus")));
                    FactorType = Strings.Trim((Information.IsDBNull(myRow1.Field<string>("FactorType")) ? "" : myRow1.Field<string>("FactorType")));
                    Description = Strings.Trim((Information.IsDBNull(myRow1.Field<string>("Description")) ? "" : myRow1.Field<string>("Description")));
                    coefficient = Strings.Trim((Information.IsDBNull(myRow1.Field<string>("coefficient")) ? "" : myRow1.Field<string>("coefficient")));
                    if (!Information.IsDBNull(myRow1.Field<string>("TriggerBy")))
                    {
                        TriggerBy = Strings.Trim(myRow1.Field<string>("TriggerBy"));
                    }
                    else
                    {
                        TriggerBy = "";
                    }

                    if (!Information.IsDBNull(myRow1.Field<string>("TriggerBy2")))
                    {
                        TriggerBy2 = Strings.Trim(myRow1.Field<string>("TriggerBy2"));
                    }
                    else
                    {
                        TriggerBy2 = "";
                    }

                    if (!Information.IsDBNull(myRow1.Field<string>("factorOperator")))
                    {
                        factorOperator = Strings.Trim(myRow1.Field<string>("factorOperator"));
                    }
                    else
                    {
                        factorOperator = "";
                    }

                    FileSystem.PrintLine(FileNum, coefID + "," + Quarter + "," + MeasureID + "," + EqType + "," + FactorID + "," + FactorStatus + "," +
                        FactorType + "," + Description + "," + coefficient + "," + TriggerBy + "," + TriggerBy2 + "," + factorOperator);

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                modGlobal.gv_rs.Dispose();

                FileSystem.PrintLine(FileNum, "[INDICATORRISKADJUSTMENTCOEFFICIENTFIELDLINKS]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks WHERE CoefID IN " +
                    " (SELECT CoefID FROM tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                // WHERE Quarter = '" & quarter & "')"
                modGlobal.gv_sql = string.Format("{0} WHERE Quarter in ({1}) )", modGlobal.gv_sql, Quarters);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    coefID = Strings.Trim((Information.IsDBNull(myRow2.Field<string>("coefID")) ? "" : myRow2.Field<string>("coefID")));
                    DDID = Strings.Trim((Information.IsDBNull(myRow2.Field<string>("DDID")) ? "" : myRow2.Field<string>("DDID")));
                    strtab = Strings.Trim((Information.IsDBNull(myRow2.Field<string>("Tab")) ? "" : myRow2.Field<string>("Tab")));

                    FileSystem.PrintLine(FileNum, string.Format("{0},{1},{2}", coefID, DDID, strtab));

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                modGlobal.gv_rs.Dispose();

                FileSystem.PrintLine(FileNum, "[INDICATORRISKADJUSTMENTCOEFFICIENTTRIGGERS]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers WHERE COefID in " +
                    " (SELECT CoefID FROM tbl_Setup_IndicatorRiskAdjustmentCoefficients  ";
                // WHERE Quarter = '" & quarter & "')"
                modGlobal.gv_sql = string.Format("{0} WHERE Quarter in ({1})) ", modGlobal.gv_sql, Quarters);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                {
                    triggerID = Strings.Trim((Information.IsDBNull(myRow3.Field<string>("triggerID")) ? "" : myRow3.Field<string>("triggerID")));
                    coefID = Strings.Trim((Information.IsDBNull(myRow3.Field<string>("coefID")) ? "" : myRow3.Field<string>("coefID")));
                    TriggerValue = Strings.Trim((Information.IsDBNull(myRow3.Field<string>("TriggerValue")) ? "" : myRow3.Field<string>("TriggerValue")));
                    strtab = Strings.Trim((Information.IsDBNull(myRow3.Field<string>("Tab")) ? "" : myRow3.Field<string>("Tab")));

                    FileSystem.PrintLine(FileNum, string.Format("{0},{1},{2},{3}", triggerID, coefID, TriggerValue, strtab));

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                modGlobal.gv_rs.Dispose();

                FileSystem.PrintLine(FileNum, "[INDICATORRISKADJUSTMENTCOEFFICIENTFACTORLINKS]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks WHERE COefID in " +
                    " (SELECT CoefID FROM tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                // WHERE Quarter = '" & quarter & "')"
                modGlobal.gv_sql = string.Format("{0} WHERE Quarter in ({1} )) ", modGlobal.gv_sql, Quarters);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName4].Rows)
                {
                    coefID = Strings.Trim((Information.IsDBNull(myRow4.Field<string>("coefID")) ? "" : myRow4.Field<string>("coefID")));
                    FactorID = Strings.Trim((Information.IsDBNull(myRow4.Field<string>("FactorID")) ? "" : myRow4.Field<string>("FactorID")));
                    factortxt = Strings.Trim((Information.IsDBNull(myRow4.Field<string>("factortxt")) ? "" : myRow4.Field<string>("factortxt")));

                    FileSystem.PrintLine(FileNum, string.Format("{0},{1},{2}", coefID, FactorID, factortxt));

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                modGlobal.gv_rs.Dispose();


                FileSystem.PrintLine(FileNum, "[INDICATORRISKADJUSTMENTCOEFFICIENTSMISSING]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientsMissing ";
                modGlobal.gv_sql = string.Format("{0} WHERE Quarter in ({1}) ", modGlobal.gv_sql, Quarters);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName5 = "tbl_Setup_IndicatorRiskAdjustmentCoefficientsMissing";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow5 in modGlobal.gv_rs.Tables[sqlTableName5].Rows)
                {
                    FactorID = Strings.Trim((Information.IsDBNull(myRow5.Field<string>("FactorID")) ? "" : myRow5.Field<string>("FactorID")));
                    Method = Strings.Trim((Information.IsDBNull(myRow5.Field<string>("Method")) ? "" : myRow5.Field<string>("Method")));
                    Quarter = Strings.Trim((Information.IsDBNull(myRow5.Field<string>("Quarter")) ? "" : myRow5.Field<string>("Quarter")));

                    FileSystem.PrintLine(FileNum, string.Format("{0},{1},{2}", FactorID, Method, Quarter));

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

        public void RefreshPeriods()
        {
            List<Item> itemslstPeriods = new List<Item>();

            try
            {
                //retrieve the list of periods
                modGlobal.gv_sql = "Select Quarter from tbl_Setup_IndicatorRiskAdjustmentCoefficients GROUP BY quarter order by quarter desc";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName6 = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                lstPeriods.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow6 in modGlobal.gv_rs.Tables[sqlTableName6].Rows)
                {
                    itemslstPeriods.Add(new Item(myRow6.Field<int>("Quarter"), Strings.Mid(myRow6.Field<string>("Quarter"), 5, 2) + " - " + Strings.Mid(myRow6.Field<string>("Quarter"), 1, 4)));


                    //lstPeriods.Items.Add(new ListBoxItem(Strings.Mid(myRow6.Field<string>("Quarter"), 5, 2) + " - " + Strings.Mid(myRow6.Field<string>("Quarter"), 1, 4), myRow6.Field<int>("Quarter")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.lstPeriods.DataSource = itemslstPeriods;
                this.lstPeriods.DisplayMember = "Description";
                this.lstPeriods.ValueMember = "Id";

                //LDW lstPeriods.SetSelected(0, true);
                lstPeriods.SelectedIndex = 0;
                lstPeriods.SelectedItem.Active = true;
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
