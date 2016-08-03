namespace COP2001
{
    partial class frmSubmissionGroupAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubmissionGroupAdd));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.lstGroups = new Telerik.WinControls.UI.RadListControl();
            this.cmdMoveUp = new Telerik.WinControls.UI.RadButton();
            this.cmdMoveDown = new Telerik.WinControls.UI.RadButton();
            this.cmdChangeStatus = new Telerik.WinControls.UI.RadButton();
            this.cmdDeleteGroup = new Telerik.WinControls.UI.RadButton();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            this.sstabGroup = new Telerik.WinControls.UI.Docking.RadDock();
            this.sstabGroup1 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.cmdUpdate = new Telerik.WinControls.UI.RadButton();
            this.chkShowTotalToUpdate = new Telerik.WinControls.UI.RadCheckBox();
            this.chkDisplayGroupTitleToUpdate = new Telerik.WinControls.UI.RadCheckBox();
            this.chkIncludeGroupToUpdate = new Telerik.WinControls.UI.RadCheckBox();
            this.txtGroupNameToUpdate = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.sstabGroup0 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.cmdAddSubmissionGroup = new Telerik.WinControls.UI.RadButton();
            this.chkShowTotal = new Telerik.WinControls.UI.RadCheckBox();
            this.chkDisplayGroupTitle = new Telerik.WinControls.UI.RadCheckBox();
            this.chkIncludeGroup = new Telerik.WinControls.UI.RadCheckBox();
            this.txtGroupName = new Telerik.WinControls.UI.RadTextBox();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdMoveUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdMoveDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdChangeStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDeleteGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sstabGroup)).BeginInit();
            this.sstabGroup.SuspendLayout();
            this.sstabGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowTotalToUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDisplayGroupTitleToUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeGroupToUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupNameToUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            this.documentContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            this.documentTabStrip1.SuspendLayout();
            this.sstabGroup0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddSubmissionGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDisplayGroupTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(222, 24);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(137, 27);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Existing Groups";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel2.Location = new System.Drawing.Point(22, 25);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(118, 27);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Group Name:";
            this.radLabel2.ThemeName = "Aqua";
            // 
            // lstGroups
            // 
            this.lstGroups.Location = new System.Drawing.Point(12, 57);
            this.lstGroups.Name = "lstGroups";
            this.lstGroups.Size = new System.Drawing.Size(550, 285);
            this.lstGroups.TabIndex = 2;
            this.lstGroups.ThemeName = "Aqua";
            this.lstGroups.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.lstGroups_SelectedIndexChanged);
            // 
            // cmdMoveUp
            // 
            this.cmdMoveUp.Location = new System.Drawing.Point(12, 355);
            this.cmdMoveUp.Name = "cmdMoveUp";
            this.cmdMoveUp.Size = new System.Drawing.Size(165, 36);
            this.cmdMoveUp.TabIndex = 3;
            this.cmdMoveUp.Text = "&Move Up";
            this.cmdMoveUp.ThemeName = "Aqua";
            this.cmdMoveUp.Click += new System.EventHandler(this.cmdMoveUp_Click);
            // 
            // cmdMoveDown
            // 
            this.cmdMoveDown.Location = new System.Drawing.Point(248, 355);
            this.cmdMoveDown.Name = "cmdMoveDown";
            this.cmdMoveDown.Size = new System.Drawing.Size(165, 36);
            this.cmdMoveDown.TabIndex = 4;
            this.cmdMoveDown.Text = "Move Do&wn";
            this.cmdMoveDown.ThemeName = "Aqua";
            this.cmdMoveDown.Click += new System.EventHandler(this.cmdMoveDown_Click);
            // 
            // cmdChangeStatus
            // 
            this.cmdChangeStatus.Location = new System.Drawing.Point(720, 355);
            this.cmdChangeStatus.Name = "cmdChangeStatus";
            this.cmdChangeStatus.Size = new System.Drawing.Size(165, 36);
            this.cmdChangeStatus.TabIndex = 6;
            this.cmdChangeStatus.Text = "Cha&nge Status";
            this.cmdChangeStatus.ThemeName = "Aqua";
            this.cmdChangeStatus.Click += new System.EventHandler(this.cmdChangeStatus_Click);
            // 
            // cmdDeleteGroup
            // 
            this.cmdDeleteGroup.Location = new System.Drawing.Point(484, 355);
            this.cmdDeleteGroup.Name = "cmdDeleteGroup";
            this.cmdDeleteGroup.Size = new System.Drawing.Size(165, 36);
            this.cmdDeleteGroup.TabIndex = 5;
            this.cmdDeleteGroup.Text = "&Delete Group";
            this.cmdDeleteGroup.ThemeName = "Aqua";
            this.cmdDeleteGroup.Click += new System.EventHandler(this.cmdDeleteGroup_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(956, 355);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(165, 36);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "&Close";
            this.cmdCancel.ThemeName = "Aqua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // sstabGroup
            // 
            this.sstabGroup.ActiveWindow = this.sstabGroup0;
            this.sstabGroup.Controls.Add(this.documentContainer1);
            this.sstabGroup.IsCleanUpTarget = true;
            this.sstabGroup.Location = new System.Drawing.Point(574, 57);
            this.sstabGroup.MainDocumentContainer = this.documentContainer1;
            this.sstabGroup.Name = "sstabGroup";
            this.sstabGroup.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.sstabGroup.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.sstabGroup.Size = new System.Drawing.Size(550, 285);
            this.sstabGroup.SplitterWidth = 3;
            this.sstabGroup.TabIndex = 8;
            this.sstabGroup.TabStop = false;
            this.sstabGroup.ThemeName = "Aqua";
            // 
            // sstabGroup1
            // 
            this.sstabGroup1.Controls.Add(this.cmdUpdate);
            this.sstabGroup1.Controls.Add(this.chkShowTotalToUpdate);
            this.sstabGroup1.Controls.Add(this.chkDisplayGroupTitleToUpdate);
            this.sstabGroup1.Controls.Add(this.chkIncludeGroupToUpdate);
            this.sstabGroup1.Controls.Add(this.txtGroupNameToUpdate);
            this.sstabGroup1.Controls.Add(this.radLabel3);
            this.sstabGroup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sstabGroup1.Location = new System.Drawing.Point(4, 38);
            this.sstabGroup1.Name = "sstabGroup1";
            this.sstabGroup1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.sstabGroup1.Size = new System.Drawing.Size(542, 243);
            this.sstabGroup1.Text = "Update";
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(216, 179);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(165, 36);
            this.cmdUpdate.TabIndex = 13;
            this.cmdUpdate.Text = "&Update";
            this.cmdUpdate.ThemeName = "Aqua";
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // chkShowTotalToUpdate
            // 
            this.chkShowTotalToUpdate.Location = new System.Drawing.Point(154, 135);
            this.chkShowTotalToUpdate.Name = "chkShowTotalToUpdate";
            this.chkShowTotalToUpdate.Size = new System.Drawing.Size(274, 26);
            this.chkShowTotalToUpdate.TabIndex = 12;
            this.chkShowTotalToUpdate.Text = "Show Total on the report";
            this.chkShowTotalToUpdate.ThemeName = "Aqua";
            // 
            // chkDisplayGroupTitleToUpdate
            // 
            this.chkDisplayGroupTitleToUpdate.Location = new System.Drawing.Point(154, 103);
            this.chkDisplayGroupTitleToUpdate.Name = "chkDisplayGroupTitleToUpdate";
            this.chkDisplayGroupTitleToUpdate.Size = new System.Drawing.Size(359, 26);
            this.chkDisplayGroupTitleToUpdate.TabIndex = 11;
            this.chkDisplayGroupTitleToUpdate.Text = "Display Group Title on the Report";
            this.chkDisplayGroupTitleToUpdate.ThemeName = "Aqua";
            // 
            // chkIncludeGroupToUpdate
            // 
            this.chkIncludeGroupToUpdate.Location = new System.Drawing.Point(154, 71);
            this.chkIncludeGroupToUpdate.Name = "chkIncludeGroupToUpdate";
            this.chkIncludeGroupToUpdate.Size = new System.Drawing.Size(304, 26);
            this.chkIncludeGroupToUpdate.TabIndex = 10;
            this.chkIncludeGroupToUpdate.Text = "Include Group on the report";
            this.chkIncludeGroupToUpdate.ThemeName = "Aqua";
            // 
            // txtGroupNameToUpdate
            // 
            this.txtGroupNameToUpdate.Location = new System.Drawing.Point(145, 21);
            this.txtGroupNameToUpdate.Name = "txtGroupNameToUpdate";
            this.txtGroupNameToUpdate.Size = new System.Drawing.Size(362, 27);
            this.txtGroupNameToUpdate.TabIndex = 9;
            this.txtGroupNameToUpdate.ThemeName = "Aqua";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel3.Location = new System.Drawing.Point(21, 21);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(118, 27);
            this.radLabel3.TabIndex = 8;
            this.radLabel3.Text = "Group Name:";
            this.radLabel3.ThemeName = "Aqua";
            // 
            // documentContainer1
            // 
            this.documentContainer1.Controls.Add(this.documentTabStrip1);
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer1.SplitterWidth = 3;
            this.documentContainer1.ThemeName = "Aqua";
            // 
            // documentTabStrip1
            // 
            this.documentTabStrip1.CanUpdateChildIndex = true;
            this.documentTabStrip1.Controls.Add(this.sstabGroup0);
            this.documentTabStrip1.Controls.Add(this.sstabGroup1);
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentTabStrip1.SelectedIndex = 0;
            this.documentTabStrip1.Size = new System.Drawing.Size(550, 285);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            this.documentTabStrip1.ThemeName = "Aqua";
            // 
            // sstabGroup0
            // 
            this.sstabGroup0.Controls.Add(this.cmdAddSubmissionGroup);
            this.sstabGroup0.Controls.Add(this.chkShowTotal);
            this.sstabGroup0.Controls.Add(this.chkDisplayGroupTitle);
            this.sstabGroup0.Controls.Add(this.chkIncludeGroup);
            this.sstabGroup0.Controls.Add(this.txtGroupName);
            this.sstabGroup0.Controls.Add(this.radLabel2);
            this.sstabGroup0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sstabGroup0.Location = new System.Drawing.Point(4, 38);
            this.sstabGroup0.Name = "sstabGroup0";
            this.sstabGroup0.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.sstabGroup0.Size = new System.Drawing.Size(542, 243);
            this.sstabGroup0.Text = "Add";
            // 
            // cmdAddSubmissionGroup
            // 
            this.cmdAddSubmissionGroup.Location = new System.Drawing.Point(217, 180);
            this.cmdAddSubmissionGroup.Name = "cmdAddSubmissionGroup";
            this.cmdAddSubmissionGroup.Size = new System.Drawing.Size(165, 36);
            this.cmdAddSubmissionGroup.TabIndex = 7;
            this.cmdAddSubmissionGroup.Text = "&Add";
            this.cmdAddSubmissionGroup.ThemeName = "Aqua";
            this.cmdAddSubmissionGroup.Click += new System.EventHandler(this.cmdAddSubmissionGroup_Click);
            // 
            // chkShowTotal
            // 
            this.chkShowTotal.Location = new System.Drawing.Point(155, 139);
            this.chkShowTotal.Name = "chkShowTotal";
            this.chkShowTotal.Size = new System.Drawing.Size(274, 26);
            this.chkShowTotal.TabIndex = 5;
            this.chkShowTotal.Text = "Show Total on the report";
            this.chkShowTotal.ThemeName = "Aqua";
            // 
            // chkDisplayGroupTitle
            // 
            this.chkDisplayGroupTitle.Location = new System.Drawing.Point(155, 107);
            this.chkDisplayGroupTitle.Name = "chkDisplayGroupTitle";
            this.chkDisplayGroupTitle.Size = new System.Drawing.Size(359, 26);
            this.chkDisplayGroupTitle.TabIndex = 4;
            this.chkDisplayGroupTitle.Text = "Display Group Title on the Report";
            this.chkDisplayGroupTitle.ThemeName = "Aqua";
            // 
            // chkIncludeGroup
            // 
            this.chkIncludeGroup.Location = new System.Drawing.Point(155, 75);
            this.chkIncludeGroup.Name = "chkIncludeGroup";
            this.chkIncludeGroup.Size = new System.Drawing.Size(304, 26);
            this.chkIncludeGroup.TabIndex = 3;
            this.chkIncludeGroup.Text = "Include Group on the report";
            this.chkIncludeGroup.ThemeName = "Aqua";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(146, 25);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(362, 27);
            this.txtGroupName.TabIndex = 2;
            this.txtGroupName.ThemeName = "Aqua";
            // 
            // frmSubmissionGroupAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 408);
            this.Controls.Add(this.sstabGroup);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdChangeStatus);
            this.Controls.Add(this.cmdDeleteGroup);
            this.Controls.Add(this.cmdMoveDown);
            this.Controls.Add(this.cmdMoveUp);
            this.Controls.Add(this.lstGroups);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSubmissionGroupAdd";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Add Submission Group";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmSubmissionGroupAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdMoveUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdMoveDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdChangeStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDeleteGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sstabGroup)).EndInit();
            this.sstabGroup.ResumeLayout(false);
            this.sstabGroup1.ResumeLayout(false);
            this.sstabGroup1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowTotalToUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDisplayGroupTitleToUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeGroupToUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupNameToUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            this.documentContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            this.documentTabStrip1.ResumeLayout(false);
            this.sstabGroup0.ResumeLayout(false);
            this.sstabGroup0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddSubmissionGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDisplayGroupTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadListControl lstGroups;
        private Telerik.WinControls.UI.RadButton cmdMoveUp;
        private Telerik.WinControls.UI.RadButton cmdMoveDown;
        private Telerik.WinControls.UI.RadButton cmdChangeStatus;
        private Telerik.WinControls.UI.RadButton cmdDeleteGroup;
        private Telerik.WinControls.UI.RadButton cmdCancel;
        private Telerik.WinControls.UI.Docking.RadDock sstabGroup;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.Docking.DocumentWindow sstabGroup1;
        private Telerik.WinControls.UI.RadButton cmdUpdate;
        private Telerik.WinControls.UI.RadCheckBox chkShowTotalToUpdate;
        private Telerik.WinControls.UI.RadCheckBox chkDisplayGroupTitleToUpdate;
        private Telerik.WinControls.UI.RadCheckBox chkIncludeGroupToUpdate;
        private Telerik.WinControls.UI.RadTextBox txtGroupNameToUpdate;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;
        private Telerik.WinControls.UI.Docking.DocumentWindow sstabGroup0;
        private Telerik.WinControls.UI.RadButton cmdAddSubmissionGroup;
        private Telerik.WinControls.UI.RadCheckBox chkShowTotal;
        private Telerik.WinControls.UI.RadCheckBox chkDisplayGroupTitle;
        private Telerik.WinControls.UI.RadCheckBox chkIncludeGroup;
        private Telerik.WinControls.UI.RadTextBox txtGroupName;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
