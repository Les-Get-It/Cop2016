namespace COP2001
{
    partial class frmMeasureFieldGroups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMeasureFieldGroups));
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cmdPrint = new Telerik.WinControls.UI.RadButton();
            this.dbgGroups = new Telerik.WinControls.UI.RadGridView();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgGroups.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(428, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(347, 40);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Measure Field Group Logic";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(1025, 16);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(165, 36);
            this.cmdPrint.TabIndex = 1;
            this.cmdPrint.Text = "&Print";
            this.cmdPrint.ThemeName = "Aqua";
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // dbgGroups
            // 
            this.dbgGroups.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dbgGroups.Location = new System.Drawing.Point(0, 64);
            // 
            // 
            // 
            this.dbgGroups.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dbgGroups.Name = "dbgGroups";
            this.dbgGroups.Size = new System.Drawing.Size(1202, 401);
            this.dbgGroups.TabIndex = 2;
            this.dbgGroups.ThemeName = "Aqua";
            this.dbgGroups.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dbgGroups_KeyDown);
            // 
            // frmMeasureFieldGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 465);
            this.Controls.Add(this.dbgGroups);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMeasureFieldGroups";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Measure Field Group List";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmMeasureFieldGroups_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgGroups.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton cmdPrint;
        private Telerik.WinControls.UI.RadGridView dbgGroups;
        //private cop2001currentDataSet cop2001currentDataSet;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
