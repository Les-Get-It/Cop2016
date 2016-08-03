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
	partial class OldfrmMeasureAddCritSetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmMeasureAddCritSetup() : base()
		{
			Load += frmMeasureAddCritSetup_Load;
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
		public System.Windows.Forms.RadioButton OptAll;
		public System.Windows.Forms.RadioButton OptMultAny;
		public System.Windows.Forms.GroupBox frmMultSel;
		private System.Windows.Forms.ListBox withEventsField_lstFieldList;
		public System.Windows.Forms.ListBox lstFieldList {
			get { return withEventsField_lstFieldList; }
			set {
				if (withEventsField_lstFieldList != null) {
					withEventsField_lstFieldList.SelectedIndexChanged -= lstFieldList_SelectedIndexChanged;
				}
				withEventsField_lstFieldList = value;
				if (withEventsField_lstFieldList != null) {
					withEventsField_lstFieldList.SelectedIndexChanged += lstFieldList_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.TabPage _TabFirstField_TabPage0;
		public System.Windows.Forms.ListBox lstGroupList;
		public System.Windows.Forms.TabPage _TabFirstField_TabPage1;
		public System.Windows.Forms.TabControl TabFirstField;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.TextBox txtGoToStep;
		private System.Windows.Forms.ComboBox withEventsField_cboStep;
		public System.Windows.Forms.ComboBox cboStep {
			get { return withEventsField_cboStep; }
			set {
				if (withEventsField_cboStep != null) {
					withEventsField_cboStep.SelectedIndexChanged -= cboStep_SelectedIndexChanged;
				}
				withEventsField_cboStep = value;
				if (withEventsField_cboStep != null) {
					withEventsField_cboStep.SelectedIndexChanged += cboStep_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboCat;
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
		public System.Windows.Forms.ComboBox cboJoinOperator;
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
		private System.Windows.Forms.RadioButton withEventsField_Opt6Method;
		public System.Windows.Forms.RadioButton Opt6Method {
			get { return withEventsField_Opt6Method; }
			set {
				if (withEventsField_Opt6Method != null) {
					withEventsField_Opt6Method.CheckedChanged -= Opt6Method_CheckedChanged;
				}
				withEventsField_Opt6Method = value;
				if (withEventsField_Opt6Method != null) {
					withEventsField_Opt6Method.CheckedChanged += Opt6Method_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_Opt5Method;
		public System.Windows.Forms.RadioButton Opt5Method {
			get { return withEventsField_Opt5Method; }
			set {
				if (withEventsField_Opt5Method != null) {
					withEventsField_Opt5Method.CheckedChanged -= Opt5Method_CheckedChanged;
				}
				withEventsField_Opt5Method = value;
				if (withEventsField_Opt5Method != null) {
					withEventsField_Opt5Method.CheckedChanged += Opt5Method_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_Opt3Method;
		public System.Windows.Forms.RadioButton Opt3Method {
			get { return withEventsField_Opt3Method; }
			set {
				if (withEventsField_Opt3Method != null) {
					withEventsField_Opt3Method.CheckedChanged -= Opt3Method_CheckedChanged;
				}
				withEventsField_Opt3Method = value;
				if (withEventsField_Opt3Method != null) {
					withEventsField_Opt3Method.CheckedChanged += Opt3Method_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_Opt2Method;
		public System.Windows.Forms.RadioButton Opt2Method {
			get { return withEventsField_Opt2Method; }
			set {
				if (withEventsField_Opt2Method != null) {
					withEventsField_Opt2Method.CheckedChanged -= Opt2Method_CheckedChanged;
				}
				withEventsField_Opt2Method = value;
				if (withEventsField_Opt2Method != null) {
					withEventsField_Opt2Method.CheckedChanged += Opt2Method_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_Opt1Method;
		public System.Windows.Forms.RadioButton Opt1Method {
			get { return withEventsField_Opt1Method; }
			set {
				if (withEventsField_Opt1Method != null) {
					withEventsField_Opt1Method.CheckedChanged -= Opt1Method_CheckedChanged;
				}
				withEventsField_Opt1Method = value;
				if (withEventsField_Opt1Method != null) {
					withEventsField_Opt1Method.CheckedChanged += Opt1Method_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_Opt4Method;
		public System.Windows.Forms.RadioButton Opt4Method {
			get { return withEventsField_Opt4Method; }
			set {
				if (withEventsField_Opt4Method != null) {
					withEventsField_Opt4Method.CheckedChanged -= Opt4Method_CheckedChanged;
				}
				withEventsField_Opt4Method = value;
				if (withEventsField_Opt4Method != null) {
					withEventsField_Opt4Method.CheckedChanged += Opt4Method_CheckedChanged;
				}
			}
		}
		public System.Windows.Forms.GroupBox Frame2;
		private System.Windows.Forms.ComboBox withEventsField_cboSet;
		public System.Windows.Forms.ComboBox cboSet {
			get { return withEventsField_cboSet; }
			set {
				if (withEventsField_cboSet != null) {
					withEventsField_cboSet.SelectedIndexChanged -= cboSet_SelectedIndexChanged;
				}
				withEventsField_cboSet = value;
				if (withEventsField_cboSet != null) {
					withEventsField_cboSet.SelectedIndexChanged += cboSet_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label6;
		private System.Windows.Forms.ComboBox withEventsField_cboDestField;
		public System.Windows.Forms.ComboBox cboDestField {
			get { return withEventsField_cboDestField; }
			set {
				if (withEventsField_cboDestField != null) {
					withEventsField_cboDestField.SelectedIndexChanged -= cboDestField_SelectedIndexChanged;
				}
				withEventsField_cboDestField = value;
				if (withEventsField_cboDestField != null) {
					withEventsField_cboDestField.SelectedIndexChanged += cboDestField_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.CheckBox withEventsField_chkBlank;
		public System.Windows.Forms.CheckBox chkBlank {
			get { return withEventsField_chkBlank; }
			set {
				if (withEventsField_chkBlank != null) {
					withEventsField_chkBlank.CheckStateChanged -= chkBlank_CheckStateChanged;
				}
				withEventsField_chkBlank = value;
				if (withEventsField_chkBlank != null) {
					withEventsField_chkBlank.CheckStateChanged += chkBlank_CheckStateChanged;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtOpt1TypeinValue;
		public System.Windows.Forms.TextBox txtOpt1TypeinValue {
			get { return withEventsField_txtOpt1TypeinValue; }
			set {
				if (withEventsField_txtOpt1TypeinValue != null) {
					withEventsField_txtOpt1TypeinValue.TextChanged -= txtOpt1TypeinValue_TextChanged;
				}
				withEventsField_txtOpt1TypeinValue = value;
				if (withEventsField_txtOpt1TypeinValue != null) {
					withEventsField_txtOpt1TypeinValue.TextChanged += txtOpt1TypeinValue_TextChanged;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboOpt1ValueOperator;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage0;
		public System.Windows.Forms.ComboBox cboOpt2ValueOperator;
		public System.Windows.Forms.ComboBox cboLookupValues;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.Label Label14;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage1;
		public System.Windows.Forms.ComboBox cboLookupTables;
		public System.Windows.Forms.ComboBox cboOpLkTable;
		public System.Windows.Forms.Label Label16;
		public System.Windows.Forms.Label Label17;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage2;
		public System.Windows.Forms.ComboBox cboOpt3Unit;
		public System.Windows.Forms.ComboBox cboOpt3ValueOperator;
		public System.Windows.Forms.TextBox txtOpt3TypeinValue;
		public System.Windows.Forms.ComboBox cboFieldOperator;
		public System.Windows.Forms.ComboBox cboField2List;
		public System.Windows.Forms.Label Label15;
		public System.Windows.Forms.Label Label13;
		public System.Windows.Forms.Label Label11;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage3;
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
		private System.Windows.Forms.Button withEventsField_cmdAddVal;
		public System.Windows.Forms.Button cmdAddVal {
			get { return withEventsField_cmdAddVal; }
			set {
				if (withEventsField_cmdAddVal != null) {
					withEventsField_cmdAddVal.Click -= cmdAddVal_Click;
				}
				withEventsField_cmdAddVal = value;
				if (withEventsField_cmdAddVal != null) {
					withEventsField_cmdAddVal.Click += cmdAddVal_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstRange;
		public System.Windows.Forms.ComboBox cboOpt5ValueOperator;
		public System.Windows.Forms.Label Label19;
		public System.Windows.Forms.Label Label18;
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage4;
		public System.Windows.Forms.ComboBox cboOpt6ValueOperator;
		public System.Windows.Forms.CheckBox chkBlank6;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage5;
		public System.Windows.Forms.TabControl sstabOptions;
		public Microsoft.VisualBasic.PowerPacks.LineShape Line2;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label lblSet;
		public Microsoft.VisualBasic.PowerPacks.LineShape Line1;
		public System.Windows.Forms.Label lblCat;
		public System.Windows.Forms.Label lblColName;
		public System.Windows.Forms.Label lblJoinOperator;
		public System.Windows.Forms.Label lblNote;
		public System.Windows.Forms.Label lblStep;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmMeasureAddCritSetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.frmMultSel = new System.Windows.Forms.GroupBox();
			this.OptAll = new System.Windows.Forms.RadioButton();
			this.OptMultAny = new System.Windows.Forms.RadioButton();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.TabFirstField = new System.Windows.Forms.TabControl();
			this._TabFirstField_TabPage0 = new System.Windows.Forms.TabPage();
			this.lstFieldList = new System.Windows.Forms.ListBox();
			this._TabFirstField_TabPage1 = new System.Windows.Forms.TabPage();
			this.lstGroupList = new System.Windows.Forms.ListBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtGoToStep = new System.Windows.Forms.TextBox();
			this.cboStep = new System.Windows.Forms.ComboBox();
			this.cboCat = new System.Windows.Forms.ComboBox();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cboJoinOperator = new System.Windows.Forms.ComboBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this.Opt6Method = new System.Windows.Forms.RadioButton();
			this.Opt5Method = new System.Windows.Forms.RadioButton();
			this.Opt3Method = new System.Windows.Forms.RadioButton();
			this.Opt2Method = new System.Windows.Forms.RadioButton();
			this.Opt1Method = new System.Windows.Forms.RadioButton();
			this.Opt4Method = new System.Windows.Forms.RadioButton();
			this.cboSet = new System.Windows.Forms.ComboBox();
			this.sstabOptions = new System.Windows.Forms.TabControl();
			this._sstabOptions_TabPage0 = new System.Windows.Forms.TabPage();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.cboDestField = new System.Windows.Forms.ComboBox();
			this.chkBlank = new System.Windows.Forms.CheckBox();
			this.txtOpt1TypeinValue = new System.Windows.Forms.TextBox();
			this.cboOpt1ValueOperator = new System.Windows.Forms.ComboBox();
			this._sstabOptions_TabPage1 = new System.Windows.Forms.TabPage();
			this.cboOpt2ValueOperator = new System.Windows.Forms.ComboBox();
			this.cboLookupValues = new System.Windows.Forms.ComboBox();
			this.Label10 = new System.Windows.Forms.Label();
			this.Label14 = new System.Windows.Forms.Label();
			this._sstabOptions_TabPage2 = new System.Windows.Forms.TabPage();
			this.cboLookupTables = new System.Windows.Forms.ComboBox();
			this.cboOpLkTable = new System.Windows.Forms.ComboBox();
			this.Label16 = new System.Windows.Forms.Label();
			this.Label17 = new System.Windows.Forms.Label();
			this._sstabOptions_TabPage3 = new System.Windows.Forms.TabPage();
			this.cboOpt3Unit = new System.Windows.Forms.ComboBox();
			this.cboOpt3ValueOperator = new System.Windows.Forms.ComboBox();
			this.txtOpt3TypeinValue = new System.Windows.Forms.TextBox();
			this.cboFieldOperator = new System.Windows.Forms.ComboBox();
			this.cboField2List = new System.Windows.Forms.ComboBox();
			this.Label15 = new System.Windows.Forms.Label();
			this.Label13 = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this._sstabOptions_TabPage4 = new System.Windows.Forms.TabPage();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdAddVal = new System.Windows.Forms.Button();
			this.lstRange = new System.Windows.Forms.ListBox();
			this.cboOpt5ValueOperator = new System.Windows.Forms.ComboBox();
			this.Label19 = new System.Windows.Forms.Label();
			this.Label18 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this._sstabOptions_TabPage5 = new System.Windows.Forms.TabPage();
			this.cboOpt6ValueOperator = new System.Windows.Forms.ComboBox();
			this.chkBlank6 = new System.Windows.Forms.CheckBox();
			this.Line2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.Label7 = new System.Windows.Forms.Label();
			this.lblSet = new System.Windows.Forms.Label();
			this.Line1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.lblCat = new System.Windows.Forms.Label();
			this.lblColName = new System.Windows.Forms.Label();
			this.lblJoinOperator = new System.Windows.Forms.Label();
			this.lblNote = new System.Windows.Forms.Label();
			this.lblStep = new System.Windows.Forms.Label();
			this.frmMultSel.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.TabFirstField.SuspendLayout();
			this._TabFirstField_TabPage0.SuspendLayout();
			this._TabFirstField_TabPage1.SuspendLayout();
			this.Frame2.SuspendLayout();
			this.sstabOptions.SuspendLayout();
			this._sstabOptions_TabPage0.SuspendLayout();
			this._sstabOptions_TabPage1.SuspendLayout();
			this._sstabOptions_TabPage2.SuspendLayout();
			this._sstabOptions_TabPage3.SuspendLayout();
			this._sstabOptions_TabPage4.SuspendLayout();
			this._sstabOptions_TabPage5.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Measure Flowchart Setup";
			this.ClientSize = new System.Drawing.Size(1277, 684);
			this.Location = new System.Drawing.Point(5, 29);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
			this.Name = "frmMeasureAddCritSetup";
			this.frmMultSel.Text = "Multiple Sel";
			this.frmMultSel.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.frmMultSel.Size = new System.Drawing.Size(102, 102);
			this.frmMultSel.Location = new System.Drawing.Point(630, 390);
			this.frmMultSel.TabIndex = 63;
			this.frmMultSel.Visible = false;
			this.frmMultSel.BackColor = System.Drawing.SystemColors.Control;
			this.frmMultSel.Enabled = true;
			this.frmMultSel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmMultSel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmMultSel.Padding = new System.Windows.Forms.Padding(0);
			this.frmMultSel.Name = "frmMultSel";
			this.OptAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptAll.Text = "All";
			this.OptAll.Size = new System.Drawing.Size(52, 22);
			this.OptAll.Location = new System.Drawing.Point(20, 60);
			this.OptAll.TabIndex = 65;
			this.OptAll.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OptAll.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptAll.BackColor = System.Drawing.SystemColors.Control;
			this.OptAll.CausesValidation = true;
			this.OptAll.Enabled = true;
			this.OptAll.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OptAll.Cursor = System.Windows.Forms.Cursors.Default;
			this.OptAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptAll.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptAll.TabStop = true;
			this.OptAll.Checked = false;
			this.OptAll.Visible = true;
			this.OptAll.Name = "OptAll";
			this.OptMultAny.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptMultAny.Text = "Any";
			this.OptMultAny.Size = new System.Drawing.Size(52, 22);
			this.OptMultAny.Location = new System.Drawing.Point(20, 30);
			this.OptMultAny.TabIndex = 64;
			this.OptMultAny.Checked = true;
			this.OptMultAny.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OptMultAny.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptMultAny.BackColor = System.Drawing.SystemColors.Control;
			this.OptMultAny.CausesValidation = true;
			this.OptMultAny.Enabled = true;
			this.OptMultAny.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OptMultAny.Cursor = System.Windows.Forms.Cursors.Default;
			this.OptMultAny.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptMultAny.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptMultAny.TabStop = true;
			this.OptMultAny.Visible = true;
			this.OptMultAny.Name = "OptMultAny";
			this.Frame1.Size = new System.Drawing.Size(632, 412);
			this.Frame1.Location = new System.Drawing.Point(0, 270);
			this.Frame1.TabIndex = 58;
			this.Frame1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.TabFirstField.Size = new System.Drawing.Size(612, 372);
			this.TabFirstField.Location = new System.Drawing.Point(10, 20);
			this.TabFirstField.TabIndex = 59;
			this.TabFirstField.ItemSize = new System.Drawing.Size(42, 22);
			this.TabFirstField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.TabFirstField.Name = "TabFirstField";
			this._TabFirstField_TabPage0.Text = "Patient Field";
			this.lstFieldList.Size = new System.Drawing.Size(587, 318);
			this.lstFieldList.Location = new System.Drawing.Point(10, 40);
			this.lstFieldList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstFieldList.TabIndex = 60;
			this.lstFieldList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstFieldList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstFieldList.BackColor = System.Drawing.SystemColors.Window;
			this.lstFieldList.CausesValidation = true;
			this.lstFieldList.Enabled = true;
			this.lstFieldList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstFieldList.IntegralHeight = true;
			this.lstFieldList.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstFieldList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstFieldList.Sorted = false;
			this.lstFieldList.TabStop = true;
			this.lstFieldList.Visible = true;
			this.lstFieldList.MultiColumn = false;
			this.lstFieldList.Name = "lstFieldList";
			this._TabFirstField_TabPage1.Text = "Group Logic";
			this.lstGroupList.Size = new System.Drawing.Size(585, 318);
			this.lstGroupList.Location = new System.Drawing.Point(17, 40);
			this.lstGroupList.TabIndex = 61;
			this.lstGroupList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstGroupList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstGroupList.BackColor = System.Drawing.SystemColors.Window;
			this.lstGroupList.CausesValidation = true;
			this.lstGroupList.Enabled = true;
			this.lstGroupList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstGroupList.IntegralHeight = true;
			this.lstGroupList.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstGroupList.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstGroupList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstGroupList.Sorted = false;
			this.lstGroupList.TabStop = true;
			this.lstGroupList.Visible = true;
			this.lstGroupList.MultiColumn = false;
			this.lstGroupList.Name = "lstGroupList";
			this.Label1.Text = "Select FIRST Field";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.ForeColor = System.Drawing.Color.Blue;
			this.Label1.Size = new System.Drawing.Size(287, 17);
			this.Label1.Location = new System.Drawing.Point(40, 190);
			this.Label1.TabIndex = 62;
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.Enabled = true;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.txtGoToStep.AutoSize = false;
			this.txtGoToStep.Size = new System.Drawing.Size(60, 24);
			this.txtGoToStep.Location = new System.Drawing.Point(570, 238);
			this.txtGoToStep.TabIndex = 57;
			this.txtGoToStep.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtGoToStep.AcceptsReturn = true;
			this.txtGoToStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtGoToStep.BackColor = System.Drawing.SystemColors.Window;
			this.txtGoToStep.CausesValidation = true;
			this.txtGoToStep.Enabled = true;
			this.txtGoToStep.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGoToStep.HideSelection = true;
			this.txtGoToStep.ReadOnly = false;
			this.txtGoToStep.MaxLength = 0;
			this.txtGoToStep.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtGoToStep.Multiline = false;
			this.txtGoToStep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtGoToStep.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtGoToStep.TabStop = true;
			this.txtGoToStep.Visible = true;
			this.txtGoToStep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtGoToStep.Name = "txtGoToStep";
			this.cboStep.Size = new System.Drawing.Size(92, 27);
			this.cboStep.Location = new System.Drawing.Point(10, 235);
			this.cboStep.TabIndex = 0;
			this.cboStep.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboStep.BackColor = System.Drawing.SystemColors.Window;
			this.cboStep.CausesValidation = true;
			this.cboStep.Enabled = true;
			this.cboStep.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStep.IntegralHeight = true;
			this.cboStep.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboStep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboStep.Sorted = false;
			this.cboStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboStep.TabStop = true;
			this.cboStep.Visible = true;
			this.cboStep.Name = "cboStep";
			this.cboCat.Size = new System.Drawing.Size(62, 27);
			this.cboCat.Location = new System.Drawing.Point(370, 235);
			this.cboCat.TabIndex = 1;
			this.cboCat.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboCat.BackColor = System.Drawing.SystemColors.Window;
			this.cboCat.CausesValidation = true;
			this.cboCat.Enabled = true;
			this.cboCat.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCat.IntegralHeight = true;
			this.cboCat.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboCat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboCat.Sorted = false;
			this.cboCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboCat.TabStop = true;
			this.cboCat.Visible = true;
			this.cboCat.Name = "cboCat";
			this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAdd.Text = "Add";
			this.cmdAdd.Size = new System.Drawing.Size(120, 34);
			this.cmdAdd.Location = new System.Drawing.Point(820, 600);
			this.cmdAdd.TabIndex = 18;
			this.cmdAdd.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdd.CausesValidation = true;
			this.cmdAdd.Enabled = true;
			this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdd.TabStop = true;
			this.cmdAdd.Name = "cmdAdd";
			this.cboJoinOperator.Size = new System.Drawing.Size(72, 27);
			this.cboJoinOperator.Location = new System.Drawing.Point(930, 235);
			this.cboJoinOperator.Items.AddRange(new object[] {
				"AND",
				"OR"
			});
			this.cboJoinOperator.TabIndex = 3;
			this.cboJoinOperator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboJoinOperator.BackColor = System.Drawing.SystemColors.Window;
			this.cboJoinOperator.CausesValidation = true;
			this.cboJoinOperator.Enabled = true;
			this.cboJoinOperator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboJoinOperator.IntegralHeight = true;
			this.cboJoinOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboJoinOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboJoinOperator.Sorted = false;
			this.cboJoinOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboJoinOperator.TabStop = true;
			this.cboJoinOperator.Visible = true;
			this.cboJoinOperator.Name = "cboJoinOperator";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(110, 34);
			this.cmdCancel.Location = new System.Drawing.Point(1040, 600);
			this.cmdCancel.TabIndex = 19;
			this.cmdCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.Frame2.Text = "Select A Method";
			this.Frame2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame2.ForeColor = System.Drawing.Color.Blue;
			this.Frame2.Size = new System.Drawing.Size(594, 172);
			this.Frame2.Location = new System.Drawing.Point(0, 20);
			this.Frame2.TabIndex = 34;
			this.Frame2.BackColor = System.Drawing.SystemColors.Control;
			this.Frame2.Enabled = true;
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Visible = true;
			this.Frame2.Padding = new System.Windows.Forms.Padding(0);
			this.Frame2.Name = "Frame2";
			this.Opt6Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt6Method.Text = "Method 6: Earliest Previous Set(s) Valid Dates (compared to next time field to add or subtract date/time)";
			this.Opt6Method.Size = new System.Drawing.Size(574, 35);
			this.Opt6Method.Location = new System.Drawing.Point(10, 130);
			this.Opt6Method.TabIndex = 53;
			this.Opt6Method.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Opt6Method.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt6Method.BackColor = System.Drawing.SystemColors.Control;
			this.Opt6Method.CausesValidation = true;
			this.Opt6Method.Enabled = true;
			this.Opt6Method.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Opt6Method.Cursor = System.Windows.Forms.Cursors.Default;
			this.Opt6Method.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Opt6Method.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Opt6Method.TabStop = true;
			this.Opt6Method.Checked = false;
			this.Opt6Method.Visible = true;
			this.Opt6Method.Name = "Opt6Method";
			this.Opt5Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt5Method.Text = "Method 5: Compare a field Month to several values";
			this.Opt5Method.Size = new System.Drawing.Size(444, 25);
			this.Opt5Method.Location = new System.Drawing.Point(10, 108);
			this.Opt5Method.TabIndex = 45;
			this.Opt5Method.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Opt5Method.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt5Method.BackColor = System.Drawing.SystemColors.Control;
			this.Opt5Method.CausesValidation = true;
			this.Opt5Method.Enabled = true;
			this.Opt5Method.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Opt5Method.Cursor = System.Windows.Forms.Cursors.Default;
			this.Opt5Method.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Opt5Method.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Opt5Method.TabStop = true;
			this.Opt5Method.Checked = false;
			this.Opt5Method.Visible = true;
			this.Opt5Method.Name = "Opt5Method";
			this.Opt3Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt3Method.Text = "Method 3: Compare a field to every value of a lookup table";
			this.Opt3Method.Size = new System.Drawing.Size(427, 25);
			this.Opt3Method.Location = new System.Drawing.Point(10, 64);
			this.Opt3Method.TabIndex = 44;
			this.Opt3Method.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Opt3Method.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt3Method.BackColor = System.Drawing.SystemColors.Control;
			this.Opt3Method.CausesValidation = true;
			this.Opt3Method.Enabled = true;
			this.Opt3Method.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Opt3Method.Cursor = System.Windows.Forms.Cursors.Default;
			this.Opt3Method.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Opt3Method.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Opt3Method.TabStop = true;
			this.Opt3Method.Checked = false;
			this.Opt3Method.Visible = true;
			this.Opt3Method.Name = "Opt3Method";
			this.Opt2Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt2Method.Text = "Method 2: Compare a field to a value in a lookup table";
			this.Opt2Method.Size = new System.Drawing.Size(427, 25);
			this.Opt2Method.Location = new System.Drawing.Point(10, 41);
			this.Opt2Method.TabIndex = 43;
			this.Opt2Method.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Opt2Method.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt2Method.BackColor = System.Drawing.SystemColors.Control;
			this.Opt2Method.CausesValidation = true;
			this.Opt2Method.Enabled = true;
			this.Opt2Method.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Opt2Method.Cursor = System.Windows.Forms.Cursors.Default;
			this.Opt2Method.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Opt2Method.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Opt2Method.TabStop = true;
			this.Opt2Method.Checked = false;
			this.Opt2Method.Visible = true;
			this.Opt2Method.Name = "Opt2Method";
			this.Opt1Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt1Method.Text = "Method 1: Compare a field to a value or another field";
			this.Opt1Method.Size = new System.Drawing.Size(510, 25);
			this.Opt1Method.Location = new System.Drawing.Point(10, 19);
			this.Opt1Method.TabIndex = 42;
			this.Opt1Method.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Opt1Method.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt1Method.BackColor = System.Drawing.SystemColors.Control;
			this.Opt1Method.CausesValidation = true;
			this.Opt1Method.Enabled = true;
			this.Opt1Method.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Opt1Method.Cursor = System.Windows.Forms.Cursors.Default;
			this.Opt1Method.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Opt1Method.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Opt1Method.TabStop = true;
			this.Opt1Method.Checked = false;
			this.Opt1Method.Visible = true;
			this.Opt1Method.Name = "Opt1Method";
			this.Opt4Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt4Method.Text = "Method 4: Add or subtract a field to/from another field, and compare the result to a fix value";
			this.Opt4Method.Size = new System.Drawing.Size(564, 25);
			this.Opt4Method.Location = new System.Drawing.Point(10, 86);
			this.Opt4Method.TabIndex = 41;
			this.Opt4Method.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Opt4Method.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt4Method.BackColor = System.Drawing.SystemColors.Control;
			this.Opt4Method.CausesValidation = true;
			this.Opt4Method.Enabled = true;
			this.Opt4Method.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Opt4Method.Cursor = System.Windows.Forms.Cursors.Default;
			this.Opt4Method.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Opt4Method.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Opt4Method.TabStop = true;
			this.Opt4Method.Checked = false;
			this.Opt4Method.Visible = true;
			this.Opt4Method.Name = "Opt4Method";
			this.cboSet.Size = new System.Drawing.Size(92, 27);
			this.cboSet.Location = new System.Drawing.Point(730, 235);
			this.cboSet.Items.AddRange(new object[] {
				"And",
				"Or"
			});
			this.cboSet.TabIndex = 2;
			this.cboSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboSet.BackColor = System.Drawing.SystemColors.Window;
			this.cboSet.CausesValidation = true;
			this.cboSet.Enabled = true;
			this.cboSet.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboSet.IntegralHeight = true;
			this.cboSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboSet.Sorted = false;
			this.cboSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboSet.TabStop = true;
			this.cboSet.Visible = true;
			this.cboSet.Name = "cboSet";
			this.sstabOptions.Size = new System.Drawing.Size(525, 263);
			this.sstabOptions.Location = new System.Drawing.Point(740, 290);
			this.sstabOptions.TabIndex = 8;
			this.sstabOptions.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabOptions.Enabled = false;
			this.sstabOptions.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabOptions.Name = "sstabOptions";
			this._sstabOptions_TabPage0.Text = "Method 1";
			this.Label8.Text = "This Field";
			this.Label8.Size = new System.Drawing.Size(107, 18);
			this.Label8.Location = new System.Drawing.Point(112, 184);
			this.Label8.TabIndex = 27;
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
			this.Label5.Text = "OR";
			this.Label5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label5.Size = new System.Drawing.Size(28, 23);
			this.Label5.Location = new System.Drawing.Point(110, 160);
			this.Label5.TabIndex = 28;
			this.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this.Label4.Text = "OR";
			this.Label4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label4.Size = new System.Drawing.Size(28, 23);
			this.Label4.Location = new System.Drawing.Point(109, 112);
			this.Label4.TabIndex = 29;
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
			this.Label9.Text = "This Value";
			this.Label9.Size = new System.Drawing.Size(107, 18);
			this.Label9.Location = new System.Drawing.Point(110, 60);
			this.Label9.TabIndex = 31;
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
			this.Label6.Text = "Op.:";
			this.Label6.Size = new System.Drawing.Size(35, 18);
			this.Label6.Location = new System.Drawing.Point(44, 108);
			this.Label6.TabIndex = 32;
			this.Label6.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this.cboDestField.Size = new System.Drawing.Size(309, 27);
			this.cboDestField.Location = new System.Drawing.Point(112, 203);
			this.cboDestField.TabIndex = 7;
			this.cboDestField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboDestField.BackColor = System.Drawing.SystemColors.Window;
			this.cboDestField.CausesValidation = true;
			this.cboDestField.Enabled = true;
			this.cboDestField.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboDestField.IntegralHeight = true;
			this.cboDestField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboDestField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboDestField.Sorted = false;
			this.cboDestField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboDestField.TabStop = true;
			this.cboDestField.Visible = true;
			this.cboDestField.Name = "cboDestField";
			this.chkBlank.Text = " Blank";
			this.chkBlank.Size = new System.Drawing.Size(232, 29);
			this.chkBlank.Location = new System.Drawing.Point(112, 128);
			this.chkBlank.TabIndex = 6;
			this.chkBlank.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkBlank.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBlank.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkBlank.BackColor = System.Drawing.SystemColors.Control;
			this.chkBlank.CausesValidation = true;
			this.chkBlank.Enabled = true;
			this.chkBlank.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkBlank.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkBlank.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkBlank.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkBlank.TabStop = true;
			this.chkBlank.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkBlank.Visible = true;
			this.chkBlank.Name = "chkBlank";
			this.txtOpt1TypeinValue.AutoSize = false;
			this.txtOpt1TypeinValue.Size = new System.Drawing.Size(100, 24);
			this.txtOpt1TypeinValue.Location = new System.Drawing.Point(112, 82);
			this.txtOpt1TypeinValue.TabIndex = 5;
			this.txtOpt1TypeinValue.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtOpt1TypeinValue.AcceptsReturn = true;
			this.txtOpt1TypeinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtOpt1TypeinValue.BackColor = System.Drawing.SystemColors.Window;
			this.txtOpt1TypeinValue.CausesValidation = true;
			this.txtOpt1TypeinValue.Enabled = true;
			this.txtOpt1TypeinValue.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOpt1TypeinValue.HideSelection = true;
			this.txtOpt1TypeinValue.ReadOnly = false;
			this.txtOpt1TypeinValue.MaxLength = 0;
			this.txtOpt1TypeinValue.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtOpt1TypeinValue.Multiline = false;
			this.txtOpt1TypeinValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtOpt1TypeinValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOpt1TypeinValue.TabStop = true;
			this.txtOpt1TypeinValue.Visible = true;
			this.txtOpt1TypeinValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtOpt1TypeinValue.Name = "txtOpt1TypeinValue";
			this.cboOpt1ValueOperator.Size = new System.Drawing.Size(50, 27);
			this.cboOpt1ValueOperator.Location = new System.Drawing.Point(40, 130);
			this.cboOpt1ValueOperator.Items.AddRange(new object[] {
				"=",
				"<>",
				">",
				"<",
				">=",
				"<="
			});
			this.cboOpt1ValueOperator.TabIndex = 4;
			this.cboOpt1ValueOperator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboOpt1ValueOperator.BackColor = System.Drawing.SystemColors.Window;
			this.cboOpt1ValueOperator.CausesValidation = true;
			this.cboOpt1ValueOperator.Enabled = true;
			this.cboOpt1ValueOperator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOpt1ValueOperator.IntegralHeight = true;
			this.cboOpt1ValueOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboOpt1ValueOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboOpt1ValueOperator.Sorted = false;
			this.cboOpt1ValueOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboOpt1ValueOperator.TabStop = true;
			this.cboOpt1ValueOperator.Visible = true;
			this.cboOpt1ValueOperator.Name = "cboOpt1ValueOperator";
			this._sstabOptions_TabPage1.Text = "Method 2";
			this.cboOpt2ValueOperator.Size = new System.Drawing.Size(50, 27);
			this.cboOpt2ValueOperator.Location = new System.Drawing.Point(32, 138);
			this.cboOpt2ValueOperator.Items.AddRange(new object[] {
				"=",
				"<>",
				">",
				"<",
				">=",
				"<="
			});
			this.cboOpt2ValueOperator.TabIndex = 9;
			this.cboOpt2ValueOperator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboOpt2ValueOperator.BackColor = System.Drawing.SystemColors.Window;
			this.cboOpt2ValueOperator.CausesValidation = true;
			this.cboOpt2ValueOperator.Enabled = true;
			this.cboOpt2ValueOperator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOpt2ValueOperator.IntegralHeight = true;
			this.cboOpt2ValueOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboOpt2ValueOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboOpt2ValueOperator.Sorted = false;
			this.cboOpt2ValueOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboOpt2ValueOperator.TabStop = true;
			this.cboOpt2ValueOperator.Visible = true;
			this.cboOpt2ValueOperator.Name = "cboOpt2ValueOperator";
			this.cboLookupValues.Size = new System.Drawing.Size(393, 27);
			this.cboLookupValues.Location = new System.Drawing.Point(85, 138);
			this.cboLookupValues.TabIndex = 10;
			this.cboLookupValues.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboLookupValues.BackColor = System.Drawing.SystemColors.Window;
			this.cboLookupValues.CausesValidation = true;
			this.cboLookupValues.Enabled = true;
			this.cboLookupValues.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboLookupValues.IntegralHeight = true;
			this.cboLookupValues.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboLookupValues.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboLookupValues.Sorted = false;
			this.cboLookupValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboLookupValues.TabStop = true;
			this.cboLookupValues.Visible = true;
			this.cboLookupValues.Name = "cboLookupValues";
			this.Label10.Text = "Op.";
			this.Label10.Size = new System.Drawing.Size(35, 18);
			this.Label10.Location = new System.Drawing.Point(34, 117);
			this.Label10.TabIndex = 33;
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
			this.Label14.Text = "Lookup Values";
			this.Label14.Size = new System.Drawing.Size(157, 20);
			this.Label14.Location = new System.Drawing.Point(89, 118);
			this.Label14.TabIndex = 30;
			this.Label14.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label14.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this._sstabOptions_TabPage2.Text = "Method 3";
			this.cboLookupTables.Size = new System.Drawing.Size(364, 27);
			this.cboLookupTables.Location = new System.Drawing.Point(110, 130);
			this.cboLookupTables.TabIndex = 12;
			this.cboLookupTables.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboLookupTables.BackColor = System.Drawing.SystemColors.Window;
			this.cboLookupTables.CausesValidation = true;
			this.cboLookupTables.Enabled = true;
			this.cboLookupTables.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboLookupTables.IntegralHeight = true;
			this.cboLookupTables.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboLookupTables.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboLookupTables.Sorted = false;
			this.cboLookupTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboLookupTables.TabStop = true;
			this.cboLookupTables.Visible = true;
			this.cboLookupTables.Name = "cboLookupTables";
			this.cboOpLkTable.Size = new System.Drawing.Size(84, 27);
			this.cboOpLkTable.Location = new System.Drawing.Point(28, 130);
			this.cboOpLkTable.Items.AddRange(new object[] {
				"In",
				"Not In"
			});
			this.cboOpLkTable.TabIndex = 11;
			this.cboOpLkTable.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboOpLkTable.BackColor = System.Drawing.SystemColors.Window;
			this.cboOpLkTable.CausesValidation = true;
			this.cboOpLkTable.Enabled = true;
			this.cboOpLkTable.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOpLkTable.IntegralHeight = true;
			this.cboOpLkTable.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboOpLkTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboOpLkTable.Sorted = false;
			this.cboOpLkTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboOpLkTable.TabStop = true;
			this.cboOpLkTable.Visible = true;
			this.cboOpLkTable.Name = "cboOpLkTable";
			this.Label16.Text = "Lookup Table";
			this.Label16.Size = new System.Drawing.Size(157, 20);
			this.Label16.Location = new System.Drawing.Point(110, 108);
			this.Label16.TabIndex = 21;
			this.Label16.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label16.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label16.BackColor = System.Drawing.SystemColors.Control;
			this.Label16.Enabled = true;
			this.Label16.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label16.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label16.UseMnemonic = true;
			this.Label16.Visible = true;
			this.Label16.AutoSize = false;
			this.Label16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label16.Name = "Label16";
			this.Label17.Text = "Op.";
			this.Label17.Size = new System.Drawing.Size(35, 18);
			this.Label17.Location = new System.Drawing.Point(30, 109);
			this.Label17.TabIndex = 20;
			this.Label17.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label17.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label17.BackColor = System.Drawing.SystemColors.Control;
			this.Label17.Enabled = true;
			this.Label17.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label17.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label17.UseMnemonic = true;
			this.Label17.Visible = true;
			this.Label17.AutoSize = false;
			this.Label17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label17.Name = "Label17";
			this._sstabOptions_TabPage3.Text = "Method 4";
			this.cboOpt3Unit.Size = new System.Drawing.Size(68, 27);
			this.cboOpt3Unit.Location = new System.Drawing.Point(253, 177);
			this.cboOpt3Unit.Items.AddRange(new object[] {
				"Years",
				"Months",
				"Days",
				"Hours",
				"Minutes",
				"Seconds"
			});
			this.cboOpt3Unit.TabIndex = 17;
			this.cboOpt3Unit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboOpt3Unit.BackColor = System.Drawing.SystemColors.Window;
			this.cboOpt3Unit.CausesValidation = true;
			this.cboOpt3Unit.Enabled = true;
			this.cboOpt3Unit.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOpt3Unit.IntegralHeight = true;
			this.cboOpt3Unit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboOpt3Unit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboOpt3Unit.Sorted = false;
			this.cboOpt3Unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboOpt3Unit.TabStop = true;
			this.cboOpt3Unit.Visible = true;
			this.cboOpt3Unit.Name = "cboOpt3Unit";
			this.cboOpt3ValueOperator.Size = new System.Drawing.Size(50, 27);
			this.cboOpt3ValueOperator.Location = new System.Drawing.Point(39, 175);
			this.cboOpt3ValueOperator.Items.AddRange(new object[] {
				"=",
				"<>",
				">",
				"<",
				">=",
				"<="
			});
			this.cboOpt3ValueOperator.TabIndex = 15;
			this.cboOpt3ValueOperator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboOpt3ValueOperator.BackColor = System.Drawing.SystemColors.Window;
			this.cboOpt3ValueOperator.CausesValidation = true;
			this.cboOpt3ValueOperator.Enabled = true;
			this.cboOpt3ValueOperator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOpt3ValueOperator.IntegralHeight = true;
			this.cboOpt3ValueOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboOpt3ValueOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboOpt3ValueOperator.Sorted = false;
			this.cboOpt3ValueOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboOpt3ValueOperator.TabStop = true;
			this.cboOpt3ValueOperator.Visible = true;
			this.cboOpt3ValueOperator.Name = "cboOpt3ValueOperator";
			this.txtOpt3TypeinValue.AutoSize = false;
			this.txtOpt3TypeinValue.Size = new System.Drawing.Size(105, 27);
			this.txtOpt3TypeinValue.Location = new System.Drawing.Point(124, 178);
			this.txtOpt3TypeinValue.TabIndex = 16;
			this.txtOpt3TypeinValue.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtOpt3TypeinValue.AcceptsReturn = true;
			this.txtOpt3TypeinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtOpt3TypeinValue.BackColor = System.Drawing.SystemColors.Window;
			this.txtOpt3TypeinValue.CausesValidation = true;
			this.txtOpt3TypeinValue.Enabled = true;
			this.txtOpt3TypeinValue.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOpt3TypeinValue.HideSelection = true;
			this.txtOpt3TypeinValue.ReadOnly = false;
			this.txtOpt3TypeinValue.MaxLength = 0;
			this.txtOpt3TypeinValue.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtOpt3TypeinValue.Multiline = false;
			this.txtOpt3TypeinValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtOpt3TypeinValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOpt3TypeinValue.TabStop = true;
			this.txtOpt3TypeinValue.Visible = true;
			this.txtOpt3TypeinValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtOpt3TypeinValue.Name = "txtOpt3TypeinValue";
			this.cboFieldOperator.Size = new System.Drawing.Size(74, 27);
			this.cboFieldOperator.Location = new System.Drawing.Point(37, 115);
			this.cboFieldOperator.Items.AddRange(new object[] {
				"+",
				"-"
			});
			this.cboFieldOperator.TabIndex = 13;
			this.cboFieldOperator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboFieldOperator.BackColor = System.Drawing.SystemColors.Window;
			this.cboFieldOperator.CausesValidation = true;
			this.cboFieldOperator.Enabled = true;
			this.cboFieldOperator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboFieldOperator.IntegralHeight = true;
			this.cboFieldOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboFieldOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboFieldOperator.Sorted = false;
			this.cboFieldOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboFieldOperator.TabStop = true;
			this.cboFieldOperator.Visible = true;
			this.cboFieldOperator.Name = "cboFieldOperator";
			this.cboField2List.Size = new System.Drawing.Size(327, 27);
			this.cboField2List.Location = new System.Drawing.Point(119, 114);
			this.cboField2List.TabIndex = 14;
			this.cboField2List.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboField2List.BackColor = System.Drawing.SystemColors.Window;
			this.cboField2List.CausesValidation = true;
			this.cboField2List.Enabled = true;
			this.cboField2List.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboField2List.IntegralHeight = true;
			this.cboField2List.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboField2List.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboField2List.Sorted = false;
			this.cboField2List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboField2List.TabStop = true;
			this.cboField2List.Visible = true;
			this.cboField2List.Name = "cboField2List";
			this.Label15.Text = "Type in a Value";
			this.Label15.Size = new System.Drawing.Size(107, 18);
			this.Label15.Location = new System.Drawing.Point(122, 158);
			this.Label15.TabIndex = 26;
			this.Label15.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label15.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label15.BackColor = System.Drawing.SystemColors.Control;
			this.Label15.Enabled = true;
			this.Label15.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label15.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label15.UseMnemonic = true;
			this.Label15.Visible = true;
			this.Label15.AutoSize = false;
			this.Label15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label15.Name = "Label15";
			this.Label13.Text = "Op.:";
			this.Label13.Size = new System.Drawing.Size(35, 18);
			this.Label13.Location = new System.Drawing.Point(42, 154);
			this.Label13.TabIndex = 25;
			this.Label13.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label13.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this.Label11.Text = "Date/Time Unit (if the field is a date or time field)?";
			this.Label11.Size = new System.Drawing.Size(188, 32);
			this.Label11.Location = new System.Drawing.Point(253, 145);
			this.Label11.TabIndex = 24;
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
			this.Label2.Text = "Add/Subtract";
			this.Label2.Size = new System.Drawing.Size(82, 15);
			this.Label2.Location = new System.Drawing.Point(30, 98);
			this.Label2.TabIndex = 23;
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
			this.Label3.Text = "Second Field";
			this.Label3.Size = new System.Drawing.Size(203, 18);
			this.Label3.Location = new System.Drawing.Point(120, 95);
			this.Label3.TabIndex = 22;
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
			this._sstabOptions_TabPage4.Text = "Method 5";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "Del";
			this.cmdDelete.Size = new System.Drawing.Size(42, 22);
			this.cmdDelete.Location = new System.Drawing.Point(380, 145);
			this.cmdDelete.TabIndex = 52;
			this.cmdDelete.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelete.CausesValidation = true;
			this.cmdDelete.Enabled = true;
			this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelete.TabStop = true;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdAddVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddVal.Text = "Add";
			this.cmdAddVal.Size = new System.Drawing.Size(42, 22);
			this.cmdAddVal.Location = new System.Drawing.Point(380, 115);
			this.cmdAddVal.TabIndex = 51;
			this.cmdAddVal.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddVal.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddVal.CausesValidation = true;
			this.cmdAddVal.Enabled = true;
			this.cmdAddVal.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddVal.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddVal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddVal.TabStop = true;
			this.cmdAddVal.Name = "cmdAddVal";
			this.lstRange.Size = new System.Drawing.Size(142, 90);
			this.lstRange.Location = new System.Drawing.Point(230, 115);
			this.lstRange.TabIndex = 48;
			this.lstRange.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstRange.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstRange.BackColor = System.Drawing.SystemColors.Window;
			this.lstRange.CausesValidation = true;
			this.lstRange.Enabled = true;
			this.lstRange.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstRange.IntegralHeight = true;
			this.lstRange.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstRange.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstRange.Sorted = false;
			this.lstRange.TabStop = true;
			this.lstRange.Visible = true;
			this.lstRange.MultiColumn = false;
			this.lstRange.Name = "lstRange";
			this.cboOpt5ValueOperator.Size = new System.Drawing.Size(84, 27);
			this.cboOpt5ValueOperator.Location = new System.Drawing.Point(110, 115);
			this.cboOpt5ValueOperator.Items.AddRange(new object[] {
				"In",
				"Not In"
			});
			this.cboOpt5ValueOperator.TabIndex = 46;
			this.cboOpt5ValueOperator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboOpt5ValueOperator.BackColor = System.Drawing.SystemColors.Window;
			this.cboOpt5ValueOperator.CausesValidation = true;
			this.cboOpt5ValueOperator.Enabled = true;
			this.cboOpt5ValueOperator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOpt5ValueOperator.IntegralHeight = true;
			this.cboOpt5ValueOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboOpt5ValueOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboOpt5ValueOperator.Sorted = false;
			this.cboOpt5ValueOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboOpt5ValueOperator.TabStop = true;
			this.cboOpt5ValueOperator.Visible = true;
			this.cboOpt5ValueOperator.Name = "cboOpt5ValueOperator";
			this.Label19.Text = "Value(s):";
			this.Label19.Size = new System.Drawing.Size(132, 22);
			this.Label19.Location = new System.Drawing.Point(220, 95);
			this.Label19.TabIndex = 50;
			this.Label19.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label19.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label19.BackColor = System.Drawing.SystemColors.Control;
			this.Label19.Enabled = true;
			this.Label19.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label19.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label19.UseMnemonic = true;
			this.Label19.Visible = true;
			this.Label19.AutoSize = false;
			this.Label19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label19.Name = "Label19";
			this.Label18.Text = "Op.";
			this.Label18.Size = new System.Drawing.Size(35, 18);
			this.Label18.Location = new System.Drawing.Point(113, 99);
			this.Label18.TabIndex = 49;
			this.Label18.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label18.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label18.BackColor = System.Drawing.SystemColors.Control;
			this.Label18.Enabled = true;
			this.Label18.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label18.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label18.UseMnemonic = true;
			this.Label18.Visible = true;
			this.Label18.AutoSize = false;
			this.Label18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label18.Name = "Label18";
			this.Label12.Text = "Month is";
			this.Label12.Size = new System.Drawing.Size(62, 22);
			this.Label12.Location = new System.Drawing.Point(30, 120);
			this.Label12.TabIndex = 47;
			this.Label12.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label12.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this._sstabOptions_TabPage5.Text = "Method 6";
			this.cboOpt6ValueOperator.Size = new System.Drawing.Size(60, 27);
			this.cboOpt6ValueOperator.Location = new System.Drawing.Point(50, 120);
			this.cboOpt6ValueOperator.Items.AddRange(new object[] {
				"=",
				"<>"
			});
			this.cboOpt6ValueOperator.TabIndex = 55;
			this.cboOpt6ValueOperator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboOpt6ValueOperator.BackColor = System.Drawing.SystemColors.Window;
			this.cboOpt6ValueOperator.CausesValidation = true;
			this.cboOpt6ValueOperator.Enabled = true;
			this.cboOpt6ValueOperator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOpt6ValueOperator.IntegralHeight = true;
			this.cboOpt6ValueOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboOpt6ValueOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboOpt6ValueOperator.Sorted = false;
			this.cboOpt6ValueOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboOpt6ValueOperator.TabStop = true;
			this.cboOpt6ValueOperator.Visible = true;
			this.cboOpt6ValueOperator.Name = "cboOpt6ValueOperator";
			this.chkBlank6.Text = "Blank";
			this.chkBlank6.Size = new System.Drawing.Size(82, 22);
			this.chkBlank6.Location = new System.Drawing.Point(120, 120);
			this.chkBlank6.TabIndex = 54;
			this.chkBlank6.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkBlank6.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkBlank6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBlank6.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkBlank6.BackColor = System.Drawing.SystemColors.Control;
			this.chkBlank6.CausesValidation = true;
			this.chkBlank6.Enabled = true;
			this.chkBlank6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkBlank6.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkBlank6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkBlank6.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkBlank6.TabStop = true;
			this.chkBlank6.Visible = true;
			this.chkBlank6.Name = "chkBlank6";
			this.Line2.X1 = 200;
			this.Line2.X2 = 200;
			this.Line2.Y1 = 260;
			this.Line2.Y2 = 210;
			this.Line2.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Line2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.Line2.BorderWidth = 1;
			this.Line2.Visible = true;
			this.Line2.Name = "Line2";
			this.Label7.Text = "[OR]        Go To Step:";
			this.Label7.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label7.ForeColor = System.Drawing.Color.Blue;
			this.Label7.Size = new System.Drawing.Size(163, 18);
			this.Label7.Location = new System.Drawing.Point(470, 200);
			this.Label7.TabIndex = 56;
			this.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label7.BackColor = System.Drawing.SystemColors.Control;
			this.Label7.Enabled = true;
			this.Label7.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label7.UseMnemonic = true;
			this.Label7.Visible = true;
			this.Label7.AutoSize = false;
			this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label7.Name = "Label7";
			this.lblSet.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblSet.Text = "Set #:";
			this.lblSet.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblSet.ForeColor = System.Drawing.Color.Blue;
			this.lblSet.Size = new System.Drawing.Size(82, 22);
			this.lblSet.Location = new System.Drawing.Point(750, 200);
			this.lblSet.TabIndex = 40;
			this.lblSet.BackColor = System.Drawing.SystemColors.Control;
			this.lblSet.Enabled = true;
			this.lblSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblSet.UseMnemonic = true;
			this.lblSet.Visible = true;
			this.lblSet.AutoSize = false;
			this.lblSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblSet.Name = "lblSet";
			this.Line1.X1 = 690;
			this.Line1.X2 = 690;
			this.Line1.Y1 = 200;
			this.Line1.Y2 = 260;
			this.Line1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Line1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.Line1.BorderWidth = 1;
			this.Line1.Visible = true;
			this.Line1.Name = "Line1";
			this.lblCat.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblCat.Text = "Assign Category:";
			this.lblCat.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblCat.ForeColor = System.Drawing.Color.Blue;
			this.lblCat.Size = new System.Drawing.Size(172, 22);
			this.lblCat.Location = new System.Drawing.Point(260, 200);
			this.lblCat.TabIndex = 39;
			this.lblCat.BackColor = System.Drawing.SystemColors.Control;
			this.lblCat.Enabled = true;
			this.lblCat.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblCat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblCat.UseMnemonic = true;
			this.lblCat.Visible = true;
			this.lblCat.AutoSize = false;
			this.lblCat.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblCat.Name = "lblCat";
			this.lblColName.Text = "Set up Criteria";
			this.lblColName.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblColName.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.lblColName.Size = new System.Drawing.Size(797, 20);
			this.lblColName.Location = new System.Drawing.Point(2, 0);
			this.lblColName.TabIndex = 38;
			this.lblColName.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblColName.BackColor = System.Drawing.SystemColors.Control;
			this.lblColName.Enabled = true;
			this.lblColName.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblColName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblColName.UseMnemonic = true;
			this.lblColName.Visible = true;
			this.lblColName.AutoSize = false;
			this.lblColName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblColName.Name = "lblColName";
			this.lblJoinOperator.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblJoinOperator.Text = "Set Join Type:";
			this.lblJoinOperator.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblJoinOperator.ForeColor = System.Drawing.Color.Blue;
			this.lblJoinOperator.Size = new System.Drawing.Size(122, 22);
			this.lblJoinOperator.Location = new System.Drawing.Point(870, 200);
			this.lblJoinOperator.TabIndex = 37;
			this.lblJoinOperator.BackColor = System.Drawing.SystemColors.Control;
			this.lblJoinOperator.Enabled = true;
			this.lblJoinOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblJoinOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblJoinOperator.UseMnemonic = true;
			this.lblJoinOperator.Visible = true;
			this.lblJoinOperator.AutoSize = false;
			this.lblJoinOperator.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblJoinOperator.Name = "lblJoinOperator";
			this.lblNote.BackColor = System.Drawing.Color.Transparent;
			this.lblNote.Text = "Note: If you are defining the interval between 2 date fields, select the earliest date field from the above list";
			this.lblNote.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblNote.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.lblNote.Size = new System.Drawing.Size(214, 118);
			this.lblNote.Location = new System.Drawing.Point(602, 33);
			this.lblNote.TabIndex = 36;
			this.lblNote.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblNote.Enabled = true;
			this.lblNote.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblNote.UseMnemonic = true;
			this.lblNote.Visible = true;
			this.lblNote.AutoSize = false;
			this.lblNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblNote.Name = "lblNote";
			this.lblStep.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblStep.Text = "Step #:";
			this.lblStep.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblStep.ForeColor = System.Drawing.Color.Blue;
			this.lblStep.Size = new System.Drawing.Size(92, 22);
			this.lblStep.Location = new System.Drawing.Point(10, 200);
			this.lblStep.TabIndex = 35;
			this.lblStep.BackColor = System.Drawing.SystemColors.Control;
			this.lblStep.Enabled = true;
			this.lblStep.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblStep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblStep.UseMnemonic = true;
			this.lblStep.Visible = true;
			this.lblStep.AutoSize = false;
			this.lblStep.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStep.Name = "lblStep";
			this.Controls.Add(frmMultSel);
			this.Controls.Add(Frame1);
			this.Controls.Add(txtGoToStep);
			this.Controls.Add(cboStep);
			this.Controls.Add(cboCat);
			this.Controls.Add(cmdAdd);
			this.Controls.Add(cboJoinOperator);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(Frame2);
			this.Controls.Add(cboSet);
			this.Controls.Add(sstabOptions);
			this.ShapeContainer1.Shapes.Add(Line2);
			this.Controls.Add(Label7);
			this.Controls.Add(lblSet);
			this.ShapeContainer1.Shapes.Add(Line1);
			this.Controls.Add(lblCat);
			this.Controls.Add(lblColName);
			this.Controls.Add(lblJoinOperator);
			this.Controls.Add(lblNote);
			this.Controls.Add(lblStep);
			this.Controls.Add(ShapeContainer1);
			this.frmMultSel.Controls.Add(OptAll);
			this.frmMultSel.Controls.Add(OptMultAny);
			this.Frame1.Controls.Add(TabFirstField);
			this.Frame1.Controls.Add(Label1);
			this.TabFirstField.Controls.Add(_TabFirstField_TabPage0);
			this.TabFirstField.Controls.Add(_TabFirstField_TabPage1);
			this._TabFirstField_TabPage0.Controls.Add(lstFieldList);
			this._TabFirstField_TabPage1.Controls.Add(lstGroupList);
			this.Frame2.Controls.Add(Opt6Method);
			this.Frame2.Controls.Add(Opt5Method);
			this.Frame2.Controls.Add(Opt3Method);
			this.Frame2.Controls.Add(Opt2Method);
			this.Frame2.Controls.Add(Opt1Method);
			this.Frame2.Controls.Add(Opt4Method);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage0);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage1);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage2);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage3);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage4);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage5);
			this._sstabOptions_TabPage0.Controls.Add(Label8);
			this._sstabOptions_TabPage0.Controls.Add(Label5);
			this._sstabOptions_TabPage0.Controls.Add(Label4);
			this._sstabOptions_TabPage0.Controls.Add(Label9);
			this._sstabOptions_TabPage0.Controls.Add(Label6);
			this._sstabOptions_TabPage0.Controls.Add(cboDestField);
			this._sstabOptions_TabPage0.Controls.Add(chkBlank);
			this._sstabOptions_TabPage0.Controls.Add(txtOpt1TypeinValue);
			this._sstabOptions_TabPage0.Controls.Add(cboOpt1ValueOperator);
			this._sstabOptions_TabPage1.Controls.Add(cboOpt2ValueOperator);
			this._sstabOptions_TabPage1.Controls.Add(cboLookupValues);
			this._sstabOptions_TabPage1.Controls.Add(Label10);
			this._sstabOptions_TabPage1.Controls.Add(Label14);
			this._sstabOptions_TabPage2.Controls.Add(cboLookupTables);
			this._sstabOptions_TabPage2.Controls.Add(cboOpLkTable);
			this._sstabOptions_TabPage2.Controls.Add(Label16);
			this._sstabOptions_TabPage2.Controls.Add(Label17);
			this._sstabOptions_TabPage3.Controls.Add(cboOpt3Unit);
			this._sstabOptions_TabPage3.Controls.Add(cboOpt3ValueOperator);
			this._sstabOptions_TabPage3.Controls.Add(txtOpt3TypeinValue);
			this._sstabOptions_TabPage3.Controls.Add(cboFieldOperator);
			this._sstabOptions_TabPage3.Controls.Add(cboField2List);
			this._sstabOptions_TabPage3.Controls.Add(Label15);
			this._sstabOptions_TabPage3.Controls.Add(Label13);
			this._sstabOptions_TabPage3.Controls.Add(Label11);
			this._sstabOptions_TabPage3.Controls.Add(Label2);
			this._sstabOptions_TabPage3.Controls.Add(Label3);
			this._sstabOptions_TabPage4.Controls.Add(cmdDelete);
			this._sstabOptions_TabPage4.Controls.Add(cmdAddVal);
			this._sstabOptions_TabPage4.Controls.Add(lstRange);
			this._sstabOptions_TabPage4.Controls.Add(cboOpt5ValueOperator);
			this._sstabOptions_TabPage4.Controls.Add(Label19);
			this._sstabOptions_TabPage4.Controls.Add(Label18);
			this._sstabOptions_TabPage4.Controls.Add(Label12);
			this._sstabOptions_TabPage5.Controls.Add(cboOpt6ValueOperator);
			this._sstabOptions_TabPage5.Controls.Add(chkBlank6);
			this.frmMultSel.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.TabFirstField.ResumeLayout(false);
			this._TabFirstField_TabPage0.ResumeLayout(false);
			this._TabFirstField_TabPage1.ResumeLayout(false);
			this.Frame2.ResumeLayout(false);
			this.sstabOptions.ResumeLayout(false);
			this._sstabOptions_TabPage0.ResumeLayout(false);
			this._sstabOptions_TabPage1.ResumeLayout(false);
			this._sstabOptions_TabPage2.ResumeLayout(false);
			this._sstabOptions_TabPage3.ResumeLayout(false);
			this._sstabOptions_TabPage4.ResumeLayout(false);
			this._sstabOptions_TabPage5.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
