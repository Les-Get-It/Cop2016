namespace COP2001
{
    partial class frmPatientFieldsExportFormat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatientFieldsExportFormat));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.lstFieldList = new Telerik.WinControls.UI.RadListControl();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtJCFieldCode = new Telerik.WinControls.UI.RadTextBox();
            this.txtCMSFieldCode = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.lstMeasureList = new Telerik.WinControls.UI.RadListControl();
            this.lstSelectedMeasures = new Telerik.WinControls.UI.RadListControl();
            this.cmdUpdate = new Telerik.WinControls.UI.RadButton();
            this.cmdMeasureFieldDetails = new Telerik.WinControls.UI.RadButton();
            this.cmdRemoveFromMeasure = new Telerik.WinControls.UI.RadButton();
            this.cmdLinkToMeasure = new Telerik.WinControls.UI.RadButton();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.lstFieldList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJCFieldCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCMSFieldCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstMeasureList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstSelectedMeasures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdMeasureFieldDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdRemoveFromMeasure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdLinkToMeasure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lstFieldList
            // 
            this.lstFieldList.Location = new System.Drawing.Point(12, 71);
            this.lstFieldList.Name = "lstFieldList";
            this.lstFieldList.Size = new System.Drawing.Size(651, 329);
            this.lstFieldList.TabIndex = 0;
            this.lstFieldList.ThemeName = "Aqua";
            this.lstFieldList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.lstFieldList_SelectedIndexChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(266, 39);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(119, 27);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Patient Fields";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // txtJCFieldCode
            // 
            this.txtJCFieldCode.Location = new System.Drawing.Point(873, 71);
            this.txtJCFieldCode.Name = "txtJCFieldCode";
            this.txtJCFieldCode.Size = new System.Drawing.Size(405, 27);
            this.txtJCFieldCode.TabIndex = 2;
            this.txtJCFieldCode.ThemeName = "Aqua";
            // 
            // txtCMSFieldCode
            // 
            this.txtCMSFieldCode.Location = new System.Drawing.Point(873, 104);
            this.txtCMSFieldCode.Name = "txtCMSFieldCode";
            this.txtCMSFieldCode.Size = new System.Drawing.Size(405, 27);
            this.txtCMSFieldCode.TabIndex = 3;
            this.txtCMSFieldCode.ThemeName = "Aqua";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel2.Location = new System.Drawing.Point(744, 71);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(123, 27);
            this.radLabel2.TabIndex = 4;
            this.radLabel2.Text = "JC Field Code:";
            this.radLabel2.ThemeName = "Aqua";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel3.Location = new System.Drawing.Point(726, 104);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(141, 27);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "CMS Field Code:";
            this.radLabel3.ThemeName = "Aqua";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel4.Location = new System.Drawing.Point(726, 163);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(112, 27);
            this.radLabel4.TabIndex = 6;
            this.radLabel4.Text = "Measure List";
            this.radLabel4.ThemeName = "Aqua";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel5.Location = new System.Drawing.Point(1115, 163);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(85, 27);
            this.radLabel5.TabIndex = 7;
            this.radLabel5.Text = "Linked to";
            this.radLabel5.ThemeName = "Aqua";
            // 
            // lstMeasureList
            // 
            this.lstMeasureList.Location = new System.Drawing.Point(669, 196);
            this.lstMeasureList.Name = "lstMeasureList";
            this.lstMeasureList.Size = new System.Drawing.Size(239, 204);
            this.lstMeasureList.TabIndex = 8;
            this.lstMeasureList.ThemeName = "Aqua";
            // 
            // lstSelectedMeasures
            // 
            this.lstSelectedMeasures.Location = new System.Drawing.Point(1041, 196);
            this.lstSelectedMeasures.Name = "lstSelectedMeasures";
            this.lstSelectedMeasures.Size = new System.Drawing.Size(239, 204);
            this.lstSelectedMeasures.TabIndex = 9;
            this.lstSelectedMeasures.ThemeName = "Aqua";
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(466, 437);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(165, 36);
            this.cmdUpdate.TabIndex = 10;
            this.cmdUpdate.Text = "&Update";
            this.cmdUpdate.ThemeName = "Aqua";
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdMeasureFieldDetails
            // 
            this.cmdMeasureFieldDetails.Location = new System.Drawing.Point(637, 437);
            this.cmdMeasureFieldDetails.Name = "cmdMeasureFieldDetails";
            this.cmdMeasureFieldDetails.Size = new System.Drawing.Size(189, 36);
            this.cmdMeasureFieldDetails.TabIndex = 11;
            this.cmdMeasureFieldDetails.Text = "&Measure Details ";
            this.cmdMeasureFieldDetails.ThemeName = "Aqua";
            this.cmdMeasureFieldDetails.Click += new System.EventHandler(this.cmdMeasureFieldDetails_Click);
            // 
            // cmdRemoveFromMeasure
            // 
            this.cmdRemoveFromMeasure.Location = new System.Drawing.Point(932, 313);
            this.cmdRemoveFromMeasure.Name = "cmdRemoveFromMeasure";
            this.cmdRemoveFromMeasure.Size = new System.Drawing.Size(90, 36);
            this.cmdRemoveFromMeasure.TabIndex = 13;
            this.cmdRemoveFromMeasure.Text = "<<";
            this.cmdRemoveFromMeasure.ThemeName = "Aqua";
            this.cmdRemoveFromMeasure.Click += new System.EventHandler(this.cmdRemoveFromMeasure_Click);
            // 
            // cmdLinkToMeasure
            // 
            this.cmdLinkToMeasure.Location = new System.Drawing.Point(932, 250);
            this.cmdLinkToMeasure.Name = "cmdLinkToMeasure";
            this.cmdLinkToMeasure.Size = new System.Drawing.Size(90, 36);
            this.cmdLinkToMeasure.TabIndex = 12;
            this.cmdLinkToMeasure.Text = ">>";
            this.cmdLinkToMeasure.ThemeName = "Aqua";
            this.cmdLinkToMeasure.Click += new System.EventHandler(this.cmdLinkToMeasure_Click);
            // 
            // frmPatientFieldsExportFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 495);
            this.Controls.Add(this.cmdRemoveFromMeasure);
            this.Controls.Add(this.cmdLinkToMeasure);
            this.Controls.Add(this.cmdMeasureFieldDetails);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.lstSelectedMeasures);
            this.Controls.Add(this.lstMeasureList);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txtCMSFieldCode);
            this.Controls.Add(this.txtJCFieldCode);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.lstFieldList);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPatientFieldsExportFormat";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Patient Field Export Format";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmPatientFieldsExportFormat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lstFieldList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJCFieldCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCMSFieldCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstMeasureList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstSelectedMeasures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdMeasureFieldDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdRemoveFromMeasure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdLinkToMeasure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadListControl lstFieldList;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtJCFieldCode;
        private Telerik.WinControls.UI.RadTextBox txtCMSFieldCode;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadListControl lstMeasureList;
        private Telerik.WinControls.UI.RadListControl lstSelectedMeasures;
        private Telerik.WinControls.UI.RadButton cmdUpdate;
        private Telerik.WinControls.UI.RadButton cmdMeasureFieldDetails;
        private Telerik.WinControls.UI.RadButton cmdRemoveFromMeasure;
        private Telerik.WinControls.UI.RadButton cmdLinkToMeasure;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
