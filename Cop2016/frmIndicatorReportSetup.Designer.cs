namespace COP2001
{
    partial class frmIndicatorReportSetup
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndicatorReportSetup));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.cmbIndicators = new Telerik.WinControls.UI.RadDropDownList();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.Command2 = new Telerik.WinControls.UI.RadButton();
            this.Command1 = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.cmdReportUpdateDenominatorField = new Telerik.WinControls.UI.RadButton();
            this.dbgDenominatorFields = new Telerik.WinControls.UI.RadGridView();
            this.lstHeading = new Telerik.WinControls.UI.RadCheckedListBox();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIndicators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Command2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Command1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdReportUpdateDenominatorField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgDenominatorFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgDenominatorFields.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstHeading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.cmbIndicators);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 8.6F, System.Drawing.FontStyle.Bold);
            this.radGroupBox1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox1.HeaderText = "Select Indicator";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(901, 85);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Select Indicator";
            this.radGroupBox1.ThemeName = "Aqua";
            // 
            // cmbIndicators
            // 
            this.cmbIndicators.Location = new System.Drawing.Point(5, 39);
            this.cmbIndicators.Name = "cmbIndicators";
            this.cmbIndicators.Size = new System.Drawing.Size(891, 27);
            this.cmbIndicators.TabIndex = 0;
            this.cmbIndicators.ThemeName = "Aqua";
            this.cmbIndicators.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cmbIndicators_SelectedIndexChanged);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.Command2);
            this.radGroupBox2.Controls.Add(this.Command1);
            this.radGroupBox2.Controls.Add(this.radGroupBox3);
            this.radGroupBox2.Controls.Add(this.lstHeading);
            this.radGroupBox2.Font = new System.Drawing.Font("Segoe UI", 8.6F, System.Drawing.FontStyle.Bold);
            this.radGroupBox2.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox2.HeaderText = "Numerator Setup";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 103);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(901, 488);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Numerator Setup";
            this.radGroupBox2.ThemeName = "Aqua";
            // 
            // Command2
            // 
            this.Command2.Location = new System.Drawing.Point(193, 408);
            this.Command2.Name = "Command2";
            this.Command2.Size = new System.Drawing.Size(136, 36);
            this.Command2.TabIndex = 3;
            this.Command2.Text = "Move &Down";
            this.Command2.ThemeName = "Aqua";
            this.Command2.Click += new System.EventHandler(this.Command2_Click);
            // 
            // Command1
            // 
            this.Command1.Location = new System.Drawing.Point(5, 408);
            this.Command1.Name = "Command1";
            this.Command1.Size = new System.Drawing.Size(136, 36);
            this.Command1.TabIndex = 2;
            this.Command1.Text = "Move &Up";
            this.Command1.ThemeName = "Aqua";
            this.Command1.Click += new System.EventHandler(this.Command1_Click);
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.cmdReportUpdateDenominatorField);
            this.radGroupBox3.Controls.Add(this.dbgDenominatorFields);
            this.radGroupBox3.Font = new System.Drawing.Font("Segoe UI", 8.6F, System.Drawing.FontStyle.Bold);
            this.radGroupBox3.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox3.HeaderText = "Denominator Setup";
            this.radGroupBox3.Location = new System.Drawing.Point(335, 57);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(561, 394);
            this.radGroupBox3.TabIndex = 1;
            this.radGroupBox3.Text = "Denominator Setup";
            this.radGroupBox3.ThemeName = "Aqua";
            // 
            // cmdReportUpdateDenominatorField
            // 
            this.cmdReportUpdateDenominatorField.Location = new System.Drawing.Point(208, 341);
            this.cmdReportUpdateDenominatorField.Name = "cmdReportUpdateDenominatorField";
            this.cmdReportUpdateDenominatorField.Size = new System.Drawing.Size(136, 36);
            this.cmdReportUpdateDenominatorField.TabIndex = 4;
            this.cmdReportUpdateDenominatorField.Text = "Update &List";
            this.cmdReportUpdateDenominatorField.ThemeName = "Aqua";
            this.cmdReportUpdateDenominatorField.Click += new System.EventHandler(this.cmdReportUpdateDenominatorField_Click);
            // 
            // dbgDenominatorFields
            // 
            this.dbgDenominatorFields.Location = new System.Drawing.Point(5, 39);
            // 
            // 
            // 
            this.dbgDenominatorFields.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dbgDenominatorFields.Name = "dbgDenominatorFields";
            this.dbgDenominatorFields.Size = new System.Drawing.Size(551, 296);
            this.dbgDenominatorFields.TabIndex = 0;
            this.dbgDenominatorFields.ThemeName = "Aqua";
            this.dbgDenominatorFields.DoubleClick += new System.EventHandler(this.dbgDenominatorFields_DoubleClick);
            // 
            // lstHeading
            // 
            this.lstHeading.Location = new System.Drawing.Point(5, 70);
            this.lstHeading.Name = "lstHeading";
            this.lstHeading.Size = new System.Drawing.Size(324, 332);
            this.lstHeading.TabIndex = 0;
            this.lstHeading.ThemeName = "Aqua";
            this.lstHeading.SelectedIndexChanged += new System.EventHandler(this.lstHeading_SelectedIndexChanged);
            this.lstHeading.ItemCheckedChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.lstHeading_ItemCheckedChanged);
            // 
            // frmIndicatorReportSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 595);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmIndicatorReportSetup";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Indicator Report Setup";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmIndicatorReportSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIndicators)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Command2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Command1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmdReportUpdateDenominatorField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgDenominatorFields.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgDenominatorFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstHeading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadDropDownList cmbIndicators;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadGridView dbgDenominatorFields;
        //private cop2001currentDataSet cop2001currentDataSet;
        public Telerik.WinControls.UI.RadCheckedListBox lstHeading;
        private Telerik.WinControls.UI.RadButton Command2;
        private Telerik.WinControls.UI.RadButton Command1;
        private Telerik.WinControls.UI.RadButton cmdReportUpdateDenominatorField;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
