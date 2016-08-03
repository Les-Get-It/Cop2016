namespace COP2001
{
    partial class dlgValidationRightField
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgValidationRightField));
            this.Label1 = new Telerik.WinControls.UI.RadLabel();
            this.Label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtPreviousField = new Telerik.WinControls.UI.RadTextBox();
            this.cboField = new Telerik.WinControls.UI.RadDropDownList();
            this.OKButton = new Telerik.WinControls.UI.RadButton();
            this.CancelButton = new Telerik.WinControls.UI.RadButton();
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreviousField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OKButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Label1.Location = new System.Drawing.Point(13, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(59, 28);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "From:";
            this.Label1.ThemeName = "Aqua";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Label2.Location = new System.Drawing.Point(13, 70);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(36, 28);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "To:";
            this.Label2.ThemeName = "Aqua";
            // 
            // txtPreviousField
            // 
            this.txtPreviousField.Location = new System.Drawing.Point(78, 17);
            this.txtPreviousField.Name = "txtPreviousField";
            this.txtPreviousField.Size = new System.Drawing.Size(527, 27);
            this.txtPreviousField.TabIndex = 2;
            this.txtPreviousField.ThemeName = "Aqua";
            // 
            // cboField
            // 
            this.cboField.Location = new System.Drawing.Point(79, 72);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(527, 27);
            this.cboField.TabIndex = 3;
            this.cboField.ThemeName = "Aqua";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(637, 12);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(165, 36);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "&Ok";
            this.OKButton.ThemeName = "Aqua";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(637, 62);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(165, 36);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "&Cancel";
            this.CancelButton.ThemeName = "Aqua";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // dlgValidationRightField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 119);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.txtPreviousField);
            this.Controls.Add(this.cboField);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "dlgValidationRightField";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Change Field";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.dlgValidationRightField_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreviousField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OKButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel Label1;
        private Telerik.WinControls.UI.RadLabel Label2;
        private Telerik.WinControls.UI.RadTextBox txtPreviousField;
        private Telerik.WinControls.UI.RadDropDownList cboField;
        private Telerik.WinControls.UI.RadButton OKButton;
        private Telerik.WinControls.UI.RadButton CancelButton;
        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
