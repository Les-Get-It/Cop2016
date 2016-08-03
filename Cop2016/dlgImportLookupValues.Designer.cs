namespace COP2001
{
    partial class dlgImportLookupValues
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgImportLookupValues));
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.OptInsert = new Telerik.WinControls.UI.RadRadioButton();
            this.OptDelete = new Telerik.WinControls.UI.RadRadioButton();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.chkStripDecimal = new Telerik.WinControls.UI.RadCheckBox();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.OptValue = new Telerik.WinControls.UI.RadRadioButton();
            this.optID = new Telerik.WinControls.UI.RadRadioButton();
            this.OKButton = new Telerik.WinControls.UI.RadButton();
            this.CancelButton = new Telerik.WinControls.UI.RadButton();
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkStripDecimal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OKButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.OptInsert);
            this.radGroupBox1.Controls.Add(this.OptDelete);
            this.radGroupBox1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox1.HeaderText = "Overwrite Previous Values or Add:";
            this.radGroupBox1.Location = new System.Drawing.Point(13, 13);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(480, 150);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Overwrite Previous Values or Add:";
            this.radGroupBox1.ThemeName = "Aqua";
            // 
            // OptInsert
            // 
            this.OptInsert.Location = new System.Drawing.Point(6, 79);
            this.OptInsert.Name = "OptInsert";
            this.OptInsert.Size = new System.Drawing.Size(435, 26);
            this.OptInsert.TabIndex = 1;
            this.OptInsert.Text = "Add Values in Addition to Existing Values";
            this.OptInsert.ThemeName = "Aqua";
            // 
            // OptDelete
            // 
            this.OptDelete.Location = new System.Drawing.Point(6, 45);
            this.OptDelete.Name = "OptDelete";
            this.OptDelete.Size = new System.Drawing.Size(352, 26);
            this.OptDelete.TabIndex = 0;
            this.OptDelete.Text = "Overwrite (Deleta All old Values)";
            this.OptDelete.ThemeName = "Aqua";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.chkStripDecimal);
            this.radGroupBox2.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox2.HeaderText = "Strip:";
            this.radGroupBox2.Location = new System.Drawing.Point(13, 180);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(718, 80);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Strip:";
            this.radGroupBox2.ThemeName = "Aqua";
            // 
            // chkStripDecimal
            // 
            this.chkStripDecimal.Location = new System.Drawing.Point(245, 37);
            this.chkStripDecimal.Name = "chkStripDecimal";
            this.chkStripDecimal.Size = new System.Drawing.Size(175, 26);
            this.chkStripDecimal.TabIndex = 0;
            this.chkStripDecimal.Text = "Decimal Values";
            this.chkStripDecimal.ThemeName = "Aqua";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.OptValue);
            this.radGroupBox3.Controls.Add(this.optID);
            this.radGroupBox3.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox3.HeaderText = "First Value in List are:";
            this.radGroupBox3.Location = new System.Drawing.Point(499, 13);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(232, 150);
            this.radGroupBox3.TabIndex = 2;
            this.radGroupBox3.Text = "First Value in List are:";
            this.radGroupBox3.ThemeName = "Aqua";
            // 
            // OptValue
            // 
            this.OptValue.Location = new System.Drawing.Point(6, 79);
            this.OptValue.Name = "OptValue";
            this.OptValue.Size = new System.Drawing.Size(157, 26);
            this.OptValue.TabIndex = 1;
            this.OptValue.Text = "Lookup Value";
            this.OptValue.ThemeName = "Aqua";
            // 
            // optID
            // 
            this.optID.Location = new System.Drawing.Point(6, 45);
            this.optID.Name = "optID";
            this.optID.Size = new System.Drawing.Size(45, 26);
            this.optID.TabIndex = 0;
            this.optID.Text = "ID";
            this.optID.ThemeName = "Aqua";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(779, 82);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(165, 36);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "&Ok";
            this.OKButton.ThemeName = "Aqua";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(779, 163);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(165, 36);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "&Cancel";
            this.CancelButton.ThemeName = "Aqua";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // dlgImportLookupValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 272);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "dlgImportLookupValues";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Import Lookup Values";
            this.ThemeName = "Aqua";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkStripDecimal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.radGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OKButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadRadioButton OptInsert;
        private Telerik.WinControls.UI.RadRadioButton OptDelete;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadCheckBox chkStripDecimal;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadRadioButton OptValue;
        private Telerik.WinControls.UI.RadRadioButton optID;
        private Telerik.WinControls.UI.RadButton OKButton;
        private Telerik.WinControls.UI.RadButton CancelButton;
        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
