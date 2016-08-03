using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
namespace COP2001
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	partial class OldfrmTableFieldAdd
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmTableFieldAdd() : base()
		{
			Load += frmTableFieldAdd_Load;
			//This call is required by the Windows Form Designer.
			InitializeComponent();
		}
//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool Disposing)
		{
			if (Disposing) {
				if ((components != null)) {
					components.Dispose();
				}
			}
			base.Dispose(Disposing);
		}
//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTip1;
		public System.Windows.Forms.CheckBox chkDynamic;
		public System.Windows.Forms.CheckBox chkPhysician;
		public System.Windows.Forms.TextBox txtFieldSize;
		private System.Windows.Forms.ComboBox withEventsField_cboFieldType;
		public System.Windows.Forms.ComboBox cboFieldType {
			get { return withEventsField_cboFieldType; }
			set {
				if (withEventsField_cboFieldType != null) {
					withEventsField_cboFieldType.SelectedIndexChanged -= cboFieldType_SelectedIndexChanged;
					withEventsField_cboFieldType.Leave -= cboFieldType_Leave;
				}
				withEventsField_cboFieldType = value;
				if (withEventsField_cboFieldType != null) {
					withEventsField_cboFieldType.SelectedIndexChanged += cboFieldType_SelectedIndexChanged;
					withEventsField_cboFieldType.Leave += cboFieldType_Leave;
				}
			}
		}
		public System.Windows.Forms.TextBox txtHelp;
		public System.Windows.Forms.TextBox txtFieldName;
		private System.Windows.Forms.ComboBox withEventsField_cbo_LookupTbls;
		public System.Windows.Forms.ComboBox cbo_LookupTbls {
			get { return withEventsField_cbo_LookupTbls; }
			set {
				if (withEventsField_cbo_LookupTbls != null) {
					withEventsField_cbo_LookupTbls.SelectedIndexChanged -= cbo_LookupTbls_SelectedIndexChanged;
				}
				withEventsField_cbo_LookupTbls = value;
				if (withEventsField_cbo_LookupTbls != null) {
					withEventsField_cbo_LookupTbls.SelectedIndexChanged += cbo_LookupTbls_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboDateFields;
		public System.Windows.Forms.CheckBox chkInactive;
		private System.Windows.Forms.CheckBox withEventsField_chkMultipleSel;
		public System.Windows.Forms.CheckBox chkMultipleSel {
			get { return withEventsField_chkMultipleSel; }
			set {
				if (withEventsField_chkMultipleSel != null) {
					withEventsField_chkMultipleSel.CheckStateChanged -= chkMultipleSel_CheckStateChanged;
				}
				withEventsField_chkMultipleSel = value;
				if (withEventsField_chkMultipleSel != null) {
					withEventsField_chkMultipleSel.CheckStateChanged += chkMultipleSel_CheckStateChanged;
				}
			}
		}
		public System.Windows.Forms.TextBox txtMaxSel;
		public System.Windows.Forms.CheckBox chkUTD;
		private System.Windows.Forms.Button withEventsField_cmdCancel;
		public System.Windows.Forms.Button cmdCancel {
			get { return withEventsField_cmdCancel; }
			set {
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click -= cmdCancel_Click;
				}
				withEventsField_cmdCancel = value;
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click += cmdCancel_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAdd;
		public System.Windows.Forms.Button cmdAdd {
			get { return withEventsField_cmdAdd; }
			set {
				if (withEventsField_cmdAdd != null) {
					withEventsField_cmdAdd.Click -= cmdAdd_Click;
				}
				withEventsField_cmdAdd = value;
				if (withEventsField_cmdAdd != null) {
					withEventsField_cmdAdd.Click += cmdAdd_Click;
				}
			}
		}
		public AxMSRDC.AxMSRDC rdcLookupTableList;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label lblFieldSize;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label lblLookupTable;
		public System.Windows.Forms.Label lblDateFields;
		public System.Windows.Forms.Label lblMaxSel;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmTableFieldAdd));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.chkDynamic = new System.Windows.Forms.CheckBox();
			this.chkPhysician = new System.Windows.Forms.CheckBox();
			this.txtFieldSize = new System.Windows.Forms.TextBox();
			this.cboFieldType = new System.Windows.Forms.ComboBox();
			this.txtHelp = new System.Windows.Forms.TextBox();
			this.txtFieldName = new System.Windows.Forms.TextBox();
			this.cbo_LookupTbls = new System.Windows.Forms.ComboBox();
			this.cboDateFields = new System.Windows.Forms.ComboBox();
			this.chkInactive = new System.Windows.Forms.CheckBox();
			this.chkMultipleSel = new System.Windows.Forms.CheckBox();
			this.txtMaxSel = new System.Windows.Forms.TextBox();
			this.chkUTD = new System.Windows.Forms.CheckBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.rdcLookupTableList = new AxMSRDC.AxMSRDC();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.lblFieldSize = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.lblLookupTable = new System.Windows.Forms.Label();
			this.lblDateFields = new System.Windows.Forms.Label();
			this.lblMaxSel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.rdcLookupTableList).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Text = "Add a new Field";
			this.ClientSize = new System.Drawing.Size(950, 685);
			this.Location = new System.Drawing.Point(5, 29);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
			this.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ControlBox = true;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmTableFieldAdd";
			this.chkDynamic.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkDynamic.Text = "Dynamic Field";
			this.chkDynamic.ForeColor = System.Drawing.Color.Red;
			this.chkDynamic.Size = new System.Drawing.Size(172, 22);
			this.chkDynamic.Location = new System.Drawing.Point(500, 30);
			this.chkDynamic.TabIndex = 20;
			this.chkDynamic.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkDynamic.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkDynamic.BackColor = System.Drawing.SystemColors.Control;
			this.chkDynamic.CausesValidation = true;
			this.chkDynamic.Enabled = true;
			this.chkDynamic.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkDynamic.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDynamic.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkDynamic.TabStop = true;
			this.chkDynamic.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkDynamic.Visible = true;
			this.chkDynamic.Name = "chkDynamic";
			this.chkPhysician.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkPhysician.Text = "Physician Field?";
			this.chkPhysician.Size = new System.Drawing.Size(172, 22);
			this.chkPhysician.Location = new System.Drawing.Point(499, 60);
			this.chkPhysician.TabIndex = 19;
			this.chkPhysician.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkPhysician.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkPhysician.BackColor = System.Drawing.SystemColors.Control;
			this.chkPhysician.CausesValidation = true;
			this.chkPhysician.Enabled = true;
			this.chkPhysician.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkPhysician.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkPhysician.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkPhysician.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkPhysician.TabStop = true;
			this.chkPhysician.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkPhysician.Visible = true;
			this.chkPhysician.Name = "chkPhysician";
			this.txtFieldSize.AutoSize = false;
			this.txtFieldSize.Size = new System.Drawing.Size(43, 27);
			this.txtFieldSize.Location = new System.Drawing.Point(92, 65);
			this.txtFieldSize.TabIndex = 11;
			this.txtFieldSize.Visible = false;
			this.txtFieldSize.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtFieldSize.AcceptsReturn = true;
			this.txtFieldSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtFieldSize.BackColor = System.Drawing.SystemColors.Window;
			this.txtFieldSize.CausesValidation = true;
			this.txtFieldSize.Enabled = true;
			this.txtFieldSize.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFieldSize.HideSelection = true;
			this.txtFieldSize.ReadOnly = false;
			this.txtFieldSize.MaxLength = 0;
			this.txtFieldSize.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtFieldSize.Multiline = false;
			this.txtFieldSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtFieldSize.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtFieldSize.TabStop = true;
			this.txtFieldSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtFieldSize.Name = "txtFieldSize";
			this.cboFieldType.Size = new System.Drawing.Size(184, 27);
			this.cboFieldType.Location = new System.Drawing.Point(92, 32);
			this.cboFieldType.Items.AddRange(new object[] {
				"Date",
				"Number",
				"Text",
				"Time",
				"Date/Time"
			});
			this.cboFieldType.TabIndex = 10;
			this.cboFieldType.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboFieldType.BackColor = System.Drawing.SystemColors.Window;
			this.cboFieldType.CausesValidation = true;
			this.cboFieldType.Enabled = true;
			this.cboFieldType.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboFieldType.IntegralHeight = true;
			this.cboFieldType.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboFieldType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboFieldType.Sorted = false;
			this.cboFieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboFieldType.TabStop = true;
			this.cboFieldType.Visible = true;
			this.cboFieldType.Name = "cboFieldType";
			this.txtHelp.AutoSize = false;
			this.txtHelp.Size = new System.Drawing.Size(817, 355);
			this.txtHelp.Location = new System.Drawing.Point(92, 97);
			this.txtHelp.Multiline = true;
			this.txtHelp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtHelp.WordWrap = false;
			this.txtHelp.TabIndex = 9;
			this.txtHelp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtHelp.AcceptsReturn = true;
			this.txtHelp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtHelp.BackColor = System.Drawing.SystemColors.Window;
			this.txtHelp.CausesValidation = true;
			this.txtHelp.Enabled = true;
			this.txtHelp.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtHelp.HideSelection = true;
			this.txtHelp.ReadOnly = false;
			this.txtHelp.MaxLength = 0;
			this.txtHelp.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtHelp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtHelp.TabStop = true;
			this.txtHelp.Visible = true;
			this.txtHelp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtHelp.Name = "txtHelp";
			this.txtFieldName.AutoSize = false;
			this.txtFieldName.Size = new System.Drawing.Size(808, 27);
			this.txtFieldName.Location = new System.Drawing.Point(92, 0);
			this.txtFieldName.TabIndex = 8;
			this.txtFieldName.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtFieldName.AcceptsReturn = true;
			this.txtFieldName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtFieldName.BackColor = System.Drawing.SystemColors.Window;
			this.txtFieldName.CausesValidation = true;
			this.txtFieldName.Enabled = true;
			this.txtFieldName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFieldName.HideSelection = true;
			this.txtFieldName.ReadOnly = false;
			this.txtFieldName.MaxLength = 0;
			this.txtFieldName.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtFieldName.Multiline = false;
			this.txtFieldName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtFieldName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtFieldName.TabStop = true;
			this.txtFieldName.Visible = true;
			this.txtFieldName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtFieldName.Name = "txtFieldName";
			this.cbo_LookupTbls.Size = new System.Drawing.Size(797, 27);
			this.cbo_LookupTbls.Location = new System.Drawing.Point(112, 467);
			this.cbo_LookupTbls.TabIndex = 7;
			this.cbo_LookupTbls.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cbo_LookupTbls.BackColor = System.Drawing.SystemColors.Window;
			this.cbo_LookupTbls.CausesValidation = true;
			this.cbo_LookupTbls.Enabled = true;
			this.cbo_LookupTbls.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cbo_LookupTbls.IntegralHeight = true;
			this.cbo_LookupTbls.Cursor = System.Windows.Forms.Cursors.Default;
			this.cbo_LookupTbls.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cbo_LookupTbls.Sorted = false;
			this.cbo_LookupTbls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cbo_LookupTbls.TabStop = true;
			this.cbo_LookupTbls.Visible = true;
			this.cbo_LookupTbls.Name = "cbo_LookupTbls";
			this.cboDateFields.Size = new System.Drawing.Size(797, 27);
			this.cboDateFields.Location = new System.Drawing.Point(112, 598);
			this.cboDateFields.TabIndex = 6;
			this.cboDateFields.Visible = false;
			this.cboDateFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboDateFields.BackColor = System.Drawing.SystemColors.Window;
			this.cboDateFields.CausesValidation = true;
			this.cboDateFields.Enabled = true;
			this.cboDateFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboDateFields.IntegralHeight = true;
			this.cboDateFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboDateFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboDateFields.Sorted = false;
			this.cboDateFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboDateFields.TabStop = true;
			this.cboDateFields.Name = "cboDateFields";
			this.chkInactive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkInactive.Text = "Inactive:";
			this.chkInactive.Size = new System.Drawing.Size(148, 19);
			this.chkInactive.Location = new System.Drawing.Point(289, 32);
			this.chkInactive.TabIndex = 5;
			this.chkInactive.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkInactive.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkInactive.BackColor = System.Drawing.SystemColors.Control;
			this.chkInactive.CausesValidation = true;
			this.chkInactive.Enabled = true;
			this.chkInactive.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkInactive.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkInactive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkInactive.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkInactive.TabStop = true;
			this.chkInactive.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkInactive.Visible = true;
			this.chkInactive.Name = "chkInactive";
			this.chkMultipleSel.Text = "Multiple Selections";
			this.chkMultipleSel.Enabled = false;
			this.chkMultipleSel.Size = new System.Drawing.Size(142, 32);
			this.chkMultipleSel.Location = new System.Drawing.Point(29, 520);
			this.chkMultipleSel.TabIndex = 4;
			this.chkMultipleSel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkMultipleSel.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkMultipleSel.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkMultipleSel.BackColor = System.Drawing.SystemColors.Control;
			this.chkMultipleSel.CausesValidation = true;
			this.chkMultipleSel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkMultipleSel.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkMultipleSel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkMultipleSel.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkMultipleSel.TabStop = true;
			this.chkMultipleSel.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkMultipleSel.Visible = true;
			this.chkMultipleSel.Name = "chkMultipleSel";
			this.txtMaxSel.AutoSize = false;
			this.txtMaxSel.Enabled = false;
			this.txtMaxSel.Size = new System.Drawing.Size(62, 24);
			this.txtMaxSel.Location = new System.Drawing.Point(169, 520);
			this.txtMaxSel.TabIndex = 3;
			this.txtMaxSel.Text = "2";
			this.txtMaxSel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtMaxSel.AcceptsReturn = true;
			this.txtMaxSel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtMaxSel.BackColor = System.Drawing.SystemColors.Window;
			this.txtMaxSel.CausesValidation = true;
			this.txtMaxSel.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtMaxSel.HideSelection = true;
			this.txtMaxSel.ReadOnly = false;
			this.txtMaxSel.MaxLength = 0;
			this.txtMaxSel.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMaxSel.Multiline = false;
			this.txtMaxSel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtMaxSel.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtMaxSel.TabStop = true;
			this.txtMaxSel.Visible = true;
			this.txtMaxSel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtMaxSel.Name = "txtMaxSel";
			this.chkUTD.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkUTD.Text = "Can Be UTD?";
			this.chkUTD.Size = new System.Drawing.Size(148, 19);
			this.chkUTD.Location = new System.Drawing.Point(289, 60);
			this.chkUTD.TabIndex = 2;
			this.chkUTD.Visible = false;
			this.chkUTD.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkUTD.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkUTD.BackColor = System.Drawing.SystemColors.Control;
			this.chkUTD.CausesValidation = true;
			this.chkUTD.Enabled = true;
			this.chkUTD.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkUTD.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkUTD.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkUTD.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkUTD.TabStop = true;
			this.chkUTD.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkUTD.Name = "chkUTD";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(88, 28);
			this.cmdCancel.Location = new System.Drawing.Point(253, 645);
			this.cmdCancel.TabIndex = 1;
			this.cmdCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAdd.Text = "Add";
			this.cmdAdd.Size = new System.Drawing.Size(88, 28);
			this.cmdAdd.Location = new System.Drawing.Point(150, 645);
			this.cmdAdd.TabIndex = 0;
			this.cmdAdd.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdd.CausesValidation = true;
			this.cmdAdd.Enabled = true;
			this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdd.TabStop = true;
			this.cmdAdd.Name = "cmdAdd";
			rdcLookupTableList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcLookupTableList.OcxState");
			this.rdcLookupTableList.Size = new System.Drawing.Size(178, 28);
			this.rdcLookupTableList.Location = new System.Drawing.Point(30, 680);
			this.rdcLookupTableList.Visible = false;
			this.rdcLookupTableList.Name = "rdcLookupTableList";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label2.Text = "Field Name:";
			this.Label2.Size = new System.Drawing.Size(87, 20);
			this.Label2.Location = new System.Drawing.Point(0, 0);
			this.Label2.TabIndex = 18;
			this.Label2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.BackColor = System.Drawing.SystemColors.Control;
			this.Label2.Enabled = true;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label3.Text = "Field Type:";
			this.Label3.Size = new System.Drawing.Size(87, 20);
			this.Label3.Location = new System.Drawing.Point(0, 34);
			this.Label3.TabIndex = 17;
			this.Label3.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Enabled = true;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.lblFieldSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblFieldSize.Text = "Field Size:";
			this.lblFieldSize.Size = new System.Drawing.Size(87, 20);
			this.lblFieldSize.Location = new System.Drawing.Point(0, 68);
			this.lblFieldSize.TabIndex = 16;
			this.lblFieldSize.Visible = false;
			this.lblFieldSize.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblFieldSize.BackColor = System.Drawing.SystemColors.Control;
			this.lblFieldSize.Enabled = true;
			this.lblFieldSize.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblFieldSize.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblFieldSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblFieldSize.UseMnemonic = true;
			this.lblFieldSize.AutoSize = false;
			this.lblFieldSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblFieldSize.Name = "lblFieldSize";
			this.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label5.Text = "Help Message:";
			this.Label5.Size = new System.Drawing.Size(87, 39);
			this.Label5.Location = new System.Drawing.Point(0, 98);
			this.Label5.TabIndex = 15;
			this.Label5.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label5.BackColor = System.Drawing.SystemColors.Control;
			this.Label5.Enabled = true;
			this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label5.UseMnemonic = true;
			this.Label5.Visible = true;
			this.Label5.AutoSize = false;
			this.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label5.Name = "Label5";
			this.lblLookupTable.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblLookupTable.Text = "Lookup Table:";
			this.lblLookupTable.Size = new System.Drawing.Size(87, 20);
			this.lblLookupTable.Location = new System.Drawing.Point(20, 470);
			this.lblLookupTable.TabIndex = 14;
			this.lblLookupTable.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblLookupTable.BackColor = System.Drawing.SystemColors.Control;
			this.lblLookupTable.Enabled = true;
			this.lblLookupTable.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblLookupTable.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblLookupTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblLookupTable.UseMnemonic = true;
			this.lblLookupTable.Visible = true;
			this.lblLookupTable.AutoSize = false;
			this.lblLookupTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblLookupTable.Name = "lblLookupTable";
			this.lblDateFields.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblDateFields.Text = "Related Date Field:";
			this.lblDateFields.Size = new System.Drawing.Size(104, 32);
			this.lblDateFields.Location = new System.Drawing.Point(5, 595);
			this.lblDateFields.TabIndex = 13;
			this.lblDateFields.Visible = false;
			this.lblDateFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblDateFields.BackColor = System.Drawing.SystemColors.Control;
			this.lblDateFields.Enabled = true;
			this.lblDateFields.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDateFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDateFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDateFields.UseMnemonic = true;
			this.lblDateFields.AutoSize = false;
			this.lblDateFields.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblDateFields.Name = "lblDateFields";
			this.lblMaxSel.Text = "(Max Selections)";
			this.lblMaxSel.Enabled = false;
			this.lblMaxSel.Size = new System.Drawing.Size(82, 42);
			this.lblMaxSel.Location = new System.Drawing.Point(239, 510);
			this.lblMaxSel.TabIndex = 12;
			this.lblMaxSel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblMaxSel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblMaxSel.BackColor = System.Drawing.SystemColors.Control;
			this.lblMaxSel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblMaxSel.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblMaxSel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblMaxSel.UseMnemonic = true;
			this.lblMaxSel.Visible = true;
			this.lblMaxSel.AutoSize = false;
			this.lblMaxSel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblMaxSel.Name = "lblMaxSel";
			this.Controls.Add(chkDynamic);
			this.Controls.Add(chkPhysician);
			this.Controls.Add(txtFieldSize);
			this.Controls.Add(cboFieldType);
			this.Controls.Add(txtHelp);
			this.Controls.Add(txtFieldName);
			this.Controls.Add(cbo_LookupTbls);
			this.Controls.Add(cboDateFields);
			this.Controls.Add(chkInactive);
			this.Controls.Add(chkMultipleSel);
			this.Controls.Add(txtMaxSel);
			this.Controls.Add(chkUTD);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdAdd);
			this.Controls.Add(rdcLookupTableList);
			this.Controls.Add(Label2);
			this.Controls.Add(Label3);
			this.Controls.Add(lblFieldSize);
			this.Controls.Add(Label5);
			this.Controls.Add(lblLookupTable);
			this.Controls.Add(lblDateFields);
			this.Controls.Add(lblMaxSel);
			((System.ComponentModel.ISupportInitialize)this.rdcLookupTableList).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
