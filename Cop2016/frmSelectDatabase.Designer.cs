namespace COP2001
{
    partial class frmSelectDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectDatabase));
            this.Frame1 = new Telerik.WinControls.UI.RadGroupBox();
            this.optArchive = new Telerik.WinControls.UI.RadRadioButton();
            this.optCurrent = new Telerik.WinControls.UI.RadRadioButton();
            this.optIHHA = new Telerik.WinControls.UI.RadRadioButton();
            this.cmdConnect = new Telerik.WinControls.UI.RadButton();
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.Frame1)).BeginInit();
            this.Frame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optArchive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optIHHA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Frame1
            // 
            this.Frame1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.Frame1.Controls.Add(this.optArchive);
            this.Frame1.Controls.Add(this.optCurrent);
            this.Frame1.Controls.Add(this.optIHHA);
            this.Frame1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.Frame1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.Frame1.HeaderText = "Select a Database to Connect to:";
            this.Frame1.Location = new System.Drawing.Point(60, 12);
            this.Frame1.Name = "Frame1";
            this.Frame1.Size = new System.Drawing.Size(398, 165);
            this.Frame1.TabIndex = 0;
            this.Frame1.Text = "Select a Database to Connect to:";
            this.Frame1.ThemeName = "Aqua";
            // 
            // optArchive
            // 
            this.optArchive.Location = new System.Drawing.Point(6, 113);
            this.optArchive.Name = "optArchive";
            this.optArchive.Size = new System.Drawing.Size(103, 26);
            this.optArchive.TabIndex = 3;
            this.optArchive.Text = "Archive ";
            this.optArchive.ThemeName = "Aqua";
            // 
            // optCurrent
            // 
            this.optCurrent.Location = new System.Drawing.Point(6, 81);
            this.optCurrent.Name = "optCurrent";
            this.optCurrent.Size = new System.Drawing.Size(369, 26);
            this.optCurrent.TabIndex = 2;
            this.optCurrent.Text = "Current (To process hospital data)";
            this.optCurrent.ThemeName = "Aqua";
            // 
            // optIHHA
            // 
            this.optIHHA.Location = new System.Drawing.Point(6, 49);
            this.optIHHA.Name = "optIHHA";
            this.optIHHA.Size = new System.Drawing.Size(334, 26);
            this.optIHHA.TabIndex = 1;
            this.optIHHA.Text = "IHHA (To accept new changes)";
            this.optIHHA.ThemeName = "Aqua";
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(177, 195);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(165, 36);
            this.cmdConnect.TabIndex = 1;
            this.cmdConnect.Text = "&Connect";
            this.cmdConnect.ThemeName = "Aqua";
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // frmSelectDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 243);
            this.Controls.Add(this.cmdConnect);
            this.Controls.Add(this.Frame1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSelectDatabase";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Select Database";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmSelectDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Frame1)).EndInit();
            this.Frame1.ResumeLayout(false);
            this.Frame1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optArchive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optIHHA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGroupBox Frame1;
        private Telerik.WinControls.UI.RadRadioButton optArchive;
        private Telerik.WinControls.UI.RadRadioButton optCurrent;
        private Telerik.WinControls.UI.RadRadioButton optIHHA;
        private Telerik.WinControls.UI.RadButton cmdConnect;
        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
