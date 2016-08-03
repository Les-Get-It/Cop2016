namespace COP2001
{
    partial class frmImportSelectLayout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportSelectLayout));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.dbgImportLayout = new Telerik.WinControls.UI.RadGridView();
            this.cmdSelect = new Telerik.WinControls.UI.RadButton();
            this.cmdUpdate = new Telerik.WinControls.UI.RadButton();
            this.cmdDelete = new Telerik.WinControls.UI.RadButton();
            this.cmdChangeStatus = new Telerik.WinControls.UI.RadButton();
            this.cmdAdd = new Telerik.WinControls.UI.RadButton();
            this.cmdClose = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtNewImportLayout = new Telerik.WinControls.UI.RadTextBox();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.dbgImportLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgImportLayout.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdChangeStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewImportLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dbgImportLayout
            // 
            this.dbgImportLayout.Location = new System.Drawing.Point(12, 12);
            // 
            // 
            // 
            this.dbgImportLayout.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dbgImportLayout.Name = "dbgImportLayout";
            this.dbgImportLayout.Size = new System.Drawing.Size(1066, 432);
            this.dbgImportLayout.TabIndex = 0;
            this.dbgImportLayout.ThemeName = "Aqua";
            // 
            // cmdSelect
            // 
            this.cmdSelect.Location = new System.Drawing.Point(120, 450);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(165, 36);
            this.cmdSelect.TabIndex = 1;
            this.cmdSelect.Text = "&Select";
            this.cmdSelect.ThemeName = "Aqua";
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(291, 450);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(165, 36);
            this.cmdUpdate.TabIndex = 2;
            this.cmdUpdate.Text = "&Update Desc.";
            this.cmdUpdate.ThemeName = "Aqua";
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(462, 450);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(165, 36);
            this.cmdDelete.TabIndex = 3;
            this.cmdDelete.Text = "&Delete";
            this.cmdDelete.ThemeName = "Aqua";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdChangeStatus
            // 
            this.cmdChangeStatus.Location = new System.Drawing.Point(633, 450);
            this.cmdChangeStatus.Name = "cmdChangeStatus";
            this.cmdChangeStatus.Size = new System.Drawing.Size(165, 36);
            this.cmdChangeStatus.TabIndex = 4;
            this.cmdChangeStatus.Text = "Chan&ge Status";
            this.cmdChangeStatus.ThemeName = "Aqua";
            this.cmdChangeStatus.Click += new System.EventHandler(this.cmdChangeStatus_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(804, 516);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(165, 36);
            this.cmdAdd.TabIndex = 5;
            this.cmdAdd.Text = "&Add";
            this.cmdAdd.ThemeName = "Aqua";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(804, 450);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(165, 36);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "&Close";
            this.cmdClose.ThemeName = "Aqua";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(121, 524);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(184, 24);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "New Layout (Desc.):";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // txtNewImportLayout
            // 
            this.txtNewImportLayout.Location = new System.Drawing.Point(322, 523);
            this.txtNewImportLayout.Name = "txtNewImportLayout";
            this.txtNewImportLayout.Size = new System.Drawing.Size(476, 27);
            this.txtNewImportLayout.TabIndex = 8;
            this.txtNewImportLayout.ThemeName = "Aqua";
            // 
            // frmImportSelectLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 568);
            this.Controls.Add(this.txtNewImportLayout);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdChangeStatus);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.dbgImportLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmImportSelectLayout";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Select the Layout";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmImportSelectLayout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbgImportLayout.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgImportLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdChangeStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewImportLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadGridView dbgImportLayout;
        //private cop2001currentDataSet cop2001currentDataSet;
        private Telerik.WinControls.UI.RadButton cmdSelect;
        private Telerik.WinControls.UI.RadButton cmdUpdate;
        private Telerik.WinControls.UI.RadButton cmdDelete;
        private Telerik.WinControls.UI.RadButton cmdChangeStatus;
        private Telerik.WinControls.UI.RadButton cmdAdd;
        private Telerik.WinControls.UI.RadButton cmdClose;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtNewImportLayout;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
