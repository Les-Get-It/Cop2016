namespace COP2001
{
    partial class frmValidationCopyCriteria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValidationCopyCriteria));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lblCopyFrom = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.cboWarning = new Telerik.WinControls.UI.RadDropDownList();
            this.cboError = new Telerik.WinControls.UI.RadDropDownList();
            this.rboWarning = new Telerik.WinControls.UI.RadRadioButton();
            this.rboError = new Telerik.WinControls.UI.RadRadioButton();
            this.cmdCopySetp = new Telerik.WinControls.UI.RadButton();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCopyFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rboWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rboError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCopySetp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel1.ForeColor = System.Drawing.Color.Firebrick;
            this.radLabel1.Location = new System.Drawing.Point(12, 41);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(55, 27);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Copy:";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // lblCopyFrom
            // 
            this.lblCopyFrom.AutoSize = false;
            this.lblCopyFrom.BorderVisible = true;
            this.lblCopyFrom.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCopyFrom.ForeColor = System.Drawing.Color.Blue;
            this.lblCopyFrom.Location = new System.Drawing.Point(73, 41);
            this.lblCopyFrom.Name = "lblCopyFrom";
            this.lblCopyFrom.Size = new System.Drawing.Size(902, 57);
            this.lblCopyFrom.TabIndex = 1;
            this.lblCopyFrom.Text = "This criteria";
            this.lblCopyFrom.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCopyFrom.ThemeName = "Aqua";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel3.ForeColor = System.Drawing.Color.Firebrick;
            this.radLabel3.Location = new System.Drawing.Point(33, 142);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(34, 27);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "To:";
            this.radLabel3.ThemeName = "Aqua";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.cboWarning);
            this.radGroupBox1.Controls.Add(this.cboError);
            this.radGroupBox1.Controls.Add(this.rboWarning);
            this.radGroupBox1.Controls.Add(this.rboError);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(73, 142);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(902, 150);
            this.radGroupBox1.TabIndex = 3;
            this.radGroupBox1.ThemeName = "Aqua";
            // 
            // cboWarning
            // 
            this.cboWarning.Location = new System.Drawing.Point(152, 83);
            this.cboWarning.Name = "cboWarning";
            this.cboWarning.Size = new System.Drawing.Size(730, 27);
            this.cboWarning.TabIndex = 3;
            this.cboWarning.ThemeName = "Aqua";
            // 
            // cboError
            // 
            this.cboError.Location = new System.Drawing.Point(152, 40);
            this.cboError.Name = "cboError";
            this.cboError.Size = new System.Drawing.Size(730, 27);
            this.cboError.TabIndex = 2;
            this.cboError.ThemeName = "Aqua";
            // 
            // rboWarning
            // 
            this.rboWarning.Location = new System.Drawing.Point(32, 83);
            this.rboWarning.Name = "rboWarning";
            this.rboWarning.Size = new System.Drawing.Size(114, 26);
            this.rboWarning.TabIndex = 1;
            this.rboWarning.Text = "Warning:";
            this.rboWarning.ThemeName = "Aqua";
            // 
            // rboError
            // 
            this.rboError.Location = new System.Drawing.Point(37, 37);
            this.rboError.Name = "rboError";
            this.rboError.Size = new System.Drawing.Size(109, 26);
            this.rboError.TabIndex = 0;
            this.rboError.Text = "    Error:";
            this.rboError.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.rboError.ThemeName = "Aqua";
            // 
            // cmdCopySetp
            // 
            this.cmdCopySetp.Location = new System.Drawing.Point(268, 310);
            this.cmdCopySetp.Name = "cmdCopySetp";
            this.cmdCopySetp.Size = new System.Drawing.Size(232, 36);
            this.cmdCopySetp.TabIndex = 4;
            this.cmdCopySetp.Text = "Copy Entire &Message";
            this.cmdCopySetp.ThemeName = "Aqua";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(536, 310);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(182, 36);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.ThemeName = "Aqua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmValidationCopyCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 354);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdCopySetp);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.lblCopyFrom);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmValidationCopyCriteria";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Copy Measure Criteria";
            this.ThemeName = "Aqua";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmValidationCopyCriteria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCopyFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rboWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rboError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCopySetp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel lblCopyFrom;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadRadioButton rboError;
        private Telerik.WinControls.UI.RadDropDownList cboWarning;
        private Telerik.WinControls.UI.RadDropDownList cboError;
        private Telerik.WinControls.UI.RadRadioButton rboWarning;
        private Telerik.WinControls.UI.RadButton cmdCopySetp;
        private Telerik.WinControls.UI.RadButton cmdCancel;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
