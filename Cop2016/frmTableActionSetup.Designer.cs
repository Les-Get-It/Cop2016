namespace COP2001
{
    partial class frmTableActionSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTableActionSetup));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.lstAvailableActions = new Telerik.WinControls.UI.RadListControl();
            this.lstAppliedActions = new Telerik.WinControls.UI.RadListControl();
            this.lblFieldName = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.cmdAddAction = new Telerik.WinControls.UI.RadButton();
            this.cmdRemoveAction = new Telerik.WinControls.UI.RadButton();
            this.cmdClose = new Telerik.WinControls.UI.RadButton();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.lstAvailableActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstAppliedActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFieldName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdRemoveAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lstAvailableActions
            // 
            this.lstAvailableActions.Location = new System.Drawing.Point(12, 128);
            this.lstAvailableActions.Name = "lstAvailableActions";
            this.lstAvailableActions.Size = new System.Drawing.Size(544, 442);
            this.lstAvailableActions.TabIndex = 0;
            this.lstAvailableActions.ThemeName = "Aqua";
            // 
            // lstAppliedActions
            // 
            this.lstAppliedActions.Location = new System.Drawing.Point(754, 128);
            this.lstAppliedActions.Name = "lstAppliedActions";
            this.lstAppliedActions.Size = new System.Drawing.Size(544, 442);
            this.lstAppliedActions.TabIndex = 1;
            this.lstAppliedActions.ThemeName = "Aqua";
            // 
            // lblFieldName
            // 
            this.lblFieldName.AutoSize = false;
            this.lblFieldName.BorderVisible = true;
            this.lblFieldName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFieldName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFieldName.ForeColor = System.Drawing.Color.Firebrick;
            this.lblFieldName.Location = new System.Drawing.Point(0, 0);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(1321, 58);
            this.lblFieldName.TabIndex = 2;
            this.lblFieldName.Text = "Field Name";
            this.lblFieldName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFieldName.ThemeName = "Aqua";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(210, 96);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(151, 26);
            this.radLabel1.TabIndex = 3;
            this.radLabel1.Text = "Available  Actions";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel2.Location = new System.Drawing.Point(954, 96);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(135, 26);
            this.radLabel2.TabIndex = 4;
            this.radLabel2.Text = "Applied Actions";
            this.radLabel2.ThemeName = "Aqua";
            // 
            // cmdAddAction
            // 
            this.cmdAddAction.Location = new System.Drawing.Point(571, 239);
            this.cmdAddAction.Name = "cmdAddAction";
            this.cmdAddAction.Size = new System.Drawing.Size(165, 36);
            this.cmdAddAction.TabIndex = 5;
            this.cmdAddAction.Text = ">>";
            this.cmdAddAction.ThemeName = "Aqua";
            this.cmdAddAction.Click += new System.EventHandler(this.cmdAddAction_Click);
            // 
            // cmdRemoveAction
            // 
            this.cmdRemoveAction.Location = new System.Drawing.Point(571, 338);
            this.cmdRemoveAction.Name = "cmdRemoveAction";
            this.cmdRemoveAction.Size = new System.Drawing.Size(165, 36);
            this.cmdRemoveAction.TabIndex = 6;
            this.cmdRemoveAction.Text = "<<";
            this.cmdRemoveAction.ThemeName = "Aqua";
            this.cmdRemoveAction.Click += new System.EventHandler(this.cmdRemoveAction_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(571, 437);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(165, 36);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "&Close";
            this.cmdClose.ThemeName = "Aqua";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmTableActionSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 598);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdRemoveAction);
            this.Controls.Add(this.cmdAddAction);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.lblFieldName);
            this.Controls.Add(this.lstAppliedActions);
            this.Controls.Add(this.lstAvailableActions);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmTableActionSetup";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Data Entry Actions";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmTableActionSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lstAvailableActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstAppliedActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFieldName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdRemoveAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadListControl lstAvailableActions;
        private Telerik.WinControls.UI.RadListControl lstAppliedActions;
        private Telerik.WinControls.UI.RadLabel lblFieldName;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton cmdAddAction;
        private Telerik.WinControls.UI.RadButton cmdRemoveAction;
        private Telerik.WinControls.UI.RadButton cmdClose;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
