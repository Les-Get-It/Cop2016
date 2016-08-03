namespace COP2001
{
    partial class frmImportCopyValidation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportCopyValidation));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lstImportLayout = new Telerik.WinControls.UI.RadListControl();
            this.cmdCopy = new Telerik.WinControls.UI.RadButton();
            this.Command2 = new Telerik.WinControls.UI.RadButton();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstImportLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Command2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(9, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(566, 26);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Select the layout that you want to copy the validation messages from:";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // lstImportLayout
            // 
            this.lstImportLayout.Location = new System.Drawing.Point(9, 44);
            this.lstImportLayout.Name = "lstImportLayout";
            this.lstImportLayout.Size = new System.Drawing.Size(566, 165);
            this.lstImportLayout.TabIndex = 1;
            this.lstImportLayout.ThemeName = "Aqua";
            // 
            // cmdCopy
            // 
            this.cmdCopy.Location = new System.Drawing.Point(9, 215);
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Size = new System.Drawing.Size(291, 36);
            this.cmdCopy.TabIndex = 2;
            this.cmdCopy.Text = "Copy Validation &Messages";
            this.cmdCopy.ThemeName = "Aqua";
            this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
            // 
            // Command2
            // 
            this.Command2.Location = new System.Drawing.Point(358, 215);
            this.Command2.Name = "Command2";
            this.Command2.Size = new System.Drawing.Size(217, 36);
            this.Command2.TabIndex = 3;
            this.Command2.Text = "&Cancel";
            this.Command2.ThemeName = "Aqua";
            // 
            // frmImportCopyValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 260);
            this.Controls.Add(this.Command2);
            this.Controls.Add(this.cmdCopy);
            this.Controls.Add(this.lstImportLayout);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmImportCopyValidation";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Copy Validation Errors and Warnings";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmImportCopyValidation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstImportLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Command2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadListControl lstImportLayout;
        private Telerik.WinControls.UI.RadButton cmdCopy;
        private Telerik.WinControls.UI.RadButton Command2;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
