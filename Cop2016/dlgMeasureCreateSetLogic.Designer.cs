namespace COP2001
{
    partial class dlgMeasureCreateSetLogic
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgMeasureCreateSetLogic));
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtDDID = new Telerik.WinControls.UI.RadTextBox();
            this.OptDDID2 = new Telerik.WinControls.UI.RadRadioButton();
            this.OptDDID1 = new Telerik.WinControls.UI.RadRadioButton();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.cboSetJoinOp = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lstDDID = new Telerik.WinControls.UI.RadListControl();
            this.OptNewSet = new Telerik.WinControls.UI.RadRadioButton();
            this.OptNewCrit = new Telerik.WinControls.UI.RadRadioButton();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.CancelButton = new Telerik.WinControls.UI.RadButton();
            this.cmdSave = new Telerik.WinControls.UI.RadButton();
            this.cmdDelete = new Telerik.WinControls.UI.RadButton();
            this.lstReplacements = new Telerik.WinControls.UI.RadListControl();
            this.dbgMeasureSet = new Telerik.WinControls.UI.RadGridView();
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDDID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptDDID2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptDDID1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSetJoinOp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstDDID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptNewSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptNewCrit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstReplacements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgMeasureSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgMeasureSet.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.txtDDID);
            this.radGroupBox1.Controls.Add(this.OptDDID2);
            this.radGroupBox1.Controls.Add(this.OptDDID1);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.radGroupBox1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox1.HeaderText = "Replace:";
            this.radGroupBox1.Location = new System.Drawing.Point(674, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(567, 141);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "Replace:";
            this.radGroupBox1.ThemeName = "Aqua";
            // 
            // txtDDID
            // 
            this.txtDDID.Location = new System.Drawing.Point(14, 84);
            this.txtDDID.Name = "txtDDID";
            this.txtDDID.Size = new System.Drawing.Size(537, 27);
            this.txtDDID.TabIndex = 2;
            this.txtDDID.ThemeName = "Aqua";
            // 
            // OptDDID2
            // 
            this.OptDDID2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.OptDDID2.Location = new System.Drawing.Point(344, 50);
            this.OptDDID2.Name = "OptDDID2";
            this.OptDDID2.Size = new System.Drawing.Size(78, 26);
            this.OptDDID2.TabIndex = 1;
            this.OptDDID2.Text = "Field 2";
            this.OptDDID2.ThemeName = "Aqua";
            this.OptDDID2.CheckStateChanged += new System.EventHandler(this.OptDDID2_CheckStateChanged);
            // 
            // OptDDID1
            // 
            this.OptDDID1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.OptDDID1.Location = new System.Drawing.Point(141, 50);
            this.OptDDID1.Name = "OptDDID1";
            this.OptDDID1.Size = new System.Drawing.Size(78, 26);
            this.OptDDID1.TabIndex = 0;
            this.OptDDID1.Text = "Field 1";
            this.OptDDID1.ThemeName = "Aqua";
            this.OptDDID1.CheckStateChanged += new System.EventHandler(this.OptDDID1_CheckStateChanged);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.btnAdd);
            this.radGroupBox2.Controls.Add(this.cboSetJoinOp);
            this.radGroupBox2.Controls.Add(this.radLabel1);
            this.radGroupBox2.Controls.Add(this.lstDDID);
            this.radGroupBox2.Controls.Add(this.OptNewSet);
            this.radGroupBox2.Controls.Add(this.OptNewCrit);
            this.radGroupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.radGroupBox2.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox2.HeaderText = "Replace With:";
            this.radGroupBox2.Location = new System.Drawing.Point(674, 159);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(567, 287);
            this.radGroupBox2.TabIndex = 2;
            this.radGroupBox2.Text = "Replace With:";
            this.radGroupBox2.ThemeName = "Aqua";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(386, 232);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(165, 36);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "&Add to List";
            this.btnAdd.ThemeName = "Aqua";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboSetJoinOp
            // 
            this.cboSetJoinOp.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            radListDataItem1.Text = "And";
            radListDataItem2.Text = "Or";
            this.cboSetJoinOp.Items.Add(radListDataItem1);
            this.cboSetJoinOp.Items.Add(radListDataItem2);
            this.cboSetJoinOp.Location = new System.Drawing.Point(180, 241);
            this.cboSetJoinOp.Name = "cboSetJoinOp";
            this.cboSetJoinOp.Size = new System.Drawing.Size(187, 28);
            this.cboSetJoinOp.TabIndex = 6;
            this.cboSetJoinOp.ThemeName = "Aqua";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(14, 241);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(157, 27);
            this.radLabel1.TabIndex = 5;
            this.radLabel1.Text = "Set Join Operator:";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // lstDDID
            // 
            this.lstDDID.Location = new System.Drawing.Point(14, 45);
            this.lstDDID.Name = "lstDDID";
            this.lstDDID.Size = new System.Drawing.Size(537, 114);
            this.lstDDID.TabIndex = 4;
            this.lstDDID.ThemeName = "Aqua";
            // 
            // OptNewSet
            // 
            this.OptNewSet.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.OptNewSet.Location = new System.Drawing.Point(14, 199);
            this.OptNewSet.Name = "OptNewSet";
            this.OptNewSet.Size = new System.Drawing.Size(499, 25);
            this.OptNewSet.TabIndex = 3;
            this.OptNewSet.Text = "Duplicate and Replace fields with New Set(s) (within Step)";
            this.OptNewSet.ThemeName = "Aqua";
            this.OptNewSet.CheckStateChanged += new System.EventHandler(this.OptNewSet_CheckStateChanged);
            // 
            // OptNewCrit
            // 
            this.OptNewCrit.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.OptNewCrit.Location = new System.Drawing.Point(14, 165);
            this.OptNewCrit.Name = "OptNewCrit";
            this.OptNewCrit.Size = new System.Drawing.Size(411, 25);
            this.OptNewCrit.TabIndex = 2;
            this.OptNewCrit.Text = "Duplicate and Replace New Criteria (within Set)";
            this.OptNewCrit.ThemeName = "Aqua";
            this.OptNewCrit.CheckStateChanged += new System.EventHandler(this.OptNewCrit_CheckStateChanged);
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.CancelButton);
            this.radGroupBox3.Controls.Add(this.cmdSave);
            this.radGroupBox3.Controls.Add(this.cmdDelete);
            this.radGroupBox3.Controls.Add(this.lstReplacements);
            this.radGroupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.radGroupBox3.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox3.HeaderText = "Replacements:";
            this.radGroupBox3.Location = new System.Drawing.Point(12, 452);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(1229, 338);
            this.radGroupBox3.TabIndex = 3;
            this.radGroupBox3.Text = "Replacements:";
            this.radGroupBox3.ThemeName = "Aqua";
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.CancelButton.Location = new System.Drawing.Point(1048, 283);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(165, 36);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "&Close";
            this.CancelButton.ThemeName = "Aqua";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Location = new System.Drawing.Point(1048, 144);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(165, 76);
            this.cmdSave.TabIndex = 8;
            this.cmdSave.Text = "Create Duplicate &Logic in Flowchart";
            this.cmdSave.TextWrap = true;
            this.cmdSave.ThemeName = "Aqua";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Location = new System.Drawing.Point(1048, 45);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(165, 36);
            this.cmdDelete.TabIndex = 7;
            this.cmdDelete.Text = "&Delete All";
            this.cmdDelete.ThemeName = "Aqua";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // lstReplacements
            // 
            this.lstReplacements.Location = new System.Drawing.Point(14, 45);
            this.lstReplacements.Name = "lstReplacements";
            this.lstReplacements.Size = new System.Drawing.Size(1015, 275);
            this.lstReplacements.TabIndex = 4;
            this.lstReplacements.ThemeName = "Aqua";
            // 
            // dbgMeasureSet
            // 
            this.dbgMeasureSet.Location = new System.Drawing.Point(12, 12);
            // 
            // 
            // 
            this.dbgMeasureSet.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dbgMeasureSet.Name = "dbgMeasureSet";
            this.dbgMeasureSet.Size = new System.Drawing.Size(656, 434);
            this.dbgMeasureSet.TabIndex = 4;
            this.dbgMeasureSet.ThemeName = "Aqua";
            this.dbgMeasureSet.CurrentCellChanged += new Telerik.WinControls.UI.CurrentCellChangedEventHandler(this.dbgMeasureSet_CurrentCellChanged);
            // 
            // dlgMeasureCreateSetLogic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 792);
            this.Controls.Add(this.dbgMeasureSet);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "dlgMeasureCreateSetLogic";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Create Replacement Logic";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.dlgMeasureCreateSetLogic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDDID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptDDID2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptDDID1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSetJoinOp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstDDID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptNewSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptNewCrit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstReplacements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgMeasureSet.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgMeasureSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadTextBox txtDDID;
        private Telerik.WinControls.UI.RadRadioButton OptDDID2;
        private Telerik.WinControls.UI.RadRadioButton OptDDID1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadDropDownList cboSetJoinOp;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadListControl lstDDID;
        private Telerik.WinControls.UI.RadRadioButton OptNewSet;
        private Telerik.WinControls.UI.RadRadioButton OptNewCrit;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadButton cmdDelete;
        private Telerik.WinControls.UI.RadListControl lstReplacements;
        private Telerik.WinControls.UI.RadButton CancelButton;
        private Telerik.WinControls.UI.RadButton cmdSave;
        private Telerik.WinControls.UI.RadGridView dbgMeasureSet;
        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
