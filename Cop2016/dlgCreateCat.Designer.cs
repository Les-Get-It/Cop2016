namespace COP2001
{
    partial class dlgCreateCat
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCreateCat));
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtCatID = new Telerik.WinControls.UI.RadTextBox();
            this.txtCatDesc = new Telerik.WinControls.UI.RadTextBox();
            this.cboType = new Telerik.WinControls.UI.RadDropDownList();
            this.OKButton = new Telerik.WinControls.UI.RadButton();
            this.CancelButton = new Telerik.WinControls.UI.RadButton();
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCatID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCatDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OKButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(79, 33);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(31, 26);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "ID:";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel2.Location = new System.Drawing.Point(60, 90);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(50, 26);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Desc:";
            this.radLabel2.ThemeName = "Aqua";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel3.Location = new System.Drawing.Point(59, 142);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(51, 26);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "Type:";
            this.radLabel3.ThemeName = "Aqua";
            // 
            // txtCatID
            // 
            this.txtCatID.Location = new System.Drawing.Point(116, 32);
            this.txtCatID.Name = "txtCatID";
            this.txtCatID.Size = new System.Drawing.Size(92, 27);
            this.txtCatID.TabIndex = 3;
            this.txtCatID.ThemeName = "Aqua";
            // 
            // txtCatDesc
            // 
            this.txtCatDesc.Location = new System.Drawing.Point(116, 85);
            this.txtCatDesc.Name = "txtCatDesc";
            this.txtCatDesc.Size = new System.Drawing.Size(395, 27);
            this.txtCatDesc.TabIndex = 4;
            this.txtCatDesc.ThemeName = "Aqua";
            // 
            // cboType
            // 
            radListDataItem1.Text = "RA";
            radListDataItem2.Text = "CI";
            this.cboType.Items.Add(radListDataItem1);
            this.cboType.Items.Add(radListDataItem2);
            this.cboType.Location = new System.Drawing.Point(116, 142);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(187, 27);
            this.cboType.TabIndex = 5;
            this.cboType.ThemeName = "Aqua";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(552, 54);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(165, 36);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "&Ok";
            this.OKButton.ThemeName = "Aqua";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(552, 106);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(165, 36);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "&Cancel";
            this.CancelButton.ThemeName = "Aqua";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // dlgCreateCat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 201);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.txtCatDesc);
            this.Controls.Add(this.txtCatID);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "dlgCreateCat";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Create New Measure Category";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.dlgCreateCat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCatID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCatDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OKButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtCatID;
        private Telerik.WinControls.UI.RadTextBox txtCatDesc;
        private Telerik.WinControls.UI.RadDropDownList cboType;
        private Telerik.WinControls.UI.RadButton OKButton;
        private Telerik.WinControls.UI.RadButton CancelButton;
        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
