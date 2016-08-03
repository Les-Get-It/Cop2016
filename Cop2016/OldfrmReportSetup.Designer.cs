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
	partial class OldfrmReportSetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmReportSetup() : base()
		{
			Load += frmReportSetup_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdDup;
		public System.Windows.Forms.Button cmdDup {
			get { return withEventsField_cmdDup; }
			set {
				if (withEventsField_cmdDup != null) {
					withEventsField_cmdDup.Click -= cmdDup_Click;
				}
				withEventsField_cmdDup = value;
				if (withEventsField_cmdDup != null) {
					withEventsField_cmdDup.Click += cmdDup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRenameReport;
		public System.Windows.Forms.Button cmdRenameReport {
			get { return withEventsField_cmdRenameReport; }
			set {
				if (withEventsField_cmdRenameReport != null) {
					withEventsField_cmdRenameReport.Click -= cmdRenameReport_Click;
				}
				withEventsField_cmdRenameReport = value;
				if (withEventsField_cmdRenameReport != null) {
					withEventsField_cmdRenameReport.Click += cmdRenameReport_Click;
				}
			}
		}
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
		private System.Windows.Forms.Button withEventsField_cmdHelp;
		public System.Windows.Forms.Button cmdHelp {
			get { return withEventsField_cmdHelp; }
			set {
				if (withEventsField_cmdHelp != null) {
					withEventsField_cmdHelp.Click -= cmdHelp_Click;
				}
				withEventsField_cmdHelp = value;
				if (withEventsField_cmdHelp != null) {
					withEventsField_cmdHelp.Click += cmdHelp_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox txtHelp;
		public System.Windows.Forms.Label dtHelp;
		public AxMSRDC.AxMSRDC rdcReports;
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
		private System.Windows.Forms.Button withEventsField_cmdNewReport;
		public System.Windows.Forms.Button cmdNewReport {
			get { return withEventsField_cmdNewReport; }
			set {
				if (withEventsField_cmdNewReport != null) {
					withEventsField_cmdNewReport.Click -= cmdNewReport_Click;
				}
				withEventsField_cmdNewReport = value;
				if (withEventsField_cmdNewReport != null) {
					withEventsField_cmdNewReport.Click += cmdNewReport_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDeleteReport;
		public System.Windows.Forms.Button cmdDeleteReport {
			get { return withEventsField_cmdDeleteReport; }
			set {
				if (withEventsField_cmdDeleteReport != null) {
					withEventsField_cmdDeleteReport.Click -= cmdDeleteReport_Click;
				}
				withEventsField_cmdDeleteReport = value;
				if (withEventsField_cmdDeleteReport != null) {
					withEventsField_cmdDeleteReport.Click += cmdDeleteReport_Click;
				}
			}
		}
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.ListBox lstAvailableFieldList;
		private System.Windows.Forms.Button withEventsField_cmdMoveFieldup;
		public System.Windows.Forms.Button cmdMoveFieldup {
			get { return withEventsField_cmdMoveFieldup; }
			set {
				if (withEventsField_cmdMoveFieldup != null) {
					withEventsField_cmdMoveFieldup.Click -= cmdMoveFieldup_Click;
				}
				withEventsField_cmdMoveFieldup = value;
				if (withEventsField_cmdMoveFieldup != null) {
					withEventsField_cmdMoveFieldup.Click += cmdMoveFieldup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdMoveFieldDown;
		public System.Windows.Forms.Button cmdMoveFieldDown {
			get { return withEventsField_cmdMoveFieldDown; }
			set {
				if (withEventsField_cmdMoveFieldDown != null) {
					withEventsField_cmdMoveFieldDown.Click -= cmdMoveFieldDown_Click;
				}
				withEventsField_cmdMoveFieldDown = value;
				if (withEventsField_cmdMoveFieldDown != null) {
					withEventsField_cmdMoveFieldDown.Click += cmdMoveFieldDown_Click;
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
		public System.Windows.Forms.ListBox lstSelectedFieldList;
		private System.Windows.Forms.Button withEventsField_cmdRenameField;
		public System.Windows.Forms.Button cmdRenameField {
			get { return withEventsField_cmdRenameField; }
			set {
				if (withEventsField_cmdRenameField != null) {
					withEventsField_cmdRenameField.Click -= cmdRenameField_Click;
				}
				withEventsField_cmdRenameField = value;
				if (withEventsField_cmdRenameField != null) {
					withEventsField_cmdRenameField.Click += cmdRenameField_Click;
				}
			}
		}
		public System.Windows.Forms.TabPage _sstabReportSpec_TabPage0;
		private System.Windows.Forms.Button withEventsField_cmdDuplCriteria;
		public System.Windows.Forms.Button cmdDuplCriteria {
			get { return withEventsField_cmdDuplCriteria; }
			set {
				if (withEventsField_cmdDuplCriteria != null) {
					withEventsField_cmdDuplCriteria.Click -= cmdDuplCriteria_Click;
				}
				withEventsField_cmdDuplCriteria = value;
				if (withEventsField_cmdDuplCriteria != null) {
					withEventsField_cmdDuplCriteria.Click += cmdDuplCriteria_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdCopyCriteria;
		public System.Windows.Forms.Button cmdCopyCriteria {
			get { return withEventsField_cmdCopyCriteria; }
			set {
				if (withEventsField_cmdCopyCriteria != null) {
					withEventsField_cmdCopyCriteria.Click -= cmdCopyCriteria_Click;
				}
				withEventsField_cmdCopyCriteria = value;
				if (withEventsField_cmdCopyCriteria != null) {
					withEventsField_cmdCopyCriteria.Click += cmdCopyCriteria_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdChangeReportAndOr;
		public System.Windows.Forms.Button cmdChangeReportAndOr {
			get { return withEventsField_cmdChangeReportAndOr; }
			set {
				if (withEventsField_cmdChangeReportAndOr != null) {
					withEventsField_cmdChangeReportAndOr.Click -= cmdChangeReportAndOr_Click;
				}
				withEventsField_cmdChangeReportAndOr = value;
				if (withEventsField_cmdChangeReportAndOr != null) {
					withEventsField_cmdChangeReportAndOr.Click += cmdChangeReportAndOr_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstSelectedCriteria;
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
		private System.Windows.Forms.Button withEventsField_cmdChangeOrAnd;
		public System.Windows.Forms.Button cmdChangeOrAnd {
			get { return withEventsField_cmdChangeOrAnd; }
			set {
				if (withEventsField_cmdChangeOrAnd != null) {
					withEventsField_cmdChangeOrAnd.Click -= cmdChangeOrAnd_Click;
				}
				withEventsField_cmdChangeOrAnd = value;
				if (withEventsField_cmdChangeOrAnd != null) {
					withEventsField_cmdChangeOrAnd.Click += cmdChangeOrAnd_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddCriteria;
		public System.Windows.Forms.Button cmdAddCriteria {
			get { return withEventsField_cmdAddCriteria; }
			set {
				if (withEventsField_cmdAddCriteria != null) {
					withEventsField_cmdAddCriteria.Click -= cmdAddCriteria_Click;
				}
				withEventsField_cmdAddCriteria = value;
				if (withEventsField_cmdAddCriteria != null) {
					withEventsField_cmdAddCriteria.Click += cmdAddCriteria_Click;
				}
			}
		}
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.TabPage _sstabReportSpec_TabPage1;
		private System.Windows.Forms.Button withEventsField_cmdAddSumCriteria;
		public System.Windows.Forms.Button cmdAddSumCriteria {
			get { return withEventsField_cmdAddSumCriteria; }
			set {
				if (withEventsField_cmdAddSumCriteria != null) {
					withEventsField_cmdAddSumCriteria.Click -= cmdAddSumCriteria_Click;
				}
				withEventsField_cmdAddSumCriteria = value;
				if (withEventsField_cmdAddSumCriteria != null) {
					withEventsField_cmdAddSumCriteria.Click += cmdAddSumCriteria_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdChangeOrAndSumCriteria;
		public System.Windows.Forms.Button cmdChangeOrAndSumCriteria {
			get { return withEventsField_cmdChangeOrAndSumCriteria; }
			set {
				if (withEventsField_cmdChangeOrAndSumCriteria != null) {
					withEventsField_cmdChangeOrAndSumCriteria.Click -= cmdChangeOrAndSumCriteria_Click;
				}
				withEventsField_cmdChangeOrAndSumCriteria = value;
				if (withEventsField_cmdChangeOrAndSumCriteria != null) {
					withEventsField_cmdChangeOrAndSumCriteria.Click += cmdChangeOrAndSumCriteria_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemoveSumCriteria;
		public System.Windows.Forms.Button cmdRemoveSumCriteria {
			get { return withEventsField_cmdRemoveSumCriteria; }
			set {
				if (withEventsField_cmdRemoveSumCriteria != null) {
					withEventsField_cmdRemoveSumCriteria.Click -= cmdRemoveSumCriteria_Click;
				}
				withEventsField_cmdRemoveSumCriteria = value;
				if (withEventsField_cmdRemoveSumCriteria != null) {
					withEventsField_cmdRemoveSumCriteria.Click += cmdRemoveSumCriteria_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstSelectedSumCriteria;
		private System.Windows.Forms.Button withEventsField_cmdChangeReportAndOrSumCriteria;
		public System.Windows.Forms.Button cmdChangeReportAndOrSumCriteria {
			get { return withEventsField_cmdChangeReportAndOrSumCriteria; }
			set {
				if (withEventsField_cmdChangeReportAndOrSumCriteria != null) {
					withEventsField_cmdChangeReportAndOrSumCriteria.Click -= cmdChangeReportAndOrSumCriteria_Click;
				}
				withEventsField_cmdChangeReportAndOrSumCriteria = value;
				if (withEventsField_cmdChangeReportAndOrSumCriteria != null) {
					withEventsField_cmdChangeReportAndOrSumCriteria.Click += cmdChangeReportAndOrSumCriteria_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdCopySumCriteria;
		public System.Windows.Forms.Button cmdCopySumCriteria {
			get { return withEventsField_cmdCopySumCriteria; }
			set {
				if (withEventsField_cmdCopySumCriteria != null) {
					withEventsField_cmdCopySumCriteria.Click -= cmdCopySumCriteria_Click;
				}
				withEventsField_cmdCopySumCriteria = value;
				if (withEventsField_cmdCopySumCriteria != null) {
					withEventsField_cmdCopySumCriteria.Click += cmdCopySumCriteria_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDuplSumCriteria;
		public System.Windows.Forms.Button cmdDuplSumCriteria {
			get { return withEventsField_cmdDuplSumCriteria; }
			set {
				if (withEventsField_cmdDuplSumCriteria != null) {
					withEventsField_cmdDuplSumCriteria.Click -= cmdDuplSumCriteria_Click;
				}
				withEventsField_cmdDuplSumCriteria = value;
				if (withEventsField_cmdDuplSumCriteria != null) {
					withEventsField_cmdDuplSumCriteria.Click += cmdDuplSumCriteria_Click;
				}
			}
		}
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.TabPage _sstabReportSpec_TabPage2;
		public System.Windows.Forms.TabControl sstabReportSpec;
		private System.Windows.Forms.ComboBox withEventsField_cboTableList;
		public System.Windows.Forms.ComboBox cboTableList {
			get { return withEventsField_cboTableList; }
			set {
				if (withEventsField_cboTableList != null) {
					withEventsField_cboTableList.SelectedIndexChanged -= cboTableList_SelectedIndexChanged;
				}
				withEventsField_cboTableList = value;
				if (withEventsField_cboTableList != null) {
					withEventsField_cboTableList.SelectedIndexChanged += cboTableList_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.ComboBox withEventsField_cboReportList;
		public System.Windows.Forms.ComboBox cboReportList {
			get { return withEventsField_cboReportList; }
			set {
				if (withEventsField_cboReportList != null) {
					withEventsField_cboReportList.SelectedIndexChanged -= cboReportList_SelectedIndexChanged;
				}
				withEventsField_cboReportList = value;
				if (withEventsField_cboReportList != null) {
					withEventsField_cboReportList.SelectedIndexChanged += cboReportList_SelectedIndexChanged;
				}
			}
		}
		public AxMSRDC.AxMSRDC rdcHelp;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmReportSetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdDup = new System.Windows.Forms.Button();
			this.cmdRenameReport = new System.Windows.Forms.Button();
			this.cmdChangeStatus = new System.Windows.Forms.Button();
			this.cmdHelp = new System.Windows.Forms.Button();
			this.txtHelp = new System.Windows.Forms.TextBox();
			this.dtHelp = new System.Windows.Forms.Label();
			this.rdcReports = new AxMSRDC.AxMSRDC();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdNewReport = new System.Windows.Forms.Button();
			this.cmdDeleteReport = new System.Windows.Forms.Button();
			this.sstabReportSpec = new System.Windows.Forms.TabControl();
			this._sstabReportSpec_TabPage0 = new System.Windows.Forms.TabPage();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.lstAvailableFieldList = new System.Windows.Forms.ListBox();
			this.cmdMoveFieldup = new System.Windows.Forms.Button();
			this.cmdMoveFieldDown = new System.Windows.Forms.Button();
			this.cmdAddField = new System.Windows.Forms.Button();
			this.cmdRemoveField = new System.Windows.Forms.Button();
			this.lstSelectedFieldList = new System.Windows.Forms.ListBox();
			this.cmdRenameField = new System.Windows.Forms.Button();
			this._sstabReportSpec_TabPage1 = new System.Windows.Forms.TabPage();
			this.cmdDuplCriteria = new System.Windows.Forms.Button();
			this.cmdCopyCriteria = new System.Windows.Forms.Button();
			this.cmdChangeReportAndOr = new System.Windows.Forms.Button();
			this.lstSelectedCriteria = new System.Windows.Forms.ListBox();
			this.cmdRemove = new System.Windows.Forms.Button();
			this.cmdChangeOrAnd = new System.Windows.Forms.Button();
			this.cmdAddCriteria = new System.Windows.Forms.Button();
			this.Label8 = new System.Windows.Forms.Label();
			this._sstabReportSpec_TabPage2 = new System.Windows.Forms.TabPage();
			this.cmdAddSumCriteria = new System.Windows.Forms.Button();
			this.cmdChangeOrAndSumCriteria = new System.Windows.Forms.Button();
			this.cmdRemoveSumCriteria = new System.Windows.Forms.Button();
			this.lstSelectedSumCriteria = new System.Windows.Forms.ListBox();
			this.cmdChangeReportAndOrSumCriteria = new System.Windows.Forms.Button();
			this.cmdCopySumCriteria = new System.Windows.Forms.Button();
			this.cmdDuplSumCriteria = new System.Windows.Forms.Button();
			this.Label3 = new System.Windows.Forms.Label();
			this.cboTableList = new System.Windows.Forms.ComboBox();
			this.cboReportList = new System.Windows.Forms.ComboBox();
			this.rdcHelp = new AxMSRDC.AxMSRDC();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.sstabReportSpec.SuspendLayout();
			this._sstabReportSpec_TabPage0.SuspendLayout();
			this._sstabReportSpec_TabPage1.SuspendLayout();
			this._sstabReportSpec_TabPage2.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.rdcReports).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcHelp).BeginInit();
			this.Text = "System Report Setup";
			this.ClientSize = new System.Drawing.Size(875, 689);
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
			this.Name = "frmReportSetup";
			this.cmdDup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDup.Text = "Duplicate Report";
			this.cmdDup.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDup.Size = new System.Drawing.Size(155, 35);
			this.cmdDup.Location = new System.Drawing.Point(550, 640);
			this.cmdDup.TabIndex = 37;
			this.cmdDup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDup.CausesValidation = true;
			this.cmdDup.Enabled = true;
			this.cmdDup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDup.TabStop = true;
			this.cmdDup.Name = "cmdDup";
			this.cmdRenameReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRenameReport.Text = "Rename Report";
			this.cmdRenameReport.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRenameReport.Size = new System.Drawing.Size(125, 45);
			this.cmdRenameReport.Location = new System.Drawing.Point(730, 10);
			this.cmdRenameReport.TabIndex = 25;
			this.cmdRenameReport.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRenameReport.CausesValidation = true;
			this.cmdRenameReport.Enabled = true;
			this.cmdRenameReport.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRenameReport.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRenameReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRenameReport.TabStop = true;
			this.cmdRenameReport.Name = "cmdRenameReport";
			this.cmdChangeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeStatus.Text = "Change Status";
			this.cmdChangeStatus.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeStatus.Size = new System.Drawing.Size(112, 44);
			this.cmdChangeStatus.Location = new System.Drawing.Point(409, 638);
			this.cmdChangeStatus.TabIndex = 24;
			this.cmdChangeStatus.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeStatus.CausesValidation = true;
			this.cmdChangeStatus.Enabled = true;
			this.cmdChangeStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeStatus.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeStatus.TabStop = true;
			this.cmdChangeStatus.Name = "cmdChangeStatus";
			this.cmdHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdHelp.Text = "? Help on Field";
			this.cmdHelp.Size = new System.Drawing.Size(330, 22);
			this.cmdHelp.Location = new System.Drawing.Point(22, 727);
			this.cmdHelp.TabIndex = 18;
			this.cmdHelp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdHelp.BackColor = System.Drawing.SystemColors.Control;
			this.cmdHelp.CausesValidation = true;
			this.cmdHelp.Enabled = true;
			this.cmdHelp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdHelp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdHelp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdHelp.TabStop = true;
			this.cmdHelp.Name = "cmdHelp";
			this.txtHelp.AutoSize = false;
			this.txtHelp.Size = new System.Drawing.Size(103, 25);
			this.txtHelp.Location = new System.Drawing.Point(579, 690);
			this.txtHelp.TabIndex = 17;
			this.txtHelp.Visible = false;
			this.txtHelp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtHelp.AcceptsReturn = true;
			this.txtHelp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtHelp.BackColor = System.Drawing.SystemColors.Window;
			this.txtHelp.CausesValidation = true;
			this.txtHelp.Enabled = true;
			this.txtHelp.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtHelp.HideSelection = true;
			this.txtHelp.ReadOnly = false;
			this.txtHelp.MaxLength = 0;
			this.txtHelp.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtHelp.Multiline = false;
			this.txtHelp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtHelp.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtHelp.TabStop = true;
			this.txtHelp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtHelp.Name = "txtHelp";
			this.dtHelp.Text = "dtaHelp";
			this.dtHelp.Size = new System.Drawing.Size(90, 29);
			this.dtHelp.Location = new System.Drawing.Point(603, 719);
			this.dtHelp.Visible = false;
			this.dtHelp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.dtHelp.BackColor = System.Drawing.Color.Red;
			this.dtHelp.ForeColor = System.Drawing.Color.Black;
			this.dtHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dtHelp.Text = "dtHelp";
			this.dtHelp.Name = "dtHelp";
			rdcReports.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcReports.OcxState");
			this.rdcReports.Size = new System.Drawing.Size(278, 28);
			this.rdcReports.Location = new System.Drawing.Point(15, 693);
			this.rdcReports.Visible = false;
			this.rdcReports.Name = "rdcReports";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "Close";
			this.cmdClose.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdClose.Size = new System.Drawing.Size(112, 24);
			this.cmdClose.Location = new System.Drawing.Point(730, 640);
			this.cmdClose.TabIndex = 10;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.TabStop = true;
			this.cmdClose.Name = "cmdClose";
			this.cmdNewReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNewReport.Text = "New Report";
			this.cmdNewReport.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdNewReport.Size = new System.Drawing.Size(178, 34);
			this.cmdNewReport.Location = new System.Drawing.Point(12, 637);
			this.cmdNewReport.TabIndex = 9;
			this.cmdNewReport.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNewReport.CausesValidation = true;
			this.cmdNewReport.Enabled = true;
			this.cmdNewReport.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNewReport.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNewReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNewReport.TabStop = true;
			this.cmdNewReport.Name = "cmdNewReport";
			this.cmdDeleteReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDeleteReport.Text = "Delete Report";
			this.cmdDeleteReport.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDeleteReport.Size = new System.Drawing.Size(190, 34);
			this.cmdDeleteReport.Location = new System.Drawing.Point(200, 638);
			this.cmdDeleteReport.TabIndex = 8;
			this.cmdDeleteReport.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDeleteReport.CausesValidation = true;
			this.cmdDeleteReport.Enabled = true;
			this.cmdDeleteReport.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDeleteReport.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDeleteReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDeleteReport.TabStop = true;
			this.cmdDeleteReport.Name = "cmdDeleteReport";
			this.sstabReportSpec.Size = new System.Drawing.Size(833, 542);
			this.sstabReportSpec.Location = new System.Drawing.Point(20, 70);
			this.sstabReportSpec.TabIndex = 4;
			this.sstabReportSpec.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabReportSpec.Enabled = false;
			this.sstabReportSpec.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabReportSpec.Name = "sstabReportSpec";
			this._sstabReportSpec_TabPage0.Text = "Report Fields";
			this.Label5.Text = "Select Up to 10 Fields From the List:";
			this.Label5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label5.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.Label5.Size = new System.Drawing.Size(268, 22);
			this.Label5.Location = new System.Drawing.Point(27, 54);
			this.Label5.TabIndex = 11;
			this.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label5.BackColor = System.Drawing.SystemColors.Control;
			this.Label5.Enabled = true;
			this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label5.UseMnemonic = true;
			this.Label5.Visible = true;
			this.Label5.AutoSize = false;
			this.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label5.Name = "Label5";
			this.Label6.Text = "Selected Field for The Report";
			this.Label6.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label6.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.Label6.Size = new System.Drawing.Size(225, 22);
			this.Label6.Location = new System.Drawing.Point(372, 52);
			this.Label6.TabIndex = 12;
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
			this.lstAvailableFieldList.Size = new System.Drawing.Size(348, 432);
			this.lstAvailableFieldList.Location = new System.Drawing.Point(20, 78);
			this.lstAvailableFieldList.TabIndex = 5;
			this.lstAvailableFieldList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstAvailableFieldList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstAvailableFieldList.BackColor = System.Drawing.SystemColors.Window;
			this.lstAvailableFieldList.CausesValidation = true;
			this.lstAvailableFieldList.Enabled = true;
			this.lstAvailableFieldList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstAvailableFieldList.IntegralHeight = true;
			this.lstAvailableFieldList.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstAvailableFieldList.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstAvailableFieldList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstAvailableFieldList.Sorted = false;
			this.lstAvailableFieldList.TabStop = true;
			this.lstAvailableFieldList.Visible = true;
			this.lstAvailableFieldList.MultiColumn = false;
			this.lstAvailableFieldList.Name = "lstAvailableFieldList";
			this.cmdMoveFieldup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveFieldup.Text = "Move Up";
			this.cmdMoveFieldup.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveFieldup.Size = new System.Drawing.Size(89, 24);
			this.cmdMoveFieldup.Location = new System.Drawing.Point(482, 500);
			this.cmdMoveFieldup.TabIndex = 6;
			this.cmdMoveFieldup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveFieldup.CausesValidation = true;
			this.cmdMoveFieldup.Enabled = true;
			this.cmdMoveFieldup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveFieldup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveFieldup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveFieldup.TabStop = true;
			this.cmdMoveFieldup.Name = "cmdMoveFieldup";
			this.cmdMoveFieldDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveFieldDown.Text = "Move Down";
			this.cmdMoveFieldDown.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveFieldDown.Size = new System.Drawing.Size(100, 24);
			this.cmdMoveFieldDown.Location = new System.Drawing.Point(575, 500);
			this.cmdMoveFieldDown.TabIndex = 7;
			this.cmdMoveFieldDown.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveFieldDown.CausesValidation = true;
			this.cmdMoveFieldDown.Enabled = true;
			this.cmdMoveFieldDown.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveFieldDown.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveFieldDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveFieldDown.TabStop = true;
			this.cmdMoveFieldDown.Name = "cmdMoveFieldDown";
			this.cmdAddField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddField.Text = "==>>";
			this.cmdAddField.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddField.Size = new System.Drawing.Size(49, 30);
			this.cmdAddField.Location = new System.Drawing.Point(385, 147);
			this.cmdAddField.TabIndex = 13;
			this.cmdAddField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddField.CausesValidation = true;
			this.cmdAddField.Enabled = true;
			this.cmdAddField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddField.TabStop = true;
			this.cmdAddField.Name = "cmdAddField";
			this.cmdRemoveField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveField.Text = "<<==";
			this.cmdRemoveField.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveField.Size = new System.Drawing.Size(48, 30);
			this.cmdRemoveField.Location = new System.Drawing.Point(387, 184);
			this.cmdRemoveField.TabIndex = 14;
			this.cmdRemoveField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveField.CausesValidation = true;
			this.cmdRemoveField.Enabled = true;
			this.cmdRemoveField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveField.TabStop = true;
			this.cmdRemoveField.Name = "cmdRemoveField";
			this.lstSelectedFieldList.Size = new System.Drawing.Size(364, 415);
			this.lstSelectedFieldList.Location = new System.Drawing.Point(450, 80);
			this.lstSelectedFieldList.TabIndex = 15;
			this.lstSelectedFieldList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstSelectedFieldList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSelectedFieldList.BackColor = System.Drawing.SystemColors.Window;
			this.lstSelectedFieldList.CausesValidation = true;
			this.lstSelectedFieldList.Enabled = true;
			this.lstSelectedFieldList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSelectedFieldList.IntegralHeight = true;
			this.lstSelectedFieldList.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSelectedFieldList.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstSelectedFieldList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSelectedFieldList.Sorted = false;
			this.lstSelectedFieldList.TabStop = true;
			this.lstSelectedFieldList.Visible = true;
			this.lstSelectedFieldList.MultiColumn = false;
			this.lstSelectedFieldList.Name = "lstSelectedFieldList";
			this.cmdRenameField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRenameField.Text = "Rename";
			this.cmdRenameField.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRenameField.Size = new System.Drawing.Size(85, 24);
			this.cmdRenameField.Location = new System.Drawing.Point(680, 500);
			this.cmdRenameField.TabIndex = 16;
			this.cmdRenameField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRenameField.CausesValidation = true;
			this.cmdRenameField.Enabled = true;
			this.cmdRenameField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRenameField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRenameField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRenameField.TabStop = true;
			this.cmdRenameField.Name = "cmdRenameField";
			this._sstabReportSpec_TabPage1.Text = "Report Criteria";
			this.cmdDuplCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDuplCriteria.Text = "Duplicate Criteria Set";
			this.cmdDuplCriteria.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDuplCriteria.Size = new System.Drawing.Size(288, 25);
			this.cmdDuplCriteria.Location = new System.Drawing.Point(334, 508);
			this.cmdDuplCriteria.TabIndex = 28;
			this.cmdDuplCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDuplCriteria.CausesValidation = true;
			this.cmdDuplCriteria.Enabled = true;
			this.cmdDuplCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDuplCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDuplCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDuplCriteria.TabStop = true;
			this.cmdDuplCriteria.Name = "cmdDuplCriteria";
			this.cmdCopyCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCopyCriteria.Text = "Copy Criteria";
			this.cmdCopyCriteria.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCopyCriteria.Size = new System.Drawing.Size(148, 24);
			this.cmdCopyCriteria.Location = new System.Drawing.Point(489, 44);
			this.cmdCopyCriteria.TabIndex = 27;
			this.cmdCopyCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCopyCriteria.CausesValidation = true;
			this.cmdCopyCriteria.Enabled = true;
			this.cmdCopyCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCopyCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCopyCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCopyCriteria.TabStop = true;
			this.cmdCopyCriteria.Name = "cmdCopyCriteria";
			this.cmdChangeReportAndOr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeReportAndOr.Text = "Change Or/And Between All the Sets";
			this.cmdChangeReportAndOr.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeReportAndOr.Size = new System.Drawing.Size(293, 25);
			this.cmdChangeReportAndOr.Location = new System.Drawing.Point(12, 508);
			this.cmdChangeReportAndOr.TabIndex = 26;
			this.cmdChangeReportAndOr.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeReportAndOr.CausesValidation = true;
			this.cmdChangeReportAndOr.Enabled = true;
			this.cmdChangeReportAndOr.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeReportAndOr.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeReportAndOr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeReportAndOr.TabStop = true;
			this.cmdChangeReportAndOr.Name = "cmdChangeReportAndOr";
			this.lstSelectedCriteria.Size = new System.Drawing.Size(795, 399);
			this.lstSelectedCriteria.Location = new System.Drawing.Point(22, 72);
			this.lstSelectedCriteria.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstSelectedCriteria.TabIndex = 22;
			this.lstSelectedCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstSelectedCriteria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSelectedCriteria.BackColor = System.Drawing.SystemColors.Window;
			this.lstSelectedCriteria.CausesValidation = true;
			this.lstSelectedCriteria.Enabled = true;
			this.lstSelectedCriteria.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSelectedCriteria.IntegralHeight = true;
			this.lstSelectedCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSelectedCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSelectedCriteria.Sorted = false;
			this.lstSelectedCriteria.TabStop = true;
			this.lstSelectedCriteria.Visible = true;
			this.lstSelectedCriteria.MultiColumn = false;
			this.lstSelectedCriteria.Name = "lstSelectedCriteria";
			this.cmdRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemove.Text = "Remove Criteria";
			this.cmdRemove.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemove.Size = new System.Drawing.Size(148, 24);
			this.cmdRemove.Location = new System.Drawing.Point(337, 44);
			this.cmdRemove.TabIndex = 21;
			this.cmdRemove.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemove.CausesValidation = true;
			this.cmdRemove.Enabled = true;
			this.cmdRemove.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemove.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemove.TabStop = true;
			this.cmdRemove.Name = "cmdRemove";
			this.cmdChangeOrAnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeOrAnd.Text = "Change Or/And of the Criteria Set";
			this.cmdChangeOrAnd.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeOrAnd.Size = new System.Drawing.Size(293, 24);
			this.cmdChangeOrAnd.Location = new System.Drawing.Point(12, 483);
			this.cmdChangeOrAnd.TabIndex = 20;
			this.cmdChangeOrAnd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeOrAnd.CausesValidation = true;
			this.cmdChangeOrAnd.Enabled = true;
			this.cmdChangeOrAnd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeOrAnd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeOrAnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeOrAnd.TabStop = true;
			this.cmdChangeOrAnd.Name = "cmdChangeOrAnd";
			this.cmdAddCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddCriteria.Text = "Add Criteria";
			this.cmdAddCriteria.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddCriteria.Size = new System.Drawing.Size(148, 24);
			this.cmdAddCriteria.Location = new System.Drawing.Point(185, 44);
			this.cmdAddCriteria.TabIndex = 19;
			this.cmdAddCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddCriteria.CausesValidation = true;
			this.cmdAddCriteria.Enabled = true;
			this.cmdAddCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddCriteria.TabStop = true;
			this.cmdAddCriteria.Name = "cmdAddCriteria";
			this.Label8.Text = "Criteria";
			this.Label8.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label8.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.Label8.Size = new System.Drawing.Size(82, 15);
			this.Label8.Location = new System.Drawing.Point(32, 47);
			this.Label8.TabIndex = 23;
			this.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label8.BackColor = System.Drawing.Color.Transparent;
			this.Label8.Enabled = true;
			this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label8.UseMnemonic = true;
			this.Label8.Visible = true;
			this.Label8.AutoSize = false;
			this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label8.Name = "Label8";
			this._sstabReportSpec_TabPage2.Text = "Summarization Criteria";
			this.cmdAddSumCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddSumCriteria.Text = "Add Criteria";
			this.cmdAddSumCriteria.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddSumCriteria.Size = new System.Drawing.Size(148, 24);
			this.cmdAddSumCriteria.Location = new System.Drawing.Point(185, 44);
			this.cmdAddSumCriteria.TabIndex = 35;
			this.cmdAddSumCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddSumCriteria.CausesValidation = true;
			this.cmdAddSumCriteria.Enabled = true;
			this.cmdAddSumCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddSumCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddSumCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddSumCriteria.TabStop = true;
			this.cmdAddSumCriteria.Name = "cmdAddSumCriteria";
			this.cmdChangeOrAndSumCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeOrAndSumCriteria.Text = "Change Or/And of the Criteria Set";
			this.cmdChangeOrAndSumCriteria.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeOrAndSumCriteria.Size = new System.Drawing.Size(293, 24);
			this.cmdChangeOrAndSumCriteria.Location = new System.Drawing.Point(22, 473);
			this.cmdChangeOrAndSumCriteria.TabIndex = 34;
			this.cmdChangeOrAndSumCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeOrAndSumCriteria.CausesValidation = true;
			this.cmdChangeOrAndSumCriteria.Enabled = true;
			this.cmdChangeOrAndSumCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeOrAndSumCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeOrAndSumCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeOrAndSumCriteria.TabStop = true;
			this.cmdChangeOrAndSumCriteria.Name = "cmdChangeOrAndSumCriteria";
			this.cmdRemoveSumCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveSumCriteria.Text = "Remove Criteria";
			this.cmdRemoveSumCriteria.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveSumCriteria.Size = new System.Drawing.Size(148, 24);
			this.cmdRemoveSumCriteria.Location = new System.Drawing.Point(337, 44);
			this.cmdRemoveSumCriteria.TabIndex = 33;
			this.cmdRemoveSumCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveSumCriteria.CausesValidation = true;
			this.cmdRemoveSumCriteria.Enabled = true;
			this.cmdRemoveSumCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveSumCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveSumCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveSumCriteria.TabStop = true;
			this.cmdRemoveSumCriteria.Name = "cmdRemoveSumCriteria";
			this.lstSelectedSumCriteria.Size = new System.Drawing.Size(795, 383);
			this.lstSelectedSumCriteria.Location = new System.Drawing.Point(22, 72);
			this.lstSelectedSumCriteria.TabIndex = 32;
			this.lstSelectedSumCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstSelectedSumCriteria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSelectedSumCriteria.BackColor = System.Drawing.SystemColors.Window;
			this.lstSelectedSumCriteria.CausesValidation = true;
			this.lstSelectedSumCriteria.Enabled = true;
			this.lstSelectedSumCriteria.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSelectedSumCriteria.IntegralHeight = true;
			this.lstSelectedSumCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSelectedSumCriteria.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstSelectedSumCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSelectedSumCriteria.Sorted = false;
			this.lstSelectedSumCriteria.TabStop = true;
			this.lstSelectedSumCriteria.Visible = true;
			this.lstSelectedSumCriteria.MultiColumn = false;
			this.lstSelectedSumCriteria.Name = "lstSelectedSumCriteria";
			this.cmdChangeReportAndOrSumCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeReportAndOrSumCriteria.Text = "Change Or/And Between All the Sets";
			this.cmdChangeReportAndOrSumCriteria.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeReportAndOrSumCriteria.Size = new System.Drawing.Size(293, 25);
			this.cmdChangeReportAndOrSumCriteria.Location = new System.Drawing.Point(22, 498);
			this.cmdChangeReportAndOrSumCriteria.TabIndex = 31;
			this.cmdChangeReportAndOrSumCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeReportAndOrSumCriteria.CausesValidation = true;
			this.cmdChangeReportAndOrSumCriteria.Enabled = true;
			this.cmdChangeReportAndOrSumCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeReportAndOrSumCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeReportAndOrSumCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeReportAndOrSumCriteria.TabStop = true;
			this.cmdChangeReportAndOrSumCriteria.Name = "cmdChangeReportAndOrSumCriteria";
			this.cmdCopySumCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCopySumCriteria.Text = "Copy Criteria";
			this.cmdCopySumCriteria.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCopySumCriteria.Size = new System.Drawing.Size(148, 24);
			this.cmdCopySumCriteria.Location = new System.Drawing.Point(489, 44);
			this.cmdCopySumCriteria.TabIndex = 30;
			this.cmdCopySumCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCopySumCriteria.CausesValidation = true;
			this.cmdCopySumCriteria.Enabled = true;
			this.cmdCopySumCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCopySumCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCopySumCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCopySumCriteria.TabStop = true;
			this.cmdCopySumCriteria.Name = "cmdCopySumCriteria";
			this.cmdDuplSumCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDuplSumCriteria.Text = "Duplicate Criteria Set";
			this.cmdDuplSumCriteria.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDuplSumCriteria.Size = new System.Drawing.Size(288, 25);
			this.cmdDuplSumCriteria.Location = new System.Drawing.Point(344, 498);
			this.cmdDuplSumCriteria.TabIndex = 29;
			this.cmdDuplSumCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDuplSumCriteria.CausesValidation = true;
			this.cmdDuplSumCriteria.Enabled = true;
			this.cmdDuplSumCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDuplSumCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDuplSumCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDuplSumCriteria.TabStop = true;
			this.cmdDuplSumCriteria.Name = "cmdDuplSumCriteria";
			this.Label3.Text = "Criteria";
			this.Label3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label3.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.Label3.Size = new System.Drawing.Size(82, 15);
			this.Label3.Location = new System.Drawing.Point(32, 47);
			this.Label3.TabIndex = 36;
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label3.BackColor = System.Drawing.Color.Transparent;
			this.Label3.Enabled = true;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.cboTableList.Enabled = false;
			this.cboTableList.Size = new System.Drawing.Size(497, 27);
			this.cboTableList.Location = new System.Drawing.Point(95, 40);
			this.cboTableList.TabIndex = 2;
			this.cboTableList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboTableList.BackColor = System.Drawing.SystemColors.Window;
			this.cboTableList.CausesValidation = true;
			this.cboTableList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboTableList.IntegralHeight = true;
			this.cboTableList.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboTableList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboTableList.Sorted = false;
			this.cboTableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboTableList.TabStop = true;
			this.cboTableList.Visible = true;
			this.cboTableList.Name = "cboTableList";
			this.cboReportList.Size = new System.Drawing.Size(499, 27);
			this.cboReportList.Location = new System.Drawing.Point(93, 5);
			this.cboReportList.TabIndex = 0;
			this.cboReportList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboReportList.BackColor = System.Drawing.SystemColors.Window;
			this.cboReportList.CausesValidation = true;
			this.cboReportList.Enabled = true;
			this.cboReportList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboReportList.IntegralHeight = true;
			this.cboReportList.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboReportList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboReportList.Sorted = false;
			this.cboReportList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboReportList.TabStop = true;
			this.cboReportList.Visible = true;
			this.cboReportList.Name = "cboReportList";
			rdcHelp.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcHelp.OcxState");
			this.rdcHelp.Size = new System.Drawing.Size(278, 28);
			this.rdcHelp.Location = new System.Drawing.Point(294, 693);
			this.rdcHelp.Visible = false;
			this.rdcHelp.Name = "rdcHelp";
			this.Label2.Text = "Table:";
			this.Label2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.Size = new System.Drawing.Size(59, 23);
			this.Label2.Location = new System.Drawing.Point(29, 43);
			this.Label2.TabIndex = 3;
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
			this.Label1.Text = "Reports:";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.Size = new System.Drawing.Size(62, 24);
			this.Label1.Location = new System.Drawing.Point(28, 9);
			this.Label1.TabIndex = 1;
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
			((System.ComponentModel.ISupportInitialize)this.rdcHelp).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcReports).EndInit();
			this.Controls.Add(cmdDup);
			this.Controls.Add(cmdRenameReport);
			this.Controls.Add(cmdChangeStatus);
			this.Controls.Add(cmdHelp);
			this.Controls.Add(txtHelp);
			this.Controls.Add(dtHelp);
			this.Controls.Add(rdcReports);
			this.Controls.Add(cmdClose);
			this.Controls.Add(cmdNewReport);
			this.Controls.Add(cmdDeleteReport);
			this.Controls.Add(sstabReportSpec);
			this.Controls.Add(cboTableList);
			this.Controls.Add(cboReportList);
			this.Controls.Add(rdcHelp);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.sstabReportSpec.Controls.Add(_sstabReportSpec_TabPage0);
			this.sstabReportSpec.Controls.Add(_sstabReportSpec_TabPage1);
			this.sstabReportSpec.Controls.Add(_sstabReportSpec_TabPage2);
			this._sstabReportSpec_TabPage0.Controls.Add(Label5);
			this._sstabReportSpec_TabPage0.Controls.Add(Label6);
			this._sstabReportSpec_TabPage0.Controls.Add(lstAvailableFieldList);
			this._sstabReportSpec_TabPage0.Controls.Add(cmdMoveFieldup);
			this._sstabReportSpec_TabPage0.Controls.Add(cmdMoveFieldDown);
			this._sstabReportSpec_TabPage0.Controls.Add(cmdAddField);
			this._sstabReportSpec_TabPage0.Controls.Add(cmdRemoveField);
			this._sstabReportSpec_TabPage0.Controls.Add(lstSelectedFieldList);
			this._sstabReportSpec_TabPage0.Controls.Add(cmdRenameField);
			this._sstabReportSpec_TabPage1.Controls.Add(cmdDuplCriteria);
			this._sstabReportSpec_TabPage1.Controls.Add(cmdCopyCriteria);
			this._sstabReportSpec_TabPage1.Controls.Add(cmdChangeReportAndOr);
			this._sstabReportSpec_TabPage1.Controls.Add(lstSelectedCriteria);
			this._sstabReportSpec_TabPage1.Controls.Add(cmdRemove);
			this._sstabReportSpec_TabPage1.Controls.Add(cmdChangeOrAnd);
			this._sstabReportSpec_TabPage1.Controls.Add(cmdAddCriteria);
			this._sstabReportSpec_TabPage1.Controls.Add(Label8);
			this._sstabReportSpec_TabPage2.Controls.Add(cmdAddSumCriteria);
			this._sstabReportSpec_TabPage2.Controls.Add(cmdChangeOrAndSumCriteria);
			this._sstabReportSpec_TabPage2.Controls.Add(cmdRemoveSumCriteria);
			this._sstabReportSpec_TabPage2.Controls.Add(lstSelectedSumCriteria);
			this._sstabReportSpec_TabPage2.Controls.Add(cmdChangeReportAndOrSumCriteria);
			this._sstabReportSpec_TabPage2.Controls.Add(cmdCopySumCriteria);
			this._sstabReportSpec_TabPage2.Controls.Add(cmdDuplSumCriteria);
			this._sstabReportSpec_TabPage2.Controls.Add(Label3);
			this.sstabReportSpec.ResumeLayout(false);
			this._sstabReportSpec_TabPage0.ResumeLayout(false);
			this._sstabReportSpec_TabPage1.ResumeLayout(false);
			this._sstabReportSpec_TabPage2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
