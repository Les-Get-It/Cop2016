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
	partial class OldfrmRiskAdjustment
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmRiskAdjustment() : base()
		{
			Load += frmRiskAdjustment_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdDeletePeriod;
		public System.Windows.Forms.Button cmdDeletePeriod {
			get { return withEventsField_cmdDeletePeriod; }
			set {
				if (withEventsField_cmdDeletePeriod != null) {
					withEventsField_cmdDeletePeriod.Click -= cmdDeletePeriod_Click;
				}
				withEventsField_cmdDeletePeriod = value;
				if (withEventsField_cmdDeletePeriod != null) {
					withEventsField_cmdDeletePeriod.Click += cmdDeletePeriod_Click;
				}
			}
		}
		private System.Windows.Forms.ListBox withEventsField_lstPeriods;
		public System.Windows.Forms.ListBox lstPeriods {
			get { return withEventsField_lstPeriods; }
			set {
				if (withEventsField_lstPeriods != null) {
					withEventsField_lstPeriods.SelectedIndexChanged -= lstPeriods_SelectedIndexChanged;
				}
				withEventsField_lstPeriods = value;
				if (withEventsField_lstPeriods != null) {
					withEventsField_lstPeriods.SelectedIndexChanged += lstPeriods_SelectedIndexChanged;
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
		private System.Windows.Forms.ComboBox withEventsField_cmbFactor;
		public System.Windows.Forms.ComboBox cmbFactor {
			get { return withEventsField_cmbFactor; }
			set {
				if (withEventsField_cmbFactor != null) {
					withEventsField_cmbFactor.SelectedIndexChanged -= cmbFactor_SelectedIndexChanged;
				}
				withEventsField_cmbFactor = value;
				if (withEventsField_cmbFactor != null) {
					withEventsField_cmbFactor.SelectedIndexChanged += cmbFactor_SelectedIndexChanged;
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
		public System.Windows.Forms.RadioButton _optFields_0;
		public System.Windows.Forms.RadioButton _optFields_1;
		private System.Windows.Forms.CheckedListBox withEventsField_lstPatRecFields;
		public System.Windows.Forms.CheckedListBox lstPatRecFields {
			get { return withEventsField_lstPatRecFields; }
			set {
				if (withEventsField_lstPatRecFields != null) {
					withEventsField_lstPatRecFields.ItemCheck -= lstPatRecFields_ItemCheck;
				}
				withEventsField_lstPatRecFields = value;
				if (withEventsField_lstPatRecFields != null) {
					withEventsField_lstPatRecFields.ItemCheck += lstPatRecFields_ItemCheck;
				}
			}
		}
		public System.Windows.Forms.ListBox lstTriggers;
		private System.Windows.Forms.ComboBox withEventsField_cmbTrigger;
		public System.Windows.Forms.ComboBox cmbTrigger {
			get { return withEventsField_cmbTrigger; }
			set {
				if (withEventsField_cmbTrigger != null) {
					withEventsField_cmbTrigger.SelectedIndexChanged -= cmbTrigger_SelectedIndexChanged;
				}
				withEventsField_cmbTrigger = value;
				if (withEventsField_cmbTrigger != null) {
					withEventsField_cmbTrigger.SelectedIndexChanged += cmbTrigger_SelectedIndexChanged;
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
		private System.Windows.Forms.Button withEventsField_cmdRemove;
		public System.Windows.Forms.Button cmdRemove {
			get { return withEventsField_cmdRemove; }
			set {
				if (withEventsField_cmdRemove != null) {
					withEventsField_cmdRemove.Click -= cmdRemove_Click;
				}
				withEventsField_cmdRemove = value;
				if (withEventsField_cmdRemove != null) {
					withEventsField_cmdRemove.Click += cmdRemove_Click;
				}
			}
		}
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Panel Frame4;
		public System.Windows.Forms.TabPage _tabFacor_TabPage0;
		private System.Windows.Forms.Button withEventsField_cmdEdit2;
		public System.Windows.Forms.Button cmdEdit2 {
			get { return withEventsField_cmdEdit2; }
			set {
				if (withEventsField_cmdEdit2 != null) {
					withEventsField_cmdEdit2.Click -= cmdEdit2_Click;
				}
				withEventsField_cmdEdit2 = value;
				if (withEventsField_cmdEdit2 != null) {
					withEventsField_cmdEdit2.Click += cmdEdit2_Click;
				}
			}
		}
		private System.Windows.Forms.CheckedListBox withEventsField_lstPatRecFields2;
		public System.Windows.Forms.CheckedListBox lstPatRecFields2 {
			get { return withEventsField_lstPatRecFields2; }
			set {
				if (withEventsField_lstPatRecFields2 != null) {
					withEventsField_lstPatRecFields2.ItemCheck -= lstPatRecFields2_ItemCheck;
				}
				withEventsField_lstPatRecFields2 = value;
				if (withEventsField_lstPatRecFields2 != null) {
					withEventsField_lstPatRecFields2.ItemCheck += lstPatRecFields2_ItemCheck;
				}
			}
		}
		public System.Windows.Forms.ListBox lstTriggers2;
		private System.Windows.Forms.ComboBox withEventsField_cmbTrigger2;
		public System.Windows.Forms.ComboBox cmbTrigger2 {
			get { return withEventsField_cmbTrigger2; }
			set {
				if (withEventsField_cmbTrigger2 != null) {
					withEventsField_cmbTrigger2.SelectedIndexChanged -= cmbTrigger2_SelectedIndexChanged;
				}
				withEventsField_cmbTrigger2 = value;
				if (withEventsField_cmbTrigger2 != null) {
					withEventsField_cmbTrigger2.SelectedIndexChanged += cmbTrigger2_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAdd2;
		public System.Windows.Forms.Button cmdAdd2 {
			get { return withEventsField_cmdAdd2; }
			set {
				if (withEventsField_cmdAdd2 != null) {
					withEventsField_cmdAdd2.Click -= cmdAdd2_Click;
				}
				withEventsField_cmdAdd2 = value;
				if (withEventsField_cmdAdd2 != null) {
					withEventsField_cmdAdd2.Click += cmdAdd2_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemove2;
		public System.Windows.Forms.Button cmdRemove2 {
			get { return withEventsField_cmdRemove2; }
			set {
				if (withEventsField_cmdRemove2 != null) {
					withEventsField_cmdRemove2.Click -= cmdRemove2_Click;
				}
				withEventsField_cmdRemove2 = value;
				if (withEventsField_cmdRemove2 != null) {
					withEventsField_cmdRemove2.Click += cmdRemove2_Click;
				}
			}
		}
		public System.Windows.Forms.RadioButton _optFieldsTwo_1;
		public System.Windows.Forms.RadioButton _optFieldsTwo_0;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label11;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.Panel Frame2;
		public System.Windows.Forms.TabPage _tabFacor_TabPage1;
		private System.Windows.Forms.CheckedListBox withEventsField_lstPatRecFields3;
		public System.Windows.Forms.CheckedListBox lstPatRecFields3 {
			get { return withEventsField_lstPatRecFields3; }
			set {
				if (withEventsField_lstPatRecFields3 != null) {
					withEventsField_lstPatRecFields3.ItemCheck -= lstPatRecFields3_ItemCheck;
				}
				withEventsField_lstPatRecFields3 = value;
				if (withEventsField_lstPatRecFields3 != null) {
					withEventsField_lstPatRecFields3.ItemCheck += lstPatRecFields3_ItemCheck;
				}
			}
		}
		private System.Windows.Forms.ComboBox withEventsField_cmbTrigger3;
		public System.Windows.Forms.ComboBox cmbTrigger3 {
			get { return withEventsField_cmbTrigger3; }
			set {
				if (withEventsField_cmbTrigger3 != null) {
					withEventsField_cmbTrigger3.SelectedIndexChanged -= cmbTrigger3_SelectedIndexChanged;
				}
				withEventsField_cmbTrigger3 = value;
				if (withEventsField_cmbTrigger3 != null) {
					withEventsField_cmbTrigger3.SelectedIndexChanged += cmbTrigger3_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.RadioButton _optFieldsThree_1;
		public System.Windows.Forms.RadioButton _optFieldsThree_0;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Panel Frame1;
		public System.Windows.Forms.TabPage _tabFacor_TabPage2;
		public System.Windows.Forms.TabControl tabFacor;
		public System.Windows.Forms.GroupBox fraFactors;
		public AxMSRDC.AxMSRDC rdcCondition;
		private System.Windows.Forms.ComboBox withEventsField_cmbIndicators;
		public System.Windows.Forms.ComboBox cmbIndicators {
			get { return withEventsField_cmbIndicators; }
			set {
				if (withEventsField_cmbIndicators != null) {
					withEventsField_cmbIndicators.SelectedIndexChanged -= cmbIndicators_SelectedIndexChanged;
				}
				withEventsField_cmbIndicators = value;
				if (withEventsField_cmbIndicators != null) {
					withEventsField_cmbIndicators.SelectedIndexChanged += cmbIndicators_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.GroupBox Frame3;
		public System.Windows.Forms.Label Label1;
		private Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray withEventsField_optFields;
		public Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray optFields {
			get { return withEventsField_optFields; }
			set {
				if (withEventsField_optFields != null) {
					withEventsField_optFields.CheckedChanged -= optFields_CheckedChanged;
				}
				withEventsField_optFields = value;
				if (withEventsField_optFields != null) {
					withEventsField_optFields.CheckedChanged += optFields_CheckedChanged;
				}
			}
		}
		private Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray withEventsField_optFieldsThree;
		public Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray optFieldsThree {
			get { return withEventsField_optFieldsThree; }
			set {
				if (withEventsField_optFieldsThree != null) {
					withEventsField_optFieldsThree.CheckedChanged -= optFieldsThree_CheckedChanged;
				}
				withEventsField_optFieldsThree = value;
				if (withEventsField_optFieldsThree != null) {
					withEventsField_optFieldsThree.CheckedChanged += optFieldsThree_CheckedChanged;
				}
			}
		}
		private Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray withEventsField_optFieldsTwo;
		public Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray optFieldsTwo {
			get { return withEventsField_optFieldsTwo; }
			set {
				if (withEventsField_optFieldsTwo != null) {
					withEventsField_optFieldsTwo.CheckedChanged -= optFieldsTwo_CheckedChanged;
				}
				withEventsField_optFieldsTwo = value;
				if (withEventsField_optFieldsTwo != null) {
					withEventsField_optFieldsTwo.CheckedChanged += optFieldsTwo_CheckedChanged;
				}
			}
		}
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmRiskAdjustment));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdDeletePeriod = new System.Windows.Forms.Button();
			this.lstPeriods = new System.Windows.Forms.ListBox();
			this.fraFactors = new System.Windows.Forms.GroupBox();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmbFactor = new System.Windows.Forms.ComboBox();
			this.tabFacor = new System.Windows.Forms.TabControl();
			this._tabFacor_TabPage0 = new System.Windows.Forms.TabPage();
			this.Frame4 = new System.Windows.Forms.Panel();
			this.cmdEdit = new System.Windows.Forms.Button();
			this._optFields_0 = new System.Windows.Forms.RadioButton();
			this._optFields_1 = new System.Windows.Forms.RadioButton();
			this.lstPatRecFields = new System.Windows.Forms.CheckedListBox();
			this.lstTriggers = new System.Windows.Forms.ListBox();
			this.cmbTrigger = new System.Windows.Forms.ComboBox();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdRemove = new System.Windows.Forms.Button();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this._tabFacor_TabPage1 = new System.Windows.Forms.TabPage();
			this.Frame2 = new System.Windows.Forms.Panel();
			this.cmdEdit2 = new System.Windows.Forms.Button();
			this.lstPatRecFields2 = new System.Windows.Forms.CheckedListBox();
			this.lstTriggers2 = new System.Windows.Forms.ListBox();
			this.cmbTrigger2 = new System.Windows.Forms.ComboBox();
			this.cmdAdd2 = new System.Windows.Forms.Button();
			this.cmdRemove2 = new System.Windows.Forms.Button();
			this._optFieldsTwo_1 = new System.Windows.Forms.RadioButton();
			this._optFieldsTwo_0 = new System.Windows.Forms.RadioButton();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this._tabFacor_TabPage2 = new System.Windows.Forms.TabPage();
			this.Frame1 = new System.Windows.Forms.Panel();
			this.lstPatRecFields3 = new System.Windows.Forms.CheckedListBox();
			this.cmbTrigger3 = new System.Windows.Forms.ComboBox();
			this._optFieldsThree_1 = new System.Windows.Forms.RadioButton();
			this._optFieldsThree_0 = new System.Windows.Forms.RadioButton();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.rdcCondition = new AxMSRDC.AxMSRDC();
			this.Frame3 = new System.Windows.Forms.GroupBox();
			this.cmbIndicators = new System.Windows.Forms.ComboBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.optFields = new Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components);
			this.optFieldsThree = new Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components);
			this.optFieldsTwo = new Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components);
			this.fraFactors.SuspendLayout();
			this.tabFacor.SuspendLayout();
			this._tabFacor_TabPage0.SuspendLayout();
			this.Frame4.SuspendLayout();
			this._tabFacor_TabPage1.SuspendLayout();
			this.Frame2.SuspendLayout();
			this._tabFacor_TabPage2.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.Frame3.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.rdcCondition).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.optFields).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.optFieldsThree).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.optFieldsTwo).BeginInit();
			this.Text = "Risk Adjustment";
			this.ClientSize = new System.Drawing.Size(1055, 383);
			this.Location = new System.Drawing.Point(5, 38);
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
			this.Name = "frmRiskAdjustment";
			this.cmdDeletePeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDeletePeriod.Text = "Delete Period";
			this.cmdDeletePeriod.Size = new System.Drawing.Size(122, 32);
			this.cmdDeletePeriod.Location = new System.Drawing.Point(20, 330);
			this.cmdDeletePeriod.TabIndex = 39;
			this.cmdDeletePeriod.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDeletePeriod.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDeletePeriod.CausesValidation = true;
			this.cmdDeletePeriod.Enabled = true;
			this.cmdDeletePeriod.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDeletePeriod.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDeletePeriod.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDeletePeriod.TabStop = true;
			this.cmdDeletePeriod.Name = "cmdDeletePeriod";
			this.lstPeriods.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.lstPeriods.Size = new System.Drawing.Size(128, 220);
			this.lstPeriods.Location = new System.Drawing.Point(15, 100);
			this.lstPeriods.TabIndex = 4;
			this.lstPeriods.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstPeriods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstPeriods.CausesValidation = true;
			this.lstPeriods.Enabled = true;
			this.lstPeriods.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstPeriods.IntegralHeight = true;
			this.lstPeriods.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstPeriods.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstPeriods.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstPeriods.Sorted = false;
			this.lstPeriods.TabStop = true;
			this.lstPeriods.Visible = true;
			this.lstPeriods.MultiColumn = false;
			this.lstPeriods.Name = "lstPeriods";
			this.fraFactors.Text = "Factor Description";
			this.fraFactors.Enabled = false;
			this.fraFactors.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.fraFactors.Size = new System.Drawing.Size(870, 302);
			this.fraFactors.Location = new System.Drawing.Point(172, 69);
			this.fraFactors.TabIndex = 2;
			this.fraFactors.BackColor = System.Drawing.SystemColors.Control;
			this.fraFactors.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraFactors.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraFactors.Visible = true;
			this.fraFactors.Padding = new System.Windows.Forms.Padding(0);
			this.fraFactors.Name = "fraFactors";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "Delete Factor";
			this.cmdDelete.Size = new System.Drawing.Size(112, 32);
			this.cmdDelete.Location = new System.Drawing.Point(480, 20);
			this.cmdDelete.TabIndex = 38;
			this.cmdDelete.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelete.CausesValidation = true;
			this.cmdDelete.Enabled = true;
			this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelete.TabStop = true;
			this.cmdDelete.Name = "cmdDelete";
			this.cmbFactor.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.cmbFactor.ForeColor = System.Drawing.Color.Blue;
			this.cmbFactor.Size = new System.Drawing.Size(422, 27);
			this.cmbFactor.Location = new System.Drawing.Point(10, 20);
			this.cmbFactor.TabIndex = 3;
			this.cmbFactor.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmbFactor.CausesValidation = true;
			this.cmbFactor.Enabled = true;
			this.cmbFactor.IntegralHeight = true;
			this.cmbFactor.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbFactor.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbFactor.Sorted = false;
			this.cmbFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cmbFactor.TabStop = true;
			this.cmbFactor.Visible = true;
			this.cmbFactor.Name = "cmbFactor";
			this.tabFacor.Size = new System.Drawing.Size(852, 232);
			this.tabFacor.Location = new System.Drawing.Point(10, 60);
			this.tabFacor.TabIndex = 6;
			this.tabFacor.ItemSize = new System.Drawing.Size(42, 22);
			this.tabFacor.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.tabFacor.Name = "tabFacor";
			this._tabFacor_TabPage0.Text = "Compare Fields 1";
			this.Frame4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame4.Size = new System.Drawing.Size(832, 192);
			this.Frame4.Location = new System.Drawing.Point(10, 30);
			this.Frame4.TabIndex = 21;
			this.Frame4.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame4.BackColor = System.Drawing.SystemColors.Control;
			this.Frame4.Enabled = true;
			this.Frame4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame4.Visible = true;
			this.Frame4.Name = "Frame4";
			this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEdit.Text = "Edit";
			this.cmdEdit.Size = new System.Drawing.Size(62, 32);
			this.cmdEdit.Location = new System.Drawing.Point(700, 150);
			this.cmdEdit.TabIndex = 36;
			this.cmdEdit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdEdit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEdit.CausesValidation = true;
			this.cmdEdit.Enabled = true;
			this.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEdit.TabStop = true;
			this.cmdEdit.Name = "cmdEdit";
			this._optFields_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optFields_0.Text = "Show Associated Fields";
			this._optFields_0.Size = new System.Drawing.Size(192, 22);
			this._optFields_0.Location = new System.Drawing.Point(0, 160);
			this._optFields_0.TabIndex = 31;
			this._optFields_0.Checked = true;
			this._optFields_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._optFields_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optFields_0.BackColor = System.Drawing.SystemColors.Control;
			this._optFields_0.CausesValidation = true;
			this._optFields_0.Enabled = true;
			this._optFields_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optFields_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._optFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optFields_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optFields_0.TabStop = true;
			this._optFields_0.Visible = true;
			this._optFields_0.Name = "_optFields_0";
			this._optFields_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optFields_1.Text = "Show All Fields";
			this._optFields_1.Size = new System.Drawing.Size(162, 22);
			this._optFields_1.Location = new System.Drawing.Point(210, 160);
			this._optFields_1.TabIndex = 30;
			this._optFields_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._optFields_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optFields_1.BackColor = System.Drawing.SystemColors.Control;
			this._optFields_1.CausesValidation = true;
			this._optFields_1.Enabled = true;
			this._optFields_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optFields_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._optFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optFields_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optFields_1.TabStop = true;
			this._optFields_1.Checked = false;
			this._optFields_1.Visible = true;
			this._optFields_1.Name = "_optFields_1";
			this.lstPatRecFields.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.lstPatRecFields.ForeColor = System.Drawing.Color.Blue;
			this.lstPatRecFields.Size = new System.Drawing.Size(402, 118);
			this.lstPatRecFields.Location = new System.Drawing.Point(0, 40);
			this.lstPatRecFields.TabIndex = 26;
			this.lstPatRecFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstPatRecFields.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstPatRecFields.CausesValidation = true;
			this.lstPatRecFields.Enabled = true;
			this.lstPatRecFields.IntegralHeight = true;
			this.lstPatRecFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstPatRecFields.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstPatRecFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstPatRecFields.Sorted = false;
			this.lstPatRecFields.TabStop = true;
			this.lstPatRecFields.Visible = true;
			this.lstPatRecFields.MultiColumn = false;
			this.lstPatRecFields.Name = "lstPatRecFields";
			this.lstTriggers.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.lstTriggers.ForeColor = System.Drawing.Color.Blue;
			this.lstTriggers.Size = new System.Drawing.Size(202, 107);
			this.lstTriggers.Location = new System.Drawing.Point(630, 40);
			this.lstTriggers.TabIndex = 25;
			this.lstTriggers.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstTriggers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstTriggers.CausesValidation = true;
			this.lstTriggers.Enabled = true;
			this.lstTriggers.IntegralHeight = true;
			this.lstTriggers.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstTriggers.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstTriggers.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstTriggers.Sorted = false;
			this.lstTriggers.TabStop = true;
			this.lstTriggers.Visible = true;
			this.lstTriggers.MultiColumn = false;
			this.lstTriggers.Name = "lstTriggers";
			this.cmbTrigger.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.cmbTrigger.ForeColor = System.Drawing.Color.Blue;
			this.cmbTrigger.Size = new System.Drawing.Size(192, 27);
			this.cmbTrigger.Location = new System.Drawing.Point(420, 40);
			this.cmbTrigger.Items.AddRange(new object[] {
				"Contains",
				"Patient Age Is",
				"Is Between",
				"Is Greater Than",
				"Is Less Than"
			});
			this.cmbTrigger.TabIndex = 24;
			this.cmbTrigger.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmbTrigger.CausesValidation = true;
			this.cmbTrigger.Enabled = true;
			this.cmbTrigger.IntegralHeight = true;
			this.cmbTrigger.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbTrigger.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbTrigger.Sorted = false;
			this.cmbTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cmbTrigger.TabStop = true;
			this.cmbTrigger.Visible = true;
			this.cmbTrigger.Name = "cmbTrigger";
			this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAdd.Text = "Add";
			this.cmdAdd.Size = new System.Drawing.Size(62, 32);
			this.cmdAdd.Location = new System.Drawing.Point(630, 150);
			this.cmdAdd.TabIndex = 23;
			this.cmdAdd.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdd.CausesValidation = true;
			this.cmdAdd.Enabled = true;
			this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdd.TabStop = true;
			this.cmdAdd.Name = "cmdAdd";
			this.cmdRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemove.Text = "Remove";
			this.cmdRemove.Size = new System.Drawing.Size(62, 32);
			this.cmdRemove.Location = new System.Drawing.Point(770, 150);
			this.cmdRemove.TabIndex = 22;
			this.cmdRemove.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemove.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemove.CausesValidation = true;
			this.cmdRemove.Enabled = true;
			this.cmdRemove.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemove.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemove.TabStop = true;
			this.cmdRemove.Name = "cmdRemove";
			this.Label4.Text = "Values";
			this.Label4.Size = new System.Drawing.Size(162, 22);
			this.Label4.Location = new System.Drawing.Point(630, 10);
			this.Label4.TabIndex = 29;
			this.Label4.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
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
			this.Label3.Text = "Operator";
			this.Label3.Size = new System.Drawing.Size(162, 22);
			this.Label3.Location = new System.Drawing.Point(420, 10);
			this.Label3.TabIndex = 28;
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
			this.Label2.Text = "Fields";
			this.Label2.Size = new System.Drawing.Size(162, 22);
			this.Label2.Location = new System.Drawing.Point(0, 10);
			this.Label2.TabIndex = 27;
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
			this._tabFacor_TabPage1.Text = "Compare Fields 2";
			this.Frame2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame2.Size = new System.Drawing.Size(832, 182);
			this.Frame2.Location = new System.Drawing.Point(10, 40);
			this.Frame2.TabIndex = 10;
			this.Frame2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame2.BackColor = System.Drawing.SystemColors.Control;
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Visible = true;
			this.Frame2.Name = "Frame2";
			this.cmdEdit2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEdit2.Text = "Edit";
			this.cmdEdit2.Size = new System.Drawing.Size(62, 32);
			this.cmdEdit2.Location = new System.Drawing.Point(700, 140);
			this.cmdEdit2.TabIndex = 37;
			this.cmdEdit2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdEdit2.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEdit2.CausesValidation = true;
			this.cmdEdit2.Enabled = true;
			this.cmdEdit2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEdit2.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEdit2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEdit2.TabStop = true;
			this.cmdEdit2.Name = "cmdEdit2";
			this.lstPatRecFields2.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.lstPatRecFields2.ForeColor = System.Drawing.Color.Blue;
			this.lstPatRecFields2.Size = new System.Drawing.Size(402, 118);
			this.lstPatRecFields2.Location = new System.Drawing.Point(0, 30);
			this.lstPatRecFields2.TabIndex = 17;
			this.lstPatRecFields2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstPatRecFields2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstPatRecFields2.CausesValidation = true;
			this.lstPatRecFields2.Enabled = true;
			this.lstPatRecFields2.IntegralHeight = true;
			this.lstPatRecFields2.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstPatRecFields2.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstPatRecFields2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstPatRecFields2.Sorted = false;
			this.lstPatRecFields2.TabStop = true;
			this.lstPatRecFields2.Visible = true;
			this.lstPatRecFields2.MultiColumn = false;
			this.lstPatRecFields2.Name = "lstPatRecFields2";
			this.lstTriggers2.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.lstTriggers2.ForeColor = System.Drawing.Color.Blue;
			this.lstTriggers2.Size = new System.Drawing.Size(202, 107);
			this.lstTriggers2.Location = new System.Drawing.Point(630, 30);
			this.lstTriggers2.TabIndex = 16;
			this.lstTriggers2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstTriggers2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstTriggers2.CausesValidation = true;
			this.lstTriggers2.Enabled = true;
			this.lstTriggers2.IntegralHeight = true;
			this.lstTriggers2.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstTriggers2.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstTriggers2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstTriggers2.Sorted = false;
			this.lstTriggers2.TabStop = true;
			this.lstTriggers2.Visible = true;
			this.lstTriggers2.MultiColumn = false;
			this.lstTriggers2.Name = "lstTriggers2";
			this.cmbTrigger2.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.cmbTrigger2.ForeColor = System.Drawing.Color.Blue;
			this.cmbTrigger2.Size = new System.Drawing.Size(192, 27);
			this.cmbTrigger2.Location = new System.Drawing.Point(420, 30);
			this.cmbTrigger2.Items.AddRange(new object[] {
				"Contains",
				"Patient Age Is",
				"Is Between",
				"Is Greater Than",
				"Is Less Than"
			});
			this.cmbTrigger2.TabIndex = 15;
			this.cmbTrigger2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmbTrigger2.CausesValidation = true;
			this.cmbTrigger2.Enabled = true;
			this.cmbTrigger2.IntegralHeight = true;
			this.cmbTrigger2.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbTrigger2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbTrigger2.Sorted = false;
			this.cmbTrigger2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cmbTrigger2.TabStop = true;
			this.cmbTrigger2.Visible = true;
			this.cmbTrigger2.Name = "cmbTrigger2";
			this.cmdAdd2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAdd2.Text = "Add";
			this.cmdAdd2.Size = new System.Drawing.Size(62, 32);
			this.cmdAdd2.Location = new System.Drawing.Point(630, 140);
			this.cmdAdd2.TabIndex = 14;
			this.cmdAdd2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAdd2.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdd2.CausesValidation = true;
			this.cmdAdd2.Enabled = true;
			this.cmdAdd2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdd2.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAdd2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdd2.TabStop = true;
			this.cmdAdd2.Name = "cmdAdd2";
			this.cmdRemove2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemove2.Text = "Remove";
			this.cmdRemove2.Size = new System.Drawing.Size(62, 32);
			this.cmdRemove2.Location = new System.Drawing.Point(770, 140);
			this.cmdRemove2.TabIndex = 13;
			this.cmdRemove2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemove2.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemove2.CausesValidation = true;
			this.cmdRemove2.Enabled = true;
			this.cmdRemove2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemove2.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemove2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemove2.TabStop = true;
			this.cmdRemove2.Name = "cmdRemove2";
			this._optFieldsTwo_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optFieldsTwo_1.Text = "Show All Fields";
			this._optFieldsTwo_1.Size = new System.Drawing.Size(182, 22);
			this._optFieldsTwo_1.Location = new System.Drawing.Point(210, 150);
			this._optFieldsTwo_1.TabIndex = 12;
			this._optFieldsTwo_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._optFieldsTwo_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optFieldsTwo_1.BackColor = System.Drawing.SystemColors.Control;
			this._optFieldsTwo_1.CausesValidation = true;
			this._optFieldsTwo_1.Enabled = true;
			this._optFieldsTwo_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optFieldsTwo_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._optFieldsTwo_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optFieldsTwo_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optFieldsTwo_1.TabStop = true;
			this._optFieldsTwo_1.Checked = false;
			this._optFieldsTwo_1.Visible = true;
			this._optFieldsTwo_1.Name = "_optFieldsTwo_1";
			this._optFieldsTwo_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optFieldsTwo_0.Text = "Show Associated Fields";
			this._optFieldsTwo_0.Size = new System.Drawing.Size(182, 22);
			this._optFieldsTwo_0.Location = new System.Drawing.Point(0, 150);
			this._optFieldsTwo_0.TabIndex = 11;
			this._optFieldsTwo_0.Checked = true;
			this._optFieldsTwo_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._optFieldsTwo_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optFieldsTwo_0.BackColor = System.Drawing.SystemColors.Control;
			this._optFieldsTwo_0.CausesValidation = true;
			this._optFieldsTwo_0.Enabled = true;
			this._optFieldsTwo_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optFieldsTwo_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._optFieldsTwo_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optFieldsTwo_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optFieldsTwo_0.TabStop = true;
			this._optFieldsTwo_0.Visible = true;
			this._optFieldsTwo_0.Name = "_optFieldsTwo_0";
			this.Label7.Text = "Values";
			this.Label7.Size = new System.Drawing.Size(162, 22);
			this.Label7.Location = new System.Drawing.Point(630, 0);
			this.Label7.TabIndex = 20;
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
			this.Label11.Text = "Operator";
			this.Label11.Size = new System.Drawing.Size(162, 22);
			this.Label11.Location = new System.Drawing.Point(420, 0);
			this.Label11.TabIndex = 19;
			this.Label11.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this.Label10.Text = "Fields";
			this.Label10.Size = new System.Drawing.Size(162, 22);
			this.Label10.Location = new System.Drawing.Point(0, 0);
			this.Label10.TabIndex = 18;
			this.Label10.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label10.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this._tabFacor_TabPage2.Text = "Calculate Factors";
			this.Frame1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame1.Size = new System.Drawing.Size(832, 192);
			this.Frame1.Location = new System.Drawing.Point(10, 30);
			this.Frame1.TabIndex = 7;
			this.Frame1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Name = "Frame1";
			this.lstPatRecFields3.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.lstPatRecFields3.ForeColor = System.Drawing.Color.Blue;
			this.lstPatRecFields3.Size = new System.Drawing.Size(402, 118);
			this.lstPatRecFields3.Location = new System.Drawing.Point(0, 40);
			this.lstPatRecFields3.TabIndex = 33;
			this.lstPatRecFields3.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstPatRecFields3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstPatRecFields3.CausesValidation = true;
			this.lstPatRecFields3.Enabled = true;
			this.lstPatRecFields3.IntegralHeight = true;
			this.lstPatRecFields3.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstPatRecFields3.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstPatRecFields3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstPatRecFields3.Sorted = false;
			this.lstPatRecFields3.TabStop = true;
			this.lstPatRecFields3.Visible = true;
			this.lstPatRecFields3.MultiColumn = false;
			this.lstPatRecFields3.Name = "lstPatRecFields3";
			this.cmbTrigger3.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.cmbTrigger3.ForeColor = System.Drawing.Color.Blue;
			this.cmbTrigger3.Size = new System.Drawing.Size(192, 27);
			this.cmbTrigger3.Location = new System.Drawing.Point(420, 40);
			this.cmbTrigger3.Items.AddRange(new object[] { "Multiply" });
			this.cmbTrigger3.TabIndex = 32;
			this.cmbTrigger3.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmbTrigger3.CausesValidation = true;
			this.cmbTrigger3.Enabled = true;
			this.cmbTrigger3.IntegralHeight = true;
			this.cmbTrigger3.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbTrigger3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbTrigger3.Sorted = false;
			this.cmbTrigger3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cmbTrigger3.TabStop = true;
			this.cmbTrigger3.Visible = true;
			this.cmbTrigger3.Name = "cmbTrigger3";
			this._optFieldsThree_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optFieldsThree_1.Text = "Show All Factors";
			this._optFieldsThree_1.Size = new System.Drawing.Size(172, 22);
			this._optFieldsThree_1.Location = new System.Drawing.Point(210, 160);
			this._optFieldsThree_1.TabIndex = 9;
			this._optFieldsThree_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._optFieldsThree_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optFieldsThree_1.BackColor = System.Drawing.SystemColors.Control;
			this._optFieldsThree_1.CausesValidation = true;
			this._optFieldsThree_1.Enabled = true;
			this._optFieldsThree_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optFieldsThree_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._optFieldsThree_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optFieldsThree_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optFieldsThree_1.TabStop = true;
			this._optFieldsThree_1.Checked = false;
			this._optFieldsThree_1.Visible = true;
			this._optFieldsThree_1.Name = "_optFieldsThree_1";
			this._optFieldsThree_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optFieldsThree_0.Text = "Show Associated Factors";
			this._optFieldsThree_0.Size = new System.Drawing.Size(212, 22);
			this._optFieldsThree_0.Location = new System.Drawing.Point(0, 160);
			this._optFieldsThree_0.TabIndex = 8;
			this._optFieldsThree_0.Checked = true;
			this._optFieldsThree_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._optFieldsThree_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optFieldsThree_0.BackColor = System.Drawing.SystemColors.Control;
			this._optFieldsThree_0.CausesValidation = true;
			this._optFieldsThree_0.Enabled = true;
			this._optFieldsThree_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optFieldsThree_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._optFieldsThree_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optFieldsThree_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optFieldsThree_0.TabStop = true;
			this._optFieldsThree_0.Visible = true;
			this._optFieldsThree_0.Name = "_optFieldsThree_0";
			this.Label9.Text = "Operator";
			this.Label9.Size = new System.Drawing.Size(162, 22);
			this.Label9.Location = new System.Drawing.Point(420, 10);
			this.Label9.TabIndex = 35;
			this.Label9.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label9.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this.Label8.Text = "Factors";
			this.Label8.Size = new System.Drawing.Size(162, 22);
			this.Label8.Location = new System.Drawing.Point(0, 10);
			this.Label8.TabIndex = 34;
			this.Label8.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			rdcCondition.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcCondition.OcxState");
			this.rdcCondition.Size = new System.Drawing.Size(162, 28);
			this.rdcCondition.Location = new System.Drawing.Point(20, 400);
			this.rdcCondition.Visible = false;
			this.rdcCondition.Name = "rdcCondition";
			this.Frame3.Text = "Select Indicator";
			this.Frame3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame3.Size = new System.Drawing.Size(442, 62);
			this.Frame3.Location = new System.Drawing.Point(10, 0);
			this.Frame3.TabIndex = 0;
			this.Frame3.BackColor = System.Drawing.SystemColors.Control;
			this.Frame3.Enabled = true;
			this.Frame3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame3.Visible = true;
			this.Frame3.Padding = new System.Windows.Forms.Padding(0);
			this.Frame3.Name = "Frame3";
			this.cmbIndicators.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.cmbIndicators.ForeColor = System.Drawing.Color.Blue;
			this.cmbIndicators.Size = new System.Drawing.Size(422, 27);
			this.cmbIndicators.Location = new System.Drawing.Point(10, 20);
			this.cmbIndicators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbIndicators.TabIndex = 1;
			this.cmbIndicators.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmbIndicators.CausesValidation = true;
			this.cmbIndicators.Enabled = true;
			this.cmbIndicators.IntegralHeight = true;
			this.cmbIndicators.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbIndicators.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbIndicators.Sorted = false;
			this.cmbIndicators.TabStop = true;
			this.cmbIndicators.Visible = true;
			this.cmbIndicators.Name = "cmbIndicators";
			this.Label1.Text = "Reporting Period";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.Size = new System.Drawing.Size(147, 27);
			this.Label1.Location = new System.Drawing.Point(17, 73);
			this.Label1.TabIndex = 5;
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
			this.optFields.SetIndex(_optFields_0, Convert.ToInt16(0));
			this.optFields.SetIndex(_optFields_1, Convert.ToInt16(1));
			this.optFieldsThree.SetIndex(_optFieldsThree_1, Convert.ToInt16(1));
			this.optFieldsThree.SetIndex(_optFieldsThree_0, Convert.ToInt16(0));
			this.optFieldsTwo.SetIndex(_optFieldsTwo_1, Convert.ToInt16(1));
			this.optFieldsTwo.SetIndex(_optFieldsTwo_0, Convert.ToInt16(0));
			((System.ComponentModel.ISupportInitialize)this.optFieldsTwo).EndInit();
			((System.ComponentModel.ISupportInitialize)this.optFieldsThree).EndInit();
			((System.ComponentModel.ISupportInitialize)this.optFields).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcCondition).EndInit();
			this.Controls.Add(cmdDeletePeriod);
			this.Controls.Add(lstPeriods);
			this.Controls.Add(fraFactors);
			this.Controls.Add(rdcCondition);
			this.Controls.Add(Frame3);
			this.Controls.Add(Label1);
			this.fraFactors.Controls.Add(cmdDelete);
			this.fraFactors.Controls.Add(cmbFactor);
			this.fraFactors.Controls.Add(tabFacor);
			this.tabFacor.Controls.Add(_tabFacor_TabPage0);
			this.tabFacor.Controls.Add(_tabFacor_TabPage1);
			this.tabFacor.Controls.Add(_tabFacor_TabPage2);
			this._tabFacor_TabPage0.Controls.Add(Frame4);
			this.Frame4.Controls.Add(cmdEdit);
			this.Frame4.Controls.Add(_optFields_0);
			this.Frame4.Controls.Add(_optFields_1);
			this.Frame4.Controls.Add(lstPatRecFields);
			this.Frame4.Controls.Add(lstTriggers);
			this.Frame4.Controls.Add(cmbTrigger);
			this.Frame4.Controls.Add(cmdAdd);
			this.Frame4.Controls.Add(cmdRemove);
			this.Frame4.Controls.Add(Label4);
			this.Frame4.Controls.Add(Label3);
			this.Frame4.Controls.Add(Label2);
			this._tabFacor_TabPage1.Controls.Add(Frame2);
			this.Frame2.Controls.Add(cmdEdit2);
			this.Frame2.Controls.Add(lstPatRecFields2);
			this.Frame2.Controls.Add(lstTriggers2);
			this.Frame2.Controls.Add(cmbTrigger2);
			this.Frame2.Controls.Add(cmdAdd2);
			this.Frame2.Controls.Add(cmdRemove2);
			this.Frame2.Controls.Add(_optFieldsTwo_1);
			this.Frame2.Controls.Add(_optFieldsTwo_0);
			this.Frame2.Controls.Add(Label7);
			this.Frame2.Controls.Add(Label11);
			this.Frame2.Controls.Add(Label10);
			this._tabFacor_TabPage2.Controls.Add(Frame1);
			this.Frame1.Controls.Add(lstPatRecFields3);
			this.Frame1.Controls.Add(cmbTrigger3);
			this.Frame1.Controls.Add(_optFieldsThree_1);
			this.Frame1.Controls.Add(_optFieldsThree_0);
			this.Frame1.Controls.Add(Label9);
			this.Frame1.Controls.Add(Label8);
			this.Frame3.Controls.Add(cmbIndicators);
			this.fraFactors.ResumeLayout(false);
			this.tabFacor.ResumeLayout(false);
			this._tabFacor_TabPage0.ResumeLayout(false);
			this.Frame4.ResumeLayout(false);
			this._tabFacor_TabPage1.ResumeLayout(false);
			this.Frame2.ResumeLayout(false);
			this._tabFacor_TabPage2.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.Frame3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
