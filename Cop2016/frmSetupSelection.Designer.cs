namespace COP2001
{
    partial class frmSetupSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetupSelection));
            this.Frame1 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtNewState = new Telerik.WinControls.UI.RadTextBoxControl();
            this.cboExistingState = new Telerik.WinControls.UI.RadDropDownList();
            this.optNewState = new Telerik.WinControls.UI.RadRadioButton();
            this.optExistingState = new Telerik.WinControls.UI.RadRadioButton();
            this.optJC = new Telerik.WinControls.UI.RadRadioButton();
            this.fraSelectedModule = new Telerik.WinControls.UI.RadGroupBox();
            this.optActive = new Telerik.WinControls.UI.RadRadioButton();
            this.optTest = new Telerik.WinControls.UI.RadRadioButton();
            this.cmdOk = new Telerik.WinControls.UI.RadButton();
            this.cmdMoveAllToActive = new Telerik.WinControls.UI.RadButton();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.Frame1)).BeginInit();
            this.Frame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExistingState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optNewState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optExistingState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optJC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fraSelectedModule)).BeginInit();
            this.fraSelectedModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdMoveAllToActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Frame1
            // 
            this.Frame1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.Frame1.Controls.Add(this.txtNewState);
            this.Frame1.Controls.Add(this.cboExistingState);
            this.Frame1.Controls.Add(this.optNewState);
            this.Frame1.Controls.Add(this.optExistingState);
            this.Frame1.Controls.Add(this.optJC);
            this.Frame1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.Frame1.HeaderText = "Select the setup ";
            this.Frame1.Location = new System.Drawing.Point(12, 31);
            this.Frame1.Name = "Frame1";
            this.Frame1.Size = new System.Drawing.Size(556, 150);
            this.Frame1.TabIndex = 0;
            this.Frame1.Text = "Select the setup ";
            this.Frame1.ThemeName = "Aqua";
            ((Telerik.WinControls.UI.RadGroupBoxElement)(this.Frame1.GetChildAt(0))).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.Frame1.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).Text = "Select the setup ";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.Frame1.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.Frame1.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNewState
            // 
            this.txtNewState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNewState.Location = new System.Drawing.Point(348, 99);
            this.txtNewState.Name = "txtNewState";
            this.txtNewState.Size = new System.Drawing.Size(187, 30);
            this.txtNewState.TabIndex = 4;
            this.txtNewState.ThemeName = "Aqua";
            // 
            // cboExistingState
            // 
            this.cboExistingState.Location = new System.Drawing.Point(348, 65);
            this.cboExistingState.Name = "cboExistingState";
            this.cboExistingState.Size = new System.Drawing.Size(187, 27);
            this.cboExistingState.TabIndex = 3;
            this.cboExistingState.ThemeName = "Aqua";
            // 
            // optNewState
            // 
            this.optNewState.Location = new System.Drawing.Point(6, 98);
            this.optNewState.Name = "optNewState";
            this.optNewState.Size = new System.Drawing.Size(294, 26);
            this.optNewState.TabIndex = 2;
            this.optNewState.TabStop = false;
            this.optNewState.Text = "State Specific Setup (New)";
            this.optNewState.ThemeName = "Aqua";
            // 
            // optExistingState
            // 
            this.optExistingState.Location = new System.Drawing.Point(6, 66);
            this.optExistingState.Name = "optExistingState";
            this.optExistingState.Size = new System.Drawing.Size(329, 26);
            this.optExistingState.TabIndex = 1;
            this.optExistingState.TabStop = false;
            this.optExistingState.Text = "State Specific Setup (Existing)";
            this.optExistingState.ThemeName = "Aqua";
            // 
            // optJC
            // 
            this.optJC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optJC.Location = new System.Drawing.Point(6, 34);
            this.optJC.Name = "optJC";
            this.optJC.Size = new System.Drawing.Size(264, 26);
            this.optJC.TabIndex = 0;
            this.optJC.Text = "Joint Commission Setup";
            this.optJC.ThemeName = "Aqua";
            this.optJC.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // fraSelectedModule
            // 
            this.fraSelectedModule.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.fraSelectedModule.Controls.Add(this.optActive);
            this.fraSelectedModule.Controls.Add(this.optTest);
            this.fraSelectedModule.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.fraSelectedModule.HeaderText = "Select the module";
            this.fraSelectedModule.Location = new System.Drawing.Point(607, 31);
            this.fraSelectedModule.Name = "fraSelectedModule";
            this.fraSelectedModule.Size = new System.Drawing.Size(300, 150);
            this.fraSelectedModule.TabIndex = 1;
            this.fraSelectedModule.Text = "Select the module";
            this.fraSelectedModule.ThemeName = "Aqua";
            ((Telerik.WinControls.UI.RadGroupBoxElement)(this.fraSelectedModule.GetChildAt(0))).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.fraSelectedModule.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).Text = "Select the module";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.fraSelectedModule.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.fraSelectedModule.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // optActive
            // 
            this.optActive.Location = new System.Drawing.Point(82, 85);
            this.optActive.Name = "optActive";
            this.optActive.Size = new System.Drawing.Size(148, 26);
            this.optActive.TabIndex = 1;
            this.optActive.TabStop = false;
            this.optActive.Text = "Active Setup";
            this.optActive.ThemeName = "Aqua";
            // 
            // optTest
            // 
            this.optTest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optTest.Location = new System.Drawing.Point(82, 53);
            this.optTest.Name = "optTest";
            this.optTest.Size = new System.Drawing.Size(130, 26);
            this.optTest.TabIndex = 0;
            this.optTest.Text = "Test Setup";
            this.optTest.ThemeName = "Aqua";
            this.optTest.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(44, 207);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(193, 36);
            this.cmdOk.TabIndex = 2;
            this.cmdOk.Text = "Open the Setup";
            this.cmdOk.ThemeName = "Aqua";
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdMoveAllToActive
            // 
            this.cmdMoveAllToActive.Location = new System.Drawing.Point(315, 207);
            this.cmdMoveAllToActive.Name = "cmdMoveAllToActive";
            this.cmdMoveAllToActive.Size = new System.Drawing.Size(308, 36);
            this.cmdMoveAllToActive.TabIndex = 3;
            this.cmdMoveAllToActive.Text = "Move Test Setup To Active";
            this.cmdMoveAllToActive.ThemeName = "Aqua";
            this.cmdMoveAllToActive.Click += new System.EventHandler(this.cmdMoveAllToActive_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(701, 207);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(165, 36);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Close";
            this.cmdCancel.ThemeName = "Aqua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmSetupSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 257);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdMoveAllToActive);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.fraSelectedModule);
            this.Controls.Add(this.Frame1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSetupSelection";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Select the Setup/Module";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmSetupSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Frame1)).EndInit();
            this.Frame1.ResumeLayout(false);
            this.Frame1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExistingState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optNewState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optExistingState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optJC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fraSelectedModule)).EndInit();
            this.fraSelectedModule.ResumeLayout(false);
            this.fraSelectedModule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdMoveAllToActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGroupBox Frame1;
        private Telerik.WinControls.UI.RadTextBoxControl txtNewState;
        private Telerik.WinControls.UI.RadDropDownList cboExistingState;
        private Telerik.WinControls.UI.RadRadioButton optNewState;
        private Telerik.WinControls.UI.RadRadioButton optExistingState;
        private Telerik.WinControls.UI.RadRadioButton optJC;
        private Telerik.WinControls.UI.RadGroupBox fraSelectedModule;
        private Telerik.WinControls.UI.RadRadioButton optActive;
        private Telerik.WinControls.UI.RadRadioButton optTest;
        private Telerik.WinControls.UI.RadButton cmdOk;
        private Telerik.WinControls.UI.RadButton cmdMoveAllToActive;
        private Telerik.WinControls.UI.RadButton cmdCancel;
        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
