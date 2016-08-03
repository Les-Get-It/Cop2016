using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
namespace COP2001
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	partial class OldfrmImportMeasureSetFile
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmImportMeasureSetFile() : base()
		{
			Load += frmImportMeasureSetFile_Load;
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = My.MyProject.Forms.frmMasterForm;
			My.MyProject.Forms.frmMasterForm.Show();
		}
//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool Disposing)
		{
			if (Disposing) {
				if ((components != null)) {
					components.Dispose();
				}
			}
			base.Dispose(Disposing);
		}
//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTip1;
		public System.Windows.Forms.CheckBox chkNotImport;
		public System.Windows.Forms.ListBox lstIndicators;
		public AxCrystal.AxCrystalReport crReport;
		private System.Windows.Forms.Button withEventsField_cmdCancel;
		public System.Windows.Forms.Button cmdCancel {
			get { return withEventsField_cmdCancel; }
			set {
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click -= cmdCancel_Click;
				}
				withEventsField_cmdCancel = value;
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click += cmdCancel_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdProcess;
		public System.Windows.Forms.Button cmdProcess {
			get { return withEventsField_cmdProcess; }
			set {
				if (withEventsField_cmdProcess != null) {
					withEventsField_cmdProcess.Click -= cmdProcess_Click;
				}
				withEventsField_cmdProcess = value;
				if (withEventsField_cmdProcess != null) {
					withEventsField_cmdProcess.Click += cmdProcess_Click;
				}
			}
		}
		public System.Windows.Forms.ProgressBar pgStatus;
		private System.Windows.Forms.ComboBox withEventsField_cboMeasureSet;
		public System.Windows.Forms.ComboBox cboMeasureSet {
			get { return withEventsField_cboMeasureSet; }
			set {
				if (withEventsField_cboMeasureSet != null) {
					withEventsField_cboMeasureSet.SelectedIndexChanged -= cboMeasureSet_SelectedIndexChanged;
				}
				withEventsField_cboMeasureSet = value;
				if (withEventsField_cboMeasureSet != null) {
					withEventsField_cboMeasureSet.SelectedIndexChanged += cboMeasureSet_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_Opt4th;
		public System.Windows.Forms.RadioButton Opt4th {
			get { return withEventsField_Opt4th; }
			set {
				if (withEventsField_Opt4th != null) {
					withEventsField_Opt4th.Enter -= opt4th_Enter;
				}
				withEventsField_Opt4th = value;
				if (withEventsField_Opt4th != null) {
					withEventsField_Opt4th.Enter += opt4th_Enter;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_Opt3rd;
		public System.Windows.Forms.RadioButton Opt3rd {
			get { return withEventsField_Opt3rd; }
			set {
				if (withEventsField_Opt3rd != null) {
					withEventsField_Opt3rd.Enter -= opt3rd_Enter;
				}
				withEventsField_Opt3rd = value;
				if (withEventsField_Opt3rd != null) {
					withEventsField_Opt3rd.Enter += opt3rd_Enter;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_Opt2nd;
		public System.Windows.Forms.RadioButton Opt2nd {
			get { return withEventsField_Opt2nd; }
			set {
				if (withEventsField_Opt2nd != null) {
					withEventsField_Opt2nd.Enter -= opt2nd_Enter;
				}
				withEventsField_Opt2nd = value;
				if (withEventsField_Opt2nd != null) {
					withEventsField_Opt2nd.Enter += opt2nd_Enter;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_Opt1st;
		public System.Windows.Forms.RadioButton Opt1st {
			get { return withEventsField_Opt1st; }
			set {
				if (withEventsField_Opt1st != null) {
					withEventsField_Opt1st.Enter -= opt1st_Enter;
				}
				withEventsField_Opt1st = value;
				if (withEventsField_Opt1st != null) {
					withEventsField_Opt1st.Enter += opt1st_Enter;
				}
			}
		}
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.ListBox lstYear;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label lblStatus;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label lblMonths;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmImportMeasureSetFile));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.chkNotImport = new System.Windows.Forms.CheckBox();
			this.lstIndicators = new System.Windows.Forms.ListBox();
			this.crReport = new AxCrystal.AxCrystalReport();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdProcess = new System.Windows.Forms.Button();
			this.pgStatus = new System.Windows.Forms.ProgressBar();
			this.cboMeasureSet = new System.Windows.Forms.ComboBox();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.Opt4th = new System.Windows.Forms.RadioButton();
			this.Opt3rd = new System.Windows.Forms.RadioButton();
			this.Opt2nd = new System.Windows.Forms.RadioButton();
			this.Opt1st = new System.Windows.Forms.RadioButton();
			this.lstYear = new System.Windows.Forms.ListBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.lblMonths = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.crReport).BeginInit();
			this.Text = "Import Measure Set File";
			this.ClientSize = new System.Drawing.Size(1032, 467);
			this.Location = new System.Drawing.Point(5, 29);
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
			this.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.ControlBox = true;
			this.Enabled = true;
			this.KeyPreview = false;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmImportMeasureSetFile";
			this.chkNotImport.Text = "Do not prompt for import file - Use records imported during last import ";
			this.chkNotImport.Size = new System.Drawing.Size(432, 17);
			this.chkNotImport.Location = new System.Drawing.Point(270, 340);
			this.chkNotImport.TabIndex = 16;
			this.chkNotImport.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkNotImport.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkNotImport.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkNotImport.BackColor = System.Drawing.SystemColors.Control;
			this.chkNotImport.CausesValidation = true;
			this.chkNotImport.Enabled = true;
			this.chkNotImport.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkNotImport.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkNotImport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkNotImport.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkNotImport.TabStop = true;
			this.chkNotImport.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkNotImport.Visible = true;
			this.chkNotImport.Name = "chkNotImport";
			this.lstIndicators.Size = new System.Drawing.Size(692, 155);
			this.lstIndicators.Location = new System.Drawing.Point(330, 120);
			this.lstIndicators.TabIndex = 14;
			this.lstIndicators.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstIndicators.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstIndicators.BackColor = System.Drawing.SystemColors.Window;
			this.lstIndicators.CausesValidation = true;
			this.lstIndicators.Enabled = true;
			this.lstIndicators.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstIndicators.IntegralHeight = true;
			this.lstIndicators.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstIndicators.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstIndicators.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstIndicators.Sorted = false;
			this.lstIndicators.TabStop = true;
			this.lstIndicators.Visible = true;
			this.lstIndicators.MultiColumn = false;
			this.lstIndicators.Name = "lstIndicators";
			crReport.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("crReport.OcxState");
			this.crReport.Location = new System.Drawing.Point(700, 430);
			this.crReport.Name = "crReport";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CancelButton = this.cmdCancel;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(102, 32);
			this.cmdCancel.Location = new System.Drawing.Point(530, 370);
			this.cmdCancel.TabIndex = 12;
			this.cmdCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdProcess.Text = "Import And Process";
			this.AcceptButton = this.cmdProcess;
			this.cmdProcess.Size = new System.Drawing.Size(152, 32);
			this.cmdProcess.Location = new System.Drawing.Point(350, 370);
			this.cmdProcess.TabIndex = 11;
			this.cmdProcess.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdProcess.BackColor = System.Drawing.SystemColors.Control;
			this.cmdProcess.CausesValidation = true;
			this.cmdProcess.Enabled = true;
			this.cmdProcess.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdProcess.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdProcess.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdProcess.TabStop = true;
			this.cmdProcess.Name = "cmdProcess";
			this.pgStatus.Size = new System.Drawing.Size(662, 32);
			this.pgStatus.Location = new System.Drawing.Point(0, 410);
			this.pgStatus.TabIndex = 10;
			this.pgStatus.Name = "pgStatus";
			this.cboMeasureSet.Size = new System.Drawing.Size(322, 27);
			this.cboMeasureSet.Location = new System.Drawing.Point(330, 60);
			this.cboMeasureSet.TabIndex = 8;
			this.cboMeasureSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboMeasureSet.BackColor = System.Drawing.SystemColors.Window;
			this.cboMeasureSet.CausesValidation = true;
			this.cboMeasureSet.Enabled = true;
			this.cboMeasureSet.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboMeasureSet.IntegralHeight = true;
			this.cboMeasureSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboMeasureSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboMeasureSet.Sorted = false;
			this.cboMeasureSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboMeasureSet.TabStop = true;
			this.cboMeasureSet.Visible = true;
			this.cboMeasureSet.Name = "cboMeasureSet";
			this.Frame1.Text = "Quarter";
			this.Frame1.Size = new System.Drawing.Size(152, 192);
			this.Frame1.Location = new System.Drawing.Point(160, 50);
			this.Frame1.TabIndex = 2;
			this.Frame1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.Opt4th.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt4th.Text = "4th Quarter";
			this.Opt4th.Size = new System.Drawing.Size(112, 22);
			this.Opt4th.Location = new System.Drawing.Point(20, 150);
			this.Opt4th.TabIndex = 6;
			this.Opt4th.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Opt4th.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt4th.BackColor = System.Drawing.SystemColors.Control;
			this.Opt4th.CausesValidation = true;
			this.Opt4th.Enabled = true;
			this.Opt4th.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Opt4th.Cursor = System.Windows.Forms.Cursors.Default;
			this.Opt4th.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Opt4th.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Opt4th.TabStop = true;
			this.Opt4th.Checked = false;
			this.Opt4th.Visible = true;
			this.Opt4th.Name = "Opt4th";
			this.Opt3rd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt3rd.Text = "3rd Quarter";
			this.Opt3rd.Size = new System.Drawing.Size(112, 22);
			this.Opt3rd.Location = new System.Drawing.Point(20, 110);
			this.Opt3rd.TabIndex = 5;
			this.Opt3rd.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Opt3rd.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt3rd.BackColor = System.Drawing.SystemColors.Control;
			this.Opt3rd.CausesValidation = true;
			this.Opt3rd.Enabled = true;
			this.Opt3rd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Opt3rd.Cursor = System.Windows.Forms.Cursors.Default;
			this.Opt3rd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Opt3rd.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Opt3rd.TabStop = true;
			this.Opt3rd.Checked = false;
			this.Opt3rd.Visible = true;
			this.Opt3rd.Name = "Opt3rd";
			this.Opt2nd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt2nd.Text = "2nd Quarter";
			this.Opt2nd.Size = new System.Drawing.Size(112, 22);
			this.Opt2nd.Location = new System.Drawing.Point(20, 70);
			this.Opt2nd.TabIndex = 4;
			this.Opt2nd.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Opt2nd.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt2nd.BackColor = System.Drawing.SystemColors.Control;
			this.Opt2nd.CausesValidation = true;
			this.Opt2nd.Enabled = true;
			this.Opt2nd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Opt2nd.Cursor = System.Windows.Forms.Cursors.Default;
			this.Opt2nd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Opt2nd.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Opt2nd.TabStop = true;
			this.Opt2nd.Checked = false;
			this.Opt2nd.Visible = true;
			this.Opt2nd.Name = "Opt2nd";
			this.Opt1st.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt1st.Text = "1st Quarter";
			this.Opt1st.Size = new System.Drawing.Size(112, 22);
			this.Opt1st.Location = new System.Drawing.Point(20, 30);
			this.Opt1st.TabIndex = 3;
			this.Opt1st.Checked = true;
			this.Opt1st.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Opt1st.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt1st.BackColor = System.Drawing.SystemColors.Control;
			this.Opt1st.CausesValidation = true;
			this.Opt1st.Enabled = true;
			this.Opt1st.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Opt1st.Cursor = System.Windows.Forms.Cursors.Default;
			this.Opt1st.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Opt1st.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Opt1st.TabStop = true;
			this.Opt1st.Visible = true;
			this.Opt1st.Name = "Opt1st";
			this.lstYear.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstYear.Size = new System.Drawing.Size(132, 189);
			this.lstYear.Location = new System.Drawing.Point(10, 50);
			this.lstYear.TabIndex = 1;
			this.lstYear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstYear.BackColor = System.Drawing.SystemColors.Window;
			this.lstYear.CausesValidation = true;
			this.lstYear.Enabled = true;
			this.lstYear.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstYear.IntegralHeight = true;
			this.lstYear.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstYear.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstYear.Sorted = false;
			this.lstYear.TabStop = true;
			this.lstYear.Visible = true;
			this.lstYear.MultiColumn = false;
			this.lstYear.Name = "lstYear";
			this.Label3.Text = "Choose Indicators to Run:";
			this.Label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label3.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.Label3.Size = new System.Drawing.Size(262, 22);
			this.Label3.Location = new System.Drawing.Point(330, 100);
			this.Label3.TabIndex = 15;
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Enabled = true;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.lblStatus.Text = "Verify Status..";
			this.lblStatus.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblStatus.ForeColor = System.Drawing.Color.Yellow;
			this.lblStatus.Size = new System.Drawing.Size(812, 32);
			this.lblStatus.Location = new System.Drawing.Point(210, 300);
			this.lblStatus.TabIndex = 13;
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblStatus.BackColor = System.Drawing.SystemColors.Control;
			this.lblStatus.Enabled = true;
			this.lblStatus.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblStatus.UseMnemonic = true;
			this.lblStatus.Visible = true;
			this.lblStatus.AutoSize = false;
			this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblStatus.Name = "lblStatus";
			this.Label2.Text = "Choose Measure Set to Import:";
			this.Label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.Label2.Size = new System.Drawing.Size(262, 22);
			this.Label2.Location = new System.Drawing.Point(330, 20);
			this.Label2.TabIndex = 9;
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.SystemColors.Control;
			this.Label2.Enabled = true;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.lblMonths.Text = "January, February, March";
			this.lblMonths.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblMonths.ForeColor = System.Drawing.Color.Blue;
			this.lblMonths.Size = new System.Drawing.Size(192, 32);
			this.lblMonths.Location = new System.Drawing.Point(150, 250);
			this.lblMonths.TabIndex = 7;
			this.lblMonths.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblMonths.BackColor = System.Drawing.SystemColors.Control;
			this.lblMonths.Enabled = true;
			this.lblMonths.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblMonths.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblMonths.UseMnemonic = true;
			this.lblMonths.Visible = true;
			this.lblMonths.AutoSize = false;
			this.lblMonths.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblMonths.Name = "lblMonths";
			this.Label1.Text = "Select A Year And A Quarter:";
			this.Label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.Label1.Size = new System.Drawing.Size(292, 22);
			this.Label1.Location = new System.Drawing.Point(10, 20);
			this.Label1.TabIndex = 0;
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.Enabled = true;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			((System.ComponentModel.ISupportInitialize)this.crReport).EndInit();
			this.Controls.Add(chkNotImport);
			this.Controls.Add(lstIndicators);
			this.Controls.Add(crReport);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdProcess);
			this.Controls.Add(pgStatus);
			this.Controls.Add(cboMeasureSet);
			this.Controls.Add(Frame1);
			this.Controls.Add(lstYear);
			this.Controls.Add(Label3);
			this.Controls.Add(lblStatus);
			this.Controls.Add(Label2);
			this.Controls.Add(lblMonths);
			this.Controls.Add(Label1);
			this.Frame1.Controls.Add(Opt4th);
			this.Frame1.Controls.Add(Opt3rd);
			this.Frame1.Controls.Add(Opt2nd);
			this.Frame1.Controls.Add(Opt1st);
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
