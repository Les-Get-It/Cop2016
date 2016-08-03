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
	partial class OldfrmIndicatorSetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmIndicatorSetup() : base()
		{
			Load += frmIndicatorSetup_Load;
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
		public System.Windows.Forms.Label Label5;
		private System.Windows.Forms.Button withEventsField_cmdDeleteIndicator;
		public System.Windows.Forms.Button cmdDeleteIndicator {
			get { return withEventsField_cmdDeleteIndicator; }
			set {
				if (withEventsField_cmdDeleteIndicator != null) {
					withEventsField_cmdDeleteIndicator.Click -= cmdDeleteIndicator_Click;
				}
				withEventsField_cmdDeleteIndicator = value;
				if (withEventsField_cmdDeleteIndicator != null) {
					withEventsField_cmdDeleteIndicator.Click += cmdDeleteIndicator_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdEditIndicator;
		public System.Windows.Forms.Button cmdEditIndicator {
			get { return withEventsField_cmdEditIndicator; }
			set {
				if (withEventsField_cmdEditIndicator != null) {
					withEventsField_cmdEditIndicator.Click -= cmdEditIndicator_Click;
				}
				withEventsField_cmdEditIndicator = value;
				if (withEventsField_cmdEditIndicator != null) {
					withEventsField_cmdEditIndicator.Click += cmdEditIndicator_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdNewIndicator;
		public System.Windows.Forms.Button cmdNewIndicator {
			get { return withEventsField_cmdNewIndicator; }
			set {
				if (withEventsField_cmdNewIndicator != null) {
					withEventsField_cmdNewIndicator.Click -= cmdNewIndicator_Click;
				}
				withEventsField_cmdNewIndicator = value;
				if (withEventsField_cmdNewIndicator != null) {
					withEventsField_cmdNewIndicator.Click += cmdNewIndicator_Click;
				}
			}
		}
		private System.Windows.Forms.ListBox withEventsField_lstIndicators;
		public System.Windows.Forms.ListBox lstIndicators {
			get { return withEventsField_lstIndicators; }
			set {
				if (withEventsField_lstIndicators != null) {
					withEventsField_lstIndicators.SelectedIndexChanged -= lstIndicators_SelectedIndexChanged;
				}
				withEventsField_lstIndicators = value;
				if (withEventsField_lstIndicators != null) {
					withEventsField_lstIndicators.SelectedIndexChanged += lstIndicators_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemoveDepIndicator;
		public System.Windows.Forms.Button cmdRemoveDepIndicator {
			get { return withEventsField_cmdRemoveDepIndicator; }
			set {
				if (withEventsField_cmdRemoveDepIndicator != null) {
					withEventsField_cmdRemoveDepIndicator.Click -= cmdRemoveDepIndicator_Click;
				}
				withEventsField_cmdRemoveDepIndicator = value;
				if (withEventsField_cmdRemoveDepIndicator != null) {
					withEventsField_cmdRemoveDepIndicator.Click += cmdRemoveDepIndicator_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddDepIndicator;
		public System.Windows.Forms.Button cmdAddDepIndicator {
			get { return withEventsField_cmdAddDepIndicator; }
			set {
				if (withEventsField_cmdAddDepIndicator != null) {
					withEventsField_cmdAddDepIndicator.Click -= cmdAddDepIndicator_Click;
				}
				withEventsField_cmdAddDepIndicator = value;
				if (withEventsField_cmdAddDepIndicator != null) {
					withEventsField_cmdAddDepIndicator.Click += cmdAddDepIndicator_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstRequiredIndicator;
		private System.Windows.Forms.Button withEventsField_cmdEffDate;
		public System.Windows.Forms.Button cmdEffDate {
			get { return withEventsField_cmdEffDate; }
			set {
				if (withEventsField_cmdEffDate != null) {
					withEventsField_cmdEffDate.Click -= cmdEffDate_Click;
				}
				withEventsField_cmdEffDate = value;
				if (withEventsField_cmdEffDate != null) {
					withEventsField_cmdEffDate.Click += cmdEffDate_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemoveEffDate;
		public System.Windows.Forms.Button cmdRemoveEffDate {
			get { return withEventsField_cmdRemoveEffDate; }
			set {
				if (withEventsField_cmdRemoveEffDate != null) {
					withEventsField_cmdRemoveEffDate.Click -= cmdRemoveEffDate_Click;
				}
				withEventsField_cmdRemoveEffDate = value;
				if (withEventsField_cmdRemoveEffDate != null) {
					withEventsField_cmdRemoveEffDate.Click += cmdRemoveEffDate_Click;
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
		public System.Windows.Forms.TabPage _sstabIndicatorList_TabPage0;
		private System.Windows.Forms.Button withEventsField_cmdChangeStatusForset;
		public System.Windows.Forms.Button cmdChangeStatusForset {
			get { return withEventsField_cmdChangeStatusForset; }
			set {
				if (withEventsField_cmdChangeStatusForset != null) {
					withEventsField_cmdChangeStatusForset.Click -= cmdChangeStatusForset_Click;
				}
				withEventsField_cmdChangeStatusForset = value;
				if (withEventsField_cmdChangeStatusForset != null) {
					withEventsField_cmdChangeStatusForset.Click += cmdChangeStatusForset_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstIndicatorSet;
		private System.Windows.Forms.Button withEventsField_cmdAddIndicatorToSet;
		public System.Windows.Forms.Button cmdAddIndicatorToSet {
			get { return withEventsField_cmdAddIndicatorToSet; }
			set {
				if (withEventsField_cmdAddIndicatorToSet != null) {
					withEventsField_cmdAddIndicatorToSet.Click -= cmdAddIndicatorToSet_Click;
				}
				withEventsField_cmdAddIndicatorToSet = value;
				if (withEventsField_cmdAddIndicatorToSet != null) {
					withEventsField_cmdAddIndicatorToSet.Click += cmdAddIndicatorToSet_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemoveIndicatorFromSet;
		public System.Windows.Forms.Button cmdRemoveIndicatorFromSet {
			get { return withEventsField_cmdRemoveIndicatorFromSet; }
			set {
				if (withEventsField_cmdRemoveIndicatorFromSet != null) {
					withEventsField_cmdRemoveIndicatorFromSet.Click -= cmdRemoveIndicatorFromSet_Click;
				}
				withEventsField_cmdRemoveIndicatorFromSet = value;
				if (withEventsField_cmdRemoveIndicatorFromSet != null) {
					withEventsField_cmdRemoveIndicatorFromSet.Click += cmdRemoveIndicatorFromSet_Click;
				}
			}
		}
		private System.Windows.Forms.ComboBox withEventsField_cboIndicatorSet;
		public System.Windows.Forms.ComboBox cboIndicatorSet {
			get { return withEventsField_cboIndicatorSet; }
			set {
				if (withEventsField_cboIndicatorSet != null) {
					withEventsField_cboIndicatorSet.SelectedIndexChanged -= cboIndicatorSet_SelectedIndexChanged;
				}
				withEventsField_cboIndicatorSet = value;
				if (withEventsField_cboIndicatorSet != null) {
					withEventsField_cboIndicatorSet.SelectedIndexChanged += cboIndicatorSet_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddSet;
		public System.Windows.Forms.Button cmdAddSet {
			get { return withEventsField_cmdAddSet; }
			set {
				if (withEventsField_cmdAddSet != null) {
					withEventsField_cmdAddSet.Click -= cmdAddSet_Click;
				}
				withEventsField_cmdAddSet = value;
				if (withEventsField_cmdAddSet != null) {
					withEventsField_cmdAddSet.Click += cmdAddSet_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdEditSet;
		public System.Windows.Forms.Button cmdEditSet {
			get { return withEventsField_cmdEditSet; }
			set {
				if (withEventsField_cmdEditSet != null) {
					withEventsField_cmdEditSet.Click -= cmdEditSet_Click;
				}
				withEventsField_cmdEditSet = value;
				if (withEventsField_cmdEditSet != null) {
					withEventsField_cmdEditSet.Click += cmdEditSet_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDeleteSet;
		public System.Windows.Forms.Button cmdDeleteSet {
			get { return withEventsField_cmdDeleteSet; }
			set {
				if (withEventsField_cmdDeleteSet != null) {
					withEventsField_cmdDeleteSet.Click -= cmdDeleteSet_Click;
				}
				withEventsField_cmdDeleteSet = value;
				if (withEventsField_cmdDeleteSet != null) {
					withEventsField_cmdDeleteSet.Click += cmdDeleteSet_Click;
				}
			}
		}
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.TabPage _sstabIndicatorList_TabPage1;
		public System.Windows.Forms.TabControl sstabIndicatorList;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmIndicatorSetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.sstabIndicatorList = new System.Windows.Forms.TabControl();
			this._sstabIndicatorList_TabPage0 = new System.Windows.Forms.TabPage();
			this.Label5 = new System.Windows.Forms.Label();
			this.cmdDeleteIndicator = new System.Windows.Forms.Button();
			this.cmdEditIndicator = new System.Windows.Forms.Button();
			this.cmdNewIndicator = new System.Windows.Forms.Button();
			this.lstIndicators = new System.Windows.Forms.ListBox();
			this.cmdRemoveDepIndicator = new System.Windows.Forms.Button();
			this.cmdAddDepIndicator = new System.Windows.Forms.Button();
			this.lstRequiredIndicator = new System.Windows.Forms.ListBox();
			this.cmdEffDate = new System.Windows.Forms.Button();
			this.cmdRemoveEffDate = new System.Windows.Forms.Button();
			this.cmdChangeStatus = new System.Windows.Forms.Button();
			this._sstabIndicatorList_TabPage1 = new System.Windows.Forms.TabPage();
			this.cmdChangeStatusForset = new System.Windows.Forms.Button();
			this.lstIndicatorSet = new System.Windows.Forms.ListBox();
			this.cmdAddIndicatorToSet = new System.Windows.Forms.Button();
			this.cmdRemoveIndicatorFromSet = new System.Windows.Forms.Button();
			this.cboIndicatorSet = new System.Windows.Forms.ComboBox();
			this.cmdAddSet = new System.Windows.Forms.Button();
			this.cmdEditSet = new System.Windows.Forms.Button();
			this.cmdDeleteSet = new System.Windows.Forms.Button();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.sstabIndicatorList.SuspendLayout();
			this._sstabIndicatorList_TabPage0.SuspendLayout();
			this._sstabIndicatorList_TabPage1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Indicator Setup";
			this.ClientSize = new System.Drawing.Size(648, 388);
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
			this.Name = "frmIndicatorSetup";
			this.sstabIndicatorList.Size = new System.Drawing.Size(570, 347);
			this.sstabIndicatorList.Location = new System.Drawing.Point(28, 17);
			this.sstabIndicatorList.TabIndex = 0;
			this.sstabIndicatorList.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabIndicatorList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabIndicatorList.Name = "sstabIndicatorList";
			this._sstabIndicatorList_TabPage0.Text = "Indicators";
			this.Label5.Text = "List of indicators that must be selected along with the above indicator";
			this.Label5.Size = new System.Drawing.Size(438, 19);
			this.Label5.Location = new System.Drawing.Point(27, 218);
			this.Label5.TabIndex = 17;
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
			this.cmdDeleteIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDeleteIndicator.Text = "Delete";
			this.cmdDeleteIndicator.Size = new System.Drawing.Size(60, 25);
			this.cmdDeleteIndicator.Location = new System.Drawing.Point(162, 184);
			this.cmdDeleteIndicator.TabIndex = 4;
			this.cmdDeleteIndicator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDeleteIndicator.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDeleteIndicator.CausesValidation = true;
			this.cmdDeleteIndicator.Enabled = true;
			this.cmdDeleteIndicator.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDeleteIndicator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDeleteIndicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDeleteIndicator.TabStop = true;
			this.cmdDeleteIndicator.Name = "cmdDeleteIndicator";
			this.cmdEditIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEditIndicator.Text = "Edit";
			this.cmdEditIndicator.Size = new System.Drawing.Size(63, 25);
			this.cmdEditIndicator.Location = new System.Drawing.Point(97, 184);
			this.cmdEditIndicator.TabIndex = 5;
			this.cmdEditIndicator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdEditIndicator.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEditIndicator.CausesValidation = true;
			this.cmdEditIndicator.Enabled = true;
			this.cmdEditIndicator.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEditIndicator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEditIndicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEditIndicator.TabStop = true;
			this.cmdEditIndicator.Name = "cmdEditIndicator";
			this.cmdNewIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNewIndicator.Text = "New";
			this.cmdNewIndicator.Size = new System.Drawing.Size(64, 25);
			this.cmdNewIndicator.Location = new System.Drawing.Point(28, 184);
			this.cmdNewIndicator.TabIndex = 6;
			this.cmdNewIndicator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdNewIndicator.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNewIndicator.CausesValidation = true;
			this.cmdNewIndicator.Enabled = true;
			this.cmdNewIndicator.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNewIndicator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNewIndicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNewIndicator.TabStop = true;
			this.cmdNewIndicator.Name = "cmdNewIndicator";
			this.lstIndicators.Size = new System.Drawing.Size(483, 139);
			this.lstIndicators.Location = new System.Drawing.Point(27, 47);
			this.lstIndicators.TabIndex = 7;
			this.lstIndicators.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstIndicators.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstIndicators.BackColor = System.Drawing.SystemColors.Window;
			this.lstIndicators.CausesValidation = true;
			this.lstIndicators.Enabled = true;
			this.lstIndicators.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstIndicators.IntegralHeight = true;
			this.lstIndicators.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstIndicators.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstIndicators.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstIndicators.Sorted = false;
			this.lstIndicators.TabStop = true;
			this.lstIndicators.Visible = true;
			this.lstIndicators.MultiColumn = false;
			this.lstIndicators.Name = "lstIndicators";
			this.cmdRemoveDepIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveDepIndicator.Text = "Remove";
			this.cmdRemoveDepIndicator.Size = new System.Drawing.Size(93, 22);
			this.cmdRemoveDepIndicator.Location = new System.Drawing.Point(467, 255);
			this.cmdRemoveDepIndicator.TabIndex = 12;
			this.cmdRemoveDepIndicator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveDepIndicator.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveDepIndicator.CausesValidation = true;
			this.cmdRemoveDepIndicator.Enabled = true;
			this.cmdRemoveDepIndicator.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveDepIndicator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveDepIndicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveDepIndicator.TabStop = true;
			this.cmdRemoveDepIndicator.Name = "cmdRemoveDepIndicator";
			this.cmdAddDepIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddDepIndicator.Text = "Add";
			this.cmdAddDepIndicator.Size = new System.Drawing.Size(93, 22);
			this.cmdAddDepIndicator.Location = new System.Drawing.Point(467, 232);
			this.cmdAddDepIndicator.TabIndex = 13;
			this.cmdAddDepIndicator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddDepIndicator.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddDepIndicator.CausesValidation = true;
			this.cmdAddDepIndicator.Enabled = true;
			this.cmdAddDepIndicator.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddDepIndicator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddDepIndicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddDepIndicator.TabStop = true;
			this.cmdAddDepIndicator.Name = "cmdAddDepIndicator";
			this.lstRequiredIndicator.Size = new System.Drawing.Size(438, 90);
			this.lstRequiredIndicator.Location = new System.Drawing.Point(23, 239);
			this.lstRequiredIndicator.TabIndex = 14;
			this.lstRequiredIndicator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstRequiredIndicator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstRequiredIndicator.BackColor = System.Drawing.SystemColors.Window;
			this.lstRequiredIndicator.CausesValidation = true;
			this.lstRequiredIndicator.Enabled = true;
			this.lstRequiredIndicator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstRequiredIndicator.IntegralHeight = true;
			this.lstRequiredIndicator.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstRequiredIndicator.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstRequiredIndicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstRequiredIndicator.Sorted = false;
			this.lstRequiredIndicator.TabStop = true;
			this.lstRequiredIndicator.Visible = true;
			this.lstRequiredIndicator.MultiColumn = false;
			this.lstRequiredIndicator.Name = "lstRequiredIndicator";
			this.cmdEffDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEffDate.Text = "Edit Eff. Date";
			this.cmdEffDate.Size = new System.Drawing.Size(93, 22);
			this.cmdEffDate.Location = new System.Drawing.Point(467, 279);
			this.cmdEffDate.TabIndex = 18;
			this.cmdEffDate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdEffDate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEffDate.CausesValidation = true;
			this.cmdEffDate.Enabled = true;
			this.cmdEffDate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEffDate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEffDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEffDate.TabStop = true;
			this.cmdEffDate.Name = "cmdEffDate";
			this.cmdRemoveEffDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveEffDate.Text = "Remove Eff. Date";
			this.cmdRemoveEffDate.Size = new System.Drawing.Size(94, 33);
			this.cmdRemoveEffDate.Location = new System.Drawing.Point(465, 304);
			this.cmdRemoveEffDate.TabIndex = 19;
			this.cmdRemoveEffDate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveEffDate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveEffDate.CausesValidation = true;
			this.cmdRemoveEffDate.Enabled = true;
			this.cmdRemoveEffDate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveEffDate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveEffDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveEffDate.TabStop = true;
			this.cmdRemoveEffDate.Name = "cmdRemoveEffDate";
			this.cmdChangeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeStatus.Text = "Change Status";
			this.cmdChangeStatus.Size = new System.Drawing.Size(124, 25);
			this.cmdChangeStatus.Location = new System.Drawing.Point(224, 184);
			this.cmdChangeStatus.TabIndex = 20;
			this.cmdChangeStatus.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeStatus.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeStatus.CausesValidation = true;
			this.cmdChangeStatus.Enabled = true;
			this.cmdChangeStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeStatus.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeStatus.TabStop = true;
			this.cmdChangeStatus.Name = "cmdChangeStatus";
			this._sstabIndicatorList_TabPage1.Text = "Indicator Set Validation";
			this.cmdChangeStatusForset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeStatusForset.Text = "Change Status";
			this.cmdChangeStatusForset.Size = new System.Drawing.Size(192, 25);
			this.cmdChangeStatusForset.Location = new System.Drawing.Point(370, 99);
			this.cmdChangeStatusForset.TabIndex = 21;
			this.cmdChangeStatusForset.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeStatusForset.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeStatusForset.CausesValidation = true;
			this.cmdChangeStatusForset.Enabled = true;
			this.cmdChangeStatusForset.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeStatusForset.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeStatusForset.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeStatusForset.TabStop = true;
			this.cmdChangeStatusForset.Name = "cmdChangeStatusForset";
			this.lstIndicatorSet.Size = new System.Drawing.Size(430, 139);
			this.lstIndicatorSet.Location = new System.Drawing.Point(32, 137);
			this.lstIndicatorSet.TabIndex = 11;
			this.lstIndicatorSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstIndicatorSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstIndicatorSet.BackColor = System.Drawing.SystemColors.Window;
			this.lstIndicatorSet.CausesValidation = true;
			this.lstIndicatorSet.Enabled = true;
			this.lstIndicatorSet.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstIndicatorSet.IntegralHeight = true;
			this.lstIndicatorSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstIndicatorSet.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstIndicatorSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstIndicatorSet.Sorted = false;
			this.lstIndicatorSet.TabStop = true;
			this.lstIndicatorSet.Visible = true;
			this.lstIndicatorSet.MultiColumn = false;
			this.lstIndicatorSet.Name = "lstIndicatorSet";
			this.cmdAddIndicatorToSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddIndicatorToSet.Text = "Add";
			this.cmdAddIndicatorToSet.Size = new System.Drawing.Size(64, 25);
			this.cmdAddIndicatorToSet.Location = new System.Drawing.Point(470, 135);
			this.cmdAddIndicatorToSet.TabIndex = 10;
			this.cmdAddIndicatorToSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddIndicatorToSet.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddIndicatorToSet.CausesValidation = true;
			this.cmdAddIndicatorToSet.Enabled = true;
			this.cmdAddIndicatorToSet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddIndicatorToSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddIndicatorToSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddIndicatorToSet.TabStop = true;
			this.cmdAddIndicatorToSet.Name = "cmdAddIndicatorToSet";
			this.cmdRemoveIndicatorFromSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveIndicatorFromSet.Text = "Remove";
			this.cmdRemoveIndicatorFromSet.Size = new System.Drawing.Size(63, 25);
			this.cmdRemoveIndicatorFromSet.Location = new System.Drawing.Point(472, 163);
			this.cmdRemoveIndicatorFromSet.TabIndex = 9;
			this.cmdRemoveIndicatorFromSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveIndicatorFromSet.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveIndicatorFromSet.CausesValidation = true;
			this.cmdRemoveIndicatorFromSet.Enabled = true;
			this.cmdRemoveIndicatorFromSet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveIndicatorFromSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveIndicatorFromSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveIndicatorFromSet.TabStop = true;
			this.cmdRemoveIndicatorFromSet.Name = "cmdRemoveIndicatorFromSet";
			this.cboIndicatorSet.Size = new System.Drawing.Size(335, 27);
			this.cboIndicatorSet.Location = new System.Drawing.Point(29, 72);
			this.cboIndicatorSet.TabIndex = 8;
			this.cboIndicatorSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboIndicatorSet.BackColor = System.Drawing.SystemColors.Window;
			this.cboIndicatorSet.CausesValidation = true;
			this.cboIndicatorSet.Enabled = true;
			this.cboIndicatorSet.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboIndicatorSet.IntegralHeight = true;
			this.cboIndicatorSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboIndicatorSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboIndicatorSet.Sorted = false;
			this.cboIndicatorSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboIndicatorSet.TabStop = true;
			this.cboIndicatorSet.Visible = true;
			this.cboIndicatorSet.Name = "cboIndicatorSet";
			this.cmdAddSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddSet.Text = "New";
			this.cmdAddSet.Size = new System.Drawing.Size(64, 25);
			this.cmdAddSet.Location = new System.Drawing.Point(370, 72);
			this.cmdAddSet.TabIndex = 3;
			this.cmdAddSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddSet.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddSet.CausesValidation = true;
			this.cmdAddSet.Enabled = true;
			this.cmdAddSet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddSet.TabStop = true;
			this.cmdAddSet.Name = "cmdAddSet";
			this.cmdEditSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEditSet.Text = "Edit";
			this.cmdEditSet.Size = new System.Drawing.Size(63, 25);
			this.cmdEditSet.Location = new System.Drawing.Point(437, 72);
			this.cmdEditSet.TabIndex = 2;
			this.cmdEditSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdEditSet.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEditSet.CausesValidation = true;
			this.cmdEditSet.Enabled = true;
			this.cmdEditSet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEditSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEditSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEditSet.TabStop = true;
			this.cmdEditSet.Name = "cmdEditSet";
			this.cmdDeleteSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDeleteSet.Text = "Delete";
			this.cmdDeleteSet.Size = new System.Drawing.Size(60, 25);
			this.cmdDeleteSet.Location = new System.Drawing.Point(502, 72);
			this.cmdDeleteSet.TabIndex = 1;
			this.cmdDeleteSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDeleteSet.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDeleteSet.CausesValidation = true;
			this.cmdDeleteSet.Enabled = true;
			this.cmdDeleteSet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDeleteSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDeleteSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDeleteSet.TabStop = true;
			this.cmdDeleteSet.Name = "cmdDeleteSet";
			this.Label6.Text = "List of indicators that should be selected altogether.";
			this.Label6.Size = new System.Drawing.Size(405, 22);
			this.Label6.Location = new System.Drawing.Point(32, 113);
			this.Label6.TabIndex = 16;
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
			this.Label2.Text = "Set Description";
			this.Label2.Size = new System.Drawing.Size(263, 18);
			this.Label2.Location = new System.Drawing.Point(32, 52);
			this.Label2.TabIndex = 15;
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
			this.Controls.Add(sstabIndicatorList);
			this.sstabIndicatorList.Controls.Add(_sstabIndicatorList_TabPage0);
			this.sstabIndicatorList.Controls.Add(_sstabIndicatorList_TabPage1);
			this._sstabIndicatorList_TabPage0.Controls.Add(Label5);
			this._sstabIndicatorList_TabPage0.Controls.Add(cmdDeleteIndicator);
			this._sstabIndicatorList_TabPage0.Controls.Add(cmdEditIndicator);
			this._sstabIndicatorList_TabPage0.Controls.Add(cmdNewIndicator);
			this._sstabIndicatorList_TabPage0.Controls.Add(lstIndicators);
			this._sstabIndicatorList_TabPage0.Controls.Add(cmdRemoveDepIndicator);
			this._sstabIndicatorList_TabPage0.Controls.Add(cmdAddDepIndicator);
			this._sstabIndicatorList_TabPage0.Controls.Add(lstRequiredIndicator);
			this._sstabIndicatorList_TabPage0.Controls.Add(cmdEffDate);
			this._sstabIndicatorList_TabPage0.Controls.Add(cmdRemoveEffDate);
			this._sstabIndicatorList_TabPage0.Controls.Add(cmdChangeStatus);
			this._sstabIndicatorList_TabPage1.Controls.Add(cmdChangeStatusForset);
			this._sstabIndicatorList_TabPage1.Controls.Add(lstIndicatorSet);
			this._sstabIndicatorList_TabPage1.Controls.Add(cmdAddIndicatorToSet);
			this._sstabIndicatorList_TabPage1.Controls.Add(cmdRemoveIndicatorFromSet);
			this._sstabIndicatorList_TabPage1.Controls.Add(cboIndicatorSet);
			this._sstabIndicatorList_TabPage1.Controls.Add(cmdAddSet);
			this._sstabIndicatorList_TabPage1.Controls.Add(cmdEditSet);
			this._sstabIndicatorList_TabPage1.Controls.Add(cmdDeleteSet);
			this._sstabIndicatorList_TabPage1.Controls.Add(Label6);
			this._sstabIndicatorList_TabPage1.Controls.Add(Label2);
			this.sstabIndicatorList.ResumeLayout(false);
			this._sstabIndicatorList_TabPage0.ResumeLayout(false);
			this._sstabIndicatorList_TabPage1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
