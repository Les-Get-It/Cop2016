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
	partial class OldfrmHospStatSetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmHospStatSetup() : base()
		{
			Load += frmHospStatSetup_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdMoveSecUp;
		public System.Windows.Forms.Button cmdMoveSecUp {
			get { return withEventsField_cmdMoveSecUp; }
			set {
				if (withEventsField_cmdMoveSecUp != null) {
					withEventsField_cmdMoveSecUp.Click -= cmdMoveSecUp_Click;
				}
				withEventsField_cmdMoveSecUp = value;
				if (withEventsField_cmdMoveSecUp != null) {
					withEventsField_cmdMoveSecUp.Click += cmdMoveSecUp_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdMoveSectionDown;
		public System.Windows.Forms.Button cmdMoveSectionDown {
			get { return withEventsField_cmdMoveSectionDown; }
			set {
				if (withEventsField_cmdMoveSectionDown != null) {
					withEventsField_cmdMoveSectionDown.Click -= cmdMoveSectionDown_Click;
				}
				withEventsField_cmdMoveSectionDown = value;
				if (withEventsField_cmdMoveSectionDown != null) {
					withEventsField_cmdMoveSectionDown.Click += cmdMoveSectionDown_Click;
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
		private System.Windows.Forms.ComboBox withEventsField_cboIndicatorGroup;
		public System.Windows.Forms.ComboBox cboIndicatorGroup {
			get { return withEventsField_cboIndicatorGroup; }
			set {
				if (withEventsField_cboIndicatorGroup != null) {
					withEventsField_cboIndicatorGroup.TextChanged -= cboIndicatorGroup_TextChanged;
					withEventsField_cboIndicatorGroup.SelectedIndexChanged -= cboIndicatorGroup_SelectedIndexChanged;
				}
				withEventsField_cboIndicatorGroup = value;
				if (withEventsField_cboIndicatorGroup != null) {
					withEventsField_cboIndicatorGroup.TextChanged += cboIndicatorGroup_TextChanged;
					withEventsField_cboIndicatorGroup.SelectedIndexChanged += cboIndicatorGroup_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdNewGroup;
		public System.Windows.Forms.Button cmdNewGroup {
			get { return withEventsField_cmdNewGroup; }
			set {
				if (withEventsField_cmdNewGroup != null) {
					withEventsField_cmdNewGroup.Click -= cmdNewGroup_Click;
				}
				withEventsField_cmdNewGroup = value;
				if (withEventsField_cmdNewGroup != null) {
					withEventsField_cmdNewGroup.Click += cmdNewGroup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdEditGroup;
		public System.Windows.Forms.Button cmdEditGroup {
			get { return withEventsField_cmdEditGroup; }
			set {
				if (withEventsField_cmdEditGroup != null) {
					withEventsField_cmdEditGroup.Click -= cmdEditGroup_Click;
				}
				withEventsField_cmdEditGroup = value;
				if (withEventsField_cmdEditGroup != null) {
					withEventsField_cmdEditGroup.Click += cmdEditGroup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDelGroup;
		public System.Windows.Forms.Button cmdDelGroup {
			get { return withEventsField_cmdDelGroup; }
			set {
				if (withEventsField_cmdDelGroup != null) {
					withEventsField_cmdDelGroup.Click -= cmdDelGroup_Click;
				}
				withEventsField_cmdDelGroup = value;
				if (withEventsField_cmdDelGroup != null) {
					withEventsField_cmdDelGroup.Click += cmdDelGroup_Click;
				}
			}
		}
		private System.Windows.Forms.ListBox withEventsField_lstHospStatGroup;
		public System.Windows.Forms.ListBox lstHospStatGroup {
			get { return withEventsField_lstHospStatGroup; }
			set {
				if (withEventsField_lstHospStatGroup != null) {
					withEventsField_lstHospStatGroup.SelectedIndexChanged -= lstHospStatGroup_SelectedIndexChanged;
				}
				withEventsField_lstHospStatGroup = value;
				if (withEventsField_lstHospStatGroup != null) {
					withEventsField_lstHospStatGroup.SelectedIndexChanged += lstHospStatGroup_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.ListBox lstHospStatGroupFields;
		private System.Windows.Forms.Button withEventsField_cmdAddFieldToGroup;
		public System.Windows.Forms.Button cmdAddFieldToGroup {
			get { return withEventsField_cmdAddFieldToGroup; }
			set {
				if (withEventsField_cmdAddFieldToGroup != null) {
					withEventsField_cmdAddFieldToGroup.Click -= cmdAddFieldToGroup_Click;
				}
				withEventsField_cmdAddFieldToGroup = value;
				if (withEventsField_cmdAddFieldToGroup != null) {
					withEventsField_cmdAddFieldToGroup.Click += cmdAddFieldToGroup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemoveFieldFromGroup;
		public System.Windows.Forms.Button cmdRemoveFieldFromGroup {
			get { return withEventsField_cmdRemoveFieldFromGroup; }
			set {
				if (withEventsField_cmdRemoveFieldFromGroup != null) {
					withEventsField_cmdRemoveFieldFromGroup.Click -= cmdRemoveFieldFromGroup_Click;
				}
				withEventsField_cmdRemoveFieldFromGroup = value;
				if (withEventsField_cmdRemoveFieldFromGroup != null) {
					withEventsField_cmdRemoveFieldFromGroup.Click += cmdRemoveFieldFromGroup_Click;
				}
			}
		}
		public System.Windows.Forms.TabPage _sstabGroupDetails_TabPage0;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.ListBox lstFieldIndicator;
		private System.Windows.Forms.Button withEventsField_cmdLinkIndicator;
		public System.Windows.Forms.Button cmdLinkIndicator {
			get { return withEventsField_cmdLinkIndicator; }
			set {
				if (withEventsField_cmdLinkIndicator != null) {
					withEventsField_cmdLinkIndicator.Click -= cmdLinkIndicator_Click;
				}
				withEventsField_cmdLinkIndicator = value;
				if (withEventsField_cmdLinkIndicator != null) {
					withEventsField_cmdLinkIndicator.Click += cmdLinkIndicator_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemoveFieldIndicator;
		public System.Windows.Forms.Button cmdRemoveFieldIndicator {
			get { return withEventsField_cmdRemoveFieldIndicator; }
			set {
				if (withEventsField_cmdRemoveFieldIndicator != null) {
					withEventsField_cmdRemoveFieldIndicator.Click -= cmdRemoveFieldIndicator_Click;
				}
				withEventsField_cmdRemoveFieldIndicator = value;
				if (withEventsField_cmdRemoveFieldIndicator != null) {
					withEventsField_cmdRemoveFieldIndicator.Click += cmdRemoveFieldIndicator_Click;
				}
			}
		}
		public System.Windows.Forms.TabPage _sstabGroupDetails_TabPage1;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.TextBox txtValEffDate;
		public System.Windows.Forms.ComboBox cboGroupList;
		public System.Windows.Forms.ComboBox cboOperator;
		public System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Button withEventsField_cmdAddValWarning;
		public System.Windows.Forms.Button cmdAddValWarning {
			get { return withEventsField_cmdAddValWarning; }
			set {
				if (withEventsField_cmdAddValWarning != null) {
					withEventsField_cmdAddValWarning.Click -= cmdAddValWarning_Click;
				}
				withEventsField_cmdAddValWarning = value;
				if (withEventsField_cmdAddValWarning != null) {
					withEventsField_cmdAddValWarning.Click += cmdAddValWarning_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddValErr;
		public System.Windows.Forms.Button cmdAddValErr {
			get { return withEventsField_cmdAddValErr; }
			set {
				if (withEventsField_cmdAddValErr != null) {
					withEventsField_cmdAddValErr.Click -= cmdAddValErr_Click;
				}
				withEventsField_cmdAddValErr = value;
				if (withEventsField_cmdAddValErr != null) {
					withEventsField_cmdAddValErr.Click += cmdAddValErr_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemoveValidation;
		public System.Windows.Forms.Button cmdRemoveValidation {
			get { return withEventsField_cmdRemoveValidation; }
			set {
				if (withEventsField_cmdRemoveValidation != null) {
					withEventsField_cmdRemoveValidation.Click -= cmdRemoveValidation_Click;
				}
				withEventsField_cmdRemoveValidation = value;
				if (withEventsField_cmdRemoveValidation != null) {
					withEventsField_cmdRemoveValidation.Click += cmdRemoveValidation_Click;
				}
			}
		}
		public System.Windows.Forms.TabPage _sstabGroupDetails_TabPage2;
		public System.Windows.Forms.TabControl sstabGroupDetails;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.TabPage _sstabMainTab_TabPage0;
		public System.Windows.Forms.Label Label6;
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
		private System.Windows.Forms.Button withEventsField_cmdMoveToAbsPosition;
		public System.Windows.Forms.Button cmdMoveToAbsPosition {
			get { return withEventsField_cmdMoveToAbsPosition; }
			set {
				if (withEventsField_cmdMoveToAbsPosition != null) {
					withEventsField_cmdMoveToAbsPosition.Click -= cmdMoveToAbsPosition_Click;
				}
				withEventsField_cmdMoveToAbsPosition = value;
				if (withEventsField_cmdMoveToAbsPosition != null) {
					withEventsField_cmdMoveToAbsPosition.Click += cmdMoveToAbsPosition_Click;
				}
			}
		}
		public System.Windows.Forms.TabPage _sstabMainTab_TabPage1;
		private System.Windows.Forms.TabControl withEventsField_sstabMainTab;
		public System.Windows.Forms.TabControl sstabMainTab {
			get { return withEventsField_sstabMainTab; }
			set {
				if (withEventsField_sstabMainTab != null) {
					withEventsField_sstabMainTab.SelectedIndexChanged -= sstabMainTab_SelectedIndexChanged;
				}
				withEventsField_sstabMainTab = value;
				if (withEventsField_sstabMainTab != null) {
					withEventsField_sstabMainTab.SelectedIndexChanged += sstabMainTab_SelectedIndexChanged;
				}
			}
		}
		public AxMSRDC.AxMSRDC rdcHospStatFields;
		public AxMSRDC.AxMSRDC rdcHospStatValid;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmHospStatSetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdChangeStatus = new System.Windows.Forms.Button();
			this.cmdMoveSecUp = new System.Windows.Forms.Button();
			this.cmdMoveSectionDown = new System.Windows.Forms.Button();
			this.cmdNew = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cboIndicatorGroup = new System.Windows.Forms.ComboBox();
			this.sstabMainTab = new System.Windows.Forms.TabControl();
			this._sstabMainTab_TabPage0 = new System.Windows.Forms.TabPage();
			this.cmdNewGroup = new System.Windows.Forms.Button();
			this.cmdEditGroup = new System.Windows.Forms.Button();
			this.cmdDelGroup = new System.Windows.Forms.Button();
			this.lstHospStatGroup = new System.Windows.Forms.ListBox();
			this.sstabGroupDetails = new System.Windows.Forms.TabControl();
			this._sstabGroupDetails_TabPage0 = new System.Windows.Forms.TabPage();
			this.Label3 = new System.Windows.Forms.Label();
			this.lstHospStatGroupFields = new System.Windows.Forms.ListBox();
			this.cmdAddFieldToGroup = new System.Windows.Forms.Button();
			this.cmdRemoveFieldFromGroup = new System.Windows.Forms.Button();
			this._sstabGroupDetails_TabPage1 = new System.Windows.Forms.TabPage();
			this.Label4 = new System.Windows.Forms.Label();
			this.lstFieldIndicator = new System.Windows.Forms.ListBox();
			this.cmdLinkIndicator = new System.Windows.Forms.Button();
			this.cmdRemoveFieldIndicator = new System.Windows.Forms.Button();
			this._sstabGroupDetails_TabPage2 = new System.Windows.Forms.TabPage();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this.txtValEffDate = new System.Windows.Forms.TextBox();
			this.cboGroupList = new System.Windows.Forms.ComboBox();
			this.cboOperator = new System.Windows.Forms.ComboBox();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.cmdAddValWarning = new System.Windows.Forms.Button();
			this.cmdAddValErr = new System.Windows.Forms.Button();
			this.cmdRemoveValidation = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this._sstabMainTab_TabPage1 = new System.Windows.Forms.TabPage();
			this.Label6 = new System.Windows.Forms.Label();
			this.cmdMoveUp = new System.Windows.Forms.Button();
			this.cmdMoveDown = new System.Windows.Forms.Button();
			this.cmdMoveToAbsPosition = new System.Windows.Forms.Button();
			this.rdcHospStatFields = new AxMSRDC.AxMSRDC();
			this.rdcHospStatValid = new AxMSRDC.AxMSRDC();
			this.Label1 = new System.Windows.Forms.Label();
			this.sstabMainTab.SuspendLayout();
			this._sstabMainTab_TabPage0.SuspendLayout();
			this.sstabGroupDetails.SuspendLayout();
			this._sstabGroupDetails_TabPage0.SuspendLayout();
			this._sstabGroupDetails_TabPage1.SuspendLayout();
			this._sstabGroupDetails_TabPage2.SuspendLayout();
			this._sstabMainTab_TabPage1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.rdcHospStatFields).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcHospStatValid).BeginInit();
			this.Text = "Hospital Statistics Setup";
			this.ClientSize = new System.Drawing.Size(775, 512);
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
			this.Name = "frmHospStatSetup";
			this.cmdChangeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeStatus.Text = "Change Status";
			this.cmdChangeStatus.Size = new System.Drawing.Size(124, 25);
			this.cmdChangeStatus.Location = new System.Drawing.Point(474, 38);
			this.cmdChangeStatus.TabIndex = 18;
			this.cmdChangeStatus.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeStatus.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeStatus.CausesValidation = true;
			this.cmdChangeStatus.Enabled = true;
			this.cmdChangeStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeStatus.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeStatus.TabStop = true;
			this.cmdChangeStatus.Name = "cmdChangeStatus";
			this.cmdMoveSecUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveSecUp.Text = "Move Up";
			this.cmdMoveSecUp.Size = new System.Drawing.Size(88, 25);
			this.cmdMoveSecUp.Location = new System.Drawing.Point(289, 38);
			this.cmdMoveSecUp.TabIndex = 25;
			this.cmdMoveSecUp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveSecUp.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveSecUp.CausesValidation = true;
			this.cmdMoveSecUp.Enabled = true;
			this.cmdMoveSecUp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveSecUp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveSecUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveSecUp.TabStop = true;
			this.cmdMoveSecUp.Name = "cmdMoveSecUp";
			this.cmdMoveSectionDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveSectionDown.Text = "Move Down";
			this.cmdMoveSectionDown.Size = new System.Drawing.Size(89, 25);
			this.cmdMoveSectionDown.Location = new System.Drawing.Point(382, 38);
			this.cmdMoveSectionDown.TabIndex = 24;
			this.cmdMoveSectionDown.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveSectionDown.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveSectionDown.CausesValidation = true;
			this.cmdMoveSectionDown.Enabled = true;
			this.cmdMoveSectionDown.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveSectionDown.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveSectionDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveSectionDown.TabStop = true;
			this.cmdMoveSectionDown.Name = "cmdMoveSectionDown";
			this.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNew.Text = "New";
			this.cmdNew.Size = new System.Drawing.Size(64, 25);
			this.cmdNew.Location = new System.Drawing.Point(92, 38);
			this.cmdNew.TabIndex = 4;
			this.cmdNew.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdNew.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNew.CausesValidation = true;
			this.cmdNew.Enabled = true;
			this.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNew.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNew.TabStop = true;
			this.cmdNew.Name = "cmdNew";
			this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEdit.Text = "Edit";
			this.cmdEdit.Size = new System.Drawing.Size(63, 25);
			this.cmdEdit.Location = new System.Drawing.Point(159, 38);
			this.cmdEdit.TabIndex = 3;
			this.cmdEdit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdEdit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEdit.CausesValidation = true;
			this.cmdEdit.Enabled = true;
			this.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEdit.TabStop = true;
			this.cmdEdit.Name = "cmdEdit";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "Delete";
			this.cmdDelete.Size = new System.Drawing.Size(60, 25);
			this.cmdDelete.Location = new System.Drawing.Point(225, 38);
			this.cmdDelete.TabIndex = 2;
			this.cmdDelete.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelete.CausesValidation = true;
			this.cmdDelete.Enabled = true;
			this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelete.TabStop = true;
			this.cmdDelete.Name = "cmdDelete";
			this.cboIndicatorGroup.Size = new System.Drawing.Size(347, 27);
			this.cboIndicatorGroup.Location = new System.Drawing.Point(89, 5);
			this.cboIndicatorGroup.TabIndex = 1;
			this.cboIndicatorGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboIndicatorGroup.BackColor = System.Drawing.SystemColors.Window;
			this.cboIndicatorGroup.CausesValidation = true;
			this.cboIndicatorGroup.Enabled = true;
			this.cboIndicatorGroup.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboIndicatorGroup.IntegralHeight = true;
			this.cboIndicatorGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboIndicatorGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboIndicatorGroup.Sorted = false;
			this.cboIndicatorGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboIndicatorGroup.TabStop = true;
			this.cboIndicatorGroup.Visible = true;
			this.cboIndicatorGroup.Name = "cboIndicatorGroup";
			this.sstabMainTab.Size = new System.Drawing.Size(750, 405);
			this.sstabMainTab.Location = new System.Drawing.Point(14, 77);
			this.sstabMainTab.TabIndex = 0;
			this.sstabMainTab.SelectedIndex = 1;
			this.sstabMainTab.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabMainTab.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabMainTab.Name = "sstabMainTab";
			this._sstabMainTab_TabPage0.Text = "Group Setup";
			this.cmdNewGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNewGroup.Text = "New";
			this.cmdNewGroup.Size = new System.Drawing.Size(60, 25);
			this.cmdNewGroup.Location = new System.Drawing.Point(488, 62);
			this.cmdNewGroup.TabIndex = 9;
			this.cmdNewGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdNewGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNewGroup.CausesValidation = true;
			this.cmdNewGroup.Enabled = true;
			this.cmdNewGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNewGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNewGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNewGroup.TabStop = true;
			this.cmdNewGroup.Name = "cmdNewGroup";
			this.cmdEditGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEditGroup.Text = "Edit";
			this.cmdEditGroup.Size = new System.Drawing.Size(60, 25);
			this.cmdEditGroup.Location = new System.Drawing.Point(554, 62);
			this.cmdEditGroup.TabIndex = 8;
			this.cmdEditGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdEditGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEditGroup.CausesValidation = true;
			this.cmdEditGroup.Enabled = true;
			this.cmdEditGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEditGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEditGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEditGroup.TabStop = true;
			this.cmdEditGroup.Name = "cmdEditGroup";
			this.cmdDelGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelGroup.Text = "Delete";
			this.cmdDelGroup.Size = new System.Drawing.Size(60, 25);
			this.cmdDelGroup.Location = new System.Drawing.Point(619, 62);
			this.cmdDelGroup.TabIndex = 7;
			this.cmdDelGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDelGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelGroup.CausesValidation = true;
			this.cmdDelGroup.Enabled = true;
			this.cmdDelGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelGroup.TabStop = true;
			this.cmdDelGroup.Name = "cmdDelGroup";
			this.lstHospStatGroup.Size = new System.Drawing.Size(427, 56);
			this.lstHospStatGroup.Location = new System.Drawing.Point(40, 65);
			this.lstHospStatGroup.TabIndex = 6;
			this.lstHospStatGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstHospStatGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstHospStatGroup.BackColor = System.Drawing.SystemColors.Window;
			this.lstHospStatGroup.CausesValidation = true;
			this.lstHospStatGroup.Enabled = true;
			this.lstHospStatGroup.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstHospStatGroup.IntegralHeight = true;
			this.lstHospStatGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstHospStatGroup.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstHospStatGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstHospStatGroup.Sorted = false;
			this.lstHospStatGroup.TabStop = true;
			this.lstHospStatGroup.Visible = true;
			this.lstHospStatGroup.MultiColumn = false;
			this.lstHospStatGroup.Name = "lstHospStatGroup";
			this.sstabGroupDetails.Size = new System.Drawing.Size(700, 265);
			this.sstabGroupDetails.Location = new System.Drawing.Point(32, 130);
			this.sstabGroupDetails.TabIndex = 11;
			this.sstabGroupDetails.SelectedIndex = 2;
			this.sstabGroupDetails.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabGroupDetails.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabGroupDetails.Name = "sstabGroupDetails";
			this._sstabGroupDetails_TabPage0.Text = "Fields";
			this.Label3.Text = "Fields for the selected Group:";
			this.Label3.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label3.Size = new System.Drawing.Size(322, 22);
			this.Label3.Location = new System.Drawing.Point(23, 37);
			this.Label3.TabIndex = 13;
			this.Label3.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Enabled = true;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.lstHospStatGroupFields.Size = new System.Drawing.Size(382, 152);
			this.lstHospStatGroupFields.Location = new System.Drawing.Point(20, 53);
			this.lstHospStatGroupFields.TabIndex = 19;
			this.lstHospStatGroupFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstHospStatGroupFields.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstHospStatGroupFields.BackColor = System.Drawing.SystemColors.Window;
			this.lstHospStatGroupFields.CausesValidation = true;
			this.lstHospStatGroupFields.Enabled = true;
			this.lstHospStatGroupFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstHospStatGroupFields.IntegralHeight = true;
			this.lstHospStatGroupFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstHospStatGroupFields.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstHospStatGroupFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstHospStatGroupFields.Sorted = false;
			this.lstHospStatGroupFields.TabStop = true;
			this.lstHospStatGroupFields.Visible = true;
			this.lstHospStatGroupFields.MultiColumn = false;
			this.lstHospStatGroupFields.Name = "lstHospStatGroupFields";
			this.cmdAddFieldToGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddFieldToGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddFieldToGroup.Text = "Add field to group";
			this.cmdAddFieldToGroup.Size = new System.Drawing.Size(193, 29);
			this.cmdAddFieldToGroup.Location = new System.Drawing.Point(409, 140);
			this.cmdAddFieldToGroup.TabIndex = 20;
			this.cmdAddFieldToGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddFieldToGroup.CausesValidation = true;
			this.cmdAddFieldToGroup.Enabled = true;
			this.cmdAddFieldToGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddFieldToGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddFieldToGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddFieldToGroup.TabStop = true;
			this.cmdAddFieldToGroup.Name = "cmdAddFieldToGroup";
			this.cmdRemoveFieldFromGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveFieldFromGroup.Text = "Remove field from group";
			this.cmdRemoveFieldFromGroup.Size = new System.Drawing.Size(193, 29);
			this.cmdRemoveFieldFromGroup.Location = new System.Drawing.Point(409, 174);
			this.cmdRemoveFieldFromGroup.TabIndex = 21;
			this.cmdRemoveFieldFromGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveFieldFromGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveFieldFromGroup.CausesValidation = true;
			this.cmdRemoveFieldFromGroup.Enabled = true;
			this.cmdRemoveFieldFromGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveFieldFromGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveFieldFromGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveFieldFromGroup.TabStop = true;
			this.cmdRemoveFieldFromGroup.Name = "cmdRemoveFieldFromGroup";
			this._sstabGroupDetails_TabPage1.Text = "Indicators";
			this.Label4.Text = "Indicators selected for this field";
			this.Label4.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label4.Size = new System.Drawing.Size(197, 22);
			this.Label4.Location = new System.Drawing.Point(24, 40);
			this.Label4.TabIndex = 14;
			this.Label4.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
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
			this.lstFieldIndicator.Size = new System.Drawing.Size(380, 152);
			this.lstFieldIndicator.Location = new System.Drawing.Point(25, 59);
			this.lstFieldIndicator.TabIndex = 12;
			this.lstFieldIndicator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstFieldIndicator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstFieldIndicator.BackColor = System.Drawing.SystemColors.Window;
			this.lstFieldIndicator.CausesValidation = true;
			this.lstFieldIndicator.Enabled = true;
			this.lstFieldIndicator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstFieldIndicator.IntegralHeight = true;
			this.lstFieldIndicator.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstFieldIndicator.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstFieldIndicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstFieldIndicator.Sorted = false;
			this.lstFieldIndicator.TabStop = true;
			this.lstFieldIndicator.Visible = true;
			this.lstFieldIndicator.MultiColumn = false;
			this.lstFieldIndicator.Name = "lstFieldIndicator";
			this.cmdLinkIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdLinkIndicator.Text = "Link Indicator To Group";
			this.cmdLinkIndicator.Size = new System.Drawing.Size(204, 25);
			this.cmdLinkIndicator.Location = new System.Drawing.Point(423, 133);
			this.cmdLinkIndicator.TabIndex = 22;
			this.cmdLinkIndicator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdLinkIndicator.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLinkIndicator.CausesValidation = true;
			this.cmdLinkIndicator.Enabled = true;
			this.cmdLinkIndicator.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLinkIndicator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLinkIndicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLinkIndicator.TabStop = true;
			this.cmdLinkIndicator.Name = "cmdLinkIndicator";
			this.cmdRemoveFieldIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveFieldIndicator.Text = "Unlink Indicator From Group";
			this.cmdRemoveFieldIndicator.Size = new System.Drawing.Size(208, 25);
			this.cmdRemoveFieldIndicator.Location = new System.Drawing.Point(424, 162);
			this.cmdRemoveFieldIndicator.TabIndex = 23;
			this.cmdRemoveFieldIndicator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveFieldIndicator.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveFieldIndicator.CausesValidation = true;
			this.cmdRemoveFieldIndicator.Enabled = true;
			this.cmdRemoveFieldIndicator.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveFieldIndicator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveFieldIndicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveFieldIndicator.TabStop = true;
			this.cmdRemoveFieldIndicator.Name = "cmdRemoveFieldIndicator";
			this._sstabGroupDetails_TabPage2.Text = "Group Validation";
			this.Label8.Text = "Current Validation";
			this.Label8.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label8.Size = new System.Drawing.Size(113, 18);
			this.Label8.Location = new System.Drawing.Point(19, 137);
			this.Label8.TabIndex = 34;
			this.Label8.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
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
			this.Label7.Text = "Message to display:";
			this.Label7.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label7.Size = new System.Drawing.Size(133, 18);
			this.Label7.Location = new System.Drawing.Point(318, 47);
			this.Label7.TabIndex = 35;
			this.Label7.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
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
			this.Label5.Text = "Eff. Date:";
			this.Label5.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label5.Size = new System.Drawing.Size(63, 18);
			this.Label5.Location = new System.Drawing.Point(358, 112);
			this.Label5.TabIndex = 36;
			this.Label5.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
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
			this.Label9.Text = "Group";
			this.Label9.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label9.Size = new System.Drawing.Size(124, 17);
			this.Label9.Location = new System.Drawing.Point(114, 43);
			this.Label9.TabIndex = 37;
			this.Label9.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label9.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label9.BackColor = System.Drawing.SystemColors.Control;
			this.Label9.Enabled = true;
			this.Label9.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label9.UseMnemonic = true;
			this.Label9.Visible = true;
			this.Label9.AutoSize = false;
			this.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label9.Name = "Label9";
			this.Label10.Text = "Op.";
			this.Label10.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label10.Size = new System.Drawing.Size(28, 18);
			this.Label10.Location = new System.Drawing.Point(60, 43);
			this.Label10.TabIndex = 38;
			this.Label10.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label10.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label10.BackColor = System.Drawing.SystemColors.Control;
			this.Label10.Enabled = true;
			this.Label10.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label10.UseMnemonic = true;
			this.Label10.Visible = true;
			this.Label10.AutoSize = false;
			this.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label10.Name = "Label10";
			this.txtValEffDate.AutoSize = false;
			this.txtValEffDate.Size = new System.Drawing.Size(109, 24);
			this.txtValEffDate.Location = new System.Drawing.Point(425, 109);
			this.txtValEffDate.TabIndex = 26;
			this.txtValEffDate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtValEffDate.AcceptsReturn = true;
			this.txtValEffDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtValEffDate.BackColor = System.Drawing.SystemColors.Window;
			this.txtValEffDate.CausesValidation = true;
			this.txtValEffDate.Enabled = true;
			this.txtValEffDate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtValEffDate.HideSelection = true;
			this.txtValEffDate.ReadOnly = false;
			this.txtValEffDate.MaxLength = 0;
			this.txtValEffDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtValEffDate.Multiline = false;
			this.txtValEffDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtValEffDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtValEffDate.TabStop = true;
			this.txtValEffDate.Visible = true;
			this.txtValEffDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtValEffDate.Name = "txtValEffDate";
			this.cboGroupList.Size = new System.Drawing.Size(198, 27);
			this.cboGroupList.Location = new System.Drawing.Point(108, 65);
			this.cboGroupList.TabIndex = 27;
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
			this.cboOperator.Size = new System.Drawing.Size(50, 27);
			this.cboOperator.Location = new System.Drawing.Point(54, 65);
			this.cboOperator.Items.AddRange(new object[] {
				"=",
				"<>",
				">",
				"<",
				">=",
				"<="
			});
			this.cboOperator.TabIndex = 28;
			this.cboOperator.Text = "<>";
			this.cboOperator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboOperator.BackColor = System.Drawing.SystemColors.Window;
			this.cboOperator.CausesValidation = true;
			this.cboOperator.Enabled = true;
			this.cboOperator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOperator.IntegralHeight = true;
			this.cboOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboOperator.Sorted = false;
			this.cboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboOperator.TabStop = true;
			this.cboOperator.Visible = true;
			this.cboOperator.Name = "cboOperator";
			this.txtMessage.AutoSize = false;
			this.txtMessage.Size = new System.Drawing.Size(220, 39);
			this.txtMessage.Location = new System.Drawing.Point(315, 65);
			this.txtMessage.TabIndex = 29;
			this.txtMessage.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtMessage.AcceptsReturn = true;
			this.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtMessage.BackColor = System.Drawing.SystemColors.Window;
			this.txtMessage.CausesValidation = true;
			this.txtMessage.Enabled = true;
			this.txtMessage.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtMessage.HideSelection = true;
			this.txtMessage.ReadOnly = false;
			this.txtMessage.MaxLength = 0;
			this.txtMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMessage.Multiline = false;
			this.txtMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtMessage.TabStop = true;
			this.txtMessage.Visible = true;
			this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtMessage.Name = "txtMessage";
			this.cmdAddValWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddValWarning.Text = "Add as Warning";
			this.cmdAddValWarning.Size = new System.Drawing.Size(109, 27);
			this.cmdAddValWarning.Location = new System.Drawing.Point(543, 94);
			this.cmdAddValWarning.TabIndex = 30;
			this.cmdAddValWarning.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddValWarning.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddValWarning.CausesValidation = true;
			this.cmdAddValWarning.Enabled = true;
			this.cmdAddValWarning.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddValWarning.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddValWarning.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddValWarning.TabStop = true;
			this.cmdAddValWarning.Name = "cmdAddValWarning";
			this.cmdAddValErr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddValErr.Text = "Add as an Error";
			this.cmdAddValErr.Size = new System.Drawing.Size(109, 27);
			this.cmdAddValErr.Location = new System.Drawing.Point(543, 64);
			this.cmdAddValErr.TabIndex = 31;
			this.cmdAddValErr.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddValErr.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddValErr.CausesValidation = true;
			this.cmdAddValErr.Enabled = true;
			this.cmdAddValErr.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddValErr.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddValErr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddValErr.TabStop = true;
			this.cmdAddValErr.Name = "cmdAddValErr";
			this.cmdRemoveValidation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveValidation.Text = "Remove Validation";
			this.cmdRemoveValidation.Size = new System.Drawing.Size(140, 29);
			this.cmdRemoveValidation.Location = new System.Drawing.Point(133, 130);
			this.cmdRemoveValidation.TabIndex = 32;
			this.cmdRemoveValidation.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveValidation.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveValidation.CausesValidation = true;
			this.cmdRemoveValidation.Enabled = true;
			this.cmdRemoveValidation.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveValidation.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveValidation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveValidation.TabStop = true;
			this.cmdRemoveValidation.Name = "cmdRemoveValidation";
			this.Label2.Text = "Groups (for validation purposes only) (users will not see the groups)";
			this.Label2.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label2.Size = new System.Drawing.Size(429, 19);
			this.Label2.Location = new System.Drawing.Point(42, 43);
			this.Label2.TabIndex = 10;
			this.Label2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
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
			this._sstabMainTab_TabPage1.Text = "All Fields";
			this.Label6.Text = "Fields Display Order";
			this.Label6.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label6.Size = new System.Drawing.Size(322, 22);
			this.Label6.Location = new System.Drawing.Point(77, 45);
			this.Label6.TabIndex = 15;
			this.Label6.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
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
			this.cmdMoveUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveUp.Text = "Move Up";
			this.cmdMoveUp.Size = new System.Drawing.Size(74, 37);
			this.cmdMoveUp.Location = new System.Drawing.Point(610, 190);
			this.cmdMoveUp.TabIndex = 16;
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
			this.cmdMoveDown.Size = new System.Drawing.Size(74, 38);
			this.cmdMoveDown.Location = new System.Drawing.Point(610, 229);
			this.cmdMoveDown.TabIndex = 17;
			this.cmdMoveDown.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveDown.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveDown.CausesValidation = true;
			this.cmdMoveDown.Enabled = true;
			this.cmdMoveDown.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveDown.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveDown.TabStop = true;
			this.cmdMoveDown.Name = "cmdMoveDown";
			this.cmdMoveToAbsPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveToAbsPosition.Text = "Move To a Position";
			this.cmdMoveToAbsPosition.Size = new System.Drawing.Size(73, 45);
			this.cmdMoveToAbsPosition.Location = new System.Drawing.Point(610, 269);
			this.cmdMoveToAbsPosition.TabIndex = 33;
			this.cmdMoveToAbsPosition.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveToAbsPosition.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveToAbsPosition.CausesValidation = true;
			this.cmdMoveToAbsPosition.Enabled = true;
			this.cmdMoveToAbsPosition.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveToAbsPosition.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveToAbsPosition.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveToAbsPosition.TabStop = true;
			this.cmdMoveToAbsPosition.Name = "cmdMoveToAbsPosition";
			rdcHospStatFields.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcHospStatFields.OcxState");
			this.rdcHospStatFields.Size = new System.Drawing.Size(249, 28);
			this.rdcHospStatFields.Location = new System.Drawing.Point(197, 493);
			this.rdcHospStatFields.Visible = false;
			this.rdcHospStatFields.Name = "rdcHospStatFields";
			rdcHospStatValid.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcHospStatValid.OcxState");
			this.rdcHospStatValid.Size = new System.Drawing.Size(178, 28);
			this.rdcHospStatValid.Location = new System.Drawing.Point(14, 492);
			this.rdcHospStatValid.Visible = false;
			this.rdcHospStatValid.Name = "rdcHospStatValid";
			this.Label1.Text = "Section";
			this.Label1.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label1.Size = new System.Drawing.Size(64, 19);
			this.Label1.Location = new System.Drawing.Point(20, 8);
			this.Label1.TabIndex = 5;
			this.Label1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
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
			((System.ComponentModel.ISupportInitialize)this.rdcHospStatValid).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcHospStatFields).EndInit();
			this.Controls.Add(cmdChangeStatus);
			this.Controls.Add(cmdMoveSecUp);
			this.Controls.Add(cmdMoveSectionDown);
			this.Controls.Add(cmdNew);
			this.Controls.Add(cmdEdit);
			this.Controls.Add(cmdDelete);
			this.Controls.Add(cboIndicatorGroup);
			this.Controls.Add(sstabMainTab);
			this.Controls.Add(rdcHospStatFields);
			this.Controls.Add(rdcHospStatValid);
			this.Controls.Add(Label1);
			this.sstabMainTab.Controls.Add(_sstabMainTab_TabPage0);
			this.sstabMainTab.Controls.Add(_sstabMainTab_TabPage1);
			this._sstabMainTab_TabPage0.Controls.Add(cmdNewGroup);
			this._sstabMainTab_TabPage0.Controls.Add(cmdEditGroup);
			this._sstabMainTab_TabPage0.Controls.Add(cmdDelGroup);
			this._sstabMainTab_TabPage0.Controls.Add(lstHospStatGroup);
			this._sstabMainTab_TabPage0.Controls.Add(sstabGroupDetails);
			this._sstabMainTab_TabPage0.Controls.Add(Label2);
			this.sstabGroupDetails.Controls.Add(_sstabGroupDetails_TabPage0);
			this.sstabGroupDetails.Controls.Add(_sstabGroupDetails_TabPage1);
			this.sstabGroupDetails.Controls.Add(_sstabGroupDetails_TabPage2);
			this._sstabGroupDetails_TabPage0.Controls.Add(Label3);
			this._sstabGroupDetails_TabPage0.Controls.Add(lstHospStatGroupFields);
			this._sstabGroupDetails_TabPage0.Controls.Add(cmdAddFieldToGroup);
			this._sstabGroupDetails_TabPage0.Controls.Add(cmdRemoveFieldFromGroup);
			this._sstabGroupDetails_TabPage1.Controls.Add(Label4);
			this._sstabGroupDetails_TabPage1.Controls.Add(lstFieldIndicator);
			this._sstabGroupDetails_TabPage1.Controls.Add(cmdLinkIndicator);
			this._sstabGroupDetails_TabPage1.Controls.Add(cmdRemoveFieldIndicator);
			this._sstabGroupDetails_TabPage2.Controls.Add(Label8);
			this._sstabGroupDetails_TabPage2.Controls.Add(Label7);
			this._sstabGroupDetails_TabPage2.Controls.Add(Label5);
			this._sstabGroupDetails_TabPage2.Controls.Add(Label9);
			this._sstabGroupDetails_TabPage2.Controls.Add(Label10);
			this._sstabGroupDetails_TabPage2.Controls.Add(txtValEffDate);
			this._sstabGroupDetails_TabPage2.Controls.Add(cboGroupList);
			this._sstabGroupDetails_TabPage2.Controls.Add(cboOperator);
			this._sstabGroupDetails_TabPage2.Controls.Add(txtMessage);
			this._sstabGroupDetails_TabPage2.Controls.Add(cmdAddValWarning);
			this._sstabGroupDetails_TabPage2.Controls.Add(cmdAddValErr);
			this._sstabGroupDetails_TabPage2.Controls.Add(cmdRemoveValidation);
			this._sstabMainTab_TabPage1.Controls.Add(Label6);
			this._sstabMainTab_TabPage1.Controls.Add(cmdMoveUp);
			this._sstabMainTab_TabPage1.Controls.Add(cmdMoveDown);
			this._sstabMainTab_TabPage1.Controls.Add(cmdMoveToAbsPosition);
			this.sstabMainTab.ResumeLayout(false);
			this._sstabMainTab_TabPage0.ResumeLayout(false);
			this.sstabGroupDetails.ResumeLayout(false);
			this._sstabGroupDetails_TabPage0.ResumeLayout(false);
			this._sstabGroupDetails_TabPage1.ResumeLayout(false);
			this._sstabGroupDetails_TabPage2.ResumeLayout(false);
			this._sstabMainTab_TabPage1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
