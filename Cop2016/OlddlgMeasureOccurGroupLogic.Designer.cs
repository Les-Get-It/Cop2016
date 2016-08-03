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
	partial class OlddlgMeasureOccurGroupLogic
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OlddlgMeasureOccurGroupLogic() : base()
		{
			Load += dlgMeasureOccurGroupLogic_Load;
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
		private System.Windows.Forms.RadioButton withEventsField_Opt7Method;
		public System.Windows.Forms.RadioButton Opt7Method {
			get { return withEventsField_Opt7Method; }
			set {
				if (withEventsField_Opt7Method != null) {
					withEventsField_Opt7Method.CheckedChanged -= Opt7Method_CheckedChanged;
				}
				withEventsField_Opt7Method = value;
				if (withEventsField_Opt7Method != null) {
					withEventsField_Opt7Method.CheckedChanged += Opt7Method_CheckedChanged;
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
		public System.Windows.Forms.CheckBox ChkProceed;
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
		public System.Windows.Forms.GroupBox Frame2;
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
		public System.Windows.Forms.ComboBox cboJoinOperator;
		private System.Windows.Forms.Button withEventsField_cmdSave;
		public System.Windows.Forms.Button cmdSave {
			get { return withEventsField_cmdSave; }
			set {
				if (withEventsField_cmdSave != null) {
					withEventsField_cmdSave.Click -= cmdSave_Click;
				}
				withEventsField_cmdSave = value;
				if (withEventsField_cmdSave != null) {
					withEventsField_cmdSave.Click += cmdSave_Click;
				}
			}
		}
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label _Label20_0;
		private System.Windows.Forms.ComboBox withEventsField_cboOpt1ValueOperator;
		public System.Windows.Forms.ComboBox cboOpt1ValueOperator {
			get { return withEventsField_cboOpt1ValueOperator; }
			set {
				if (withEventsField_cboOpt1ValueOperator != null) {
					withEventsField_cboOpt1ValueOperator.SelectedIndexChanged -= cboOpt1ValueOperator_SelectedIndexChanged;
				}
				withEventsField_cboOpt1ValueOperator = value;
				if (withEventsField_cboOpt1ValueOperator != null) {
					withEventsField_cboOpt1ValueOperator.SelectedIndexChanged += cboOpt1ValueOperator_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboDestField;
		public System.Windows.Forms.ComboBox cboDestGroupField;
		public System.Windows.Forms.TextBox txtOpt1IsBetweenMax;
		public System.Windows.Forms.TextBox txtOpt1TypeinValue;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label lblOpt1IsBetweenMax;
		public System.Windows.Forms.GroupBox Frame3;
		public System.Windows.Forms.CheckBox chkUTD;
		public System.Windows.Forms.CheckBox chkBlank;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.GroupBox Frame4;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage0;
		public System.Windows.Forms.ComboBox cboLookupValues;
		public System.Windows.Forms.ComboBox cboOpt2ValueOperator;
		public System.Windows.Forms.Label Label14;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage1;
		public System.Windows.Forms.ComboBox cboOpLkTable;
		public System.Windows.Forms.ComboBox cboLookupTables;
		public System.Windows.Forms.Label Label17;
		public System.Windows.Forms.Label Label16;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage2;
		public System.Windows.Forms.TextBox txtOpt4IsBetweenMax;
		public System.Windows.Forms.ComboBox cboField2GroupList;
		public System.Windows.Forms.ComboBox cboField2List;
		public System.Windows.Forms.ComboBox cboFieldOperator;
		public System.Windows.Forms.TextBox txtOpt3TypeinValue;
		private System.Windows.Forms.ComboBox withEventsField_cboOpt3ValueOperator;
		public System.Windows.Forms.ComboBox cboOpt3ValueOperator {
			get { return withEventsField_cboOpt3ValueOperator; }
			set {
				if (withEventsField_cboOpt3ValueOperator != null) {
					withEventsField_cboOpt3ValueOperator.SelectedIndexChanged -= cboOpt3ValueOperator_SelectedIndexChanged;
				}
				withEventsField_cboOpt3ValueOperator = value;
				if (withEventsField_cboOpt3ValueOperator != null) {
					withEventsField_cboOpt3ValueOperator.SelectedIndexChanged += cboOpt3ValueOperator_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboOpt3Unit;
		public System.Windows.Forms.Label lblOpt4IsBetweenMax;
		public System.Windows.Forms.Label Label22;
		public System.Windows.Forms.Label Label21;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label11;
		public System.Windows.Forms.Label Label13;
		public System.Windows.Forms.Label Label15;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage3;
		public System.Windows.Forms.ComboBox cboOpt5ValueOperator;
		public System.Windows.Forms.ListBox lstRange;
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
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.Label Label18;
		public System.Windows.Forms.Label Label19;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage4;
		private System.Windows.Forms.Button withEventsField_cmdDel6;
		public System.Windows.Forms.Button cmdDel6 {
			get { return withEventsField_cmdDel6; }
			set {
				if (withEventsField_cmdDel6 != null) {
					withEventsField_cmdDel6.Click -= cmdDel6_Click;
				}
				withEventsField_cmdDel6 = value;
				if (withEventsField_cmdDel6 != null) {
					withEventsField_cmdDel6.Click += cmdDel6_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAdd6;
		public System.Windows.Forms.Button cmdAdd6 {
			get { return withEventsField_cmdAdd6; }
			set {
				if (withEventsField_cmdAdd6 != null) {
					withEventsField_cmdAdd6.Click -= cmdAdd6_Click;
				}
				withEventsField_cmdAdd6 = value;
				if (withEventsField_cmdAdd6 != null) {
					withEventsField_cmdAdd6.Click += cmdAdd6_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lst6Range;
		public System.Windows.Forms.ComboBox cboOpt6ValueOperator;
		public System.Windows.Forms.Label Label24;
		public System.Windows.Forms.Label Label23;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage5;
		public System.Windows.Forms.Label Label25;
		public System.Windows.Forms.Label Label26;
		public System.Windows.Forms.CheckBox chkOpt7Blank;
		public System.Windows.Forms.ComboBox cboOpt7ValueOperator;
		public System.Windows.Forms.CheckBox chkMethod7UTD;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage6;
		public System.Windows.Forms.TabControl sstabOptions;
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
		private System.Windows.Forms.ListBox withEventsField_lstGroupList;
		public System.Windows.Forms.ListBox lstGroupList {
			get { return withEventsField_lstGroupList; }
			set {
				if (withEventsField_lstGroupList != null) {
					withEventsField_lstGroupList.SelectedIndexChanged -= lstGroupList_SelectedIndexChanged;
				}
				withEventsField_lstGroupList = value;
				if (withEventsField_lstGroupList != null) {
					withEventsField_lstGroupList.SelectedIndexChanged += lstGroupList_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.TabPage _TabFirstField_TabPage1;
		public System.Windows.Forms.TabControl TabFirstField;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.Label lblNote;
		public System.Windows.Forms.Label lblJoinOperator;
		public System.Windows.Forms.Label lblColName;
		public Microsoft.VisualBasic.Compatibility.VB6.LabelArray Label20;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OlddlgMeasureOccurGroupLogic));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this.Opt5Method = new System.Windows.Forms.RadioButton();
			this.Opt7Method = new System.Windows.Forms.RadioButton();
			this.Opt6Method = new System.Windows.Forms.RadioButton();
			this.ChkProceed = new System.Windows.Forms.CheckBox();
			this.Opt4Method = new System.Windows.Forms.RadioButton();
			this.Opt1Method = new System.Windows.Forms.RadioButton();
			this.Opt2Method = new System.Windows.Forms.RadioButton();
			this.Opt3Method = new System.Windows.Forms.RadioButton();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cboJoinOperator = new System.Windows.Forms.ComboBox();
			this.cmdSave = new System.Windows.Forms.Button();
			this.sstabOptions = new System.Windows.Forms.TabControl();
			this._sstabOptions_TabPage0 = new System.Windows.Forms.TabPage();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this._Label20_0 = new System.Windows.Forms.Label();
			this.cboOpt1ValueOperator = new System.Windows.Forms.ComboBox();
			this.cboDestField = new System.Windows.Forms.ComboBox();
			this.cboDestGroupField = new System.Windows.Forms.ComboBox();
			this.Frame3 = new System.Windows.Forms.GroupBox();
			this.txtOpt1IsBetweenMax = new System.Windows.Forms.TextBox();
			this.txtOpt1TypeinValue = new System.Windows.Forms.TextBox();
			this.Label9 = new System.Windows.Forms.Label();
			this.lblOpt1IsBetweenMax = new System.Windows.Forms.Label();
			this.Frame4 = new System.Windows.Forms.GroupBox();
			this.chkUTD = new System.Windows.Forms.CheckBox();
			this.chkBlank = new System.Windows.Forms.CheckBox();
			this.Label4 = new System.Windows.Forms.Label();
			this._sstabOptions_TabPage1 = new System.Windows.Forms.TabPage();
			this.cboLookupValues = new System.Windows.Forms.ComboBox();
			this.cboOpt2ValueOperator = new System.Windows.Forms.ComboBox();
			this.Label14 = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this._sstabOptions_TabPage2 = new System.Windows.Forms.TabPage();
			this.cboOpLkTable = new System.Windows.Forms.ComboBox();
			this.cboLookupTables = new System.Windows.Forms.ComboBox();
			this.Label17 = new System.Windows.Forms.Label();
			this.Label16 = new System.Windows.Forms.Label();
			this._sstabOptions_TabPage3 = new System.Windows.Forms.TabPage();
			this.txtOpt4IsBetweenMax = new System.Windows.Forms.TextBox();
			this.cboField2GroupList = new System.Windows.Forms.ComboBox();
			this.cboField2List = new System.Windows.Forms.ComboBox();
			this.cboFieldOperator = new System.Windows.Forms.ComboBox();
			this.txtOpt3TypeinValue = new System.Windows.Forms.TextBox();
			this.cboOpt3ValueOperator = new System.Windows.Forms.ComboBox();
			this.cboOpt3Unit = new System.Windows.Forms.ComboBox();
			this.lblOpt4IsBetweenMax = new System.Windows.Forms.Label();
			this.Label22 = new System.Windows.Forms.Label();
			this.Label21 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this.Label13 = new System.Windows.Forms.Label();
			this.Label15 = new System.Windows.Forms.Label();
			this._sstabOptions_TabPage4 = new System.Windows.Forms.TabPage();
			this.cboOpt5ValueOperator = new System.Windows.Forms.ComboBox();
			this.lstRange = new System.Windows.Forms.ListBox();
			this.cmdAddVal = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.Label12 = new System.Windows.Forms.Label();
			this.Label18 = new System.Windows.Forms.Label();
			this.Label19 = new System.Windows.Forms.Label();
			this._sstabOptions_TabPage5 = new System.Windows.Forms.TabPage();
			this.cmdDel6 = new System.Windows.Forms.Button();
			this.cmdAdd6 = new System.Windows.Forms.Button();
			this.lst6Range = new System.Windows.Forms.ListBox();
			this.cboOpt6ValueOperator = new System.Windows.Forms.ComboBox();
			this.Label24 = new System.Windows.Forms.Label();
			this.Label23 = new System.Windows.Forms.Label();
			this._sstabOptions_TabPage6 = new System.Windows.Forms.TabPage();
			this.Label25 = new System.Windows.Forms.Label();
			this.Label26 = new System.Windows.Forms.Label();
			this.chkOpt7Blank = new System.Windows.Forms.CheckBox();
			this.cboOpt7ValueOperator = new System.Windows.Forms.ComboBox();
			this.chkMethod7UTD = new System.Windows.Forms.CheckBox();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.TabFirstField = new System.Windows.Forms.TabControl();
			this._TabFirstField_TabPage0 = new System.Windows.Forms.TabPage();
			this.lstFieldList = new System.Windows.Forms.ListBox();
			this._TabFirstField_TabPage1 = new System.Windows.Forms.TabPage();
			this.lstGroupList = new System.Windows.Forms.ListBox();
			this.Label7 = new System.Windows.Forms.Label();
			this.lblNote = new System.Windows.Forms.Label();
			this.lblJoinOperator = new System.Windows.Forms.Label();
			this.lblColName = new System.Windows.Forms.Label();
			this.Label20 = new Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components);
			this.Frame2.SuspendLayout();
			this.sstabOptions.SuspendLayout();
			this._sstabOptions_TabPage0.SuspendLayout();
			this.Frame3.SuspendLayout();
			this.Frame4.SuspendLayout();
			this._sstabOptions_TabPage1.SuspendLayout();
			this._sstabOptions_TabPage2.SuspendLayout();
			this._sstabOptions_TabPage3.SuspendLayout();
			this._sstabOptions_TabPage4.SuspendLayout();
			this._sstabOptions_TabPage5.SuspendLayout();
			this._sstabOptions_TabPage6.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.TabFirstField.SuspendLayout();
			this._TabFirstField_TabPage0.SuspendLayout();
			this._TabFirstField_TabPage1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.Label20).BeginInit();
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Setup Multiple Occurrence Group Logic";
			this.ClientSize = new System.Drawing.Size(1022, 740);
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
			this.Name = "dlgMeasureOccurGroupLogic";
			this.Frame2.Text = "Select A Method";
			this.Frame2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame2.ForeColor = System.Drawing.Color.Blue;
			this.Frame2.Size = new System.Drawing.Size(594, 212);
			this.Frame2.Location = new System.Drawing.Point(0, 20);
			this.Frame2.TabIndex = 3;
			this.Frame2.BackColor = System.Drawing.SystemColors.Control;
			this.Frame2.Enabled = true;
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Visible = true;
			this.Frame2.Padding = new System.Windows.Forms.Padding(0);
			this.Frame2.Name = "Frame2";
			this.Opt5Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt5Method.Text = "Option1";
			this.Opt5Method.Size = new System.Drawing.Size(222, 17);
			this.Opt5Method.Location = new System.Drawing.Point(20, 110);
			this.Opt5Method.TabIndex = 67;
			this.Opt5Method.Visible = false;
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
			this.Opt5Method.Name = "Opt5Method";
			this.Opt7Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt7Method.Text = "Method 7: Find the Earliest Date/Time of a Group Date/Time Field";
			this.Opt7Method.Size = new System.Drawing.Size(564, 25);
			this.Opt7Method.Location = new System.Drawing.Point(10, 150);
			this.Opt7Method.TabIndex = 63;
			this.Opt7Method.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Opt7Method.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt7Method.BackColor = System.Drawing.SystemColors.Control;
			this.Opt7Method.CausesValidation = true;
			this.Opt7Method.Enabled = true;
			this.Opt7Method.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Opt7Method.Cursor = System.Windows.Forms.Cursors.Default;
			this.Opt7Method.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Opt7Method.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Opt7Method.TabStop = true;
			this.Opt7Method.Checked = false;
			this.Opt7Method.Visible = true;
			this.Opt7Method.Name = "Opt7Method";
			this.Opt6Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt6Method.Text = "Method 6: Compare a field to several values";
			this.Opt6Method.Size = new System.Drawing.Size(564, 25);
			this.Opt6Method.Location = new System.Drawing.Point(10, 129);
			this.Opt6Method.TabIndex = 54;
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
			this.ChkProceed.Text = "Only Proceed with Related Element Group Fields";
			this.ChkProceed.Size = new System.Drawing.Size(362, 27);
			this.ChkProceed.Location = new System.Drawing.Point(30, 180);
			this.ChkProceed.TabIndex = 42;
			this.ChkProceed.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkProceed.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.ChkProceed.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ChkProceed.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.ChkProceed.BackColor = System.Drawing.SystemColors.Control;
			this.ChkProceed.CausesValidation = true;
			this.ChkProceed.Enabled = true;
			this.ChkProceed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ChkProceed.Cursor = System.Windows.Forms.Cursors.Default;
			this.ChkProceed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ChkProceed.Appearance = System.Windows.Forms.Appearance.Normal;
			this.ChkProceed.TabStop = true;
			this.ChkProceed.Visible = true;
			this.ChkProceed.Name = "ChkProceed";
			this.Opt4Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt4Method.Text = "Method 4: Add or subtract a field to/from another field, and compare the result to a fix value";
			this.Opt4Method.Size = new System.Drawing.Size(564, 25);
			this.Opt4Method.Location = new System.Drawing.Point(10, 85);
			this.Opt4Method.TabIndex = 7;
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
			this.Opt1Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt1Method.Text = "Method 1: Compare a field to a value or another field";
			this.Opt1Method.Size = new System.Drawing.Size(564, 25);
			this.Opt1Method.Location = new System.Drawing.Point(10, 19);
			this.Opt1Method.TabIndex = 6;
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
			this.Opt2Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt2Method.Text = "Method 2: Compare a field to a value in a lookup table";
			this.Opt2Method.Size = new System.Drawing.Size(564, 25);
			this.Opt2Method.Location = new System.Drawing.Point(10, 41);
			this.Opt2Method.TabIndex = 5;
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
			this.Opt3Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt3Method.Text = "Method 3: Compare a field to every value of a lookup table";
			this.Opt3Method.Size = new System.Drawing.Size(564, 25);
			this.Opt3Method.Location = new System.Drawing.Point(10, 63);
			this.Opt3Method.TabIndex = 4;
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
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(80, 24);
			this.cmdCancel.Location = new System.Drawing.Point(770, 680);
			this.cmdCancel.TabIndex = 2;
			this.cmdCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.cboJoinOperator.Size = new System.Drawing.Size(72, 27);
			this.cboJoinOperator.Location = new System.Drawing.Point(70, 270);
			this.cboJoinOperator.Items.AddRange(new object[] {
				"AND",
				"OR"
			});
			this.cboJoinOperator.TabIndex = 1;
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
			this.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSave.Text = "Save Group Logic";
			this.cmdSave.Size = new System.Drawing.Size(130, 24);
			this.cmdSave.Location = new System.Drawing.Point(600, 680);
			this.cmdSave.TabIndex = 0;
			this.cmdSave.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdSave.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSave.CausesValidation = true;
			this.cmdSave.Enabled = true;
			this.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSave.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSave.TabStop = true;
			this.cmdSave.Name = "cmdSave";
			this.sstabOptions.Size = new System.Drawing.Size(495, 352);
			this.sstabOptions.Location = new System.Drawing.Point(500, 320);
			this.sstabOptions.TabIndex = 8;
			this.sstabOptions.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabOptions.Enabled = false;
			this.sstabOptions.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabOptions.Name = "sstabOptions";
			this._sstabOptions_TabPage0.Text = "Method 1";
			this.Label6.Text = "Op.:";
			this.Label6.Size = new System.Drawing.Size(35, 18);
			this.Label6.Location = new System.Drawing.Point(14, 78);
			this.Label6.TabIndex = 28;
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
			this.Label5.Text = "OR";
			this.Label5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label5.Size = new System.Drawing.Size(28, 23);
			this.Label5.Location = new System.Drawing.Point(10, 250);
			this.Label5.TabIndex = 30;
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
			this.Label8.Text = "This Field";
			this.Label8.Size = new System.Drawing.Size(67, 18);
			this.Label8.Location = new System.Drawing.Point(80, 250);
			this.Label8.TabIndex = 31;
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
			this.Label1.Text = "This Group Field";
			this.Label1.Size = new System.Drawing.Size(97, 18);
			this.Label1.Location = new System.Drawing.Point(40, 290);
			this.Label1.TabIndex = 49;
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
			this._Label20_0.Text = "OR";
			this._Label20_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._Label20_0.Size = new System.Drawing.Size(28, 23);
			this._Label20_0.Location = new System.Drawing.Point(10, 290);
			this._Label20_0.TabIndex = 50;
			this._Label20_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label20_0.BackColor = System.Drawing.SystemColors.Control;
			this._Label20_0.Enabled = true;
			this._Label20_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label20_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label20_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label20_0.UseMnemonic = true;
			this._Label20_0.Visible = true;
			this._Label20_0.AutoSize = false;
			this._Label20_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label20_0.Name = "_Label20_0";
			this.cboOpt1ValueOperator.Size = new System.Drawing.Size(110, 27);
			this.cboOpt1ValueOperator.Location = new System.Drawing.Point(10, 100);
			this.cboOpt1ValueOperator.Items.AddRange(new object[] {
				"=",
				"<>",
				">",
				"<",
				">=",
				"<=",
				"Is Between"
			});
			this.cboOpt1ValueOperator.TabIndex = 15;
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
			this.cboDestField.Size = new System.Drawing.Size(309, 27);
			this.cboDestField.Location = new System.Drawing.Point(150, 243);
			this.cboDestField.TabIndex = 16;
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
			this.cboDestGroupField.Size = new System.Drawing.Size(309, 27);
			this.cboDestGroupField.Location = new System.Drawing.Point(150, 280);
			this.cboDestGroupField.TabIndex = 48;
			this.cboDestGroupField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboDestGroupField.BackColor = System.Drawing.SystemColors.Window;
			this.cboDestGroupField.CausesValidation = true;
			this.cboDestGroupField.Enabled = true;
			this.cboDestGroupField.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboDestGroupField.IntegralHeight = true;
			this.cboDestGroupField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboDestGroupField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboDestGroupField.Sorted = false;
			this.cboDestGroupField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboDestGroupField.TabStop = true;
			this.cboDestGroupField.Visible = true;
			this.cboDestGroupField.Name = "cboDestGroupField";
			this.Frame3.Text = "Fixed Value / Between:";
			this.Frame3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame3.Size = new System.Drawing.Size(342, 102);
			this.Frame3.Location = new System.Drawing.Point(130, 60);
			this.Frame3.TabIndex = 68;
			this.Frame3.BackColor = System.Drawing.SystemColors.Control;
			this.Frame3.Enabled = true;
			this.Frame3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame3.Visible = true;
			this.Frame3.Padding = new System.Windows.Forms.Padding(0);
			this.Frame3.Name = "Frame3";
			this.txtOpt1IsBetweenMax.AutoSize = false;
			this.txtOpt1IsBetweenMax.Enabled = false;
			this.txtOpt1IsBetweenMax.Size = new System.Drawing.Size(100, 24);
			this.txtOpt1IsBetweenMax.Location = new System.Drawing.Point(210, 60);
			this.txtOpt1IsBetweenMax.TabIndex = 70;
			this.txtOpt1IsBetweenMax.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtOpt1IsBetweenMax.AcceptsReturn = true;
			this.txtOpt1IsBetweenMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtOpt1IsBetweenMax.BackColor = System.Drawing.SystemColors.Window;
			this.txtOpt1IsBetweenMax.CausesValidation = true;
			this.txtOpt1IsBetweenMax.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOpt1IsBetweenMax.HideSelection = true;
			this.txtOpt1IsBetweenMax.ReadOnly = false;
			this.txtOpt1IsBetweenMax.MaxLength = 0;
			this.txtOpt1IsBetweenMax.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtOpt1IsBetweenMax.Multiline = false;
			this.txtOpt1IsBetweenMax.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtOpt1IsBetweenMax.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOpt1IsBetweenMax.TabStop = true;
			this.txtOpt1IsBetweenMax.Visible = true;
			this.txtOpt1IsBetweenMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtOpt1IsBetweenMax.Name = "txtOpt1IsBetweenMax";
			this.txtOpt1TypeinValue.AutoSize = false;
			this.txtOpt1TypeinValue.Size = new System.Drawing.Size(100, 24);
			this.txtOpt1TypeinValue.Location = new System.Drawing.Point(90, 24);
			this.txtOpt1TypeinValue.TabIndex = 69;
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
			this.Label9.Text = "This Value";
			this.Label9.Size = new System.Drawing.Size(67, 18);
			this.Label9.Location = new System.Drawing.Point(10, 30);
			this.Label9.TabIndex = 72;
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
			this.lblOpt1IsBetweenMax.Text = "AND  Max Value";
			this.lblOpt1IsBetweenMax.Enabled = false;
			this.lblOpt1IsBetweenMax.Size = new System.Drawing.Size(117, 18);
			this.lblOpt1IsBetweenMax.Location = new System.Drawing.Point(210, 30);
			this.lblOpt1IsBetweenMax.TabIndex = 71;
			this.lblOpt1IsBetweenMax.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblOpt1IsBetweenMax.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblOpt1IsBetweenMax.BackColor = System.Drawing.SystemColors.Control;
			this.lblOpt1IsBetweenMax.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblOpt1IsBetweenMax.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblOpt1IsBetweenMax.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblOpt1IsBetweenMax.UseMnemonic = true;
			this.lblOpt1IsBetweenMax.Visible = true;
			this.lblOpt1IsBetweenMax.AutoSize = false;
			this.lblOpt1IsBetweenMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblOpt1IsBetweenMax.Name = "lblOpt1IsBetweenMax";
			this.Frame4.Text = "Fixed Checks";
			this.Frame4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame4.Size = new System.Drawing.Size(332, 62);
			this.Frame4.Location = new System.Drawing.Point(130, 170);
			this.Frame4.TabIndex = 73;
			this.Frame4.BackColor = System.Drawing.SystemColors.Control;
			this.Frame4.Enabled = true;
			this.Frame4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame4.Visible = true;
			this.Frame4.Padding = new System.Windows.Forms.Padding(0);
			this.Frame4.Name = "Frame4";
			this.chkUTD.Text = "UTD";
			this.chkUTD.Size = new System.Drawing.Size(112, 29);
			this.chkUTD.Location = new System.Drawing.Point(200, 20);
			this.chkUTD.TabIndex = 75;
			this.chkUTD.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkUTD.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			this.chkUTD.Visible = true;
			this.chkUTD.Name = "chkUTD";
			this.chkBlank.Text = " Blank";
			this.chkBlank.Size = new System.Drawing.Size(92, 29);
			this.chkBlank.Location = new System.Drawing.Point(40, 20);
			this.chkBlank.TabIndex = 74;
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
			this.Label4.Text = "OR";
			this.Label4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label4.Size = new System.Drawing.Size(48, 23);
			this.Label4.Location = new System.Drawing.Point(140, 27);
			this.Label4.TabIndex = 76;
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
			this._sstabOptions_TabPage1.Text = "Method 2";
			this.cboLookupValues.Size = new System.Drawing.Size(393, 27);
			this.cboLookupValues.Location = new System.Drawing.Point(85, 138);
			this.cboLookupValues.TabIndex = 14;
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
			this.cboOpt2ValueOperator.TabIndex = 13;
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
			this.Label14.Text = "Lookup Values";
			this.Label14.Size = new System.Drawing.Size(157, 20);
			this.Label14.Location = new System.Drawing.Point(89, 118);
			this.Label14.TabIndex = 29;
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
			this.Label10.Text = "Op.";
			this.Label10.Size = new System.Drawing.Size(35, 18);
			this.Label10.Location = new System.Drawing.Point(34, 117);
			this.Label10.TabIndex = 27;
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
			this._sstabOptions_TabPage2.Text = "Method 3";
			this.cboOpLkTable.Size = new System.Drawing.Size(84, 27);
			this.cboOpLkTable.Location = new System.Drawing.Point(28, 130);
			this.cboOpLkTable.Items.AddRange(new object[] {
				"In",
				"Not In"
			});
			this.cboOpLkTable.TabIndex = 23;
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
			this.cboLookupTables.Size = new System.Drawing.Size(364, 27);
			this.cboLookupTables.Location = new System.Drawing.Point(110, 130);
			this.cboLookupTables.TabIndex = 22;
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
			this.Label17.Text = "Op.";
			this.Label17.Size = new System.Drawing.Size(35, 18);
			this.Label17.Location = new System.Drawing.Point(30, 109);
			this.Label17.TabIndex = 38;
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
			this.Label16.Text = "Lookup Table";
			this.Label16.Size = new System.Drawing.Size(157, 20);
			this.Label16.Location = new System.Drawing.Point(110, 108);
			this.Label16.TabIndex = 37;
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
			this._sstabOptions_TabPage3.Text = "Method 4";
			this.txtOpt4IsBetweenMax.AutoSize = false;
			this.txtOpt4IsBetweenMax.Enabled = false;
			this.txtOpt4IsBetweenMax.Size = new System.Drawing.Size(105, 27);
			this.txtOpt4IsBetweenMax.Location = new System.Drawing.Point(123, 310);
			this.txtOpt4IsBetweenMax.TabIndex = 61;
			this.txtOpt4IsBetweenMax.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtOpt4IsBetweenMax.AcceptsReturn = true;
			this.txtOpt4IsBetweenMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtOpt4IsBetweenMax.BackColor = System.Drawing.SystemColors.Window;
			this.txtOpt4IsBetweenMax.CausesValidation = true;
			this.txtOpt4IsBetweenMax.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOpt4IsBetweenMax.HideSelection = true;
			this.txtOpt4IsBetweenMax.ReadOnly = false;
			this.txtOpt4IsBetweenMax.MaxLength = 0;
			this.txtOpt4IsBetweenMax.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtOpt4IsBetweenMax.Multiline = false;
			this.txtOpt4IsBetweenMax.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtOpt4IsBetweenMax.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOpt4IsBetweenMax.TabStop = true;
			this.txtOpt4IsBetweenMax.Visible = true;
			this.txtOpt4IsBetweenMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtOpt4IsBetweenMax.Name = "txtOpt4IsBetweenMax";
			this.cboField2GroupList.Size = new System.Drawing.Size(327, 27);
			this.cboField2GroupList.Location = new System.Drawing.Point(130, 189);
			this.cboField2GroupList.TabIndex = 51;
			this.cboField2GroupList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboField2GroupList.BackColor = System.Drawing.SystemColors.Window;
			this.cboField2GroupList.CausesValidation = true;
			this.cboField2GroupList.Enabled = true;
			this.cboField2GroupList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboField2GroupList.IntegralHeight = true;
			this.cboField2GroupList.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboField2GroupList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboField2GroupList.Sorted = false;
			this.cboField2GroupList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboField2GroupList.TabStop = true;
			this.cboField2GroupList.Visible = true;
			this.cboField2GroupList.Name = "cboField2GroupList";
			this.cboField2List.Size = new System.Drawing.Size(327, 27);
			this.cboField2List.Location = new System.Drawing.Point(129, 104);
			this.cboField2List.TabIndex = 21;
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
			this.cboFieldOperator.Size = new System.Drawing.Size(74, 27);
			this.cboFieldOperator.Location = new System.Drawing.Point(27, 135);
			this.cboFieldOperator.Items.AddRange(new object[] {
				"+",
				"-"
			});
			this.cboFieldOperator.TabIndex = 20;
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
			this.txtOpt3TypeinValue.AutoSize = false;
			this.txtOpt3TypeinValue.Size = new System.Drawing.Size(105, 27);
			this.txtOpt3TypeinValue.Location = new System.Drawing.Point(124, 248);
			this.txtOpt3TypeinValue.TabIndex = 19;
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
			this.cboOpt3ValueOperator.Size = new System.Drawing.Size(103, 27);
			this.cboOpt3ValueOperator.Location = new System.Drawing.Point(9, 245);
			this.cboOpt3ValueOperator.Items.AddRange(new object[] {
				"=",
				"<>",
				">",
				"<",
				">=",
				"<=",
				"Is Between"
			});
			this.cboOpt3ValueOperator.TabIndex = 18;
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
			this.cboOpt3Unit.Size = new System.Drawing.Size(68, 27);
			this.cboOpt3Unit.Location = new System.Drawing.Point(283, 267);
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
			this.lblOpt4IsBetweenMax.Text = "AND   Max Value";
			this.lblOpt4IsBetweenMax.Enabled = false;
			this.lblOpt4IsBetweenMax.Size = new System.Drawing.Size(107, 18);
			this.lblOpt4IsBetweenMax.Location = new System.Drawing.Point(120, 290);
			this.lblOpt4IsBetweenMax.TabIndex = 62;
			this.lblOpt4IsBetweenMax.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblOpt4IsBetweenMax.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblOpt4IsBetweenMax.BackColor = System.Drawing.SystemColors.Control;
			this.lblOpt4IsBetweenMax.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblOpt4IsBetweenMax.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblOpt4IsBetweenMax.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblOpt4IsBetweenMax.UseMnemonic = true;
			this.lblOpt4IsBetweenMax.Visible = true;
			this.lblOpt4IsBetweenMax.AutoSize = false;
			this.lblOpt4IsBetweenMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblOpt4IsBetweenMax.Name = "lblOpt4IsBetweenMax";
			this.Label22.Text = "OR";
			this.Label22.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label22.Size = new System.Drawing.Size(28, 23);
			this.Label22.Location = new System.Drawing.Point(130, 140);
			this.Label22.TabIndex = 53;
			this.Label22.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label22.BackColor = System.Drawing.SystemColors.Control;
			this.Label22.Enabled = true;
			this.Label22.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label22.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label22.UseMnemonic = true;
			this.Label22.Visible = true;
			this.Label22.AutoSize = false;
			this.Label22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label22.Name = "Label22";
			this.Label21.Text = "Second Group Field";
			this.Label21.Size = new System.Drawing.Size(203, 18);
			this.Label21.Location = new System.Drawing.Point(132, 170);
			this.Label21.TabIndex = 52;
			this.Label21.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label21.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label21.BackColor = System.Drawing.SystemColors.Control;
			this.Label21.Enabled = true;
			this.Label21.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label21.UseMnemonic = true;
			this.Label21.Visible = true;
			this.Label21.AutoSize = false;
			this.Label21.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label21.Name = "Label21";
			this.Label3.Text = "Second Field";
			this.Label3.Size = new System.Drawing.Size(203, 18);
			this.Label3.Location = new System.Drawing.Point(130, 85);
			this.Label3.TabIndex = 36;
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
			this.Label2.Text = "Add/Subtract";
			this.Label2.Size = new System.Drawing.Size(82, 15);
			this.Label2.Location = new System.Drawing.Point(20, 118);
			this.Label2.TabIndex = 35;
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
			this.Label11.Text = "Date/Time Unit (if the field is a date or time field)?";
			this.Label11.Size = new System.Drawing.Size(188, 32);
			this.Label11.Location = new System.Drawing.Point(283, 235);
			this.Label11.TabIndex = 34;
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
			this.Label13.Text = "Op.:";
			this.Label13.Size = new System.Drawing.Size(35, 18);
			this.Label13.Location = new System.Drawing.Point(12, 224);
			this.Label13.TabIndex = 33;
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
			this.Label15.Text = "Type in a Value";
			this.Label15.Size = new System.Drawing.Size(107, 18);
			this.Label15.Location = new System.Drawing.Point(122, 228);
			this.Label15.TabIndex = 32;
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
			this._sstabOptions_TabPage4.Text = "Method 5";
			this.cboOpt5ValueOperator.Size = new System.Drawing.Size(84, 27);
			this.cboOpt5ValueOperator.Location = new System.Drawing.Point(110, 115);
			this.cboOpt5ValueOperator.Items.AddRange(new object[] {
				"In",
				"Not In"
			});
			this.cboOpt5ValueOperator.TabIndex = 12;
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
			this.lstRange.Size = new System.Drawing.Size(142, 90);
			this.lstRange.Location = new System.Drawing.Point(230, 115);
			this.lstRange.TabIndex = 11;
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
			this.cmdAddVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddVal.Text = "Add";
			this.cmdAddVal.Size = new System.Drawing.Size(42, 22);
			this.cmdAddVal.Location = new System.Drawing.Point(380, 115);
			this.cmdAddVal.TabIndex = 10;
			this.cmdAddVal.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddVal.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddVal.CausesValidation = true;
			this.cmdAddVal.Enabled = true;
			this.cmdAddVal.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddVal.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddVal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddVal.TabStop = true;
			this.cmdAddVal.Name = "cmdAddVal";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "Del";
			this.cmdDelete.Size = new System.Drawing.Size(42, 22);
			this.cmdDelete.Location = new System.Drawing.Point(380, 145);
			this.cmdDelete.TabIndex = 9;
			this.cmdDelete.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelete.CausesValidation = true;
			this.cmdDelete.Enabled = true;
			this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelete.TabStop = true;
			this.cmdDelete.Name = "cmdDelete";
			this.Label12.Text = "Month is";
			this.Label12.Size = new System.Drawing.Size(62, 22);
			this.Label12.Location = new System.Drawing.Point(30, 120);
			this.Label12.TabIndex = 26;
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
			this.Label18.Text = "Op.";
			this.Label18.Size = new System.Drawing.Size(35, 18);
			this.Label18.Location = new System.Drawing.Point(113, 90);
			this.Label18.TabIndex = 25;
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
			this.Label19.Text = "Value(s):";
			this.Label19.Size = new System.Drawing.Size(132, 22);
			this.Label19.Location = new System.Drawing.Point(220, 95);
			this.Label19.TabIndex = 24;
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
			this._sstabOptions_TabPage5.Text = "Method 6";
			this.cmdDel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDel6.Text = "Del";
			this.cmdDel6.Size = new System.Drawing.Size(42, 22);
			this.cmdDel6.Location = new System.Drawing.Point(360, 185);
			this.cmdDel6.TabIndex = 58;
			this.cmdDel6.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDel6.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDel6.CausesValidation = true;
			this.cmdDel6.Enabled = true;
			this.cmdDel6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDel6.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDel6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDel6.TabStop = true;
			this.cmdDel6.Name = "cmdDel6";
			this.cmdAdd6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAdd6.Text = "Add";
			this.cmdAdd6.Size = new System.Drawing.Size(42, 22);
			this.cmdAdd6.Location = new System.Drawing.Point(360, 155);
			this.cmdAdd6.TabIndex = 57;
			this.cmdAdd6.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAdd6.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdd6.CausesValidation = true;
			this.cmdAdd6.Enabled = true;
			this.cmdAdd6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdd6.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAdd6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdd6.TabStop = true;
			this.cmdAdd6.Name = "cmdAdd6";
			this.lst6Range.Size = new System.Drawing.Size(142, 90);
			this.lst6Range.Location = new System.Drawing.Point(210, 155);
			this.lst6Range.TabIndex = 56;
			this.lst6Range.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lst6Range.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lst6Range.BackColor = System.Drawing.SystemColors.Window;
			this.lst6Range.CausesValidation = true;
			this.lst6Range.Enabled = true;
			this.lst6Range.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lst6Range.IntegralHeight = true;
			this.lst6Range.Cursor = System.Windows.Forms.Cursors.Default;
			this.lst6Range.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lst6Range.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lst6Range.Sorted = false;
			this.lst6Range.TabStop = true;
			this.lst6Range.Visible = true;
			this.lst6Range.MultiColumn = false;
			this.lst6Range.Name = "lst6Range";
			this.cboOpt6ValueOperator.Size = new System.Drawing.Size(84, 27);
			this.cboOpt6ValueOperator.Location = new System.Drawing.Point(90, 155);
			this.cboOpt6ValueOperator.Items.AddRange(new object[] {
				"In",
				"Not In"
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
			this.Label24.Text = "Value(s):";
			this.Label24.Size = new System.Drawing.Size(132, 22);
			this.Label24.Location = new System.Drawing.Point(200, 135);
			this.Label24.TabIndex = 60;
			this.Label24.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label24.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label24.BackColor = System.Drawing.SystemColors.Control;
			this.Label24.Enabled = true;
			this.Label24.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label24.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label24.UseMnemonic = true;
			this.Label24.Visible = true;
			this.Label24.AutoSize = false;
			this.Label24.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label24.Name = "Label24";
			this.Label23.Text = "Op.";
			this.Label23.Size = new System.Drawing.Size(35, 18);
			this.Label23.Location = new System.Drawing.Point(93, 130);
			this.Label23.TabIndex = 59;
			this.Label23.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label23.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label23.BackColor = System.Drawing.SystemColors.Control;
			this.Label23.Enabled = true;
			this.Label23.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label23.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label23.UseMnemonic = true;
			this.Label23.Visible = true;
			this.Label23.AutoSize = false;
			this.Label23.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label23.Name = "Label23";
			this._sstabOptions_TabPage6.Text = "Method 7";
			this.Label25.Text = "Op.:";
			this.Label25.Size = new System.Drawing.Size(35, 18);
			this.Label25.Location = new System.Drawing.Point(54, 160);
			this.Label25.TabIndex = 66;
			this.Label25.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label25.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label25.BackColor = System.Drawing.SystemColors.Control;
			this.Label25.Enabled = true;
			this.Label25.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label25.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label25.UseMnemonic = true;
			this.Label25.Visible = true;
			this.Label25.AutoSize = false;
			this.Label25.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label25.Name = "Label25";
			this.Label26.Text = "OR";
			this.Label26.Size = new System.Drawing.Size(132, 22);
			this.Label26.Location = new System.Drawing.Point(220, 180);
			this.Label26.TabIndex = 77;
			this.Label26.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label26.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label26.BackColor = System.Drawing.SystemColors.Control;
			this.Label26.Enabled = true;
			this.Label26.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label26.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label26.UseMnemonic = true;
			this.Label26.Visible = true;
			this.Label26.AutoSize = false;
			this.Label26.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label26.Name = "Label26";
			this.chkOpt7Blank.Text = " Blank";
			this.chkOpt7Blank.Size = new System.Drawing.Size(232, 27);
			this.chkOpt7Blank.Location = new System.Drawing.Point(190, 140);
			this.chkOpt7Blank.TabIndex = 64;
			this.chkOpt7Blank.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkOpt7Blank.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkOpt7Blank.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkOpt7Blank.BackColor = System.Drawing.SystemColors.Control;
			this.chkOpt7Blank.CausesValidation = true;
			this.chkOpt7Blank.Enabled = true;
			this.chkOpt7Blank.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkOpt7Blank.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkOpt7Blank.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkOpt7Blank.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkOpt7Blank.TabStop = true;
			this.chkOpt7Blank.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkOpt7Blank.Visible = true;
			this.chkOpt7Blank.Name = "chkOpt7Blank";
			this.cboOpt7ValueOperator.Size = new System.Drawing.Size(110, 27);
			this.cboOpt7ValueOperator.Location = new System.Drawing.Point(50, 183);
			this.cboOpt7ValueOperator.Items.AddRange(new object[] {
				"=",
				"<>"
			});
			this.cboOpt7ValueOperator.TabIndex = 65;
			this.cboOpt7ValueOperator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboOpt7ValueOperator.BackColor = System.Drawing.SystemColors.Window;
			this.cboOpt7ValueOperator.CausesValidation = true;
			this.cboOpt7ValueOperator.Enabled = true;
			this.cboOpt7ValueOperator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOpt7ValueOperator.IntegralHeight = true;
			this.cboOpt7ValueOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboOpt7ValueOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboOpt7ValueOperator.Sorted = false;
			this.cboOpt7ValueOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboOpt7ValueOperator.TabStop = true;
			this.cboOpt7ValueOperator.Visible = true;
			this.cboOpt7ValueOperator.Name = "cboOpt7ValueOperator";
			this.chkMethod7UTD.Text = "UTD";
			this.chkMethod7UTD.Size = new System.Drawing.Size(232, 27);
			this.chkMethod7UTD.Location = new System.Drawing.Point(190, 210);
			this.chkMethod7UTD.TabIndex = 78;
			this.chkMethod7UTD.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkMethod7UTD.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkMethod7UTD.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkMethod7UTD.BackColor = System.Drawing.SystemColors.Control;
			this.chkMethod7UTD.CausesValidation = true;
			this.chkMethod7UTD.Enabled = true;
			this.chkMethod7UTD.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkMethod7UTD.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkMethod7UTD.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkMethod7UTD.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkMethod7UTD.TabStop = true;
			this.chkMethod7UTD.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkMethod7UTD.Visible = true;
			this.chkMethod7UTD.Name = "chkMethod7UTD";
			this.Frame1.Size = new System.Drawing.Size(472, 422);
			this.Frame1.Location = new System.Drawing.Point(0, 310);
			this.Frame1.TabIndex = 43;
			this.Frame1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.TabFirstField.Size = new System.Drawing.Size(452, 372);
			this.TabFirstField.Location = new System.Drawing.Point(10, 30);
			this.TabFirstField.TabIndex = 44;
			this.TabFirstField.SelectedIndex = 1;
			this.TabFirstField.ItemSize = new System.Drawing.Size(42, 22);
			this.TabFirstField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.TabFirstField.Name = "TabFirstField";
			this._TabFirstField_TabPage0.Text = "Patient Field";
			this.lstFieldList.Size = new System.Drawing.Size(427, 318);
			this.lstFieldList.Location = new System.Drawing.Point(10, 40);
			this.lstFieldList.TabIndex = 46;
			this.lstFieldList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstFieldList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstFieldList.BackColor = System.Drawing.SystemColors.Window;
			this.lstFieldList.CausesValidation = true;
			this.lstFieldList.Enabled = true;
			this.lstFieldList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstFieldList.IntegralHeight = true;
			this.lstFieldList.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstFieldList.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstFieldList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstFieldList.Sorted = false;
			this.lstFieldList.TabStop = true;
			this.lstFieldList.Visible = true;
			this.lstFieldList.MultiColumn = false;
			this.lstFieldList.Name = "lstFieldList";
			this._TabFirstField_TabPage1.Text = "Group Field";
			this.lstGroupList.Size = new System.Drawing.Size(427, 318);
			this.lstGroupList.Location = new System.Drawing.Point(17, 40);
			this.lstGroupList.TabIndex = 45;
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
			this.Label7.Text = "Select FIRST Field";
			this.Label7.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label7.ForeColor = System.Drawing.Color.Blue;
			this.Label7.Size = new System.Drawing.Size(287, 17);
			this.Label7.Location = new System.Drawing.Point(10, 0);
			this.Label7.TabIndex = 47;
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
			this.lblNote.BackColor = System.Drawing.Color.Transparent;
			this.lblNote.Text = "Note: If you are defining the interval between 2 date fields, select the earliest date field from the above list";
			this.lblNote.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblNote.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.lblNote.Size = new System.Drawing.Size(214, 118);
			this.lblNote.Location = new System.Drawing.Point(602, 33);
			this.lblNote.TabIndex = 41;
			this.lblNote.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblNote.Enabled = true;
			this.lblNote.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblNote.UseMnemonic = true;
			this.lblNote.Visible = true;
			this.lblNote.AutoSize = false;
			this.lblNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblNote.Name = "lblNote";
			this.lblJoinOperator.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblJoinOperator.Text = "Set Join Type:";
			this.lblJoinOperator.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblJoinOperator.ForeColor = System.Drawing.Color.Blue;
			this.lblJoinOperator.Size = new System.Drawing.Size(122, 22);
			this.lblJoinOperator.Location = new System.Drawing.Point(20, 250);
			this.lblJoinOperator.TabIndex = 40;
			this.lblJoinOperator.BackColor = System.Drawing.SystemColors.Control;
			this.lblJoinOperator.Enabled = true;
			this.lblJoinOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblJoinOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblJoinOperator.UseMnemonic = true;
			this.lblJoinOperator.Visible = true;
			this.lblJoinOperator.AutoSize = false;
			this.lblJoinOperator.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblJoinOperator.Name = "lblJoinOperator";
			this.lblColName.Text = "Set up Criteria";
			this.lblColName.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblColName.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.lblColName.Size = new System.Drawing.Size(797, 20);
			this.lblColName.Location = new System.Drawing.Point(2, 0);
			this.lblColName.TabIndex = 39;
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
			this.Controls.Add(Frame2);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cboJoinOperator);
			this.Controls.Add(cmdSave);
			this.Controls.Add(sstabOptions);
			this.Controls.Add(Frame1);
			this.Controls.Add(lblNote);
			this.Controls.Add(lblJoinOperator);
			this.Controls.Add(lblColName);
			this.Frame2.Controls.Add(Opt5Method);
			this.Frame2.Controls.Add(Opt7Method);
			this.Frame2.Controls.Add(Opt6Method);
			this.Frame2.Controls.Add(ChkProceed);
			this.Frame2.Controls.Add(Opt4Method);
			this.Frame2.Controls.Add(Opt1Method);
			this.Frame2.Controls.Add(Opt2Method);
			this.Frame2.Controls.Add(Opt3Method);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage0);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage1);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage2);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage3);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage4);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage5);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage6);
			this._sstabOptions_TabPage0.Controls.Add(Label6);
			this._sstabOptions_TabPage0.Controls.Add(Label5);
			this._sstabOptions_TabPage0.Controls.Add(Label8);
			this._sstabOptions_TabPage0.Controls.Add(Label1);
			this._sstabOptions_TabPage0.Controls.Add(_Label20_0);
			this._sstabOptions_TabPage0.Controls.Add(cboOpt1ValueOperator);
			this._sstabOptions_TabPage0.Controls.Add(cboDestField);
			this._sstabOptions_TabPage0.Controls.Add(cboDestGroupField);
			this._sstabOptions_TabPage0.Controls.Add(Frame3);
			this._sstabOptions_TabPage0.Controls.Add(Frame4);
			this.Frame3.Controls.Add(txtOpt1IsBetweenMax);
			this.Frame3.Controls.Add(txtOpt1TypeinValue);
			this.Frame3.Controls.Add(Label9);
			this.Frame3.Controls.Add(lblOpt1IsBetweenMax);
			this.Frame4.Controls.Add(chkUTD);
			this.Frame4.Controls.Add(chkBlank);
			this.Frame4.Controls.Add(Label4);
			this._sstabOptions_TabPage1.Controls.Add(cboLookupValues);
			this._sstabOptions_TabPage1.Controls.Add(cboOpt2ValueOperator);
			this._sstabOptions_TabPage1.Controls.Add(Label14);
			this._sstabOptions_TabPage1.Controls.Add(Label10);
			this._sstabOptions_TabPage2.Controls.Add(cboOpLkTable);
			this._sstabOptions_TabPage2.Controls.Add(cboLookupTables);
			this._sstabOptions_TabPage2.Controls.Add(Label17);
			this._sstabOptions_TabPage2.Controls.Add(Label16);
			this._sstabOptions_TabPage3.Controls.Add(txtOpt4IsBetweenMax);
			this._sstabOptions_TabPage3.Controls.Add(cboField2GroupList);
			this._sstabOptions_TabPage3.Controls.Add(cboField2List);
			this._sstabOptions_TabPage3.Controls.Add(cboFieldOperator);
			this._sstabOptions_TabPage3.Controls.Add(txtOpt3TypeinValue);
			this._sstabOptions_TabPage3.Controls.Add(cboOpt3ValueOperator);
			this._sstabOptions_TabPage3.Controls.Add(cboOpt3Unit);
			this._sstabOptions_TabPage3.Controls.Add(lblOpt4IsBetweenMax);
			this._sstabOptions_TabPage3.Controls.Add(Label22);
			this._sstabOptions_TabPage3.Controls.Add(Label21);
			this._sstabOptions_TabPage3.Controls.Add(Label3);
			this._sstabOptions_TabPage3.Controls.Add(Label2);
			this._sstabOptions_TabPage3.Controls.Add(Label11);
			this._sstabOptions_TabPage3.Controls.Add(Label13);
			this._sstabOptions_TabPage3.Controls.Add(Label15);
			this._sstabOptions_TabPage4.Controls.Add(cboOpt5ValueOperator);
			this._sstabOptions_TabPage4.Controls.Add(lstRange);
			this._sstabOptions_TabPage4.Controls.Add(cmdAddVal);
			this._sstabOptions_TabPage4.Controls.Add(cmdDelete);
			this._sstabOptions_TabPage4.Controls.Add(Label12);
			this._sstabOptions_TabPage4.Controls.Add(Label18);
			this._sstabOptions_TabPage4.Controls.Add(Label19);
			this._sstabOptions_TabPage5.Controls.Add(cmdDel6);
			this._sstabOptions_TabPage5.Controls.Add(cmdAdd6);
			this._sstabOptions_TabPage5.Controls.Add(lst6Range);
			this._sstabOptions_TabPage5.Controls.Add(cboOpt6ValueOperator);
			this._sstabOptions_TabPage5.Controls.Add(Label24);
			this._sstabOptions_TabPage5.Controls.Add(Label23);
			this._sstabOptions_TabPage6.Controls.Add(Label25);
			this._sstabOptions_TabPage6.Controls.Add(Label26);
			this._sstabOptions_TabPage6.Controls.Add(chkOpt7Blank);
			this._sstabOptions_TabPage6.Controls.Add(cboOpt7ValueOperator);
			this._sstabOptions_TabPage6.Controls.Add(chkMethod7UTD);
			this.Frame1.Controls.Add(TabFirstField);
			this.Frame1.Controls.Add(Label7);
			this.TabFirstField.Controls.Add(_TabFirstField_TabPage0);
			this.TabFirstField.Controls.Add(_TabFirstField_TabPage1);
			this._TabFirstField_TabPage0.Controls.Add(lstFieldList);
			this._TabFirstField_TabPage1.Controls.Add(lstGroupList);
			this.Label20.SetIndex(_Label20_0, Convert.ToInt16(0));
			((System.ComponentModel.ISupportInitialize)this.Label20).EndInit();
			this.Frame2.ResumeLayout(false);
			this.sstabOptions.ResumeLayout(false);
			this._sstabOptions_TabPage0.ResumeLayout(false);
			this.Frame3.ResumeLayout(false);
			this.Frame4.ResumeLayout(false);
			this._sstabOptions_TabPage1.ResumeLayout(false);
			this._sstabOptions_TabPage2.ResumeLayout(false);
			this._sstabOptions_TabPage3.ResumeLayout(false);
			this._sstabOptions_TabPage4.ResumeLayout(false);
			this._sstabOptions_TabPage5.ResumeLayout(false);
			this._sstabOptions_TabPage6.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.TabFirstField.ResumeLayout(false);
			this._TabFirstField_TabPage0.ResumeLayout(false);
			this._TabFirstField_TabPage1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
