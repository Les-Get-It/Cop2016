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
	partial class OldfrmReportAddCrit
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmReportAddCrit() : base()
		{
			Load += frmReportAddCrit_Load;
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
		private System.Windows.Forms.ListBox withEventsField_lstField1List;
		public System.Windows.Forms.ListBox lstField1List {
			get { return withEventsField_lstField1List; }
			set {
				if (withEventsField_lstField1List != null) {
					withEventsField_lstField1List.SelectedIndexChanged -= lstField1List_SelectedIndexChanged;
				}
				withEventsField_lstField1List = value;
				if (withEventsField_lstField1List != null) {
					withEventsField_lstField1List.SelectedIndexChanged += lstField1List_SelectedIndexChanged;
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
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label18;
		public System.Windows.Forms.Label Label1;
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
		private System.Windows.Forms.ComboBox withEventsField_cboDestFieldList;
		public System.Windows.Forms.ComboBox cboDestFieldList {
			get { return withEventsField_cboDestFieldList; }
			set {
				if (withEventsField_cboDestFieldList != null) {
					withEventsField_cboDestFieldList.SelectedIndexChanged -= cboDestFieldList_SelectedIndexChanged;
				}
				withEventsField_cboDestFieldList = value;
				if (withEventsField_cboDestFieldList != null) {
					withEventsField_cboDestFieldList.SelectedIndexChanged += cboDestFieldList_SelectedIndexChanged;
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
		public System.Windows.Forms.ComboBox cboLookupValues;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage0;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label11;
		public System.Windows.Forms.Label Label13;
		public System.Windows.Forms.Label Label15;
		public System.Windows.Forms.ComboBox cboField2List;
		public System.Windows.Forms.ComboBox cboFieldOperator;
		public System.Windows.Forms.TextBox txtOpt3TypeinValue;
		public System.Windows.Forms.ComboBox cboOpt3ValueOperator;
		public System.Windows.Forms.ComboBox cboOpt3Unit;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage1;
		public System.Windows.Forms.Label Label17;
		public System.Windows.Forms.Label Label16;
		public System.Windows.Forms.ComboBox cboOpLkTable;
		public System.Windows.Forms.ComboBox cboLookupTables;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage2;
		public System.Windows.Forms.TabControl sstabOptions;
		public System.Windows.Forms.Label lblMessage;
		public System.Windows.Forms.Label lblJoinOperator;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label12;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmReportAddCrit));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.lstField1List = new System.Windows.Forms.ListBox();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cboJoinOperator = new System.Windows.Forms.ComboBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this.Opt3Method = new System.Windows.Forms.RadioButton();
			this.Opt2Method = new System.Windows.Forms.RadioButton();
			this.Opt1Method = new System.Windows.Forms.RadioButton();
			this.cboSet = new System.Windows.Forms.ComboBox();
			this.sstabOptions = new System.Windows.Forms.TabControl();
			this._sstabOptions_TabPage0 = new System.Windows.Forms.TabPage();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label18 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtOpt1TypeinValue = new System.Windows.Forms.TextBox();
			this.cboOpt1ValueOperator = new System.Windows.Forms.ComboBox();
			this.cboDestFieldList = new System.Windows.Forms.ComboBox();
			this.chkBlank = new System.Windows.Forms.CheckBox();
			this.cboLookupValues = new System.Windows.Forms.ComboBox();
			this._sstabOptions_TabPage1 = new System.Windows.Forms.TabPage();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this.Label13 = new System.Windows.Forms.Label();
			this.Label15 = new System.Windows.Forms.Label();
			this.cboField2List = new System.Windows.Forms.ComboBox();
			this.cboFieldOperator = new System.Windows.Forms.ComboBox();
			this.txtOpt3TypeinValue = new System.Windows.Forms.TextBox();
			this.cboOpt3ValueOperator = new System.Windows.Forms.ComboBox();
			this.cboOpt3Unit = new System.Windows.Forms.ComboBox();
			this._sstabOptions_TabPage2 = new System.Windows.Forms.TabPage();
			this.Label17 = new System.Windows.Forms.Label();
			this.Label16 = new System.Windows.Forms.Label();
			this.cboOpLkTable = new System.Windows.Forms.ComboBox();
			this.cboLookupTables = new System.Windows.Forms.ComboBox();
			this.lblMessage = new System.Windows.Forms.Label();
			this.lblJoinOperator = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this.Frame2.SuspendLayout();
			this.sstabOptions.SuspendLayout();
			this._sstabOptions_TabPage0.SuspendLayout();
			this._sstabOptions_TabPage1.SuspendLayout();
			this._sstabOptions_TabPage2.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Add Criteria";
			this.ClientSize = new System.Drawing.Size(843, 470);
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
			this.Name = "frmReportAddCrit";
			this.lstField1List.Size = new System.Drawing.Size(317, 253);
			this.lstField1List.Location = new System.Drawing.Point(4, 183);
			this.lstField1List.TabIndex = 13;
			this.lstField1List.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstField1List.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstField1List.BackColor = System.Drawing.SystemColors.Window;
			this.lstField1List.CausesValidation = true;
			this.lstField1List.Enabled = true;
			this.lstField1List.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstField1List.IntegralHeight = true;
			this.lstField1List.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstField1List.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstField1List.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstField1List.Sorted = false;
			this.lstField1List.TabStop = true;
			this.lstField1List.Visible = true;
			this.lstField1List.MultiColumn = false;
			this.lstField1List.Name = "lstField1List";
			this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAdd.Text = "Add";
			this.cmdAdd.Size = new System.Drawing.Size(80, 24);
			this.cmdAdd.Location = new System.Drawing.Point(528, 432);
			this.cmdAdd.TabIndex = 12;
			this.cmdAdd.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdd.CausesValidation = true;
			this.cmdAdd.Enabled = true;
			this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdd.TabStop = true;
			this.cmdAdd.Name = "cmdAdd";
			this.cboJoinOperator.Size = new System.Drawing.Size(67, 27);
			this.cboJoinOperator.Location = new System.Drawing.Point(398, 147);
			this.cboJoinOperator.Items.AddRange(new object[] {
				"And",
				"Or"
			});
			this.cboJoinOperator.TabIndex = 11;
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
			this.cmdCancel.Size = new System.Drawing.Size(80, 24);
			this.cmdCancel.Location = new System.Drawing.Point(618, 432);
			this.cmdCancel.TabIndex = 10;
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
			this.Frame2.Size = new System.Drawing.Size(594, 107);
			this.Frame2.Location = new System.Drawing.Point(7, 25);
			this.Frame2.TabIndex = 7;
			this.Frame2.BackColor = System.Drawing.SystemColors.Control;
			this.Frame2.Enabled = true;
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Visible = true;
			this.Frame2.Padding = new System.Windows.Forms.Padding(0);
			this.Frame2.Name = "Frame2";
			this.Opt3Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt3Method.Text = "Method 3: Compare a field to every value in a lookup table";
			this.Opt3Method.Size = new System.Drawing.Size(564, 29);
			this.Opt3Method.Location = new System.Drawing.Point(7, 65);
			this.Opt3Method.TabIndex = 33;
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
			this.Opt2Method.Text = "Method 2: Add or subtract a field to/from another field, and compare the result to a fix value";
			this.Opt2Method.Size = new System.Drawing.Size(564, 29);
			this.Opt2Method.Location = new System.Drawing.Point(7, 43);
			this.Opt2Method.TabIndex = 9;
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
			this.Opt1Method.Text = "Method 1: Compare a field to another field, a value (typed in or from a lookup list), or blank";
			this.Opt1Method.Size = new System.Drawing.Size(568, 25);
			this.Opt1Method.Location = new System.Drawing.Point(7, 20);
			this.Opt1Method.TabIndex = 8;
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
			this.cboSet.Size = new System.Drawing.Size(67, 27);
			this.cboSet.Location = new System.Drawing.Point(160, 145);
			this.cboSet.Items.AddRange(new object[] {
				"And",
				"Or"
			});
			this.cboSet.TabIndex = 0;
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
			this.sstabOptions.Size = new System.Drawing.Size(495, 243);
			this.sstabOptions.Location = new System.Drawing.Point(323, 184);
			this.sstabOptions.TabIndex = 1;
			this.sstabOptions.SelectedIndex = 2;
			this.sstabOptions.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabOptions.Enabled = false;
			this.sstabOptions.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabOptions.Name = "sstabOptions";
			this._sstabOptions_TabPage0.Text = "Method 1";
			this.Label9.Text = "This value:";
			this.Label9.Size = new System.Drawing.Size(100, 20);
			this.Label9.Location = new System.Drawing.Point(107, 165);
			this.Label9.TabIndex = 4;
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
			this.Label6.Location = new System.Drawing.Point(19, 117);
			this.Label6.TabIndex = 5;
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
			this.Label8.Text = "OR";
			this.Label8.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label8.Size = new System.Drawing.Size(28, 23);
			this.Label8.Location = new System.Drawing.Point(105, 94);
			this.Label8.TabIndex = 6;
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
			this.Label18.Text = "This field:";
			this.Label18.Size = new System.Drawing.Size(213, 22);
			this.Label18.Location = new System.Drawing.Point(104, 42);
			this.Label18.TabIndex = 19;
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
			this.Label1.Text = "OR";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.Size = new System.Drawing.Size(28, 23);
			this.Label1.Location = new System.Drawing.Point(108, 144);
			this.Label1.TabIndex = 20;
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
			this.txtOpt1TypeinValue.AutoSize = false;
			this.txtOpt1TypeinValue.Size = new System.Drawing.Size(69, 24);
			this.txtOpt1TypeinValue.Location = new System.Drawing.Point(109, 184);
			this.txtOpt1TypeinValue.TabIndex = 2;
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
			this.cboOpt1ValueOperator.Location = new System.Drawing.Point(47, 113);
			this.cboOpt1ValueOperator.Items.AddRange(new object[] {
				"=",
				"<>",
				">",
				"<",
				">=",
				"<="
			});
			this.cboOpt1ValueOperator.TabIndex = 3;
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
			this.cboDestFieldList.Size = new System.Drawing.Size(309, 27);
			this.cboDestFieldList.Location = new System.Drawing.Point(104, 63);
			this.cboDestFieldList.TabIndex = 18;
			this.cboDestFieldList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboDestFieldList.BackColor = System.Drawing.SystemColors.Window;
			this.cboDestFieldList.CausesValidation = true;
			this.cboDestFieldList.Enabled = true;
			this.cboDestFieldList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboDestFieldList.IntegralHeight = true;
			this.cboDestFieldList.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboDestFieldList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboDestFieldList.Sorted = false;
			this.cboDestFieldList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboDestFieldList.TabStop = true;
			this.cboDestFieldList.Visible = true;
			this.cboDestFieldList.Name = "cboDestFieldList";
			this.chkBlank.Text = " Blank";
			this.chkBlank.Size = new System.Drawing.Size(232, 29);
			this.chkBlank.Location = new System.Drawing.Point(107, 112);
			this.chkBlank.TabIndex = 21;
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
			this.cboLookupValues.Size = new System.Drawing.Size(378, 27);
			this.cboLookupValues.Location = new System.Drawing.Point(109, 197);
			this.cboLookupValues.TabIndex = 22;
			this.cboLookupValues.Visible = false;
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
			this.cboLookupValues.Name = "cboLookupValues";
			this._sstabOptions_TabPage1.Text = "Method 2";
			this.Label3.Text = "Second Field";
			this.Label3.Size = new System.Drawing.Size(203, 18);
			this.Label3.Location = new System.Drawing.Point(127, 65);
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
			this.Label2.Text = "Add/Subtract";
			this.Label2.Size = new System.Drawing.Size(82, 15);
			this.Label2.Location = new System.Drawing.Point(37, 67);
			this.Label2.TabIndex = 29;
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
			this.Label11.Text = "Date/Time Unit? (if the field is a date or time field)";
			this.Label11.Size = new System.Drawing.Size(227, 32);
			this.Label11.Location = new System.Drawing.Point(245, 115);
			this.Label11.TabIndex = 30;
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
			this.Label13.Location = new System.Drawing.Point(48, 124);
			this.Label13.TabIndex = 31;
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
			this.Label15.Location = new System.Drawing.Point(128, 128);
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
			this.cboField2List.Size = new System.Drawing.Size(327, 27);
			this.cboField2List.Location = new System.Drawing.Point(125, 84);
			this.cboField2List.TabIndex = 23;
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
			this.cboFieldOperator.Location = new System.Drawing.Point(42, 85);
			this.cboFieldOperator.Items.AddRange(new object[] {
				"+",
				"-"
			});
			this.cboFieldOperator.TabIndex = 24;
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
			this.txtOpt3TypeinValue.Location = new System.Drawing.Point(130, 148);
			this.txtOpt3TypeinValue.TabIndex = 25;
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
			this.cboOpt3ValueOperator.Size = new System.Drawing.Size(50, 27);
			this.cboOpt3ValueOperator.Location = new System.Drawing.Point(45, 145);
			this.cboOpt3ValueOperator.Items.AddRange(new object[] {
				"=",
				"<>",
				">",
				"<",
				">=",
				"<="
			});
			this.cboOpt3ValueOperator.TabIndex = 26;
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
			this.cboOpt3Unit.Size = new System.Drawing.Size(105, 27);
			this.cboOpt3Unit.Location = new System.Drawing.Point(247, 147);
			this.cboOpt3Unit.Items.AddRange(new object[] {
				"Years",
				"Months",
				"Days",
				"Hours",
				"Minutes",
				"Seconds"
			});
			this.cboOpt3Unit.TabIndex = 27;
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
			this._sstabOptions_TabPage2.Text = "Method 3";
			this.Label17.Text = "Op.";
			this.Label17.Size = new System.Drawing.Size(35, 18);
			this.Label17.Location = new System.Drawing.Point(37, 87);
			this.Label17.TabIndex = 36;
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
			this.Label16.Location = new System.Drawing.Point(117, 85);
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
			this.cboOpLkTable.Size = new System.Drawing.Size(84, 27);
			this.cboOpLkTable.Location = new System.Drawing.Point(34, 108);
			this.cboOpLkTable.Items.AddRange(new object[] {
				"In",
				"Not In"
			});
			this.cboOpLkTable.TabIndex = 34;
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
			this.cboLookupTables.Location = new System.Drawing.Point(117, 108);
			this.cboLookupTables.TabIndex = 35;
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
			this.lblMessage.Text = "Setting up Criteria ";
			this.lblMessage.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.lblMessage.Size = new System.Drawing.Size(797, 20);
			this.lblMessage.Location = new System.Drawing.Point(2, 0);
			this.lblMessage.TabIndex = 17;
			this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblMessage.BackColor = System.Drawing.SystemColors.Control;
			this.lblMessage.Enabled = true;
			this.lblMessage.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblMessage.UseMnemonic = true;
			this.lblMessage.Visible = true;
			this.lblMessage.AutoSize = false;
			this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblMessage.Name = "lblMessage";
			this.lblJoinOperator.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblJoinOperator.Text = "Join type in this Set:";
			this.lblJoinOperator.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblJoinOperator.ForeColor = System.Drawing.Color.Blue;
			this.lblJoinOperator.Size = new System.Drawing.Size(157, 18);
			this.lblJoinOperator.Location = new System.Drawing.Point(237, 149);
			this.lblJoinOperator.TabIndex = 16;
			this.lblJoinOperator.BackColor = System.Drawing.SystemColors.Control;
			this.lblJoinOperator.Enabled = true;
			this.lblJoinOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblJoinOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblJoinOperator.UseMnemonic = true;
			this.lblJoinOperator.Visible = true;
			this.lblJoinOperator.AutoSize = false;
			this.lblJoinOperator.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblJoinOperator.Name = "lblJoinOperator";
			this.Label7.BackColor = System.Drawing.Color.Transparent;
			this.Label7.Text = "Note: If you are defining the interval between 2 date fields, select the earliest date field from the list";
			this.Label7.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label7.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label7.Size = new System.Drawing.Size(214, 75);
			this.Label7.Location = new System.Drawing.Point(602, 33);
			this.Label7.TabIndex = 15;
			this.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label7.Enabled = true;
			this.Label7.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label7.UseMnemonic = true;
			this.Label7.Visible = true;
			this.Label7.AutoSize = false;
			this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Label7.Name = "Label7";
			this.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label12.Text = "Select Criteria Set #:";
			this.Label12.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label12.ForeColor = System.Drawing.Color.Blue;
			this.Label12.Size = new System.Drawing.Size(153, 18);
			this.Label12.Location = new System.Drawing.Point(3, 147);
			this.Label12.TabIndex = 14;
			this.Label12.BackColor = System.Drawing.SystemColors.Control;
			this.Label12.Enabled = true;
			this.Label12.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label12.UseMnemonic = true;
			this.Label12.Visible = true;
			this.Label12.AutoSize = false;
			this.Label12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label12.Name = "Label12";
			this.Controls.Add(lstField1List);
			this.Controls.Add(cmdAdd);
			this.Controls.Add(cboJoinOperator);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(Frame2);
			this.Controls.Add(cboSet);
			this.Controls.Add(sstabOptions);
			this.Controls.Add(lblMessage);
			this.Controls.Add(lblJoinOperator);
			this.Controls.Add(Label7);
			this.Controls.Add(Label12);
			this.Frame2.Controls.Add(Opt3Method);
			this.Frame2.Controls.Add(Opt2Method);
			this.Frame2.Controls.Add(Opt1Method);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage0);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage1);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage2);
			this._sstabOptions_TabPage0.Controls.Add(Label9);
			this._sstabOptions_TabPage0.Controls.Add(Label6);
			this._sstabOptions_TabPage0.Controls.Add(Label8);
			this._sstabOptions_TabPage0.Controls.Add(Label18);
			this._sstabOptions_TabPage0.Controls.Add(Label1);
			this._sstabOptions_TabPage0.Controls.Add(txtOpt1TypeinValue);
			this._sstabOptions_TabPage0.Controls.Add(cboOpt1ValueOperator);
			this._sstabOptions_TabPage0.Controls.Add(cboDestFieldList);
			this._sstabOptions_TabPage0.Controls.Add(chkBlank);
			this._sstabOptions_TabPage0.Controls.Add(cboLookupValues);
			this._sstabOptions_TabPage1.Controls.Add(Label3);
			this._sstabOptions_TabPage1.Controls.Add(Label2);
			this._sstabOptions_TabPage1.Controls.Add(Label11);
			this._sstabOptions_TabPage1.Controls.Add(Label13);
			this._sstabOptions_TabPage1.Controls.Add(Label15);
			this._sstabOptions_TabPage1.Controls.Add(cboField2List);
			this._sstabOptions_TabPage1.Controls.Add(cboFieldOperator);
			this._sstabOptions_TabPage1.Controls.Add(txtOpt3TypeinValue);
			this._sstabOptions_TabPage1.Controls.Add(cboOpt3ValueOperator);
			this._sstabOptions_TabPage1.Controls.Add(cboOpt3Unit);
			this._sstabOptions_TabPage2.Controls.Add(Label17);
			this._sstabOptions_TabPage2.Controls.Add(Label16);
			this._sstabOptions_TabPage2.Controls.Add(cboOpLkTable);
			this._sstabOptions_TabPage2.Controls.Add(cboLookupTables);
			this.Frame2.ResumeLayout(false);
			this.sstabOptions.ResumeLayout(false);
			this._sstabOptions_TabPage0.ResumeLayout(false);
			this._sstabOptions_TabPage1.ResumeLayout(false);
			this._sstabOptions_TabPage2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
