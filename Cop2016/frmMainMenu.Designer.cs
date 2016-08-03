namespace COP2001
{
    partial class frmMainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.mnuFile = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuImportRiskCoefficients = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuRiskSpecs = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuClose = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuEdit = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuTabFieldValidSetup = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuTableValidationSetup = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuLookupTableSetup = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuIndicatorSetup = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuPatientSetup = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuHospStatSetup = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuReportSetup = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuImport = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuSubmitSetup = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuPatientfieldExportFormat = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuMeasureFlowchart = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuMeasureSetup = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuDefineFlowcharts = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuImpVerifyRecords = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuRiskFactorAssociation = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuIndicatorReportSetup = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuSetupVer = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuUpdateExistingDB = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuCreateCMSSetup = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuUpdateSystemSetup = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuLoadCMSSetup = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuExportRiskCoef = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuAbout = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuSoftwareVer = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuSetup = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuStateSetup = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.lblDatabase = new Telerik.WinControls.UI.RadLabel();
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuFile
            // 
            this.mnuFile.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.mnuImportRiskCoefficients,
            this.mnuRiskSpecs,
            this.mnuClose});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Text = "File";
            // 
            // mnuImportRiskCoefficients
            // 
            this.mnuImportRiskCoefficients.Name = "mnuImportRiskCoefficients";
            this.mnuImportRiskCoefficients.Text = "Import Risk Coefficients";
            this.mnuImportRiskCoefficients.Click += new System.EventHandler(this.mnuImportRiskCoefficients_Click);
            // 
            // mnuRiskSpecs
            // 
            this.mnuRiskSpecs.Name = "mnuRiskSpecs";
            this.mnuRiskSpecs.Text = "Import Risk Factor Specifications";
            this.mnuRiskSpecs.Click += new System.EventHandler(this.mnuRiskSpecs_Click);
            // 
            // mnuClose
            // 
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.Text = "Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Items.AddRange(new Telerik.WinControls.RadItem[] {
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
            this.mnuIndicatorReportSetup});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Text = "General Setup";
            // 
            // mnuTabFieldValidSetup
            // 
            this.mnuTabFieldValidSetup.Name = "mnuTabFieldValidSetup";
            this.mnuTabFieldValidSetup.Text = "Tables and Fields Setup";
            this.mnuTabFieldValidSetup.Click += new System.EventHandler(this.mnuTabFieldValidSetup_Click);
            // 
            // mnuTableValidationSetup
            // 
            this.mnuTableValidationSetup.Name = "mnuTableValidationSetup";
            this.mnuTableValidationSetup.Text = "Table Validation Setup";
            this.mnuTableValidationSetup.Click += new System.EventHandler(this.mnuTableValidationSetup_Click);
            // 
            // mnuLookupTableSetup
            // 
            this.mnuLookupTableSetup.Name = "mnuLookupTableSetup";
            this.mnuLookupTableSetup.Text = "Lookup Table Setup";
            this.mnuLookupTableSetup.Click += new System.EventHandler(this.mnuLookupTableSetup_Click);
            // 
            // mnuIndicatorSetup
            // 
            this.mnuIndicatorSetup.Name = "mnuIndicatorSetup";
            this.mnuIndicatorSetup.Text = "Indicator Setup";
            this.mnuIndicatorSetup.Click += new System.EventHandler(this.mnuIndicatorSetup_Click);
            // 
            // mnuPatientSetup
            // 
            this.mnuPatientSetup.Name = "mnuPatientSetup";
            this.mnuPatientSetup.Text = "Patient Setup";
            this.mnuPatientSetup.Click += new System.EventHandler(this.mnuPatientSetup_Click);
            // 
            // mnuHospStatSetup
            // 
            this.mnuHospStatSetup.Name = "mnuHospStatSetup";
            this.mnuHospStatSetup.Text = "Hospital Stat Setup";
            this.mnuHospStatSetup.Click += new System.EventHandler(this.mnuHospStatSetup_Click);
            // 
            // mnuReportSetup
            // 
            this.mnuReportSetup.Name = "mnuReportSetup";
            this.mnuReportSetup.Text = "Report Setup";
            this.mnuReportSetup.Click += new System.EventHandler(this.mnuReportSetup_Click);
            // 
            // mnuImport
            // 
            this.mnuImport.Name = "mnuImport";
            this.mnuImport.Text = "Import Setup";
            this.mnuImport.Click += new System.EventHandler(this.mnuImport_Click);
            // 
            // mnuSubmitSetup
            // 
            this.mnuSubmitSetup.Name = "mnuSubmitSetup";
            this.mnuSubmitSetup.Text = "Data Submission Setup";
            this.mnuSubmitSetup.Click += new System.EventHandler(this.mnuSubmitSetup_Click);
            // 
            // mnuPatientfieldExportFormat
            // 
            this.mnuPatientfieldExportFormat.Name = "mnuPatientfieldExportFormat";
            this.mnuPatientfieldExportFormat.Text = "Patient Fields Export Format";
            this.mnuPatientfieldExportFormat.Click += new System.EventHandler(this.mnuPatientfieldExportFormat_Click);
            // 
            // mnuMeasureFlowchart
            // 
            this.mnuMeasureFlowchart.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.mnuMeasureSetup,
            this.mnuDefineFlowcharts,
            this.mnuImpVerifyRecords});
            this.mnuMeasureFlowchart.Name = "mnuMeasureFlowchart";
            this.mnuMeasureFlowchart.Text = "Measure Flowchart Setup";
            // 
            // mnuMeasureSetup
            // 
            this.mnuMeasureSetup.Name = "mnuMeasureSetup";
            this.mnuMeasureSetup.Text = "Measure Setup";
            this.mnuMeasureSetup.Click += new System.EventHandler(this.mnuMeasureSetup_Click);
            // 
            // mnuDefineFlowcharts
            // 
            this.mnuDefineFlowcharts.Name = "mnuDefineFlowcharts";
            this.mnuDefineFlowcharts.Text = "Define Flowcharts";
            this.mnuDefineFlowcharts.Click += new System.EventHandler(this.mnuDefineFlowcharts_Click);
            // 
            // mnuImpVerifyRecords
            // 
            this.mnuImpVerifyRecords.Name = "mnuImpVerifyRecords";
            this.mnuImpVerifyRecords.Text = "Import / Verify Records";
            this.mnuImpVerifyRecords.Click += new System.EventHandler(this.mnuImpVerifyRecords_Click);
            // 
            // mnuRiskFactorAssociation
            // 
            this.mnuRiskFactorAssociation.Name = "mnuRiskFactorAssociation";
            this.mnuRiskFactorAssociation.Text = "Risk Factor Association Setup";
            this.mnuRiskFactorAssociation.Click += new System.EventHandler(this.mnuRiskFactorAssociation_Click);
            // 
            // mnuIndicatorReportSetup
            // 
            this.mnuIndicatorReportSetup.Name = "mnuIndicatorReportSetup";
            this.mnuIndicatorReportSetup.Text = "Indicator Report Setup";
            this.mnuIndicatorReportSetup.Click += new System.EventHandler(this.mnuIndicatorReportSetup_Click);
            // 
            // mnuSetupVer
            // 
            this.mnuSetupVer.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.mnuUpdateExistingDB,
            this.mnuCreateCMSSetup,
            this.mnuUpdateSystemSetup,
            this.mnuLoadCMSSetup,
            this.mnuExportRiskCoef});
            this.mnuSetupVer.Name = "mnuSetupVer";
            this.mnuSetupVer.Text = "Update Hospital App";
            // 
            // mnuUpdateExistingDB
            // 
            this.mnuUpdateExistingDB.Name = "mnuUpdateExistingDB";
            this.mnuUpdateExistingDB.Text = "Create an Access Update File";
            this.mnuUpdateExistingDB.Click += new System.EventHandler(this.mnuUpdateExistingDB_Click);
            // 
            // mnuCreateCMSSetup
            // 
            this.mnuCreateCMSSetup.Name = "mnuCreateCMSSetup";
            this.mnuCreateCMSSetup.Text = "Create CMS Setup";
            this.mnuCreateCMSSetup.Click += new System.EventHandler(this.mnuCreateCMSSetup_Click);
            // 
            // mnuUpdateSystemSetup
            // 
            this.mnuUpdateSystemSetup.Name = "mnuUpdateSystemSetup";
            this.mnuUpdateSystemSetup.Text = "Update System Setup";
            this.mnuUpdateSystemSetup.Click += new System.EventHandler(this.mnuUpdateSystemSetup_Click);
            // 
            // mnuLoadCMSSetup
            // 
            this.mnuLoadCMSSetup.Name = "mnuLoadCMSSetup";
            this.mnuLoadCMSSetup.Text = "Load CMS Setup";
            this.mnuLoadCMSSetup.Click += new System.EventHandler(this.mnuLoadCMSSetup_Click);
            // 
            // mnuExportRiskCoef
            // 
            this.mnuExportRiskCoef.Name = "mnuExportRiskCoef";
            this.mnuExportRiskCoef.Text = "Export Risk Adjustment Coefficients";
            this.mnuExportRiskCoef.Click += new System.EventHandler(this.mnuExportRiskCoef_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.mnuSoftwareVer,
            this.mnuSetup,
            this.mnuStateSetup});
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Text = "About";
            // 
            // mnuSoftwareVer
            // 
            this.mnuSoftwareVer.Name = "mnuSoftwareVer";
            this.mnuSoftwareVer.Text = "Software";
            this.mnuSoftwareVer.Click += new System.EventHandler(this.mnuSoftwareVer_Click);
            // 
            // mnuSetup
            // 
            this.mnuSetup.Name = "mnuSetup";
            this.mnuSetup.Text = "JC Setup";
            this.mnuSetup.Click += new System.EventHandler(this.mnuSetup_Click);
            // 
            // mnuStateSetup
            // 
            this.mnuStateSetup.Name = "mnuStateSetup";
            this.mnuStateSetup.Text = "State Setup";
            this.mnuStateSetup.Click += new System.EventHandler(this.mnuStateSetup_Click);
            // 
            // radMenu1
            // 
            this.radMenu1.Font = new System.Drawing.Font("Segoe UI", 8.8F, System.Drawing.FontStyle.Bold);
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuSetupVer,
            this.mnuAbout});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(1300, 30);
            this.radMenu1.TabIndex = 0;
            this.radMenu1.Text = "radMenu1";
            this.radMenu1.ThemeName = "Aqua";
            // 
            // lblDatabase
            // 
            this.lblDatabase.Font = new System.Drawing.Font("Segoe UI", 8.9F, System.Drawing.FontStyle.Bold);
            this.lblDatabase.Location = new System.Drawing.Point(610, 48);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(2, 2);
            this.lblDatabase.TabIndex = 1;
            this.lblDatabase.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDatabase.ThemeName = "BreezeTheme1";
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1300, 676);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.radMenu1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMainMenu";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Main Menu";
            this.ThemeName = "Aqua";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMainMenu_FormClosed);
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadMenuItem mnuFile;
        private Telerik.WinControls.UI.RadMenuItem mnuImportRiskCoefficients;
        private Telerik.WinControls.UI.RadMenuItem mnuRiskSpecs;
        private Telerik.WinControls.UI.RadMenuItem mnuClose;
        private Telerik.WinControls.UI.RadMenuItem mnuEdit;
        private Telerik.WinControls.UI.RadMenuItem mnuTabFieldValidSetup;
        private Telerik.WinControls.UI.RadMenuItem mnuTableValidationSetup;
        private Telerik.WinControls.UI.RadMenuItem mnuLookupTableSetup;
        private Telerik.WinControls.UI.RadMenuItem mnuIndicatorSetup;
        private Telerik.WinControls.UI.RadMenuItem mnuPatientSetup;
        private Telerik.WinControls.UI.RadMenuItem mnuHospStatSetup;
        private Telerik.WinControls.UI.RadMenuItem mnuReportSetup;
        private Telerik.WinControls.UI.RadMenuItem mnuImport;
        private Telerik.WinControls.UI.RadMenuItem mnuSubmitSetup;
        private Telerik.WinControls.UI.RadMenuItem mnuPatientfieldExportFormat;
        private Telerik.WinControls.UI.RadMenuItem mnuMeasureFlowchart;
        private Telerik.WinControls.UI.RadMenuItem mnuRiskFactorAssociation;
        private Telerik.WinControls.UI.RadMenuItem mnuIndicatorReportSetup;
        private Telerik.WinControls.UI.RadMenuItem mnuSetupVer;
        private Telerik.WinControls.UI.RadMenuItem mnuUpdateExistingDB;
        private Telerik.WinControls.UI.RadMenuItem mnuCreateCMSSetup;
        private Telerik.WinControls.UI.RadMenuItem mnuUpdateSystemSetup;
        private Telerik.WinControls.UI.RadMenuItem mnuLoadCMSSetup;
        private Telerik.WinControls.UI.RadMenuItem mnuExportRiskCoef;
        private Telerik.WinControls.UI.RadMenuItem mnuAbout;
        private Telerik.WinControls.UI.RadMenuItem mnuSoftwareVer;
        private Telerik.WinControls.UI.RadMenuItem mnuSetup;
        private Telerik.WinControls.UI.RadMenuItem mnuStateSetup;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem mnuMeasureSetup;
        private Telerik.WinControls.UI.RadMenuItem mnuDefineFlowcharts;
        private Telerik.WinControls.UI.RadMenuItem mnuImpVerifyRecords;
        private Telerik.WinControls.UI.RadLabel lblDatabase;
        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
