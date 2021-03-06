﻿namespace COP2001
{
    partial class frmIndicatorAddDep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndicatorAddDep));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.lstIndicators = new Telerik.WinControls.UI.RadListControl();
            this.cmdSelect = new Telerik.WinControls.UI.RadButton();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstIndicators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(12, 88);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(92, 28);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Indicator:";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.radLabel2.Location = new System.Drawing.Point(165, 268);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(465, 28);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Hold down the Shift key to make multiple selections";
            this.radLabel2.ThemeName = "Aqua";
            // 
            // lstIndicators
            // 
            this.lstIndicators.Location = new System.Drawing.Point(126, 12);
            this.lstIndicators.Name = "lstIndicators";
            this.lstIndicators.Size = new System.Drawing.Size(646, 240);
            this.lstIndicators.TabIndex = 2;
            this.lstIndicators.ThemeName = "Aqua";
            // 
            // cmdSelect
            // 
            this.cmdSelect.Location = new System.Drawing.Point(200, 302);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(165, 36);
            this.cmdSelect.TabIndex = 3;
            this.cmdSelect.Text = "&Select";
            this.cmdSelect.ThemeName = "Aqua";
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(430, 302);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(165, 36);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.ThemeName = "Aqua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmIndicatorAddDep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 345);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.lstIndicators);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmIndicatorAddDep";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Define the Required Indicators for the Selected Indicator";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmIndicatorAddDep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstIndicators)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadListControl lstIndicators;
        private Telerik.WinControls.UI.RadButton cmdSelect;
        private Telerik.WinControls.UI.RadButton cmdCancel;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
