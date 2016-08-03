namespace COP2001
{
    partial class frmReportCopySumCriteria
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportCopySumCriteria));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            this.cmdCopy = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.cboJoinOperator = new Telerik.WinControls.UI.RadDropDownList();
            this.cboSet = new Telerik.WinControls.UI.RadDropDownList();
            this.lblJoinOperator = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.lblCopyFrom = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboJoinOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJoinOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCopyFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(528, 191);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(165, 36);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "Ca&ncel";
            this.cmdCancel.ThemeName = "Aqua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdCopy
            // 
            this.cmdCopy.Location = new System.Drawing.Point(334, 191);
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Size = new System.Drawing.Size(165, 36);
            this.cmdCopy.TabIndex = 10;
            this.cmdCopy.Text = "&Copy";
            this.cmdCopy.ThemeName = "Aqua";
            this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.cboJoinOperator);
            this.radGroupBox1.Controls.Add(this.cboSet);
            this.radGroupBox1.Controls.Add(this.lblJoinOperator);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(94, 86);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(900, 67);
            this.radGroupBox1.TabIndex = 9;
            this.radGroupBox1.ThemeName = "Aqua";
            // 
            // cboJoinOperator
            // 
            radListDataItem1.Text = "And";
            radListDataItem2.Text = "Or";
            this.cboJoinOperator.Items.Add(radListDataItem1);
            this.cboJoinOperator.Items.Add(radListDataItem2);
            this.cboJoinOperator.Location = new System.Drawing.Point(614, 21);
            this.cboJoinOperator.Name = "cboJoinOperator";
            this.cboJoinOperator.Size = new System.Drawing.Size(187, 27);
            this.cboJoinOperator.TabIndex = 5;
            this.cboJoinOperator.ThemeName = "Aqua";
            // 
            // cboSet
            // 
            radListDataItem3.Text = "And";
            radListDataItem4.Text = "Or";
            this.cboSet.Items.Add(radListDataItem3);
            this.cboSet.Items.Add(radListDataItem4);
            this.cboSet.Location = new System.Drawing.Point(159, 21);
            this.cboSet.Name = "cboSet";
            this.cboSet.Size = new System.Drawing.Size(187, 27);
            this.cboSet.TabIndex = 4;
            this.cboSet.ThemeName = "Aqua";
            this.cboSet.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboSet_SelectedIndexChanged);
            // 
            // lblJoinOperator
            // 
            this.lblJoinOperator.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblJoinOperator.ForeColor = System.Drawing.Color.Blue;
            this.lblJoinOperator.Location = new System.Drawing.Point(433, 21);
            this.lblJoinOperator.Name = "lblJoinOperator";
            this.lblJoinOperator.Size = new System.Drawing.Size(175, 27);
            this.lblJoinOperator.TabIndex = 3;
            this.lblJoinOperator.Text = "Join type in this Set:";
            this.lblJoinOperator.ThemeName = "Aqua";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel3.ForeColor = System.Drawing.Color.Blue;
            this.radLabel3.Location = new System.Drawing.Point(99, 21);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(54, 27);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "Set #:";
            this.radLabel3.ThemeName = "Aqua";
            // 
            // lblCopyFrom
            // 
            this.lblCopyFrom.AutoSize = false;
            this.lblCopyFrom.BorderVisible = true;
            this.lblCopyFrom.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCopyFrom.ForeColor = System.Drawing.Color.Firebrick;
            this.lblCopyFrom.Location = new System.Drawing.Point(94, 12);
            this.lblCopyFrom.Name = "lblCopyFrom";
            this.lblCopyFrom.Size = new System.Drawing.Size(900, 57);
            this.lblCopyFrom.TabIndex = 8;
            this.lblCopyFrom.Text = "This criteria";
            this.lblCopyFrom.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCopyFrom.ThemeName = "Aqua";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel2.ForeColor = System.Drawing.Color.Firebrick;
            this.radLabel2.Location = new System.Drawing.Point(54, 105);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(34, 27);
            this.radLabel2.TabIndex = 7;
            this.radLabel2.Text = "To:";
            this.radLabel2.ThemeName = "Aqua";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel1.ForeColor = System.Drawing.Color.Firebrick;
            this.radLabel1.Location = new System.Drawing.Point(33, 27);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(55, 27);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "Copy:";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // frmReportCopySumCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 236);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdCopy);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.lblCopyFrom);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmReportCopySumCriteria";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Copy Summarization Criteria";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmReportCopySumCriteria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboJoinOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJoinOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCopyFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadButton cmdCancel;
        private Telerik.WinControls.UI.RadButton cmdCopy;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadDropDownList cboJoinOperator;
        private Telerik.WinControls.UI.RadDropDownList cboSet;
        private Telerik.WinControls.UI.RadLabel lblJoinOperator;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel lblCopyFrom;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
