namespace COP2001
{
    partial class dlgSyncMeasure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgSyncMeasure));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.OptArchive = new Telerik.WinControls.UI.RadRadioButton();
            this.OptCurrent = new Telerik.WinControls.UI.RadRadioButton();
            this.OptIHHA = new Telerik.WinControls.UI.RadRadioButton();
            this.OKButton = new Telerik.WinControls.UI.RadButton();
            this.CancelButton = new Telerik.WinControls.UI.RadButton();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptArchive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptIHHA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OKButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.OptArchive);
            this.radGroupBox1.Controls.Add(this.OptCurrent);
            this.radGroupBox1.Controls.Add(this.OptIHHA);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radGroupBox1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox1.HeaderText = "COP Setup Databases";
            this.radGroupBox1.Location = new System.Drawing.Point(52, 30);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(434, 178);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "COP Setup Databases";
            this.radGroupBox1.ThemeName = "Aqua";
            // 
            // OptArchive
            // 
            this.OptArchive.Location = new System.Drawing.Point(154, 110);
            this.OptArchive.Name = "OptArchive";
            this.OptArchive.Size = new System.Drawing.Size(96, 26);
            this.OptArchive.TabIndex = 2;
            this.OptArchive.Text = "Archive";
            this.OptArchive.ThemeName = "Aqua";
            // 
            // OptCurrent
            // 
            this.OptCurrent.Location = new System.Drawing.Point(154, 78);
            this.OptCurrent.Name = "OptCurrent";
            this.OptCurrent.Size = new System.Drawing.Size(97, 26);
            this.OptCurrent.TabIndex = 1;
            this.OptCurrent.Text = "Current";
            this.OptCurrent.ThemeName = "Aqua";
            // 
            // OptIHHA
            // 
            this.OptIHHA.Location = new System.Drawing.Point(154, 46);
            this.OptIHHA.Name = "OptIHHA";
            this.OptIHHA.Size = new System.Drawing.Size(73, 26);
            this.OptIHHA.TabIndex = 0;
            this.OptIHHA.Text = "IHHA";
            this.OptIHHA.ThemeName = "Aqua";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(492, 80);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(165, 36);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "&Ok";
            this.OKButton.ThemeName = "Aqua";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(492, 122);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(165, 36);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "&Cancel";
            this.CancelButton.ThemeName = "Aqua";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // dlgSyncMeasure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 234);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.radGroupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "dlgSyncMeasure";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Dialog Caption";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.dlgSyncMeasure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptArchive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptIHHA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OKButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadRadioButton OptArchive;
        private Telerik.WinControls.UI.RadRadioButton OptCurrent;
        private Telerik.WinControls.UI.RadRadioButton OptIHHA;
        private Telerik.WinControls.UI.RadButton OKButton;
        private Telerik.WinControls.UI.RadButton CancelButton;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
