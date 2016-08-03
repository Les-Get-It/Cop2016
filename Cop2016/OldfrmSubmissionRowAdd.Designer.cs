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
	partial class OldfrmSubmissionRowAdd
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmSubmissionRowAdd() : base()
		{
			Load += frmSubmissionRowAdd_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdDeleteRow;
		public System.Windows.Forms.Button cmdDeleteRow {
			get { return withEventsField_cmdDeleteRow; }
			set {
				if (withEventsField_cmdDeleteRow != null) {
					withEventsField_cmdDeleteRow.Click -= cmdDeleteRow_Click;
				}
				withEventsField_cmdDeleteRow = value;
				if (withEventsField_cmdDeleteRow != null) {
					withEventsField_cmdDeleteRow.Click += cmdDeleteRow_Click;
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
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.ComboBox cboGroupList;
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
		public System.Windows.Forms.CheckBox chkIncludeRow;
		public System.Windows.Forms.TextBox txtRowName;
		public System.Windows.Forms.TabPage _sstabRow_TabPage0;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.ComboBox cboGroupListToUpdate;
		public System.Windows.Forms.CheckBox chkIncludeRowToUpdate;
		public System.Windows.Forms.TextBox txtRowNameToUpdate;
		private System.Windows.Forms.Button withEventsField_cmdUpdate;
		public System.Windows.Forms.Button cmdUpdate {
			get { return withEventsField_cmdUpdate; }
			set {
				if (withEventsField_cmdUpdate != null) {
					withEventsField_cmdUpdate.Click -= cmdUpdate_Click;
				}
				withEventsField_cmdUpdate = value;
				if (withEventsField_cmdUpdate != null) {
					withEventsField_cmdUpdate.Click += cmdUpdate_Click;
				}
			}
		}
		public System.Windows.Forms.TabPage _sstabRow_TabPage1;
		public System.Windows.Forms.TabControl sstabRow;
		private System.Windows.Forms.ListBox withEventsField_lstRows;
		public System.Windows.Forms.ListBox lstRows {
			get { return withEventsField_lstRows; }
			set {
				if (withEventsField_lstRows != null) {
					withEventsField_lstRows.SelectedIndexChanged -= lstRows_SelectedIndexChanged;
				}
				withEventsField_lstRows = value;
				if (withEventsField_lstRows != null) {
					withEventsField_lstRows.SelectedIndexChanged += lstRows_SelectedIndexChanged;
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
		public System.Windows.Forms.Label Label3;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmSubmissionRowAdd));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdDeleteRow = new System.Windows.Forms.Button();
			this.cmdMoveUp = new System.Windows.Forms.Button();
			this.cmdMoveDown = new System.Windows.Forms.Button();
			this.sstabRow = new System.Windows.Forms.TabControl();
			this._sstabRow_TabPage0 = new System.Windows.Forms.TabPage();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.cboGroupList = new System.Windows.Forms.ComboBox();
			this.cmdAddSubmissionGroup = new System.Windows.Forms.Button();
			this.chkIncludeRow = new System.Windows.Forms.CheckBox();
			this.txtRowName = new System.Windows.Forms.TextBox();
			this._sstabRow_TabPage1 = new System.Windows.Forms.TabPage();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.cboGroupListToUpdate = new System.Windows.Forms.ComboBox();
			this.chkIncludeRowToUpdate = new System.Windows.Forms.CheckBox();
			this.txtRowNameToUpdate = new System.Windows.Forms.TextBox();
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.lstRows = new System.Windows.Forms.ListBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.Label3 = new System.Windows.Forms.Label();
			this.sstabRow.SuspendLayout();
			this._sstabRow_TabPage0.SuspendLayout();
			this._sstabRow_TabPage1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Add Submission Row";
			this.ClientSize = new System.Drawing.Size(703, 248);
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
			this.Name = "frmSubmissionRowAdd";
			this.cmdDeleteRow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDeleteRow.Text = "Delete Row";
			this.cmdDeleteRow.Size = new System.Drawing.Size(100, 23);
			this.cmdDeleteRow.Location = new System.Drawing.Point(212, 222);
			this.cmdDeleteRow.TabIndex = 18;
			this.cmdDeleteRow.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDeleteRow.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDeleteRow.CausesValidation = true;
			this.cmdDeleteRow.Enabled = true;
			this.cmdDeleteRow.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDeleteRow.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDeleteRow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDeleteRow.TabStop = true;
			this.cmdDeleteRow.Name = "cmdDeleteRow";
			this.cmdMoveUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveUp.Text = "Move Up";
			this.cmdMoveUp.Size = new System.Drawing.Size(92, 22);
			this.cmdMoveUp.Location = new System.Drawing.Point(7, 223);
			this.cmdMoveUp.TabIndex = 11;
			this.cmdMoveUp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveUp.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveUp.CausesValidation = true;
			this.cmdMoveUp.Enabled = true;
			this.cmdMoveUp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveUp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveUp.TabStop = true;
			this.cmdMoveUp.Name = "cmdMoveUp";
			this.cmdMoveDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveDown.Text = "Move Down";
			this.cmdMoveDown.Size = new System.Drawing.Size(95, 22);
			this.cmdMoveDown.Location = new System.Drawing.Point(105, 223);
			this.cmdMoveDown.TabIndex = 10;
			this.cmdMoveDown.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveDown.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveDown.CausesValidation = true;
			this.cmdMoveDown.Enabled = true;
			this.cmdMoveDown.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveDown.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveDown.TabStop = true;
			this.cmdMoveDown.Name = "cmdMoveDown";
			this.sstabRow.Size = new System.Drawing.Size(365, 193);
			this.sstabRow.Location = new System.Drawing.Point(322, 28);
			this.sstabRow.TabIndex = 3;
			this.sstabRow.SelectedIndex = 1;
			this.sstabRow.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabRow.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabRow.Name = "sstabRow";
			this._sstabRow_TabPage0.Text = "Add Row";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label2.Text = "Group";
			this.Label2.Size = new System.Drawing.Size(67, 22);
			this.Label2.Location = new System.Drawing.Point(22, 47);
			this.Label2.TabIndex = 8;
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
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label1.Text = "Row Name";
			this.Label1.Size = new System.Drawing.Size(82, 24);
			this.Label1.Location = new System.Drawing.Point(9, 79);
			this.Label1.TabIndex = 9;
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
			this.cboGroupList.Size = new System.Drawing.Size(262, 27);
			this.cboGroupList.Location = new System.Drawing.Point(92, 42);
			this.cboGroupList.TabIndex = 4;
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
			this.cmdAddSubmissionGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddSubmissionGroup.Text = "Add";
			this.cmdAddSubmissionGroup.Size = new System.Drawing.Size(120, 22);
			this.cmdAddSubmissionGroup.Location = new System.Drawing.Point(133, 162);
			this.cmdAddSubmissionGroup.TabIndex = 5;
			this.cmdAddSubmissionGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddSubmissionGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddSubmissionGroup.CausesValidation = true;
			this.cmdAddSubmissionGroup.Enabled = true;
			this.cmdAddSubmissionGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddSubmissionGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddSubmissionGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddSubmissionGroup.TabStop = true;
			this.cmdAddSubmissionGroup.Name = "cmdAddSubmissionGroup";
			this.chkIncludeRow.Text = "Include Row on the report";
			this.chkIncludeRow.Size = new System.Drawing.Size(202, 22);
			this.chkIncludeRow.Location = new System.Drawing.Point(104, 124);
			this.chkIncludeRow.TabIndex = 6;
			this.chkIncludeRow.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkIncludeRow.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkIncludeRow.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeRow.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkIncludeRow.BackColor = System.Drawing.SystemColors.Control;
			this.chkIncludeRow.CausesValidation = true;
			this.chkIncludeRow.Enabled = true;
			this.chkIncludeRow.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeRow.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkIncludeRow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeRow.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeRow.TabStop = true;
			this.chkIncludeRow.Visible = true;
			this.chkIncludeRow.Name = "chkIncludeRow";
			this.txtRowName.AutoSize = false;
			this.txtRowName.Size = new System.Drawing.Size(257, 24);
			this.txtRowName.Location = new System.Drawing.Point(94, 78);
			this.txtRowName.TabIndex = 7;
			this.txtRowName.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtRowName.AcceptsReturn = true;
			this.txtRowName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtRowName.BackColor = System.Drawing.SystemColors.Window;
			this.txtRowName.CausesValidation = true;
			this.txtRowName.Enabled = true;
			this.txtRowName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtRowName.HideSelection = true;
			this.txtRowName.ReadOnly = false;
			this.txtRowName.MaxLength = 0;
			this.txtRowName.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtRowName.Multiline = false;
			this.txtRowName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtRowName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtRowName.TabStop = true;
			this.txtRowName.Visible = true;
			this.txtRowName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtRowName.Name = "txtRowName";
			this._sstabRow_TabPage1.Text = "Update Row";
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label4.Text = "Group";
			this.Label4.Size = new System.Drawing.Size(67, 22);
			this.Label4.Location = new System.Drawing.Point(23, 47);
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
			this.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label5.Text = "Row Name";
			this.Label5.Size = new System.Drawing.Size(82, 24);
			this.Label5.Location = new System.Drawing.Point(10, 77);
			this.Label5.TabIndex = 16;
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
			this.cboGroupListToUpdate.Size = new System.Drawing.Size(262, 27);
			this.cboGroupListToUpdate.Location = new System.Drawing.Point(93, 40);
			this.cboGroupListToUpdate.TabIndex = 12;
			this.cboGroupListToUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboGroupListToUpdate.BackColor = System.Drawing.SystemColors.Window;
			this.cboGroupListToUpdate.CausesValidation = true;
			this.cboGroupListToUpdate.Enabled = true;
			this.cboGroupListToUpdate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGroupListToUpdate.IntegralHeight = true;
			this.cboGroupListToUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboGroupListToUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboGroupListToUpdate.Sorted = false;
			this.cboGroupListToUpdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboGroupListToUpdate.TabStop = true;
			this.cboGroupListToUpdate.Visible = true;
			this.cboGroupListToUpdate.Name = "cboGroupListToUpdate";
			this.chkIncludeRowToUpdate.Text = "Include Row on the report";
			this.chkIncludeRowToUpdate.Size = new System.Drawing.Size(202, 22);
			this.chkIncludeRowToUpdate.Location = new System.Drawing.Point(97, 118);
			this.chkIncludeRowToUpdate.TabIndex = 13;
			this.chkIncludeRowToUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkIncludeRowToUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkIncludeRowToUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeRowToUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkIncludeRowToUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.chkIncludeRowToUpdate.CausesValidation = true;
			this.chkIncludeRowToUpdate.Enabled = true;
			this.chkIncludeRowToUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeRowToUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkIncludeRowToUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeRowToUpdate.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeRowToUpdate.TabStop = true;
			this.chkIncludeRowToUpdate.Visible = true;
			this.chkIncludeRowToUpdate.Name = "chkIncludeRowToUpdate";
			this.txtRowNameToUpdate.AutoSize = false;
			this.txtRowNameToUpdate.Size = new System.Drawing.Size(257, 24);
			this.txtRowNameToUpdate.Location = new System.Drawing.Point(94, 74);
			this.txtRowNameToUpdate.TabIndex = 14;
			this.txtRowNameToUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtRowNameToUpdate.AcceptsReturn = true;
			this.txtRowNameToUpdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtRowNameToUpdate.BackColor = System.Drawing.SystemColors.Window;
			this.txtRowNameToUpdate.CausesValidation = true;
			this.txtRowNameToUpdate.Enabled = true;
			this.txtRowNameToUpdate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtRowNameToUpdate.HideSelection = true;
			this.txtRowNameToUpdate.ReadOnly = false;
			this.txtRowNameToUpdate.MaxLength = 0;
			this.txtRowNameToUpdate.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtRowNameToUpdate.Multiline = false;
			this.txtRowNameToUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtRowNameToUpdate.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtRowNameToUpdate.TabStop = true;
			this.txtRowNameToUpdate.Visible = true;
			this.txtRowNameToUpdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtRowNameToUpdate.Name = "txtRowNameToUpdate";
			this.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUpdate.Text = "Update";
			this.cmdUpdate.Size = new System.Drawing.Size(120, 22);
			this.cmdUpdate.Location = new System.Drawing.Point(134, 160);
			this.cmdUpdate.TabIndex = 17;
			this.cmdUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdate.CausesValidation = true;
			this.cmdUpdate.Enabled = true;
			this.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdate.TabStop = true;
			this.cmdUpdate.Name = "cmdUpdate";
			this.lstRows.Size = new System.Drawing.Size(304, 188);
			this.lstRows.Location = new System.Drawing.Point(5, 33);
			this.lstRows.TabIndex = 1;
			this.lstRows.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstRows.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstRows.BackColor = System.Drawing.SystemColors.Window;
			this.lstRows.CausesValidation = true;
			this.lstRows.Enabled = true;
			this.lstRows.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstRows.IntegralHeight = true;
			this.lstRows.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstRows.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstRows.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstRows.Sorted = false;
			this.lstRows.TabStop = true;
			this.lstRows.Visible = true;
			this.lstRows.MultiColumn = false;
			this.lstRows.Name = "lstRows";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Close";
			this.cmdCancel.Size = new System.Drawing.Size(94, 22);
			this.cmdCancel.Location = new System.Drawing.Point(465, 227);
			this.cmdCancel.TabIndex = 0;
			this.cmdCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.Label3.Text = "Existing Rows (Group / Row)";
			this.Label3.Size = new System.Drawing.Size(245, 24);
			this.Label3.Location = new System.Drawing.Point(8, 12);
			this.Label3.TabIndex = 2;
			this.Label3.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this.Controls.Add(cmdDeleteRow);
			this.Controls.Add(cmdMoveUp);
			this.Controls.Add(cmdMoveDown);
			this.Controls.Add(sstabRow);
			this.Controls.Add(lstRows);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(Label3);
			this.sstabRow.Controls.Add(_sstabRow_TabPage0);
			this.sstabRow.Controls.Add(_sstabRow_TabPage1);
			this._sstabRow_TabPage0.Controls.Add(Label2);
			this._sstabRow_TabPage0.Controls.Add(Label1);
			this._sstabRow_TabPage0.Controls.Add(cboGroupList);
			this._sstabRow_TabPage0.Controls.Add(cmdAddSubmissionGroup);
			this._sstabRow_TabPage0.Controls.Add(chkIncludeRow);
			this._sstabRow_TabPage0.Controls.Add(txtRowName);
			this._sstabRow_TabPage1.Controls.Add(Label4);
			this._sstabRow_TabPage1.Controls.Add(Label5);
			this._sstabRow_TabPage1.Controls.Add(cboGroupListToUpdate);
			this._sstabRow_TabPage1.Controls.Add(chkIncludeRowToUpdate);
			this._sstabRow_TabPage1.Controls.Add(txtRowNameToUpdate);
			this._sstabRow_TabPage1.Controls.Add(cmdUpdate);
			this.sstabRow.ResumeLayout(false);
			this._sstabRow_TabPage0.ResumeLayout(false);
			this._sstabRow_TabPage1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
