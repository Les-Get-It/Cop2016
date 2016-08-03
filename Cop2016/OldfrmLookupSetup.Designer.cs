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
	partial class OldfrmLookupSetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmLookupSetup() : base()
		{
			Load += frmLookupSetup_Load;
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = My.MyProject.Forms.frmMasterForm;
			My.MyProject.Forms.frmMasterForm.Show();
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
		private System.Windows.Forms.RadioButton withEventsField_OptLKValue;
		public System.Windows.Forms.RadioButton OptLKValue {
			get { return withEventsField_OptLKValue; }
			set {
				if (withEventsField_OptLKValue != null) {
					withEventsField_OptLKValue.CheckedChanged -= OptLKValue_CheckedChanged;
				}
				withEventsField_OptLKValue = value;
				if (withEventsField_OptLKValue != null) {
					withEventsField_OptLKValue.CheckedChanged += OptLKValue_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_optID;
		public System.Windows.Forms.RadioButton optID {
			get { return withEventsField_optID; }
			set {
				if (withEventsField_optID != null) {
					withEventsField_optID.CheckedChanged -= optID_CheckedChanged;
				}
				withEventsField_optID = value;
				if (withEventsField_optID != null) {
					withEventsField_optID.CheckedChanged += optID_CheckedChanged;
				}
			}
		}
		public System.Windows.Forms.GroupBox fraLk;
		public System.Windows.Forms.GroupBox Frame1;
		private System.Windows.Forms.Button withEventsField_cmdImport;
		public System.Windows.Forms.Button cmdImport {
			get { return withEventsField_cmdImport; }
			set {
				if (withEventsField_cmdImport != null) {
					withEventsField_cmdImport.Click -= cmdImport_Click;
				}
				withEventsField_cmdImport = value;
				if (withEventsField_cmdImport != null) {
					withEventsField_cmdImport.Click += cmdImport_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdEdit;
		public System.Windows.Forms.Button cmdEdit {
			get { return withEventsField_cmdEdit; }
			set {
				if (withEventsField_cmdEdit != null) {
					withEventsField_cmdEdit.Click -= cmdEdit_Click;
				}
				withEventsField_cmdEdit = value;
				if (withEventsField_cmdEdit != null) {
					withEventsField_cmdEdit.Click += cmdEdit_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdMoveDown;
		public System.Windows.Forms.Button cmdMoveDown {
			get { return withEventsField_cmdMoveDown; }
			set {
				if (withEventsField_cmdMoveDown != null) {
					withEventsField_cmdMoveDown.Click -= cmdMoveDown_Click;
				}
				withEventsField_cmdMoveDown = value;
				if (withEventsField_cmdMoveDown != null) {
					withEventsField_cmdMoveDown.Click += cmdMoveDown_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdMoveUp;
		public System.Windows.Forms.Button cmdMoveUp {
			get { return withEventsField_cmdMoveUp; }
			set {
				if (withEventsField_cmdMoveUp != null) {
					withEventsField_cmdMoveUp.Click -= cmdMoveUp_Click;
				}
				withEventsField_cmdMoveUp = value;
				if (withEventsField_cmdMoveUp != null) {
					withEventsField_cmdMoveUp.Click += cmdMoveUp_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDelete;
		public System.Windows.Forms.Button cmdDelete {
			get { return withEventsField_cmdDelete; }
			set {
				if (withEventsField_cmdDelete != null) {
					withEventsField_cmdDelete.Click -= cmdDelete_Click;
				}
				withEventsField_cmdDelete = value;
				if (withEventsField_cmdDelete != null) {
					withEventsField_cmdDelete.Click += cmdDelete_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddLookupTable;
		public System.Windows.Forms.Button cmdAddLookupTable {
			get { return withEventsField_cmdAddLookupTable; }
			set {
				if (withEventsField_cmdAddLookupTable != null) {
					withEventsField_cmdAddLookupTable.Click -= cmdAddLookupTable_Click;
				}
				withEventsField_cmdAddLookupTable = value;
				if (withEventsField_cmdAddLookupTable != null) {
					withEventsField_cmdAddLookupTable.Click += cmdAddLookupTable_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdClose;
		public System.Windows.Forms.Button cmdClose {
			get { return withEventsField_cmdClose; }
			set {
				if (withEventsField_cmdClose != null) {
					withEventsField_cmdClose.Click -= cmdClose_Click;
				}
				withEventsField_cmdClose = value;
				if (withEventsField_cmdClose != null) {
					withEventsField_cmdClose.Click += cmdClose_Click;
				}
			}
		}
		private System.Windows.Forms.ComboBox withEventsField_cboLookupTableList;
		public System.Windows.Forms.ComboBox cboLookupTableList {
			get { return withEventsField_cboLookupTableList; }
			set {
				if (withEventsField_cboLookupTableList != null) {
					withEventsField_cboLookupTableList.SelectedIndexChanged -= cboLookupTableList_SelectedIndexChanged;
				}
				withEventsField_cboLookupTableList = value;
				if (withEventsField_cboLookupTableList != null) {
					withEventsField_cboLookupTableList.SelectedIndexChanged += cboLookupTableList_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdEditLookup;
		public System.Windows.Forms.Button cmdEditLookup {
			get { return withEventsField_cmdEditLookup; }
			set {
				if (withEventsField_cmdEditLookup != null) {
					withEventsField_cmdEditLookup.Click -= cmdEditLookup_Click;
				}
				withEventsField_cmdEditLookup = value;
				if (withEventsField_cmdEditLookup != null) {
					withEventsField_cmdEditLookup.Click += cmdEditLookup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDelLookup;
		public System.Windows.Forms.Button cmdDelLookup {
			get { return withEventsField_cmdDelLookup; }
			set {
				if (withEventsField_cmdDelLookup != null) {
					withEventsField_cmdDelLookup.Click -= cmdDelLookup_Click;
				}
				withEventsField_cmdDelLookup = value;
				if (withEventsField_cmdDelLookup != null) {
					withEventsField_cmdDelLookup.Click += cmdDelLookup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddLookupValue;
		public System.Windows.Forms.Button cmdAddLookupValue {
			get { return withEventsField_cmdAddLookupValue; }
			set {
				if (withEventsField_cmdAddLookupValue != null) {
					withEventsField_cmdAddLookupValue.Click -= cmdAddLookupValue_Click;
				}
				withEventsField_cmdAddLookupValue = value;
				if (withEventsField_cmdAddLookupValue != null) {
					withEventsField_cmdAddLookupValue.Click += cmdAddLookupValue_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox txtLookupValue;
		public System.Windows.Forms.TextBox txtID;
		public AxMSRDC.AxMSRDC rdcLookupTableList;
		public AxMSRDC.AxMSRDC rdcLookupList;
		public AxMSDBGrid.AxDBGrid dbgLookupList;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label3;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmLookupSetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.fraLk = new System.Windows.Forms.GroupBox();
			this.OptLKValue = new System.Windows.Forms.RadioButton();
			this.optID = new System.Windows.Forms.RadioButton();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.cmdImport = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdMoveDown = new System.Windows.Forms.Button();
			this.cmdMoveUp = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdAddLookupTable = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cboLookupTableList = new System.Windows.Forms.ComboBox();
			this.cmdEditLookup = new System.Windows.Forms.Button();
			this.cmdDelLookup = new System.Windows.Forms.Button();
			this.cmdAddLookupValue = new System.Windows.Forms.Button();
			this.txtLookupValue = new System.Windows.Forms.TextBox();
			this.txtID = new System.Windows.Forms.TextBox();
			this.rdcLookupTableList = new AxMSRDC.AxMSRDC();
			this.rdcLookupList = new AxMSRDC.AxMSRDC();
			this.dbgLookupList = new AxMSDBGrid.AxDBGrid();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.fraLk.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.rdcLookupTableList).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcLookupList).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dbgLookupList).BeginInit();
			this.Text = "Lookup Table Setup";
			this.ClientSize = new System.Drawing.Size(808, 438);
			this.Location = new System.Drawing.Point(5, 29);
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
			this.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.ControlBox = true;
			this.Enabled = true;
			this.KeyPreview = false;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmLookupSetup";
			this.fraLk.Text = "Compare Table Values to:";
			this.fraLk.Enabled = false;
			this.fraLk.Size = new System.Drawing.Size(224, 64);
			this.fraLk.Location = new System.Drawing.Point(510, 90);
			this.fraLk.TabIndex = 15;
			this.fraLk.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.fraLk.BackColor = System.Drawing.SystemColors.Control;
			this.fraLk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraLk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraLk.Visible = true;
			this.fraLk.Padding = new System.Windows.Forms.Padding(0);
			this.fraLk.Name = "fraLk";
			this.OptLKValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptLKValue.Text = "Lookup Value";
			this.OptLKValue.Size = new System.Drawing.Size(122, 19);
			this.OptLKValue.Location = new System.Drawing.Point(17, 40);
			this.OptLKValue.TabIndex = 17;
			this.OptLKValue.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OptLKValue.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptLKValue.BackColor = System.Drawing.SystemColors.Control;
			this.OptLKValue.CausesValidation = true;
			this.OptLKValue.Enabled = true;
			this.OptLKValue.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OptLKValue.Cursor = System.Windows.Forms.Cursors.Default;
			this.OptLKValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptLKValue.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptLKValue.TabStop = true;
			this.OptLKValue.Checked = false;
			this.OptLKValue.Visible = true;
			this.OptLKValue.Name = "OptLKValue";
			this.optID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optID.Text = "ID";
			this.optID.Size = new System.Drawing.Size(122, 19);
			this.optID.Location = new System.Drawing.Point(17, 20);
			this.optID.TabIndex = 16;
			this.optID.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optID.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optID.BackColor = System.Drawing.SystemColors.Control;
			this.optID.CausesValidation = true;
			this.optID.Enabled = true;
			this.optID.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optID.Cursor = System.Windows.Forms.Cursors.Default;
			this.optID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optID.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optID.TabStop = true;
			this.optID.Checked = false;
			this.optID.Visible = true;
			this.optID.Name = "optID";
			this.Frame1.Text = "Lookup Table Preferences";
			this.Frame1.Size = new System.Drawing.Size(314, 254);
			this.Frame1.Location = new System.Drawing.Point(480, 60);
			this.Frame1.TabIndex = 19;
			this.Frame1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.cmdImport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdImport.Text = "Import values from *.csv List";
			this.cmdImport.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdImport.Size = new System.Drawing.Size(162, 52);
			this.cmdImport.Location = new System.Drawing.Point(510, 350);
			this.cmdImport.TabIndex = 18;
			this.cmdImport.BackColor = System.Drawing.SystemColors.Control;
			this.cmdImport.CausesValidation = true;
			this.cmdImport.Enabled = true;
			this.cmdImport.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdImport.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdImport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdImport.TabStop = true;
			this.cmdImport.Name = "cmdImport";
			this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEdit.Text = "Edit";
			this.cmdEdit.Size = new System.Drawing.Size(58, 25);
			this.cmdEdit.Location = new System.Drawing.Point(718, 17);
			this.cmdEdit.TabIndex = 14;
			this.cmdEdit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdEdit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEdit.CausesValidation = true;
			this.cmdEdit.Enabled = true;
			this.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEdit.TabStop = true;
			this.cmdEdit.Name = "cmdEdit";
			this.cmdMoveDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveDown.Text = "Move Down";
			this.cmdMoveDown.Size = new System.Drawing.Size(88, 25);
			this.cmdMoveDown.Location = new System.Drawing.Point(122, 327);
			this.cmdMoveDown.TabIndex = 13;
			this.cmdMoveDown.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveDown.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveDown.CausesValidation = true;
			this.cmdMoveDown.Enabled = true;
			this.cmdMoveDown.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveDown.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveDown.TabStop = true;
			this.cmdMoveDown.Name = "cmdMoveDown";
			this.cmdMoveUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveUp.Text = "Move Up";
			this.cmdMoveUp.Size = new System.Drawing.Size(83, 25);
			this.cmdMoveUp.Location = new System.Drawing.Point(37, 327);
			this.cmdMoveUp.TabIndex = 12;
			this.cmdMoveUp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveUp.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveUp.CausesValidation = true;
			this.cmdMoveUp.Enabled = true;
			this.cmdMoveUp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveUp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveUp.TabStop = true;
			this.cmdMoveUp.Name = "cmdMoveUp";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "Delete";
			this.cmdDelete.Size = new System.Drawing.Size(63, 25);
			this.cmdDelete.Location = new System.Drawing.Point(653, 17);
			this.cmdDelete.TabIndex = 11;
			this.cmdDelete.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelete.CausesValidation = true;
			this.cmdDelete.Enabled = true;
			this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelete.TabStop = true;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdAddLookupTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddLookupTable.Text = "Add";
			this.cmdAddLookupTable.Size = new System.Drawing.Size(63, 25);
			this.cmdAddLookupTable.Location = new System.Drawing.Point(587, 17);
			this.cmdAddLookupTable.TabIndex = 10;
			this.cmdAddLookupTable.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddLookupTable.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddLookupTable.CausesValidation = true;
			this.cmdAddLookupTable.Enabled = true;
			this.cmdAddLookupTable.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddLookupTable.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddLookupTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddLookupTable.TabStop = true;
			this.cmdAddLookupTable.Name = "cmdAddLookupTable";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "Close";
			this.cmdClose.Size = new System.Drawing.Size(115, 23);
			this.cmdClose.Location = new System.Drawing.Point(199, 404);
			this.cmdClose.TabIndex = 9;
			this.cmdClose.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.TabStop = true;
			this.cmdClose.Name = "cmdClose";
			this.cboLookupTableList.Size = new System.Drawing.Size(425, 27);
			this.cboLookupTableList.Location = new System.Drawing.Point(114, 15);
			this.cboLookupTableList.TabIndex = 6;
			this.cboLookupTableList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboLookupTableList.BackColor = System.Drawing.SystemColors.Window;
			this.cboLookupTableList.CausesValidation = true;
			this.cboLookupTableList.Enabled = true;
			this.cboLookupTableList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboLookupTableList.IntegralHeight = true;
			this.cboLookupTableList.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboLookupTableList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboLookupTableList.Sorted = false;
			this.cboLookupTableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboLookupTableList.TabStop = true;
			this.cboLookupTableList.Visible = true;
			this.cboLookupTableList.Name = "cboLookupTableList";
			this.cmdEditLookup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEditLookup.Text = "Edit";
			this.cmdEditLookup.Size = new System.Drawing.Size(73, 27);
			this.cmdEditLookup.Location = new System.Drawing.Point(322, 327);
			this.cmdEditLookup.TabIndex = 4;
			this.cmdEditLookup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdEditLookup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEditLookup.CausesValidation = true;
			this.cmdEditLookup.Enabled = true;
			this.cmdEditLookup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEditLookup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEditLookup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEditLookup.TabStop = true;
			this.cmdEditLookup.Name = "cmdEditLookup";
			this.cmdDelLookup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelLookup.Text = "Delete";
			this.cmdDelLookup.Size = new System.Drawing.Size(73, 27);
			this.cmdDelLookup.Location = new System.Drawing.Point(398, 327);
			this.cmdDelLookup.TabIndex = 3;
			this.cmdDelLookup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDelLookup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelLookup.CausesValidation = true;
			this.cmdDelLookup.Enabled = true;
			this.cmdDelLookup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelLookup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelLookup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelLookup.TabStop = true;
			this.cmdDelLookup.Name = "cmdDelLookup";
			this.cmdAddLookupValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddLookupValue.Text = "Add";
			this.cmdAddLookupValue.Size = new System.Drawing.Size(70, 27);
			this.cmdAddLookupValue.Location = new System.Drawing.Point(404, 367);
			this.cmdAddLookupValue.TabIndex = 2;
			this.cmdAddLookupValue.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddLookupValue.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddLookupValue.CausesValidation = true;
			this.cmdAddLookupValue.Enabled = true;
			this.cmdAddLookupValue.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddLookupValue.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddLookupValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddLookupValue.TabStop = true;
			this.cmdAddLookupValue.Name = "cmdAddLookupValue";
			this.txtLookupValue.AutoSize = false;
			this.txtLookupValue.Size = new System.Drawing.Size(289, 27);
			this.txtLookupValue.Location = new System.Drawing.Point(112, 367);
			this.txtLookupValue.TabIndex = 1;
			this.txtLookupValue.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtLookupValue.AcceptsReturn = true;
			this.txtLookupValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtLookupValue.BackColor = System.Drawing.SystemColors.Window;
			this.txtLookupValue.CausesValidation = true;
			this.txtLookupValue.Enabled = true;
			this.txtLookupValue.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtLookupValue.HideSelection = true;
			this.txtLookupValue.ReadOnly = false;
			this.txtLookupValue.MaxLength = 0;
			this.txtLookupValue.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtLookupValue.Multiline = false;
			this.txtLookupValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtLookupValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtLookupValue.TabStop = true;
			this.txtLookupValue.Visible = true;
			this.txtLookupValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtLookupValue.Name = "txtLookupValue";
			this.txtID.AutoSize = false;
			this.txtID.BackColor = System.Drawing.Color.White;
			this.txtID.Size = new System.Drawing.Size(40, 27);
			this.txtID.Location = new System.Drawing.Point(73, 367);
			this.txtID.TabIndex = 0;
			this.txtID.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtID.AcceptsReturn = true;
			this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtID.CausesValidation = true;
			this.txtID.Enabled = true;
			this.txtID.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtID.HideSelection = true;
			this.txtID.ReadOnly = false;
			this.txtID.MaxLength = 0;
			this.txtID.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtID.Multiline = false;
			this.txtID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtID.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtID.TabStop = true;
			this.txtID.Visible = true;
			this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtID.Name = "txtID";
			rdcLookupTableList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcLookupTableList.OcxState");
			this.rdcLookupTableList.Size = new System.Drawing.Size(225, 28);
			this.rdcLookupTableList.Location = new System.Drawing.Point(29, 424);
			this.rdcLookupTableList.Visible = false;
			this.rdcLookupTableList.Name = "rdcLookupTableList";
			rdcLookupList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcLookupList.OcxState");
			this.rdcLookupList.Size = new System.Drawing.Size(225, 28);
			this.rdcLookupList.Location = new System.Drawing.Point(257, 424);
			this.rdcLookupList.Visible = false;
			this.rdcLookupList.Name = "rdcLookupList";
			dbgLookupList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgLookupList.OcxState");
			this.dbgLookupList.Size = new System.Drawing.Size(442, 275);
			this.dbgLookupList.Location = new System.Drawing.Point(28, 48);
			this.dbgLookupList.TabIndex = 5;
			this.dbgLookupList.Name = "dbgLookupList";
			this.Label2.Text = "Lookup Tables:";
			this.Label2.Size = new System.Drawing.Size(100, 24);
			this.Label2.Location = new System.Drawing.Point(10, 17);
			this.Label2.TabIndex = 8;
			this.Label2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this.Label3.Text = "New:";
			this.Label3.ForeColor = System.Drawing.Color.Blue;
			this.Label3.Size = new System.Drawing.Size(50, 22);
			this.Label3.Location = new System.Drawing.Point(22, 368);
			this.Label3.TabIndex = 7;
			this.Label3.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Enabled = true;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			((System.ComponentModel.ISupportInitialize)this.dbgLookupList).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcLookupList).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcLookupTableList).EndInit();
			this.Controls.Add(fraLk);
			this.Controls.Add(Frame1);
			this.Controls.Add(cmdImport);
			this.Controls.Add(cmdEdit);
			this.Controls.Add(cmdMoveDown);
			this.Controls.Add(cmdMoveUp);
			this.Controls.Add(cmdDelete);
			this.Controls.Add(cmdAddLookupTable);
			this.Controls.Add(cmdClose);
			this.Controls.Add(cboLookupTableList);
			this.Controls.Add(cmdEditLookup);
			this.Controls.Add(cmdDelLookup);
			this.Controls.Add(cmdAddLookupValue);
			this.Controls.Add(txtLookupValue);
			this.Controls.Add(txtID);
			this.Controls.Add(rdcLookupTableList);
			this.Controls.Add(rdcLookupList);
			this.Controls.Add(dbgLookupList);
			this.Controls.Add(Label2);
			this.Controls.Add(Label3);
			this.fraLk.Controls.Add(OptLKValue);
			this.fraLk.Controls.Add(optID);
			this.fraLk.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
