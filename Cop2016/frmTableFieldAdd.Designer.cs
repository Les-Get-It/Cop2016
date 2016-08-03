namespace COP2001
{
    partial class frmTableFieldAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTableFieldAdd));
            this.txtFieldName = new Telerik.WinControls.UI.RadTextBoxControl();
            this.Label2 = new Telerik.WinControls.UI.RadLabel();
            this.Label3 = new Telerik.WinControls.UI.RadLabel();
            this.cboFieldType = new Telerik.WinControls.UI.RadDropDownList();
            this.lblFieldSize = new Telerik.WinControls.UI.RadLabel();
            this.txtFieldSize = new Telerik.WinControls.UI.RadTextBoxControl();
            this.chkInactive = new Telerik.WinControls.UI.RadCheckBox();
            this.chkUTD = new Telerik.WinControls.UI.RadCheckBox();
            this.chkPhysician = new Telerik.WinControls.UI.RadCheckBox();
            this.chkDynamic = new Telerik.WinControls.UI.RadCheckBox();
            this.Label5 = new Telerik.WinControls.UI.RadLabel();
            this.txtHelp = new Telerik.WinControls.UI.RadTextBoxControl();
            this.cbo_LookupTbls = new Telerik.WinControls.UI.RadDropDownList();
            this.lblLookupTable = new Telerik.WinControls.UI.RadLabel();
            this.chkMultipleSel = new Telerik.WinControls.UI.RadCheckBox();
            this.lblMaxSel = new Telerik.WinControls.UI.RadLabel();
            this.txtMaxSel = new Telerik.WinControls.UI.RadTextBoxControl();
            this.cboDateFields = new Telerik.WinControls.UI.RadDropDownList();
            this.lblDateFields = new Telerik.WinControls.UI.RadLabel();
            this.cmdAdd = new Telerik.WinControls.UI.RadButton();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFieldType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFieldSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInactive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPhysician)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDynamic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_LookupTbls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLookupTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMultipleSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaxSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDateFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDateFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFieldName
            // 
            this.txtFieldName.Location = new System.Drawing.Point(204, 9);
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(857, 30);
            this.txtFieldName.TabIndex = 0;
            this.txtFieldName.ThemeName = "Aqua";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Label2.Location = new System.Drawing.Point(86, 11);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(112, 28);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Field Name:";
            this.Label2.ThemeName = "Aqua";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Label3.Location = new System.Drawing.Point(95, 43);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(103, 28);
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
            this.cboFieldType.Location = new System.Drawing.Point(204, 47);
            this.cboFieldType.Name = "cboFieldType";
            this.cboFieldType.Size = new System.Drawing.Size(315, 27);
            this.cboFieldType.TabIndex = 3;
            this.cboFieldType.ThemeName = "Aqua";
            this.cboFieldType.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboFieldType_SelectedIndexChanged);
            // 
            // lblFieldSize
            // 
            this.lblFieldSize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFieldSize.Location = new System.Drawing.Point(103, 80);
            this.lblFieldSize.Name = "lblFieldSize";
            this.lblFieldSize.Size = new System.Drawing.Size(95, 28);
            this.lblFieldSize.TabIndex = 5;
            this.lblFieldSize.Text = "Field Size:";
            this.lblFieldSize.ThemeName = "Aqua";
            // 
            // txtFieldSize
            // 
            this.txtFieldSize.Location = new System.Drawing.Point(204, 78);
            this.txtFieldSize.Name = "txtFieldSize";
            this.txtFieldSize.Size = new System.Drawing.Size(54, 30);
            this.txtFieldSize.TabIndex = 4;
            this.txtFieldSize.ThemeName = "Aqua";
            // 
            // chkInactive
            // 
            this.chkInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInactive.Location = new System.Drawing.Point(624, 49);
            this.chkInactive.Name = "chkInactive";
            this.chkInactive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkInactive.Size = new System.Drawing.Size(84, 20);
            this.chkInactive.TabIndex = 6;
            this.chkInactive.Text = ":Inactive";
            this.chkInactive.ThemeName = "Aqua";
            // 
            // chkUTD
            // 
            this.chkUTD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUTD.Location = new System.Drawing.Point(583, 83);
            this.chkUTD.Name = "chkUTD";
            this.chkUTD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkUTD.Size = new System.Drawing.Size(125, 20);
            this.chkUTD.TabIndex = 7;
            this.chkUTD.Text = "?Can Be UTD";
            this.chkUTD.ThemeName = "Aqua";
            // 
            // chkPhysician
            // 
            this.chkPhysician.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPhysician.Location = new System.Drawing.Point(831, 83);
            this.chkPhysician.Name = "chkPhysician";
            this.chkPhysician.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPhysician.Size = new System.Drawing.Size(145, 20);
            this.chkPhysician.TabIndex = 7;
            this.chkPhysician.Text = "?Physician Field";
            this.chkPhysician.ThemeName = "Aqua";
            // 
            // chkDynamic
            // 
            this.chkDynamic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDynamic.ForeColor = System.Drawing.Color.Red;
            this.chkDynamic.Location = new System.Drawing.Point(843, 49);
            this.chkDynamic.Name = "chkDynamic";
            this.chkDynamic.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDynamic.Size = new System.Drawing.Size(133, 20);
            this.chkDynamic.TabIndex = 8;
            this.chkDynamic.Text = ":Dynamic Field";
            this.chkDynamic.ThemeName = "Aqua";
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Label5.Location = new System.Drawing.Point(63, 114);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(135, 28);
            this.Label5.TabIndex = 10;
            this.Label5.Text = "Help Message:";
            this.Label5.ThemeName = "Aqua";
            ((Telerik.WinControls.UI.RadLabelElement)(this.Label5.GetChildAt(0))).Text = "Help Message:";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.Label5.GetChildAt(0).GetChildAt(2).GetChildAt(1))).TextWrap = true;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.Label5.GetChildAt(0).GetChildAt(2).GetChildAt(1))).TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.Label5.GetChildAt(0).GetChildAt(2).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // txtHelp
            // 
            this.txtHelp.Location = new System.Drawing.Point(204, 114);
            this.txtHelp.Multiline = true;
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.Size = new System.Drawing.Size(857, 413);
            this.txtHelp.TabIndex = 9;
            this.txtHelp.ThemeName = "Aqua";
            // 
            // cbo_LookupTbls
            // 
            this.cbo_LookupTbls.Location = new System.Drawing.Point(204, 535);
            this.cbo_LookupTbls.Name = "cbo_LookupTbls";
            this.cbo_LookupTbls.Size = new System.Drawing.Size(857, 27);
            this.cbo_LookupTbls.TabIndex = 12;
            this.cbo_LookupTbls.ThemeName = "Aqua";
            this.cbo_LookupTbls.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cbo_LookupTbls_SelectedIndexChanged);
            // 
            // lblLookupTable
            // 
            this.lblLookupTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLookupTable.Location = new System.Drawing.Point(67, 531);
            this.lblLookupTable.Name = "lblLookupTable";
            this.lblLookupTable.Size = new System.Drawing.Size(131, 28);
            this.lblLookupTable.TabIndex = 11;
            this.lblLookupTable.Text = "Lookup Table:";
            this.lblLookupTable.ThemeName = "Aqua";
            // 
            // chkMultipleSel
            // 
            this.chkMultipleSel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMultipleSel.Location = new System.Drawing.Point(204, 588);
            this.chkMultipleSel.Name = "chkMultipleSel";
            this.chkMultipleSel.Size = new System.Drawing.Size(164, 20);
            this.chkMultipleSel.TabIndex = 13;
            this.chkMultipleSel.Text = "Multiple Selections";
            this.chkMultipleSel.ThemeName = "Aqua";
            this.chkMultipleSel.CheckStateChanged += new System.EventHandler(this.chkMultipleSel_CheckStateChanged);
            // 
            // lblMaxSel
            // 
            this.lblMaxSel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaxSel.Location = new System.Drawing.Point(390, 582);
            this.lblMaxSel.Name = "lblMaxSel";
            this.lblMaxSel.Size = new System.Drawing.Size(153, 28);
            this.lblMaxSel.TabIndex = 15;
            this.lblMaxSel.Text = "(Max Selections)";
            this.lblMaxSel.ThemeName = "Aqua";
            // 
            // txtMaxSel
            // 
            this.txtMaxSel.Location = new System.Drawing.Point(549, 580);
            this.txtMaxSel.Name = "txtMaxSel";
            this.txtMaxSel.Size = new System.Drawing.Size(66, 30);
            this.txtMaxSel.TabIndex = 14;
            this.txtMaxSel.Text = "2";
            this.txtMaxSel.ThemeName = "Aqua";
            // 
            // cboDateFields
            // 
            this.cboDateFields.Location = new System.Drawing.Point(204, 631);
            this.cboDateFields.Name = "cboDateFields";
            this.cboDateFields.Size = new System.Drawing.Size(857, 27);
            this.cboDateFields.TabIndex = 17;
            this.cboDateFields.ThemeName = "Aqua";
            // 
            // lblDateFields
            // 
            this.lblDateFields.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateFields.Location = new System.Drawing.Point(26, 627);
            this.lblDateFields.Name = "lblDateFields";
            // 
            // 
            // 
            this.lblDateFields.RootElement.AutoSize = true;
            this.lblDateFields.Size = new System.Drawing.Size(172, 28);
            this.lblDateFields.TabIndex = 16;
            this.lblDateFields.Text = "Related Date Field:";
            this.lblDateFields.ThemeName = "Aqua";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(379, 677);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(165, 36);
            this.cmdAdd.TabIndex = 18;
            this.cmdAdd.Text = "&Add";
            this.cmdAdd.ThemeName = "Aqua";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(565, 677);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(165, 36);
            this.cmdCancel.TabIndex = 19;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.ThemeName = "Aqua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmTableFieldAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 723);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cboDateFields);
            this.Controls.Add(this.lblDateFields);
            this.Controls.Add(this.lblMaxSel);
            this.Controls.Add(this.txtMaxSel);
            this.Controls.Add(this.chkMultipleSel);
            this.Controls.Add(this.cbo_LookupTbls);
            this.Controls.Add(this.lblLookupTable);
            this.Controls.Add(this.txtHelp);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.chkDynamic);
            this.Controls.Add(this.chkPhysician);
            this.Controls.Add(this.chkUTD);
            this.Controls.Add(this.chkInactive);
            this.Controls.Add(this.lblFieldSize);
            this.Controls.Add(this.txtFieldSize);
            this.Controls.Add(this.cboFieldType);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtFieldName);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmTableFieldAdd";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Add a New Field";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmTableFieldAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFieldType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFieldSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInactive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUTD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPhysician)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDynamic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_LookupTbls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLookupTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMultipleSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaxSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDateFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDateFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadTextBoxControl txtFieldName;
        private Telerik.WinControls.UI.RadTextBoxControl txtFieldSize;
        private Telerik.WinControls.UI.RadLabel Label2;
        private Telerik.WinControls.UI.RadLabel Label3;
        private Telerik.WinControls.UI.RadDropDownList cboFieldType;
        private Telerik.WinControls.UI.RadLabel lblFieldSize;
        private Telerik.WinControls.UI.RadCheckBox chkInactive;
        private Telerik.WinControls.UI.RadCheckBox chkUTD;
        private Telerik.WinControls.UI.RadCheckBox chkPhysician;
        private Telerik.WinControls.UI.RadCheckBox chkDynamic;
        private Telerik.WinControls.UI.RadLabel Label5;
        private Telerik.WinControls.UI.RadTextBoxControl txtHelp;
        private Telerik.WinControls.UI.RadDropDownList cbo_LookupTbls;
        private Telerik.WinControls.UI.RadLabel lblLookupTable;
        private Telerik.WinControls.UI.RadCheckBox chkMultipleSel;
        private Telerik.WinControls.UI.RadLabel lblMaxSel;
        private Telerik.WinControls.UI.RadTextBoxControl txtMaxSel;
        private Telerik.WinControls.UI.RadDropDownList cboDateFields;
        private Telerik.WinControls.UI.RadLabel lblDateFields;
        private Telerik.WinControls.UI.RadButton cmdAdd;
        private Telerik.WinControls.UI.RadButton cmdCancel;
        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
