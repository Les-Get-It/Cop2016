namespace COP2001
{
    partial class frmTableValidationAddAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTableValidationAddAction));
            this.Label1 = new Telerik.WinControls.UI.RadLabel();
            this.lstFieldList = new Telerik.WinControls.UI.RadListControl();
            this.Frame1 = new Telerik.WinControls.UI.RadGroupBox();
            this.optZero = new Telerik.WinControls.UI.RadRadioButton();
            this.optBlank = new Telerik.WinControls.UI.RadRadioButton();
            this.cmdAdd = new Telerik.WinControls.UI.RadButton();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstFieldList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame1)).BeginInit();
            this.Frame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optBlank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Label1.Location = new System.Drawing.Point(346, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(63, 28);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Fields:";
            this.Label1.ThemeName = "Aqua";
            // 
            // lstFieldList
            // 
            this.lstFieldList.Location = new System.Drawing.Point(12, 46);
            this.lstFieldList.Name = "lstFieldList";
            this.lstFieldList.Size = new System.Drawing.Size(731, 279);
            this.lstFieldList.TabIndex = 1;
            this.lstFieldList.ThemeName = "Aqua";
            // 
            // Frame1
            // 
            this.Frame1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.Frame1.Controls.Add(this.optZero);
            this.Frame1.Controls.Add(this.optBlank);
            this.Frame1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.Frame1.HeaderText = "Set to:";
            this.Frame1.HeaderTextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.Frame1.Location = new System.Drawing.Point(12, 331);
            this.Frame1.Name = "Frame1";
            this.Frame1.Size = new System.Drawing.Size(276, 79);
            this.Frame1.TabIndex = 2;
            this.Frame1.Text = "Set to:";
            this.Frame1.ThemeName = "Aqua";
            // 
            // optZero
            // 
            this.optZero.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.optZero.Location = new System.Drawing.Point(165, 39);
            this.optZero.Name = "optZero";
            this.optZero.Size = new System.Drawing.Size(60, 26);
            this.optZero.TabIndex = 3;
            this.optZero.Text = "Zero";
            this.optZero.ThemeName = "Aqua";
            // 
            // optBlank
            // 
            this.optBlank.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.optBlank.Location = new System.Drawing.Point(41, 39);
            this.optBlank.Name = "optBlank";
            this.optBlank.Size = new System.Drawing.Size(69, 26);
            this.optBlank.TabIndex = 0;
            this.optBlank.Text = "Blank";
            this.optBlank.ThemeName = "Aqua";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(360, 361);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(165, 36);
            this.cmdAdd.TabIndex = 3;
            this.cmdAdd.Text = "&Add";
            this.cmdAdd.ThemeName = "Aqua";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(531, 361);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(165, 36);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.ThemeName = "Aqua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmTableValidationAddAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 432);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.Frame1);
            this.Controls.Add(this.lstFieldList);
            this.Controls.Add(this.Label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmTableValidationAddAction";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Add Validation Action";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmTableValidationAddAction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstFieldList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame1)).EndInit();
            this.Frame1.ResumeLayout(false);
            this.Frame1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optBlank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel Label1;
        private Telerik.WinControls.UI.RadListControl lstFieldList;
        private Telerik.WinControls.UI.RadGroupBox Frame1;
        private Telerik.WinControls.UI.RadRadioButton optZero;
        private Telerik.WinControls.UI.RadRadioButton optBlank;
        private Telerik.WinControls.UI.RadButton cmdAdd;
        private Telerik.WinControls.UI.RadButton cmdCancel;
        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
