namespace COP2001
{
    partial class frmLookupSetup
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLookupSetup));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cboLookupTableList = new Telerik.WinControls.UI.RadDropDownList();
            this.cmdAddLookupTable = new Telerik.WinControls.UI.RadButton();
            this.cmdDelete = new Telerik.WinControls.UI.RadButton();
            this.cmdEdit = new Telerik.WinControls.UI.RadButton();
            this.dbgLookupList = new Telerik.WinControls.UI.RadGridView();
            //this.cop2001currentDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.cop2001currentDataSet = new COP2001.cop2001currentDataSet();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.fraLk = new Telerik.WinControls.UI.RadGroupBox();
            this.OptLKValue = new Telerik.WinControls.UI.RadRadioButton();
            this.optID = new Telerik.WinControls.UI.RadRadioButton();
            this.cmdImport = new Telerik.WinControls.UI.RadButton();
            this.cmdMoveDown = new Telerik.WinControls.UI.RadButton();
            this.cmdMoveUp = new Telerik.WinControls.UI.RadButton();
            this.cmdEditLookup = new Telerik.WinControls.UI.RadButton();
            this.cmdDelLookup = new Telerik.WinControls.UI.RadButton();
            this.cmdAddLookupValue = new Telerik.WinControls.UI.RadButton();
            this.cmdClose = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtID = new Telerik.WinControls.UI.RadTextBox();
            this.txtLookupValue = new Telerik.WinControls.UI.RadTextBox();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLookupTableList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddLookupTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgLookupList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgLookupList.MasterTemplate)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.cop2001currentDataSetBindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.cop2001currentDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fraLk)).BeginInit();
            this.fraLk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptLKValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdMoveDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdMoveUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEditLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddLookupValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLookupValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(12, 22);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(128, 26);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Lookup Tables:";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // cboLookupTableList
            // 
            this.cboLookupTableList.Location = new System.Drawing.Point(146, 21);
            this.cboLookupTableList.Name = "cboLookupTableList";
            this.cboLookupTableList.Size = new System.Drawing.Size(552, 27);
            this.cboLookupTableList.TabIndex = 1;
            this.cboLookupTableList.ThemeName = "Aqua";
            this.cboLookupTableList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboLookupTableList_SelectedIndexChanged);
            // 
            // cmdAddLookupTable
            // 
            this.cmdAddLookupTable.Location = new System.Drawing.Point(731, 12);
            this.cmdAddLookupTable.Name = "cmdAddLookupTable";
            this.cmdAddLookupTable.Size = new System.Drawing.Size(109, 36);
            this.cmdAddLookupTable.TabIndex = 2;
            this.cmdAddLookupTable.Text = "&Add";
            this.cmdAddLookupTable.ThemeName = "Aqua";
            this.cmdAddLookupTable.Click += new System.EventHandler(this.cmdAddLookupTable_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(873, 12);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(109, 36);
            this.cmdDelete.TabIndex = 3;
            this.cmdDelete.Text = "&Delete";
            this.cmdDelete.ThemeName = "Aqua";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(1015, 12);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(109, 36);
            this.cmdEdit.TabIndex = 4;
            this.cmdEdit.Text = "&Edit";
            this.cmdEdit.ThemeName = "Aqua";
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // dbgLookupList
            // 
            this.dbgLookupList.Location = new System.Drawing.Point(12, 72);
            // 
            // 
            // 
            //this.dbgLookupList.MasterTemplate.DataSource = this.cop2001currentDataSetBindingSource;
            this.dbgLookupList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dbgLookupList.Name = "dbgLookupList";
            this.dbgLookupList.Size = new System.Drawing.Size(686, 322);
            this.dbgLookupList.TabIndex = 5;
            this.dbgLookupList.ThemeName = "Aqua";
            // 
            // cop2001currentDataSetBindingSource
            // 
            //this.cop2001currentDataSetBindingSource.DataSource = this.cop2001currentDataSet;
            //this.cop2001currentDataSetBindingSource.Position = 0;
            // 
            // cop2001currentDataSet
            // 
            //this.cop2001currentDataSet.DataSetName = "cop2001currentDataSet";
            //this.cop2001currentDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.fraLk);
            this.radGroupBox1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox1.HeaderText = "Lookup Table Preferences";
            this.radGroupBox1.Location = new System.Drawing.Point(731, 72);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(394, 322);
            this.radGroupBox1.TabIndex = 6;
            this.radGroupBox1.Text = "Lookup Table Preferences";
            this.radGroupBox1.ThemeName = "Aqua";
            // 
            // fraLk
            // 
            this.fraLk.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.fraLk.Controls.Add(this.OptLKValue);
            this.fraLk.Controls.Add(this.optID);
            this.fraLk.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.fraLk.HeaderText = "Compare Table Values to:";
            this.fraLk.Location = new System.Drawing.Point(65, 39);
            this.fraLk.Name = "fraLk";
            this.fraLk.Size = new System.Drawing.Size(274, 109);
            this.fraLk.TabIndex = 17;
            this.fraLk.Text = "Compare Table Values to:";
            this.fraLk.ThemeName = "Aqua";
            // 
            // OptLKValue
            // 
            this.OptLKValue.Location = new System.Drawing.Point(77, 69);
            this.OptLKValue.Name = "OptLKValue";
            this.OptLKValue.Size = new System.Drawing.Size(157, 26);
            this.OptLKValue.TabIndex = 3;
            this.OptLKValue.Text = "Lookup Value";
            this.OptLKValue.ThemeName = "Aqua";
            this.OptLKValue.CheckStateChanged += new System.EventHandler(this.OptLKValue_CheckStateChanged);
            // 
            // optID
            // 
            this.optID.Location = new System.Drawing.Point(77, 37);
            this.optID.Name = "optID";
            this.optID.Size = new System.Drawing.Size(45, 26);
            this.optID.TabIndex = 2;
            this.optID.Text = "ID";
            this.optID.ThemeName = "Aqua";
            this.optID.CheckStateChanged += new System.EventHandler(this.optID_CheckStateChanged);
            // 
            // cmdImport
            // 
            this.cmdImport.Location = new System.Drawing.Point(764, 400);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(341, 36);
            this.cmdImport.TabIndex = 7;
            this.cmdImport.Text = "&Import values from *.csv List";
            this.cmdImport.ThemeName = "Aqua";
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // cmdMoveDown
            // 
            this.cmdMoveDown.Location = new System.Drawing.Point(938, 448);
            this.cmdMoveDown.Name = "cmdMoveDown";
            this.cmdMoveDown.Size = new System.Drawing.Size(132, 36);
            this.cmdMoveDown.TabIndex = 9;
            this.cmdMoveDown.Text = "&Move Down";
            this.cmdMoveDown.ThemeName = "Aqua";
            this.cmdMoveDown.Click += new System.EventHandler(this.cmdMoveDown_Click);
            // 
            // cmdMoveUp
            // 
            this.cmdMoveUp.Location = new System.Drawing.Point(783, 448);
            this.cmdMoveUp.Name = "cmdMoveUp";
            this.cmdMoveUp.Size = new System.Drawing.Size(132, 36);
            this.cmdMoveUp.TabIndex = 8;
            this.cmdMoveUp.Text = "Move &Up";
            this.cmdMoveUp.ThemeName = "Aqua";
            this.cmdMoveUp.Click += new System.EventHandler(this.cmdMoveUp_Click);
            // 
            // cmdEditLookup
            // 
            this.cmdEditLookup.Location = new System.Drawing.Point(12, 400);
            this.cmdEditLookup.Name = "cmdEditLookup";
            this.cmdEditLookup.Size = new System.Drawing.Size(132, 36);
            this.cmdEditLookup.TabIndex = 12;
            this.cmdEditLookup.Text = "Edi&t";
            this.cmdEditLookup.ThemeName = "Aqua";
            this.cmdEditLookup.Click += new System.EventHandler(this.cmdEditLookup_Click);
            // 
            // cmdDelLookup
            // 
            this.cmdDelLookup.Location = new System.Drawing.Point(196, 400);
            this.cmdDelLookup.Name = "cmdDelLookup";
            this.cmdDelLookup.Size = new System.Drawing.Size(132, 36);
            this.cmdDelLookup.TabIndex = 11;
            this.cmdDelLookup.Text = "De&lete";
            this.cmdDelLookup.ThemeName = "Aqua";
            this.cmdDelLookup.Click += new System.EventHandler(this.cmdDelLookup_Click);
            // 
            // cmdAddLookupValue
            // 
            this.cmdAddLookupValue.Location = new System.Drawing.Point(380, 400);
            this.cmdAddLookupValue.Name = "cmdAddLookupValue";
            this.cmdAddLookupValue.Size = new System.Drawing.Size(132, 36);
            this.cmdAddLookupValue.TabIndex = 10;
            this.cmdAddLookupValue.Text = "Add";
            this.cmdAddLookupValue.ThemeName = "Aqua";
            this.cmdAddLookupValue.Click += new System.EventHandler(this.cmdAddLookupValue_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(564, 400);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(132, 36);
            this.cmdClose.TabIndex = 13;
            this.cmdClose.Text = "&Close";
            this.cmdClose.ThemeName = "Aqua";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel3.ForeColor = System.Drawing.Color.Blue;
            this.radLabel3.Location = new System.Drawing.Point(12, 458);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(49, 26);
            this.radLabel3.TabIndex = 14;
            this.radLabel3.Text = "New:";
            this.radLabel3.ThemeName = "Aqua";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(67, 457);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(86, 27);
            this.txtID.TabIndex = 15;
            this.txtID.ThemeName = "Aqua";
            // 
            // txtLookupValue
            // 
            this.txtLookupValue.Location = new System.Drawing.Point(169, 457);
            this.txtLookupValue.Name = "txtLookupValue";
            this.txtLookupValue.Size = new System.Drawing.Size(527, 27);
            this.txtLookupValue.TabIndex = 16;
            this.txtLookupValue.ThemeName = "Aqua";
            // 
            // frmLookupSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 496);
            this.Controls.Add(this.txtLookupValue);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdEditLookup);
            this.Controls.Add(this.cmdDelLookup);
            this.Controls.Add(this.cmdAddLookupValue);
            this.Controls.Add(this.cmdMoveDown);
            this.Controls.Add(this.cmdMoveUp);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.dbgLookupList);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdAddLookupTable);
            this.Controls.Add(this.cboLookupTableList);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLookupSetup";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Lookup Table Setup";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmLookupSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLookupTableList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddLookupTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgLookupList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgLookupList)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.cop2001currentDataSetBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.cop2001currentDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fraLk)).EndInit();
            this.fraLk.ResumeLayout(false);
            this.fraLk.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptLKValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdMoveDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdMoveUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEditLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddLookupValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLookupValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList cboLookupTableList;
        private Telerik.WinControls.UI.RadButton cmdAddLookupTable;
        private Telerik.WinControls.UI.RadButton cmdDelete;
        private Telerik.WinControls.UI.RadButton cmdEdit;
        private Telerik.WinControls.UI.RadGridView dbgLookupList;
        //private System.Windows.Forms.BindingSource cop2001currentDataSetBindingSource;
        //private cop2001currentDataSet cop2001currentDataSet;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadRadioButton OptLKValue;
        private Telerik.WinControls.UI.RadRadioButton optID;
        private Telerik.WinControls.UI.RadButton cmdImport;
        private Telerik.WinControls.UI.RadButton cmdMoveDown;
        private Telerik.WinControls.UI.RadButton cmdMoveUp;
        private Telerik.WinControls.UI.RadButton cmdEditLookup;
        private Telerik.WinControls.UI.RadButton cmdDelLookup;
        private Telerik.WinControls.UI.RadButton cmdAddLookupValue;
        private Telerik.WinControls.UI.RadButton cmdClose;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtID;
        private Telerik.WinControls.UI.RadTextBox txtLookupValue;
        private Telerik.WinControls.UI.RadGroupBox fraLk;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
