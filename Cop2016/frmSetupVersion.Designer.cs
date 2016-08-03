namespace COP2001
{
    partial class frmSetupVersion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetupVersion));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.cmdReset = new Telerik.WinControls.UI.RadButton();
            this.dbgVersionHistory = new Telerik.WinControls.UI.RadGridView();
            this.cmdDelete = new Telerik.WinControls.UI.RadButton();
            this.cmdEdit = new Telerik.WinControls.UI.RadButton();
            this.txtNotes = new Telerik.WinControls.UI.RadTextBox();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.cmdReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgVersionHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgVersionHistory.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdReset
            // 
            this.cmdReset.Location = new System.Drawing.Point(169, 429);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(165, 36);
            this.cmdReset.TabIndex = 3;
            this.cmdReset.Text = "&Reset";
            this.cmdReset.ThemeName = "Aqua";
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
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
            this.dbgVersionHistory.Size = new System.Drawing.Size(1129, 416);
            this.dbgVersionHistory.TabIndex = 2;
            this.dbgVersionHistory.ThemeName = "Aqua";
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(595, 429);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(165, 36);
            this.cmdDelete.TabIndex = 4;
            this.cmdDelete.Text = "&Delete";
            this.cmdDelete.ThemeName = "Aqua";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(382, 429);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(165, 36);
            this.cmdEdit.TabIndex = 5;
            this.cmdEdit.Text = "&Edit";
            this.cmdEdit.ThemeName = "Aqua";
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(808, 434);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(150, 27);
            this.txtNotes.TabIndex = 6;
            this.txtNotes.ThemeName = "Aqua";
            // 
            // frmSetupVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 477);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.dbgVersionHistory);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSetupVersion";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Setup Version History";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmSetupVersion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmdReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgVersionHistory.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgVersionHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadButton cmdReset;
        private Telerik.WinControls.UI.RadGridView dbgVersionHistory;
        private Telerik.WinControls.UI.RadButton cmdDelete;
        private Telerik.WinControls.UI.RadButton cmdEdit;
        public Telerik.WinControls.UI.RadTextBox txtNotes;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
