using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using MSDataGridLib;



namespace COP2001
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	partial class OlddlgMeasureCreateSetLogic
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OlddlgMeasureCreateSetLogic() : base()
		{
			Load += dlgMeasureCreateSetLogic_Load;
			//This call is required by the Windows Form Designer.
			InitializeComponent();
		}
//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool Disposing)
		{
			if (Disposing)
            {
				if ((components != null))
                {
					components.Dispose();
				}
			}
			base.Dispose(Disposing);
		}
//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTip1;
		private System.Windows.Forms.Button withEventsField_cmdDelete;
		public System.Windows.Forms.Button cmdDelete
        {
			get { return withEventsField_cmdDelete; }
			set {
				if (withEventsField_cmdDelete != null)
                {
					withEventsField_cmdDelete.Click -= cmdDelete_Click;
				}
				withEventsField_cmdDelete = value;
				if (withEventsField_cmdDelete != null)
                {
					withEventsField_cmdDelete.Click += cmdDelete_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdSave;
		public System.Windows.Forms.Button cmdSave
        {
			get { return withEventsField_cmdSave; }
			set
            {
				if (withEventsField_cmdSave != null)
                {
					withEventsField_cmdSave.Click -= cmdSave_Click;
				}
				withEventsField_cmdSave = value;
				if (withEventsField_cmdSave != null)
                {
					withEventsField_cmdSave.Click += cmdSave_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstReplacements;
		public System.Windows.Forms.ListBox lstDDID;
		private System.Windows.Forms.Button withEventsField_CancelButton_Renamed;
		public System.Windows.Forms.Button CancelButton_Renamed
        {
			get { return withEventsField_CancelButton_Renamed; }
			set
            {
				if (withEventsField_CancelButton_Renamed != null)
                {
					withEventsField_CancelButton_Renamed.Click -= CancelButton_Renamed_Click;
				}
				withEventsField_CancelButton_Renamed = value;
				if (withEventsField_CancelButton_Renamed != null)
                {
					withEventsField_CancelButton_Renamed.Click += CancelButton_Renamed_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_btnAdd;
		public System.Windows.Forms.Button btnAdd
        {
			get { return withEventsField_btnAdd; }
			set
            {
				if (withEventsField_btnAdd != null)
                {
					withEventsField_btnAdd.Click -= btnAdd_Click;
				}
				withEventsField_btnAdd = value;
				if (withEventsField_btnAdd != null)
                {
					withEventsField_btnAdd.Click += btnAdd_Click;
				}
			}
		}
        //LDW private AxMSDBGrid.AxDBGrid withEventsField_dbgMeasureSet;
        private DataGridView withEventsField_dbgMeasureSet;
        //LDW public AxMSDBGrid.AxDBGrid dbgMeasureSet
        public DataGridView dbgMeasureSet
        {
			get { return withEventsField_dbgMeasureSet; }
			set
            {
				if (withEventsField_dbgMeasureSet != null)
                {
                    //LDW withEventsField_dbgMeasureSet.RowColChange -= dbgMeasureSet_RowColChange;
                    withEventsField_dbgMeasureSet.CurrentCellChanged -= dbgMeasureSet_RowColChange;
                }
				withEventsField_dbgMeasureSet = value;
				if (withEventsField_dbgMeasureSet != null)
                {
                    //LDW withEventsField_dbgMeasureSet.RowColChange += dbgMeasureSet_RowColChange;
                    withEventsField_dbgMeasureSet.CurrentCellChanged += dbgMeasureSet_RowColChange;
                }
			}
		}
        //LDW public AxMSRDC.AxMSRDC rdcMeasureSet;
        public BindingNavigator rdcMeasureSet;
        private System.Windows.Forms.RadioButton withEventsField_OptDDID2;
		public System.Windows.Forms.RadioButton OptDDID2
        {
			get { return withEventsField_OptDDID2; }
			set
            {
				if (withEventsField_OptDDID2 != null)
                {
					withEventsField_OptDDID2.CheckedChanged -= OptDDID2_CheckedChanged;
				}
				withEventsField_OptDDID2 = value;
				if (withEventsField_OptDDID2 != null)
                {
					withEventsField_OptDDID2.CheckedChanged += OptDDID2_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_OptDDID1;
		public System.Windows.Forms.RadioButton OptDDID1 {
			get { return withEventsField_OptDDID1; }
			set {
				if (withEventsField_OptDDID1 != null) {
					withEventsField_OptDDID1.CheckedChanged -= OptDDID1_CheckedChanged;
				}
				withEventsField_OptDDID1 = value;
				if (withEventsField_OptDDID1 != null) {
					withEventsField_OptDDID1.CheckedChanged += OptDDID1_CheckedChanged;
				}
			}
		}
		public System.Windows.Forms.TextBox txtDDID;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.ComboBox cboSetJoinOp;
		private System.Windows.Forms.RadioButton withEventsField_OptNewSet;
		public System.Windows.Forms.RadioButton OptNewSet {
			get { return withEventsField_OptNewSet; }
			set {
				if (withEventsField_OptNewSet != null) {
					withEventsField_OptNewSet.CheckedChanged -= OptNewSet_CheckedChanged;
				}
				withEventsField_OptNewSet = value;
				if (withEventsField_OptNewSet != null) {
					withEventsField_OptNewSet.CheckedChanged += OptNewSet_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_OptNewCrit;
		public System.Windows.Forms.RadioButton OptNewCrit {
			get { return withEventsField_OptNewCrit; }
			set {
				if (withEventsField_OptNewCrit != null) {
					withEventsField_OptNewCrit.CheckedChanged -= OptNewCrit_CheckedChanged;
				}
				withEventsField_OptNewCrit = value;
				if (withEventsField_OptNewCrit != null) {
					withEventsField_OptNewCrit.CheckedChanged += OptNewCrit_CheckedChanged;
				}
			}
		}
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.GroupBox Frame2;
		public System.Windows.Forms.GroupBox frm;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OlddlgMeasureCreateSetLogic));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdSave = new System.Windows.Forms.Button();
			this.lstReplacements = new System.Windows.Forms.ListBox();
			this.lstDDID = new System.Windows.Forms.ListBox();
			this.CancelButton_Renamed = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
            //this.dbgMeasureSet = new AxMSDBGrid.AxDBGrid();
            this.dbgMeasureSet = new DataGridView();
            //LDW this.rdcMeasureSet = new AxMSRDC.AxMSRDC();
            this.rdcMeasureSet = new BindingNavigator();
			this.frm = new System.Windows.Forms.GroupBox();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.OptDDID2 = new System.Windows.Forms.RadioButton();
			this.OptDDID1 = new System.Windows.Forms.RadioButton();
			this.txtDDID = new System.Windows.Forms.TextBox();
			this.Label8 = new System.Windows.Forms.Label();
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this.cboSetJoinOp = new System.Windows.Forms.ComboBox();
			this.OptNewSet = new System.Windows.Forms.RadioButton();
			this.OptNewCrit = new System.Windows.Forms.RadioButton();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.frm.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.Frame2.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.dbgMeasureSet).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcMeasureSet).BeginInit();
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Create Replacement Logic";
			this.ClientSize = new System.Drawing.Size(1165, 723);
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
			this.Name = "dlgMeasureCreateSetLogic";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "Delete All";
			this.cmdDelete.Size = new System.Drawing.Size(192, 32);
			this.cmdDelete.Location = new System.Drawing.Point(970, 530);
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
			this.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSave.Text = "Create Duplicate Logic in Flowchart";
			this.cmdSave.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdSave.Size = new System.Drawing.Size(182, 42);
			this.cmdSave.Location = new System.Drawing.Point(970, 620);
			this.cmdSave.TabIndex = 10;
			this.cmdSave.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSave.CausesValidation = true;
			this.cmdSave.Enabled = true;
			this.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSave.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSave.TabStop = true;
			this.cmdSave.Name = "cmdSave";
			this.lstReplacements.Size = new System.Drawing.Size(942, 269);
			this.lstReplacements.Location = new System.Drawing.Point(0, 450);
			this.lstReplacements.TabIndex = 7;
			this.lstReplacements.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstReplacements.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstReplacements.BackColor = System.Drawing.SystemColors.Window;
			this.lstReplacements.CausesValidation = true;
			this.lstReplacements.Enabled = true;
			this.lstReplacements.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstReplacements.IntegralHeight = true;
			this.lstReplacements.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstReplacements.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstReplacements.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstReplacements.Sorted = false;
			this.lstReplacements.TabStop = true;
			this.lstReplacements.Visible = true;
			this.lstReplacements.MultiColumn = false;
			this.lstReplacements.Name = "lstReplacements";
			this.lstDDID.Size = new System.Drawing.Size(492, 123);
			this.lstDDID.Location = new System.Drawing.Point(640, 150);
			this.lstDDID.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstDDID.TabIndex = 6;
			this.lstDDID.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstDDID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstDDID.BackColor = System.Drawing.SystemColors.Window;
			this.lstDDID.CausesValidation = true;
			this.lstDDID.Enabled = true;
			this.lstDDID.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstDDID.IntegralHeight = true;
			this.lstDDID.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstDDID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstDDID.Sorted = false;
			this.lstDDID.TabStop = true;
			this.lstDDID.Visible = true;
			this.lstDDID.MultiColumn = false;
			this.lstDDID.Name = "lstDDID";
			this.CancelButton_Renamed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CancelButton_Renamed.Text = "Close";
			this.CancelButton_Renamed.Size = new System.Drawing.Size(182, 32);
			this.CancelButton_Renamed.Location = new System.Drawing.Point(970, 680);
			this.CancelButton_Renamed.TabIndex = 1;
			this.CancelButton_Renamed.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.CancelButton_Renamed.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton_Renamed.CausesValidation = true;
			this.CancelButton_Renamed.Enabled = true;
			this.CancelButton_Renamed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CancelButton_Renamed.Cursor = System.Windows.Forms.Cursors.Default;
			this.CancelButton_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CancelButton_Renamed.TabStop = true;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnAdd.Text = "Add to List";
			this.btnAdd.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.btnAdd.Size = new System.Drawing.Size(112, 37);
			this.btnAdd.Location = new System.Drawing.Point(1020, 370);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
			this.btnAdd.CausesValidation = true;
			this.btnAdd.Enabled = true;
			this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnAdd.TabStop = true;
			this.btnAdd.Name = "btnAdd";
            //LDW dbgMeasureSet.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgMeasureSet.OcxState");
            this.dbgMeasureSet.Size = new System.Drawing.Size(619, 420);
			this.dbgMeasureSet.Location = new System.Drawing.Point(0, 0);
			this.dbgMeasureSet.TabIndex = 2;
			this.dbgMeasureSet.Name = "dbgMeasureSet";
			//LDW rdcMeasureSet.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcMeasureSet.OcxState");
			this.rdcMeasureSet.Size = new System.Drawing.Size(197, 28);
			this.rdcMeasureSet.Location = new System.Drawing.Point(420, 210);
			this.rdcMeasureSet.Visible = false;
			this.rdcMeasureSet.Name = "rdcMeasureSet";
			this.frm.Size = new System.Drawing.Size(532, 422);
			this.frm.Location = new System.Drawing.Point(620, 0);
			this.frm.TabIndex = 9;
			this.frm.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.frm.BackColor = System.Drawing.SystemColors.Control;
			this.frm.Enabled = true;
			this.frm.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frm.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frm.Visible = true;
			this.frm.Padding = new System.Windows.Forms.Padding(0);
			this.frm.Name = "frm";
			this.Frame1.Size = new System.Drawing.Size(522, 112);
			this.Frame1.Location = new System.Drawing.Point(10, 0);
			this.Frame1.TabIndex = 12;
			this.Frame1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.OptDDID2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptDDID2.Text = "Field 2";
			this.OptDDID2.Size = new System.Drawing.Size(122, 22);
			this.OptDDID2.Location = new System.Drawing.Point(310, 50);
			this.OptDDID2.TabIndex = 22;
			this.OptDDID2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OptDDID2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptDDID2.BackColor = System.Drawing.SystemColors.Control;
			this.OptDDID2.CausesValidation = true;
			this.OptDDID2.Enabled = true;
			this.OptDDID2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OptDDID2.Cursor = System.Windows.Forms.Cursors.Default;
			this.OptDDID2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptDDID2.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptDDID2.TabStop = true;
			this.OptDDID2.Checked = false;
			this.OptDDID2.Visible = true;
			this.OptDDID2.Name = "OptDDID2";
			this.OptDDID1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptDDID1.Text = "Field 1";
			this.OptDDID1.Size = new System.Drawing.Size(122, 22);
			this.OptDDID1.Location = new System.Drawing.Point(90, 50);
			this.OptDDID1.TabIndex = 21;
			this.OptDDID1.Checked = true;
			this.OptDDID1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OptDDID1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptDDID1.BackColor = System.Drawing.SystemColors.Control;
			this.OptDDID1.CausesValidation = true;
			this.OptDDID1.Enabled = true;
			this.OptDDID1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OptDDID1.Cursor = System.Windows.Forms.Cursors.Default;
			this.OptDDID1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptDDID1.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptDDID1.TabStop = true;
			this.OptDDID1.Visible = true;
			this.OptDDID1.Name = "OptDDID1";
			this.txtDDID.AutoSize = false;
			this.txtDDID.Size = new System.Drawing.Size(492, 24);
			this.txtDDID.Location = new System.Drawing.Point(10, 80);
			this.txtDDID.TabIndex = 14;
			this.txtDDID.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtDDID.AcceptsReturn = true;
			this.txtDDID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtDDID.BackColor = System.Drawing.SystemColors.Window;
			this.txtDDID.CausesValidation = true;
			this.txtDDID.Enabled = true;
			this.txtDDID.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtDDID.HideSelection = true;
			this.txtDDID.ReadOnly = false;
			this.txtDDID.MaxLength = 0;
			this.txtDDID.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtDDID.Multiline = false;
			this.txtDDID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtDDID.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtDDID.TabStop = true;
			this.txtDDID.Visible = true;
			this.txtDDID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtDDID.Name = "txtDDID";
			this.Label8.Text = "Replace";
			this.Label8.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label8.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			this.Label8.Size = new System.Drawing.Size(252, 32);
			this.Label8.Location = new System.Drawing.Point(10, 10);
			this.Label8.TabIndex = 13;
			this.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label8.BackColor = System.Drawing.SystemColors.Control;
			this.Label8.Enabled = true;
			this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label8.UseMnemonic = true;
			this.Label8.Visible = true;
			this.Label8.AutoSize = false;
			this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label8.Name = "Label8";
			this.Frame2.Size = new System.Drawing.Size(522, 262);
			this.Frame2.Location = new System.Drawing.Point(10, 100);
			this.Frame2.TabIndex = 15;
			this.Frame2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame2.BackColor = System.Drawing.SystemColors.Control;
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Visible = true;
			this.Frame2.Padding = new System.Windows.Forms.Padding(0);
			this.Frame2.Name = "Frame2";
			this.cboSetJoinOp.Enabled = false;
			this.cboSetJoinOp.Size = new System.Drawing.Size(102, 27);
			this.cboSetJoinOp.Location = new System.Drawing.Point(210, 230);
			this.cboSetJoinOp.Items.AddRange(new object[] {
				"AND",
				"OR"
			});
			this.cboSetJoinOp.TabIndex = 19;
			this.cboSetJoinOp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboSetJoinOp.BackColor = System.Drawing.SystemColors.Window;
			this.cboSetJoinOp.CausesValidation = true;
			this.cboSetJoinOp.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboSetJoinOp.IntegralHeight = true;
			this.cboSetJoinOp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboSetJoinOp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboSetJoinOp.Sorted = false;
			this.cboSetJoinOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboSetJoinOp.TabStop = true;
			this.cboSetJoinOp.Visible = true;
			this.cboSetJoinOp.Name = "cboSetJoinOp";
			this.OptNewSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptNewSet.Text = "Duplicate and Replace fields with New Set(s) (within Step)";
			this.OptNewSet.Size = new System.Drawing.Size(402, 32);
			this.OptNewSet.Location = new System.Drawing.Point(40, 200);
			this.OptNewSet.TabIndex = 18;
			this.OptNewSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OptNewSet.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptNewSet.BackColor = System.Drawing.SystemColors.Control;
			this.OptNewSet.CausesValidation = true;
			this.OptNewSet.Enabled = true;
			this.OptNewSet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OptNewSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.OptNewSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptNewSet.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptNewSet.TabStop = true;
			this.OptNewSet.Checked = false;
			this.OptNewSet.Visible = true;
			this.OptNewSet.Name = "OptNewSet";
			this.OptNewCrit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptNewCrit.Text = "Duplicate and Replace New Criteria (within Set)";
			this.OptNewCrit.Size = new System.Drawing.Size(372, 32);
			this.OptNewCrit.Location = new System.Drawing.Point(40, 170);
			this.OptNewCrit.TabIndex = 17;
			this.OptNewCrit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OptNewCrit.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptNewCrit.BackColor = System.Drawing.SystemColors.Control;
			this.OptNewCrit.CausesValidation = true;
			this.OptNewCrit.Enabled = true;
			this.OptNewCrit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OptNewCrit.Cursor = System.Windows.Forms.Cursors.Default;
			this.OptNewCrit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptNewCrit.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptNewCrit.TabStop = true;
			this.OptNewCrit.Checked = false;
			this.OptNewCrit.Visible = true;
			this.OptNewCrit.Name = "OptNewCrit";
			this.Label7.Text = "Set Join Operator";
			this.Label7.Size = new System.Drawing.Size(112, 22);
			this.Label7.Location = new System.Drawing.Point(90, 235);
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
			this.Label4.Text = "Replace with";
			this.Label4.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			this.Label4.Size = new System.Drawing.Size(252, 32);
			this.Label4.Location = new System.Drawing.Point(10, 20);
			this.Label4.TabIndex = 16;
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label4.BackColor = System.Drawing.SystemColors.Control;
			this.Label4.Enabled = true;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.UseMnemonic = true;
			this.Label4.Visible = true;
			this.Label4.AutoSize = false;
			this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label4.Name = "Label4";
			this.Label6.Text = "Replacements";
			this.Label6.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label6.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			this.Label6.Size = new System.Drawing.Size(342, 32);
			this.Label6.Location = new System.Drawing.Point(0, 420);
			this.Label6.TabIndex = 8;
			this.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label6.BackColor = System.Drawing.SystemColors.Control;
			this.Label6.Enabled = true;
			this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label6.UseMnemonic = true;
			this.Label6.Visible = true;
			this.Label6.AutoSize = false;
			this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label6.Name = "Label6";
			this.Label5.Text = "Field(s)";
			this.Label5.Size = new System.Drawing.Size(42, 22);
			this.Label5.Location = new System.Drawing.Point(630, 130);
			this.Label5.TabIndex = 5;
			this.Label5.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
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
			this.Label3.Text = "Field 1";
			this.Label3.Size = new System.Drawing.Size(92, 22);
			this.Label3.Location = new System.Drawing.Point(630, 40);
			this.Label3.TabIndex = 4;
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
			this.Label2.Text = "With Replacement Field(s)";
			this.Label2.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			this.Label2.Size = new System.Drawing.Size(372, 32);
			this.Label2.Location = new System.Drawing.Point(630, 100);
			this.Label2.TabIndex = 3;
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.SystemColors.Control;
			this.Label2.Enabled = true;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.Controls.Add(cmdDelete);
			this.Controls.Add(cmdSave);
			this.Controls.Add(lstReplacements);
			this.Controls.Add(lstDDID);
			this.Controls.Add(CancelButton_Renamed);
			this.Controls.Add(btnAdd);
			this.Controls.Add(dbgMeasureSet);
			this.Controls.Add(rdcMeasureSet);
			this.Controls.Add(frm);
			this.Controls.Add(Label6);
			this.Controls.Add(Label5);
			this.Controls.Add(Label3);
			this.Controls.Add(Label2);
			this.frm.Controls.Add(Frame1);
			this.frm.Controls.Add(Frame2);
			this.Frame1.Controls.Add(OptDDID2);
			this.Frame1.Controls.Add(OptDDID1);
			this.Frame1.Controls.Add(txtDDID);
			this.Frame1.Controls.Add(Label8);
			this.Frame2.Controls.Add(cboSetJoinOp);
			this.Frame2.Controls.Add(OptNewSet);
			this.Frame2.Controls.Add(OptNewCrit);
			this.Frame2.Controls.Add(Label7);
			this.Frame2.Controls.Add(Label4);
			((System.ComponentModel.ISupportInitialize)this.rdcMeasureSet).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgMeasureSet).EndInit();
			this.frm.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.Frame2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
