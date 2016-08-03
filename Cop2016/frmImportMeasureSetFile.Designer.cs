namespace COP2001
{
    partial class frmImportMeasureSetFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportMeasureSetFile));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.lstYear = new Telerik.WinControls.UI.RadListControl();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.Opt4th = new Telerik.WinControls.UI.RadRadioButton();
            this.Opt3rd = new Telerik.WinControls.UI.RadRadioButton();
            this.Opt2nd = new Telerik.WinControls.UI.RadRadioButton();
            this.Opt1st = new Telerik.WinControls.UI.RadRadioButton();
            this.cboMeasureSet = new Telerik.WinControls.UI.RadDropDownList();
            this.lstIndicators = new Telerik.WinControls.UI.RadListControl();
            this.lblMonths = new Telerik.WinControls.UI.RadLabel();
            this.lblStatus = new Telerik.WinControls.UI.RadLabel();
            this.chkNotImport = new Telerik.WinControls.UI.RadCheckBox();
            this.cmdProcess = new Telerik.WinControls.UI.RadButton();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            this.crReport = new System.Windows.Forms.PictureBox();
            this.pgStatus = new Telerik.WinControls.UI.RadProgressBar();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Opt4th)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opt3rd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opt2nd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opt1st)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMeasureSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstIndicators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.radLabel1.ForeColor = System.Drawing.Color.Firebrick;
            this.radLabel1.Location = new System.Drawing.Point(50, 13);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(249, 28);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Select a Year and a Quarter:";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.radLabel2.ForeColor = System.Drawing.Color.Firebrick;
            this.radLabel2.Location = new System.Drawing.Point(581, 14);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(279, 28);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Choose Measure Set to Import:";
            this.radLabel2.ThemeName = "Aqua";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.radLabel3.ForeColor = System.Drawing.Color.Firebrick;
            this.radLabel3.Location = new System.Drawing.Point(628, 87);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(232, 28);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "Choose Indicators to Run:";
            this.radLabel3.ThemeName = "Aqua";
            // 
            // lstYear
            // 
            this.lstYear.Location = new System.Drawing.Point(14, 64);
            this.lstYear.Name = "lstYear";
            this.lstYear.Size = new System.Drawing.Size(161, 297);
            this.lstYear.TabIndex = 3;
            this.lstYear.ThemeName = "Aqua";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.Opt4th);
            this.radGroupBox1.Controls.Add(this.Opt3rd);
            this.radGroupBox1.Controls.Add(this.Opt2nd);
            this.radGroupBox1.Controls.Add(this.Opt1st);
            this.radGroupBox1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox1.HeaderText = "Quarter";
            this.radGroupBox1.Location = new System.Drawing.Point(181, 64);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(181, 297);
            this.radGroupBox1.TabIndex = 4;
            this.radGroupBox1.Text = "Quarter";
            this.radGroupBox1.ThemeName = "Aqua";
            // 
            // Opt4th
            // 
            this.Opt4th.Location = new System.Drawing.Point(22, 240);
            this.Opt4th.Name = "Opt4th";
            this.Opt4th.Size = new System.Drawing.Size(139, 26);
            this.Opt4th.TabIndex = 3;
            this.Opt4th.Text = "4th Quarter";
            this.Opt4th.ThemeName = "Aqua";
            this.Opt4th.Enter += new System.EventHandler(this.Opt4th_Enter);
            // 
            // Opt3rd
            // 
            this.Opt3rd.Location = new System.Drawing.Point(22, 173);
            this.Opt3rd.Name = "Opt3rd";
            this.Opt3rd.Size = new System.Drawing.Size(140, 26);
            this.Opt3rd.TabIndex = 2;
            this.Opt3rd.Text = "3rd Quarter";
            this.Opt3rd.ThemeName = "Aqua";
            this.Opt3rd.Enter += new System.EventHandler(this.Opt3rd_Enter);
            // 
            // Opt2nd
            // 
            this.Opt2nd.Location = new System.Drawing.Point(22, 106);
            this.Opt2nd.Name = "Opt2nd";
            this.Opt2nd.Size = new System.Drawing.Size(144, 26);
            this.Opt2nd.TabIndex = 1;
            this.Opt2nd.Text = "2nd Quarter";
            this.Opt2nd.ThemeName = "Aqua";
            this.Opt2nd.Enter += new System.EventHandler(this.Opt2nd_Enter);
            // 
            // Opt1st
            // 
            this.Opt1st.Location = new System.Drawing.Point(22, 39);
            this.Opt1st.Name = "Opt1st";
            this.Opt1st.Size = new System.Drawing.Size(137, 26);
            this.Opt1st.TabIndex = 0;
            this.Opt1st.Text = "1st Quarter";
            this.Opt1st.ThemeName = "Aqua";
            this.Opt1st.Enter += new System.EventHandler(this.Opt1st_Enter);
            // 
            // cboMeasureSet
            // 
            this.cboMeasureSet.Location = new System.Drawing.Point(510, 48);
            this.cboMeasureSet.Name = "cboMeasureSet";
            this.cboMeasureSet.Size = new System.Drawing.Size(420, 27);
            this.cboMeasureSet.TabIndex = 5;
            this.cboMeasureSet.ThemeName = "Aqua";
            this.cboMeasureSet.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboMeasureSet_SelectedIndexChanged);
            // 
            // lstIndicators
            // 
            this.lstIndicators.Location = new System.Drawing.Point(387, 121);
            this.lstIndicators.Name = "lstIndicators";
            this.lstIndicators.Size = new System.Drawing.Size(875, 224);
            this.lstIndicators.TabIndex = 6;
            this.lstIndicators.ThemeName = "Aqua";
            // 
            // lblMonths
            // 
            this.lblMonths.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMonths.ForeColor = System.Drawing.Color.Blue;
            this.lblMonths.Location = new System.Drawing.Point(1033, 12);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(229, 28);
            this.lblMonths.TabIndex = 7;
            this.lblMonths.Text = "January, February, March";
            this.lblMonths.ThemeName = "Aqua";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.BorderVisible = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblStatus.Location = new System.Drawing.Point(78, 367);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1099, 37);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Verify Status...";
            this.lblStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.ThemeName = "Aqua";
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblStatus.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblStatus.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblStatus.GetChildAt(0))).Text = "Verify Status...";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblStatus.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblStatus.GetChildAt(0).GetChildAt(1))).PaintUsingParentShape = true;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblStatus.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // chkNotImport
            // 
            this.chkNotImport.Location = new System.Drawing.Point(263, 427);
            this.chkNotImport.Name = "chkNotImport";
            this.chkNotImport.Size = new System.Drawing.Size(749, 26);
            this.chkNotImport.TabIndex = 9;
            this.chkNotImport.Text = "Do not prompt for import file - Use records imported during last import ";
            this.chkNotImport.ThemeName = "Aqua";
            // 
            // cmdProcess
            // 
            this.cmdProcess.Location = new System.Drawing.Point(430, 471);
            this.cmdProcess.Name = "cmdProcess";
            this.cmdProcess.Size = new System.Drawing.Size(215, 36);
            this.cmdProcess.TabIndex = 10;
            this.cmdProcess.Text = "&Import And Process";
            this.cmdProcess.ThemeName = "Aqua";
            this.cmdProcess.Click += new System.EventHandler(this.cmdProcess_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(680, 471);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(165, 36);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.ThemeName = "Aqua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // crReport
            // 
            this.crReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.crReport.Location = new System.Drawing.Point(1135, 530);
            this.crReport.Name = "crReport";
            this.crReport.Size = new System.Drawing.Size(127, 34);
            this.crReport.TabIndex = 13;
            this.crReport.TabStop = false;
            // 
            // pgStatus
            // 
            this.pgStatus.Location = new System.Drawing.Point(167, 528);
            this.pgStatus.Name = "pgStatus";
            this.pgStatus.Size = new System.Drawing.Size(940, 36);
            this.pgStatus.TabIndex = 14;
            this.pgStatus.ThemeName = "Aqua";
            // 
            // frmImportMeasureSetFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 568);
            this.Controls.Add(this.pgStatus);
            this.Controls.Add(this.crReport);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdProcess);
            this.Controls.Add(this.chkNotImport);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblMonths);
            this.Controls.Add(this.lstIndicators);
            this.Controls.Add(this.cboMeasureSet);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.lstYear);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmImportMeasureSetFile";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Import Measure Set File";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmImportMeasureSetFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Opt4th)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opt3rd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opt2nd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opt1st)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMeasureSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstIndicators)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadListControl lstYear;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadRadioButton Opt4th;
        private Telerik.WinControls.UI.RadRadioButton Opt3rd;
        private Telerik.WinControls.UI.RadRadioButton Opt2nd;
        private Telerik.WinControls.UI.RadRadioButton Opt1st;
        private Telerik.WinControls.UI.RadDropDownList cboMeasureSet;
        public Telerik.WinControls.UI.RadListControl lstIndicators;
        private Telerik.WinControls.UI.RadLabel lblMonths;
        public Telerik.WinControls.UI.RadLabel lblStatus;
        private Telerik.WinControls.UI.RadCheckBox chkNotImport;
        private Telerik.WinControls.UI.RadButton cmdProcess;
        private Telerik.WinControls.UI.RadButton cmdCancel;
        private System.Windows.Forms.PictureBox crReport;
        public Telerik.WinControls.UI.RadProgressBar pgStatus;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
