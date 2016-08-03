namespace COP2001
{
    partial class frmSetupStateVersion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetupStateVersion));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.dbgVersionHistory = new Telerik.WinControls.UI.RadGridView();
            this.cmdReset = new Telerik.WinControls.UI.RadButton();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.dbgVersionHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgVersionHistory.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dbgVersionHistory
            // 
            this.dbgVersionHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.dbgVersionHistory.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.dbgVersionHistory.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dbgVersionHistory.Name = "dbgVersionHistory";
            this.dbgVersionHistory.Size = new System.Drawing.Size(1136, 424);
            this.dbgVersionHistory.TabIndex = 0;
            this.dbgVersionHistory.ThemeName = "Aqua";
            // 
            // cmdReset
            // 
            this.cmdReset.Location = new System.Drawing.Point(486, 444);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(165, 36);
            this.cmdReset.TabIndex = 1;
            this.cmdReset.Text = "&Reset";
            this.cmdReset.ThemeName = "Aqua";
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // frmSetupStateVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 488);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.dbgVersionHistory);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSetupStateVersion";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "State Setup Version History";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmSetupStateVersion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbgVersionHistory.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgVersionHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadGridView dbgVersionHistory;
        //private System.Windows.Forms.BindingSource cop2001currentDataSetBindingSource;
        //private cop2001currentDataSet cop2001currentDataSet;
        private Telerik.WinControls.UI.RadButton cmdReset;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
