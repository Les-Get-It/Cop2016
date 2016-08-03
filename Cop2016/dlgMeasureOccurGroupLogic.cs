using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using static COP2001.RadDropBinder;
using System.Diagnostics;

namespace COP2001
{
    public partial class dlgMeasureOccurGroupLogic : Telerik.WinControls.UI.RadForm
    {
        public dlgMeasureOccurGroupLogic()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboOpt1ValueOperator_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (cboOpt1ValueOperator.Text == "Is Between")
                {
                    lblOpt1IsBetweenMax.Enabled = true;
                    txtOpt1IsBetweenMax.Enabled = true;
                    //    cboJoinOperator = "AND"
                }
                else
                {
                    lblOpt1IsBetweenMax.Enabled = false;
                    txtOpt1IsBetweenMax.Enabled = false;
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

        private void cboOpt3ValueOperator_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (cboOpt3ValueOperator.Text == "Is Between")
                {
                    lblOpt4IsBetweenMax.Enabled = true;
                    txtOpt4IsBetweenMax.Enabled = true;

                    // cboJoinOperator = "AND"
                }
                else
                {
                    lblOpt4IsBetweenMax.Enabled = false;
                    txtOpt4IsBetweenMax.Enabled = false;
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

        private void cmdAdd6_Click(object sender, EventArgs e)
        {
            string ls_add = null;
            //EditCat:
            try
            {
                //LDW ls_add = RadInputBox.Show("Enter a valid value.", "Add Values", "");
                ls_add = RadInputBox.Show("Enter a valid value.", "Add Values", "");

                if (Strings.Len(ls_add) == 0)
                    return;

                lst6Range.Items.Add(ls_add);
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

        private void cmdAddVal_Click(object sender, EventArgs e)
        {
            string ls_add = null;
            var rsIsValid = new DataSet();
            //EditCat:

            try
            {
                ls_add = RadInputBox.Show("Enter a valid month value.", "Add Values", "");

                if (Strings.Len(ls_add) == 0)
                    return;

                // ERROR: Not supported in C#: OnErrorStatement

                modGlobal.gv_sql = string.Format("SELECT MONTH('{0}/1/2000')", ls_add);
                //LDW rsIsValid = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "Temp1";
                rsIsValid = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, rsIsValid);

                int recCount = rsIsValid.Tables[sqlTableName1].Rows.Count;

                for (int i = 0; i < recCount; i++)
                {
                    DataRow dRow = rsIsValid.Tables[sqlTableName1].Rows[i];
                    int rowIndex = rsIsValid.Tables[sqlTableName1].Rows.IndexOf(dRow);
                    if (rowIndex == recCount - 1)
                    {
                        //LDW RadMessageBox.Show("Please Enter A Valid Month", MsgBoxStyle.Critical, "Invalid Month");

                        DialogResult ds1 = RadMessageBox.Show(this, "Please Enter A Valid Month", "Invalid Month", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds1.ToString();
                        //goto EditCat;
                    }
                    else
                    {
                        lstRange.Items.Add(ls_add);
                    }
                }
                rsIsValid.Dispose();
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDel6_Click(object sender, EventArgs e)
        {
            try
            {
                if (lst6Range.SelectedIndex < 0)
                {
                    return;
                }

                lst6Range.Items.RemoveAt((lst6Range.SelectedIndex));
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

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstRange.SelectedIndex < 0)
                {
                    return;
                }

                lstRange.Items.RemoveAt((lstRange.SelectedIndex));
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                //LDW if (sstabOptions.TabPages[0].Enabled == false & sstabOptions.TabPages[1].Enabled == false & sstabOptions.TabPages[2].Enabled == false & sstabOptions.TabPages[3].Enabled == false & sstabOptions.TabPages[4].Enabled == false & sstabOptions.TabPages[5].Enabled == false & sstabOptions.TabPages[6].Enabled == false)
                if (sstabOptions.Enabled == false)
                {
                    //LDW RadMessageBox.Show("Please select a method.");

                    DialogResult ds2 = RadMessageBox.Show(this, "Please select a method.", "Method Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds2.ToString();
                    return;
                }

                if (string.IsNullOrEmpty(Strings.Trim(cboJoinOperator.Text)))
                {
                    //LDW RadMessageBox.Show("Please select the Join Type; the option that defines how to compare the Group Fields to each other.");

                    DialogResult ds3 = RadMessageBox.Show(this, "Please select the Join Type; the option that defines how to compare the Group Fields to each other.",
                        "Join Type Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds3.ToString();
                    return;
                }

                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    if (lstGroupList.SelectedIndex < 0)
                    {
                        //LDW RadMessageBox.Show("Please select a group from the list");

                        DialogResult ds4 = RadMessageBox.Show(this, "Please select a group from the list.", "Group Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds4.ToString();
                        return;
                    }
                }
                else if (TabFirstField.ActiveWindow == TabFirstFieldPatient)
                {
                    if (lstFieldList.SelectedIndex < 0)
                    {
                        //LDW RadMessageBox.Show("Please select field(s) from the list");

                        DialogResult ds5 = RadMessageBox.Show(this, "Please select field(s) from the list.", "Field Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds5.ToString();
                        return;
                    }
                }

                if (sstabOptionsMethod1.ActiveControl.Enabled == true)
                {
                    AddCriteriaWithMethod1();
                }
                else if (sstabOptionsMethod2.ActiveControl.Enabled == true)
                {
                    AddCriteriaWithMethod2();
                }
                else if (sstabOptionsMethod3.ActiveControl.Enabled == true)
                {
                    AddCriteriaWithMethod3();
                }
                else if (sstabOptionsMethod4.ActiveControl.Enabled == true)
                {
                    AddCriteriaWithMethod4();
                }
                else if (sstabOptionsMethod5.ActiveControl.Enabled == true)
                {
                    AddCriteriaWithMethod5();
                }
                else if (sstabOptionsMethod6.ActiveControl.Enabled == true)
                {
                    AddCriteriaWithMethod6();
                }
                else if (sstabOptionsMethod7.ActiveControl.Enabled == true)
                {
                    AddCriteriaWithMethod7();
                }

                return;
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
            //LDW //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void dlgMeasureOccurGroupLogic_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            try
            {
                RefreshMultipleGroupList();

                sstabOptions.ActiveWindow = sstabOptionsMethod1;
                sstabOptionsMethod1.ActiveControl.Enabled = false;
                sstabOptionsMethod2.ActiveControl.Enabled = false;
                sstabOptionsMethod3.ActiveControl.Enabled = false;
                sstabOptionsMethod4.ActiveControl.Enabled = false;
                sstabOptionsMethod5.ActiveControl.Enabled = false;

                Opt1Method.IsChecked = false;
                Opt2Method.IsChecked = false;
                Opt3Method.IsChecked = false;
                Opt4Method.IsChecked = false;
                Opt5Method.IsChecked = false;

                RefreshFieldsList();
                RefreshLookupTables();
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

        private void lstFieldList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshLookupListForThisField();
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

        private void lstGroupList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshLookupListForThisField();
                RefreshCriteriaFieldList();
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

        private void Opt1Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt1Method.IsChecked))
                {
                    if (Opt1Method.IsChecked == true)
                    {
                        sstabOptions.Enabled = true;
                        sstabOptionsMethod1.ActiveControl.Enabled = true;
                        sstabOptionsMethod2.ActiveControl.Enabled = false;
                        sstabOptionsMethod3.ActiveControl.Enabled = false;
                        sstabOptionsMethod4.ActiveControl.Enabled = false;
                        sstabOptionsMethod5.ActiveControl.Enabled = false;
                        sstabOptionsMethod6.ActiveControl.Enabled = false;
                        sstabOptionsMethod7.ActiveControl.Enabled = false;

                        sstabOptions.ActiveWindow = sstabOptionsMethod1;
                    }
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

        private void Opt2Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt2Method.IsChecked))
                {
                    if (Opt2Method.IsChecked == true)
                    {
                        sstabOptions.Enabled = true;
                        sstabOptionsMethod1.ActiveControl.Enabled = false;
                        sstabOptionsMethod2.ActiveControl.Enabled = true;
                        sstabOptionsMethod3.ActiveControl.Enabled = false;
                        sstabOptionsMethod4.ActiveControl.Enabled = false;
                        sstabOptionsMethod5.ActiveControl.Enabled = false;
                        sstabOptionsMethod6.ActiveControl.Enabled = false;
                        sstabOptionsMethod7.ActiveControl.Enabled = false;

                        sstabOptions.ActiveWindow = sstabOptionsMethod2;
                    }
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

        private void Opt3Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt3Method.IsChecked))
                {
                    if (Opt3Method.IsChecked == true)
                    {
                        sstabOptions.Enabled = true;
                        sstabOptionsMethod1.ActiveControl.Enabled = false;
                        sstabOptionsMethod2.ActiveControl.Enabled = false;
                        sstabOptionsMethod3.ActiveControl.Enabled = true;
                        sstabOptionsMethod4.ActiveControl.Enabled = false;
                        sstabOptionsMethod5.ActiveControl.Enabled = false;
                        sstabOptionsMethod6.ActiveControl.Enabled = false;
                        sstabOptionsMethod7.ActiveControl.Enabled = false;

                        sstabOptions.ActiveWindow = sstabOptionsMethod3;
                    }
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

        private void Opt4Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt4Method.IsChecked))
                {
                    if (Opt4Method.IsChecked == true)
                    {
                        sstabOptions.Enabled = true;
                        sstabOptionsMethod1.ActiveControl.Enabled = false;
                        sstabOptionsMethod2.ActiveControl.Enabled = false;
                        sstabOptionsMethod3.ActiveControl.Enabled = false;
                        sstabOptionsMethod4.ActiveControl.Enabled = true;
                        sstabOptionsMethod5.ActiveControl.Enabled = false;
                        sstabOptionsMethod6.ActiveControl.Enabled = false;
                        sstabOptionsMethod7.ActiveControl.Enabled = false;

                        sstabOptions.ActiveWindow = sstabOptionsMethod4;
                    }
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

        private void Opt5Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt5Method.IsChecked))
                {
                    if (Opt5Method.IsChecked == true)
                    {
                        sstabOptions.Enabled = true;
                        sstabOptionsMethod1.ActiveControl.Enabled = false;
                        sstabOptionsMethod2.ActiveControl.Enabled = false;
                        sstabOptionsMethod3.ActiveControl.Enabled = false;
                        sstabOptionsMethod4.ActiveControl.Enabled = false;
                        sstabOptionsMethod5.ActiveControl.Enabled = true;
                        sstabOptionsMethod6.ActiveControl.Enabled = false;
                        sstabOptionsMethod7.ActiveControl.Enabled = false;

                        sstabOptions.ActiveWindow = sstabOptionsMethod5;
                    }
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

        private void Opt6Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt6Method.IsChecked))
                {
                    if (Opt6Method.IsChecked == true)
                    {
                        sstabOptions.Enabled = true;
                        sstabOptionsMethod1.ActiveControl.Enabled = false;
                        sstabOptionsMethod2.ActiveControl.Enabled = false;
                        sstabOptionsMethod3.ActiveControl.Enabled = false;
                        sstabOptionsMethod4.ActiveControl.Enabled = false;
                        sstabOptionsMethod5.ActiveControl.Enabled = false;
                        sstabOptionsMethod6.ActiveControl.Enabled = true;
                        sstabOptionsMethod7.ActiveControl.Enabled = false;

                        sstabOptions.ActiveWindow = sstabOptionsMethod6;
                    }
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

        private void Opt7Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt7Method.IsChecked))
                {
                    if (Opt7Method.IsChecked == true)
                    {
                        sstabOptions.Enabled = true;
                        sstabOptionsMethod1.ActiveControl.Enabled = false;
                        sstabOptionsMethod2.ActiveControl.Enabled = false;
                        sstabOptionsMethod3.ActiveControl.Enabled = false;
                        sstabOptionsMethod4.ActiveControl.Enabled = false;
                        sstabOptionsMethod5.ActiveControl.Enabled = false;
                        sstabOptionsMethod6.ActiveControl.Enabled = false;
                        sstabOptionsMethod7.ActiveControl.Enabled = true;

                        sstabOptions.ActiveWindow = sstabOptionsMethod7;
                        TabFirstField.ActiveWindow = TabFirstFieldGroup;
                    }
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

        private void AddCriteriaWithMethod1()
        {
            string field1type = null;
            string CritTitle = null;
            //Dim li_order as long

            int li_cnt = 0;
            string ls_Dest = null;

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (cboOpt1ValueOperator.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the field operation from the list");

                    DialogResult ds6 = RadMessageBox.Show(this, "Please select the field operation from the list", "Method 1 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds6.ToString();
                    return;
                }

                if (string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & chkBlank.CheckState == 0 & cboDestField.SelectedIndex < 0 & cboDestGroupField.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Define a value, blank, or another field for this criteria type.");

                    DialogResult ds7 = RadMessageBox.Show(this, "Define a value, blank, or another field for this criteria type.", "Method 1 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds7.ToString();
                    return;
                }

                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    li_cnt = lstGroupList.SelectedIndex;

                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = {1})",
                        modGlobal.gv_sql, Support.GetItemData(lstGroupList, li_cnt));

                }
                else if (TabFirstField.ActiveWindow == TabFirstFieldPatient)
                {
                    li_cnt = lstFieldList.SelectedIndex;

                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));

                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);
                field1type = modGlobal.gv_rs.Tables[sqlTableName8].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                if (cboOpt1ValueOperator.Text == "Is Between" & (string.IsNullOrEmpty(txtOpt1TypeinValue.Text) | string.IsNullOrEmpty(txtOpt1IsBetweenMax.Text)))
                {
                    //LDW RadMessageBox.Show("Please enter a min and max for the between logic", MsgBoxStyle.Critical);

                    DialogResult ds8 = RadMessageBox.Show(this, "Please enter a min and max for the between logic.", "Method 1 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds8.ToString();
                    return;
                }

                //make sure that the typed value is of the same type as the field type
                if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & cboOpt1ValueOperator.Text != "Is Between")
                {
                    //If mid(field1type, 1, 3) = "Num" And Not IsNumeric(txtOpt1TypeinValue) Then
                    if (Strings.Mid(field1type, 1, 3) == "Num" & !Information.IsNumeric(txtOpt1TypeinValue.Text) & Strings.UCase(Strings.Trim(txtOpt1TypeinValue.Text)) != "UTD")
                    {
                        //LDW RadMessageBox.Show((lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) + " is a numeric field, but the value is not a number. Please re-Specify...");

                        DialogResult ds9 = RadMessageBox.Show(this, (lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) +
                            " is a numeric field, but the value is not a number. Please re-Specify...", "Method 1 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds9.ToString();
                        return;
                    }

                    if ((Strings.Mid(field1type, 1, 3) == "Dat" | Strings.Mid(field1type, 1, 3) == "Tim") & Strings.UCase(Strings.Trim(txtOpt1TypeinValue.Text)) == "UTD")
                    {
                        //this is OK
                    }
                    else
                    {
                        if (Strings.Mid(field1type, 1, 3) == "Dat" & !Information.IsDate(txtOpt1TypeinValue.Text))
                        {
                            //LDW RadMessageBox.Show((lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) + " is a date field, but the value is not a date. Please re-Specify...");

                            DialogResult ds9 = RadMessageBox.Show(this, (lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) +
                                " is a date field, but the value is not a date. Please re-Specify...", "Method 1 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = ds9.ToString();
                            return;
                        }
                        if (Strings.Mid(field1type, 1, 3) == "Tim" & (Strings.Len(txtOpt1TypeinValue.Text) != 5))
                        {
                            //LDW RadMessageBox.Show((lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");

                            DialogResult ds10 = RadMessageBox.Show(this, (lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) +
                                " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...", "Method 1 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = ds10.ToString();
                            return;
                        }
                        if (Strings.Mid(field1type, 1, 3) == "Tim" & ((!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 1, 1))) |
                            (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 2, 1))) | (Strings.Mid(txtOpt1TypeinValue.Text, 3, 1) != ":") |
                            (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 5, 1)))))
                        {
                            //LDW RadMessageBox.Show((lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");

                            DialogResult ds11 = RadMessageBox.Show(this, (lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) +
                                " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...", "Method 1 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = ds11.ToString();
                            return;
                        }
                        if (Strings.Mid(field1type, 1, 3) == "Tim" & (Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 1, 2)) > 23 | Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 4, 2)) > 59))
                        {
                            //LDW RadMessageBox.Show((lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");

                            DialogResult ds12 = RadMessageBox.Show(this, (lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) +
                                " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...", "Method 1 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = ds12.ToString();
                            return;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & cboOpt1ValueOperator.Text == "Is Between")
                {
                    if (Strings.Mid(field1type, 1, 3) != "Num")
                    {
                        //LDW RadMessageBox.Show((lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) + " is NOT a numeric field, but Between is specified. Please re-Specify...");

                        DialogResult ds13 = RadMessageBox.Show(this, (lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) +
                            " is NOT a numeric field, but Between is specified. Please re-Specify...", "Method 1 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds13.ToString();
                        return;
                    }
                    if (Strings.Mid(field1type, 1, 3) == "Num" & (!Information.IsNumeric(txtOpt1TypeinValue.Text) | !Information.IsNumeric(txtOpt1IsBetweenMax.Text)))
                    {
                        //LDW RadMessageBox.Show((lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) + " is a numeric field, but the value is not a number. Please re-Specify...");

                        DialogResult ds14 = RadMessageBox.Show(this, (lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) +
                            " is a numeric field, but the value is not a number. Please re-Specify...", "Method 1 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds14.ToString();
                        return;
                    }
                }

                modGlobal.gv_Action = "Add";

                CritTitle = (ChkProceed.Checked ? "Only Proceed with Related Fields for " : "");

                if (TabFirstField.ActiveWindow == TabFirstFieldPatient)
                {
                    CritTitle = string.Format("{0}{1} {2}", CritTitle, lstFieldList.Text, cboOpt1ValueOperator.Text);
                }
                else if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    CritTitle = string.Format("{0}{1} ({2}) {3}", CritTitle, Support.GetItemString(lstGroupList, li_cnt),
                        cboJoinOperator.Text, cboOpt1ValueOperator.Text);
                }

                if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                {
                    CritTitle = string.Format("{0} ({1}", CritTitle, txtOpt1TypeinValue.Text);
                    if (!string.IsNullOrEmpty(txtOpt1IsBetweenMax.Text))
                    {
                        CritTitle = string.Format("{0} AND {1}", CritTitle, txtOpt1IsBetweenMax.Text);
                    }
                    CritTitle = CritTitle + ") ";
                }

                if (chkBlank.CheckState == CheckState.Checked)
                {

                    CritTitle = string.Format("{0} {1}Blank", CritTitle, chkUTD.CheckState == CheckState.Checked ? "(" : "");
                    if (chkUTD.CheckState == CheckState.Checked)
                    {
                        CritTitle = CritTitle + " OR UTD) ";
                    }
                }

                ls_Dest = (cboDestField.SelectedIndex > -1 ? cboDestField.Text : (cboDestField.SelectedIndex > -1 ? string.Format("{0} ({1}) ", cboDestGroupField.Text, cboJoinOperator.Text) : ""));

                if (Strings.Len(ls_Dest) > 0)
                {
                    CritTitle = string.Format("{0} {1}", CritTitle, ls_Dest);
                }

                modGlobal.gv_sql = "Insert into tbl_Setup_MeasureFieldGroupLogic ";
                modGlobal.gv_sql = modGlobal.gv_sql + "(";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldID1, FieldID1IsGroup, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " DestDDID, DestDDIDIsGroup, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, FieldValueMax, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, OnlyProceedWithRelatedFieldGroup) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);

                if (TabFirstField.ActiveWindow == TabFirstFieldPatient)
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, 0,", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                }
                else if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, 1,", modGlobal.gv_sql, Support.GetItemData(lstGroupList, li_cnt));
                }

                if (cboDestField.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, 0,", modGlobal.gv_sql, Support.GetItemData(cboDestField, cboDestField.SelectedIndex));
                }
                else if (cboDestGroupField.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, 1,", modGlobal.gv_sql, Support.GetItemData(cboDestGroupField, cboDestGroupField.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null,0,";
                }

                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt1ValueOperator.Text);

                if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                {
                    modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, txtOpt1TypeinValue.Text);
                }
                else if (cboDestField.SelectedIndex > -1 | cboDestGroupField.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Null&UTD',";
                }

                if (cboOpt1ValueOperator.Text == "Is Between")
                {
                    modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, txtOpt1IsBetweenMax.Text);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
                }

                modGlobal.gv_sql = string.Format("{0}'{1}',{2})", modGlobal.gv_sql, cboJoinOperator.Text, ChkProceed.Checked ? 1 : 0);

                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                this.Close();
                return;
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
            //LDW //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void AddCriteriaWithMethod2()
        {
            string fieldLookupTableID = null;
            string IDFromLookup = null;
            string field1type = null;
            string CritTitle = null;
            int li_cnt = 0;
            int lL_LookupVal = 0;
            string ls_LookupTxt = null;
            int Index = 0;

            DataSet rs_Temp = new DataSet();

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (cboOpt2ValueOperator.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the field operation from the list");

                    DialogResult ds15 = RadMessageBox.Show(this, "Please select the field operation from the list", "Method 2 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds15.ToString();
                    return;
                }

                fieldLookupTableID = " Null ";
                if (cboLookupValues.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Select lookup value from list.");

                    DialogResult ds16 = RadMessageBox.Show(this, "Select lookup value from list.", "Method 2 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds16.ToString();
                    return;
                }
                else
                {
                    modGlobal.gv_sql = "Select *   ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_setup_Misclookuplist  ";
                    modGlobal.gv_sql = string.Format("{0} Where lookupid = {1}", modGlobal.gv_sql, Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName9 = "tbl_setup_Misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                    modGlobal.gv_sql = "SELECT CompareToDesc from tbl_Setup_TableDef WHERE BaseTableID = " + modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["basetableid"];
                    //LDW rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName10 = "tbl_Setup_TableDef";
                    rs_Temp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, rs_Temp);

                    if (Information.IsDBNull(rs_Temp.Tables[sqlTableName10].Rows[0]["CompareToDesc"]))
                    {
                        //LDW IDFromLookup = modGlobal.gv_rs.rdoColumns["Id"].Value;
                        IDFromLookup = modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["Id"].ToString();
                    }
                    else
                    {
                        //LDW IDFromLookup = modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value;
                        IDFromLookup = modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["FIELDVALUE"].ToString();
                    }
                    rs_Temp.Dispose();
                    rs_Temp = null;

                    modGlobal.gv_rs.Dispose();
                }

                if (string.IsNullOrEmpty(cboJoinOperator.Text))
                {
                    //LDW RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");

                    DialogResult ds17 = RadMessageBox.Show(this, "Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.",
                        "Method 2 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds17.ToString();
                    return;
                }

                ls_LookupTxt = cboLookupValues.Text;
                lL_LookupVal = Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex);

                //Loop for each selected field
                // For li_cnt = 0 To lstGroupList.ListCount - 1
                //      If lstGroupList.Selected(li_cnt) Then
                const string sqlTableName11 = "tbl_setup_Datadef";
                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    li_cnt = lstGroupList.SelectedIndex;

                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = {1})",
                        modGlobal.gv_sql, Support.GetItemData(lstGroupList, li_cnt));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);
                }
                else if (TabFirstField.ActiveWindow == TabFirstFieldPatient)
                {
                    li_cnt = lstFieldList.SelectedIndex;

                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);
                }

                field1type = modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                //make sure that the field type is not a date field
                if (Strings.Mid(field1type, 1, 3) == "Dat")
                {
                    //LDW RadMessageBox.Show("You cannot compare this field to a lookup value, because " + (TabFirstField.ActiveWindow == TabFirstFieldGroup ? Support.GetItemString(lstGroupList, li_cnt) : Support.GetItemString(lstFieldList, li_cnt)) + " is a date field. Please re-Specify...");

                    DialogResult ds18 = RadMessageBox.Show(this, string.Format("You cannot compare this field to a lookup value, because {0} is a date field. Please re-Specify...",
                        TabFirstField.ActiveWindow == TabFirstFieldGroup ? Support.GetItemString(lstGroupList, li_cnt) :
                        Support.GetItemString(lstFieldList, li_cnt)),
                        "Method 2 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds18.ToString();
                    return;
                }

                modGlobal.gv_Action = "Add";

                CritTitle = (ChkProceed.Checked ? "Only Proceed with Related Fields for " : "");

                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    CritTitle = string.Format("{0}{1} ({2}) {3} {4}", CritTitle, Support.GetItemString(lstGroupList, li_cnt),
                        cboJoinOperator.Text, cboOpt2ValueOperator.Text, ls_LookupTxt);
                }
                else
                {
                    CritTitle = string.Format("{0}{1} {2} {3}", CritTitle, Support.GetItemString(lstFieldList, li_cnt), cboOpt2ValueOperator.Text, ls_LookupTxt);
                }

                modGlobal.gv_sql = "Insert into tbl_Setup_MeasureFieldGroupLogic ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldID1, FieldID1IsGroup, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, OnlyProceedWithRelatedFieldGroup)";

                modGlobal.gv_sql = modGlobal.gv_sql + " values (";

                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);

                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, 1,", modGlobal.gv_sql, Support.GetItemData(lstGroupList, li_cnt));
                }
                else if (TabFirstField.ActiveWindow == TabFirstFieldPatient)
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, 0,", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                }

                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt2ValueOperator.Text);
                modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, IDFromLookup);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, lL_LookupVal);
                modGlobal.gv_sql = string.Format("{0} '{1}',{2})", modGlobal.gv_sql, cboJoinOperator.Text, ChkProceed.Checked ? 1 : 0);

                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                //        lstGroupList.Selected(li_cnt) = False
                //    End If
                //Next

                this.Close();
                return;
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
            //LDW //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void AddCriteriaWithMethod3()
        {
            string field1type = null;
            string CritTitle = null;
            int li_CriteriaSetID = 0;
            int li_cnt = 0;
            string ls_LookupTxt = null;
            int li_LookupVal = 0;


            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (cboOpLkTable.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the field operation from the list");

                    DialogResult ds19 = RadMessageBox.Show(this, "Please select the field operation from the list.", "Method 3 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds19.ToString();
                    return;
                }

                if (cboLookupTables.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Select lookup table from list.");

                    DialogResult ds20 = RadMessageBox.Show(this, "Select lookup table from list.", "Method 3 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds20.ToString();
                    return;
                }

                if (string.IsNullOrEmpty(cboJoinOperator.Text))
                {
                    //LDW RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");

                    DialogResult ds21 = RadMessageBox.Show(this, "Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.",
                        "Method 3 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds21.ToString();
                    return;
                }

                ls_LookupTxt = cboLookupTables.Text;
                li_LookupVal = Support.GetItemData(cboLookupTables, cboLookupTables.SelectedIndex);

                //Loop for each selected field
                //For li_cnt = 0 To lstGroupList.ListCount - 1
                //     If lstGroupList.Selected(li_cnt) Then

                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    li_cnt = lstGroupList.SelectedIndex;

                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = {1})",
                        modGlobal.gv_sql, Support.GetItemData(lstGroupList, li_cnt));
                }
                else
                {
                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName12 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName12].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                //make sure that the field type is not a date field
                if (Strings.Mid(field1type, 1, 3) == "Dat")
                {
                    //LDW RadMessageBox.Show("You cannot compare " + (TabFirstField.ActiveWindow == TabFirstFieldGroup ? Support.GetItemString(lstGroupList, li_cnt) : Support.GetItemString(lstFieldList, li_cnt)) + " to a lookup table, because the selected field is a date field. Please re-Specify...");

                    DialogResult ds22 = RadMessageBox.Show(this, string.Format("You cannot compare {0} to a lookup table, because the selected field is a date field. Please re-Specify...",
                        TabFirstField.ActiveWindow == TabFirstFieldGroup ? Support.GetItemString(lstGroupList, li_cnt) :
                        Support.GetItemString(lstFieldList, li_cnt)),
                        "Method 3 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds22.ToString();
                    return;
                }

                modGlobal.gv_Action = "Add";

                CritTitle = (ChkProceed.Checked ? "Only Proceed with Related Fields for " : "");

                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    CritTitle = string.Format("{0}{1} ({2})  {3} [{4}] Lookup Table ", CritTitle, Support.GetItemString(lstGroupList, li_cnt),
                        cboJoinOperator.Text, cboOpLkTable.Text, ls_LookupTxt);

                }
                else
                {
                    CritTitle = string.Format("{0}{1} {2} [{3}] Lookup Table ", CritTitle, Support.GetItemString(lstFieldList, li_cnt),
                        cboOpLkTable.Text, ls_LookupTxt);
                }

                modGlobal.gv_sql = "Insert into tbl_Setup_MeasureFieldGroupLogic ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldID1, FieldID1IsGroup, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator,OnlyProceedWithRelatedFieldGroup)";

                modGlobal.gv_sql = modGlobal.gv_sql + " values (";

                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);

                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, 1, ", modGlobal.gv_sql, Support.GetItemData(lstGroupList, li_cnt));
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, 0, ", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                }

                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpLkTable.Text);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_LookupVal);
                modGlobal.gv_sql = string.Format("{0} '{1}',{2})", modGlobal.gv_sql, cboJoinOperator.Text, ChkProceed.Checked ? 1 : 0);

                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                this.Close();
                return;
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
            //LDW //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void AddCriteriaWithMethod4()
        {
            string field1type = null;
            string Field2Type = null;
            string CritTitle = null;
            //Dim li_order as long
            int li_CriteriaSetID = 0;
            int li_cnt = 0;


            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (cboFieldOperator.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the Add/Subtract operation from the list.");

                    DialogResult ds23 = RadMessageBox.Show(this, "Please select the Add/Subtract operation from the list.",
                        "Method 4 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds23.ToString();
                    return;
                }

                if (cboField2List.SelectedIndex < 0 & cboField2GroupList.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the second Field from the list.");

                    DialogResult ds24 = RadMessageBox.Show(this, "Please select the second Field from the list.",
                        "Method 4 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds24.ToString();
                    return;
                }

                if (cboOpt3ValueOperator.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the field operation from the list.");

                    DialogResult ds25 = RadMessageBox.Show(this, "Please select the field operation from the list.",
                        "Method 4 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds25.ToString();
                    return;
                }

                if (string.IsNullOrEmpty(txtOpt3TypeinValue.Text))
                {
                    //LDW RadMessageBox.Show("A value should be typed in.");

                    DialogResult ds26 = RadMessageBox.Show(this, "A value should be typed in.",
                        "Method 4 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds26.ToString();
                    return;
                }

                if (cboOpt3ValueOperator.Text == "Is Between" & string.IsNullOrEmpty(txtOpt4IsBetweenMax.Text))
                {
                    //LDW RadMessageBox.Show("A value should be typed into the max field.");

                    DialogResult ds27 = RadMessageBox.Show(this, "A value should be typed into the max field.",
                        "Method 4 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds27.ToString();
                    return;
                }

                if (string.IsNullOrEmpty(cboJoinOperator.Text))
                {
                    //LDW RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");

                    DialogResult ds28 = RadMessageBox.Show(this, "Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.",
                        "Method 4 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds28.ToString();
                    return;
                }

                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    li_cnt = lstGroupList.SelectedIndex;

                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = {1})",
                        modGlobal.gv_sql, Support.GetItemData(lstGroupList, li_cnt));
                }
                else
                {
                    li_cnt = lstFieldList.SelectedIndex;

                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                }

                //Loop for each selected field
                // For li_cnt = 0 To lstGroupList.ListCount - 1
                //      If lstGroupList.Selected(li_cnt) Then

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName13 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName13].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                //make sure that the 2 selected fields are of the same type
                if (!string.IsNullOrEmpty(cboField2List.Text))
                {
                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(cboField2List, cboField2List.SelectedIndex));

                }
                else if (!string.IsNullOrEmpty(cboField2GroupList.Text))
                {
                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = {1})",
                        modGlobal.gv_sql, Support.GetItemData(cboField2GroupList, cboField2GroupList.SelectedIndex));
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName14 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, modGlobal.gv_rs);

                Field2Type = modGlobal.gv_rs.Tables[sqlTableName14].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                if (field1type != Field2Type)
                {
                    //LDW RadMessageBox.Show("The 2 fields that you have selected are not of the same type. Please re-specify...");

                    DialogResult ds29 = RadMessageBox.Show(this, "The 2 fields that you have selected are not of the same type. Please re-specify...",
                        "Method 4 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds29.ToString();
                    return;
                }

                //make sure that the typed value is numeric
                if (!Information.IsNumeric(txtOpt3TypeinValue.Text))
                {
                    //LDW RadMessageBox.Show("The typed value has to be a numeric value. Please re-Specify...");

                    DialogResult ds30 = RadMessageBox.Show(this, "The typed value has to be a numeric value. Please re-specify...",
                        "Method 4 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds30.ToString();
                    return;
                }

                if (cboOpt3ValueOperator.Text == "Is Between" & !Information.IsNumeric(txtOpt4IsBetweenMax.Text))
                {
                    //LDW RadMessageBox.Show("The max value has to be a numeric value. Please re-Specify...");

                    DialogResult ds31 = RadMessageBox.Show(this, "The max value has to be a numeric value. Please re-Specify...",
                        "Method 4 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds31.ToString();
                    return;
                }

                if (field1type == "Date")
                {
                    if (string.IsNullOrEmpty(cboOpt3Unit.Text))
                    {
                        //LDW RadMessageBox.Show("Please define a date unit associated with the value");

                        DialogResult ds32 = RadMessageBox.Show(this, "Please define a date unit associated with the value",
                            "Method 4 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds32.ToString();
                        return;
                    }
                    else if (cboOpt3Unit.Text != "Years" & cboOpt3Unit.Text != "Months" & cboOpt3Unit.Text != "Days")
                    {
                        //LDW RadMessageBox.Show("Please define the appropriate date unit associated with the value");

                        DialogResult ds33 = RadMessageBox.Show(this, "Please define the appropriate date unit associated with the value",
                            "Method 4 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds33.ToString();
                        return;
                    }
                }

                if (field1type == "Time")
                {
                    if (string.IsNullOrEmpty(cboOpt3Unit.Text))
                    {
                        //LDW RadMessageBox.Show("Please define a time unit associated with the value");

                        DialogResult ds34 = RadMessageBox.Show(this, "Please define a time unit associated with the value",
                            "Method 4 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds34.ToString();
                        return;
                    }
                    else if (cboOpt3Unit.Text != "Hours" & cboOpt3Unit.Text != "Minutes" & cboOpt3Unit.Text != "Seconds")
                    {
                        //LDW RadMessageBox.Show("Please define the appropriate time unit associated with the value");

                        DialogResult ds35 = RadMessageBox.Show(this, "Please define the appropriate time unit associated with the value",
                            "Method 4 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds35.ToString();
                        return;
                    }
                }

                if (field1type == "Time" & !Information.IsNumeric(txtOpt3TypeinValue.Text))
                {
                    //LDW RadMessageBox.Show("Please define a numeric value for this Time difference. Duration will be in minutes  ");

                    DialogResult ds36 = RadMessageBox.Show(this, "Please define a numeric value for this Time difference. Duration will be in minutes...",
                        "Method 4 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds36.ToString();
                    return;
                }

                modGlobal.gv_Action = "Add";

                CritTitle = (ChkProceed.Checked ? "Only Proceed with Related Fields for " : "");

                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    CritTitle = string.Format("{0}{1} ({2}) ", CritTitle, Support.GetItemString(lstGroupList, li_cnt), cboJoinOperator.Text);
                }
                else if (TabFirstField.ActiveWindow == TabFirstFieldPatient)
                {
                    CritTitle = CritTitle + Support.GetItemString(lstFieldList, li_cnt);
                }

                CritTitle = string.Format("{0} {1} ", CritTitle, cboFieldOperator.Text);
                CritTitle = CritTitle + (cboField2List.SelectedIndex > -1 ? cboField2List.Text : string.Format("{0} ({1}) ", cboField2GroupList.Text, cboJoinOperator.Text));
                CritTitle = string.Format("{0} {1}", CritTitle, cboOpt3ValueOperator.Text);

                if (cboOpt3ValueOperator.Text == "Is Between")
                {
                    CritTitle = string.Format("{0} ({1} AND {2}) ", CritTitle, txtOpt3TypeinValue.Text, txtOpt4IsBetweenMax.Text);
                }
                else
                {
                    CritTitle = string.Format("{0} {1}", CritTitle, txtOpt3TypeinValue.Text);
                }

                if (field1type == "Date" | field1type == "Time")
                {
                    CritTitle = string.Format("{0} {1}", CritTitle, cboOpt3Unit.Text);
                }

                modGlobal.gv_sql = "Insert into tbl_Setup_MeasureFieldGroupLogic ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldID1, FieldID1IsGroup, ValueOperator, FieldValue, FieldValueMax, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldID2, FieldID2IsGroup, FieldOperator, DateUnit, JoinOperator,OnlyProceedWithRelatedFieldGroup)";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);

                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, 1, ", modGlobal.gv_sql, Support.GetItemData(lstGroupList, li_cnt));
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, 0, ", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                }

                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt3ValueOperator.Text);
                modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, txtOpt3TypeinValue.Text);

                if (cboOpt3ValueOperator.Text == "Is Between")
                {
                    modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, txtOpt4IsBetweenMax.Text);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                }

                if (cboField2List.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0}{1},0, ", modGlobal.gv_sql, Support.GetItemData(cboField2List, cboField2List.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0}{1},1, ", modGlobal.gv_sql, Support.GetItemData(cboField2GroupList, cboField2GroupList.SelectedIndex));
                }

                modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, cboFieldOperator.Text);
                if (!string.IsNullOrEmpty(cboOpt3Unit.Text))
                {
                    switch (cboOpt3Unit.Text)
                    {
                        case "Years":
                            modGlobal.gv_sql = modGlobal.gv_sql + " 'YYYY',";
                            break;
                        case "Months":
                            modGlobal.gv_sql = modGlobal.gv_sql + " 'm',";
                            break;
                        case "Days":
                            modGlobal.gv_sql = modGlobal.gv_sql + " 'd',";
                            break;
                        case "Hours":
                            modGlobal.gv_sql = modGlobal.gv_sql + " 'h',";
                            break;
                        case "Minutes":
                            modGlobal.gv_sql = modGlobal.gv_sql + " 'n',";
                            break;
                        case "Seconds":
                            modGlobal.gv_sql = modGlobal.gv_sql + " 's',";
                            break;
                    }
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                }
                modGlobal.gv_sql = string.Format("{0}'{1}',{2})", modGlobal.gv_sql, cboJoinOperator.Text, ChkProceed.Checked ? 1 : 0);

                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //    End If
                //Next

                this.Close();
                return;
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
            //LDW //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void AddCriteriaWithMethod5()
        {
            string field1type = null;
            string Field2Type = null;
            string CritTitle = null;
            //Dim li_order as long
            int li_CriteriaSetID = 0;
            int li_cnt = 0;
            int li_cnt2 = 0;
            string[] ls_months = null;


            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (cboOpt5ValueOperator.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the field operation from the list.");

                    DialogResult ds37 = RadMessageBox.Show(this, "Please select the field operation from the list.",
                        "Method 5 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds37.ToString();
                    return;
                }

                if (lstRange.Items.Count == 0)
                {
                    //LDW RadMessageBox.Show("Value(s) should be typed in.");

                    DialogResult ds38 = RadMessageBox.Show(this, "Value(s) should be typed in.",
                        "Method 5 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds38.ToString();
                    return;
                }


                //Loop for each selected field
                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    li_cnt = lstGroupList.SelectedIndex;
                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = {1})",
                        modGlobal.gv_sql, Support.GetItemData(lstGroupList, li_cnt));
                }
                else
                {
                    li_cnt = lstFieldList.SelectedIndex;

                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));

                }
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName15 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName15, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName15].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                if (field1type != "Date")
                {
                    //LDW RadMessageBox.Show("This method is only valid with date fields", MsgBoxStyle.Critical, "Field is not a date");

                    DialogResult ds39 = RadMessageBox.Show(this, "This method is only valid with date fields",
                        "Field is not a date", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds39.ToString();
                    return;
                }

                for (li_cnt2 = 0; li_cnt2 <= lstRange.Items.Count - 1; li_cnt2++)
                {
                    Array.Resize(ref ls_months, li_cnt2 + 1);
                    ls_months[li_cnt2] = Support.GetItemString(lstRange, li_cnt2);
                }

                modGlobal.gv_Action = "Add";

                CritTitle = (ChkProceed.Checked ? "Only Proceed with Related Fields for " : "");


                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    CritTitle = string.Format("{0}{1} ({2}) ", CritTitle, Support.GetItemString(lstGroupList, li_cnt), cboJoinOperator.Text);
                }
                else
                {
                    CritTitle = string.Format("{0}{1} ({2}) ", CritTitle, Support.GetItemString(lstFieldList, li_cnt), cboJoinOperator.Text);
                }

                CritTitle = string.Format("{0} Month {1}", CritTitle, cboOpt5ValueOperator.Text);
                CritTitle = string.Format("{0} ({1})", CritTitle, Strings.Join(ls_months, ","));


                modGlobal.gv_sql = "Insert into tbl_Setup_MeasureFieldGroupLogic ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldID1, FieldID1IsGroup, ValueOperator, FieldValue, DateUnit, JoinOperator, OnlyProceedWithRelatedFieldGroup)";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);

                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, 1, ", modGlobal.gv_sql, Support.GetItemData(lstGroupList, li_cnt));
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, 0, ", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                }

                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt5ValueOperator.Text);
                modGlobal.gv_sql = string.Format("{0} '({1})',", modGlobal.gv_sql, Strings.Join(ls_months, ","));
                modGlobal.gv_sql = modGlobal.gv_sql + " 'm',";
                modGlobal.gv_sql = string.Format("{0}'{1}',{2})", modGlobal.gv_sql, cboJoinOperator.Text, ChkProceed.Checked ? 1 : 0);

                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                this.Close();
                return;
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
            //LDW //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void AddCriteriaWithMethod6()
        {
            string field1type = null;
            string Field2Type = null;
            string CritTitle = null;
            //Dim li_order as long
            int li_CriteriaSetID = 0;
            int li_cnt = 0;
            int li_cnt2 = 0;
            string[] ls_Value = null;


            try
            {
                // ERROR: Not supported in C#: OnErrorStatement
                if (cboOpt6ValueOperator.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the field operation from the list.");

                    DialogResult ds40 = RadMessageBox.Show(this, "Please select the field operation from the list.",
                        "Method 6 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds40.ToString();
                    return;
                }

                if (lst6Range.Items.Count == 0)
                {
                    //LDW RadMessageBox.Show("Value(s) should be typed in.");

                    DialogResult ds41 = RadMessageBox.Show(this, "Value(s) should be typed in.",
                        "Method 6 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds41.ToString();
                    return;
                }

                //Loop for each selected field
                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    li_cnt = lstGroupList.SelectedIndex;
                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = {1})",
                        modGlobal.gv_sql, Support.GetItemData(lstGroupList, li_cnt));
                }
                else
                {
                    li_cnt = lstFieldList.SelectedIndex;

                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                }
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName16 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName16, modGlobal.gv_rs);


                field1type = modGlobal.gv_rs.Tables[sqlTableName16].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                if (field1type != "Number" & field1type != "Text")
                {
                    //LDW RadMessageBox.Show("This method is only valid with number or text fields", MsgBoxStyle.Critical, "Field is not a number or text");

                    DialogResult ds42 = RadMessageBox.Show(this, "This method is only valid with number or text fields",
                        "Field is not a number or text.", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds42.ToString();
                    return;
                }

                for (li_cnt2 = 0; li_cnt2 <= lst6Range.Items.Count - 1; li_cnt2++)
                {
                    Array.Resize(ref ls_Value, li_cnt2 + 1);

                    ls_Value[li_cnt2] = Support.GetItemString(lst6Range, li_cnt2);
                }

                modGlobal.gv_Action = "Add";

                CritTitle = (ChkProceed.Checked ? "Only Proceed with Related Fields for " : "");


                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    CritTitle = string.Format("{0}{1} ({2}) ", CritTitle, Support.GetItemString(lstGroupList, li_cnt), cboJoinOperator.Text);
                }
                else
                {
                    CritTitle = string.Format("{0}{1} ({2}) ", CritTitle, Support.GetItemString(lstFieldList, li_cnt), cboJoinOperator.Text);
                }

                CritTitle = string.Format("{0} {1}", CritTitle, cboOpt6ValueOperator.Text);

                CritTitle = string.Format("{0} ({1})", CritTitle, Strings.Join(ls_Value, ","));


                modGlobal.gv_sql = "Insert into tbl_Setup_MeasureFieldGroupLogic ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldID1, FieldID1IsGroup, ValueOperator, FieldValue, JoinOperator, OnlyProceedWithRelatedFieldGroup)";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);

                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, 1, ", modGlobal.gv_sql, Support.GetItemData(lstGroupList, li_cnt));
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, 0, ", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                }

                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt6ValueOperator.Text);
                modGlobal.gv_sql = string.Format("{0} '({1})',", modGlobal.gv_sql, Strings.Join(ls_Value, ","));
                modGlobal.gv_sql = string.Format("{0}'{1}',{2})", modGlobal.gv_sql, cboJoinOperator.Text, ChkProceed.Checked ? 1 : 0);

                //   Debug.Print gv_sql
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                this.Close();
                return;
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
            //LDW //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void AddCriteriaWithMethod7()
        {
            string field1type = null;
            string CritTitle = null;
            //Dim li_order as long

            int li_cnt = lstGroupList.SelectedIndex;
            string ls_Dest = null;

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (cboOpt7ValueOperator.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the field operation from the list");

                    DialogResult ds43 = RadMessageBox.Show(this, "Please select the field operation from the list",
                        "Method 7 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds43.ToString();
                    return;
                }

                if (chkOpt7Blank.CheckState == 0 & chkMethod7UTD.CheckState == 0)
                {
                    //LDW RadMessageBox.Show("Define a value, blank, UTD, or another field for this criteria type.");

                    DialogResult ds44 = RadMessageBox.Show(this, "Define a value, blank, UTD, or another field for this criteria type.",
                        "Method 7 Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds44.ToString();
                    return;
                }

                //find the field type
                modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = {1})",
                    modGlobal.gv_sql, Support.GetItemData(lstGroupList, li_cnt));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName17 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName17, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName17].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();


                modGlobal.gv_Action = "Add";

                CritTitle = "Earliest (" + (ChkProceed.Checked ? "Only Proceed with Related Fields for " : "");
                CritTitle = string.Format("{0}{1} ({2})) {3}", CritTitle, Support.GetItemString(lstGroupList, li_cnt),
                    cboJoinOperator.Text, cboOpt7ValueOperator.Text);

                if (chkOpt7Blank.CheckState == CheckState.Checked & chkMethod7UTD.CheckState == 0)
                {
                    CritTitle = CritTitle + " Blank";
                }
                else if (chkOpt7Blank.CheckState == 0 & chkMethod7UTD.CheckState == CheckState.Checked)
                {
                    CritTitle = CritTitle + " UTD";
                }
                else if (chkOpt7Blank.CheckState == CheckState.Checked & chkMethod7UTD.CheckState == CheckState.Checked)
                {
                    CritTitle = CritTitle + " (Blank OR UTD)";
                }


                modGlobal.gv_sql = "Insert into tbl_Setup_MeasureFieldGroupLogic ";
                modGlobal.gv_sql = modGlobal.gv_sql + "(";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldID2, FieldID2IsGroup, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, OnlyProceedWithRelatedFieldGroup) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                modGlobal.gv_sql = string.Format("{0}{1}, 1,", modGlobal.gv_sql, Support.GetItemData(lstGroupList, li_cnt));
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt7ValueOperator.Text);

                if (chkOpt7Blank.CheckState == CheckState.Checked & chkMethod7UTD.CheckState == 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Null',";
                }
                else if (chkOpt7Blank.CheckState == 0 & chkMethod7UTD.CheckState == CheckState.Checked)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'UTD',";
                }
                else if (chkOpt7Blank.CheckState == CheckState.Checked & chkMethod7UTD.CheckState == CheckState.Checked)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Null&UTD',";
                }

                modGlobal.gv_sql = string.Format("{0}'{1}',{2})", modGlobal.gv_sql, cboJoinOperator.Text, ChkProceed.Checked ? 1 : 0);

                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                this.Close();
                return;
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
            //LDW //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void RefreshMultipleGroupList()
        {
            List<Item> itemslstGroupList = new List<Item>();
            List<Item> itemscboField2GroupList = new List<Item>();
            List<Item> itemscboDestGroupField = new List<Item>();


            try
            {
                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_FieldGroup";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_Setup_FieldGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);
                lstGroupList.Items.Clear();
                cboField2GroupList.Items.Clear();
                cboDestGroupField.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    itemslstGroupList.Add(new Item(myRow2.Field<int>("FIELDGroupID"), myRow2.Field<string>("FIELDGROUPNAME")));
                    itemscboField2GroupList.Add(new Item(myRow2.Field<int>("FIELDGroupID"), myRow2.Field<string>("FIELDGROUPNAME")));
                    itemscboDestGroupField.Add(new Item(myRow2.Field<int>("FIELDGroupID"), myRow2.Field<string>("FIELDGROUPNAME")));


                    //lstGroupList.Items.Add(new ListBoxItem(myRow2.Field<string>("FIELDGROUPNAME"), myRow2.Field<int>("FIELDGroupID")).ToString());

                    //cboField2GroupList.Items.Add(new ListBoxItem(myRow2.Field<string>("FIELDGROUPNAME"), myRow2.Field<int>("FIELDGroupID")).ToString());

                    //cboDestGroupField.Items.Add(new ListBoxItem(myRow2.Field<string>("FIELDGROUPNAME"), myRow2.Field<int>("FIELDGroupID")).ToString());

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                //LDW populate drop downs
                this.lstGroupList.DataSource = itemslstGroupList;
                this.lstGroupList.DisplayMember = "Description";
                this.lstGroupList.ValueMember = "Id";

                this.cboField2GroupList.DataSource = itemscboField2GroupList;
                this.cboField2GroupList.DisplayMember = "Description";
                this.cboField2GroupList.ValueMember = "Id";

                this.cboDestGroupField.DataSource = itemscboDestGroupField;
                this.cboDestGroupField.DisplayMember = "Description";
                this.cboDestGroupField.ValueMember = "Id";

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


        private void RefreshLookupTables()
        {
            List<Item> itemscboLookupTables = new List<Item>();
            // ERROR: Not supported in C#: OnErrorStatement


            try
            {
                modGlobal.gv_sql = "Select * From tbl_Setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Where TableType = 'LOOKUP' ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName18 = "tbl_Setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName18, modGlobal.gv_rs);

                cboLookupTables.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow5 in modGlobal.gv_rs.Tables[sqlTableName18].Rows)
                {
                    itemscboLookupTables.Add(new Item(myRow5.Field<int>("basetableid"), myRow5.Field<string>("BaseTable")));

                    //cboLookupTables.Items.Add(new ListBoxItem(myRow5.Field<string>("BaseTable"), myRow5.Field<int>("basetableid")).ToString());

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                //LDW populate dropdown
                this.cboLookupTables.DataSource = itemscboLookupTables;
                this.cboLookupTables.DisplayMember = "Description";
                this.cboLookupTables.ValueMember = "Id";

                return;
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
            //LDW //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void RefreshLookupListForThisField()
        {
            string LookupTableID = null;
            List<Item> itemscboLookupValues = new List<Item>();

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                cboLookupValues.Items.Clear();

                if (TabFirstField.ActiveWindow == TabFirstFieldGroup)
                {

                    if (lstGroupList.SelectedItems.Count == 0)
                        return;

                    modGlobal.gv_sql = "Select Lookuptableid from tbl_setup_DataDef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = {1})",
                        modGlobal.gv_sql, Support.GetItemData(lstGroupList, lstGroupList.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " and Lookuptableid is not null ";

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName19 = "tbl_setup_DataDef";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName19, modGlobal.gv_rs);

                    if (modGlobal.gv_rs.Tables[sqlTableName19].Rows.Count > 0)
                    {
                        LookupTableID = modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["LookupTableID"].ToString();

                        modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                        modGlobal.gv_sql = string.Format("{0} where basetableid = {1}", modGlobal.gv_sql, LookupTableID);
                        modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName20 = "tbl_setup_misclookuplist";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName20, modGlobal.gv_rs);

                        //LDW while (!modGlobal.gv_rs.EOF)
                        foreach (DataRow myRow6 in modGlobal.gv_rs.Tables[sqlTableName20].Rows)
                        {
                            itemscboLookupValues.Add(new Item(myRow6.Field<int>("LookupID"), myRow6.Field<int>("Id") + " " + myRow6.Field<string>("FIELDVALUE")));

                            //cboLookupValues.Items.Add(new ListBoxItem(string.Format("({0}) {1}", myRow6.Field<int>("Id"), myRow6.Field<string>("FIELDVALUE")), myRow6.Field<int>("LookupID")).ToString());
                            //LDW modGlobal.gv_rs.MoveNext();
                        }
                        this.cboLookupValues.DataSource = itemscboLookupValues;
                        this.cboLookupValues.DisplayMember = "Description";
                        this.cboLookupValues.ValueMember = "Id";
                    }
                    else if (Opt2Method.IsChecked == true)
                    {
                        Opt1Method.IsChecked = true;
                    }
                    modGlobal.gv_rs.Dispose();
                }
                else if (TabFirstField.ActiveWindow == TabFirstFieldPatient)
                {
                    modGlobal.gv_sql = "Select Lookuptableid from tbl_setup_DataDef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " and Lookuptableid is not null ";

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName21 = "tbl_setup_DataDef";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName21, modGlobal.gv_rs);

                    if (modGlobal.gv_rs.Tables[sqlTableName21].Rows.Count > 0)
                    {
                        LookupTableID = modGlobal.gv_rs.Tables[sqlTableName21].Rows[0]["LookupTableID"].ToString();

                        modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                        modGlobal.gv_sql = string.Format("{0} where basetableid = {1}", modGlobal.gv_sql, LookupTableID);
                        modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName22 = "tbl_setup_misclookuplist";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName22, modGlobal.gv_rs);

                        //LDW while (!modGlobal.gv_rs.EOF)
                        foreach (DataRow myRow7 in modGlobal.gv_rs.Tables[sqlTableName22].Rows)
                        {
                            itemscboLookupValues.Add(new Item(myRow7.Field<int>("LookupID"), myRow7.Field<int>("Id") + " " + myRow7.Field<string>("FIELDVALUE")));

                            //cboLookupValues.Items.Add(new ListBoxItem(string.Format("({0}) {1}", myRow7.Field<int>("Id"), myRow7.Field<string>("FIELDVALUE")), myRow7.Field<int>("LookupID")).ToString());
                            //LDW modGlobal.gv_rs.MoveNext();
                        }
                        this.cboLookupValues.DataSource = itemscboLookupValues;
                        this.cboLookupValues.DisplayMember = "Description";
                        this.cboLookupValues.ValueMember = "Id";
                    }
                    else if (Opt2Method.IsChecked == true)
                    {
                        Opt1Method.IsChecked = true;
                    }
                    modGlobal.gv_rs.Dispose();
                }
                return;
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
            //LDW //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void RefreshCriteriaFieldList()
        {
            string field1type = null;
            List<Item> itemscboField2List = new List<Item>();
            List<Item> itemscboDestField = new List<Item>();

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (lstGroupList.SelectedItems.Count == 0)
                    return;

                //find the field type
                modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = {1})",
                    modGlobal.gv_sql, Support.GetItemData(lstGroupList, lstGroupList.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName22 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName22, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName22].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                //retrieve the list of table fields
                modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_TableDef.BaseTable = 'PATIENT'";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is null or tbl_setup_DataDef.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = string.Format("{0} and tbl_setup_DataDef.fieldtype = '{1}'", modGlobal.gv_sql, field1type);
                modGlobal.gv_sql = string.Format("{0} and tbl_setup_DataDef.ddid <> {1}", modGlobal.gv_sql,
                    Support.GetItemData(lstGroupList, lstGroupList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " AND (ParentDDID IS NULL OR ParentDDID = DDID) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName23 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName23, modGlobal.gv_rs);

                //Display the list of fields
                cboField2List.Items.Clear();
                cboDestField.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow8 in modGlobal.gv_rs.Tables[sqlTableName23].Rows)
                {
                    itemscboField2List.Add(new Item(myRow8.Field<int>("DDID"), myRow8.Field<string>("FieldName")));
                    itemscboDestField.Add(new Item(myRow8.Field<int>("DDID"), myRow8.Field<string>("FieldName")));

                    //cboField2List.Items.Add(new ListBoxItem(myRow8.Field<string>("FieldName"), myRow8.Field<int>("DDID")).ToString());
                    //cboDestField.Items.Add(new ListBoxItem(myRow8.Field<string>("FieldName"), myRow8.Field<int>("DDID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                this.cboField2List.DataSource = itemscboField2List;
                this.cboField2List.DisplayMember = "Description";
                this.cboField2List.ValueMember = "Id";

                this.cboDestField.DataSource = itemscboDestField;
                this.cboDestField.DisplayMember = "Description";
                this.cboDestField.ValueMember = "Id";

                modGlobal.gv_rs.Dispose();
                return;
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
            //LDW //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void RefreshFieldsList()
        {
            List<Item> itemslstFieldList = new List<Item>();
            List<Item> itemscboField2List = new List<Item>();
            List<Item> itemscboDestField = new List<Item>();


            // ERROR: Not supported in C#: OnErrorStatement


            //retrieve the list of table fields
            //fields are setup in the map measures form - tbl_setup_FieldMeasureSet

            try
            {
                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_DataDef dd ";
                //" WHERE dd.DDID = fm.DDID AND fm.MeasureSetID = " & ii_MeasureSetID
                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE (ParentDDID IS NULL OR ParentDDID = DDID) ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND (dd.State = '' or dd.State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} AND (dd.State = '' or dd.State is null or dd.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName24 = "tbl_Setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName24, modGlobal.gv_rs);

                //Display the list of fields
                lstFieldList.Items.Clear();
                cboField2List.Items.Clear();
                cboDestField.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow9 in modGlobal.gv_rs.Tables[sqlTableName24].Rows)
                {
                    itemslstFieldList.Add(new Item(myRow9.Field<int>("DDID"), myRow9.Field<string>("FieldName")));
                    itemscboField2List.Add(new Item(myRow9.Field<int>("DDID"), myRow9.Field<string>("FieldName")));
                    itemscboDestField.Add(new Item(myRow9.Field<int>("DDID"), myRow9.Field<string>("FieldName")));


                    //lstFieldList.Items.Add(new ListBoxItem(myRow9.Field<string>("FieldName"), myRow9.Field<int>("DDID")).ToString());
                    //cboField2List.Items.Add(new ListBoxItem(myRow9.Field<string>("FieldName"), myRow9.Field<int>("DDID")).ToString());
                    //cboDestField.Items.Add(new ListBoxItem(myRow9.Field<string>("FieldName"), myRow9.Field<int>("DDID")).ToString());

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.lstFieldList.DataSource = itemslstFieldList;
                this.lstFieldList.DisplayMember = "Description";
                this.lstFieldList.ValueMember = "Id";

                this.cboField2List.DataSource = cboField2List;
                this.cboField2List.DisplayMember = "Description";
                this.cboField2List.ValueMember = "Id";

                this.cboDestField.DataSource = itemscboDestField;
                this.cboDestField.DisplayMember = "Description";
                this.cboDestField.ValueMember = "Id";



                modGlobal.gv_rs.Dispose();

                return;
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
            //LDW //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

    }
}
