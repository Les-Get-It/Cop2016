namespace COP2001
{
    partial class frmSectionAddPatientField
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSectionAddPatientField));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            this.cmdSelect = new Telerik.WinControls.UI.RadButton();
            this.lstIndicators = new Telerik.WinControls.UI.RadListControl();
            this.cboPatientFields = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstIndicators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPatientFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(389, 309);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(165, 36);
            this.cmdCancel.TabIndex = 13;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.ThemeName = "Aqua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSelect
            // 
            this.cmdSelect.Location = new System.Drawing.Point(131, 309);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(165, 36);
            this.cmdSelect.TabIndex = 12;
            this.cmdSelect.Text = "&Select";
            this.cmdSelect.ThemeName = "Aqua";
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // lstIndicators
            // 
            this.lstIndicators.Location = new System.Drawing.Point(177, 97);
            this.lstIndicators.Name = "lstIndicators";
            this.lstIndicators.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstIndicators.Size = new System.Drawing.Size(423, 142);
            this.lstIndicators.TabIndex = 11;
            this.lstIndicators.Text = "radListControl1";
            this.lstIndicators.ThemeName = "Aqua";
            // 
            // cboPatientFields
            // 
            this.cboPatientFields.Location = new System.Drawing.Point(177, 66);
            this.cboPatientFields.Name = "cboPatientFields";
            this.cboPatientFields.Size = new System.Drawing.Size(423, 27);
            this.cboPatientFields.TabIndex = 10;
            this.cboPatientFields.ThemeName = "Aqua";
            this.cboPatientFields.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboPatientFields_SelectedIndexChanged);
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel3.Location = new System.Drawing.Point(123, 257);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(439, 27);
            this.radLabel3.TabIndex = 9;
            this.radLabel3.Text = "Hold down the Shift key to make multiple selections";
            this.radLabel3.ThemeName = "Aqua";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel2.Location = new System.Drawing.Point(84, 97);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(87, 27);
            this.radLabel2.TabIndex = 8;
            this.radLabel2.Text = "Indicator:";
            this.radLabel2.ThemeName = "Aqua";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(47, 64);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(124, 27);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "Patient Fields:";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel4.Location = new System.Drawing.Point(145, 12);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(394, 27);
            this.radLabel4.TabIndex = 14;
            this.radLabel4.Text = "Note:  Fixed Fields Cannot be tied to Indicators";
            this.radLabel4.ThemeName = "Aqua";
            // 
            // frmSectionAddPatientField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 360);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.lstIndicators);
            this.Controls.Add(this.cboPatientFields);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSectionAddPatientField";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Add a Patient Field to the Selected Indicator";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmSectionAddPatientField_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstIndicators)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPatientFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadButton cmdCancel;
        private Telerik.WinControls.UI.RadButton cmdSelect;
        private Telerik.WinControls.UI.RadListControl lstIndicators;
        private Telerik.WinControls.UI.RadDropDownList cboPatientFields;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
