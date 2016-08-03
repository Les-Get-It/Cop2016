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
	partial class OlddlgParentFields
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OlddlgParentFields() : base()
		{
			Load += dlgParentFields_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdNew;
		public System.Windows.Forms.Button cmdNew {
			get { return withEventsField_cmdNew; }
			set {
				if (withEventsField_cmdNew != null) {
					withEventsField_cmdNew.Click -= cmdNew_Click;
				}
				withEventsField_cmdNew = value;
				if (withEventsField_cmdNew != null) {
					withEventsField_cmdNew.Click += cmdNew_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox txtDefaultValue;
		private System.Windows.Forms.Button withEventsField_OKButton;
		public System.Windows.Forms.Button OKButton {
			get { return withEventsField_OKButton; }
			set {
				if (withEventsField_OKButton != null) {
					withEventsField_OKButton.Click -= OKButton_Click;
				}
				withEventsField_OKButton = value;
				if (withEventsField_OKButton != null) {
					withEventsField_OKButton.Click += OKButton_Click;
				}
			}
		}
		public System.Windows.Forms.Label _Label3_0;
		public System.Windows.Forms.Label _Label3_1;
		public System.Windows.Forms.ListBox lstAvailable;
		public System.Windows.Forms.ListBox lstChildren;
		private System.Windows.Forms.Button withEventsField_cmdLink;
		public System.Windows.Forms.Button cmdLink {
			get { return withEventsField_cmdLink; }
			set {
				if (withEventsField_cmdLink != null) {
					withEventsField_cmdLink.Click -= cmdLink_Click;
				}
				withEventsField_cmdLink = value;
				if (withEventsField_cmdLink != null) {
					withEventsField_cmdLink.Click += cmdLink_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdUnlink;
		public System.Windows.Forms.Button cmdUnlink {
			get { return withEventsField_cmdUnlink; }
			set {
				if (withEventsField_cmdUnlink != null) {
					withEventsField_cmdUnlink.Click -= cmdUnlink_Click;
				}
				withEventsField_cmdUnlink = value;
				if (withEventsField_cmdUnlink != null) {
					withEventsField_cmdUnlink.Click += cmdUnlink_Click;
				}
			}
		}
		public System.Windows.Forms.TabPage _SSTab1_TabPage0;
		public System.Windows.Forms.ListBox lstAnswerCriteria;
		private System.Windows.Forms.ComboBox withEventsField_cboFieldsToLink;
		public System.Windows.Forms.ComboBox cboFieldsToLink {
			get { return withEventsField_cboFieldsToLink; }
			set {
				if (withEventsField_cboFieldsToLink != null) {
					withEventsField_cboFieldsToLink.SelectedIndexChanged -= cboFieldsToLink_SelectedIndexChanged;
				}
				withEventsField_cboFieldsToLink = value;
				if (withEventsField_cboFieldsToLink != null) {
					withEventsField_cboFieldsToLink.SelectedIndexChanged += cboFieldsToLink_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_OptAnswerCriteria;
		public System.Windows.Forms.RadioButton OptAnswerCriteria {
			get { return withEventsField_OptAnswerCriteria; }
			set {
				if (withEventsField_OptAnswerCriteria != null) {
					withEventsField_OptAnswerCriteria.CheckedChanged -= OptAnswerCriteria_CheckedChanged;
				}
				withEventsField_OptAnswerCriteria = value;
				if (withEventsField_OptAnswerCriteria != null) {
					withEventsField_OptAnswerCriteria.CheckedChanged += OptAnswerCriteria_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_OptAnswerCD;
		public System.Windows.Forms.RadioButton OptAnswerCD {
			get { return withEventsField_OptAnswerCD; }
			set {
				if (withEventsField_OptAnswerCD != null) {
					withEventsField_OptAnswerCD.CheckedChanged -= OptAnswerCD_CheckedChanged;
				}
				withEventsField_OptAnswerCD = value;
				if (withEventsField_OptAnswerCD != null) {
					withEventsField_OptAnswerCD.CheckedChanged += OptAnswerCD_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_CmdAddParentCrit;
		public System.Windows.Forms.Button CmdAddParentCrit {
			get { return withEventsField_CmdAddParentCrit; }
			set {
				if (withEventsField_CmdAddParentCrit != null) {
					withEventsField_CmdAddParentCrit.Click -= CmdAddParentCrit_Click;
				}
				withEventsField_CmdAddParentCrit = value;
				if (withEventsField_CmdAddParentCrit != null) {
					withEventsField_CmdAddParentCrit.Click += CmdAddParentCrit_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDelParentCrit;
		public System.Windows.Forms.Button cmdDelParentCrit {
			get { return withEventsField_cmdDelParentCrit; }
			set {
				if (withEventsField_cmdDelParentCrit != null) {
					withEventsField_cmdDelParentCrit.Click -= cmdDelParentCrit_Click;
				}
				withEventsField_cmdDelParentCrit = value;
				if (withEventsField_cmdDelParentCrit != null) {
					withEventsField_cmdDelParentCrit.Click += cmdDelParentCrit_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdChangeParentJoin;
		public System.Windows.Forms.Button cmdChangeParentJoin {
			get { return withEventsField_cmdChangeParentJoin; }
			set {
				if (withEventsField_cmdChangeParentJoin != null) {
					withEventsField_cmdChangeParentJoin.Click -= cmdChangeParentJoin_Click;
				}
				withEventsField_cmdChangeParentJoin = value;
				if (withEventsField_cmdChangeParentJoin != null) {
					withEventsField_cmdChangeParentJoin.Click += cmdChangeParentJoin_Click;
				}
			}
		}
		public System.Windows.Forms.TabPage _SSTab1_TabPage1;
		public System.Windows.Forms.TabControl SSTab1;
		public System.Windows.Forms.TextBox txtParentField;
		private System.Windows.Forms.ListBox withEventsField_lstParents;
		public System.Windows.Forms.ListBox lstParents {
			get { return withEventsField_lstParents; }
			set {
				if (withEventsField_lstParents != null) {
					withEventsField_lstParents.SelectedIndexChanged -= lstParents_SelectedIndexChanged;
				}
				withEventsField_lstParents = value;
				if (withEventsField_lstParents != null) {
					withEventsField_lstParents.SelectedIndexChanged += lstParents_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboAnswerFormat;
		public System.Windows.Forms.ComboBox cboLookup;
		private System.Windows.Forms.Button withEventsField_CancelButton_Renamed;
		public System.Windows.Forms.Button CancelButton_Renamed {
			get { return withEventsField_CancelButton_Renamed; }
			set {
				if (withEventsField_CancelButton_Renamed != null) {
					withEventsField_CancelButton_Renamed.Click -= CancelButton_Renamed_Click;
				}
				withEventsField_CancelButton_Renamed = value;
				if (withEventsField_CancelButton_Renamed != null) {
					withEventsField_CancelButton_Renamed.Click += CancelButton_Renamed_Click;
				}
			}
		}
		public AxMSRDC.AxMSRDC rdcParentFields;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label8;
		public Microsoft.VisualBasic.Compatibility.VB6.LabelArray Label3;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OlddlgParentFields));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdNew = new System.Windows.Forms.Button();
			this.txtDefaultValue = new System.Windows.Forms.TextBox();
			this.OKButton = new System.Windows.Forms.Button();
			this.SSTab1 = new System.Windows.Forms.TabControl();
			this._SSTab1_TabPage0 = new System.Windows.Forms.TabPage();
			this._Label3_0 = new System.Windows.Forms.Label();
			this._Label3_1 = new System.Windows.Forms.Label();
			this.lstAvailable = new System.Windows.Forms.ListBox();
			this.lstChildren = new System.Windows.Forms.ListBox();
			this.cmdLink = new System.Windows.Forms.Button();
			this.cmdUnlink = new System.Windows.Forms.Button();
			this._SSTab1_TabPage1 = new System.Windows.Forms.TabPage();
			this.lstAnswerCriteria = new System.Windows.Forms.ListBox();
			this.cboFieldsToLink = new System.Windows.Forms.ComboBox();
			this.OptAnswerCriteria = new System.Windows.Forms.RadioButton();
			this.OptAnswerCD = new System.Windows.Forms.RadioButton();
			this.CmdAddParentCrit = new System.Windows.Forms.Button();
			this.cmdDelParentCrit = new System.Windows.Forms.Button();
			this.cmdChangeParentJoin = new System.Windows.Forms.Button();
			this.txtParentField = new System.Windows.Forms.TextBox();
			this.lstParents = new System.Windows.Forms.ListBox();
			this.cboAnswerFormat = new System.Windows.Forms.ComboBox();
			this.cboLookup = new System.Windows.Forms.ComboBox();
			this.CancelButton_Renamed = new System.Windows.Forms.Button();
			this.rdcParentFields = new AxMSRDC.AxMSRDC();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label3 = new Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components);
			this.SSTab1.SuspendLayout();
			this._SSTab1_TabPage0.SuspendLayout();
			this._SSTab1_TabPage1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.rdcParentFields).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.Label3).BeginInit();
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Edit Parent Fields";
			this.ClientSize = new System.Drawing.Size(977, 513);
			this.Location = new System.Drawing.Point(230, 313);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ControlBox = true;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "dlgParentFields";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "Delete";
			this.cmdDelete.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDelete.Size = new System.Drawing.Size(102, 42);
			this.cmdDelete.Location = new System.Drawing.Point(870, 180);
			this.cmdDelete.TabIndex = 27;
			this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelete.CausesValidation = true;
			this.cmdDelete.Enabled = true;
			this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelete.TabStop = true;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNew.Text = "Setup Form for New Parent Field";
			this.cmdNew.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdNew.Size = new System.Drawing.Size(182, 42);
			this.cmdNew.Location = new System.Drawing.Point(660, 180);
			this.cmdNew.TabIndex = 26;
			this.cmdNew.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNew.CausesValidation = true;
			this.cmdNew.Enabled = true;
			this.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNew.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNew.TabStop = true;
			this.cmdNew.Name = "cmdNew";
			this.txtDefaultValue.AutoSize = false;
			this.txtDefaultValue.Size = new System.Drawing.Size(232, 24);
			this.txtDefaultValue.Location = new System.Drawing.Point(280, 160);
			this.txtDefaultValue.TabIndex = 4;
			this.txtDefaultValue.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtDefaultValue.AcceptsReturn = true;
			this.txtDefaultValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtDefaultValue.BackColor = System.Drawing.SystemColors.Window;
			this.txtDefaultValue.CausesValidation = true;
			this.txtDefaultValue.Enabled = true;
			this.txtDefaultValue.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtDefaultValue.HideSelection = true;
			this.txtDefaultValue.ReadOnly = false;
			this.txtDefaultValue.MaxLength = 0;
			this.txtDefaultValue.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtDefaultValue.Multiline = false;
			this.txtDefaultValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtDefaultValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtDefaultValue.TabStop = true;
			this.txtDefaultValue.Visible = true;
			this.txtDefaultValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtDefaultValue.Name = "txtDefaultValue";
			this.OKButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.OKButton.Text = "Add/Update";
			this.OKButton.Size = new System.Drawing.Size(102, 32);
			this.OKButton.Location = new System.Drawing.Point(140, 200);
			this.OKButton.TabIndex = 5;
			this.OKButton.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OKButton.BackColor = System.Drawing.SystemColors.Control;
			this.OKButton.CausesValidation = true;
			this.OKButton.Enabled = true;
			this.OKButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OKButton.Cursor = System.Windows.Forms.Cursors.Default;
			this.OKButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OKButton.TabStop = true;
			this.OKButton.Name = "OKButton";
			this.SSTab1.Size = new System.Drawing.Size(972, 272);
			this.SSTab1.Location = new System.Drawing.Point(0, 240);
			this.SSTab1.TabIndex = 11;
			this.SSTab1.SelectedIndex = 1;
			this.SSTab1.ItemSize = new System.Drawing.Size(42, 22);
			this.SSTab1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.SSTab1.Name = "SSTab1";
			this._SSTab1_TabPage0.Text = "Linked Children";
			this._Label3_0.Text = "Linked Child Question Codes";
			this._Label3_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._Label3_0.Size = new System.Drawing.Size(262, 22);
			this._Label3_0.Location = new System.Drawing.Point(550, 45);
			this._Label3_0.TabIndex = 20;
			this._Label3_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label3_0.BackColor = System.Drawing.SystemColors.Control;
			this._Label3_0.Enabled = true;
			this._Label3_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label3_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label3_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label3_0.UseMnemonic = true;
			this._Label3_0.Visible = true;
			this._Label3_0.AutoSize = false;
			this._Label3_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label3_0.Name = "_Label3_0";
			this._Label3_1.Text = "Available Question Codes";
			this._Label3_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._Label3_1.Size = new System.Drawing.Size(192, 22);
			this._Label3_1.Location = new System.Drawing.Point(10, 45);
			this._Label3_1.TabIndex = 21;
			this._Label3_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label3_1.BackColor = System.Drawing.SystemColors.Control;
			this._Label3_1.Enabled = true;
			this._Label3_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label3_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label3_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label3_1.UseMnemonic = true;
			this._Label3_1.Visible = true;
			this._Label3_1.AutoSize = false;
			this._Label3_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label3_1.Name = "_Label3_1";
			this.lstAvailable.Size = new System.Drawing.Size(432, 188);
			this.lstAvailable.Location = new System.Drawing.Point(10, 65);
			this.lstAvailable.TabIndex = 12;
			this.lstAvailable.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstAvailable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstAvailable.BackColor = System.Drawing.SystemColors.Window;
			this.lstAvailable.CausesValidation = true;
			this.lstAvailable.Enabled = true;
			this.lstAvailable.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstAvailable.IntegralHeight = true;
			this.lstAvailable.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstAvailable.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstAvailable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstAvailable.Sorted = false;
			this.lstAvailable.TabStop = true;
			this.lstAvailable.Visible = true;
			this.lstAvailable.MultiColumn = false;
			this.lstAvailable.Name = "lstAvailable";
			this.lstChildren.Size = new System.Drawing.Size(412, 188);
			this.lstChildren.Location = new System.Drawing.Point(550, 65);
			this.lstChildren.TabIndex = 13;
			this.lstChildren.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstChildren.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstChildren.BackColor = System.Drawing.SystemColors.Window;
			this.lstChildren.CausesValidation = true;
			this.lstChildren.Enabled = true;
			this.lstChildren.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstChildren.IntegralHeight = true;
			this.lstChildren.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstChildren.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstChildren.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstChildren.Sorted = false;
			this.lstChildren.TabStop = true;
			this.lstChildren.Visible = true;
			this.lstChildren.MultiColumn = false;
			this.lstChildren.Name = "lstChildren";
			this.cmdLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdLink.Text = "-->>";
			this.cmdLink.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdLink.Size = new System.Drawing.Size(82, 22);
			this.cmdLink.Location = new System.Drawing.Point(460, 95);
			this.cmdLink.TabIndex = 14;
			this.cmdLink.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLink.CausesValidation = true;
			this.cmdLink.Enabled = true;
			this.cmdLink.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLink.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLink.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLink.TabStop = true;
			this.cmdLink.Name = "cmdLink";
			this.cmdUnlink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUnlink.Text = "<<--";
			this.cmdUnlink.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdUnlink.Size = new System.Drawing.Size(82, 22);
			this.cmdUnlink.Location = new System.Drawing.Point(460, 145);
			this.cmdUnlink.TabIndex = 15;
			this.cmdUnlink.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUnlink.CausesValidation = true;
			this.cmdUnlink.Enabled = true;
			this.cmdUnlink.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUnlink.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUnlink.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUnlink.TabStop = true;
			this.cmdUnlink.Name = "cmdUnlink";
			this._SSTab1_TabPage1.Text = "Display/Answer Code";
			this.lstAnswerCriteria.Enabled = false;
			this.lstAnswerCriteria.Size = new System.Drawing.Size(542, 139);
			this.lstAnswerCriteria.Location = new System.Drawing.Point(20, 85);
			this.lstAnswerCriteria.TabIndex = 16;
			this.lstAnswerCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstAnswerCriteria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstAnswerCriteria.BackColor = System.Drawing.SystemColors.Window;
			this.lstAnswerCriteria.CausesValidation = true;
			this.lstAnswerCriteria.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstAnswerCriteria.IntegralHeight = true;
			this.lstAnswerCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstAnswerCriteria.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstAnswerCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstAnswerCriteria.Sorted = false;
			this.lstAnswerCriteria.TabStop = true;
			this.lstAnswerCriteria.Visible = true;
			this.lstAnswerCriteria.MultiColumn = false;
			this.lstAnswerCriteria.Name = "lstAnswerCriteria";
			this.cboFieldsToLink.Enabled = false;
			this.cboFieldsToLink.Size = new System.Drawing.Size(372, 27);
			this.cboFieldsToLink.Location = new System.Drawing.Point(590, 85);
			this.cboFieldsToLink.TabIndex = 17;
			this.cboFieldsToLink.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboFieldsToLink.BackColor = System.Drawing.SystemColors.Window;
			this.cboFieldsToLink.CausesValidation = true;
			this.cboFieldsToLink.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboFieldsToLink.IntegralHeight = true;
			this.cboFieldsToLink.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboFieldsToLink.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboFieldsToLink.Sorted = false;
			this.cboFieldsToLink.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboFieldsToLink.TabStop = true;
			this.cboFieldsToLink.Visible = true;
			this.cboFieldsToLink.Name = "cboFieldsToLink";
			this.OptAnswerCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptAnswerCriteria.Text = "Criteria for Virtual Parent Field";
			this.OptAnswerCriteria.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OptAnswerCriteria.Size = new System.Drawing.Size(282, 27);
			this.OptAnswerCriteria.Location = new System.Drawing.Point(20, 55);
			this.OptAnswerCriteria.TabIndex = 18;
			this.OptAnswerCriteria.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptAnswerCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.OptAnswerCriteria.CausesValidation = true;
			this.OptAnswerCriteria.Enabled = true;
			this.OptAnswerCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OptAnswerCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.OptAnswerCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptAnswerCriteria.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptAnswerCriteria.TabStop = true;
			this.OptAnswerCriteria.Checked = false;
			this.OptAnswerCriteria.Visible = true;
			this.OptAnswerCriteria.Name = "OptAnswerCriteria";
			this.OptAnswerCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptAnswerCD.Text = "Parent Patient Data Field";
			this.OptAnswerCD.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OptAnswerCD.Size = new System.Drawing.Size(242, 27);
			this.OptAnswerCD.Location = new System.Drawing.Point(590, 55);
			this.OptAnswerCD.TabIndex = 19;
			this.OptAnswerCD.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptAnswerCD.BackColor = System.Drawing.SystemColors.Control;
			this.OptAnswerCD.CausesValidation = true;
			this.OptAnswerCD.Enabled = true;
			this.OptAnswerCD.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OptAnswerCD.Cursor = System.Windows.Forms.Cursors.Default;
			this.OptAnswerCD.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptAnswerCD.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptAnswerCD.TabStop = true;
			this.OptAnswerCD.Checked = false;
			this.OptAnswerCD.Visible = true;
			this.OptAnswerCD.Name = "OptAnswerCD";
			this.CmdAddParentCrit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CmdAddParentCrit.Text = "Add Criteria";
			this.CmdAddParentCrit.Enabled = false;
			this.CmdAddParentCrit.Size = new System.Drawing.Size(92, 22);
			this.CmdAddParentCrit.Location = new System.Drawing.Point(30, 225);
			this.CmdAddParentCrit.TabIndex = 23;
			this.CmdAddParentCrit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.CmdAddParentCrit.BackColor = System.Drawing.SystemColors.Control;
			this.CmdAddParentCrit.CausesValidation = true;
			this.CmdAddParentCrit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CmdAddParentCrit.Cursor = System.Windows.Forms.Cursors.Default;
			this.CmdAddParentCrit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CmdAddParentCrit.TabStop = true;
			this.CmdAddParentCrit.Name = "CmdAddParentCrit";
			this.cmdDelParentCrit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelParentCrit.Text = "Delete Criteria";
			this.cmdDelParentCrit.Enabled = false;
			this.cmdDelParentCrit.Size = new System.Drawing.Size(102, 22);
			this.cmdDelParentCrit.Location = new System.Drawing.Point(150, 225);
			this.cmdDelParentCrit.TabIndex = 24;
			this.cmdDelParentCrit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDelParentCrit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelParentCrit.CausesValidation = true;
			this.cmdDelParentCrit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelParentCrit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelParentCrit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelParentCrit.TabStop = true;
			this.cmdDelParentCrit.Name = "cmdDelParentCrit";
			this.cmdChangeParentJoin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeParentJoin.Text = "Change Join Operator btw Sets";
			this.cmdChangeParentJoin.Size = new System.Drawing.Size(122, 42);
			this.cmdChangeParentJoin.Location = new System.Drawing.Point(420, 225);
			this.cmdChangeParentJoin.TabIndex = 28;
			this.cmdChangeParentJoin.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeParentJoin.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeParentJoin.CausesValidation = true;
			this.cmdChangeParentJoin.Enabled = true;
			this.cmdChangeParentJoin.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeParentJoin.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeParentJoin.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeParentJoin.TabStop = true;
			this.cmdChangeParentJoin.Name = "cmdChangeParentJoin";
			this.txtParentField.AutoSize = false;
			this.txtParentField.Size = new System.Drawing.Size(232, 24);
			this.txtParentField.Location = new System.Drawing.Point(280, 40);
			this.txtParentField.TabIndex = 1;
			this.txtParentField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtParentField.AcceptsReturn = true;
			this.txtParentField.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtParentField.BackColor = System.Drawing.SystemColors.Window;
			this.txtParentField.CausesValidation = true;
			this.txtParentField.Enabled = true;
			this.txtParentField.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtParentField.HideSelection = true;
			this.txtParentField.ReadOnly = false;
			this.txtParentField.MaxLength = 0;
			this.txtParentField.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtParentField.Multiline = false;
			this.txtParentField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtParentField.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtParentField.TabStop = true;
			this.txtParentField.Visible = true;
			this.txtParentField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtParentField.Name = "txtParentField";
			this.lstParents.Size = new System.Drawing.Size(312, 139);
			this.lstParents.Location = new System.Drawing.Point(660, 40);
			this.lstParents.Items.AddRange(new object[] { "lstParents" });
			this.lstParents.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstParents.TabIndex = 0;
			this.lstParents.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstParents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstParents.BackColor = System.Drawing.SystemColors.Window;
			this.lstParents.CausesValidation = true;
			this.lstParents.Enabled = true;
			this.lstParents.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstParents.IntegralHeight = true;
			this.lstParents.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstParents.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstParents.Sorted = false;
			this.lstParents.TabStop = true;
			this.lstParents.Visible = true;
			this.lstParents.MultiColumn = false;
			this.lstParents.Name = "lstParents";
			this.cboAnswerFormat.Size = new System.Drawing.Size(229, 27);
			this.cboAnswerFormat.Location = new System.Drawing.Point(280, 120);
			this.cboAnswerFormat.Items.AddRange(new object[] {
				"",
				"DX",
				"PX",
				"DATE",
				"TIME"
			});
			this.cboAnswerFormat.TabIndex = 3;
			this.cboAnswerFormat.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboAnswerFormat.BackColor = System.Drawing.SystemColors.Window;
			this.cboAnswerFormat.CausesValidation = true;
			this.cboAnswerFormat.Enabled = true;
			this.cboAnswerFormat.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboAnswerFormat.IntegralHeight = true;
			this.cboAnswerFormat.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboAnswerFormat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboAnswerFormat.Sorted = false;
			this.cboAnswerFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboAnswerFormat.TabStop = true;
			this.cboAnswerFormat.Visible = true;
			this.cboAnswerFormat.Name = "cboAnswerFormat";
			this.cboLookup.Size = new System.Drawing.Size(229, 27);
			this.cboLookup.Location = new System.Drawing.Point(280, 80);
			this.cboLookup.TabIndex = 2;
			this.cboLookup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboLookup.BackColor = System.Drawing.SystemColors.Window;
			this.cboLookup.CausesValidation = true;
			this.cboLookup.Enabled = true;
			this.cboLookup.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboLookup.IntegralHeight = true;
			this.cboLookup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboLookup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboLookup.Sorted = false;
			this.cboLookup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboLookup.TabStop = true;
			this.cboLookup.Visible = true;
			this.cboLookup.Name = "cboLookup";
			this.CancelButton_Renamed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CancelButton_Renamed.Text = "Cancel/Close";
			this.CancelButton_Renamed.Size = new System.Drawing.Size(102, 32);
			this.CancelButton_Renamed.Location = new System.Drawing.Point(300, 200);
			this.CancelButton_Renamed.TabIndex = 6;
			this.CancelButton_Renamed.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.CancelButton_Renamed.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton_Renamed.CausesValidation = true;
			this.CancelButton_Renamed.Enabled = true;
			this.CancelButton_Renamed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CancelButton_Renamed.Cursor = System.Windows.Forms.Cursors.Default;
			this.CancelButton_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CancelButton_Renamed.TabStop = true;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			rdcParentFields.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcParentFields.OcxState");
			this.rdcParentFields.Size = new System.Drawing.Size(100, 28);
			this.rdcParentFields.Location = new System.Drawing.Point(660, 210);
			this.rdcParentFields.Visible = false;
			this.rdcParentFields.Name = "rdcParentFields";
			this.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label5.Text = "(Optional) Default Value";
			this.Label5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label5.Size = new System.Drawing.Size(262, 22);
			this.Label5.Location = new System.Drawing.Point(14, 170);
			this.Label5.TabIndex = 25;
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
			this.Label4.Text = "(Yes/No is default)";
			this.Label4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label4.Size = new System.Drawing.Size(142, 22);
			this.Label4.Location = new System.Drawing.Point(510, 90);
			this.Label4.TabIndex = 22;
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this.Label2.Text = "List of all Parent Fields (click to Edit)";
			this.Label2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.Size = new System.Drawing.Size(322, 22);
			this.Label2.Location = new System.Drawing.Point(660, 20);
			this.Label2.TabIndex = 10;
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
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label1.Text = "Parent Field Name";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.Size = new System.Drawing.Size(192, 22);
			this.Label1.Location = new System.Drawing.Point(84, 40);
			this.Label1.TabIndex = 9;
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
			this.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label9.Text = "(Optional) Answer Code Format:";
			this.Label9.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label9.Size = new System.Drawing.Size(272, 27);
			this.Label9.Location = new System.Drawing.Point(0, 130);
			this.Label9.TabIndex = 8;
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
			this.Label8.Text = "Valid Answer Codes from Lookup Table:";
			this.Label8.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label8.Size = new System.Drawing.Size(252, 39);
			this.Label8.Location = new System.Drawing.Point(24, 80);
			this.Label8.TabIndex = 7;
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
			this.Controls.Add(cmdDelete);
			this.Controls.Add(cmdNew);
			this.Controls.Add(txtDefaultValue);
			this.Controls.Add(OKButton);
			this.Controls.Add(SSTab1);
			this.Controls.Add(txtParentField);
			this.Controls.Add(lstParents);
			this.Controls.Add(cboAnswerFormat);
			this.Controls.Add(cboLookup);
			this.Controls.Add(CancelButton_Renamed);
			this.Controls.Add(rdcParentFields);
			this.Controls.Add(Label5);
			this.Controls.Add(Label4);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.Controls.Add(Label9);
			this.Controls.Add(Label8);
			this.SSTab1.Controls.Add(_SSTab1_TabPage0);
			this.SSTab1.Controls.Add(_SSTab1_TabPage1);
			this._SSTab1_TabPage0.Controls.Add(_Label3_0);
			this._SSTab1_TabPage0.Controls.Add(_Label3_1);
			this._SSTab1_TabPage0.Controls.Add(lstAvailable);
			this._SSTab1_TabPage0.Controls.Add(lstChildren);
			this._SSTab1_TabPage0.Controls.Add(cmdLink);
			this._SSTab1_TabPage0.Controls.Add(cmdUnlink);
			this._SSTab1_TabPage1.Controls.Add(lstAnswerCriteria);
			this._SSTab1_TabPage1.Controls.Add(cboFieldsToLink);
			this._SSTab1_TabPage1.Controls.Add(OptAnswerCriteria);
			this._SSTab1_TabPage1.Controls.Add(OptAnswerCD);
			this._SSTab1_TabPage1.Controls.Add(CmdAddParentCrit);
			this._SSTab1_TabPage1.Controls.Add(cmdDelParentCrit);
			this._SSTab1_TabPage1.Controls.Add(cmdChangeParentJoin);
			this.Label3.SetIndex(_Label3_1, Convert.ToInt16(1));
			this.Label3.SetIndex(_Label3_0, Convert.ToInt16(0));
			((System.ComponentModel.ISupportInitialize)this.Label3).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcParentFields).EndInit();
			this.SSTab1.ResumeLayout(false);
			this._SSTab1_TabPage0.ResumeLayout(false);
			this._SSTab1_TabPage1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
