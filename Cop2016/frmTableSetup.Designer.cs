namespace COP2001
{
    partial class frmTableSetup
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTableSetup));
            this.cboTableList = new Telerik.WinControls.UI.RadDropDownList();
            this.cmdClose = new Telerik.WinControls.UI.RadButton();
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.cmdMoveDown = new Telerik.WinControls.UI.RadButton();
            this.cmdMoveUp = new Telerik.WinControls.UI.RadButton();
            this.cmdChangeStatus = new Telerik.WinControls.UI.RadButton();
            this.cmdUpdateDEA = new Telerik.WinControls.UI.RadButton();
            this.cmdAddField = new Telerik.WinControls.UI.RadButton();
            this.cmdDelete = new Telerik.WinControls.UI.RadButton();
            this.cmdEdit = new Telerik.WinControls.UI.RadButton();
            this.dbgFieldList = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.cboTableList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdMoveDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdMoveUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdChangeStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdUpdateDEA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgFieldList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgFieldList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTableList
            // 
            this.cboTableList.Location = new System.Drawing.Point(414, 12);
            this.cboTableList.Name = "cboTableList";
            this.cboTableList.Size = new System.Drawing.Size(469, 27);
            this.cboTableList.TabIndex = 1;
            this.cboTableList.ThemeName = "Aqua";
            this.cboTableList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboTableList_SelectedIndexChanged);
            // 
            // cmdClose
            // 
            this.cmdClose.Font = new System.Drawing.Font("Verdana", 7.7F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Location = new System.Drawing.Point(1065, 507);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(110, 36);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "&Close";
            this.cmdClose.ThemeName = "Aqua";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.7F, System.Drawing.FontStyle.Bold);
            this.radLabel1.ForeColor = System.Drawing.Color.Firebrick;
            this.radLabel1.Location = new System.Drawing.Point(331, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(67, 27);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Tables:";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel1.ThemeName = "Aqua";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.cmdMoveDown);
            this.radGroupBox1.Controls.Add(this.cmdMoveUp);
            this.radGroupBox1.Controls.Add(this.cmdClose);
            this.radGroupBox1.Controls.Add(this.cmdChangeStatus);
            this.radGroupBox1.Controls.Add(this.cmdUpdateDEA);
            this.radGroupBox1.Controls.Add(this.cmdAddField);
            this.radGroupBox1.Controls.Add(this.cmdDelete);
            this.radGroupBox1.Controls.Add(this.cmdEdit);
            this.radGroupBox1.Controls.Add(this.dbgFieldList);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radGroupBox1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox1.HeaderText = "Fields";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 72);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1214, 552);
            this.radGroupBox1.TabIndex = 5;
            this.radGroupBox1.Text = "Fields";
            this.radGroupBox1.ThemeName = "Aqua";
            // 
            // cmdMoveDown
            // 
            this.cmdMoveDown.Font = new System.Drawing.Font("Verdana", 7.7F, System.Drawing.FontStyle.Bold);
            this.cmdMoveDown.Location = new System.Drawing.Point(903, 507);
            this.cmdMoveDown.Name = "cmdMoveDown";
            this.cmdMoveDown.Size = new System.Drawing.Size(133, 36);
            this.cmdMoveDown.TabIndex = 26;
            this.cmdMoveDown.Text = "Move Do&wn";
            this.cmdMoveDown.ThemeName = "Aqua";
            this.cmdMoveDown.Click += new System.EventHandler(this.cmdMoveDown_Click);
            // 
            // cmdMoveUp
            // 
            this.cmdMoveUp.Font = new System.Drawing.Font("Verdana", 7.7F, System.Drawing.FontStyle.Bold);
            this.cmdMoveUp.Location = new System.Drawing.Point(755, 507);
            this.cmdMoveUp.Name = "cmdMoveUp";
            this.cmdMoveUp.Size = new System.Drawing.Size(119, 36);
            this.cmdMoveUp.TabIndex = 25;
            this.cmdMoveUp.Text = "&Move Up";
            this.cmdMoveUp.ThemeName = "Aqua";
            this.cmdMoveUp.Click += new System.EventHandler(this.cmdMoveUp_Click);
            // 
            // cmdChangeStatus
            // 
            this.cmdChangeStatus.Font = new System.Drawing.Font("Verdana", 7.7F, System.Drawing.FontStyle.Bold);
            this.cmdChangeStatus.Location = new System.Drawing.Point(583, 507);
            this.cmdChangeStatus.Name = "cmdChangeStatus";
            this.cmdChangeStatus.Size = new System.Drawing.Size(143, 36);
            this.cmdChangeStatus.TabIndex = 24;
            this.cmdChangeStatus.Text = "Change &Status";
            this.cmdChangeStatus.ThemeName = "Aqua";
            this.cmdChangeStatus.Click += new System.EventHandler(this.cmdChangeStatus_Click);
            // 
            // cmdUpdateDEA
            // 
            this.cmdUpdateDEA.Font = new System.Drawing.Font("Verdana", 7.7F, System.Drawing.FontStyle.Bold);
            this.cmdUpdateDEA.Location = new System.Drawing.Point(311, 507);
            this.cmdUpdateDEA.Name = "cmdUpdateDEA";
            this.cmdUpdateDEA.Size = new System.Drawing.Size(243, 36);
            this.cmdUpdateDEA.TabIndex = 23;
            this.cmdUpdateDEA.Text = "&Update Data Entry Actions";
            this.cmdUpdateDEA.ThemeName = "Aqua";
            this.cmdUpdateDEA.Click += new System.EventHandler(this.cmdUpdateDEA_Click);
            // 
            // cmdAddField
            // 
            this.cmdAddField.Font = new System.Drawing.Font("Verdana", 7.7F, System.Drawing.FontStyle.Bold);
            this.cmdAddField.Location = new System.Drawing.Point(224, 507);
            this.cmdAddField.Name = "cmdAddField";
            this.cmdAddField.Size = new System.Drawing.Size(58, 36);
            this.cmdAddField.TabIndex = 22;
            this.cmdAddField.Text = "&Add";
            this.cmdAddField.ThemeName = "Aqua";
            this.cmdAddField.Click += new System.EventHandler(this.cmdAddField_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Font = new System.Drawing.Font("Verdana", 7.7F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Location = new System.Drawing.Point(126, 507);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(69, 36);
            this.cmdDelete.TabIndex = 21;
            this.cmdDelete.Text = "&Delete";
            this.cmdDelete.ThemeName = "Aqua";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Font = new System.Drawing.Font("Verdana", 7.7F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Location = new System.Drawing.Point(19, 507);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(78, 36);
            this.cmdEdit.TabIndex = 20;
            this.cmdEdit.Text = "&Edit";
            this.cmdEdit.ThemeName = "Aqua";
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // dbgFieldList
            // 
            this.dbgFieldList.Location = new System.Drawing.Point(19, 21);
            // 
            // 
            // 
            this.dbgFieldList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dbgFieldList.Name = "dbgFieldList";
            this.dbgFieldList.Size = new System.Drawing.Size(1156, 480);
            this.dbgFieldList.TabIndex = 19;
            this.dbgFieldList.ThemeName = "Aqua";
            // 
            // frmTableSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 624);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.cboTableList);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmTableSetup";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Table and Field Setup Form";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmTableSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboTableList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmdMoveDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdMoveUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdChangeStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdUpdateDEA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgFieldList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgFieldList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Telerik.WinControls.UI.RadDropDownList cboTableList;
        private Telerik.WinControls.UI.RadButton cmdClose;
        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        //private cop2001currentDataSet cop2001currentDataSet;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton cmdMoveDown;
        private Telerik.WinControls.UI.RadButton cmdMoveUp;
        private Telerik.WinControls.UI.RadButton cmdChangeStatus;
        private Telerik.WinControls.UI.RadButton cmdUpdateDEA;
        private Telerik.WinControls.UI.RadButton cmdAddField;
        private Telerik.WinControls.UI.RadButton cmdDelete;
        private Telerik.WinControls.UI.RadButton cmdEdit;
        private Telerik.WinControls.UI.RadGridView dbgFieldList;
    }
}
