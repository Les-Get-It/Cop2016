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
	internal partial class OldfrmIndicatorEdit : System.Windows.Forms.Form
	{

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if ((!Information.IsDBNull(txtLastupdateDate.Text)) & !string.IsNullOrEmpty(txtLastupdateDate.Text)) {
				if (!Information.IsDate(txtLastupdateDate.Text)) {
					RadMessageBox.Show("Date does not have a valid format");
					return;
				}
			}

			if (string.IsNullOrEmpty(txtIndicatorDescription.Text)) {
				RadMessageBox.Show("Indicator Name Cannot Be Blank");
				return;
			}

			if (string.IsNullOrEmpty(cboPatientType.Text)) {
				RadMessageBox.Show("You must select a patient type for this Indicator.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Update";
			modGlobal.gv_sql = "Update tbl_setup_Indicator ";
			modGlobal.gv_sql = modGlobal.gv_sql + " set Description =  '" + txtIndicatorDescription.Text + "'";
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if ((!Information.IsDBNull(txtLastupdateDate.Text)) & !string.IsNullOrEmpty(txtLastupdateDate.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,lastupdatedate =  '" + txtLastupdateDate.Text + "'";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,lastupdatedate =  Null ";
			}
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if ((!Information.IsDBNull(txtJCAHOID.Text)) & !string.IsNullOrEmpty(txtJCAHOID.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,JCAHOID =  " + txtJCAHOID.Text;
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,JCAHOID =  Null ";
			}
			if (!string.IsNullOrEmpty(cboIndicatorType.Text)) {
				if (cboIndicatorType.Text == "Acute Care") {
					modGlobal.gv_sql = modGlobal.gv_sql + " ,IndicatorType =  'AC'";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + " ,IndicatorType =  'BH'";
				}
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,IndicatorType =  Null ";
			}

			if (!string.IsNullOrEmpty(cboBaseType.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,BaseType =  '" + cboBaseType.Text + "'";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,BaseType =  Null ";
			}

			if (!string.IsNullOrEmpty(cboMeasureDataUsage.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " , MeasureDataUsage =  '" + cboMeasureDataUsage.Text + "'";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " , MeasureDataUsage =  Null ";
			}

			if (!string.IsNullOrEmpty(cboCalcType.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,Calctype =  '" + cboCalcType.Text + "'";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,CalcType =  Null ";
			}
			if (!string.IsNullOrEmpty(cboRiskAdjusted.Text)) {
				if (cboRiskAdjusted.Text == "Yes") {
					modGlobal.gv_sql = modGlobal.gv_sql + " ,RiskAdjusted =  1 ";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + " ,RiskAdjusted =  0 ";
				}
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,RiskAdjusted =  Null ";
			}
			if (!string.IsNullOrEmpty(cboMeasureTimeUnit.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " , MeasureTimeby =  '" + cboMeasureTimeUnit.Text + "'";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " , MeasureTimeby =  Null ";
			}
			if (!string.IsNullOrEmpty(cboBestPractice.Text)) {
				if (cboBestPractice.Text == "Good") {
					modGlobal.gv_sql = modGlobal.gv_sql + " , BestPractice =  '>' ";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + " ,BestPractice =  '<' ";
				}
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,BestPractice =  Null ";
			}
			if (!string.IsNullOrEmpty(cboBreakoutType.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " , BreakoutType =  '" + cboBreakoutType.Text + "'";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " , BreakoutType =  Null ";
			}
			if (!string.IsNullOrEmpty(cboSPageOrientation.Text)) {
				if (cboSPageOrientation.Text == "Portrait") {
					modGlobal.gv_sql = modGlobal.gv_sql + " , StatewidePageOrientation =  'P' ";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + " , StatewidePageOrientation =  'L' ";
				}
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,StatewidePageOrientation =  Null ";
			}
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if ((!Information.IsDBNull(txtScale.Text)) & !string.IsNullOrEmpty(txtScale.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,Scale =  " + txtScale.Text;
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,Scale =  Null ";
			}
			if (cboStartDateDDID.SelectedIndex > -1) {
				modGlobal.gv_sql = modGlobal.gv_sql + " , StartDateFieldID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStartDateDDID, cboStartDateDDID.SelectedIndex);
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,StartDateFieldID =  Null ";
			}
			if (cboStartTimeDDID.SelectedIndex > -1) {
				modGlobal.gv_sql = modGlobal.gv_sql + " , StartTimeFieldID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStartTimeDDID, cboStartTimeDDID.SelectedIndex);
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,StartTimeFieldID =  Null ";
			}
			if (cboEndDateDDID.SelectedIndex > -1) {
				modGlobal.gv_sql = modGlobal.gv_sql + " , EndDateFieldID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboEndDateDDID, cboEndDateDDID.SelectedIndex);
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " , EndDateFieldID =  Null ";
			}
			if (cboEndTimeDDID.SelectedIndex > -1) {
				modGlobal.gv_sql = modGlobal.gv_sql + " , EndTimeFieldID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboEndTimeDDID, cboEndTimeDDID.SelectedIndex);
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " ,EndTimeFieldID =  Null ";
			}
			if (cboContinuousSGID.SelectedIndex > -1) {
				modGlobal.gv_sql = modGlobal.gv_sql + " , ContinuousSGID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboContinuousSGID, cboContinuousSGID.SelectedIndex);
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " , ContinuousSGID =  Null ";
			}
			if (cboRiskAdjustSGID.SelectedIndex > -1) {
				modGlobal.gv_sql = modGlobal.gv_sql + " , RiskAdjustSGID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboRiskAdjustSGID, cboRiskAdjustSGID.SelectedIndex);
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " , RiskAdjustSGID =  Null ";
			}
			if (string.IsNullOrEmpty(txtJCCode.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " , JCCode =  null ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " , JCCode =  '" + txtJCCode.Text + "'";
			}
			if (string.IsNullOrEmpty(txtCMSCode.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " , CMSCode =  null ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " , CMSCode =  '" + txtCMSCode.Text + "'";
			}

			if (string.IsNullOrEmpty(cboCMSSampleField.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " , CMSSampleFieldDDID = null";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " , CMSSampleFieldDDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboCMSSampleField, cboCMSSampleField.SelectedIndex);
			}

			if (string.IsNullOrEmpty(cboStartDateTime.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " , StartDateTimeFieldID =  null ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " , StartDateTimeFieldID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStartDateTime, cboStartDateTime.SelectedIndex);
			}

			if (string.IsNullOrEmpty(cboEndDateTime.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " , EndDateTimeFieldID =  null ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " , EndDateTimeFieldID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboEndDateTime, cboEndDateTime.SelectedIndex);
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " , PatientType = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboPatientType, cboPatientType.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " , AppCare = " + chkAppCare.CheckState;

			modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
			modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmIndicatorSetupCopy.lstIndicators, frmIndicatorSetupCopy.lstIndicators.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			int li_cnt = 0;

			modGlobal.gv_sql = "DELETE FROM tbl_Setup_IndicatorNumberOfCases WHERE IndicatorID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmIndicatorSetupCopy.lstIndicators, frmIndicatorSetupCopy.lstIndicators.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			if (lstTotalCases.SelectedItems.Count > 0) {
				for (li_cnt = 0; li_cnt <= lstTotalCases.Items.Count - 1; li_cnt++) {
					if (lstTotalCases.GetSelected(li_cnt)) {
						modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorNumberOfCases (IndicatorID, NumberOfCasesDDID) VALUES (" + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmIndicatorSetupCopy.lstIndicators, frmIndicatorSetupCopy.lstIndicators.SelectedIndex) + ", " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstTotalCases, li_cnt) + ")";
						DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

					}
				}
			}


			modGlobal.gv_sql = "DELETE FROM tbl_Setup_IndicatorICDPop WHERE IndicatorID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmIndicatorSetupCopy.lstIndicators, frmIndicatorSetupCopy.lstIndicators.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			if (lstICD.SelectedItems.Count > 0) {
				for (li_cnt = 0; li_cnt <= lstICD.Items.Count - 1; li_cnt++) {
					if (lstICD.GetSelected(li_cnt)) {
						modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorICDPop (IndicatorID, ICDPopDDID) VALUES (" + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmIndicatorSetupCopy.lstIndicators, frmIndicatorSetupCopy.lstIndicators.SelectedIndex) + ", " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstICD, li_cnt) + ")";
						DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

					}
				}
			}

			this.Close();


		}

        private void frmIndicatorEdit_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            var i = 0;
            DataSet thisrs = null;
            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
            modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmIndicatorSetupCopy.lstIndicators, frmIndicatorSetupCopy.lstIndicators.SelectedIndex);
            thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            txtIndicatorDescription.Text = thisrs.rdoColumns["Description"].Value;

            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["JCCode"].Value))
            {
                txtJCCode.Text = thisrs.rdoColumns["JCCode"].Value;
            }
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["CMSCode"].Value))
            {
                txtCMSCode.Text = thisrs.rdoColumns["CMSCode"].Value;
            }

            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["lastupdatedate"].Value))
            {
                txtLastupdateDate.Text = thisrs.rdoColumns["lastupdatedate"].Value;
            }
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["JCAHOID"].Value))
            {
                txtJCAHOID.Text = thisrs.rdoColumns["JCAHOID"].Value;
            }

            //refresh indicator type
            cboIndicatorType.Items.Clear();
            cboIndicatorType.Items.Add("Acute Care");
            cboIndicatorType.Items.Add("Behavioral Health");
            if (thisrs.rdoColumns["IndicatorType"].Value == "AC")
            {
                cboIndicatorType.Text = "Acute Care";
            }
            else if (thisrs.rdoColumns["IndicatorType"].Value == "BH")
            {
                cboIndicatorType.Text = "Behavioral Health";
            }
            //lstIndicatorType.ItemData(lstIndicators.Items.Count-1) = thisrs!IndicatorID

            //refresh Calc. type
            cboCalcType.Items.Clear();
            cboCalcType.Items.Add("Count");
            cboCalcType.Items.Add("Time");
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["CalcType"].Value))
            {
                cboCalcType.Text = thisrs.rdoColumns["CalcType"].Value;
            }

            //refresh Risk Adjusted?
            cboRiskAdjusted.Items.Clear();
            cboRiskAdjusted.Items.Add("Yes");
            // 1
            cboRiskAdjusted.Items.Add("No");
            //0
            if (thisrs.rdoColumns["RiskAdjusted"].Value == 1)
            {
                cboRiskAdjusted.Text = "Yes";
            }
            else if (thisrs.rdoColumns["RiskAdjusted"].Value == 0)
            {
                cboRiskAdjusted.Text = "No";
            }

            //refresh Measure Time By?
            cboMeasureTimeUnit.Items.Clear();
            cboMeasureTimeUnit.Items.Add("Minute");
            cboMeasureTimeUnit.Items.Add("Hour");
            cboMeasureTimeUnit.Items.Add("Day");
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["MeasureTimeBy"].Value))
            {
                cboMeasureTimeUnit.Text = thisrs.rdoColumns["MeasureTimeBy"].Value;
            }

            //refresh Best Practice
            cboBestPractice.Items.Clear();
            cboBestPractice.Items.Add("Good");
            //>
            cboBestPractice.Items.Add("Bad");
            //<
            if (thisrs.rdoColumns["BestPractice"].Value == ">")
            {
                cboBestPractice.Text = "Good";
            }
            else if (thisrs.rdoColumns["BestPractice"].Value == "<")
            {
                cboBestPractice.Text = "Bad";
            }

            //refresh Breakout Type
            cboBreakoutType.Items.Clear();
            cboBreakoutType.Items.Add("");
            cboBreakoutType.Items.Add("Individual");
            cboBreakoutType.Items.Add("Percent");
            cboBreakoutType.Items.Add("Rate");
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["BreakoutType"].Value))
            {
                cboBreakoutType.Text = thisrs.rdoColumns["BreakoutType"].Value;
            }

            //refresh Breakout Type
            cboSPageOrientation.Items.Clear();
            cboSPageOrientation.Items.Add("Portrait");
            cboSPageOrientation.Items.Add("Landscape");
            if (thisrs.rdoColumns["StatewidePageOrientation"].Value == "P")
            {
                cboSPageOrientation.Text = "Portrait";
            }
            else if (thisrs.rdoColumns["StatewidePageOrientation"].Value == "L")
            {
                cboSPageOrientation.Text = "Landscape";
            }

            cboBaseType.Items.Clear();
            cboBaseType.Items.Add("Rate");
            cboBaseType.Items.Add("Ratio");
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["BaseType"].Value))
            {
                cboBaseType.Text = thisrs.rdoColumns["BaseType"].Value;
            }

            cboMeasureDataUsage.Items.Clear();
            cboMeasureDataUsage.Items.Add("Core");
            cboMeasureDataUsage.Items.Add("Non-Core");
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["MeasureDataUsage"].Value))
            {
                cboMeasureDataUsage.Text = thisrs.rdoColumns["MeasureDataUsage"].Value;
            }


            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["Scale"].Value))
            {
                txtScale.Text = thisrs.rdoColumns["Scale"].Value;
            }

            //refresh patient type
            cboPatientType.Items.Clear();
            cboPatientType.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Inpatient", 1));
            cboPatientType.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Outpatient", 2));
            cboPatientType.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Event Date", 3));

            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["PatientType"].Value))
            {
                cboPatientType.SelectedIndex = thisrs.rdoColumns["PatientType"].Value - 1;
            }



            RefreshSubGroups();
            RefreshDateTimeFields();

            //display the Date fields
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["StartDateFieldID"].Value))
            {
                for (i = 0; i <= cboStartDateDDID.Items.Count - 1; i++)
                {
                    if (thisrs.rdoColumns["StartDateFieldID"].Value == Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStartDateDDID, i))
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        cboStartDateDDID.SelectedIndex = i;
                    }
                }
            }
            else
            {
                cboStartDateDDID.Text = "";
                cboStartDateDDID.SelectedIndex = -1;
            }
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["EndDateFieldID"].Value))
            {
                for (i = 0; i <= cboEndDateDDID.Items.Count - 1; i++)
                {
                    if (thisrs.rdoColumns["EndDateFieldID"].Value == Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboEndDateDDID, i))
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["StartTimeFieldID"].Value))
            {
                for (i = 0; i <= cboStartTimeDDID.Items.Count - 1; i++)
                {
                    if (thisrs.rdoColumns["StartTimeFieldID"].Value == Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStartTimeDDID, i))
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        cboStartTimeDDID.SelectedIndex = i;
                    }
                }
            }
            else
            {
                cboStartTimeDDID.Text = "";
                cboStartTimeDDID.SelectedIndex = -1;
            }
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["EndTimeFieldID"].Value))
            {
                for (i = 0; i <= cboEndTimeDDID.Items.Count - 1; i++)
                {
                    if (thisrs.rdoColumns["EndTimeFieldID"].Value == Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboEndTimeDDID, i))
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["ContinuousSGID"].Value))
            {
                for (i = 0; i <= cboContinuousSGID.Items.Count - 1; i++)
                {
                    if (thisrs.rdoColumns["ContinuousSGID"].Value == Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboContinuousSGID, i))
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        cboContinuousSGID.SelectedIndex = i;
                    }
                }
            }
            else
            {
                cboContinuousSGID.Text = "";
                cboContinuousSGID.SelectedIndex = -1;
            }

            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["RiskAdjustSGID"].Value))
            {
                for (i = 0; i <= cboRiskAdjustSGID.Items.Count - 1; i++)
                {
                    if (thisrs.rdoColumns["RiskAdjustSGID"].Value == Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboRiskAdjustSGID, i))
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["CMSSampleFieldDDID"].Value))
            {
                for (i = 0; i <= cboCMSSampleField.Items.Count - 1; i++)
                {
                    if (thisrs.rdoColumns["CMSSampleFieldDDID"].Value == Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboCMSSampleField, i))
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["StartDateTimeFieldID"].Value))
            {
                for (i = 0; i <= cboStartDateTime.Items.Count - 1; i++)
                {
                    if (thisrs.rdoColumns["StartDateTimeFieldID"].Value == Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStartDateTime, i))
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        cboStartDateTime.SelectedIndex = i;
                    }
                }
            }
            else
            {
                cboStartDateTime.Text = "";
                cboStartDateTime.SelectedIndex = -1;
            }

            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["EndDateTimeFieldID"].Value))
            {
                for (i = 0; i <= cboEndDateTime.Items.Count - 1; i++)
                {
                    if (thisrs.rdoColumns["EndDateTimeFieldID"].Value == Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboEndDateTime, i))
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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

            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(thisrs.rdoColumns["appcare"].Value))
            {
                chkAppCare.CheckState = (thisrs.rdoColumns["appcare"].Value ? 1 : 0);
            }
            else
            {
                chkAppCare.CheckState = false;
            }

        }

        private void RefreshNumberofCases()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;

            DataSet rsSelected = null;

            //
            //retrieve the list of Indicators
            //
            modGlobal.gv_sql = "Select * from tbl_setup_DataDef where BaseTableID = 2 ORDER BY FieldName";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //
            //
            //
            modGlobal.gv_sql = "select NumberOfCasesDDID from tbl_Setup_IndicatorNumberOfCases where IndicatorID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmIndicatorSetupCopy.lstIndicators, frmIndicatorSetupCopy.lstIndicators.SelectedIndex);
            rsSelected = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //
            //fill the list box
            //
            lstTotalCases.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Table_ListIndex = -1;
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Table_ListIndex = LIndex;

                lstTotalCases.Items.Add(modGlobal.gv_rs.rdoColumns["FieldName"].Value + " (" + modGlobal.gv_rs.rdoColumns["DDID"].Value + ")");

                //UPGRADE_ISSUE: ListBox property lstTotalCases.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstTotalCases, lstTotalCases.Items.Count-1, modGlobal.gv_rs.rdoColumns["DDID"].Value);
                if (rsSelected.RowCount > 0)
                {
                    rsSelected.MoveFirst();
                    while (!rsSelected.EOF)
                    {
                        if (Strings.Trim(rsSelected.rdoColumns["NumberOfCasesDDID"].Value) == Strings.Trim(modGlobal.gv_rs.rdoColumns["DDID"].Value))
                        {
                            //UPGRADE_ISSUE: ListBox property lstTotalCases.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                            lstTotalCases.SetSelected(lstTotalCases.Items.Count-1, true);
                        }
                        rsSelected.MoveNext();
                    }
                }
                modGlobal.gv_rs.MoveNext();
            }

            rsSelected.Close();

        }

        public void RefreshSubGroups()
		{

			modGlobal.gv_sql = "Select g.*, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " r.GroupRowID, r.Title as GroupRow, r.ShowOnReport as ShowRowonReport, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " c.SubGroupID, c.Title as GroupCol, c.IndicatorID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " c.AggregateFunction, c.showonreport as showcolonreport ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_SubmitGroup as g inner join tbl_Setup_SubmitGroupRow as r";
			modGlobal.gv_sql = modGlobal.gv_sql + " on g.GroupID = r.GroupID)  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_SubmitSubGroup as c ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on r.GroupRowID = c.GroupRowID ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " Where (g.State = '' or g.State is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " Where g.state = '" + modGlobal.gv_State + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " and c.indicatorid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmIndicatorSetupCopy.lstIndicators, frmIndicatorSetupCopy.lstIndicators.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_status)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (g.RecordStatus = '' or g.RecordStatus is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and g.RecordStatus = '" + modGlobal.gv_status + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by g.ordernumber, r.ordernumber, c.ordernumber ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//Display the list of fields
			cboContinuousSGID.Items.Clear();
			cboRiskAdjustSGID.Items.Clear();
			while (!modGlobal.gv_rs.EOF) {
				cboContinuousSGID.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["GroupName"].Value + " / " + modGlobal.gv_rs.rdoColumns["GroupRow"].Value + " / " + modGlobal.gv_rs.rdoColumns["GroupCol"].Value, modGlobal.gv_rs.rdoColumns["SubGroupID"].Value));
				cboRiskAdjustSGID.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["GroupName"].Value + " / " + modGlobal.gv_rs.rdoColumns["GroupRow"].Value + " / " + modGlobal.gv_rs.rdoColumns["GroupCol"].Value, modGlobal.gv_rs.rdoColumns["SubGroupID"].Value));
				modGlobal.gv_rs.MoveNext();
			}

			modGlobal.gv_rs.Close();

		}

		public void RefreshDateTimeFields()
		{
			//retrieve the list of table fields
			modGlobal.gv_sql = "Select dd.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef as dd inner join tbl_setup_TableDef as td ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on dd.basetableid = td.basetableid";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where td.BaseTable = 'PATIENT' ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State = '' or dd.State is Null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State = '' or dd.State is null or dd.State = '" + modGlobal.gv_State + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " and dd.fieldtype = 'Date'";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//Display the list of fields
			cboStartDateDDID.Items.Clear();
			cboEndDateDDID.Items.Clear();
			while (!modGlobal.gv_rs.EOF) {
				cboStartDateDDID.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				cboEndDateDDID.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();

			//retrieve the list of table fields
			modGlobal.gv_sql = "Select dd.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef as dd inner join tbl_setup_TableDef as td ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on dd.basetableid = td.basetableid";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where td.BaseTable = 'PATIENT' ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State = '' or dd.State is Null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State = '' or dd.State is null or dd.State = '" + modGlobal.gv_State + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " and dd.fieldtype = 'Time'";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//Display the list of fields
			cboStartTimeDDID.Items.Clear();
			cboEndTimeDDID.Items.Clear();
			while (!modGlobal.gv_rs.EOF) {
				cboStartTimeDDID.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				cboEndTimeDDID.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();


			//retrieve the list of table fields
			modGlobal.gv_sql = "Select dd.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef as dd inner join tbl_setup_TableDef as td ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on dd.basetableid = td.basetableid";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where td.BaseTable = 'PATIENT' ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State = '' or dd.State is Null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State = '' or dd.State is null or dd.State = '" + modGlobal.gv_State + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " and dd.fieldtype = 'Date/Time'";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			cboStartDateTime.Items.Clear();
			cboEndDateTime.Items.Clear();

			while (!modGlobal.gv_rs.EOF) {
				cboStartDateTime.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));

				cboEndDateTime.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();

		}

		public void RefreshCMSSampleFields()
		{

			//retrieve the list of sample fields
			modGlobal.gv_sql = "Select dd.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef as dd inner join tbl_setup_TableDef as td ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on dd.basetableid = td.basetableid";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where td.BaseTable = 'HOSPITAL STATISTICS' ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State = '' or dd.State is Null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State = '' or dd.State is null or dd.State = '" + modGlobal.gv_State + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " and dd.fieldname like '%SAMPLE%'";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//Display the list of fields
			cboCMSSampleField.Items.Clear();

			while (!modGlobal.gv_rs.EOF) {
				cboCMSSampleField.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();

		}

        private void RefreshICDPopulation()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;

            DataSet rsSelected = null;

            //
            //retrieve the list of Indicators
            //
            modGlobal.gv_sql = "Select * from tbl_setup_DataDef where BaseTableID = 2 ORDER BY FieldName";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //
            //
            //
            modGlobal.gv_sql = "select ICDPopDDID from tbl_Setup_IndicatorICDPop where IndicatorID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmIndicatorSetupCopy.lstIndicators, frmIndicatorSetupCopy.lstIndicators.SelectedIndex);
            rsSelected = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //
            //fill the list box
            //
            lstICD.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Table_ListIndex = -1;
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Table_ListIndex = LIndex;

                lstICD.Items.Add(modGlobal.gv_rs.rdoColumns["FieldName"].Value + " (" + modGlobal.gv_rs.rdoColumns["DDID"].Value + ")");

                //UPGRADE_ISSUE: ListBox property lstICD.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstICD, lstICD.Items.Count-1, modGlobal.gv_rs.rdoColumns["DDID"].Value);
                if (rsSelected.RowCount > 0)
                {
                    rsSelected.MoveFirst();
                    while (!rsSelected.EOF)
                    {
                        if (Strings.Trim(rsSelected.rdoColumns["ICDPopDDID"].Value) == Strings.Trim(modGlobal.gv_rs.rdoColumns["DDID"].Value))
                        {
                            //UPGRADE_ISSUE: ListBox property lstICD.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                            lstICD.SetSelected(lstICD.Items.Count-1, true);
                        }
                        rsSelected.MoveNext();
                    }
                }
                modGlobal.gv_rs.MoveNext();
            }

            rsSelected.Close();

        }

        //Private Sub RefreshAppCareBoxes()
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
    }
}
