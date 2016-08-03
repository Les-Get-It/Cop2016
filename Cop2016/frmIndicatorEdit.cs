using System;
using System.Collections.Generic;
using System.Data;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmIndicatorEdit : Telerik.WinControls.UI.RadForm
    {
        public frmIndicatorEdit()
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

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            frmIndicatorSetup frmIndicatorSetupCopy = new frmIndicatorSetup();

            try
            {

                if ((!Information.IsDBNull(txtLastupdateDate.Text)) & !string.IsNullOrEmpty(txtLastupdateDate.Text))
                {
                    if (!Information.IsDate(txtLastupdateDate.Text))
                    {
                        RadMessageBox.Show("Date does not have a valid format");
                        return;
                    }
                }

                if (string.IsNullOrEmpty(txtIndicatorDescription.Text))
                {
                    RadMessageBox.Show("Indicator Name Cannot Be Blank");
                    return;
                }

                if (string.IsNullOrEmpty(cboPatientType.Text))
                {
                    RadMessageBox.Show("You must select a patient type for this Indicator.");
                    return;
                }

                modGlobal.gv_Action = "Update";
                modGlobal.gv_sql = "Update tbl_setup_Indicator ";
                modGlobal.gv_sql = string.Format("{0} set Description =  '{1}'", modGlobal.gv_sql, txtIndicatorDescription.Text);
                if ((!Information.IsDBNull(txtLastupdateDate.Text)) & !string.IsNullOrEmpty(txtLastupdateDate.Text))
                {
                    modGlobal.gv_sql = string.Format("{0} ,lastupdatedate =  '{1}'", modGlobal.gv_sql, txtLastupdateDate.Text);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " ,lastupdatedate =  Null ";
                }
                if ((!Information.IsDBNull(txtJCAHOID.Text)) & !string.IsNullOrEmpty(txtJCAHOID.Text))
                {
                    modGlobal.gv_sql = string.Format("{0} ,JCAHOID =  {1}", modGlobal.gv_sql, txtJCAHOID.Text);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " ,JCAHOID =  Null ";
                }
                if (!string.IsNullOrEmpty(cboIndicatorType.Text))
                {
                    if (cboIndicatorType.Text == "Acute Care")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " ,IndicatorType =  'AC'";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " ,IndicatorType =  'BH'";
                    }
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " ,IndicatorType =  Null ";
                }

                if (!string.IsNullOrEmpty(cboBaseType.Text))
                {
                    modGlobal.gv_sql = string.Format("{0} ,BaseType =  '{1}'", modGlobal.gv_sql, cboBaseType.Text);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " ,BaseType =  Null ";
                }

                if (!string.IsNullOrEmpty(cboMeasureDataUsage.Text))
                {
                    modGlobal.gv_sql = string.Format("{0} , MeasureDataUsage =  '{1}'", modGlobal.gv_sql, cboMeasureDataUsage.Text);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " , MeasureDataUsage =  Null ";
                }

                if (!string.IsNullOrEmpty(cboCalcType.Text))
                {
                    modGlobal.gv_sql = string.Format("{0} ,Calctype =  '{1}'", modGlobal.gv_sql, cboCalcType.Text);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " ,CalcType =  Null ";
                }
                if (!string.IsNullOrEmpty(cboRiskAdjusted.Text))
                {
                    if (cboRiskAdjusted.Text == "Yes")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " ,RiskAdjusted =  1 ";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " ,RiskAdjusted =  0 ";
                    }
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " ,RiskAdjusted =  Null ";
                }
                if (!string.IsNullOrEmpty(cboMeasureTimeUnit.Text))
                {
                    modGlobal.gv_sql = string.Format("{0} , MeasureTimeby =  '{1}'", modGlobal.gv_sql, cboMeasureTimeUnit.Text);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " , MeasureTimeby =  Null ";
                }
                if (!string.IsNullOrEmpty(cboBestPractice.Text))
                {
                    if (cboBestPractice.Text == "Good")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " , BestPractice =  '>' ";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " ,BestPractice =  '<' ";
                    }
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " ,BestPractice =  Null ";
                }
                if (!string.IsNullOrEmpty(cboBreakoutType.Text))
                {
                    modGlobal.gv_sql = string.Format("{0} , BreakoutType =  '{1}'", modGlobal.gv_sql, cboBreakoutType.Text);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " , BreakoutType =  Null ";
                }
                if (!string.IsNullOrEmpty(cboSPageOrientation.Text))
                {
                    if (cboSPageOrientation.Text == "Portrait")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " , StatewidePageOrientation =  'P' ";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " , StatewidePageOrientation =  'L' ";
                    }
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " ,StatewidePageOrientation =  Null ";
                }
                if ((!Information.IsDBNull(txtScale.Text)) & !string.IsNullOrEmpty(txtScale.Text))
                {
                    modGlobal.gv_sql = string.Format("{0} ,Scale =  {1}", modGlobal.gv_sql, txtScale.Text);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " ,Scale =  Null ";
                }
                if (cboStartDateDDID.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} , StartDateFieldID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboStartDateDDID, cboStartDateDDID.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " ,StartDateFieldID =  Null ";
                }
                if (cboStartTimeDDID.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} , StartTimeFieldID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboStartTimeDDID, cboStartTimeDDID.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " ,StartTimeFieldID =  Null ";
                }
                if (cboEndDateDDID.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} , EndDateFieldID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboEndDateDDID, cboEndDateDDID.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " , EndDateFieldID =  Null ";
                }
                if (cboEndTimeDDID.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} , EndTimeFieldID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboEndTimeDDID, cboEndTimeDDID.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " ,EndTimeFieldID =  Null ";
                }
                if (cboContinuousSGID.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} , ContinuousSGID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboContinuousSGID, cboContinuousSGID.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " , ContinuousSGID =  Null ";
                }
                if (cboRiskAdjustSGID.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} , RiskAdjustSGID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboRiskAdjustSGID, cboRiskAdjustSGID.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " , RiskAdjustSGID =  Null ";
                }
                if (string.IsNullOrEmpty(txtJCCode.Text))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " , JCCode =  null ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} , JCCode =  '{1}'", modGlobal.gv_sql, txtJCCode.Text);
                }
                if (string.IsNullOrEmpty(txtCMSCode.Text))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " , CMSCode =  null ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} , CMSCode =  '{1}'", modGlobal.gv_sql, txtCMSCode.Text);
                }

                if (string.IsNullOrEmpty(cboCMSSampleField.Text))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " , CMSSampleFieldDDID = null";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} , CMSSampleFieldDDID = {1}", modGlobal.gv_sql, Support.GetItemData(cboCMSSampleField, cboCMSSampleField.SelectedIndex));
                }

                if (string.IsNullOrEmpty(cboStartDateTime.Text))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " , StartDateTimeFieldID =  null ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} , StartDateTimeFieldID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboStartDateTime, cboStartDateTime.SelectedIndex));
                }

                if (string.IsNullOrEmpty(cboEndDateTime.Text))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " , EndDateTimeFieldID =  null ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} , EndDateTimeFieldID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboEndDateTime, cboEndDateTime.SelectedIndex));
                }

                modGlobal.gv_sql = string.Format("{0} , PatientType = {1}", modGlobal.gv_sql, Support.GetItemData(cboPatientType, cboPatientType.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} , AppCare = {1}", modGlobal.gv_sql, chkAppCare.CheckState);

                modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
                modGlobal.gv_sql = string.Format("{0} IndicatorID = {1}", modGlobal.gv_sql, Support.GetItemData(frmIndicatorSetupCopy.lstIndicators, frmIndicatorSetupCopy.lstIndicators.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                int li_cnt = 0;

                modGlobal.gv_sql = "DELETE FROM tbl_Setup_IndicatorNumberOfCases WHERE IndicatorID = " +
                        Support.GetItemData(frmIndicatorSetupCopy.lstIndicators, frmIndicatorSetupCopy.lstIndicators.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                if (lstTotalCases.SelectedItems.Count > 0)
                {
                    for (li_cnt = 0; li_cnt <= lstTotalCases.Items.Count - 1; li_cnt++)
                    {
                        if (lstTotalCases.SelectedIndex == li_cnt)
                        {
                            modGlobal.gv_sql = string.Format("INSERT INTO tbl_Setup_IndicatorNumberOfCases (IndicatorID, NumberOfCasesDDID) VALUES ({0}, {1})",
                                Support.GetItemData(frmIndicatorSetupCopy.lstIndicators,
                                frmIndicatorSetupCopy.lstIndicators.SelectedIndex), Support.GetItemData(lstTotalCases, li_cnt));
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        }
                    }
                }


                modGlobal.gv_sql = "DELETE FROM tbl_Setup_IndicatorICDPop WHERE IndicatorID = " +
                    Support.GetItemData(frmIndicatorSetupCopy.lstIndicators, frmIndicatorSetupCopy.lstIndicators.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                if (lstICD.SelectedItems.Count > 0)
                {
                    for (li_cnt = 0; li_cnt <= lstICD.Items.Count - 1; li_cnt++)
                    {
                        if (lstICD.SelectedIndex == li_cnt)
                        {
                            modGlobal.gv_sql = string.Format("INSERT INTO tbl_Setup_IndicatorICDPop (IndicatorID, ICDPopDDID) VALUES ({0}, {1})",
                                Support.GetItemData(frmIndicatorSetupCopy.lstIndicators,
                                frmIndicatorSetupCopy.lstIndicators.SelectedIndex), Support.GetItemData(lstICD, li_cnt));
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        }
                    }
                }

                this.Close();
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

        private void frmIndicatorEdit_Load(object sender, EventArgs e)
        {
            frmIndicatorSetup frmIndicatorSetupCopy = new frmIndicatorSetup();
            var i = 0;
            DataSet thisrs = new DataSet();


            try
            {

                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
                modGlobal.gv_sql = string.Format("{0} IndicatorID = {1}", modGlobal.gv_sql, Support.GetItemData(frmIndicatorSetupCopy.lstIndicators, frmIndicatorSetupCopy.lstIndicators.SelectedIndex));
                //LDW thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_Indicator";
                thisrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, thisrs);

                txtIndicatorDescription.Text = thisrs.Tables[sqlTableName1].Rows[0]["Description"].ToString();

                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["JCCode"]))
                {
                    txtJCCode.Text = thisrs.Tables[sqlTableName1].Rows[0]["JCCode"].ToString();
                }
                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["CMSCode"]))
                {
                    txtCMSCode.Text = thisrs.Tables[sqlTableName1].Rows[0]["CMSCode"].ToString();
                }

                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["lastupdatedate"]))
                {
                    txtLastupdateDate.Text = thisrs.Tables[sqlTableName1].Rows[0]["lastupdatedate"].ToString();
                }
                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["JCAHOID"]))
                {
                    txtJCAHOID.Text = thisrs.Tables[sqlTableName1].Rows[0]["JCAHOID"].ToString();
                }

                //refresh indicator type
                cboIndicatorType.Items.Clear();
                cboIndicatorType.Items.Add("Acute Care");
                cboIndicatorType.Items.Add("Behavioral Health");
                if (thisrs.Tables[sqlTableName1].Rows[0]["IndicatorType"].ToString() == "AC")
                {
                    cboIndicatorType.Text = "Acute Care";
                }
                else if (thisrs.Tables[sqlTableName1].Rows[0]["IndicatorType"].ToString() == "BH")
                {
                    cboIndicatorType.Text = "Behavioral Health";
                }
                //lstIndicatorType.ItemData(lstIndicators.NewIndex) = thisrs!IndicatorID

                //refresh Calc. type
                cboCalcType.Items.Clear();
                cboCalcType.Items.Add("Count");
                cboCalcType.Items.Add("Time");
                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["CalcType"]))
                {
                    cboCalcType.Text = thisrs.Tables[sqlTableName1].Rows[0]["CalcType"].ToString();
                }

                //refresh Risk Adjusted?
                cboRiskAdjusted.Items.Clear();
                cboRiskAdjusted.Items.Add("Yes");
                // 1
                cboRiskAdjusted.Items.Add("No");
                //0
                if (Convert.ToInt32(thisrs.Tables[sqlTableName1].Rows[0]["RiskAdjusted"]) == 1)
                {
                    cboRiskAdjusted.Text = "Yes";
                }
                else if (Convert.ToInt32(thisrs.Tables[sqlTableName1].Rows[0]["RiskAdjusted"]) == 0)
                {
                    cboRiskAdjusted.Text = "No";
                }

                //refresh Measure Time By?
                cboMeasureTimeUnit.Items.Clear();
                cboMeasureTimeUnit.Items.Add("Minute");
                cboMeasureTimeUnit.Items.Add("Hour");
                cboMeasureTimeUnit.Items.Add("Day");
                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["MeasureTimeBy"]))
                {
                    cboMeasureTimeUnit.Text = thisrs.Tables[sqlTableName1].Rows[0]["MeasureTimeBy"].ToString();
                }

                //refresh Best Practice
                cboBestPractice.Items.Clear();
                cboBestPractice.Items.Add("Good");
                //>
                cboBestPractice.Items.Add("Bad");
                //<
                if (thisrs.Tables[sqlTableName1].Rows[0]["BestPractice"].ToString() == ">")
                {
                    cboBestPractice.Text = "Good";
                }
                else if (thisrs.Tables[sqlTableName1].Rows[0]["BestPractice"].ToString() == "<")
                {
                    cboBestPractice.Text = "Bad";
                }

                //refresh Breakout Type
                cboBreakoutType.Items.Clear();
                cboBreakoutType.Items.Add("");
                cboBreakoutType.Items.Add("Individual");
                cboBreakoutType.Items.Add("Percent");
                cboBreakoutType.Items.Add("Rate");
                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["BreakoutType"]))
                {
                    cboBreakoutType.Text = thisrs.Tables[sqlTableName1].Rows[0]["BreakoutType"].ToString();
                }

                //refresh Breakout Type
                cboSPageOrientation.Items.Clear();
                cboSPageOrientation.Items.Add("Portrait");
                cboSPageOrientation.Items.Add("Landscape");
                if (thisrs.Tables[sqlTableName1].Rows[0]["StatewidePageOrientation"].ToString() == "P")
                {
                    cboSPageOrientation.Text = "Portrait";
                }
                else if (thisrs.Tables[sqlTableName1].Rows[0]["StatewidePageOrientation"].ToString() == "L")
                {
                    cboSPageOrientation.Text = "Landscape";
                }

                cboBaseType.Items.Clear();
                cboBaseType.Items.Add("Rate");
                cboBaseType.Items.Add("Ratio");
                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["BaseType"]))
                {
                    cboBaseType.Text = thisrs.Tables[sqlTableName1].Rows[0]["BaseType"].ToString();
                }

                cboMeasureDataUsage.Items.Clear();
                cboMeasureDataUsage.Items.Add("Core");
                cboMeasureDataUsage.Items.Add("Non-Core");
                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["MeasureDataUsage"]))
                {
                    cboMeasureDataUsage.Text = thisrs.Tables[sqlTableName1].Rows[0]["MeasureDataUsage"].ToString();
                }


                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["Scale"]))
                {
                    txtScale.Text = thisrs.Tables[sqlTableName1].Rows[0]["Scale"].ToString();
                }

                //refresh patient type
                cboPatientType.Items.Clear();
                cboPatientType.Items.Add(new ListBoxItem("Inpatient", 1).ToString());
                cboPatientType.Items.Add(new ListBoxItem("Outpatient", 2).ToString());
                cboPatientType.Items.Add(new ListBoxItem("Event Date", 3).ToString());

                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["PatientType"]))
                {
                    cboPatientType.SelectedIndex = Convert.ToInt32(thisrs.Tables[sqlTableName1].Rows[0]["PatientType"]) - 1;
                }

                RefreshSubGroups();
                RefreshDateTimeFields();

                //display the Date fields
                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["StartDateFieldID"]))
                {
                    for (i = 0; i <= cboStartDateDDID.Items.Count - 1; i++)
                    {
                        if (Convert.ToInt32(thisrs.Tables[sqlTableName1].Rows[0]["StartDateFieldID"]) == Support.GetItemData(cboStartDateDDID, i))
                        {
                            cboStartDateDDID.SelectedIndex = i;
                        }
                    }
                }
                else
                {
                    cboStartDateDDID.Text = "";
                    cboStartDateDDID.SelectedIndex = -1;
                }
                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["EndDateFieldID"]))
                {
                    for (i = 0; i <= cboEndDateDDID.Items.Count - 1; i++)
                    {
                        if (Convert.ToInt32(thisrs.Tables[sqlTableName1].Rows[0]["EndDateFieldID"]) == Support.GetItemData(cboEndDateDDID, i))
                        {
                            cboEndDateDDID.SelectedIndex = i;
                        }
                    }
                }
                else
                {
                    cboEndDateDDID.Text = "";
                    cboEndDateDDID.SelectedIndex = -1;
                }

                //display the time fields
                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["StartTimeFieldID"]))
                {
                    for (i = 0; i <= cboStartTimeDDID.Items.Count - 1; i++)
                    {
                        if (Convert.ToInt32(thisrs.Tables[sqlTableName1].Rows[0]["StartTimeFieldID"]) == Support.GetItemData(cboStartTimeDDID, i))
                        {
                            cboStartTimeDDID.SelectedIndex = i;
                        }
                    }
                }
                else
                {
                    cboStartTimeDDID.Text = "";
                    cboStartTimeDDID.SelectedIndex = -1;
                }
                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["EndTimeFieldID"]))
                {
                    for (i = 0; i <= cboEndTimeDDID.Items.Count - 1; i++)
                    {
                        if (Convert.ToInt32(thisrs.Tables[sqlTableName1].Rows[0]["EndTimeFieldID"]) == Support.GetItemData(cboEndTimeDDID, i))
                        {
                            cboEndTimeDDID.SelectedIndex = i;
                        }
                    }
                }
                else
                {
                    cboEndTimeDDID.Text = "";
                    cboEndTimeDDID.SelectedIndex = -1;
                }

                //display the Summary fields
                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["ContinuousSGID"]))
                {
                    for (i = 0; i <= cboContinuousSGID.Items.Count - 1; i++)
                    {
                        if (Convert.ToInt32(thisrs.Tables[sqlTableName1].Rows[0]["ContinuousSGID"]) == Support.GetItemData(cboContinuousSGID, i))
                        {
                            cboContinuousSGID.SelectedIndex = i;
                        }
                    }
                }
                else
                {
                    cboContinuousSGID.Text = "";
                    cboContinuousSGID.SelectedIndex = -1;
                }

                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["RiskAdjustSGID"]))
                {
                    for (i = 0; i <= cboRiskAdjustSGID.Items.Count - 1; i++)
                    {
                        if (Convert.ToInt32(thisrs.Tables[sqlTableName1].Rows[0]["RiskAdjustSGID"]) == Support.GetItemData(cboRiskAdjustSGID, i))
                        {
                            cboRiskAdjustSGID.SelectedIndex = i;
                        }
                    }
                }
                else
                {
                    cboRiskAdjustSGID.Text = "";
                    cboRiskAdjustSGID.SelectedIndex = -1;
                }

                RefreshCMSSampleFields();
                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["CMSSampleFieldDDID"]))
                {
                    for (i = 0; i <= cboCMSSampleField.Items.Count - 1; i++)
                    {
                        if (Convert.ToInt32(thisrs.Tables[sqlTableName1].Rows[0]["CMSSampleFieldDDID"]) == Support.GetItemData(cboCMSSampleField, i))
                        {
                            cboCMSSampleField.SelectedIndex = i;
                        }
                    }
                }
                else
                {
                    cboCMSSampleField.Text = "";
                    cboCMSSampleField.SelectedIndex = -1;
                }

                RefreshNumberofCases();

                //display the date/time fields
                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["StartDateTimeFieldID"]))
                {
                    for (i = 0; i <= cboStartDateTime.Items.Count - 1; i++)
                    {
                        if (Convert.ToInt32(thisrs.Tables[sqlTableName1].Rows[0]["StartDateTimeFieldID"]) == Support.GetItemData(cboStartDateTime, i))
                        {
                            cboStartDateTime.SelectedIndex = i;
                        }
                    }
                }
                else
                {
                    cboStartDateTime.Text = "";
                    cboStartDateTime.SelectedIndex = -1;
                }

                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["EndDateTimeFieldID"]))
                {
                    for (i = 0; i <= cboEndDateTime.Items.Count - 1; i++)
                    {
                        if (Convert.ToInt32(thisrs.Tables[sqlTableName1].Rows[0]["EndDateTimeFieldID"]) == Support.GetItemData(cboEndDateTime, i))
                        {
                            cboEndDateTime.SelectedIndex = i;
                        }
                    }
                }
                else
                {
                    cboEndDateTime.Text = "";
                    cboEndDateTime.SelectedIndex = -1;
                }

                RefreshICDPopulation();

                if (!Information.IsDBNull(thisrs.Tables[sqlTableName1].Rows[0]["appcare"]))
                {
                    chkAppCare.Checked = (Convert.ToBoolean(thisrs.Tables[sqlTableName1].Rows[0]["appcare"]) ? true : false);
                }
                else
                {
                    //LDW chkAppCare.CheckState = false;
                    chkAppCare.Checked = false;
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

        private void RefreshNumberofCases()
        {
            frmIndicatorSetup frmIndicatorSetupCopy = new frmIndicatorSetup();
            var LIndex = 0;
            var Table_ListIndex = 0;
            DataSet rsSelected = new DataSet();

            try
            {

                //
                //retrieve the list of Indicators
                //
                modGlobal.gv_sql = "Select * from tbl_setup_DataDef where BaseTableID = 2 ORDER BY FieldName";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);
                //
                //
                //
                modGlobal.gv_sql = "select NumberOfCasesDDID from tbl_Setup_IndicatorNumberOfCases where IndicatorID = " +
                    Support.GetItemData(frmIndicatorSetupCopy.lstIndicators, frmIndicatorSetupCopy.lstIndicators.SelectedIndex);
                //LDW rsSelected = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_Setup_IndicatorNumberOfCases";
                rsSelected = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, rsSelected);
                //
                //fill the list box
                //
                lstTotalCases.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    lstTotalCases.Items.Add(string.Format("{0} ({1})", myRow2.Field<string>("FieldName"), myRow2.Field<string>("DDID")));

                    Support.SetItemData(lstTotalCases, lstTotalCases.Items.Count - 1, myRow2.Field<int>("DDID"));
                    if (rsSelected.Tables[sqlTableName3].Rows.Count > 0)
                    {
                        //LDW rsSelected.MoveFirst();
                        //LDW while (!rsSelected.EOF)
                        foreach (DataRow myRow3 in rsSelected.Tables[sqlTableName3].Rows)
                        {
                            if (Strings.Trim(myRow3.Field<string>("NumberOfCasesDDID")) == Strings.Trim(myRow2.Field<string>("DDID")))
                            {
                                //LDW lstTotalCases.SetSelected(lstTotalCases.Items.Count - 1, true);
                                lstTotalCases.SelectedIndex = lstTotalCases.Items.Count - 1;
                                lstTotalCases.SelectedItem.Active = true;
                            }
                            //LDW rsSelected.MoveNext();
                        }
                    }
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                rsSelected.Dispose();
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

        public void RefreshSubGroups()
        {
            frmIndicatorSetup frmIndicatorSetupCopy = new frmIndicatorSetup();

            try
            {

                modGlobal.gv_sql = "Select g.*, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " r.GroupRowID, r.Title as GroupRow, r.ShowOnReport as ShowRowonReport, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " c.SubGroupID, c.Title as GroupCol, c.IndicatorID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " c.AggregateFunction, c.showonreport as showcolonreport ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_SubmitGroup as g inner join tbl_Setup_SubmitGroupRow as r";
                modGlobal.gv_sql = modGlobal.gv_sql + " on g.GroupID = r.GroupID)  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_SubmitSubGroup as c ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on r.GroupRowID = c.GroupRowID ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (g.State = '' or g.State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} Where g.state = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = string.Format("{0} and c.indicatorid = {1}", modGlobal.gv_sql,
                    Support.GetItemData(frmIndicatorSetupCopy.lstIndicators, frmIndicatorSetupCopy.lstIndicators.SelectedIndex));
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (g.RecordStatus = '' or g.RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and g.RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by g.ordernumber, r.ordernumber, c.ordernumber ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_setup_SubmitGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                //Display the list of fields
                cboContinuousSGID.Items.Clear();
                cboRiskAdjustSGID.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName4].Rows)
                {
                    cboContinuousSGID.Items.Add(new ListBoxItem(myRow4.Field<string>("GroupName") + " / " + myRow4.Field<string>("GroupRow") +
                        " / " + myRow4.Field<string>("GroupCol"), myRow4.Field<int>("SubGroupID")).ToString());
                    cboRiskAdjustSGID.Items.Add(new ListBoxItem(myRow4.Field<string>("GroupName") + " / " + myRow4.Field<string>("GroupRow") +
                        " / " + myRow4.Field<string>("GroupCol"), myRow4.Field<int>("SubGroupID")).ToString());
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

        public void RefreshDateTimeFields()
        {

            try
            {
                //retrieve the list of table fields
                modGlobal.gv_sql = "Select dd.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef as dd inner join tbl_setup_TableDef as td ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on dd.basetableid = td.basetableid";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where td.BaseTable = 'PATIENT' ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State = '' or dd.State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (dd.State = '' or dd.State is null or dd.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " and dd.fieldtype = 'Date'";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName5 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                //Display the list of fields
                cboStartDateDDID.Items.Clear();
                cboEndDateDDID.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow5 in modGlobal.gv_rs.Tables[sqlTableName5].Rows)
                {
                    cboStartDateDDID.Items.Add(new ListBoxItem(myRow5.Field<string>("FieldName"), myRow5.Field<int>("DDID")).ToString());
                    cboEndDateDDID.Items.Add(new ListBoxItem(myRow5.Field<string>("FieldName"), myRow5.Field<int>("DDID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                //retrieve the list of table fields
                modGlobal.gv_sql = "Select dd.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef as dd inner join tbl_setup_TableDef as td ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on dd.basetableid = td.basetableid";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where td.BaseTable = 'PATIENT' ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State = '' or dd.State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (dd.State = '' or dd.State is null or dd.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " and dd.fieldtype = 'Time'";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName6 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                //Display the list of fields
                cboStartTimeDDID.Items.Clear();
                cboEndTimeDDID.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow6 in modGlobal.gv_rs.Tables[sqlTableName6].Rows)
                {
                    cboStartTimeDDID.Items.Add(new ListBoxItem(myRow6.Field<string>("FieldName"), myRow6.Field<int>("DDID")).ToString());
                    cboEndTimeDDID.Items.Add(new ListBoxItem(myRow6.Field<string>("FieldName"), myRow6.Field<int>("DDID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();


                //retrieve the list of table fields
                modGlobal.gv_sql = "Select dd.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef as dd inner join tbl_setup_TableDef as td ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on dd.basetableid = td.basetableid";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where td.BaseTable = 'PATIENT' ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State = '' or dd.State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (dd.State = '' or dd.State is null or dd.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " and dd.fieldtype = 'Date/Time'";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName7 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                cboStartDateTime.Items.Clear();
                cboEndDateTime.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow7 in modGlobal.gv_rs.Tables[sqlTableName7].Rows)
                {
                    cboStartDateTime.Items.Add(new ListBoxItem(myRow7.Field<string>("FieldName"), myRow7.Field<int>("DDID")).ToString());

                    cboEndDateTime.Items.Add(new ListBoxItem(myRow7.Field<string>("FieldName"), myRow7.Field<int>("DDID")).ToString());
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

        public void RefreshCMSSampleFields()
        {

            try
            {
                //retrieve the list of sample fields
                modGlobal.gv_sql = "Select dd.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef as dd inner join tbl_setup_TableDef as td ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on dd.basetableid = td.basetableid";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where td.BaseTable = 'HOSPITAL STATISTICS' ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State = '' or dd.State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (dd.State = '' or dd.State is null or dd.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " and dd.fieldname like '%SAMPLE%'";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);

                //Display the list of fields
                cboCMSSampleField.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow8 in modGlobal.gv_rs.Tables[sqlTableName8].Rows)
                {
                    cboCMSSampleField.Items.Add(new ListBoxItem(myRow8.Field<string>("FieldName"), myRow8.Field<int>("DDID")).ToString());
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

        private void RefreshICDPopulation()
        {
            frmIndicatorSetup frmIndicatorSetupCopy = new frmIndicatorSetup();
            var LIndex = 0;
            var Table_ListIndex = 0;
            DataSet rsSelected = new DataSet();

            try
            {
                //
                //retrieve the list of Indicators
                //
                modGlobal.gv_sql = "Select * from tbl_setup_DataDef where BaseTableID = 2 ORDER BY FieldName";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName9 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                //
                //
                //
                modGlobal.gv_sql = "select ICDPopDDID from tbl_Setup_IndicatorICDPop where IndicatorID = " + Support.GetItemData(frmIndicatorSetupCopy.lstIndicators, frmIndicatorSetupCopy.lstIndicators.SelectedIndex);
                //LDW rsSelected = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName10 = "tbl_Setup_IndicatorICDPop";
                rsSelected = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, rsSelected);
                //
                //fill the list box
                //
                lstICD.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow9 in modGlobal.gv_rs.Tables[sqlTableName9].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    lstICD.Items.Add(string.Format("{0} ({1})", myRow9.Field<string>("FieldName"), myRow9.Field<string>("DDID")));

                    Support.SetItemData(lstICD, lstICD.Items.Count - 1, myRow9.Field<int>("DDID"));
                    if (rsSelected.Tables[sqlTableName10].Rows.Count > 0)
                    {
                        //LDW rsSelected.MoveFirst();
                        //LDW while (!rsSelected.EOF)
                        foreach (DataRow myRow10 in rsSelected.Tables[sqlTableName10].Rows)
                        {
                            if (Strings.Trim(myRow10.Field<string>("ICDPopDDID")) == Strings.Trim(myRow9.Field<string>("DDID")))
                            {
                                //LDW lstICD.SetSelected(lstICD.Items.Count - 1, true);
                                lstICD.SelectedIndex = lstICD.Items.Count - 1;
                                lstICD.SelectedItem.Active = true;
                            }
                            //LDW rsSelected.MoveNext();
                        }
                    }
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                rsSelected.Dispose();
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

        /*LDW not used
        Private Sub RefreshAppCareBoxes()
        //    cboAppCareNumerator.Clear
        //    cboAppCareDenominator.Clear
        //
        //
        //    retrieve the list of Reports
        //
        //    gv_sql = "Select * from tbl_setup_SavedAdhocReports ORDER BY Report_Name"
        //    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //
        //
        //
        //    fill the list box
        //
        //    lstICD.Clear
        //    Table_ListIndex = -1
        //    LIndex = -1
        //    While Not gv_rs.EOF
        //        LIndex = LIndex + 1
        //        Table_ListIndex = LIndex
        //
        //        cboAppCareNumerator.AddItem gv_rs!Report_Name & " (" & gv_rs!Report_ID & ")"
        //        cboAppCareNumerator.ItemData(cboAppCareNumerator.Items.Count-1) = gv_rs!Report_ID
        //
        //
        //        cboAppCareDenominator.AddItem gv_rs!Report_Name & " (" & gv_rs!Report_ID & ")"
        //        cboAppCareDenominator.ItemData(cboAppCareDenominator.Items.Count-1) = gv_rs!Report_ID
        //
        //
        //        gv_rs.MoveNext
        //    Wend
        //
        //    gv_rs.Close
        //
        //
        //
        //End Sub
        */

    }
}
