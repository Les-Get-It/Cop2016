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
	partial class OldfrmExportSetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmExportSetup() : base()
		{
			Load += frmExportSetup_Load;
			//This call is required by the Windows Form Designer.
			InitializeComponent();
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
		public System.Windows.Forms.TextBox txtNextVersionNumber;
		public System.Windows.Forms.ComboBox cboStartYear;
		public System.Windows.Forms.ComboBox cboStartQuarter;
		public System.Windows.Forms.TextBox txtMemoField;
		public System.Windows.Forms.RadioButton OptForHospitals;
		public System.Windows.Forms.RadioButton optForTesting;
		public System.Windows.Forms.GroupBox Frame2;
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
		public System.Windows.Forms.RadioButton optActiveAndTest;
		public System.Windows.Forms.RadioButton optActive;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.TextBox txtUserNotes;
		private System.Windows.Forms.Button withEventsField_cmdExport;
		public System.Windows.Forms.Button cmdExport {
			get { return withEventsField_cmdExport; }
			set {
				if (withEventsField_cmdExport != null) {
					withEventsField_cmdExport.Click -= cmdExport_Click;
				}
				withEventsField_cmdExport = value;
				if (withEventsField_cmdExport != null) {
					withEventsField_cmdExport.Click += cmdExport_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstSelectedImportLayouts;
		public System.Windows.Forms.ListBox lstAvailableImportLayouts;
		private System.Windows.Forms.Button withEventsField_cmdAddImportLayout;
		public System.Windows.Forms.Button cmdAddImportLayout {
			get { return withEventsField_cmdAddImportLayout; }
			set {
				if (withEventsField_cmdAddImportLayout != null) {
					withEventsField_cmdAddImportLayout.Click -= cmdAddImportLayout_Click;
				}
				withEventsField_cmdAddImportLayout = value;
				if (withEventsField_cmdAddImportLayout != null) {
					withEventsField_cmdAddImportLayout.Click += cmdAddImportLayout_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemoveImportLayout;
		public System.Windows.Forms.Button cmdRemoveImportLayout {
			get { return withEventsField_cmdRemoveImportLayout; }
			set {
				if (withEventsField_cmdRemoveImportLayout != null) {
					withEventsField_cmdRemoveImportLayout.Click -= cmdRemoveImportLayout_Click;
				}
				withEventsField_cmdRemoveImportLayout = value;
				if (withEventsField_cmdRemoveImportLayout != null) {
					withEventsField_cmdRemoveImportLayout.Click += cmdRemoveImportLayout_Click;
				}
			}
		}
		public AxMSDBGrid.AxDBGrid dbgMemoField;
		public AxMSRDC.AxMSRDC rdcMemoField;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label lblNextVersionNumber;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label lblCurrentVersionNumber;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label2;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmExportSetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.txtNextVersionNumber = new System.Windows.Forms.TextBox();
			this.cboStartYear = new System.Windows.Forms.ComboBox();
			this.cboStartQuarter = new System.Windows.Forms.ComboBox();
			this.txtMemoField = new System.Windows.Forms.TextBox();
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this.OptForHospitals = new System.Windows.Forms.RadioButton();
			this.optForTesting = new System.Windows.Forms.RadioButton();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.optActiveAndTest = new System.Windows.Forms.RadioButton();
			this.optActive = new System.Windows.Forms.RadioButton();
			this.txtUserNotes = new System.Windows.Forms.TextBox();
			this.cmdExport = new System.Windows.Forms.Button();
			this.lstSelectedImportLayouts = new System.Windows.Forms.ListBox();
			this.lstAvailableImportLayouts = new System.Windows.Forms.ListBox();
			this.cmdAddImportLayout = new System.Windows.Forms.Button();
			this.cmdRemoveImportLayout = new System.Windows.Forms.Button();
			this.dbgMemoField = new AxMSDBGrid.AxDBGrid();
			this.rdcMemoField = new AxMSRDC.AxMSRDC();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.lblNextVersionNumber = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.lblCurrentVersionNumber = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Frame2.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.dbgMemoField).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcMemoField).BeginInit();
			this.Text = "Create Update for Access";
			this.ClientSize = new System.Drawing.Size(1028, 467);
			this.Location = new System.Drawing.Point(5, 29);
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
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
			this.Name = "frmExportSetup";
			this.txtNextVersionNumber.AutoSize = false;
			this.txtNextVersionNumber.Size = new System.Drawing.Size(125, 32);
			this.txtNextVersionNumber.Location = new System.Drawing.Point(133, 60);
			this.txtNextVersionNumber.TabIndex = 25;
			this.txtNextVersionNumber.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtNextVersionNumber.AcceptsReturn = true;
			this.txtNextVersionNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtNextVersionNumber.BackColor = System.Drawing.SystemColors.Window;
			this.txtNextVersionNumber.CausesValidation = true;
			this.txtNextVersionNumber.Enabled = true;
			this.txtNextVersionNumber.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNextVersionNumber.HideSelection = true;
			this.txtNextVersionNumber.ReadOnly = false;
			this.txtNextVersionNumber.MaxLength = 0;
			this.txtNextVersionNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtNextVersionNumber.Multiline = false;
			this.txtNextVersionNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtNextVersionNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtNextVersionNumber.TabStop = true;
			this.txtNextVersionNumber.Visible = true;
			this.txtNextVersionNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtNextVersionNumber.Name = "txtNextVersionNumber";
			this.cboStartYear.Size = new System.Drawing.Size(99, 27);
			this.cboStartYear.Location = new System.Drawing.Point(428, 389);
			this.cboStartYear.TabIndex = 24;
			this.cboStartYear.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboStartYear.BackColor = System.Drawing.SystemColors.Window;
			this.cboStartYear.CausesValidation = true;
			this.cboStartYear.Enabled = true;
			this.cboStartYear.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStartYear.IntegralHeight = true;
			this.cboStartYear.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboStartYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboStartYear.Sorted = false;
			this.cboStartYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboStartYear.TabStop = true;
			this.cboStartYear.Visible = true;
			this.cboStartYear.Name = "cboStartYear";
			this.cboStartQuarter.Size = new System.Drawing.Size(49, 27);
			this.cboStartQuarter.Location = new System.Drawing.Point(375, 389);
			this.cboStartQuarter.Items.AddRange(new object[] {
				"1",
				"2",
				"3",
				"4"
			});
			this.cboStartQuarter.TabIndex = 23;
			this.cboStartQuarter.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboStartQuarter.BackColor = System.Drawing.SystemColors.Window;
			this.cboStartQuarter.CausesValidation = true;
			this.cboStartQuarter.Enabled = true;
			this.cboStartQuarter.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStartQuarter.IntegralHeight = true;
			this.cboStartQuarter.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboStartQuarter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboStartQuarter.Sorted = false;
			this.cboStartQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboStartQuarter.TabStop = true;
			this.cboStartQuarter.Visible = true;
			this.cboStartQuarter.Name = "cboStartQuarter";
			this.txtMemoField.AutoSize = false;
			this.txtMemoField.Size = new System.Drawing.Size(53, 23);
			this.txtMemoField.Location = new System.Drawing.Point(282, 513);
			this.txtMemoField.TabIndex = 21;
			this.txtMemoField.Visible = false;
			this.txtMemoField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtMemoField.AcceptsReturn = true;
			this.txtMemoField.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtMemoField.BackColor = System.Drawing.SystemColors.Window;
			this.txtMemoField.CausesValidation = true;
			this.txtMemoField.Enabled = true;
			this.txtMemoField.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtMemoField.HideSelection = true;
			this.txtMemoField.ReadOnly = false;
			this.txtMemoField.MaxLength = 0;
			this.txtMemoField.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMemoField.Multiline = false;
			this.txtMemoField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtMemoField.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtMemoField.TabStop = true;
			this.txtMemoField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtMemoField.Name = "txtMemoField";
			this.Frame2.Text = "Select the reason for creating this update";
			this.Frame2.Size = new System.Drawing.Size(303, 92);
			this.Frame2.Location = new System.Drawing.Point(627, 293);
			this.Frame2.TabIndex = 14;
			this.Frame2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame2.BackColor = System.Drawing.SystemColors.Control;
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Visible = true;
			this.Frame2.Padding = new System.Windows.Forms.Padding(0);
			this.Frame2.Name = "Frame2";
			this.OptForHospitals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptForHospitals.Text = "For Hospitals (New Version Number)";
			this.OptForHospitals.Size = new System.Drawing.Size(287, 25);
			this.OptForHospitals.Location = new System.Drawing.Point(7, 54);
			this.OptForHospitals.TabIndex = 16;
			this.OptForHospitals.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OptForHospitals.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptForHospitals.BackColor = System.Drawing.SystemColors.Control;
			this.OptForHospitals.CausesValidation = true;
			this.OptForHospitals.Enabled = true;
			this.OptForHospitals.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OptForHospitals.Cursor = System.Windows.Forms.Cursors.Default;
			this.OptForHospitals.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptForHospitals.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptForHospitals.TabStop = true;
			this.OptForHospitals.Checked = false;
			this.OptForHospitals.Visible = true;
			this.OptForHospitals.Name = "OptForHospitals";
			this.optForTesting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optForTesting.Text = "For Testing Only  (Don't change the version)";
			this.optForTesting.Size = new System.Drawing.Size(292, 27);
			this.optForTesting.Location = new System.Drawing.Point(7, 27);
			this.optForTesting.TabIndex = 15;
			this.optForTesting.Checked = true;
			this.optForTesting.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optForTesting.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optForTesting.BackColor = System.Drawing.SystemColors.Control;
			this.optForTesting.CausesValidation = true;
			this.optForTesting.Enabled = true;
			this.optForTesting.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optForTesting.Cursor = System.Windows.Forms.Cursors.Default;
			this.optForTesting.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optForTesting.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optForTesting.TabStop = true;
			this.optForTesting.Visible = true;
			this.optForTesting.Name = "optForTesting";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(104, 27);
			this.cmdCancel.Location = new System.Drawing.Point(362, 428);
			this.cmdCancel.TabIndex = 13;
			this.cmdCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.Frame1.Text = "Select the module";
			this.Frame1.Size = new System.Drawing.Size(214, 89);
			this.Frame1.Location = new System.Drawing.Point(88, 293);
			this.Frame1.TabIndex = 10;
			this.Frame1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.optActiveAndTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optActiveAndTest.Text = "Active and Test Setup";
			this.optActiveAndTest.Size = new System.Drawing.Size(183, 25);
			this.optActiveAndTest.Location = new System.Drawing.Point(13, 22);
			this.optActiveAndTest.TabIndex = 12;
			this.optActiveAndTest.Checked = true;
			this.optActiveAndTest.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optActiveAndTest.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optActiveAndTest.BackColor = System.Drawing.SystemColors.Control;
			this.optActiveAndTest.CausesValidation = true;
			this.optActiveAndTest.Enabled = true;
			this.optActiveAndTest.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optActiveAndTest.Cursor = System.Windows.Forms.Cursors.Default;
			this.optActiveAndTest.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optActiveAndTest.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optActiveAndTest.TabStop = true;
			this.optActiveAndTest.Visible = true;
			this.optActiveAndTest.Name = "optActiveAndTest";
			this.optActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optActive.Text = "Active Setup Only";
			this.optActive.Size = new System.Drawing.Size(179, 28);
			this.optActive.Location = new System.Drawing.Point(13, 48);
			this.optActive.TabIndex = 11;
			this.optActive.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optActive.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optActive.BackColor = System.Drawing.SystemColors.Control;
			this.optActive.CausesValidation = true;
			this.optActive.Enabled = true;
			this.optActive.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optActive.Cursor = System.Windows.Forms.Cursors.Default;
			this.optActive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optActive.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optActive.TabStop = true;
			this.optActive.Checked = false;
			this.optActive.Visible = true;
			this.optActive.Name = "optActive";
			this.txtUserNotes.AutoSize = false;
			this.txtUserNotes.Size = new System.Drawing.Size(452, 63);
			this.txtUserNotes.Location = new System.Drawing.Point(264, 30);
			this.txtUserNotes.TabIndex = 8;
			this.txtUserNotes.Text = "No Notes";
			this.txtUserNotes.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtUserNotes.AcceptsReturn = true;
			this.txtUserNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtUserNotes.BackColor = System.Drawing.SystemColors.Window;
			this.txtUserNotes.CausesValidation = true;
			this.txtUserNotes.Enabled = true;
			this.txtUserNotes.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtUserNotes.HideSelection = true;
			this.txtUserNotes.ReadOnly = false;
			this.txtUserNotes.MaxLength = 0;
			this.txtUserNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtUserNotes.Multiline = false;
			this.txtUserNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtUserNotes.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtUserNotes.TabStop = true;
			this.txtUserNotes.Visible = true;
			this.txtUserNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtUserNotes.Name = "txtUserNotes";
			this.cmdExport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExport.Text = "Export Setup";
			this.cmdExport.Size = new System.Drawing.Size(108, 27);
			this.cmdExport.Location = new System.Drawing.Point(230, 428);
			this.cmdExport.TabIndex = 6;
			this.cmdExport.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdExport.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExport.CausesValidation = true;
			this.cmdExport.Enabled = true;
			this.cmdExport.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExport.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExport.TabStop = true;
			this.cmdExport.Name = "cmdExport";
			this.lstSelectedImportLayouts.Size = new System.Drawing.Size(442, 172);
			this.lstSelectedImportLayouts.Location = new System.Drawing.Point(578, 115);
			this.lstSelectedImportLayouts.TabIndex = 3;
			this.lstSelectedImportLayouts.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstSelectedImportLayouts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSelectedImportLayouts.BackColor = System.Drawing.SystemColors.Window;
			this.lstSelectedImportLayouts.CausesValidation = true;
			this.lstSelectedImportLayouts.Enabled = true;
			this.lstSelectedImportLayouts.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSelectedImportLayouts.IntegralHeight = true;
			this.lstSelectedImportLayouts.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSelectedImportLayouts.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstSelectedImportLayouts.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSelectedImportLayouts.Sorted = false;
			this.lstSelectedImportLayouts.TabStop = true;
			this.lstSelectedImportLayouts.Visible = true;
			this.lstSelectedImportLayouts.MultiColumn = false;
			this.lstSelectedImportLayouts.Name = "lstSelectedImportLayouts";
			this.lstAvailableImportLayouts.Size = new System.Drawing.Size(462, 172);
			this.lstAvailableImportLayouts.Location = new System.Drawing.Point(23, 115);
			this.lstAvailableImportLayouts.TabIndex = 2;
			this.lstAvailableImportLayouts.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstAvailableImportLayouts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstAvailableImportLayouts.BackColor = System.Drawing.SystemColors.Window;
			this.lstAvailableImportLayouts.CausesValidation = true;
			this.lstAvailableImportLayouts.Enabled = true;
			this.lstAvailableImportLayouts.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstAvailableImportLayouts.IntegralHeight = true;
			this.lstAvailableImportLayouts.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstAvailableImportLayouts.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstAvailableImportLayouts.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstAvailableImportLayouts.Sorted = false;
			this.lstAvailableImportLayouts.TabStop = true;
			this.lstAvailableImportLayouts.Visible = true;
			this.lstAvailableImportLayouts.MultiColumn = false;
			this.lstAvailableImportLayouts.Name = "lstAvailableImportLayouts";
			this.cmdAddImportLayout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddImportLayout.Text = "==>>";
			this.cmdAddImportLayout.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddImportLayout.Size = new System.Drawing.Size(58, 30);
			this.cmdAddImportLayout.Location = new System.Drawing.Point(500, 160);
			this.cmdAddImportLayout.TabIndex = 1;
			this.cmdAddImportLayout.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddImportLayout.CausesValidation = true;
			this.cmdAddImportLayout.Enabled = true;
			this.cmdAddImportLayout.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddImportLayout.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddImportLayout.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddImportLayout.TabStop = true;
			this.cmdAddImportLayout.Name = "cmdAddImportLayout";
			this.cmdRemoveImportLayout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveImportLayout.Text = "<<==";
			this.cmdRemoveImportLayout.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveImportLayout.Size = new System.Drawing.Size(58, 30);
			this.cmdRemoveImportLayout.Location = new System.Drawing.Point(500, 220);
			this.cmdRemoveImportLayout.TabIndex = 0;
			this.cmdRemoveImportLayout.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveImportLayout.CausesValidation = true;
			this.cmdRemoveImportLayout.Enabled = true;
			this.cmdRemoveImportLayout.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveImportLayout.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveImportLayout.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveImportLayout.TabStop = true;
			this.cmdRemoveImportLayout.Name = "cmdRemoveImportLayout";
			dbgMemoField.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgMemoField.OcxState");
			this.dbgMemoField.Size = new System.Drawing.Size(227, 80);
			this.dbgMemoField.Location = new System.Drawing.Point(349, 473);
			this.dbgMemoField.TabIndex = 20;
			this.dbgMemoField.Visible = false;
			this.dbgMemoField.Name = "dbgMemoField";
			rdcMemoField.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcMemoField.OcxState");
			this.rdcMemoField.Size = new System.Drawing.Size(237, 28);
			this.rdcMemoField.Location = new System.Drawing.Point(40, 512);
			this.rdcMemoField.Visible = false;
			this.rdcMemoField.Name = "rdcMemoField";
			this.Label5.Text = "Setup Start Date (Q/YYYY):";
			this.Label5.Size = new System.Drawing.Size(170, 20);
			this.Label5.Location = new System.Drawing.Point(202, 392);
			this.Label5.TabIndex = 22;
			this.Label5.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label5.BackColor = System.Drawing.SystemColors.Control;
			this.Label5.Enabled = true;
			this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label5.UseMnemonic = true;
			this.Label5.Visible = true;
			this.Label5.AutoSize = false;
			this.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label5.Name = "Label5";
			this.Label6.Text = "New Version";
			this.Label6.Size = new System.Drawing.Size(100, 23);
			this.Label6.Location = new System.Drawing.Point(134, 4);
			this.Label6.TabIndex = 19;
			this.Label6.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label6.BackColor = System.Drawing.SystemColors.Control;
			this.Label6.Enabled = true;
			this.Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label6.UseMnemonic = true;
			this.Label6.Visible = true;
			this.Label6.AutoSize = false;
			this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label6.Name = "Label6";
			this.lblNextVersionNumber.BackColor = System.Drawing.Color.Transparent;
			this.lblNextVersionNumber.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblNextVersionNumber.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.lblNextVersionNumber.Size = new System.Drawing.Size(125, 27);
			this.lblNextVersionNumber.Location = new System.Drawing.Point(134, 30);
			this.lblNextVersionNumber.TabIndex = 18;
			this.lblNextVersionNumber.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblNextVersionNumber.Enabled = true;
			this.lblNextVersionNumber.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblNextVersionNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblNextVersionNumber.UseMnemonic = true;
			this.lblNextVersionNumber.Visible = true;
			this.lblNextVersionNumber.AutoSize = false;
			this.lblNextVersionNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblNextVersionNumber.Name = "lblNextVersionNumber";
			this.Label4.Text = "Current Version";
			this.Label4.Size = new System.Drawing.Size(117, 23);
			this.Label4.Location = new System.Drawing.Point(7, 4);
			this.Label4.TabIndex = 17;
			this.Label4.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label4.BackColor = System.Drawing.SystemColors.Control;
			this.Label4.Enabled = true;
			this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.UseMnemonic = true;
			this.Label4.Visible = true;
			this.Label4.AutoSize = false;
			this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label4.Name = "Label4";
			this.lblCurrentVersionNumber.BackColor = System.Drawing.Color.Transparent;
			this.lblCurrentVersionNumber.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblCurrentVersionNumber.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.lblCurrentVersionNumber.Size = new System.Drawing.Size(124, 62);
			this.lblCurrentVersionNumber.Location = new System.Drawing.Point(7, 30);
			this.lblCurrentVersionNumber.TabIndex = 9;
			this.lblCurrentVersionNumber.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblCurrentVersionNumber.Enabled = true;
			this.lblCurrentVersionNumber.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblCurrentVersionNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblCurrentVersionNumber.UseMnemonic = true;
			this.lblCurrentVersionNumber.Visible = true;
			this.lblCurrentVersionNumber.AutoSize = false;
			this.lblCurrentVersionNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblCurrentVersionNumber.Name = "lblCurrentVersionNumber";
			this.Label3.Text = "Please enter your notes for version ";
			this.Label3.Size = new System.Drawing.Size(234, 23);
			this.Label3.Location = new System.Drawing.Point(264, 4);
			this.Label3.TabIndex = 7;
			this.Label3.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Enabled = true;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.Label1.Text = "Selected Import Layouts";
			this.Label1.Size = new System.Drawing.Size(167, 19);
			this.Label1.Location = new System.Drawing.Point(617, 95);
			this.Label1.TabIndex = 5;
			this.Label1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.Label2.Text = "Available Import Layouts";
			this.Label2.Size = new System.Drawing.Size(167, 20);
			this.Label2.Location = new System.Drawing.Point(23, 94);
			this.Label2.TabIndex = 4;
			this.Label2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.SystemColors.Control;
			this.Label2.Enabled = true;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.Controls.Add(txtNextVersionNumber);
			this.Controls.Add(cboStartYear);
			this.Controls.Add(cboStartQuarter);
			this.Controls.Add(txtMemoField);
			this.Controls.Add(Frame2);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(Frame1);
			this.Controls.Add(txtUserNotes);
			this.Controls.Add(cmdExport);
			this.Controls.Add(lstSelectedImportLayouts);
			this.Controls.Add(lstAvailableImportLayouts);
			this.Controls.Add(cmdAddImportLayout);
			this.Controls.Add(cmdRemoveImportLayout);
			this.Controls.Add(dbgMemoField);
			this.Controls.Add(rdcMemoField);
			this.Controls.Add(Label5);
			this.Controls.Add(Label6);
			this.Controls.Add(lblNextVersionNumber);
			this.Controls.Add(Label4);
			this.Controls.Add(lblCurrentVersionNumber);
			this.Controls.Add(Label3);
			this.Controls.Add(Label1);
			this.Controls.Add(Label2);
			this.Frame2.Controls.Add(OptForHospitals);
			this.Frame2.Controls.Add(optForTesting);
			this.Frame1.Controls.Add(optActiveAndTest);
			this.Frame1.Controls.Add(optActive);
			((System.ComponentModel.ISupportInitialize)this.rdcMemoField).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgMemoField).EndInit();
			this.Frame2.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
