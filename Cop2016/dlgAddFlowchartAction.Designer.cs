namespace COP2001
{
    partial class dlgAddFlowchartAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddFlowchartAction));
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtStep = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.cboAction = new Telerik.WinControls.UI.RadDropDownList();
            this.OKButton = new Telerik.WinControls.UI.RadButton();
            this.CancelButton = new Telerik.WinControls.UI.RadButton();
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OKButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(144, 37);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(48, 26);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Step:";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // txtStep
            // 
            this.txtStep.Location = new System.Drawing.Point(202, 36);
            this.txtStep.Name = "txtStep";
            this.txtStep.Size = new System.Drawing.Size(150, 27);
            this.txtStep.TabIndex = 1;
            this.txtStep.ThemeName = "Aqua";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel2.Location = new System.Drawing.Point(87, 89);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(323, 26);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Temporary Action To Take Before Step:";
            this.radLabel2.ThemeName = "Aqua";
            // 
            // cboAction
            // 
            this.cboAction.Location = new System.Drawing.Point(13, 121);
            this.cboAction.Name = "cboAction";
            this.cboAction.Size = new System.Drawing.Size(471, 27);
            this.cboAction.TabIndex = 3;
            this.cboAction.ThemeName = "Aqua";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(56, 198);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(165, 36);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "&Add";
            this.OKButton.ThemeName = "Aqua";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(275, 198);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(165, 36);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "&Cancel";
            this.CancelButton.ThemeName = "Aqua";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // dlgAddFlowchartAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 245);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.cboAction);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txtStep);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "dlgAddFlowchartAction";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Add Data Action to Flowchart";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.dlgAddFlowchartAction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OKButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtStep;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDropDownList cboAction;
        private Telerik.WinControls.UI.RadButton OKButton;
        private Telerik.WinControls.UI.RadButton CancelButton;
        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
