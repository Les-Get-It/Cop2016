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
	partial class OldfrmMeasureSetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmMeasureSetup() : base()
		{
			Load += frmMeasureSetup_Load;
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
		public System.Windows.Forms.Label _Label2_1;
		public System.Windows.Forms.Label _Label6_1;
		public System.Windows.Forms.Button _cmdDelete_0;
		public System.Windows.Forms.Button _cmdEdit_0;
		public System.Windows.Forms.Button _cmdNew_0;
		private System.Windows.Forms.ComboBox withEventsField_cboMeasureSet;
		public System.Windows.Forms.ComboBox cboMeasureSet {
			get { return withEventsField_cboMeasureSet; }
			set {
				if (withEventsField_cboMeasureSet != null) {
					withEventsField_cboMeasureSet.SelectedIndexChanged -= cboMeasureSet_SelectedIndexChanged;
				}
				withEventsField_cboMeasureSet = value;
				if (withEventsField_cboMeasureSet != null) {
					withEventsField_cboMeasureSet.SelectedIndexChanged += cboMeasureSet_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemoveMeasureFromSet;
		public System.Windows.Forms.Button cmdRemoveMeasureFromSet {
			get { return withEventsField_cmdRemoveMeasureFromSet; }
			set {
				if (withEventsField_cmdRemoveMeasureFromSet != null) {
					withEventsField_cmdRemoveMeasureFromSet.Click -= cmdRemoveMeasureFromSet_Click;
				}
				withEventsField_cmdRemoveMeasureFromSet = value;
				if (withEventsField_cmdRemoveMeasureFromSet != null) {
					withEventsField_cmdRemoveMeasureFromSet.Click += cmdRemoveMeasureFromSet_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddMeasureToSet;
		public System.Windows.Forms.Button cmdAddMeasureToSet {
			get { return withEventsField_cmdAddMeasureToSet; }
			set {
				if (withEventsField_cmdAddMeasureToSet != null) {
					withEventsField_cmdAddMeasureToSet.Click -= cmdAddMeasureToSet_Click;
				}
				withEventsField_cmdAddMeasureToSet = value;
				if (withEventsField_cmdAddMeasureToSet != null) {
					withEventsField_cmdAddMeasureToSet.Click += cmdAddMeasureToSet_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstMeasureSet;
		public System.Windows.Forms.Button _cmdChangeStatus_0;
		public System.Windows.Forms.TabPage _sstabMeasureList_TabPage0;
		public System.Windows.Forms.Button _cmdChangeStatus_1;
		public System.Windows.Forms.Button _cmdNew_1;
		public System.Windows.Forms.Button _cmdEdit_1;
		public System.Windows.Forms.Button _cmdDelete_1;
		public System.Windows.Forms.ListBox lstMeasureCat;
		public System.Windows.Forms.TabPage _sstabMeasureList_TabPage1;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label _Label6_0;
		public System.Windows.Forms.Label lblAvailFields;
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
		private System.Windows.Forms.ListBox withEventsField_lstAvailableFieldList;
		public System.Windows.Forms.ListBox lstAvailableFieldList {
			get { return withEventsField_lstAvailableFieldList; }
			set {
				if (withEventsField_lstAvailableFieldList != null) {
					withEventsField_lstAvailableFieldList.DoubleClick -= lstAvailableFieldList_DoubleClick;
				}
				withEventsField_lstAvailableFieldList = value;
				if (withEventsField_lstAvailableFieldList != null) {
					withEventsField_lstAvailableFieldList.DoubleClick += lstAvailableFieldList_DoubleClick;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_btnUp;
		public System.Windows.Forms.Button btnUp {
			get { return withEventsField_btnUp; }
			set {
				if (withEventsField_btnUp != null) {
					withEventsField_btnUp.Click -= btnUp_Click;
				}
				withEventsField_btnUp = value;
				if (withEventsField_btnUp != null) {
					withEventsField_btnUp.Click += btnUp_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_btnDown;
		public System.Windows.Forms.Button btnDown {
			get { return withEventsField_btnDown; }
			set {
				if (withEventsField_btnDown != null) {
					withEventsField_btnDown.Click -= btnDown_Click;
				}
				withEventsField_btnDown = value;
				if (withEventsField_btnDown != null) {
					withEventsField_btnDown.Click += btnDown_Click;
				}
			}
		}
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.ListBox lstSelectedFieldList;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.GroupBox tabstat;
		public System.Windows.Forms.TabPage _sstabMeasureSpec_TabPage0;
		public System.Windows.Forms.TabControl sstabMeasureSpec;
		private System.Windows.Forms.Button withEventsField_cmdClear;
		public System.Windows.Forms.Button cmdClear {
			get { return withEventsField_cmdClear; }
			set {
				if (withEventsField_cmdClear != null) {
					withEventsField_cmdClear.Click -= cmdClear_Click;
				}
				withEventsField_cmdClear = value;
				if (withEventsField_cmdClear != null) {
					withEventsField_cmdClear.Click += cmdClear_Click;
				}
			}
		}
		private System.Windows.Forms.ComboBox withEventsField_cboMeasure;
		public System.Windows.Forms.ComboBox cboMeasure {
			get { return withEventsField_cboMeasure; }
			set {
				if (withEventsField_cboMeasure != null) {
					withEventsField_cboMeasure.SelectedIndexChanged -= cboMeasure_SelectedIndexChanged;
				}
				withEventsField_cboMeasure = value;
				if (withEventsField_cboMeasure != null) {
					withEventsField_cboMeasure.SelectedIndexChanged += cboMeasure_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.Button _cmdChangeStatus_2;
		public System.Windows.Forms.Button cmdHelp;
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
		public System.Windows.Forms.TabPage _sstabMeasureList_TabPage2;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label11;
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.Label Label13;
		private System.Windows.Forms.TreeView withEventsField_trvAvailFields;
		public System.Windows.Forms.TreeView trvAvailFields {
			get { return withEventsField_trvAvailFields; }
			set {
				if (withEventsField_trvAvailFields != null) {
					withEventsField_trvAvailFields.Click -= trvAvailFields_Click;
					withEventsField_trvAvailFields.MouseDown -= trvAvailFields_MouseDown;
				}
				withEventsField_trvAvailFields = value;
				if (withEventsField_trvAvailFields != null) {
					withEventsField_trvAvailFields.Click += trvAvailFields_Click;
					withEventsField_trvAvailFields.MouseDown += trvAvailFields_MouseDown;
				}
			}
		}
		public System.Windows.Forms.TextBox txtNewGroup;
		private System.Windows.Forms.Button withEventsField_cmdCreateGroup;
		public System.Windows.Forms.Button cmdCreateGroup {
			get { return withEventsField_cmdCreateGroup; }
			set {
				if (withEventsField_cmdCreateGroup != null) {
					withEventsField_cmdCreateGroup.Click -= cmdCreateGroup_Click;
				}
				withEventsField_cmdCreateGroup = value;
				if (withEventsField_cmdCreateGroup != null) {
					withEventsField_cmdCreateGroup.Click += cmdCreateGroup_Click;
				}
			}
		}
		private System.Windows.Forms.TreeView withEventsField_trvGroupedFields;
		public System.Windows.Forms.TreeView trvGroupedFields {
			get { return withEventsField_trvGroupedFields; }
			set {
				if (withEventsField_trvGroupedFields != null) {
					withEventsField_trvGroupedFields.Click -= trvGroupedFields_Click;
					withEventsField_trvGroupedFields.KeyDown -= trvGroupedFields_KeyDown;
					withEventsField_trvGroupedFields.MouseDown -= trvGroupedFields_MouseDown;
				}
				withEventsField_trvGroupedFields = value;
				if (withEventsField_trvGroupedFields != null) {
					withEventsField_trvGroupedFields.Click += trvGroupedFields_Click;
					withEventsField_trvGroupedFields.KeyDown += trvGroupedFields_KeyDown;
					withEventsField_trvGroupedFields.MouseDown += trvGroupedFields_MouseDown;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddRelated;
		public System.Windows.Forms.Button cmdAddRelated {
			get { return withEventsField_cmdAddRelated; }
			set {
				if (withEventsField_cmdAddRelated != null) {
					withEventsField_cmdAddRelated.Click -= cmdAddRelated_Click;
				}
				withEventsField_cmdAddRelated = value;
				if (withEventsField_cmdAddRelated != null) {
					withEventsField_cmdAddRelated.Click += cmdAddRelated_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstRelatedFields;
		public System.Windows.Forms.TabPage _sstabMeasureList_TabPage3;
		public System.Windows.Forms.TextBox txtNewRelatedGroup;
		private System.Windows.Forms.Button withEventsField_cmdCreateRelatedGroup;
		public System.Windows.Forms.Button cmdCreateRelatedGroup {
			get { return withEventsField_cmdCreateRelatedGroup; }
			set {
				if (withEventsField_cmdCreateRelatedGroup != null) {
					withEventsField_cmdCreateRelatedGroup.Click -= cmdCreateRelatedGroup_Click;
				}
				withEventsField_cmdCreateRelatedGroup = value;
				if (withEventsField_cmdCreateRelatedGroup != null) {
					withEventsField_cmdCreateRelatedGroup.Click += cmdCreateRelatedGroup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddSimilarFields;
		public System.Windows.Forms.Button cmdAddSimilarFields {
			get { return withEventsField_cmdAddSimilarFields; }
			set {
				if (withEventsField_cmdAddSimilarFields != null) {
					withEventsField_cmdAddSimilarFields.Click -= cmdAddSimilarFields_Click;
				}
				withEventsField_cmdAddSimilarFields = value;
				if (withEventsField_cmdAddSimilarFields != null) {
					withEventsField_cmdAddSimilarFields.Click += cmdAddSimilarFields_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstRelatedGroupFields;
		private System.Windows.Forms.TreeView withEventsField_trvRelatedFields;
		public System.Windows.Forms.TreeView trvRelatedFields {
			get { return withEventsField_trvRelatedFields; }
			set {
				if (withEventsField_trvRelatedFields != null) {
					withEventsField_trvRelatedFields.Click -= trvRelatedFields_Click;
					withEventsField_trvRelatedFields.KeyDown -= trvRelatedFields_KeyDown;
					withEventsField_trvRelatedFields.MouseDown -= trvRelatedFields_MouseDown;
				}
				withEventsField_trvRelatedFields = value;
				if (withEventsField_trvRelatedFields != null) {
					withEventsField_trvRelatedFields.Click += trvRelatedFields_Click;
					withEventsField_trvRelatedFields.KeyDown += trvRelatedFields_KeyDown;
					withEventsField_trvRelatedFields.MouseDown += trvRelatedFields_MouseDown;
				}
			}
		}
		private System.Windows.Forms.TreeView withEventsField_trvAvailGroupFields;
		public System.Windows.Forms.TreeView trvAvailGroupFields {
			get { return withEventsField_trvAvailGroupFields; }
			set {
				if (withEventsField_trvAvailGroupFields != null) {
					withEventsField_trvAvailGroupFields.Click -= trvAvailGroupFields_Click;
					withEventsField_trvAvailGroupFields.MouseDown -= trvAvailGroupFields_MouseDown;
				}
				withEventsField_trvAvailGroupFields = value;
				if (withEventsField_trvAvailGroupFields != null) {
					withEventsField_trvAvailGroupFields.Click += trvAvailGroupFields_Click;
					withEventsField_trvAvailGroupFields.MouseDown += trvAvailGroupFields_MouseDown;
				}
			}
		}
		public System.Windows.Forms.Label Label17;
		public System.Windows.Forms.Label Label16;
		public System.Windows.Forms.Label Label15;
		public System.Windows.Forms.Label Label14;
		public System.Windows.Forms.TabPage _sstabMeasureList_TabPage4;
		private System.Windows.Forms.TabControl withEventsField_sstabMeasureList;
		public System.Windows.Forms.TabControl sstabMeasureList {
			get { return withEventsField_sstabMeasureList; }
			set {
				if (withEventsField_sstabMeasureList != null) {
					withEventsField_sstabMeasureList.SelectedIndexChanged -= sstabMeasureList_SelectedIndexChanged;
				}
				withEventsField_sstabMeasureList = value;
				if (withEventsField_sstabMeasureList != null) {
					withEventsField_sstabMeasureList.SelectedIndexChanged += sstabMeasureList_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.Label Label10;
		public Microsoft.VisualBasic.Compatibility.VB6.LabelArray Label2;
		public Microsoft.VisualBasic.Compatibility.VB6.LabelArray Label6;
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdChangeStatus;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdChangeStatus {
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
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdDelete;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdDelete {
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
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdEdit;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdEdit {
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
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdNew;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdNew {
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
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmMeasureSetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.sstabMeasureList = new System.Windows.Forms.TabControl();
			this._sstabMeasureList_TabPage0 = new System.Windows.Forms.TabPage();
			this._Label2_1 = new System.Windows.Forms.Label();
			this._Label6_1 = new System.Windows.Forms.Label();
			this._cmdDelete_0 = new System.Windows.Forms.Button();
			this._cmdEdit_0 = new System.Windows.Forms.Button();
			this._cmdNew_0 = new System.Windows.Forms.Button();
			this.cboMeasureSet = new System.Windows.Forms.ComboBox();
			this.cmdRemoveMeasureFromSet = new System.Windows.Forms.Button();
			this.cmdAddMeasureToSet = new System.Windows.Forms.Button();
			this.lstMeasureSet = new System.Windows.Forms.ListBox();
			this._cmdChangeStatus_0 = new System.Windows.Forms.Button();
			this._sstabMeasureList_TabPage1 = new System.Windows.Forms.TabPage();
			this._cmdChangeStatus_1 = new System.Windows.Forms.Button();
			this._cmdNew_1 = new System.Windows.Forms.Button();
			this._cmdEdit_1 = new System.Windows.Forms.Button();
			this._cmdDelete_1 = new System.Windows.Forms.Button();
			this.lstMeasureCat = new System.Windows.Forms.ListBox();
			this._sstabMeasureList_TabPage2 = new System.Windows.Forms.TabPage();
			this.sstabMeasureSpec = new System.Windows.Forms.TabControl();
			this._sstabMeasureSpec_TabPage0 = new System.Windows.Forms.TabPage();
			this.Label1 = new System.Windows.Forms.Label();
			this._Label6_0 = new System.Windows.Forms.Label();
			this.lblAvailFields = new System.Windows.Forms.Label();
			this.cmdAddField = new System.Windows.Forms.Button();
			this.cmdRemoveField = new System.Windows.Forms.Button();
			this.lstAvailableFieldList = new System.Windows.Forms.ListBox();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.btnUp = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.lstSelectedFieldList = new System.Windows.Forms.ListBox();
			this.tabstat = new System.Windows.Forms.GroupBox();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.cmdClear = new System.Windows.Forms.Button();
			this.cboMeasure = new System.Windows.Forms.ComboBox();
			this._cmdChangeStatus_2 = new System.Windows.Forms.Button();
			this.cmdHelp = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this._sstabMeasureList_TabPage3 = new System.Windows.Forms.TabPage();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this.Label13 = new System.Windows.Forms.Label();
			this.trvAvailFields = new System.Windows.Forms.TreeView();
			this.txtNewGroup = new System.Windows.Forms.TextBox();
			this.cmdCreateGroup = new System.Windows.Forms.Button();
			this.trvGroupedFields = new System.Windows.Forms.TreeView();
			this.cmdAddRelated = new System.Windows.Forms.Button();
			this.lstRelatedFields = new System.Windows.Forms.ListBox();
			this._sstabMeasureList_TabPage4 = new System.Windows.Forms.TabPage();
			this.txtNewRelatedGroup = new System.Windows.Forms.TextBox();
			this.cmdCreateRelatedGroup = new System.Windows.Forms.Button();
			this.cmdAddSimilarFields = new System.Windows.Forms.Button();
			this.lstRelatedGroupFields = new System.Windows.Forms.ListBox();
			this.trvRelatedFields = new System.Windows.Forms.TreeView();
			this.trvAvailGroupFields = new System.Windows.Forms.TreeView();
			this.Label17 = new System.Windows.Forms.Label();
			this.Label16 = new System.Windows.Forms.Label();
			this.Label15 = new System.Windows.Forms.Label();
			this.Label14 = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this.Label2 = new Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components);
			this.Label6 = new Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components);
			this.cmdChangeStatus = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.cmdDelete = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.cmdEdit = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.cmdNew = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.sstabMeasureList.SuspendLayout();
			this._sstabMeasureList_TabPage0.SuspendLayout();
			this._sstabMeasureList_TabPage1.SuspendLayout();
			this._sstabMeasureList_TabPage2.SuspendLayout();
			this.sstabMeasureSpec.SuspendLayout();
			this._sstabMeasureSpec_TabPage0.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.tabstat.SuspendLayout();
			this._sstabMeasureList_TabPage3.SuspendLayout();
			this._sstabMeasureList_TabPage4.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.Label2).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.Label6).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdChangeStatus).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdDelete).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdEdit).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdNew).BeginInit();
			this.Text = "Measure Setup";
			this.ClientSize = new System.Drawing.Size(987, 627);
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
			this.Name = "frmMeasureSetup";
			this.sstabMeasureList.Size = new System.Drawing.Size(990, 627);
			this.sstabMeasureList.Location = new System.Drawing.Point(0, 0);
			this.sstabMeasureList.TabIndex = 8;
			this.sstabMeasureList.SelectedIndex = 3;
			this.sstabMeasureList.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabMeasureList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabMeasureList.Name = "sstabMeasureList";
			this._sstabMeasureList_TabPage0.Text = "Measure Sets";
			this._Label2_1.Text = "Set Description";
			this._Label2_1.Size = new System.Drawing.Size(263, 18);
			this._Label2_1.Location = new System.Drawing.Point(13, 65);
			this._Label2_1.TabIndex = 23;
			this._Label2_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._Label2_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label2_1.BackColor = System.Drawing.SystemColors.Control;
			this._Label2_1.Enabled = true;
			this._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label2_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label2_1.UseMnemonic = true;
			this._Label2_1.Visible = true;
			this._Label2_1.AutoSize = false;
			this._Label2_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label2_1.Name = "_Label2_1";
			this._Label6_1.Text = "List of Measures in the Measure Set";
			this._Label6_1.Size = new System.Drawing.Size(405, 22);
			this._Label6_1.Location = new System.Drawing.Point(13, 125);
			this._Label6_1.TabIndex = 24;
			this._Label6_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._Label6_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label6_1.BackColor = System.Drawing.SystemColors.Control;
			this._Label6_1.Enabled = true;
			this._Label6_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label6_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label6_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label6_1.UseMnemonic = true;
			this._Label6_1.Visible = true;
			this._Label6_1.AutoSize = false;
			this._Label6_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label6_1.Name = "_Label6_1";
			this._cmdDelete_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdDelete_0.Text = "Delete";
			this._cmdDelete_0.Size = new System.Drawing.Size(60, 25);
			this._cmdDelete_0.Location = new System.Drawing.Point(713, 85);
			this._cmdDelete_0.TabIndex = 3;
			this._cmdDelete_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdDelete_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdDelete_0.CausesValidation = true;
			this._cmdDelete_0.Enabled = true;
			this._cmdDelete_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdDelete_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdDelete_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdDelete_0.TabStop = true;
			this._cmdDelete_0.Name = "_cmdDelete_0";
			this._cmdEdit_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdEdit_0.Text = "Edit";
			this._cmdEdit_0.Size = new System.Drawing.Size(63, 25);
			this._cmdEdit_0.Location = new System.Drawing.Point(648, 85);
			this._cmdEdit_0.TabIndex = 2;
			this._cmdEdit_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdEdit_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdEdit_0.CausesValidation = true;
			this._cmdEdit_0.Enabled = true;
			this._cmdEdit_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdEdit_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdEdit_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdEdit_0.TabStop = true;
			this._cmdEdit_0.Name = "_cmdEdit_0";
			this._cmdNew_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdNew_0.Text = "New";
			this._cmdNew_0.Size = new System.Drawing.Size(64, 25);
			this._cmdNew_0.Location = new System.Drawing.Point(580, 85);
			this._cmdNew_0.TabIndex = 1;
			this._cmdNew_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdNew_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdNew_0.CausesValidation = true;
			this._cmdNew_0.Enabled = true;
			this._cmdNew_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdNew_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdNew_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdNew_0.TabStop = true;
			this._cmdNew_0.Name = "_cmdNew_0";
			this.cboMeasureSet.Size = new System.Drawing.Size(555, 27);
			this.cboMeasureSet.Location = new System.Drawing.Point(10, 85);
			this.cboMeasureSet.TabIndex = 0;
			this.cboMeasureSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboMeasureSet.BackColor = System.Drawing.SystemColors.Window;
			this.cboMeasureSet.CausesValidation = true;
			this.cboMeasureSet.Enabled = true;
			this.cboMeasureSet.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboMeasureSet.IntegralHeight = true;
			this.cboMeasureSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboMeasureSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboMeasureSet.Sorted = false;
			this.cboMeasureSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboMeasureSet.TabStop = true;
			this.cboMeasureSet.Visible = true;
			this.cboMeasureSet.Name = "cboMeasureSet";
			this.cmdRemoveMeasureFromSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveMeasureFromSet.Text = "Remove";
			this.cmdRemoveMeasureFromSet.Size = new System.Drawing.Size(63, 25);
			this.cmdRemoveMeasureFromSet.Location = new System.Drawing.Point(580, 197);
			this.cmdRemoveMeasureFromSet.TabIndex = 6;
			this.cmdRemoveMeasureFromSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveMeasureFromSet.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveMeasureFromSet.CausesValidation = true;
			this.cmdRemoveMeasureFromSet.Enabled = true;
			this.cmdRemoveMeasureFromSet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveMeasureFromSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveMeasureFromSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveMeasureFromSet.TabStop = true;
			this.cmdRemoveMeasureFromSet.Name = "cmdRemoveMeasureFromSet";
			this.cmdAddMeasureToSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddMeasureToSet.Text = "Add";
			this.cmdAddMeasureToSet.Size = new System.Drawing.Size(64, 25);
			this.cmdAddMeasureToSet.Location = new System.Drawing.Point(580, 169);
			this.cmdAddMeasureToSet.TabIndex = 5;
			this.cmdAddMeasureToSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddMeasureToSet.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddMeasureToSet.CausesValidation = true;
			this.cmdAddMeasureToSet.Enabled = true;
			this.cmdAddMeasureToSet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddMeasureToSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddMeasureToSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddMeasureToSet.TabStop = true;
			this.cmdAddMeasureToSet.Name = "cmdAddMeasureToSet";
			this.lstMeasureSet.Size = new System.Drawing.Size(550, 383);
			this.lstMeasureSet.Location = new System.Drawing.Point(12, 150);
			this.lstMeasureSet.TabIndex = 7;
			this.lstMeasureSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstMeasureSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstMeasureSet.BackColor = System.Drawing.SystemColors.Window;
			this.lstMeasureSet.CausesValidation = true;
			this.lstMeasureSet.Enabled = true;
			this.lstMeasureSet.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstMeasureSet.IntegralHeight = true;
			this.lstMeasureSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstMeasureSet.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstMeasureSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstMeasureSet.Sorted = false;
			this.lstMeasureSet.TabStop = true;
			this.lstMeasureSet.Visible = true;
			this.lstMeasureSet.MultiColumn = false;
			this.lstMeasureSet.Name = "lstMeasureSet";
			this._cmdChangeStatus_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdChangeStatus_0.Text = "Change Status";
			this._cmdChangeStatus_0.Size = new System.Drawing.Size(192, 25);
			this._cmdChangeStatus_0.Location = new System.Drawing.Point(580, 113);
			this._cmdChangeStatus_0.TabIndex = 4;
			this._cmdChangeStatus_0.Visible = false;
			this._cmdChangeStatus_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdChangeStatus_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdChangeStatus_0.CausesValidation = true;
			this._cmdChangeStatus_0.Enabled = true;
			this._cmdChangeStatus_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdChangeStatus_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdChangeStatus_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdChangeStatus_0.TabStop = true;
			this._cmdChangeStatus_0.Name = "_cmdChangeStatus_0";
			this._sstabMeasureList_TabPage1.Text = "Measure Category";
			this._cmdChangeStatus_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdChangeStatus_1.Text = "Change Status";
			this._cmdChangeStatus_1.Size = new System.Drawing.Size(114, 25);
			this._cmdChangeStatus_1.Location = new System.Drawing.Point(460, 325);
			this._cmdChangeStatus_1.TabIndex = 12;
			this._cmdChangeStatus_1.Visible = false;
			this._cmdChangeStatus_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdChangeStatus_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdChangeStatus_1.CausesValidation = true;
			this._cmdChangeStatus_1.Enabled = true;
			this._cmdChangeStatus_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdChangeStatus_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdChangeStatus_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdChangeStatus_1.TabStop = true;
			this._cmdChangeStatus_1.Name = "_cmdChangeStatus_1";
			this._cmdNew_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdNew_1.Text = "New";
			this._cmdNew_1.Size = new System.Drawing.Size(94, 25);
			this._cmdNew_1.Location = new System.Drawing.Point(470, 75);
			this._cmdNew_1.TabIndex = 9;
			this._cmdNew_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdNew_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdNew_1.CausesValidation = true;
			this._cmdNew_1.Enabled = true;
			this._cmdNew_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdNew_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdNew_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdNew_1.TabStop = true;
			this._cmdNew_1.Name = "_cmdNew_1";
			this._cmdEdit_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdEdit_1.Text = "Edit";
			this._cmdEdit_1.Size = new System.Drawing.Size(92, 25);
			this._cmdEdit_1.Location = new System.Drawing.Point(470, 115);
			this._cmdEdit_1.TabIndex = 10;
			this._cmdEdit_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdEdit_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdEdit_1.CausesValidation = true;
			this._cmdEdit_1.Enabled = true;
			this._cmdEdit_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdEdit_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdEdit_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdEdit_1.TabStop = true;
			this._cmdEdit_1.Name = "_cmdEdit_1";
			this._cmdDelete_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdDelete_1.Text = "Delete";
			this._cmdDelete_1.Size = new System.Drawing.Size(90, 25);
			this._cmdDelete_1.Location = new System.Drawing.Point(470, 155);
			this._cmdDelete_1.TabIndex = 11;
			this._cmdDelete_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdDelete_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdDelete_1.CausesValidation = true;
			this._cmdDelete_1.Enabled = true;
			this._cmdDelete_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdDelete_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdDelete_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdDelete_1.TabStop = true;
			this._cmdDelete_1.Name = "_cmdDelete_1";
			this.lstMeasureCat.Size = new System.Drawing.Size(422, 464);
			this.lstMeasureCat.Location = new System.Drawing.Point(10, 75);
			this.lstMeasureCat.TabIndex = 13;
			this.lstMeasureCat.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstMeasureCat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstMeasureCat.BackColor = System.Drawing.SystemColors.Window;
			this.lstMeasureCat.CausesValidation = true;
			this.lstMeasureCat.Enabled = true;
			this.lstMeasureCat.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstMeasureCat.IntegralHeight = true;
			this.lstMeasureCat.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstMeasureCat.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstMeasureCat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstMeasureCat.Sorted = false;
			this.lstMeasureCat.TabStop = true;
			this.lstMeasureCat.Visible = true;
			this.lstMeasureCat.MultiColumn = false;
			this.lstMeasureCat.Name = "lstMeasureCat";
			this._sstabMeasureList_TabPage2.Text = "Map Measure Set Fields";
			this.sstabMeasureSpec.Size = new System.Drawing.Size(932, 502);
			this.sstabMeasureSpec.Location = new System.Drawing.Point(0, 55);
			this.sstabMeasureSpec.TabIndex = 26;
			this.sstabMeasureSpec.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabMeasureSpec.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabMeasureSpec.Name = "sstabMeasureSpec";
			this._sstabMeasureSpec_TabPage0.Text = "Map Measure Set Fields";
			this.Label1.Text = "Measure Set";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.Size = new System.Drawing.Size(92, 22);
			this.Label1.Location = new System.Drawing.Point(30, 30);
			this.Label1.TabIndex = 28;
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
			this._Label6_0.Text = "Selected Elements for the Measure";
			this._Label6_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._Label6_0.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this._Label6_0.Size = new System.Drawing.Size(315, 22);
			this._Label6_0.Location = new System.Drawing.Point(400, 70);
			this._Label6_0.TabIndex = 29;
			this._Label6_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label6_0.BackColor = System.Drawing.SystemColors.Control;
			this._Label6_0.Enabled = true;
			this._Label6_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label6_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label6_0.UseMnemonic = true;
			this._Label6_0.Visible = true;
			this._Label6_0.AutoSize = false;
			this._Label6_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label6_0.Name = "_Label6_0";
			this.lblAvailFields.Text = "Available Fields";
			this.lblAvailFields.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblAvailFields.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.lblAvailFields.Size = new System.Drawing.Size(315, 22);
			this.lblAvailFields.Location = new System.Drawing.Point(10, 70);
			this.lblAvailFields.TabIndex = 36;
			this.lblAvailFields.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblAvailFields.BackColor = System.Drawing.SystemColors.Control;
			this.lblAvailFields.Enabled = true;
			this.lblAvailFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblAvailFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblAvailFields.UseMnemonic = true;
			this.lblAvailFields.Visible = true;
			this.lblAvailFields.AutoSize = false;
			this.lblAvailFields.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblAvailFields.Name = "lblAvailFields";
			this.cmdAddField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddField.Text = "==>>";
			this.cmdAddField.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddField.Size = new System.Drawing.Size(59, 30);
			this.cmdAddField.Location = new System.Drawing.Point(340, 250);
			this.cmdAddField.TabIndex = 16;
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
			this.cmdRemoveField.Size = new System.Drawing.Size(58, 30);
			this.cmdRemoveField.Location = new System.Drawing.Point(340, 300);
			this.cmdRemoveField.TabIndex = 17;
			this.cmdRemoveField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveField.CausesValidation = true;
			this.cmdRemoveField.Enabled = true;
			this.cmdRemoveField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveField.TabStop = true;
			this.cmdRemoveField.Name = "cmdRemoveField";
			this.lstAvailableFieldList.Size = new System.Drawing.Size(317, 350);
			this.lstAvailableFieldList.Location = new System.Drawing.Point(10, 90);
			this.lstAvailableFieldList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstAvailableFieldList.Sorted = true;
			this.lstAvailableFieldList.TabIndex = 15;
			this.lstAvailableFieldList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstAvailableFieldList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstAvailableFieldList.BackColor = System.Drawing.SystemColors.Window;
			this.lstAvailableFieldList.CausesValidation = true;
			this.lstAvailableFieldList.Enabled = true;
			this.lstAvailableFieldList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstAvailableFieldList.IntegralHeight = true;
			this.lstAvailableFieldList.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstAvailableFieldList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstAvailableFieldList.TabStop = true;
			this.lstAvailableFieldList.Visible = true;
			this.lstAvailableFieldList.MultiColumn = false;
			this.lstAvailableFieldList.Name = "lstAvailableFieldList";
			this.Frame1.Size = new System.Drawing.Size(322, 52);
			this.Frame1.Location = new System.Drawing.Point(410, 440);
			this.Frame1.TabIndex = 27;
			this.Frame1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.btnUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnUp.Text = "Move Up";
			this.btnUp.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.btnUp.Size = new System.Drawing.Size(92, 22);
			this.btnUp.Location = new System.Drawing.Point(10, 20);
			this.btnUp.TabIndex = 18;
			this.btnUp.BackColor = System.Drawing.SystemColors.Control;
			this.btnUp.CausesValidation = true;
			this.btnUp.Enabled = true;
			this.btnUp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUp.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnUp.TabStop = true;
			this.btnUp.Name = "btnUp";
			this.btnDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnDown.Text = "Move Down";
			this.btnDown.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.btnDown.Size = new System.Drawing.Size(102, 22);
			this.btnDown.Location = new System.Drawing.Point(120, 20);
			this.btnDown.TabIndex = 19;
			this.btnDown.BackColor = System.Drawing.SystemColors.Control;
			this.btnDown.CausesValidation = true;
			this.btnDown.Enabled = true;
			this.btnDown.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDown.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnDown.TabStop = true;
			this.btnDown.Name = "btnDown";
			this.lstSelectedFieldList.Size = new System.Drawing.Size(317, 350);
			this.lstSelectedFieldList.Location = new System.Drawing.Point(410, 90);
			this.lstSelectedFieldList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstSelectedFieldList.TabIndex = 30;
			this.lstSelectedFieldList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstSelectedFieldList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSelectedFieldList.BackColor = System.Drawing.SystemColors.Window;
			this.lstSelectedFieldList.CausesValidation = true;
			this.lstSelectedFieldList.Enabled = true;
			this.lstSelectedFieldList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSelectedFieldList.IntegralHeight = true;
			this.lstSelectedFieldList.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSelectedFieldList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSelectedFieldList.Sorted = false;
			this.lstSelectedFieldList.TabStop = true;
			this.lstSelectedFieldList.Visible = true;
			this.lstSelectedFieldList.MultiColumn = false;
			this.lstSelectedFieldList.Name = "lstSelectedFieldList";
			this.tabstat.Text = "Static Field Positions";
			this.tabstat.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.tabstat.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.tabstat.Size = new System.Drawing.Size(192, 152);
			this.tabstat.Location = new System.Drawing.Point(730, 80);
			this.tabstat.TabIndex = 31;
			this.tabstat.BackColor = System.Drawing.SystemColors.Control;
			this.tabstat.Enabled = true;
			this.tabstat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.tabstat.Visible = true;
			this.tabstat.Padding = new System.Windows.Forms.Padding(0);
			this.tabstat.Name = "tabstat";
			this.Label8.Text = "1 - Health Care Org ID";
			this.Label8.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label8.Size = new System.Drawing.Size(162, 22);
			this.Label8.Location = new System.Drawing.Point(20, 20);
			this.Label8.TabIndex = 37;
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
			this.Label7.Text = "(These field positions can not be altered)";
			this.Label7.Size = new System.Drawing.Size(172, 42);
			this.Label7.Location = new System.Drawing.Point(10, 100);
			this.Label7.TabIndex = 35;
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
			this.Label5.Text = "Last - Batch No";
			this.Label5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label5.Size = new System.Drawing.Size(162, 22);
			this.Label5.Location = new System.Drawing.Point(20, 80);
			this.Label5.TabIndex = 34;
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
			this.Label4.Text = "2nd to Last - PMSI";
			this.Label4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label4.Size = new System.Drawing.Size(162, 22);
			this.Label4.Location = new System.Drawing.Point(20, 60);
			this.Label4.TabIndex = 33;
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
			this.Label3.Text = "2 - CASE ID";
			this.Label3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label3.Size = new System.Drawing.Size(162, 22);
			this.Label3.Location = new System.Drawing.Point(20, 40);
			this.Label3.TabIndex = 32;
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
			this.cmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClear.Text = "Clear";
			this.cmdClear.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdClear.Size = new System.Drawing.Size(62, 22);
			this.cmdClear.Location = new System.Drawing.Point(660, 515);
			this.cmdClear.TabIndex = 21;
			this.cmdClear.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClear.CausesValidation = true;
			this.cmdClear.Enabled = true;
			this.cmdClear.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClear.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClear.TabStop = true;
			this.cmdClear.Name = "cmdClear";
			this.cboMeasure.Size = new System.Drawing.Size(582, 27);
			this.cboMeasure.Location = new System.Drawing.Point(130, 85);
			this.cboMeasure.TabIndex = 14;
			this.cboMeasure.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboMeasure.BackColor = System.Drawing.SystemColors.Window;
			this.cboMeasure.CausesValidation = true;
			this.cboMeasure.Enabled = true;
			this.cboMeasure.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboMeasure.IntegralHeight = true;
			this.cboMeasure.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboMeasure.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboMeasure.Sorted = false;
			this.cboMeasure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboMeasure.TabStop = true;
			this.cboMeasure.Visible = true;
			this.cboMeasure.Name = "cboMeasure";
			this._cmdChangeStatus_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdChangeStatus_2.Text = "Change Status";
			this._cmdChangeStatus_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdChangeStatus_2.Size = new System.Drawing.Size(132, 33);
			this._cmdChangeStatus_2.Location = new System.Drawing.Point(10, 505);
			this._cmdChangeStatus_2.TabIndex = 22;
			this._cmdChangeStatus_2.Visible = false;
			this._cmdChangeStatus_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdChangeStatus_2.CausesValidation = true;
			this._cmdChangeStatus_2.Enabled = true;
			this._cmdChangeStatus_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdChangeStatus_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdChangeStatus_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdChangeStatus_2.TabStop = true;
			this._cmdChangeStatus_2.Name = "_cmdChangeStatus_2";
			this.cmdHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdHelp.Text = "? Help on Field";
			this.cmdHelp.Size = new System.Drawing.Size(330, 22);
			this.cmdHelp.Location = new System.Drawing.Point(22, 782);
			this.cmdHelp.TabIndex = 25;
			this.cmdHelp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdHelp.BackColor = System.Drawing.SystemColors.Control;
			this.cmdHelp.CausesValidation = true;
			this.cmdHelp.Enabled = true;
			this.cmdHelp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdHelp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdHelp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdHelp.TabStop = true;
			this.cmdHelp.Name = "cmdHelp";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "Close";
			this.cmdClose.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdClose.Size = new System.Drawing.Size(92, 33);
			this.cmdClose.Location = new System.Drawing.Point(820, 505);
			this.cmdClose.TabIndex = 20;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.TabStop = true;
			this.cmdClose.Name = "cmdClose";
			this._sstabMeasureList_TabPage3.Text = "Setup Multiple Occurrence Groups";
			this.Label9.Text = "Multiple Occurrene Groups";
			this.Label9.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label9.Size = new System.Drawing.Size(292, 22);
			this.Label9.Location = new System.Drawing.Point(50, 285);
			this.Label9.TabIndex = 38;
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
			this.Label11.Text = "Available Field List";
			this.Label11.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label11.Size = new System.Drawing.Size(292, 22);
			this.Label11.Location = new System.Drawing.Point(50, 65);
			this.Label11.TabIndex = 40;
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
			this.Label12.Text = "Create New Group Named:";
			this.Label12.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label12.Size = new System.Drawing.Size(292, 22);
			this.Label12.Location = new System.Drawing.Point(60, 565);
			this.Label12.TabIndex = 43;
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
			this.Label13.Text = "Similar Element List";
			this.Label13.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label13.Size = new System.Drawing.Size(292, 22);
			this.Label13.Location = new System.Drawing.Point(490, 60);
			this.Label13.TabIndex = 46;
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
			this.trvAvailFields.CausesValidation = true;
			this.trvAvailFields.Size = new System.Drawing.Size(362, 182);
			this.trvAvailFields.Location = new System.Drawing.Point(50, 85);
			this.trvAvailFields.TabIndex = 41;
			this.trvAvailFields.LabelEdit = false;
			this.trvAvailFields.Sorted = true;
			this.trvAvailFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.trvAvailFields.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.trvAvailFields.Name = "trvAvailFields";
			this.txtNewGroup.AutoSize = false;
			this.txtNewGroup.Size = new System.Drawing.Size(252, 24);
			this.txtNewGroup.Location = new System.Drawing.Point(90, 585);
			this.txtNewGroup.TabIndex = 42;
			this.txtNewGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtNewGroup.AcceptsReturn = true;
			this.txtNewGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtNewGroup.BackColor = System.Drawing.SystemColors.Window;
			this.txtNewGroup.CausesValidation = true;
			this.txtNewGroup.Enabled = true;
			this.txtNewGroup.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNewGroup.HideSelection = true;
			this.txtNewGroup.ReadOnly = false;
			this.txtNewGroup.MaxLength = 0;
			this.txtNewGroup.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtNewGroup.Multiline = false;
			this.txtNewGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtNewGroup.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtNewGroup.TabStop = true;
			this.txtNewGroup.Visible = true;
			this.txtNewGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtNewGroup.Name = "txtNewGroup";
			this.cmdCreateGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCreateGroup.Text = "Create Group";
			this.cmdCreateGroup.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCreateGroup.Size = new System.Drawing.Size(122, 32);
			this.cmdCreateGroup.Location = new System.Drawing.Point(350, 575);
			this.cmdCreateGroup.TabIndex = 44;
			this.cmdCreateGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCreateGroup.CausesValidation = true;
			this.cmdCreateGroup.Enabled = true;
			this.cmdCreateGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCreateGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCreateGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCreateGroup.TabStop = true;
			this.cmdCreateGroup.Name = "cmdCreateGroup";
			this.trvGroupedFields.CausesValidation = true;
			this.trvGroupedFields.Size = new System.Drawing.Size(862, 252);
			this.trvGroupedFields.Location = new System.Drawing.Point(50, 305);
			this.trvGroupedFields.TabIndex = 45;
			this.trvGroupedFields.LabelEdit = false;
			this.trvGroupedFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.trvGroupedFields.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.trvGroupedFields.Name = "trvGroupedFields";
			this.cmdAddRelated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddRelated.Text = "Add Selected Fields to Selected Group";
			this.cmdAddRelated.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddRelated.Size = new System.Drawing.Size(232, 42);
			this.cmdAddRelated.Location = new System.Drawing.Point(490, 245);
			this.cmdAddRelated.TabIndex = 47;
			this.cmdAddRelated.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddRelated.CausesValidation = true;
			this.cmdAddRelated.Enabled = true;
			this.cmdAddRelated.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddRelated.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddRelated.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddRelated.TabStop = true;
			this.cmdAddRelated.Name = "cmdAddRelated";
			this.lstRelatedFields.Size = new System.Drawing.Size(422, 155);
			this.lstRelatedFields.Location = new System.Drawing.Point(490, 85);
			this.lstRelatedFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstRelatedFields.Sorted = true;
			this.lstRelatedFields.TabIndex = 48;
			this.lstRelatedFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstRelatedFields.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstRelatedFields.BackColor = System.Drawing.SystemColors.Window;
			this.lstRelatedFields.CausesValidation = true;
			this.lstRelatedFields.Enabled = true;
			this.lstRelatedFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstRelatedFields.IntegralHeight = true;
			this.lstRelatedFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstRelatedFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstRelatedFields.TabStop = true;
			this.lstRelatedFields.Visible = true;
			this.lstRelatedFields.MultiColumn = false;
			this.lstRelatedFields.Name = "lstRelatedFields";
			this._sstabMeasureList_TabPage4.Text = "Setup Related Element Groups";
			this.txtNewRelatedGroup.AutoSize = false;
			this.txtNewRelatedGroup.Size = new System.Drawing.Size(252, 24);
			this.txtNewRelatedGroup.Location = new System.Drawing.Point(80, 590);
			this.txtNewRelatedGroup.TabIndex = 53;
			this.txtNewRelatedGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtNewRelatedGroup.AcceptsReturn = true;
			this.txtNewRelatedGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtNewRelatedGroup.BackColor = System.Drawing.SystemColors.Window;
			this.txtNewRelatedGroup.CausesValidation = true;
			this.txtNewRelatedGroup.Enabled = true;
			this.txtNewRelatedGroup.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNewRelatedGroup.HideSelection = true;
			this.txtNewRelatedGroup.ReadOnly = false;
			this.txtNewRelatedGroup.MaxLength = 0;
			this.txtNewRelatedGroup.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtNewRelatedGroup.Multiline = false;
			this.txtNewRelatedGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtNewRelatedGroup.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtNewRelatedGroup.TabStop = true;
			this.txtNewRelatedGroup.Visible = true;
			this.txtNewRelatedGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtNewRelatedGroup.Name = "txtNewRelatedGroup";
			this.cmdCreateRelatedGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCreateRelatedGroup.Text = "Create Group";
			this.cmdCreateRelatedGroup.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCreateRelatedGroup.Size = new System.Drawing.Size(122, 32);
			this.cmdCreateRelatedGroup.Location = new System.Drawing.Point(340, 580);
			this.cmdCreateRelatedGroup.TabIndex = 52;
			this.cmdCreateRelatedGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCreateRelatedGroup.CausesValidation = true;
			this.cmdCreateRelatedGroup.Enabled = true;
			this.cmdCreateRelatedGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCreateRelatedGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCreateRelatedGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCreateRelatedGroup.TabStop = true;
			this.cmdCreateRelatedGroup.Name = "cmdCreateRelatedGroup";
			this.cmdAddSimilarFields.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddSimilarFields.Text = "Add Selected Fields to Selected Group";
			this.cmdAddSimilarFields.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddSimilarFields.Size = new System.Drawing.Size(232, 42);
			this.cmdAddSimilarFields.Location = new System.Drawing.Point(480, 250);
			this.cmdAddSimilarFields.TabIndex = 50;
			this.cmdAddSimilarFields.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddSimilarFields.CausesValidation = true;
			this.cmdAddSimilarFields.Enabled = true;
			this.cmdAddSimilarFields.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddSimilarFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddSimilarFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddSimilarFields.TabStop = true;
			this.cmdAddSimilarFields.Name = "cmdAddSimilarFields";
			this.lstRelatedGroupFields.Size = new System.Drawing.Size(422, 155);
			this.lstRelatedGroupFields.Location = new System.Drawing.Point(480, 90);
			this.lstRelatedGroupFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstRelatedGroupFields.Sorted = true;
			this.lstRelatedGroupFields.TabIndex = 49;
			this.lstRelatedGroupFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstRelatedGroupFields.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstRelatedGroupFields.BackColor = System.Drawing.SystemColors.Window;
			this.lstRelatedGroupFields.CausesValidation = true;
			this.lstRelatedGroupFields.Enabled = true;
			this.lstRelatedGroupFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstRelatedGroupFields.IntegralHeight = true;
			this.lstRelatedGroupFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstRelatedGroupFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstRelatedGroupFields.TabStop = true;
			this.lstRelatedGroupFields.Visible = true;
			this.lstRelatedGroupFields.MultiColumn = false;
			this.lstRelatedGroupFields.Name = "lstRelatedGroupFields";
			this.trvRelatedFields.CausesValidation = true;
			this.trvRelatedFields.Size = new System.Drawing.Size(862, 252);
			this.trvRelatedFields.Location = new System.Drawing.Point(40, 310);
			this.trvRelatedFields.TabIndex = 51;
			this.trvRelatedFields.LabelEdit = false;
			this.trvRelatedFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.trvRelatedFields.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.trvRelatedFields.Name = "trvRelatedFields";
			this.trvAvailGroupFields.CausesValidation = true;
			this.trvAvailGroupFields.Size = new System.Drawing.Size(362, 182);
			this.trvAvailGroupFields.Location = new System.Drawing.Point(40, 90);
			this.trvAvailGroupFields.TabIndex = 54;
			this.trvAvailGroupFields.LabelEdit = false;
			this.trvAvailGroupFields.Sorted = true;
			this.trvAvailGroupFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.trvAvailGroupFields.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.trvAvailGroupFields.Name = "trvAvailGroupFields";
			this.Label17.Text = "Related Element Groups";
			this.Label17.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label17.Size = new System.Drawing.Size(292, 22);
			this.Label17.Location = new System.Drawing.Point(40, 290);
			this.Label17.TabIndex = 58;
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
			this.Label16.Text = "Available Field List";
			this.Label16.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label16.Size = new System.Drawing.Size(292, 22);
			this.Label16.Location = new System.Drawing.Point(40, 70);
			this.Label16.TabIndex = 57;
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
			this.Label15.Text = "Create New Group Named:";
			this.Label15.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label15.Size = new System.Drawing.Size(292, 22);
			this.Label15.Location = new System.Drawing.Point(50, 570);
			this.Label15.TabIndex = 56;
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
			this.Label14.Text = "Related Element List";
			this.Label14.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label14.Size = new System.Drawing.Size(292, 22);
			this.Label14.Location = new System.Drawing.Point(480, 70);
			this.Label14.TabIndex = 55;
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
			this.Label10.Text = "Grouped Fields";
			this.Label10.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label10.Size = new System.Drawing.Size(292, 22);
			this.Label10.Location = new System.Drawing.Point(0, 0);
			this.Label10.TabIndex = 39;
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
			this.Label2.SetIndex(_Label2_1, Convert.ToInt16(1));
			this.Label6.SetIndex(_Label6_0, Convert.ToInt16(0));
			this.Label6.SetIndex(_Label6_1, Convert.ToInt16(1));
			this.cmdChangeStatus.SetIndex(_cmdChangeStatus_2, Convert.ToInt16(2));
			this.cmdChangeStatus.SetIndex(_cmdChangeStatus_1, Convert.ToInt16(1));
			this.cmdChangeStatus.SetIndex(_cmdChangeStatus_0, Convert.ToInt16(0));
			this.cmdDelete.SetIndex(_cmdDelete_1, Convert.ToInt16(1));
			this.cmdDelete.SetIndex(_cmdDelete_0, Convert.ToInt16(0));
			this.cmdEdit.SetIndex(_cmdEdit_1, Convert.ToInt16(1));
			this.cmdEdit.SetIndex(_cmdEdit_0, Convert.ToInt16(0));
			this.cmdNew.SetIndex(_cmdNew_1, Convert.ToInt16(1));
			this.cmdNew.SetIndex(_cmdNew_0, Convert.ToInt16(0));
			((System.ComponentModel.ISupportInitialize)this.cmdNew).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmdEdit).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmdDelete).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmdChangeStatus).EndInit();
			((System.ComponentModel.ISupportInitialize)this.Label6).EndInit();
			((System.ComponentModel.ISupportInitialize)this.Label2).EndInit();
			this.Controls.Add(sstabMeasureList);
			this.Controls.Add(Label10);
			this.sstabMeasureList.Controls.Add(_sstabMeasureList_TabPage0);
			this.sstabMeasureList.Controls.Add(_sstabMeasureList_TabPage1);
			this.sstabMeasureList.Controls.Add(_sstabMeasureList_TabPage2);
			this.sstabMeasureList.Controls.Add(_sstabMeasureList_TabPage3);
			this.sstabMeasureList.Controls.Add(_sstabMeasureList_TabPage4);
			this._sstabMeasureList_TabPage0.Controls.Add(_Label2_1);
			this._sstabMeasureList_TabPage0.Controls.Add(_Label6_1);
			this._sstabMeasureList_TabPage0.Controls.Add(_cmdDelete_0);
			this._sstabMeasureList_TabPage0.Controls.Add(_cmdEdit_0);
			this._sstabMeasureList_TabPage0.Controls.Add(_cmdNew_0);
			this._sstabMeasureList_TabPage0.Controls.Add(cboMeasureSet);
			this._sstabMeasureList_TabPage0.Controls.Add(cmdRemoveMeasureFromSet);
			this._sstabMeasureList_TabPage0.Controls.Add(cmdAddMeasureToSet);
			this._sstabMeasureList_TabPage0.Controls.Add(lstMeasureSet);
			this._sstabMeasureList_TabPage0.Controls.Add(_cmdChangeStatus_0);
			this._sstabMeasureList_TabPage1.Controls.Add(_cmdChangeStatus_1);
			this._sstabMeasureList_TabPage1.Controls.Add(_cmdNew_1);
			this._sstabMeasureList_TabPage1.Controls.Add(_cmdEdit_1);
			this._sstabMeasureList_TabPage1.Controls.Add(_cmdDelete_1);
			this._sstabMeasureList_TabPage1.Controls.Add(lstMeasureCat);
			this._sstabMeasureList_TabPage2.Controls.Add(sstabMeasureSpec);
			this._sstabMeasureList_TabPage2.Controls.Add(cmdClear);
			this._sstabMeasureList_TabPage2.Controls.Add(cboMeasure);
			this._sstabMeasureList_TabPage2.Controls.Add(_cmdChangeStatus_2);
			this._sstabMeasureList_TabPage2.Controls.Add(cmdHelp);
			this._sstabMeasureList_TabPage2.Controls.Add(cmdClose);
			this.sstabMeasureSpec.Controls.Add(_sstabMeasureSpec_TabPage0);
			this._sstabMeasureSpec_TabPage0.Controls.Add(Label1);
			this._sstabMeasureSpec_TabPage0.Controls.Add(_Label6_0);
			this._sstabMeasureSpec_TabPage0.Controls.Add(lblAvailFields);
			this._sstabMeasureSpec_TabPage0.Controls.Add(cmdAddField);
			this._sstabMeasureSpec_TabPage0.Controls.Add(cmdRemoveField);
			this._sstabMeasureSpec_TabPage0.Controls.Add(lstAvailableFieldList);
			this._sstabMeasureSpec_TabPage0.Controls.Add(Frame1);
			this._sstabMeasureSpec_TabPage0.Controls.Add(lstSelectedFieldList);
			this._sstabMeasureSpec_TabPage0.Controls.Add(tabstat);
			this.Frame1.Controls.Add(btnUp);
			this.Frame1.Controls.Add(btnDown);
			this.tabstat.Controls.Add(Label8);
			this.tabstat.Controls.Add(Label7);
			this.tabstat.Controls.Add(Label5);
			this.tabstat.Controls.Add(Label4);
			this.tabstat.Controls.Add(Label3);
			this._sstabMeasureList_TabPage3.Controls.Add(Label9);
			this._sstabMeasureList_TabPage3.Controls.Add(Label11);
			this._sstabMeasureList_TabPage3.Controls.Add(Label12);
			this._sstabMeasureList_TabPage3.Controls.Add(Label13);
			this._sstabMeasureList_TabPage3.Controls.Add(trvAvailFields);
			this._sstabMeasureList_TabPage3.Controls.Add(txtNewGroup);
			this._sstabMeasureList_TabPage3.Controls.Add(cmdCreateGroup);
			this._sstabMeasureList_TabPage3.Controls.Add(trvGroupedFields);
			this._sstabMeasureList_TabPage3.Controls.Add(cmdAddRelated);
			this._sstabMeasureList_TabPage3.Controls.Add(lstRelatedFields);
			this._sstabMeasureList_TabPage4.Controls.Add(txtNewRelatedGroup);
			this._sstabMeasureList_TabPage4.Controls.Add(cmdCreateRelatedGroup);
			this._sstabMeasureList_TabPage4.Controls.Add(cmdAddSimilarFields);
			this._sstabMeasureList_TabPage4.Controls.Add(lstRelatedGroupFields);
			this._sstabMeasureList_TabPage4.Controls.Add(trvRelatedFields);
			this._sstabMeasureList_TabPage4.Controls.Add(trvAvailGroupFields);
			this._sstabMeasureList_TabPage4.Controls.Add(Label17);
			this._sstabMeasureList_TabPage4.Controls.Add(Label16);
			this._sstabMeasureList_TabPage4.Controls.Add(Label15);
			this._sstabMeasureList_TabPage4.Controls.Add(Label14);
			this.sstabMeasureList.ResumeLayout(false);
			this._sstabMeasureList_TabPage0.ResumeLayout(false);
			this._sstabMeasureList_TabPage1.ResumeLayout(false);
			this._sstabMeasureList_TabPage2.ResumeLayout(false);
			this.sstabMeasureSpec.ResumeLayout(false);
			this._sstabMeasureSpec_TabPage0.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.tabstat.ResumeLayout(false);
			this._sstabMeasureList_TabPage3.ResumeLayout(false);
			this._sstabMeasureList_TabPage4.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
