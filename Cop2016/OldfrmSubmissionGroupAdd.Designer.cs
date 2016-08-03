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
	partial class OldfrmSubmissionGroupAdd
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmSubmissionGroupAdd() : base()
		{
			Load += frmSubmissionGroupAdd_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdChangeStatus;
		public System.Windows.Forms.Button cmdChangeStatus {
			get { return withEventsField_cmdChangeStatus; }
			set {
				if (withEventsField_cmdChangeStatus != null) {
					withEventsField_cmdChangeStatus.Click -= cmdChangeStatus_Click;
				}
				withEventsField_cmdChangeStatus = value;
				if (withEventsField_cmdChangeStatus != null) {
					withEventsField_cmdChangeStatus.Click += cmdChangeStatus_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDeleteGroup;
		public System.Windows.Forms.Button cmdDeleteGroup {
			get { return withEventsField_cmdDeleteGroup; }
			set {
				if (withEventsField_cmdDeleteGroup != null) {
					withEventsField_cmdDeleteGroup.Click -= cmdDeleteGroup_Click;
				}
				withEventsField_cmdDeleteGroup = value;
				if (withEventsField_cmdDeleteGroup != null) {
					withEventsField_cmdDeleteGroup.Click += cmdDeleteGroup_Click;
				}
			}
		}
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.CheckBox chkDisplayGroupTitle;
		public System.Windows.Forms.CheckBox chkIncludeGroup;
		public System.Windows.Forms.TextBox txtGroupName;
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
		public System.Windows.Forms.CheckBox chkShowTotal;
		public System.Windows.Forms.TabPage _sstabGroup_TabPage0;
		public System.Windows.Forms.CheckBox chkShowTotalToUpdate;
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
		public System.Windows.Forms.TextBox txtGroupNameToUpdate;
		public System.Windows.Forms.CheckBox chkIncludeGroupToUpdate;
		public System.Windows.Forms.CheckBox chkDisplayGroupTitleToUpdate;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.TabPage _sstabGroup_TabPage1;
		public System.Windows.Forms.TabControl sstabGroup;
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
		private System.Windows.Forms.ListBox withEventsField_lstGroups;
		public System.Windows.Forms.ListBox lstGroups {
			get { return withEventsField_lstGroups; }
			set {
				if (withEventsField_lstGroups != null) {
					withEventsField_lstGroups.SelectedIndexChanged -= lstGroups_SelectedIndexChanged;
				}
				withEventsField_lstGroups = value;
				if (withEventsField_lstGroups != null) {
					withEventsField_lstGroups.SelectedIndexChanged += lstGroups_SelectedIndexChanged;
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
		public System.Windows.Forms.Label Label2;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmSubmissionGroupAdd));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdChangeStatus = new System.Windows.Forms.Button();
			this.cmdDeleteGroup = new System.Windows.Forms.Button();
			this.sstabGroup = new System.Windows.Forms.TabControl();
			this._sstabGroup_TabPage0 = new System.Windows.Forms.TabPage();
			this.Label1 = new System.Windows.Forms.Label();
			this.chkDisplayGroupTitle = new System.Windows.Forms.CheckBox();
			this.chkIncludeGroup = new System.Windows.Forms.CheckBox();
			this.txtGroupName = new System.Windows.Forms.TextBox();
			this.cmdAddSubmissionGroup = new System.Windows.Forms.Button();
			this.chkShowTotal = new System.Windows.Forms.CheckBox();
			this._sstabGroup_TabPage1 = new System.Windows.Forms.TabPage();
			this.chkShowTotalToUpdate = new System.Windows.Forms.CheckBox();
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.txtGroupNameToUpdate = new System.Windows.Forms.TextBox();
			this.chkIncludeGroupToUpdate = new System.Windows.Forms.CheckBox();
			this.chkDisplayGroupTitleToUpdate = new System.Windows.Forms.CheckBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.cmdMoveDown = new System.Windows.Forms.Button();
			this.cmdMoveUp = new System.Windows.Forms.Button();
			this.lstGroups = new System.Windows.Forms.ListBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.sstabGroup.SuspendLayout();
			this._sstabGroup_TabPage0.SuspendLayout();
			this._sstabGroup_TabPage1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Add Submission Group";
			this.ClientSize = new System.Drawing.Size(702, 249);
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
			this.Name = "frmSubmissionGroupAdd";
			this.cmdChangeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeStatus.Text = "Change Status";
			this.cmdChangeStatus.Size = new System.Drawing.Size(164, 25);
			this.cmdChangeStatus.Location = new System.Drawing.Point(9, 223);
			this.cmdChangeStatus.TabIndex = 17;
			this.cmdChangeStatus.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeStatus.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeStatus.CausesValidation = true;
			this.cmdChangeStatus.Enabled = true;
			this.cmdChangeStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeStatus.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeStatus.TabStop = true;
			this.cmdChangeStatus.Name = "cmdChangeStatus";
			this.cmdDeleteGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDeleteGroup.Text = "Delete Group";
			this.cmdDeleteGroup.Size = new System.Drawing.Size(117, 23);
			this.cmdDeleteGroup.Location = new System.Drawing.Point(185, 198);
			this.cmdDeleteGroup.TabIndex = 16;
			this.cmdDeleteGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDeleteGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDeleteGroup.CausesValidation = true;
			this.cmdDeleteGroup.Enabled = true;
			this.cmdDeleteGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDeleteGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDeleteGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDeleteGroup.TabStop = true;
			this.cmdDeleteGroup.Name = "cmdDeleteGroup";
			this.sstabGroup.Size = new System.Drawing.Size(378, 187);
			this.sstabGroup.Location = new System.Drawing.Point(313, 28);
			this.sstabGroup.TabIndex = 5;
			this.sstabGroup.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabGroup.Name = "sstabGroup";
			this._sstabGroup_TabPage0.Text = "Add";
			this.Label1.Text = "Group Name";
			this.Label1.Size = new System.Drawing.Size(82, 24);
			this.Label1.Location = new System.Drawing.Point(22, 52);
			this.Label1.TabIndex = 9;
			this.Label1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this.chkDisplayGroupTitle.Text = "Display Group Title on the Report";
			this.chkDisplayGroupTitle.Size = new System.Drawing.Size(222, 22);
			this.chkDisplayGroupTitle.Location = new System.Drawing.Point(102, 104);
			this.chkDisplayGroupTitle.TabIndex = 6;
			this.chkDisplayGroupTitle.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkDisplayGroupTitle.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkDisplayGroupTitle.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkDisplayGroupTitle.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkDisplayGroupTitle.BackColor = System.Drawing.SystemColors.Control;
			this.chkDisplayGroupTitle.CausesValidation = true;
			this.chkDisplayGroupTitle.Enabled = true;
			this.chkDisplayGroupTitle.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkDisplayGroupTitle.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkDisplayGroupTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDisplayGroupTitle.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkDisplayGroupTitle.TabStop = true;
			this.chkDisplayGroupTitle.Visible = true;
			this.chkDisplayGroupTitle.Name = "chkDisplayGroupTitle";
			this.chkIncludeGroup.Text = "Include Group on the report";
			this.chkIncludeGroup.Size = new System.Drawing.Size(202, 22);
			this.chkIncludeGroup.Location = new System.Drawing.Point(102, 84);
			this.chkIncludeGroup.TabIndex = 7;
			this.chkIncludeGroup.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkIncludeGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkIncludeGroup.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeGroup.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkIncludeGroup.BackColor = System.Drawing.SystemColors.Control;
			this.chkIncludeGroup.CausesValidation = true;
			this.chkIncludeGroup.Enabled = true;
			this.chkIncludeGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkIncludeGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeGroup.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeGroup.TabStop = true;
			this.chkIncludeGroup.Visible = true;
			this.chkIncludeGroup.Name = "chkIncludeGroup";
			this.txtGroupName.AutoSize = false;
			this.txtGroupName.Size = new System.Drawing.Size(269, 24);
			this.txtGroupName.Location = new System.Drawing.Point(100, 50);
			this.txtGroupName.TabIndex = 8;
			this.txtGroupName.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtGroupName.AcceptsReturn = true;
			this.txtGroupName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtGroupName.BackColor = System.Drawing.SystemColors.Window;
			this.txtGroupName.CausesValidation = true;
			this.txtGroupName.Enabled = true;
			this.txtGroupName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGroupName.HideSelection = true;
			this.txtGroupName.ReadOnly = false;
			this.txtGroupName.MaxLength = 0;
			this.txtGroupName.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtGroupName.Multiline = false;
			this.txtGroupName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtGroupName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtGroupName.TabStop = true;
			this.txtGroupName.Visible = true;
			this.txtGroupName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtGroupName.Name = "txtGroupName";
			this.cmdAddSubmissionGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddSubmissionGroup.Text = "Add";
			this.cmdAddSubmissionGroup.Size = new System.Drawing.Size(120, 22);
			this.cmdAddSubmissionGroup.Location = new System.Drawing.Point(120, 155);
			this.cmdAddSubmissionGroup.TabIndex = 14;
			this.cmdAddSubmissionGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddSubmissionGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddSubmissionGroup.CausesValidation = true;
			this.cmdAddSubmissionGroup.Enabled = true;
			this.cmdAddSubmissionGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddSubmissionGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddSubmissionGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddSubmissionGroup.TabStop = true;
			this.cmdAddSubmissionGroup.Name = "cmdAddSubmissionGroup";
			this.chkShowTotal.Text = "Show Total on the report";
			this.chkShowTotal.Size = new System.Drawing.Size(202, 22);
			this.chkShowTotal.Location = new System.Drawing.Point(102, 125);
			this.chkShowTotal.TabIndex = 18;
			this.chkShowTotal.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkShowTotal.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkShowTotal.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowTotal.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkShowTotal.BackColor = System.Drawing.SystemColors.Control;
			this.chkShowTotal.CausesValidation = true;
			this.chkShowTotal.Enabled = true;
			this.chkShowTotal.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkShowTotal.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkShowTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowTotal.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowTotal.TabStop = true;
			this.chkShowTotal.Visible = true;
			this.chkShowTotal.Name = "chkShowTotal";
			this._sstabGroup_TabPage1.Text = "Update";
			this.chkShowTotalToUpdate.Text = "Show Total on the report";
			this.chkShowTotalToUpdate.Size = new System.Drawing.Size(202, 22);
			this.chkShowTotalToUpdate.Location = new System.Drawing.Point(102, 123);
			this.chkShowTotalToUpdate.TabIndex = 19;
			this.chkShowTotalToUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkShowTotalToUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowTotalToUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkShowTotalToUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.chkShowTotalToUpdate.CausesValidation = true;
			this.chkShowTotalToUpdate.Enabled = true;
			this.chkShowTotalToUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkShowTotalToUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkShowTotalToUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowTotalToUpdate.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowTotalToUpdate.TabStop = true;
			this.chkShowTotalToUpdate.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowTotalToUpdate.Visible = true;
			this.chkShowTotalToUpdate.Name = "chkShowTotalToUpdate";
			this.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUpdate.Text = "Update";
			this.cmdUpdate.Size = new System.Drawing.Size(120, 22);
			this.cmdUpdate.Location = new System.Drawing.Point(130, 153);
			this.cmdUpdate.TabIndex = 15;
			this.cmdUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdate.CausesValidation = true;
			this.cmdUpdate.Enabled = true;
			this.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdate.TabStop = true;
			this.cmdUpdate.Name = "cmdUpdate";
			this.txtGroupNameToUpdate.AutoSize = false;
			this.txtGroupNameToUpdate.Size = new System.Drawing.Size(269, 24);
			this.txtGroupNameToUpdate.Location = new System.Drawing.Point(100, 48);
			this.txtGroupNameToUpdate.TabIndex = 12;
			this.txtGroupNameToUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtGroupNameToUpdate.AcceptsReturn = true;
			this.txtGroupNameToUpdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtGroupNameToUpdate.BackColor = System.Drawing.SystemColors.Window;
			this.txtGroupNameToUpdate.CausesValidation = true;
			this.txtGroupNameToUpdate.Enabled = true;
			this.txtGroupNameToUpdate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGroupNameToUpdate.HideSelection = true;
			this.txtGroupNameToUpdate.ReadOnly = false;
			this.txtGroupNameToUpdate.MaxLength = 0;
			this.txtGroupNameToUpdate.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtGroupNameToUpdate.Multiline = false;
			this.txtGroupNameToUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtGroupNameToUpdate.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtGroupNameToUpdate.TabStop = true;
			this.txtGroupNameToUpdate.Visible = true;
			this.txtGroupNameToUpdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtGroupNameToUpdate.Name = "txtGroupNameToUpdate";
			this.chkIncludeGroupToUpdate.Text = "Include Group on the report";
			this.chkIncludeGroupToUpdate.Size = new System.Drawing.Size(202, 22);
			this.chkIncludeGroupToUpdate.Location = new System.Drawing.Point(102, 82);
			this.chkIncludeGroupToUpdate.TabIndex = 11;
			this.chkIncludeGroupToUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkIncludeGroupToUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeGroupToUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkIncludeGroupToUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.chkIncludeGroupToUpdate.CausesValidation = true;
			this.chkIncludeGroupToUpdate.Enabled = true;
			this.chkIncludeGroupToUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeGroupToUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkIncludeGroupToUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeGroupToUpdate.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeGroupToUpdate.TabStop = true;
			this.chkIncludeGroupToUpdate.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIncludeGroupToUpdate.Visible = true;
			this.chkIncludeGroupToUpdate.Name = "chkIncludeGroupToUpdate";
			this.chkDisplayGroupTitleToUpdate.Text = "Display Group Title on the Report";
			this.chkDisplayGroupTitleToUpdate.Size = new System.Drawing.Size(222, 22);
			this.chkDisplayGroupTitleToUpdate.Location = new System.Drawing.Point(102, 102);
			this.chkDisplayGroupTitleToUpdate.TabIndex = 10;
			this.chkDisplayGroupTitleToUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkDisplayGroupTitleToUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkDisplayGroupTitleToUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkDisplayGroupTitleToUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.chkDisplayGroupTitleToUpdate.CausesValidation = true;
			this.chkDisplayGroupTitleToUpdate.Enabled = true;
			this.chkDisplayGroupTitleToUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkDisplayGroupTitleToUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkDisplayGroupTitleToUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDisplayGroupTitleToUpdate.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkDisplayGroupTitleToUpdate.TabStop = true;
			this.chkDisplayGroupTitleToUpdate.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkDisplayGroupTitleToUpdate.Visible = true;
			this.chkDisplayGroupTitleToUpdate.Name = "chkDisplayGroupTitleToUpdate";
			this.Label3.Text = "Group Name";
			this.Label3.Size = new System.Drawing.Size(82, 24);
			this.Label3.Location = new System.Drawing.Point(14, 48);
			this.Label3.TabIndex = 13;
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
			this.cmdMoveDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveDown.Text = "Move Down";
			this.cmdMoveDown.Size = new System.Drawing.Size(98, 22);
			this.cmdMoveDown.Location = new System.Drawing.Point(84, 199);
			this.cmdMoveDown.TabIndex = 4;
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
			this.cmdMoveUp.Size = new System.Drawing.Size(74, 22);
			this.cmdMoveUp.Location = new System.Drawing.Point(7, 199);
			this.cmdMoveUp.TabIndex = 3;
			this.cmdMoveUp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveUp.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveUp.CausesValidation = true;
			this.cmdMoveUp.Enabled = true;
			this.cmdMoveUp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveUp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveUp.TabStop = true;
			this.cmdMoveUp.Name = "cmdMoveUp";
			this.lstGroups.Size = new System.Drawing.Size(294, 172);
			this.lstGroups.Location = new System.Drawing.Point(8, 24);
			this.lstGroups.TabIndex = 1;
			this.lstGroups.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstGroups.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstGroups.BackColor = System.Drawing.SystemColors.Window;
			this.lstGroups.CausesValidation = true;
			this.lstGroups.Enabled = true;
			this.lstGroups.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstGroups.IntegralHeight = true;
			this.lstGroups.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstGroups.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstGroups.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstGroups.Sorted = false;
			this.lstGroups.TabStop = true;
			this.lstGroups.Visible = true;
			this.lstGroups.MultiColumn = false;
			this.lstGroups.Name = "lstGroups";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Close";
			this.cmdCancel.Size = new System.Drawing.Size(84, 22);
			this.cmdCancel.Location = new System.Drawing.Point(462, 219);
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
			this.Label2.Text = "Existing Groups";
			this.Label2.Size = new System.Drawing.Size(129, 24);
			this.Label2.Location = new System.Drawing.Point(9, 2);
			this.Label2.TabIndex = 2;
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
			this.Controls.Add(cmdChangeStatus);
			this.Controls.Add(cmdDeleteGroup);
			this.Controls.Add(sstabGroup);
			this.Controls.Add(cmdMoveDown);
			this.Controls.Add(cmdMoveUp);
			this.Controls.Add(lstGroups);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(Label2);
			this.sstabGroup.Controls.Add(_sstabGroup_TabPage0);
			this.sstabGroup.Controls.Add(_sstabGroup_TabPage1);
			this._sstabGroup_TabPage0.Controls.Add(Label1);
			this._sstabGroup_TabPage0.Controls.Add(chkDisplayGroupTitle);
			this._sstabGroup_TabPage0.Controls.Add(chkIncludeGroup);
			this._sstabGroup_TabPage0.Controls.Add(txtGroupName);
			this._sstabGroup_TabPage0.Controls.Add(cmdAddSubmissionGroup);
			this._sstabGroup_TabPage0.Controls.Add(chkShowTotal);
			this._sstabGroup_TabPage1.Controls.Add(chkShowTotalToUpdate);
			this._sstabGroup_TabPage1.Controls.Add(cmdUpdate);
			this._sstabGroup_TabPage1.Controls.Add(txtGroupNameToUpdate);
			this._sstabGroup_TabPage1.Controls.Add(chkIncludeGroupToUpdate);
			this._sstabGroup_TabPage1.Controls.Add(chkDisplayGroupTitleToUpdate);
			this._sstabGroup_TabPage1.Controls.Add(Label3);
			this.sstabGroup.ResumeLayout(false);
			this._sstabGroup_TabPage0.ResumeLayout(false);
			this._sstabGroup_TabPage1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
