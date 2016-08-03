namespace COP2001
{
    partial class frmTableValidationAddMsg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTableValidationAddMsg));
            this.txtMessage = new Telerik.WinControls.UI.RadTextBox();
            this.Label2 = new Telerik.WinControls.UI.RadLabel();
            this.Frame1 = new Telerik.WinControls.UI.RadGroupBox();
            this.cmdRemoveField = new Telerik.WinControls.UI.RadButton();
            this.cmdAddfield = new Telerik.WinControls.UI.RadButton();
            this.Label3 = new Telerik.WinControls.UI.RadLabel();
            this.lstFieldstoValidate = new Telerik.WinControls.UI.RadListControl();
            this.cboFieldList = new Telerik.WinControls.UI.RadDropDownList();
            this.Label1 = new Telerik.WinControls.UI.RadLabel();
            this.opt3UpdateField = new Telerik.WinControls.UI.RadRadioButton();
            this.opt2Delete = new Telerik.WinControls.UI.RadRadioButton();
            this.opt1Save = new Telerik.WinControls.UI.RadRadioButton();
            this.cmdAdd = new Telerik.WinControls.UI.RadButton();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            this.Office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.AquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame1)).BeginInit();
            this.Frame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdRemoveField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddfield)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstFieldstoValidate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFieldList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt3UpdateField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt2Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt1Save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.AutoSize = false;
            this.txtMessage.Location = new System.Drawing.Point(35, 57);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(750, 202);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.ThemeName = "Aqua";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Label2.Location = new System.Drawing.Point(319, 23);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(182, 28);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Show This Message:";
            this.Label2.ThemeName = "Aqua";
            // 
            // Frame1
            // 
            this.Frame1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.Frame1.Controls.Add(this.cmdAdd);
            this.Frame1.Controls.Add(this.cmdCancel);
            this.Frame1.Controls.Add(this.cmdRemoveField);
            this.Frame1.Controls.Add(this.cmdAddfield);
            this.Frame1.Controls.Add(this.Label3);
            this.Frame1.Controls.Add(this.lstFieldstoValidate);
            this.Frame1.Controls.Add(this.cboFieldList);
            this.Frame1.Controls.Add(this.Label1);
            this.Frame1.Controls.Add(this.opt3UpdateField);
            this.Frame1.Controls.Add(this.opt2Delete);
            this.Frame1.Controls.Add(this.opt1Save);
            this.Frame1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.Frame1.HeaderText = "When User Takes This Action";
            this.Frame1.Location = new System.Drawing.Point(0, 295);
            this.Frame1.Name = "Frame1";
            this.Frame1.Size = new System.Drawing.Size(820, 344);
            this.Frame1.TabIndex = 2;
            this.Frame1.Text = "When User Takes This Action";
            this.Frame1.ThemeName = "Aqua";
            // 
            // cmdRemoveField
            // 
            this.cmdRemoveField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoveField.Location = new System.Drawing.Point(580, 167);
            this.cmdRemoveField.Name = "cmdRemoveField";
            this.cmdRemoveField.Size = new System.Drawing.Size(165, 36);
            this.cmdRemoveField.TabIndex = 8;
            this.cmdRemoveField.Text = "&Remove from List";
            this.cmdRemoveField.ThemeName = "Aqua";
            this.cmdRemoveField.Click += new System.EventHandler(this.cmdRemoveField_Click);
            // 
            // cmdAddfield
            // 
            this.cmdAddfield.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddfield.Location = new System.Drawing.Point(580, 106);
            this.cmdAddfield.Name = "cmdAddfield";
            this.cmdAddfield.Size = new System.Drawing.Size(165, 36);
            this.cmdAddfield.TabIndex = 7;
            this.cmdAddfield.Text = "Add To &List";
            this.cmdAddfield.ThemeName = "Aqua";
            this.cmdAddfield.Click += new System.EventHandler(this.cmdAddfield_Click);
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Label3.Location = new System.Drawing.Point(223, 142);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(139, 28);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "Selected fields:";
            this.Label3.ThemeName = "Aqua";
            // 
            // lstFieldstoValidate
            // 
            this.lstFieldstoValidate.Location = new System.Drawing.Point(22, 176);
            this.lstFieldstoValidate.Name = "lstFieldstoValidate";
            this.lstFieldstoValidate.Size = new System.Drawing.Size(539, 146);
            this.lstFieldstoValidate.TabIndex = 5;
            this.lstFieldstoValidate.ThemeName = "Aqua";
            // 
            // cboFieldList
            // 
            this.cboFieldList.Location = new System.Drawing.Point(22, 106);
            this.cboFieldList.Name = "cboFieldList";
            this.cboFieldList.Size = new System.Drawing.Size(539, 27);
            this.cboFieldList.TabIndex = 4;
            this.cboFieldList.ThemeName = "Aqua";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Label1.Location = new System.Drawing.Point(201, 72);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(192, 28);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Select From This List:";
            this.Label1.ThemeName = "Aqua";
            // 
            // opt3UpdateField
            // 
            this.opt3UpdateField.Location = new System.Drawing.Point(522, 33);
            this.opt3UpdateField.Name = "opt3UpdateField";
            this.opt3UpdateField.Size = new System.Drawing.Size(194, 26);
            this.opt3UpdateField.TabIndex = 2;
            this.opt3UpdateField.Text = "Updating Field(s)";
            this.opt3UpdateField.ThemeName = "Aqua";
            this.opt3UpdateField.CheckStateChanged += new System.EventHandler(this.opt3UpdateField_CheckStateChanged);
            // 
            // opt2Delete
            // 
            this.opt2Delete.Location = new System.Drawing.Point(286, 33);
            this.opt2Delete.Name = "opt2Delete";
            this.opt2Delete.Size = new System.Drawing.Size(181, 26);
            this.opt2Delete.TabIndex = 1;
            this.opt2Delete.Text = "Deleting Record";
            this.opt2Delete.ThemeName = "Aqua";
            this.opt2Delete.CheckStateChanged += new System.EventHandler(this.opt2Delete_CheckStateChanged);
            // 
            // opt1Save
            // 
            this.opt1Save.Location = new System.Drawing.Point(62, 33);
            this.opt1Save.Name = "opt1Save";
            this.opt1Save.Size = new System.Drawing.Size(166, 26);
            this.opt1Save.TabIndex = 0;
            this.opt1Save.Text = "Saving Record";
            this.opt1Save.ThemeName = "Aqua";
            this.opt1Save.CheckStateChanged += new System.EventHandler(this.opt1Save_CheckStateChanged);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.Location = new System.Drawing.Point(580, 228);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(165, 36);
            this.cmdAdd.TabIndex = 3;
            this.cmdAdd.Text = "&Add";
            this.cmdAdd.ThemeName = "Aqua";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(580, 289);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(165, 36);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.ThemeName = "Aqua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmTableValidationAddMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 639);
            this.Controls.Add(this.Frame1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtMessage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmTableValidationAddMsg";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Add Validation Message";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmTableValidationAddMsg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame1)).EndInit();
            this.Frame1.ResumeLayout(false);
            this.Frame1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdRemoveField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddfield)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstFieldstoValidate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFieldList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt3UpdateField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt2Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt1Save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadTextBox txtMessage;
        private Telerik.WinControls.UI.RadLabel Label2;
        private Telerik.WinControls.UI.RadGroupBox Frame1;
        private Telerik.WinControls.UI.RadButton cmdRemoveField;
        private Telerik.WinControls.UI.RadButton cmdAddfield;
        private Telerik.WinControls.UI.RadLabel Label3;
        private Telerik.WinControls.UI.RadListControl lstFieldstoValidate;
        private Telerik.WinControls.UI.RadDropDownList cboFieldList;
        private Telerik.WinControls.UI.RadLabel Label1;
        private Telerik.WinControls.UI.RadRadioButton opt3UpdateField;
        private Telerik.WinControls.UI.RadRadioButton opt2Delete;
        private Telerik.WinControls.UI.RadRadioButton opt1Save;
        private Telerik.WinControls.UI.RadButton cmdAdd;
        private Telerik.WinControls.UI.RadButton cmdCancel;
        private Telerik.WinControls.Themes.Office2010SilverTheme Office2010SilverTheme1;
        private Telerik.WinControls.Themes.AquaTheme AquaTheme1;
    }
}
