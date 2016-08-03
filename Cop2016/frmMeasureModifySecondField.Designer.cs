namespace COP2001
{
    partial class frmMeasureModifySecondField
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMeasureModifySecondField));
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            this.cmdUpdate = new Telerik.WinControls.UI.RadButton();
            this.cboDestField = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDestField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(306, 91);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(165, 36);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.ThemeName = "Aqua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(135, 91);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(165, 36);
            this.cmdUpdate.TabIndex = 6;
            this.cmdUpdate.Text = "&Update";
            this.cmdUpdate.ThemeName = "Aqua";
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cboDestField
            // 
            this.cboDestField.Location = new System.Drawing.Point(167, 31);
            this.cboDestField.Name = "cboDestField";
            this.cboDestField.Size = new System.Drawing.Size(365, 27);
            this.cboDestField.TabIndex = 5;
            this.cboDestField.ThemeName = "Aqua";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(74, 31);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(87, 27);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Operator:";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // frmMeasureModifySecondField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 153);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.cboDestField);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMeasureModifySecondField";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Modify Second Field of criteria";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmMeasureModifySecondField_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDestField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton cmdCancel;
        private Telerik.WinControls.UI.RadButton cmdUpdate;
        private Telerik.WinControls.UI.RadDropDownList cboDestField;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
