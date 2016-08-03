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
	partial class OldfrmSubmissionColAdd
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmSubmissionColAdd() : base()
		{
			FormClosed += frmSubmissionColAdd_FormClosed;
			Load += frmSubmissionColAdd_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdDeleteColumn;
		public System.Windows.Forms.Button cmdDeleteColumn {
			get { return withEventsField_cmdDeleteColumn; }
			set {
				if (withEventsField_cmdDeleteColumn != null) {
					withEventsField_cmdDeleteColumn.Click -= cmdDeleteColumn_Click;
				}
				withEventsField_cmdDeleteColumn = value;
				if (withEventsField_cmdDeleteColumn != null) {
					withEventsField_cmdDeleteColumn.Click += cmdDeleteColumn_Click;
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
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.ComboBox cboRowList;
		private System.Windows.Forms.ComboBox withEventsField_cboGroupList;
		public System.Windows.Forms.ComboBox cboGroupList {
			get { return withEventsField_cboGroupList; }
			set {
				if (withEventsField_cboGroupList != null) {
					withEventsField_cboGroupList.SelectedIndexChanged -= cboGroupList_SelectedIndexChanged;
				}
				withEventsField_cboGroupList = value;
				if (withEventsField_cboGroupList != null) {
					withEventsField_cboGroupList.SelectedIndexChanged += cboGroupList_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboIndicator;
		private System.Windows.Forms.ComboBox withEventsField_cboSumOp;
		public System.Windows.Forms.ComboBox cboSumOp {
			get { return withEventsField_cboSumOp; }
			set {
				if (withEventsField_cboSumOp != null) {
					withEventsField_cboSumOp.SelectedIndexChanged -= cboSumOp_SelectedIndexChanged;
				}
				withEventsField_cboSumOp = value;
				if (withEventsField_cboSumOp != null) {
					withEventsField_cboSumOp.SelectedIndexChanged += cboSumOp_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddSubmissionGroup;
		public System.Windows.Forms.Button cmdAddSubmissionGroup {
			get { return withEventsField_cmdAddSubmissionGroup; }
			set {
				if (withEventsField_cmdAddSubmissionGroup != null) {
					withEventsField_cmdAddSubmissionGroup.Click -= cmdAddSubmissionGroup_Click;
				}
				withEventsField_cmdAddSubmissionGroup = value;
				if (withEventsField_cmdAddSubmissionGroup != null) {
					withEventsField_cmdAddSubmissionGroup.Click += cmdAddSubmissionGroup_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox txtColName;
		public System.Windows.Forms.ListBox lstSumField;
		public System.Windows.Forms.CheckBox chkIncludeCol;
		public System.Windows.Forms.TabPage _sstabColumns_TabPage0;
		public System.Windows.Forms.Label lblGroupToUpdate;
		public System.Windows.Forms.Label Label13;
		public System.Windows.Forms.Label Label11;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.TextBox txtColNameToUpdate;
		private System.Windows.Forms.Button withEventsField_cmdUpdateColumn;
		public System.Windows.Forms.Button cmdUpdateColumn {
			get { return withEventsField_cmdUpdateColumn; }
			set {
				if (withEventsField_cmdUpdateColumn != null) {
					withEventsField_cmdUpdateColumn.Click -= cmdUpdateColumn_Click;
				}
				withEventsField_cmdUpdateColumn = value;
				if (withEventsField_cmdUpdateColumn != null) {
					withEventsField_cmdUpdateColumn.Click += cmdUpdateColumn_Click;
				}
			}
		}
		private System.Windows.Forms.ComboBox withEventsField_cboSumOpToUpdate;
		public System.Windows.Forms.ComboBox cboSumOpToUpdate {
			get { return withEventsField_cboSumOpToUpdate; }
			set {
				if (withEventsField_cboSumOpToUpdate != null) {
					withEventsField_cboSumOpToUpdate.SelectedIndexChanged -= cboSumOpToUpdate_SelectedIndexChanged;
				}
				withEventsField_cboSumOpToUpdate = value;
				if (withEventsField_cboSumOpToUpdate != null) {
					withEventsField_cboSumOpToUpdate.SelectedIndexChanged += cboSumOpToUpdate_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboIndicatorToUpdate;
		public System.Windows.Forms.ComboBox cboRowListToUpdate;
		public System.Windows.Forms.CheckBox chkIncludeColToUpdate;
		public System.Windows.Forms.TabPage _sstabUpdate_TabPage0;
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.Label Label14;
		public System.Windows.Forms.ListBox lstSumFieldToUpdate;
		private System.Windows.Forms.Button withEventsField_cmdRemoveField;
		public System.Windows.Forms.Button cmdRemoveField {
			get { return withEventsField_cmdRemoveField; }
			set {
				if (withEventsField_cmdRemoveField != null) {
					withEventsField_cmdRemoveField.Click -= cmdRemoveField_Click;
				}
				withEventsField_cmdRemoveField = value;
				if (withEventsField_cmdRemoveField != null) {
					withEventsField_cmdRemoveField.Click += cmdRemoveField_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddField;
		public System.Windows.Forms.Button cmdAddField {
			get { return withEventsField_cmdAddField; }
			set {
				if (withEventsField_cmdAddField != null) {
					withEventsField_cmdAddField.Click -= cmdAddField_Click;
				}
				withEventsField_cmdAddField = value;
				if (withEventsField_cmdAddField != null) {
					withEventsField_cmdAddField.Click += cmdAddField_Click;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboAllFields;
		public System.Windows.Forms.TabPage _sstabUpdate_TabPage1;
		public System.Windows.Forms.TabControl sstabUpdate;
		public System.Windows.Forms.TabPage _sstabColumns_TabPage1;
		public System.Windows.Forms.TabControl sstabColumns;
		private System.Windows.Forms.ListBox withEventsField_lstColumns;
		public System.Windows.Forms.ListBox lstColumns {
			get { return withEventsField_lstColumns; }
			set {
				if (withEventsField_lstColumns != null) {
					withEventsField_lstColumns.SelectedIndexChanged -= lstColumns_SelectedIndexChanged;
				}
				withEventsField_lstColumns = value;
				if (withEventsField_lstColumns != null) {
					withEventsField_lstColumns.SelectedIndexChanged += lstColumns_SelectedIndexChanged;
				}
			}
		}
		public AxMSRDC.AxMSRDC rdcSumFieldList;
		public System.Windows.Forms.Label Label7;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmSubmissionColAdd));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdDeleteColumn = new System.Windows.Forms.Button();
			this.cmdMoveDown = new System.Windows.Forms.Button();
			this.cmdMoveUp = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.sstabColumns = new System.Windows.Forms.TabControl();
			this._sstabColumns_TabPage0 = new System.Windows.Forms.TabPage();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.cboRowList = new System.Windows.Forms.ComboBox();
			this.cboGroupList = new System.Windows.Forms.ComboBox();
			this.cboIndicator = new System.Windows.Forms.ComboBox();
			this.cboSumOp = new System.Windows.Forms.ComboBox();
			this.cmdAddSubmissionGroup = new System.Windows.Forms.Button();
			this.txtColName = new System.Windows.Forms.TextBox();
			this.lstSumField = new System.Windows.Forms.ListBox();
			this.chkIncludeCol = new System.Windows.Forms.CheckBox();
			this._sstabColumns_TabPage1 = new System.Windows.Forms.TabPage();
			this.sstabUpdate = new System.Windows.Forms.TabControl();
			this._sstabUpdate_TabPage0 = new System.Windows.Forms.TabPage();
			this.lblGroupToUpdate = new System.Windows.Forms.Label();
			this.Label13 = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.txtColNameToUpdate = new System.Windows.Forms.TextBox();
			this.cmdUpdateColumn = new System.Windows.Forms.Button();
			this.cboSumOpToUpdate = new System.Windows.Forms.ComboBox();
			this.cboIndicatorToUpdate = new System.Windows.Forms.ComboBox();
			this.cboRowListToUpdate = new System.Windows.Forms.ComboBox();
			this.chkIncludeColToUpdate = new System.Windows.Forms.CheckBox();
			this._sstabUpdate_TabPage1 = new System.Windows.Forms.TabPage();
			this.Label12 = new System.Windows.Forms.Label();
			this.Label14 = new System.Windows.Forms.Label();
			this.lstSumFieldToUpdate = new System.Windows.Forms.ListBox();
			this.cmdRemoveField = new System.Windows.Forms.Button();
			this.cmdAddField = new System.Windows.Forms.Button();
			this.cboAllFields = new System.Windows.Forms.ComboBox();
			this.lstColumns = new System.Windows.Forms.ListBox();
			this.rdcSumFieldList = new AxMSRDC.AxMSRDC();
			this.Label7 = new System.Windows.Forms.Label();
			this.sstabColumns.SuspendLayout();
			this._sstabColumns_TabPage0.SuspendLayout();
			this._sstabColumns_TabPage1.SuspendLayout();
			this.sstabUpdate.SuspendLayout();
			this._sstabUpdate_TabPage0.SuspendLayout();
			this._sstabUpdate_TabPage1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.rdcSumFieldList).BeginInit();
			this.Text = "Add Submission Column";
			this.ClientSize = new System.Drawing.Size(612, 543);
			this.Location = new System.Drawing.Point(5, 29);
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
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
			this.Name = "frmSubmissionColAdd";
			this.cmdDeleteColumn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDeleteColumn.Text = "Delete Column";
			this.cmdDeleteColumn.Size = new System.Drawing.Size(143, 22);
			this.cmdDeleteColumn.Location = new System.Drawing.Point(449, 179);
			this.cmdDeleteColumn.TabIndex = 10;
			this.cmdDeleteColumn.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDeleteColumn.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDeleteColumn.CausesValidation = true;
			this.cmdDeleteColumn.Enabled = true;
			this.cmdDeleteColumn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDeleteColumn.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDeleteColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDeleteColumn.TabStop = true;
			this.cmdDeleteColumn.Name = "cmdDeleteColumn";
			this.cmdMoveDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveDown.Text = "Move Down";
			this.cmdMoveDown.Size = new System.Drawing.Size(108, 22);
			this.cmdMoveDown.Location = new System.Drawing.Point(102, 179);
			this.cmdMoveDown.TabIndex = 9;
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
			this.cmdMoveUp.Size = new System.Drawing.Size(93, 22);
			this.cmdMoveUp.Location = new System.Drawing.Point(7, 179);
			this.cmdMoveUp.TabIndex = 8;
			this.cmdMoveUp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveUp.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveUp.CausesValidation = true;
			this.cmdMoveUp.Enabled = true;
			this.cmdMoveUp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveUp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveUp.TabStop = true;
			this.cmdMoveUp.Name = "cmdMoveUp";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Close";
			this.cmdCancel.Size = new System.Drawing.Size(94, 22);
			this.cmdCancel.Location = new System.Drawing.Point(238, 519);
			this.cmdCancel.TabIndex = 11;
			this.cmdCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.sstabColumns.Size = new System.Drawing.Size(582, 307);
			this.sstabColumns.Location = new System.Drawing.Point(7, 204);
			this.sstabColumns.TabIndex = 1;
			this.sstabColumns.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabColumns.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabColumns.Name = "sstabColumns";
			this._sstabColumns_TabPage0.Text = "Add";
			this.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label6.Text = "Row:";
			this.Label6.Size = new System.Drawing.Size(40, 22);
			this.Label6.Location = new System.Drawing.Point(68, 75);
			this.Label6.TabIndex = 13;
			this.Label6.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label6.BackColor = System.Drawing.SystemColors.Control;
			this.Label6.Enabled = true;
			this.Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label6.UseMnemonic = true;
			this.Label6.Visible = true;
			this.Label6.AutoSize = false;
			this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label6.Name = "Label6";
			this.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label5.Text = "Group:";
			this.Label5.Size = new System.Drawing.Size(45, 22);
			this.Label5.Location = new System.Drawing.Point(62, 49);
			this.Label5.TabIndex = 14;
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
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label4.Text = "Indicator:";
			this.Label4.Size = new System.Drawing.Size(62, 22);
			this.Label4.Location = new System.Drawing.Point(44, 132);
			this.Label4.TabIndex = 15;
			this.Label4.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label4.BackColor = System.Drawing.SystemColors.Control;
			this.Label4.Enabled = true;
			this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.UseMnemonic = true;
			this.Label4.Visible = true;
			this.Label4.AutoSize = false;
			this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label4.Name = "Label4";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label2.Text = "Summary Operation";
			this.Label2.Size = new System.Drawing.Size(117, 20);
			this.Label2.Location = new System.Drawing.Point(53, 160);
			this.Label2.TabIndex = 16;
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
			this.Label3.Text = "Summarized Field(s):";
			this.Label3.Size = new System.Drawing.Size(127, 22);
			this.Label3.Location = new System.Drawing.Point(42, 187);
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
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label1.Text = "Column Name:";
			this.Label1.Size = new System.Drawing.Size(97, 24);
			this.Label1.Location = new System.Drawing.Point(9, 100);
			this.Label1.TabIndex = 18;
			this.Label1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.cboRowList.Size = new System.Drawing.Size(458, 27);
			this.cboRowList.Location = new System.Drawing.Point(110, 72);
			this.cboRowList.TabIndex = 3;
			this.cboRowList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboRowList.BackColor = System.Drawing.SystemColors.Window;
			this.cboRowList.CausesValidation = true;
			this.cboRowList.Enabled = true;
			this.cboRowList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboRowList.IntegralHeight = true;
			this.cboRowList.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboRowList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboRowList.Sorted = false;
			this.cboRowList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboRowList.TabStop = true;
			this.cboRowList.Visible = true;
			this.cboRowList.Name = "cboRowList";
			this.cboGroupList.Size = new System.Drawing.Size(459, 27);
			this.cboGroupList.Location = new System.Drawing.Point(110, 43);
			this.cboGroupList.TabIndex = 2;
			this.cboGroupList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboGroupList.BackColor = System.Drawing.SystemColors.Window;
			this.cboGroupList.CausesValidation = true;
			this.cboGroupList.Enabled = true;
			this.cboGroupList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGroupList.IntegralHeight = true;
			this.cboGroupList.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboGroupList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboGroupList.Sorted = false;
			this.cboGroupList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboGroupList.TabStop = true;
			this.cboGroupList.Visible = true;
			this.cboGroupList.Name = "cboGroupList";
			this.cboIndicator.Size = new System.Drawing.Size(457, 27);
			this.cboIndicator.Location = new System.Drawing.Point(112, 127);
			this.cboIndicator.TabIndex = 5;
			this.cboIndicator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboIndicator.BackColor = System.Drawing.SystemColors.Window;
			this.cboIndicator.CausesValidation = true;
			this.cboIndicator.Enabled = true;
			this.cboIndicator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboIndicator.IntegralHeight = true;
			this.cboIndicator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboIndicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboIndicator.Sorted = false;
			this.cboIndicator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboIndicator.TabStop = true;
			this.cboIndicator.Visible = true;
			this.cboIndicator.Name = "cboIndicator";
			this.cboSumOp.Size = new System.Drawing.Size(397, 27);
			this.cboSumOp.Location = new System.Drawing.Point(172, 154);
			this.cboSumOp.Items.AddRange(new object[] {
				"Count",
				"Sum"
			});
			this.cboSumOp.TabIndex = 6;
			this.cboSumOp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboSumOp.BackColor = System.Drawing.SystemColors.Window;
			this.cboSumOp.CausesValidation = true;
			this.cboSumOp.Enabled = true;
			this.cboSumOp.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboSumOp.IntegralHeight = true;
			this.cboSumOp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboSumOp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboSumOp.Sorted = false;
			this.cboSumOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboSumOp.TabStop = true;
			this.cboSumOp.Visible = true;
			this.cboSumOp.Name = "cboSumOp";
			this.cmdAddSubmissionGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddSubmissionGroup.Text = "Add";
			this.cmdAddSubmissionGroup.Size = new System.Drawing.Size(120, 22);
			this.cmdAddSubmissionGroup.Location = new System.Drawing.Point(220, 277);
			this.cmdAddSubmissionGroup.TabIndex = 7;
			this.cmdAddSubmissionGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddSubmissionGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddSubmissionGroup.CausesValidation = true;
			this.cmdAddSubmissionGroup.Enabled = true;
			this.cmdAddSubmissionGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddSubmissionGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddSubmissionGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddSubmissionGroup.TabStop = true;
			this.cmdAddSubmissionGroup.Name = "cmdAddSubmissionGroup";
			this.txtColName.AutoSize = false;
			this.txtColName.Size = new System.Drawing.Size(458, 24);
			this.txtColName.Location = new System.Drawing.Point(112, 100);
			this.txtColName.TabIndex = 4;
			this.txtColName.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtColName.AcceptsReturn = true;
			this.txtColName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtColName.BackColor = System.Drawing.SystemColors.Window;
			this.txtColName.CausesValidation = true;
			this.txtColName.Enabled = true;
			this.txtColName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtColName.HideSelection = true;
			this.txtColName.ReadOnly = false;
			this.txtColName.MaxLength = 0;
			this.txtColName.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtColName.Multiline = false;
			this.txtColName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtColName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtColName.TabStop = true;
			this.txtColName.Visible = true;
			this.txtColName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtColName.Name = "txtColName";
			this.lstSumField.Size = new System.Drawing.Size(299, 74);
			this.lstSumField.Location = new System.Drawing.Point(173, 182);
			this.lstSumField.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstSumField.TabIndex = 19;
			this.lstSumField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstSumField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSumField.BackColor = System.Drawing.SystemColors.Window;
			this.lstSumField.CausesValidation = true;
			this.lstSumField.Enabled = true;
			this.lstSumField.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSumField.IntegralHeight = true;
			this.lstSumField.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSumField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSumField.Sorted = false;
			this.lstSumField.TabStop = true;
			this.lstSumField.Visible = true;
			this.lstSumField.MultiColumn = false;
			this.lstSumField.Name = "lstSumField";
			this.chkIncludeCol.Text = "Include Column on the report";
			this.chkIncludeCol.Size = new System.Drawing.Size(202, 22);
			this.chkIncludeCol.Location = new System.Drawing.Point(175, 254);
			this.chkIncludeCol.TabIndex = 38;
			this.chkIncludeCol.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkIncludeCol.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkIncludeCol.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeCol.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkIncludeCol.BackColor = System.Drawing.SystemColors.Control;
			this.chkIncludeCol.CausesValidation = true;
			this.chkIncludeCol.Enabled = true;
			this.chkIncludeCol.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeCol.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkIncludeCol.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeCol.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeCol.TabStop = true;
			this.chkIncludeCol.Visible = true;
			this.chkIncludeCol.Name = "chkIncludeCol";
			this._sstabColumns_TabPage1.Text = "Update";
			this.sstabUpdate.Size = new System.Drawing.Size(553, 258);
			this.sstabUpdate.Location = new System.Drawing.Point(10, 30);
			this.sstabUpdate.TabIndex = 20;
			this.sstabUpdate.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.sstabUpdate.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabUpdate.Name = "sstabUpdate";
			this._sstabUpdate_TabPage0.Text = "General Definition";
			this.lblGroupToUpdate.Size = new System.Drawing.Size(434, 22);
			this.lblGroupToUpdate.Location = new System.Drawing.Point(98, 24);
			this.lblGroupToUpdate.TabIndex = 26;
			this.lblGroupToUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblGroupToUpdate.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblGroupToUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.lblGroupToUpdate.Enabled = true;
			this.lblGroupToUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblGroupToUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblGroupToUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblGroupToUpdate.UseMnemonic = true;
			this.lblGroupToUpdate.Visible = true;
			this.lblGroupToUpdate.AutoSize = false;
			this.lblGroupToUpdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblGroupToUpdate.Name = "lblGroupToUpdate";
			this.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label13.Text = "Column Name:";
			this.Label13.Size = new System.Drawing.Size(87, 24);
			this.Label13.Location = new System.Drawing.Point(10, 79);
			this.Label13.TabIndex = 27;
			this.Label13.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label13.BackColor = System.Drawing.SystemColors.Control;
			this.Label13.Enabled = true;
			this.Label13.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label13.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label13.UseMnemonic = true;
			this.Label13.Visible = true;
			this.Label13.AutoSize = false;
			this.Label13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label13.Name = "Label13";
			this.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label11.Text = "Summary Operation";
			this.Label11.Size = new System.Drawing.Size(117, 20);
			this.Label11.Location = new System.Drawing.Point(38, 142);
			this.Label11.TabIndex = 28;
			this.Label11.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label11.BackColor = System.Drawing.SystemColors.Control;
			this.Label11.Enabled = true;
			this.Label11.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label11.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label11.UseMnemonic = true;
			this.Label11.Visible = true;
			this.Label11.AutoSize = false;
			this.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label11.Name = "Label11";
			this.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label10.Text = "Indicator:";
			this.Label10.Size = new System.Drawing.Size(62, 22);
			this.Label10.Location = new System.Drawing.Point(32, 112);
			this.Label10.TabIndex = 29;
			this.Label10.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label10.BackColor = System.Drawing.SystemColors.Control;
			this.Label10.Enabled = true;
			this.Label10.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label10.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label10.UseMnemonic = true;
			this.Label10.Visible = true;
			this.Label10.AutoSize = false;
			this.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label10.Name = "Label10";
			this.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label9.Text = "Group:";
			this.Label9.Size = new System.Drawing.Size(45, 22);
			this.Label9.Location = new System.Drawing.Point(47, 24);
			this.Label9.TabIndex = 30;
			this.Label9.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label9.BackColor = System.Drawing.SystemColors.Control;
			this.Label9.Enabled = true;
			this.Label9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label9.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label9.UseMnemonic = true;
			this.Label9.Visible = true;
			this.Label9.AutoSize = false;
			this.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label9.Name = "Label9";
			this.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label8.Text = "Row:";
			this.Label8.Size = new System.Drawing.Size(40, 22);
			this.Label8.Location = new System.Drawing.Point(53, 53);
			this.Label8.TabIndex = 31;
			this.Label8.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label8.BackColor = System.Drawing.SystemColors.Control;
			this.Label8.Enabled = true;
			this.Label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label8.UseMnemonic = true;
			this.Label8.Visible = true;
			this.Label8.AutoSize = false;
			this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label8.Name = "Label8";
			this.txtColNameToUpdate.AutoSize = false;
			this.txtColNameToUpdate.Size = new System.Drawing.Size(438, 24);
			this.txtColNameToUpdate.Location = new System.Drawing.Point(97, 79);
			this.txtColNameToUpdate.TabIndex = 21;
			this.txtColNameToUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtColNameToUpdate.AcceptsReturn = true;
			this.txtColNameToUpdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtColNameToUpdate.BackColor = System.Drawing.SystemColors.Window;
			this.txtColNameToUpdate.CausesValidation = true;
			this.txtColNameToUpdate.Enabled = true;
			this.txtColNameToUpdate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtColNameToUpdate.HideSelection = true;
			this.txtColNameToUpdate.ReadOnly = false;
			this.txtColNameToUpdate.MaxLength = 0;
			this.txtColNameToUpdate.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtColNameToUpdate.Multiline = false;
			this.txtColNameToUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtColNameToUpdate.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtColNameToUpdate.TabStop = true;
			this.txtColNameToUpdate.Visible = true;
			this.txtColNameToUpdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtColNameToUpdate.Name = "txtColNameToUpdate";
			this.cmdUpdateColumn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUpdateColumn.Text = "Update";
			this.cmdUpdateColumn.Size = new System.Drawing.Size(120, 22);
			this.cmdUpdateColumn.Location = new System.Drawing.Point(180, 195);
			this.cmdUpdateColumn.TabIndex = 22;
			this.cmdUpdateColumn.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdUpdateColumn.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdateColumn.CausesValidation = true;
			this.cmdUpdateColumn.Enabled = true;
			this.cmdUpdateColumn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdateColumn.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdateColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdateColumn.TabStop = true;
			this.cmdUpdateColumn.Name = "cmdUpdateColumn";
			this.cboSumOpToUpdate.Size = new System.Drawing.Size(247, 27);
			this.cboSumOpToUpdate.Location = new System.Drawing.Point(178, 135);
			this.cboSumOpToUpdate.Items.AddRange(new object[] {
				"Count",
				"Sum"
			});
			this.cboSumOpToUpdate.TabIndex = 23;
			this.cboSumOpToUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboSumOpToUpdate.BackColor = System.Drawing.SystemColors.Window;
			this.cboSumOpToUpdate.CausesValidation = true;
			this.cboSumOpToUpdate.Enabled = true;
			this.cboSumOpToUpdate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboSumOpToUpdate.IntegralHeight = true;
			this.cboSumOpToUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboSumOpToUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboSumOpToUpdate.Sorted = false;
			this.cboSumOpToUpdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboSumOpToUpdate.TabStop = true;
			this.cboSumOpToUpdate.Visible = true;
			this.cboSumOpToUpdate.Name = "cboSumOpToUpdate";
			this.cboIndicatorToUpdate.Size = new System.Drawing.Size(437, 27);
			this.cboIndicatorToUpdate.Location = new System.Drawing.Point(100, 107);
			this.cboIndicatorToUpdate.TabIndex = 24;
			this.cboIndicatorToUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboIndicatorToUpdate.BackColor = System.Drawing.SystemColors.Window;
			this.cboIndicatorToUpdate.CausesValidation = true;
			this.cboIndicatorToUpdate.Enabled = true;
			this.cboIndicatorToUpdate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboIndicatorToUpdate.IntegralHeight = true;
			this.cboIndicatorToUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboIndicatorToUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboIndicatorToUpdate.Sorted = false;
			this.cboIndicatorToUpdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboIndicatorToUpdate.TabStop = true;
			this.cboIndicatorToUpdate.Visible = true;
			this.cboIndicatorToUpdate.Name = "cboIndicatorToUpdate";
			this.cboRowListToUpdate.Size = new System.Drawing.Size(438, 27);
			this.cboRowListToUpdate.Location = new System.Drawing.Point(98, 48);
			this.cboRowListToUpdate.TabIndex = 25;
			this.cboRowListToUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboRowListToUpdate.BackColor = System.Drawing.SystemColors.Window;
			this.cboRowListToUpdate.CausesValidation = true;
			this.cboRowListToUpdate.Enabled = true;
			this.cboRowListToUpdate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboRowListToUpdate.IntegralHeight = true;
			this.cboRowListToUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboRowListToUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboRowListToUpdate.Sorted = false;
			this.cboRowListToUpdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboRowListToUpdate.TabStop = true;
			this.cboRowListToUpdate.Visible = true;
			this.cboRowListToUpdate.Name = "cboRowListToUpdate";
			this.chkIncludeColToUpdate.Text = "Include Column on the report";
			this.chkIncludeColToUpdate.Size = new System.Drawing.Size(202, 22);
			this.chkIncludeColToUpdate.Location = new System.Drawing.Point(158, 165);
			this.chkIncludeColToUpdate.TabIndex = 39;
			this.chkIncludeColToUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkIncludeColToUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeColToUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkIncludeColToUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.chkIncludeColToUpdate.CausesValidation = true;
			this.chkIncludeColToUpdate.Enabled = true;
			this.chkIncludeColToUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeColToUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkIncludeColToUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeColToUpdate.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeColToUpdate.TabStop = true;
			this.chkIncludeColToUpdate.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIncludeColToUpdate.Visible = true;
			this.chkIncludeColToUpdate.Name = "chkIncludeColToUpdate";
			this._sstabUpdate_TabPage1.Text = "Summarized Field List";
			this.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label12.Text = "Selected Summarized Field";
			this.Label12.Size = new System.Drawing.Size(122, 35);
			this.Label12.Location = new System.Drawing.Point(9, 22);
			this.Label12.TabIndex = 32;
			this.Label12.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label12.BackColor = System.Drawing.SystemColors.Control;
			this.Label12.Enabled = true;
			this.Label12.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label12.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label12.UseMnemonic = true;
			this.Label12.Visible = true;
			this.Label12.AutoSize = false;
			this.Label12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label12.Name = "Label12";
			this.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label14.Text = "List of All Fields";
			this.Label14.Size = new System.Drawing.Size(110, 35);
			this.Label14.Location = new System.Drawing.Point(10, 164);
			this.Label14.TabIndex = 34;
			this.Label14.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label14.BackColor = System.Drawing.SystemColors.Control;
			this.Label14.Enabled = true;
			this.Label14.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label14.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label14.UseMnemonic = true;
			this.Label14.Visible = true;
			this.Label14.AutoSize = false;
			this.Label14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label14.Name = "Label14";
			this.lstSumFieldToUpdate.Size = new System.Drawing.Size(382, 90);
			this.lstSumFieldToUpdate.Location = new System.Drawing.Point(134, 20);
			this.lstSumFieldToUpdate.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstSumFieldToUpdate.TabIndex = 33;
			this.lstSumFieldToUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstSumFieldToUpdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSumFieldToUpdate.BackColor = System.Drawing.SystemColors.Window;
			this.lstSumFieldToUpdate.CausesValidation = true;
			this.lstSumFieldToUpdate.Enabled = true;
			this.lstSumFieldToUpdate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSumFieldToUpdate.IntegralHeight = true;
			this.lstSumFieldToUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSumFieldToUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSumFieldToUpdate.Sorted = false;
			this.lstSumFieldToUpdate.TabStop = true;
			this.lstSumFieldToUpdate.Visible = true;
			this.lstSumFieldToUpdate.MultiColumn = false;
			this.lstSumFieldToUpdate.Name = "lstSumFieldToUpdate";
			this.cmdRemoveField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveField.Text = "Remove Field";
			this.cmdRemoveField.Size = new System.Drawing.Size(183, 22);
			this.cmdRemoveField.Location = new System.Drawing.Point(334, 112);
			this.cmdRemoveField.TabIndex = 35;
			this.cmdRemoveField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveField.CausesValidation = true;
			this.cmdRemoveField.Enabled = true;
			this.cmdRemoveField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveField.TabStop = true;
			this.cmdRemoveField.Name = "cmdRemoveField";
			this.cmdAddField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddField.Text = "Add to selected fields";
			this.cmdAddField.Size = new System.Drawing.Size(182, 22);
			this.cmdAddField.Location = new System.Drawing.Point(335, 192);
			this.cmdAddField.TabIndex = 36;
			this.cmdAddField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddField.CausesValidation = true;
			this.cmdAddField.Enabled = true;
			this.cmdAddField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddField.TabStop = true;
			this.cmdAddField.Name = "cmdAddField";
			this.cboAllFields.Size = new System.Drawing.Size(387, 27);
			this.cboAllFields.Location = new System.Drawing.Point(134, 160);
			this.cboAllFields.TabIndex = 37;
			this.cboAllFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboAllFields.BackColor = System.Drawing.SystemColors.Window;
			this.cboAllFields.CausesValidation = true;
			this.cboAllFields.Enabled = true;
			this.cboAllFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboAllFields.IntegralHeight = true;
			this.cboAllFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboAllFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboAllFields.Sorted = false;
			this.cboAllFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboAllFields.TabStop = true;
			this.cboAllFields.Visible = true;
			this.cboAllFields.Name = "cboAllFields";
			this.lstColumns.Size = new System.Drawing.Size(588, 155);
			this.lstColumns.Location = new System.Drawing.Point(5, 24);
			this.lstColumns.TabIndex = 0;
			this.lstColumns.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstColumns.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstColumns.BackColor = System.Drawing.SystemColors.Window;
			this.lstColumns.CausesValidation = true;
			this.lstColumns.Enabled = true;
			this.lstColumns.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstColumns.IntegralHeight = true;
			this.lstColumns.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstColumns.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstColumns.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstColumns.Sorted = false;
			this.lstColumns.TabStop = true;
			this.lstColumns.Visible = true;
			this.lstColumns.MultiColumn = false;
			this.lstColumns.Name = "lstColumns";
			rdcSumFieldList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcSumFieldList.OcxState");
			this.rdcSumFieldList.Size = new System.Drawing.Size(195, 28);
			this.rdcSumFieldList.Location = new System.Drawing.Point(-26, 509);
			this.rdcSumFieldList.Visible = false;
			this.rdcSumFieldList.Name = "rdcSumFieldList";
			this.Label7.Text = "Existing Columns (Group / Row / Column)";
			this.Label7.Size = new System.Drawing.Size(374, 22);
			this.Label7.Location = new System.Drawing.Point(8, 4);
			this.Label7.TabIndex = 12;
			this.Label7.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label7.BackColor = System.Drawing.SystemColors.Control;
			this.Label7.Enabled = true;
			this.Label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label7.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label7.UseMnemonic = true;
			this.Label7.Visible = true;
			this.Label7.AutoSize = false;
			this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label7.Name = "Label7";
			this.Controls.Add(cmdDeleteColumn);
			this.Controls.Add(cmdMoveDown);
			this.Controls.Add(cmdMoveUp);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(sstabColumns);
			this.Controls.Add(lstColumns);
			this.Controls.Add(rdcSumFieldList);
			this.Controls.Add(Label7);
			this.sstabColumns.Controls.Add(_sstabColumns_TabPage0);
			this.sstabColumns.Controls.Add(_sstabColumns_TabPage1);
			this._sstabColumns_TabPage0.Controls.Add(Label6);
			this._sstabColumns_TabPage0.Controls.Add(Label5);
			this._sstabColumns_TabPage0.Controls.Add(Label4);
			this._sstabColumns_TabPage0.Controls.Add(Label2);
			this._sstabColumns_TabPage0.Controls.Add(Label3);
			this._sstabColumns_TabPage0.Controls.Add(Label1);
			this._sstabColumns_TabPage0.Controls.Add(cboRowList);
			this._sstabColumns_TabPage0.Controls.Add(cboGroupList);
			this._sstabColumns_TabPage0.Controls.Add(cboIndicator);
			this._sstabColumns_TabPage0.Controls.Add(cboSumOp);
			this._sstabColumns_TabPage0.Controls.Add(cmdAddSubmissionGroup);
			this._sstabColumns_TabPage0.Controls.Add(txtColName);
			this._sstabColumns_TabPage0.Controls.Add(lstSumField);
			this._sstabColumns_TabPage0.Controls.Add(chkIncludeCol);
			this._sstabColumns_TabPage1.Controls.Add(sstabUpdate);
			this.sstabUpdate.Controls.Add(_sstabUpdate_TabPage0);
			this.sstabUpdate.Controls.Add(_sstabUpdate_TabPage1);
			this._sstabUpdate_TabPage0.Controls.Add(lblGroupToUpdate);
			this._sstabUpdate_TabPage0.Controls.Add(Label13);
			this._sstabUpdate_TabPage0.Controls.Add(Label11);
			this._sstabUpdate_TabPage0.Controls.Add(Label10);
			this._sstabUpdate_TabPage0.Controls.Add(Label9);
			this._sstabUpdate_TabPage0.Controls.Add(Label8);
			this._sstabUpdate_TabPage0.Controls.Add(txtColNameToUpdate);
			this._sstabUpdate_TabPage0.Controls.Add(cmdUpdateColumn);
			this._sstabUpdate_TabPage0.Controls.Add(cboSumOpToUpdate);
			this._sstabUpdate_TabPage0.Controls.Add(cboIndicatorToUpdate);
			this._sstabUpdate_TabPage0.Controls.Add(cboRowListToUpdate);
			this._sstabUpdate_TabPage0.Controls.Add(chkIncludeColToUpdate);
			this._sstabUpdate_TabPage1.Controls.Add(Label12);
			this._sstabUpdate_TabPage1.Controls.Add(Label14);
			this._sstabUpdate_TabPage1.Controls.Add(lstSumFieldToUpdate);
			this._sstabUpdate_TabPage1.Controls.Add(cmdRemoveField);
			this._sstabUpdate_TabPage1.Controls.Add(cmdAddField);
			this._sstabUpdate_TabPage1.Controls.Add(cboAllFields);
			((System.ComponentModel.ISupportInitialize)this.rdcSumFieldList).EndInit();
			this.sstabColumns.ResumeLayout(false);
			this._sstabColumns_TabPage0.ResumeLayout(false);
			this._sstabColumns_TabPage1.ResumeLayout(false);
			this.sstabUpdate.ResumeLayout(false);
			this._sstabUpdate_TabPage0.ResumeLayout(false);
			this._sstabUpdate_TabPage1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
