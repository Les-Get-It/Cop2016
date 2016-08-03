namespace COP2001
{
    partial class frmTableEditField
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTableEditField));
            this.Label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtFieldName = new Telerik.WinControls.UI.RadTextBoxControl();
            this.Label3 = new Telerik.WinControls.UI.RadLabel();
            this.cboFieldType = new Telerik.WinControls.UI.RadDropDownList();
            this.chkInactive = new Telerik.WinControls.UI.RadCheckBox();
            this.chkDynamic = new Telerik.WinControls.UI.RadCheckBox();
            this.txtFieldSize = new Telerik.WinControls.UI.RadTextBoxControl();
            this.lblFieldSize = new Telerik.WinControls.UI.RadLabel();
            this.chkUTD = new Telerik.WinControls.UI.RadCheckBox();
            this.chkPhysician = new Telerik.WinControls.UI.RadCheckBox();
            this.txtHelp = new Telerik.WinControls.UI.RadTextBoxControl();
            this.Label5 = new Telerik.WinControls.UI.RadLabel();
            this.cbo_LookupTbls = new Telerik.WinControls.UI.RadDropDownList();
            this.lblLookupTable = new Telerik.WinControls.UI.RadLabel();
            this.chkMultipleSel = new Telerik.WinControls.UI.RadCheckBox();
            this.txtMaxSel = new Telerik.WinControls.UI.RadTextBoxControl();
            this.lblMaxSel = new Telerik.WinControls.UI.RadLabel();
            this.cboDateFields = new Telerik.WinControls.UI.RadDropDownList();
            this.lblDateFields = new Telerik.WinControls.UI.RadLabel();
            this.cmdUpdateField = new Telerik.WinControls.UI.RadButton();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFieldType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInactive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDynamic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFieldSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPhysician)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_LookupTbls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLookupTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMultipleSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaxSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDateFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDateFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdUpdateField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(32, 13);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(111, 24);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Field Name:";
            this.Label2.ThemeName = "Aqua";
            // 
            // txtFieldName
            // 
            this.txtFieldName.Location = new System.Drawing.Point(149, 9);
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(763, 30);
            this.txtFieldName.TabIndex = 1;
            this.txtFieldName.ThemeName = "Aqua";
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(40, 55);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(103, 24);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Field Type:";
            this.Label3.ThemeName = "Aqua";
            // 
            // cboFieldType
            // 
            radListDataItem1.Text = "Date";
            radListDataItem2.Text = "Number";
            radListDataItem3.Text = "Text";
            radListDataItem4.Text = "Time";
            radListDataItem5.Text = "Date/Time";
            this.cboFieldType.Items.Add(radListDataItem1);
            this.cboFieldType.Items.Add(radListDataItem2);
            this.cboFieldType.Items.Add(radListDataItem3);
            this.cboFieldType.Items.Add(radListDataItem4);
            this.cboFieldType.Items.Add(radListDataItem5);
            this.cboFieldType.Location = new System.Drawing.Point(149, 57);
            this.cboFieldType.Name = "cboFieldType";
            this.cboFieldType.Size = new System.Drawing.Size(274, 27);
            this.cboFieldType.TabIndex = 4;
            this.cboFieldType.ThemeName = "Aqua";
            this.cboFieldType.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboFieldType_SelectedIndexChanged);
            // 
            // chkInactive
            // 
            this.chkInactive.Location = new System.Drawing.Point(477, 59);
            this.chkInactive.Name = "chkInactive";
            this.chkInactive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkInactive.Size = new System.Drawing.Size(111, 26);
            this.chkInactive.TabIndex = 5;
            this.chkInactive.Text = ":Inactive";
            this.chkInactive.ThemeName = "Aqua";
            // 
            // chkDynamic
            // 
            this.chkDynamic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDynamic.ForeColor = System.Drawing.Color.Red;
            this.chkDynamic.Location = new System.Drawing.Point(649, 59);
            this.chkDynamic.Name = "chkDynamic";
            this.chkDynamic.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDynamic.Size = new System.Drawing.Size(159, 25);
            this.chkDynamic.TabIndex = 6;
            this.chkDynamic.Text = ":Dynamic Field";
            this.chkDynamic.ThemeName = "Aqua";
            // 
            // txtFieldSize
            // 
            this.txtFieldSize.Location = new System.Drawing.Point(149, 97);
            this.txtFieldSize.Name = "txtFieldSize";
            this.txtFieldSize.Size = new System.Drawing.Size(50, 30);
            this.txtFieldSize.TabIndex = 8;
            this.txtFieldSize.ThemeName = "Aqua";
            // 
            // lblFieldSize
            // 
            this.lblFieldSize.Location = new System.Drawing.Point(46, 101);
            this.lblFieldSize.Name = "lblFieldSize";
            this.lblFieldSize.Size = new System.Drawing.Size(97, 24);
            this.lblFieldSize.TabIndex = 7;
            this.lblFieldSize.Text = "Field Size:";
            this.lblFieldSize.ThemeName = "Aqua";
            // 
            // chkUTD
            // 
            this.chkUTD.Location = new System.Drawing.Point(435, 105);
            this.chkUTD.Name = "chkUTD";
            this.chkUTD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkUTD.Size = new System.Drawing.Size(153, 26);
            this.chkUTD.TabIndex = 9;
            this.chkUTD.Text = "?Can Be UTD";
            this.chkUTD.ThemeName = "Aqua";
            // 
            // chkPhysician
            // 
            this.chkPhysician.Location = new System.Drawing.Point(629, 105);
            this.chkPhysician.Name = "chkPhysician";
            this.chkPhysician.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPhysician.Size = new System.Drawing.Size(179, 26);
            this.chkPhysician.TabIndex = 10;
            this.chkPhysician.Text = "?Physician Field";
            this.chkPhysician.ThemeName = "Aqua";
            // 
            // txtHelp
            // 
            this.txtHelp.Location = new System.Drawing.Point(149, 146);
            this.txtHelp.Multiline = true;
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.Size = new System.Drawing.Size(763, 356);
            this.txtHelp.TabIndex = 12;
            this.txtHelp.ThemeName = "Aqua";
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(10, 146);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(133, 24);
            this.Label5.TabIndex = 11;
            this.Label5.Text = "Help Message:";
            this.Label5.ThemeName = "Aqua";
            // 
            // cbo_LookupTbls
            // 
            this.cbo_LookupTbls.Location = new System.Drawing.Point(149, 520);
            this.cbo_LookupTbls.Name = "cbo_LookupTbls";
            this.cbo_LookupTbls.Size = new System.Drawing.Size(763, 27);
            this.cbo_LookupTbls.TabIndex = 14;
            this.cbo_LookupTbls.ThemeName = "Aqua";
            this.cbo_LookupTbls.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cbo_LookupTbls_SelectedIndexChange);
            // 
            // lblLookupTable
            // 
            this.lblLookupTable.Location = new System.Drawing.Point(14, 518);
            this.lblLookupTable.Name = "lblLookupTable";
            this.lblLookupTable.Size = new System.Drawing.Size(129, 24);
            this.lblLookupTable.TabIndex = 13;
            this.lblLookupTable.Text = "Lookup Table:";
            this.lblLookupTable.ThemeName = "Aqua";
            // 
            // chkMultipleSel
            // 
            this.chkMultipleSel.Location = new System.Drawing.Point(249, 569);
            this.chkMultipleSel.Name = "chkMultipleSel";
            this.chkMultipleSel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMultipleSel.Size = new System.Drawing.Size(218, 26);
            this.chkMultipleSel.TabIndex = 15;
            this.chkMultipleSel.Text = ":Multiple Selections";
            this.chkMultipleSel.ThemeName = "Aqua";
            this.chkMultipleSel.CheckStateChanged += new System.EventHandler(this.chkMultipleSel_CheckStateChanged);
            // 
            // txtMaxSel
            // 
            this.txtMaxSel.Location = new System.Drawing.Point(658, 567);
            this.txtMaxSel.Name = "txtMaxSel";
            this.txtMaxSel.Size = new System.Drawing.Size(75, 30);
            this.txtMaxSel.TabIndex = 17;
            this.txtMaxSel.ThemeName = "Aqua";
            // 
            // lblMaxSel
            // 
            this.lblMaxSel.Location = new System.Drawing.Point(483, 570);
            this.lblMaxSel.Name = "lblMaxSel";
            this.lblMaxSel.Size = new System.Drawing.Size(151, 24);
            this.lblMaxSel.TabIndex = 16;
            this.lblMaxSel.Text = "(Max Selections)";
            this.lblMaxSel.ThemeName = "Aqua";
            // 
            // cboDateFields
            // 
            this.cboDateFields.Location = new System.Drawing.Point(149, 614);
            this.cboDateFields.Name = "cboDateFields";
            this.cboDateFields.Size = new System.Drawing.Size(763, 27);
            this.cboDateFields.TabIndex = 19;
            this.cboDateFields.ThemeName = "Aqua";
            // 
            // lblDateFields
            // 
            this.lblDateFields.AutoSize = false;
            this.lblDateFields.Location = new System.Drawing.Point(14, 595);
            this.lblDateFields.Name = "lblDateFields";
            this.lblDateFields.Size = new System.Drawing.Size(129, 49);
            this.lblDateFields.TabIndex = 18;
            this.lblDateFields.Text = "Related Date Field:";
            this.lblDateFields.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lblDateFields.ThemeName = "Aqua";
            // 
            // cmdUpdateField
            // 
            this.cmdUpdateField.Location = new System.Drawing.Point(309, 665);
            this.cmdUpdateField.Name = "cmdUpdateField";
            this.cmdUpdateField.Size = new System.Drawing.Size(165, 36);
            this.cmdUpdateField.TabIndex = 20;
            this.cmdUpdateField.Text = "&Update";
            this.cmdUpdateField.ThemeName = "Aqua";
            this.cmdUpdateField.Click += new System.EventHandler(this.cmdUpdateField_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(509, 665);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(165, 36);
            this.cmdCancel.TabIndex = 21;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.ThemeName = "Aqua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmTableEditField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 714);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdUpdateField);
            this.Controls.Add(this.cboDateFields);
            this.Controls.Add(this.lblDateFields);
            this.Controls.Add(this.txtMaxSel);
            this.Controls.Add(this.lblMaxSel);
            this.Controls.Add(this.chkMultipleSel);
            this.Controls.Add(this.cbo_LookupTbls);
            this.Controls.Add(this.lblLookupTable);
            this.Controls.Add(this.txtHelp);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.chkPhysician);
            this.Controls.Add(this.chkUTD);
            this.Controls.Add(this.txtFieldSize);
            this.Controls.Add(this.lblFieldSize);
            this.Controls.Add(this.chkDynamic);
            this.Controls.Add(this.chkInactive);
            this.Controls.Add(this.cboFieldType);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtFieldName);
            this.Controls.Add(this.Label2);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmTableEditField";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Edit Field";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmTableEditField_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFieldType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInactive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDynamic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFieldSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUTD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPhysician)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_LookupTbls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLookupTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMultipleSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaxSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDateFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDateFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdUpdateField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel Label2;
        private Telerik.WinControls.UI.RadTextBoxControl txtFieldName;
        private Telerik.WinControls.UI.RadLabel Label3;
        private Telerik.WinControls.UI.RadDropDownList cboFieldType;
        private Telerik.WinControls.UI.RadCheckBox chkInactive;
        private Telerik.WinControls.UI.RadDropDownList cbo_LookupTbls;
        private Telerik.WinControls.UI.RadCheckBox chkDynamic;
        private Telerik.WinControls.UI.RadTextBoxControl txtFieldSize;
        private Telerik.WinControls.UI.RadLabel lblFieldSize;
        private Telerik.WinControls.UI.RadCheckBox chkUTD;
        private Telerik.WinControls.UI.RadCheckBox chkPhysician;
        private Telerik.WinControls.UI.RadTextBoxControl txtHelp;
        private Telerik.WinControls.UI.RadLabel Label5;
        private Telerik.WinControls.UI.RadLabel lblLookupTable;
        private Telerik.WinControls.UI.RadCheckBox chkMultipleSel;
        private Telerik.WinControls.UI.RadTextBoxControl txtMaxSel;
        private Telerik.WinControls.UI.RadLabel lblMaxSel;
        private Telerik.WinControls.UI.RadDropDownList cboDateFields;
        private Telerik.WinControls.UI.RadLabel lblDateFields;
        private Telerik.WinControls.UI.RadButton cmdUpdateField;
        private Telerik.WinControls.UI.RadButton cmdCancel;
        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
