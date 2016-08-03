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
	partial class OldfrmMainMenu
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmMainMenu() : base()
		{
			FormClosed += frmMainMenu_FormClosed;
			Load += frmMainMenu_Load;
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
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuImportRiskCoefficients;
		public System.Windows.Forms.ToolStripMenuItem mnuImportRiskCoefficients {
			get { return withEventsField_mnuImportRiskCoefficients; }
			set {
				if (withEventsField_mnuImportRiskCoefficients != null) {
					withEventsField_mnuImportRiskCoefficients.Click -= mnuImportRiskCoefficients_Click;
				}
				withEventsField_mnuImportRiskCoefficients = value;
				if (withEventsField_mnuImportRiskCoefficients != null) {
					withEventsField_mnuImportRiskCoefficients.Click += mnuImportRiskCoefficients_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuRiskSpecs;
		public System.Windows.Forms.ToolStripMenuItem mnuRiskSpecs {
			get { return withEventsField_mnuRiskSpecs; }
			set {
				if (withEventsField_mnuRiskSpecs != null) {
					withEventsField_mnuRiskSpecs.Click -= mnuRiskSpecs_Click;
				}
				withEventsField_mnuRiskSpecs = value;
				if (withEventsField_mnuRiskSpecs != null) {
					withEventsField_mnuRiskSpecs.Click += mnuRiskSpecs_Click;
				}
			}
		}
		public System.Windows.Forms.ToolStripSeparator mnuSeparator;
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuClose;
		public System.Windows.Forms.ToolStripMenuItem mnuClose {
			get { return withEventsField_mnuClose; }
			set {
				if (withEventsField_mnuClose != null) {
					withEventsField_mnuClose.Click -= mnuClose_Click;
				}
				withEventsField_mnuClose = value;
				if (withEventsField_mnuClose != null) {
					withEventsField_mnuClose.Click += mnuClose_Click;
				}
			}
		}
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuTabFieldValidSetup;
		public System.Windows.Forms.ToolStripMenuItem mnuTabFieldValidSetup {
			get { return withEventsField_mnuTabFieldValidSetup; }
			set {
				if (withEventsField_mnuTabFieldValidSetup != null) {
					withEventsField_mnuTabFieldValidSetup.Click -= mnuTabFieldValidSetup_Click;
				}
				withEventsField_mnuTabFieldValidSetup = value;
				if (withEventsField_mnuTabFieldValidSetup != null) {
					withEventsField_mnuTabFieldValidSetup.Click += mnuTabFieldValidSetup_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuTableValidationSetup;
		public System.Windows.Forms.ToolStripMenuItem mnuTableValidationSetup {
			get { return withEventsField_mnuTableValidationSetup; }
			set {
				if (withEventsField_mnuTableValidationSetup != null) {
					withEventsField_mnuTableValidationSetup.Click -= mnuTableValidationSetup_Click;
				}
				withEventsField_mnuTableValidationSetup = value;
				if (withEventsField_mnuTableValidationSetup != null) {
					withEventsField_mnuTableValidationSetup.Click += mnuTableValidationSetup_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuLookupTableSetup;
		public System.Windows.Forms.ToolStripMenuItem mnuLookupTableSetup {
			get { return withEventsField_mnuLookupTableSetup; }
			set {
				if (withEventsField_mnuLookupTableSetup != null) {
					withEventsField_mnuLookupTableSetup.Click -= mnuLookupTableSetup_Click;
				}
				withEventsField_mnuLookupTableSetup = value;
				if (withEventsField_mnuLookupTableSetup != null) {
					withEventsField_mnuLookupTableSetup.Click += mnuLookupTableSetup_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuIndicatorSetup;
		public System.Windows.Forms.ToolStripMenuItem mnuIndicatorSetup {
			get { return withEventsField_mnuIndicatorSetup; }
			set {
				if (withEventsField_mnuIndicatorSetup != null) {
					withEventsField_mnuIndicatorSetup.Click -= mnuIndicatorSetup_Click;
				}
				withEventsField_mnuIndicatorSetup = value;
				if (withEventsField_mnuIndicatorSetup != null) {
					withEventsField_mnuIndicatorSetup.Click += mnuIndicatorSetup_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuPatientSetup;
		public System.Windows.Forms.ToolStripMenuItem mnuPatientSetup {
			get { return withEventsField_mnuPatientSetup; }
			set {
				if (withEventsField_mnuPatientSetup != null) {
					withEventsField_mnuPatientSetup.Click -= mnuPatientSetup_Click;
				}
				withEventsField_mnuPatientSetup = value;
				if (withEventsField_mnuPatientSetup != null) {
					withEventsField_mnuPatientSetup.Click += mnuPatientSetup_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuHospStatSetup;
		public System.Windows.Forms.ToolStripMenuItem mnuHospStatSetup {
			get { return withEventsField_mnuHospStatSetup; }
			set {
				if (withEventsField_mnuHospStatSetup != null) {
					withEventsField_mnuHospStatSetup.Click -= mnuHospStatSetup_Click;
				}
				withEventsField_mnuHospStatSetup = value;
				if (withEventsField_mnuHospStatSetup != null) {
					withEventsField_mnuHospStatSetup.Click += mnuHospStatSetup_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuReportSetup;
		public System.Windows.Forms.ToolStripMenuItem mnuReportSetup {
			get { return withEventsField_mnuReportSetup; }
			set {
				if (withEventsField_mnuReportSetup != null) {
					withEventsField_mnuReportSetup.Click -= mnuReportSetup_Click;
				}
				withEventsField_mnuReportSetup = value;
				if (withEventsField_mnuReportSetup != null) {
					withEventsField_mnuReportSetup.Click += mnuReportSetup_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuImport;
		public System.Windows.Forms.ToolStripMenuItem mnuImport {
			get { return withEventsField_mnuImport; }
			set {
				if (withEventsField_mnuImport != null) {
					withEventsField_mnuImport.Click -= mnuImport_Click;
				}
				withEventsField_mnuImport = value;
				if (withEventsField_mnuImport != null) {
					withEventsField_mnuImport.Click += mnuImport_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuSubmitSetup;
		public System.Windows.Forms.ToolStripMenuItem mnuSubmitSetup {
			get { return withEventsField_mnuSubmitSetup; }
			set {
				if (withEventsField_mnuSubmitSetup != null) {
					withEventsField_mnuSubmitSetup.Click -= mnuSubmitSetup_Click;
				}
				withEventsField_mnuSubmitSetup = value;
				if (withEventsField_mnuSubmitSetup != null) {
					withEventsField_mnuSubmitSetup.Click += mnuSubmitSetup_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuPatientfieldExportFormat;
		public System.Windows.Forms.ToolStripMenuItem mnuPatientfieldExportFormat {
			get { return withEventsField_mnuPatientfieldExportFormat; }
			set {
				if (withEventsField_mnuPatientfieldExportFormat != null) {
					withEventsField_mnuPatientfieldExportFormat.Click -= mnuPatientfieldExportFormat_Click;
				}
				withEventsField_mnuPatientfieldExportFormat = value;
				if (withEventsField_mnuPatientfieldExportFormat != null) {
					withEventsField_mnuPatientfieldExportFormat.Click += mnuPatientfieldExportFormat_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuMeasureSetup;
		public System.Windows.Forms.ToolStripMenuItem mnuMeasureSetup {
			get { return withEventsField_mnuMeasureSetup; }
			set {
				if (withEventsField_mnuMeasureSetup != null) {
					withEventsField_mnuMeasureSetup.Click -= mnuMeasureSetup_Click;
				}
				withEventsField_mnuMeasureSetup = value;
				if (withEventsField_mnuMeasureSetup != null) {
					withEventsField_mnuMeasureSetup.Click += mnuMeasureSetup_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuDefineFlowcharts;
		public System.Windows.Forms.ToolStripMenuItem mnuDefineFlowcharts {
			get { return withEventsField_mnuDefineFlowcharts; }
			set {
				if (withEventsField_mnuDefineFlowcharts != null) {
					withEventsField_mnuDefineFlowcharts.Click -= mnuDefineFlowcharts_Click;
				}
				withEventsField_mnuDefineFlowcharts = value;
				if (withEventsField_mnuDefineFlowcharts != null) {
					withEventsField_mnuDefineFlowcharts.Click += mnuDefineFlowcharts_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuImpVerifyRecords;
		public System.Windows.Forms.ToolStripMenuItem mnuImpVerifyRecords {
			get { return withEventsField_mnuImpVerifyRecords; }
			set {
				if (withEventsField_mnuImpVerifyRecords != null) {
					withEventsField_mnuImpVerifyRecords.Click -= mnuImpVerifyRecords_Click;
				}
				withEventsField_mnuImpVerifyRecords = value;
				if (withEventsField_mnuImpVerifyRecords != null) {
					withEventsField_mnuImpVerifyRecords.Click += mnuImpVerifyRecords_Click;
				}
			}
		}
		public System.Windows.Forms.ToolStripMenuItem mnuMeasureFlowchart;
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuRiskFactorAssociation;
		public System.Windows.Forms.ToolStripMenuItem mnuRiskFactorAssociation {
			get { return withEventsField_mnuRiskFactorAssociation; }
			set {
				if (withEventsField_mnuRiskFactorAssociation != null) {
					withEventsField_mnuRiskFactorAssociation.Click -= mnuRiskFactorAssociation_Click;
				}
				withEventsField_mnuRiskFactorAssociation = value;
				if (withEventsField_mnuRiskFactorAssociation != null) {
					withEventsField_mnuRiskFactorAssociation.Click += mnuRiskFactorAssociation_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuIndicatorReportSetup;
		public System.Windows.Forms.ToolStripMenuItem mnuIndicatorReportSetup {
			get { return withEventsField_mnuIndicatorReportSetup; }
			set {
				if (withEventsField_mnuIndicatorReportSetup != null) {
					withEventsField_mnuIndicatorReportSetup.Click -= mnuIndicatorReportSetup_Click;
				}
				withEventsField_mnuIndicatorReportSetup = value;
				if (withEventsField_mnuIndicatorReportSetup != null) {
					withEventsField_mnuIndicatorReportSetup.Click += mnuIndicatorReportSetup_Click;
				}
			}
		}
		public System.Windows.Forms.ToolStripMenuItem mnuEdit;
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuUpdateExistingDB;
		public System.Windows.Forms.ToolStripMenuItem mnuUpdateExistingDB {
			get { return withEventsField_mnuUpdateExistingDB; }
			set {
				if (withEventsField_mnuUpdateExistingDB != null) {
					withEventsField_mnuUpdateExistingDB.Click -= mnuUpdateExistingDB_Click;
				}
				withEventsField_mnuUpdateExistingDB = value;
				if (withEventsField_mnuUpdateExistingDB != null) {
					withEventsField_mnuUpdateExistingDB.Click += mnuUpdateExistingDB_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuCreateCMSSetup;
		public System.Windows.Forms.ToolStripMenuItem mnuCreateCMSSetup {
			get { return withEventsField_mnuCreateCMSSetup; }
			set {
				if (withEventsField_mnuCreateCMSSetup != null) {
					withEventsField_mnuCreateCMSSetup.Click -= mnuCreateCMSSetup_Click;
				}
				withEventsField_mnuCreateCMSSetup = value;
				if (withEventsField_mnuCreateCMSSetup != null) {
					withEventsField_mnuCreateCMSSetup.Click += mnuCreateCMSSetup_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuUpdateSystemSetup;
		public System.Windows.Forms.ToolStripMenuItem mnuUpdateSystemSetup {
			get { return withEventsField_mnuUpdateSystemSetup; }
			set {
				if (withEventsField_mnuUpdateSystemSetup != null) {
					withEventsField_mnuUpdateSystemSetup.Click -= mnuUpdateSystemSetup_Click;
				}
				withEventsField_mnuUpdateSystemSetup = value;
				if (withEventsField_mnuUpdateSystemSetup != null) {
					withEventsField_mnuUpdateSystemSetup.Click += mnuUpdateSystemSetup_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuLoadCMSSetup;
		public System.Windows.Forms.ToolStripMenuItem mnuLoadCMSSetup {
			get { return withEventsField_mnuLoadCMSSetup; }
			set {
				if (withEventsField_mnuLoadCMSSetup != null) {
					withEventsField_mnuLoadCMSSetup.Click -= mnuLoadCMSSetup_Click;
				}
				withEventsField_mnuLoadCMSSetup = value;
				if (withEventsField_mnuLoadCMSSetup != null) {
					withEventsField_mnuLoadCMSSetup.Click += mnuLoadCMSSetup_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuExportRiskCoef;
		public System.Windows.Forms.ToolStripMenuItem mnuExportRiskCoef {
			get { return withEventsField_mnuExportRiskCoef; }
			set {
				if (withEventsField_mnuExportRiskCoef != null) {
					withEventsField_mnuExportRiskCoef.Click -= mnuExportRiskCoef_Click;
				}
				withEventsField_mnuExportRiskCoef = value;
				if (withEventsField_mnuExportRiskCoef != null) {
					withEventsField_mnuExportRiskCoef.Click += mnuExportRiskCoef_Click;
				}
			}
		}
		public System.Windows.Forms.ToolStripMenuItem mnuSetupVer;
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuSoftwareVer;
		public System.Windows.Forms.ToolStripMenuItem mnuSoftwareVer {
			get { return withEventsField_mnuSoftwareVer; }
			set {
				if (withEventsField_mnuSoftwareVer != null) {
					withEventsField_mnuSoftwareVer.Click -= mnuSoftwareVer_Click;
				}
				withEventsField_mnuSoftwareVer = value;
				if (withEventsField_mnuSoftwareVer != null) {
					withEventsField_mnuSoftwareVer.Click += mnuSoftwareVer_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuSetup;
		public System.Windows.Forms.ToolStripMenuItem mnuSetup {
			get { return withEventsField_mnuSetup; }
			set {
				if (withEventsField_mnuSetup != null) {
					withEventsField_mnuSetup.Click -= mnuSetup_Click;
				}
				withEventsField_mnuSetup = value;
				if (withEventsField_mnuSetup != null) {
					withEventsField_mnuSetup.Click += mnuSetup_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuStateSetup;
		public System.Windows.Forms.ToolStripMenuItem mnuStateSetup {
			get { return withEventsField_mnuStateSetup; }
			set {
				if (withEventsField_mnuStateSetup != null) {
					withEventsField_mnuStateSetup.Click -= mnuStateSetup_Click;
				}
				withEventsField_mnuStateSetup = value;
				if (withEventsField_mnuStateSetup != null) {
					withEventsField_mnuStateSetup.Click += mnuStateSetup_Click;
				}
			}
		}
		public System.Windows.Forms.ToolStripMenuItem mnuAbout;
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuTiming;
		public System.Windows.Forms.ToolStripMenuItem mnuTiming {
			get { return withEventsField_mnuTiming; }
			set {
				if (withEventsField_mnuTiming != null) {
					withEventsField_mnuTiming.Click -= mnuTiming_Click;
				}
				withEventsField_mnuTiming = value;
				if (withEventsField_mnuTiming != null) {
					withEventsField_mnuTiming.Click += mnuTiming_Click;
				}
			}
		}
		public System.Windows.Forms.MenuStrip MainMenu1;
		public AxMSDBGrid.AxDBGrid dbgMemoField;
		public System.Windows.Forms.TextBox txtHelp;
		public AxMSRDC.AxMSRDC rdcMemoField;
		public System.Windows.Forms.TextBox txtMemoField;
		public AxMSRDC.AxMSRDC rdcHelp;
		public System.Windows.Forms.Label lblDatabase;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmMainMenu));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.MainMenu1 = new System.Windows.Forms.MenuStrip();
			this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImportRiskCoefficients = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRiskSpecs = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTabFieldValidSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTableValidationSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuLookupTableSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuIndicatorSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuPatientSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHospStatSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuReportSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImport = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSubmitSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuPatientfieldExportFormat = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuMeasureFlowchart = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuMeasureSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDefineFlowcharts = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImpVerifyRecords = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRiskFactorAssociation = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuIndicatorReportSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSetupVer = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuUpdateExistingDB = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuCreateCMSSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuUpdateSystemSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuLoadCMSSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuExportRiskCoef = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSoftwareVer = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuStateSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTiming = new System.Windows.Forms.ToolStripMenuItem();
			this.dbgMemoField = new AxMSDBGrid.AxDBGrid();
			this.txtHelp = new System.Windows.Forms.TextBox();
			this.rdcMemoField = new AxMSRDC.AxMSRDC();
			this.txtMemoField = new System.Windows.Forms.TextBox();
			this.rdcHelp = new AxMSRDC.AxMSRDC();
			this.lblDatabase = new System.Windows.Forms.Label();
			this.MainMenu1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.dbgMemoField).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcMemoField).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcHelp).BeginInit();
			this.Text = "Main Menu";
			this.ClientSize = new System.Drawing.Size(1303, 1043);
			this.Location = new System.Drawing.Point(14, 38);
			this.ControlBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Enabled = true;
			this.KeyPreview = false;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.Name = "frmMainMenu";
			this.mnuFile.Name = "mnuFile";
			this.mnuFile.Text = "File";
			this.mnuFile.Checked = false;
			this.mnuFile.Enabled = true;
			this.mnuFile.Visible = true;
			this.mnuImportRiskCoefficients.Name = "mnuImportRiskCoefficients";
			this.mnuImportRiskCoefficients.Text = "Import Risk Coefficients";
			this.mnuImportRiskCoefficients.Checked = false;
			this.mnuImportRiskCoefficients.Enabled = true;
			this.mnuImportRiskCoefficients.Visible = true;
			this.mnuRiskSpecs.Name = "mnuRiskSpecs";
			this.mnuRiskSpecs.Text = "Import Risk Factor Specifications";
			this.mnuRiskSpecs.Checked = false;
			this.mnuRiskSpecs.Enabled = true;
			this.mnuRiskSpecs.Visible = true;
			this.mnuSeparator.Enabled = true;
			this.mnuSeparator.Visible = true;
			this.mnuSeparator.Name = "mnuSeparator";
			this.mnuClose.Name = "mnuClose";
			this.mnuClose.Text = "Close";
			this.mnuClose.Checked = false;
			this.mnuClose.Enabled = true;
			this.mnuClose.Visible = true;
			this.mnuEdit.Name = "mnuEdit";
			this.mnuEdit.Text = "General Setup";
			this.mnuEdit.Checked = false;
			this.mnuEdit.Enabled = true;
			this.mnuEdit.Visible = true;
			this.mnuTabFieldValidSetup.Name = "mnuTabFieldValidSetup";
			this.mnuTabFieldValidSetup.Text = "Tables and Fields Setup";
			this.mnuTabFieldValidSetup.Checked = false;
			this.mnuTabFieldValidSetup.Enabled = true;
			this.mnuTabFieldValidSetup.Visible = true;
			this.mnuTableValidationSetup.Name = "mnuTableValidationSetup";
			this.mnuTableValidationSetup.Text = "Table Validation Setup";
			this.mnuTableValidationSetup.Checked = false;
			this.mnuTableValidationSetup.Enabled = true;
			this.mnuTableValidationSetup.Visible = true;
			this.mnuLookupTableSetup.Name = "mnuLookupTableSetup";
			this.mnuLookupTableSetup.Text = "Lookup Table Setup";
			this.mnuLookupTableSetup.Checked = false;
			this.mnuLookupTableSetup.Enabled = true;
			this.mnuLookupTableSetup.Visible = true;
			this.mnuIndicatorSetup.Name = "mnuIndicatorSetup";
			this.mnuIndicatorSetup.Text = "Indicator Setup";
			this.mnuIndicatorSetup.Checked = false;
			this.mnuIndicatorSetup.Enabled = true;
			this.mnuIndicatorSetup.Visible = true;
			this.mnuPatientSetup.Name = "mnuPatientSetup";
			this.mnuPatientSetup.Text = "Patient Setup";
			this.mnuPatientSetup.Checked = false;
			this.mnuPatientSetup.Enabled = true;
			this.mnuPatientSetup.Visible = true;
			this.mnuHospStatSetup.Name = "mnuHospStatSetup";
			this.mnuHospStatSetup.Text = "Hospital Stat Setup";
			this.mnuHospStatSetup.Checked = false;
			this.mnuHospStatSetup.Enabled = true;
			this.mnuHospStatSetup.Visible = true;
			this.mnuReportSetup.Name = "mnuReportSetup";
			this.mnuReportSetup.Text = "Report Setup";
			this.mnuReportSetup.Checked = false;
			this.mnuReportSetup.Enabled = true;
			this.mnuReportSetup.Visible = true;
			this.mnuImport.Name = "mnuImport";
			this.mnuImport.Text = "Import Setup";
			this.mnuImport.Checked = false;
			this.mnuImport.Enabled = true;
			this.mnuImport.Visible = true;
			this.mnuSubmitSetup.Name = "mnuSubmitSetup";
			this.mnuSubmitSetup.Text = "Data Submission Setup";
			this.mnuSubmitSetup.Checked = false;
			this.mnuSubmitSetup.Enabled = true;
			this.mnuSubmitSetup.Visible = true;
			this.mnuPatientfieldExportFormat.Name = "mnuPatientfieldExportFormat";
			this.mnuPatientfieldExportFormat.Text = "Patient Fields Export Format";
			this.mnuPatientfieldExportFormat.Checked = false;
			this.mnuPatientfieldExportFormat.Enabled = true;
			this.mnuPatientfieldExportFormat.Visible = true;
			this.mnuMeasureFlowchart.Name = "mnuMeasureFlowchart";
			this.mnuMeasureFlowchart.Text = "Measure Flowchart Setup";
			this.mnuMeasureFlowchart.Checked = false;
			this.mnuMeasureFlowchart.Enabled = true;
			this.mnuMeasureFlowchart.Visible = true;
			this.mnuMeasureSetup.Name = "mnuMeasureSetup";
			this.mnuMeasureSetup.Text = "Measure Setup";
			this.mnuMeasureSetup.Checked = false;
			this.mnuMeasureSetup.Enabled = true;
			this.mnuMeasureSetup.Visible = true;
			this.mnuDefineFlowcharts.Name = "mnuDefineFlowcharts";
			this.mnuDefineFlowcharts.Text = "Define Flowcharts";
			this.mnuDefineFlowcharts.Checked = false;
			this.mnuDefineFlowcharts.Enabled = true;
			this.mnuDefineFlowcharts.Visible = true;
			this.mnuImpVerifyRecords.Name = "mnuImpVerifyRecords";
			this.mnuImpVerifyRecords.Text = "Import / Verify Records";
			this.mnuImpVerifyRecords.Checked = false;
			this.mnuImpVerifyRecords.Enabled = true;
			this.mnuImpVerifyRecords.Visible = true;
			this.mnuRiskFactorAssociation.Name = "mnuRiskFactorAssociation";
			this.mnuRiskFactorAssociation.Text = "Risk Factor Association Setup";
			this.mnuRiskFactorAssociation.Checked = false;
			this.mnuRiskFactorAssociation.Enabled = true;
			this.mnuRiskFactorAssociation.Visible = true;
			this.mnuIndicatorReportSetup.Name = "mnuIndicatorReportSetup";
			this.mnuIndicatorReportSetup.Text = "Indicator Report Setup";
			this.mnuIndicatorReportSetup.Checked = false;
			this.mnuIndicatorReportSetup.Enabled = true;
			this.mnuIndicatorReportSetup.Visible = true;
			this.mnuSetupVer.Name = "mnuSetupVer";
			this.mnuSetupVer.Text = "Update Hospital App";
			this.mnuSetupVer.Checked = false;
			this.mnuSetupVer.Enabled = true;
			this.mnuSetupVer.Visible = true;
			this.mnuUpdateExistingDB.Name = "mnuUpdateExistingDB";
			this.mnuUpdateExistingDB.Text = "Create an Access Update File";
			this.mnuUpdateExistingDB.Checked = false;
			this.mnuUpdateExistingDB.Enabled = true;
			this.mnuUpdateExistingDB.Visible = true;
			this.mnuCreateCMSSetup.Name = "mnuCreateCMSSetup";
			this.mnuCreateCMSSetup.Text = "Create CMS Setup";
			this.mnuCreateCMSSetup.Checked = false;
			this.mnuCreateCMSSetup.Enabled = true;
			this.mnuCreateCMSSetup.Visible = true;
			this.mnuUpdateSystemSetup.Name = "mnuUpdateSystemSetup";
			this.mnuUpdateSystemSetup.Text = "Update System Setup";
			this.mnuUpdateSystemSetup.Checked = false;
			this.mnuUpdateSystemSetup.Enabled = true;
			this.mnuUpdateSystemSetup.Visible = true;
			this.mnuLoadCMSSetup.Name = "mnuLoadCMSSetup";
			this.mnuLoadCMSSetup.Text = "Load CMS Setup";
			this.mnuLoadCMSSetup.Checked = false;
			this.mnuLoadCMSSetup.Enabled = true;
			this.mnuLoadCMSSetup.Visible = true;
			this.mnuExportRiskCoef.Name = "mnuExportRiskCoef";
			this.mnuExportRiskCoef.Text = "Export Risk Adjustment Coefficients";
			this.mnuExportRiskCoef.Checked = false;
			this.mnuExportRiskCoef.Enabled = true;
			this.mnuExportRiskCoef.Visible = true;
			this.mnuAbout.Name = "mnuAbout";
			this.mnuAbout.Text = "About";
			this.mnuAbout.Checked = false;
			this.mnuAbout.Enabled = true;
			this.mnuAbout.Visible = true;
			this.mnuSoftwareVer.Name = "mnuSoftwareVer";
			this.mnuSoftwareVer.Text = "Software";
			this.mnuSoftwareVer.Checked = false;
			this.mnuSoftwareVer.Enabled = true;
			this.mnuSoftwareVer.Visible = true;
			this.mnuSetup.Name = "mnuSetup";
			this.mnuSetup.Text = "JC Setup";
			this.mnuSetup.Checked = false;
			this.mnuSetup.Enabled = true;
			this.mnuSetup.Visible = true;
			this.mnuStateSetup.Name = "mnuStateSetup";
			this.mnuStateSetup.Text = "State Setup";
			this.mnuStateSetup.Checked = false;
			this.mnuStateSetup.Enabled = true;
			this.mnuStateSetup.Visible = true;
			this.mnuTiming.Name = "mnuTiming";
			this.mnuTiming.Text = "Timing Tests";
			this.mnuTiming.Visible = false;
			this.mnuTiming.Checked = false;
			this.mnuTiming.Enabled = true;
			dbgMemoField.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgMemoField.OcxState");
			this.dbgMemoField.Size = new System.Drawing.Size(227, 80);
			this.dbgMemoField.Location = new System.Drawing.Point(325, 952);
			this.dbgMemoField.TabIndex = 2;
			this.dbgMemoField.Visible = false;
			this.dbgMemoField.Name = "dbgMemoField";
			this.txtHelp.AutoSize = false;
			this.txtHelp.Size = new System.Drawing.Size(53, 23);
			this.txtHelp.Location = new System.Drawing.Point(257, 957);
			this.txtHelp.TabIndex = 1;
			this.txtHelp.Visible = false;
			this.txtHelp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtHelp.AcceptsReturn = true;
			this.txtHelp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtHelp.BackColor = System.Drawing.SystemColors.Window;
			this.txtHelp.CausesValidation = true;
			this.txtHelp.Enabled = true;
			this.txtHelp.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtHelp.HideSelection = true;
			this.txtHelp.ReadOnly = false;
			this.txtHelp.MaxLength = 0;
			this.txtHelp.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtHelp.Multiline = false;
			this.txtHelp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtHelp.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtHelp.TabStop = true;
			this.txtHelp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtHelp.Name = "txtHelp";
			rdcMemoField.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcMemoField.OcxState");
			this.rdcMemoField.Size = new System.Drawing.Size(237, 28);
			this.rdcMemoField.Location = new System.Drawing.Point(17, 991);
			this.rdcMemoField.Visible = false;
			this.rdcMemoField.Name = "rdcMemoField";
			this.txtMemoField.AutoSize = false;
			this.txtMemoField.Size = new System.Drawing.Size(53, 23);
			this.txtMemoField.Location = new System.Drawing.Point(258, 992);
			this.txtMemoField.TabIndex = 0;
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
			rdcHelp.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcHelp.OcxState");
			this.rdcHelp.Size = new System.Drawing.Size(237, 38);
			this.rdcHelp.Location = new System.Drawing.Point(12, 956);
			this.rdcHelp.Visible = false;
			this.rdcHelp.Name = "rdcHelp";
			this.lblDatabase.BackColor = System.Drawing.Color.Transparent;
			this.lblDatabase.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblDatabase.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.lblDatabase.Size = new System.Drawing.Size(852, 42);
			this.lblDatabase.Location = new System.Drawing.Point(0, 30);
			this.lblDatabase.TabIndex = 3;
			this.lblDatabase.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblDatabase.Enabled = true;
			this.lblDatabase.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDatabase.UseMnemonic = true;
			this.lblDatabase.Visible = true;
			this.lblDatabase.AutoSize = false;
			this.lblDatabase.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblDatabase.Name = "lblDatabase";
			((System.ComponentModel.ISupportInitialize)this.rdcHelp).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcMemoField).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgMemoField).EndInit();
			this.Controls.Add(dbgMemoField);
			this.Controls.Add(txtHelp);
			this.Controls.Add(rdcMemoField);
			this.Controls.Add(txtMemoField);
			this.Controls.Add(rdcHelp);
			this.Controls.Add(lblDatabase);
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.mnuFile,
				this.mnuEdit,
				this.mnuSetupVer,
				this.mnuAbout,
				this.mnuTiming
			});
			mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.mnuImportRiskCoefficients,
				this.mnuRiskSpecs,
				this.mnuSeparator,
				this.mnuClose
			});
			mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.mnuTabFieldValidSetup,
				this.mnuTableValidationSetup,
				this.mnuLookupTableSetup,
				this.mnuIndicatorSetup,
				this.mnuPatientSetup,
				this.mnuHospStatSetup,
				this.mnuReportSetup,
				this.mnuImport,
				this.mnuSubmitSetup,
				this.mnuPatientfieldExportFormat,
				this.mnuMeasureFlowchart,
				this.mnuRiskFactorAssociation,
				this.mnuIndicatorReportSetup
			});
			mnuMeasureFlowchart.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.mnuMeasureSetup,
				this.mnuDefineFlowcharts,
				this.mnuImpVerifyRecords
			});
			mnuSetupVer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.mnuUpdateExistingDB,
				this.mnuCreateCMSSetup,
				this.mnuUpdateSystemSetup,
				this.mnuLoadCMSSetup,
				this.mnuExportRiskCoef
			});
			mnuAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.mnuSoftwareVer,
				this.mnuSetup,
				this.mnuStateSetup
			});
			this.Controls.Add(MainMenu1);
			this.MainMenu1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
