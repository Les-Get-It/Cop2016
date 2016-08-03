namespace COP2001
{
    partial class frmImportAddValidField
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportAddValidField));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cboImportFields = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtMessage = new Telerik.WinControls.UI.RadTextBox();
            this.cmdAdd = new Telerik.WinControls.UI.RadButton();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboImportFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(304, 19);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(78, 26);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Field List";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // cboImportFields
            // 
            this.cboImportFields.Location = new System.Drawing.Point(60, 51);
            this.cboImportFields.Name = "cboImportFields";
            this.cboImportFields.Size = new System.Drawing.Size(566, 27);
            this.cboImportFields.TabIndex = 1;
            this.cboImportFields.ThemeName = "Aqua";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel2.Location = new System.Drawing.Point(305, 105);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(77, 26);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Message";
            this.radLabel2.ThemeName = "Aqua";
            // 
            // txtMessage
            // 
            this.txtMessage.AutoSize = false;
            this.txtMessage.Location = new System.Drawing.Point(60, 137);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(566, 161);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.ThemeName = "Aqua";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(158, 319);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(165, 36);
            this.cmdAdd.TabIndex = 4;
            this.cmdAdd.Text = "&Add";
            this.cmdAdd.ThemeName = "Aqua";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(363, 319);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(165, 36);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.ThemeName = "Aqua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmImportAddValidField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 375);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.cboImportFields);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmImportAddValidField";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Select a field for a new validation";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmImportAddValidField_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboImportFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList cboImportFields;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtMessage;
        public Telerik.WinControls.UI.RadButton cmdAdd;
        private Telerik.WinControls.UI.RadButton cmdCancel;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
