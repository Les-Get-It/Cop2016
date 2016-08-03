namespace COP2001
{
    partial class frmMeasureAddCritGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMeasureAddCritGroup));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.lblColName = new Telerik.WinControls.UI.RadLabel();
            this.lblSet = new Telerik.WinControls.UI.RadLabel();
            this.lblJoinOperator = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.cboGroup = new Telerik.WinControls.UI.RadDropDownList();
            this.cboJoinOperator = new Telerik.WinControls.UI.RadDropDownList();
            this.lstSetList = new Telerik.WinControls.UI.RadListControl();
            this.lstSelectedSetList = new Telerik.WinControls.UI.RadListControl();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            this.cmdAddSet = new Telerik.WinControls.UI.RadButton();
            this.cmdRemoveSet = new Telerik.WinControls.UI.RadButton();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.lblColName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJoinOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboJoinOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstSetList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstSelectedSetList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdRemoveSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblColName
            // 
            this.lblColName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblColName.ForeColor = System.Drawing.Color.Firebrick;
            this.lblColName.Location = new System.Drawing.Point(445, 13);
            this.lblColName.Name = "lblColName";
            this.lblColName.Size = new System.Drawing.Size(138, 28);
            this.lblColName.TabIndex = 0;
            this.lblColName.Text = "Setup Sets For:";
            this.lblColName.ThemeName = "Aqua";
            // 
            // lblSet
            // 
            this.lblSet.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSet.ForeColor = System.Drawing.Color.Blue;
            this.lblSet.Location = new System.Drawing.Point(168, 51);
            this.lblSet.Name = "lblSet";
            this.lblSet.Size = new System.Drawing.Size(77, 26);
            this.lblSet.TabIndex = 1;
            this.lblSet.Text = "Group #:";
            this.lblSet.ThemeName = "Aqua";
            // 
            // lblJoinOperator
            // 
            this.lblJoinOperator.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblJoinOperator.ForeColor = System.Drawing.Color.Blue;
            this.lblJoinOperator.Location = new System.Drawing.Point(710, 51);
            this.lblJoinOperator.Name = "lblJoinOperator";
            this.lblJoinOperator.Size = new System.Drawing.Size(144, 26);
            this.lblJoinOperator.TabIndex = 2;
            this.lblJoinOperator.Text = "Group Join Type:";
            this.lblJoinOperator.ThemeName = "Aqua";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel4.ForeColor = System.Drawing.Color.Blue;
            this.radLabel4.Location = new System.Drawing.Point(119, 126);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(202, 26);
            this.radLabel4.TabIndex = 3;
            this.radLabel4.Text = "Available Sets for Group";
            this.radLabel4.ThemeName = "Aqua";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel5.ForeColor = System.Drawing.Color.Blue;
            this.radLabel5.Location = new System.Drawing.Point(693, 126);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(196, 26);
            this.radLabel5.TabIndex = 4;
            this.radLabel5.Text = "Selected Sets for Group";
            this.radLabel5.ThemeName = "Aqua";
            // 
            // cboGroup
            // 
            this.cboGroup.Location = new System.Drawing.Point(107, 83);
            this.cboGroup.Name = "cboGroup";
            this.cboGroup.Size = new System.Drawing.Size(228, 27);
            this.cboGroup.TabIndex = 5;
            this.cboGroup.ThemeName = "Aqua";
            this.cboGroup.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboGroup_SelectedIndexChanged);
            // 
            // cboJoinOperator
            // 
            radListDataItem1.Text = "AND";
            radListDataItem2.Text = "OR";
            this.cboJoinOperator.Items.Add(radListDataItem1);
            this.cboJoinOperator.Items.Add(radListDataItem2);
            this.cboJoinOperator.Location = new System.Drawing.Point(676, 83);
            this.cboJoinOperator.Name = "cboJoinOperator";
            this.cboJoinOperator.Size = new System.Drawing.Size(228, 27);
            this.cboJoinOperator.TabIndex = 6;
            this.cboJoinOperator.ThemeName = "Aqua";
            // 
            // lstSetList
            // 
            this.lstSetList.Location = new System.Drawing.Point(10, 158);
            this.lstSetList.Name = "lstSetList";
            this.lstSetList.Size = new System.Drawing.Size(441, 344);
            this.lstSetList.TabIndex = 7;
            this.lstSetList.ThemeName = "Aqua";
            // 
            // lstSelectedSetList
            // 
            this.lstSelectedSetList.Location = new System.Drawing.Point(573, 158);
            this.lstSelectedSetList.Name = "lstSelectedSetList";
            this.lstSelectedSetList.Size = new System.Drawing.Size(441, 344);
            this.lstSelectedSetList.TabIndex = 8;
            this.lstSelectedSetList.ThemeName = "Aqua";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(457, 372);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(110, 36);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.ThemeName = "Aqua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdAddSet
            // 
            this.cmdAddSet.Location = new System.Drawing.Point(457, 244);
            this.cmdAddSet.Name = "cmdAddSet";
            this.cmdAddSet.Size = new System.Drawing.Size(110, 36);
            this.cmdAddSet.TabIndex = 10;
            this.cmdAddSet.Text = ">>";
            this.cmdAddSet.ThemeName = "Aqua";
            this.cmdAddSet.Click += new System.EventHandler(this.cmdAddSet_Click);
            // 
            // cmdRemoveSet
            // 
            this.cmdRemoveSet.Location = new System.Drawing.Point(457, 308);
            this.cmdRemoveSet.Name = "cmdRemoveSet";
            this.cmdRemoveSet.Size = new System.Drawing.Size(110, 36);
            this.cmdRemoveSet.TabIndex = 11;
            this.cmdRemoveSet.Text = "<<";
            this.cmdRemoveSet.ThemeName = "Aqua";
            this.cmdRemoveSet.Click += new System.EventHandler(this.cmdRemoveSet_Click);
            // 
            // frmMeasureAddCritGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 519);
            this.Controls.Add(this.cmdRemoveSet);
            this.Controls.Add(this.cmdAddSet);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.lstSelectedSetList);
            this.Controls.Add(this.lstSetList);
            this.Controls.Add(this.cboJoinOperator);
            this.Controls.Add(this.cboGroup);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.lblJoinOperator);
            this.Controls.Add(this.lblSet);
            this.Controls.Add(this.lblColName);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMeasureAddCritGroup";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Group Sets in Step";
            this.ThemeName = "Aqua";
            ((System.ComponentModel.ISupportInitialize)(this.lblColName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJoinOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboJoinOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstSetList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstSelectedSetList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdRemoveSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadLabel lblColName;
        private Telerik.WinControls.UI.RadLabel lblSet;
        private Telerik.WinControls.UI.RadLabel lblJoinOperator;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadDropDownList cboGroup;
        private Telerik.WinControls.UI.RadDropDownList cboJoinOperator;
        private Telerik.WinControls.UI.RadListControl lstSetList;
        private Telerik.WinControls.UI.RadListControl lstSelectedSetList;
        private Telerik.WinControls.UI.RadButton cmdCancel;
        private Telerik.WinControls.UI.RadButton cmdAddSet;
        private Telerik.WinControls.UI.RadButton cmdRemoveSet;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
