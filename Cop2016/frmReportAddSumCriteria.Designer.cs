namespace COP2001
{
    partial class frmReportAddSumCriteria
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportAddSumCriteria));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.lblMessage = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.lblJoinOperator = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.cboSet = new Telerik.WinControls.UI.RadDropDownList();
            this.cboJoinOperator = new Telerik.WinControls.UI.RadDropDownList();
            this.lstIndicatorList = new Telerik.WinControls.UI.RadListControl();
            this.cboEqual = new Telerik.WinControls.UI.RadDropDownList();
            this.cboCategory = new Telerik.WinControls.UI.RadDropDownList();
            this.cmdAdd = new Telerik.WinControls.UI.RadButton();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.lblMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJoinOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboJoinOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstIndicatorList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEqual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMessage.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMessage.Location = new System.Drawing.Point(13, 13);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(293, 27);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Setting up Summarization Criteria ";
            this.lblMessage.ThemeName = "Aqua";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(449, 64);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(396, 28);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Compare an indicator to a measure category";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel2.ForeColor = System.Drawing.Color.Blue;
            this.radLabel2.Location = new System.Drawing.Point(758, 278);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(168, 26);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Select Criteria Set #:";
            this.radLabel2.ThemeName = "Aqua";
            // 
            // lblJoinOperator
            // 
            this.lblJoinOperator.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblJoinOperator.ForeColor = System.Drawing.Color.Blue;
            this.lblJoinOperator.Location = new System.Drawing.Point(951, 278);
            this.lblJoinOperator.Name = "lblJoinOperator";
            this.lblJoinOperator.Size = new System.Drawing.Size(170, 26);
            this.lblJoinOperator.TabIndex = 3;
            this.lblJoinOperator.Text = "Join type in this Set:";
            this.lblJoinOperator.ThemeName = "Aqua";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel3.Location = new System.Drawing.Point(715, 184);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(36, 26);
            this.radLabel3.TabIndex = 4;
            this.radLabel3.Text = "Op.";
            this.radLabel3.ThemeName = "Aqua";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel4.Location = new System.Drawing.Point(961, 184);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(153, 26);
            this.radLabel4.TabIndex = 5;
            this.radLabel4.Text = "Measure Category";
            this.radLabel4.ThemeName = "Aqua";
            // 
            // cboSet
            // 
            radListDataItem1.Text = "And";
            radListDataItem2.Text = "Or";
            this.cboSet.Items.Add(radListDataItem1);
            this.cboSet.Items.Add(radListDataItem2);
            this.cboSet.Location = new System.Drawing.Point(758, 310);
            this.cboSet.Name = "cboSet";
            this.cboSet.Size = new System.Drawing.Size(168, 27);
            this.cboSet.TabIndex = 6;
            this.cboSet.ThemeName = "Aqua";
            this.cboSet.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboSet_SelectedIndexChanged);
            // 
            // cboJoinOperator
            // 
            radListDataItem3.Text = "And";
            radListDataItem4.Text = "Or";
            this.cboJoinOperator.Items.Add(radListDataItem3);
            this.cboJoinOperator.Items.Add(radListDataItem4);
            this.cboJoinOperator.Location = new System.Drawing.Point(951, 310);
            this.cboJoinOperator.Name = "cboJoinOperator";
            this.cboJoinOperator.Size = new System.Drawing.Size(170, 27);
            this.cboJoinOperator.TabIndex = 7;
            this.cboJoinOperator.ThemeName = "Aqua";
            // 
            // lstIndicatorList
            // 
            this.lstIndicatorList.Location = new System.Drawing.Point(12, 184);
            this.lstIndicatorList.Name = "lstIndicatorList";
            this.lstIndicatorList.Size = new System.Drawing.Size(629, 378);
            this.lstIndicatorList.TabIndex = 8;
            this.lstIndicatorList.ThemeName = "Aqua";
            // 
            // cboEqual
            // 
            radListDataItem5.Text = "=";
            radListDataItem6.Text = "<>";
            this.cboEqual.Items.Add(radListDataItem5);
            this.cboEqual.Items.Add(radListDataItem6);
            this.cboEqual.Location = new System.Drawing.Point(681, 216);
            this.cboEqual.Name = "cboEqual";
            this.cboEqual.Size = new System.Drawing.Size(115, 27);
            this.cboEqual.TabIndex = 9;
            this.cboEqual.ThemeName = "Aqua";
            // 
            // cboCategory
            // 
            this.cboCategory.Location = new System.Drawing.Point(851, 216);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(397, 27);
            this.cboCategory.TabIndex = 10;
            this.cboCategory.ThemeName = "Aqua";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(761, 437);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(165, 36);
            this.cmdAdd.TabIndex = 11;
            this.cmdAdd.Text = "&Add";
            this.cmdAdd.ThemeName = "Aqua";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(961, 437);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(165, 36);
            this.cmdCancel.TabIndex = 12;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.ThemeName = "Aqua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmReportAddSumCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 570);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.cboEqual);
            this.Controls.Add(this.lstIndicatorList);
            this.Controls.Add(this.cboJoinOperator);
            this.Controls.Add(this.cboSet);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.lblJoinOperator);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.lblMessage);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmReportAddSumCriteria";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Add Summarization Criteria";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmReportAddSumCriteria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJoinOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboJoinOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstIndicatorList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEqual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadLabel lblMessage;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel lblJoinOperator;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadDropDownList cboSet;
        private Telerik.WinControls.UI.RadDropDownList cboEqual;
        private Telerik.WinControls.UI.RadDropDownList cboJoinOperator;
        private Telerik.WinControls.UI.RadListControl lstIndicatorList;
        private Telerik.WinControls.UI.RadDropDownList cboCategory;
        private Telerik.WinControls.UI.RadButton cmdAdd;
        private Telerik.WinControls.UI.RadButton cmdCancel;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
