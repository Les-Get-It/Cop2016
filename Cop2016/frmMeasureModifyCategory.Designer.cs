namespace COP2001
{
    partial class frmMeasureModifyCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMeasureModifyCategory));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.lblCat = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cboCat = new Telerik.WinControls.UI.RadDropDownList();
            this.txtGoToStep = new Telerik.WinControls.UI.RadTextBox();
            this.cmdUpdate = new Telerik.WinControls.UI.RadButton();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.lblCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoToStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCat
            // 
            this.lblCat.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCat.ForeColor = System.Drawing.Color.Blue;
            this.lblCat.Location = new System.Drawing.Point(160, 52);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(152, 27);
            this.lblCat.TabIndex = 0;
            this.lblCat.Text = "Modify Category:";
            this.lblCat.ThemeName = "Aqua";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel1.ForeColor = System.Drawing.Color.Blue;
            this.radLabel1.Location = new System.Drawing.Point(102, 85);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(210, 27);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "[OR]  Define Go To Step:";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // cboCat
            // 
            this.cboCat.Location = new System.Drawing.Point(318, 52);
            this.cboCat.Name = "cboCat";
            this.cboCat.Size = new System.Drawing.Size(187, 27);
            this.cboCat.TabIndex = 2;
            this.cboCat.ThemeName = "Aqua";
            // 
            // txtGoToStep
            // 
            this.txtGoToStep.Location = new System.Drawing.Point(318, 85);
            this.txtGoToStep.Name = "txtGoToStep";
            this.txtGoToStep.Size = new System.Drawing.Size(187, 27);
            this.txtGoToStep.TabIndex = 3;
            this.txtGoToStep.ThemeName = "Aqua";
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(135, 153);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(165, 36);
            this.cmdUpdate.TabIndex = 4;
            this.cmdUpdate.Text = "&Update";
            this.cmdUpdate.ThemeName = "Aqua";
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(306, 153);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(165, 36);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.ThemeName = "Aqua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmMeasureModifyCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 213);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.txtGoToStep);
            this.Controls.Add(this.cboCat);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.lblCat);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMeasureModifyCategory";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Modify Category/Go To Step Assignment";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmMeasureModifyCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoToStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadLabel lblCat;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList cboCat;
        private Telerik.WinControls.UI.RadTextBox txtGoToStep;
        private Telerik.WinControls.UI.RadButton cmdUpdate;
        private Telerik.WinControls.UI.RadButton cmdCancel;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
