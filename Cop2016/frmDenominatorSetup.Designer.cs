namespace COP2001
{
    partial class frmDenominatorSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDenominatorSetup));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.SSTab1 = new Telerik.WinControls.UI.Docking.RadDock();
            this.SSTab1Summaries = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.lstSummaryFields = new Telerik.WinControls.UI.RadCheckedListBox();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.SSTab1Utilization = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.lstUtilizationFields = new Telerik.WinControls.UI.RadCheckedListBox();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.SSTab1)).BeginInit();
            this.SSTab1.SuspendLayout();
            this.SSTab1Summaries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstSummaryFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            this.documentContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            this.documentTabStrip1.SuspendLayout();
            this.SSTab1Utilization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstUtilizationFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // SSTab1
            // 
            this.SSTab1.ActiveWindow = this.SSTab1Summaries;
            this.SSTab1.Controls.Add(this.documentContainer1);
            this.SSTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SSTab1.IsCleanUpTarget = true;
            this.SSTab1.Location = new System.Drawing.Point(0, 0);
            this.SSTab1.MainDocumentContainer = this.documentContainer1;
            this.SSTab1.Name = "SSTab1";
            this.SSTab1.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.SSTab1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.SSTab1.Size = new System.Drawing.Size(1080, 477);
            this.SSTab1.SplitterWidth = 3;
            this.SSTab1.TabIndex = 0;
            this.SSTab1.TabStop = false;
            this.SSTab1.ThemeName = "Aqua";
            // 
            // SSTab1Summaries
            // 
            this.SSTab1Summaries.Controls.Add(this.lstSummaryFields);
            this.SSTab1Summaries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSTab1Summaries.Location = new System.Drawing.Point(4, 38);
            this.SSTab1Summaries.Name = "SSTab1Summaries";
            this.SSTab1Summaries.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.SSTab1Summaries.Size = new System.Drawing.Size(1072, 435);
            this.SSTab1Summaries.Text = "Summaries";
            // 
            // lstSummaryFields
            // 
            this.lstSummaryFields.Location = new System.Drawing.Point(3, 3);
            this.lstSummaryFields.Name = "lstSummaryFields";
            this.lstSummaryFields.Size = new System.Drawing.Size(1034, 404);
            this.lstSummaryFields.TabIndex = 0;
            this.lstSummaryFields.ThemeName = "Aqua";
            this.lstSummaryFields.ItemCheckedChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.lstSummaryFields_ItemCheckedChanged);
            // 
            // documentContainer1
            // 
            this.documentContainer1.Controls.Add(this.documentTabStrip1);
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer1.SplitterWidth = 3;
            this.documentContainer1.ThemeName = "Aqua";
            // 
            // documentTabStrip1
            // 
            this.documentTabStrip1.CanUpdateChildIndex = true;
            this.documentTabStrip1.Controls.Add(this.SSTab1Summaries);
            this.documentTabStrip1.Controls.Add(this.SSTab1Utilization);
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentTabStrip1.SelectedIndex = 0;
            this.documentTabStrip1.Size = new System.Drawing.Size(1080, 477);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            this.documentTabStrip1.ThemeName = "Aqua";
            // 
            // SSTab1Utilization
            // 
            this.SSTab1Utilization.Controls.Add(this.lstUtilizationFields);
            this.SSTab1Utilization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSTab1Utilization.Location = new System.Drawing.Point(4, 38);
            this.SSTab1Utilization.Name = "SSTab1Utilization";
            this.SSTab1Utilization.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.SSTab1Utilization.Size = new System.Drawing.Size(1072, 435);
            this.SSTab1Utilization.Text = "Utilization";
            // 
            // lstUtilizationFields
            // 
            this.lstUtilizationFields.Location = new System.Drawing.Point(3, 3);
            this.lstUtilizationFields.Name = "lstUtilizationFields";
            this.lstUtilizationFields.Size = new System.Drawing.Size(1034, 404);
            this.lstUtilizationFields.TabIndex = 1;
            this.lstUtilizationFields.ThemeName = "Aqua";
            this.lstUtilizationFields.ItemCheckedChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.lstUtilizationFields_ItemCheckedChanged);
            // 
            // frmDenominatorSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 477);
            this.Controls.Add(this.SSTab1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmDenominatorSetup";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Denominator Setup";
            this.ThemeName = "Aqua";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDenominatorSetup_FormClosed);
            this.Load += new System.EventHandler(this.frmDenominatorSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SSTab1)).EndInit();
            this.SSTab1.ResumeLayout(false);
            this.SSTab1Summaries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstSummaryFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            this.documentContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            this.documentTabStrip1.ResumeLayout(false);
            this.SSTab1Utilization.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstUtilizationFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.Docking.RadDock SSTab1;
        private Telerik.WinControls.UI.Docking.DocumentWindow SSTab1Summaries;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;
        private Telerik.WinControls.UI.Docking.DocumentWindow SSTab1Utilization;
        private Telerik.WinControls.UI.RadCheckedListBox lstUtilizationFields;
        private Telerik.WinControls.UI.RadCheckedListBox lstSummaryFields;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
