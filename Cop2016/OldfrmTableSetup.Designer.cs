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
	partial class OldfrmTableSetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmTableSetup() : base()
		{
			Load += frmTableSetup_Load;
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
		public AxMSDBGrid.AxDBGrid dbgFieldList;
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
		private System.Windows.Forms.Button withEventsField_cmdUpdateDEA;
		public System.Windows.Forms.Button cmdUpdateDEA {
			get { return withEventsField_cmdUpdateDEA; }
			set {
				if (withEventsField_cmdUpdateDEA != null) {
					withEventsField_cmdUpdateDEA.Click -= cmdUpdateDEA_Click;
				}
				withEventsField_cmdUpdateDEA = value;
				if (withEventsField_cmdUpdateDEA != null) {
					withEventsField_cmdUpdateDEA.Click += cmdUpdateDEA_Click;
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
		public System.Windows.Forms.TabPage _tabFields_TabPage0;
		public System.Windows.Forms.TabControl tabFields;
		public AxMSRDC.AxMSRDC rdcTableList;
		public AxMSRDC.AxMSRDC rdcFieldList;
		public AxMSRDC.AxMSRDC rdcValDynFields;
		public AxMSRDC.AxMSRDC rdcFieldReqVal;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmTableSetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cboTableList = new System.Windows.Forms.ComboBox();
			this.cmdClose = new System.Windows.Forms.Button();
			this.tabFields = new System.Windows.Forms.TabControl();
			this._tabFields_TabPage0 = new System.Windows.Forms.TabPage();
			this.cmdAddField = new System.Windows.Forms.Button();
			this.dbgFieldList = new AxMSDBGrid.AxDBGrid();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdChangeStatus = new System.Windows.Forms.Button();
			this.cmdUpdateDEA = new System.Windows.Forms.Button();
			this.cmdMoveDown = new System.Windows.Forms.Button();
			this.cmdMoveUp = new System.Windows.Forms.Button();
			this.rdcTableList = new AxMSRDC.AxMSRDC();
			this.rdcFieldList = new AxMSRDC.AxMSRDC();
			this.rdcValDynFields = new AxMSRDC.AxMSRDC();
			this.rdcFieldReqVal = new AxMSRDC.AxMSRDC();
			this.Label1 = new System.Windows.Forms.Label();
			this.tabFields.SuspendLayout();
			this._tabFields_TabPage0.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.dbgFieldList).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcTableList).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcFieldList).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValDynFields).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcFieldReqVal).BeginInit();
			this.Text = "Table and Field Setup Form";
			this.ClientSize = new System.Drawing.Size(880, 697);
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
			this.Name = "frmTableSetup";
			this.cboTableList.Size = new System.Drawing.Size(415, 27);
			this.cboTableList.Location = new System.Drawing.Point(275, 5);
			this.cboTableList.TabIndex = 2;
			this.cboTableList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboTableList.BackColor = System.Drawing.SystemColors.Window;
			this.cboTableList.CausesValidation = true;
			this.cboTableList.Enabled = true;
			this.cboTableList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboTableList.IntegralHeight = true;
			this.cboTableList.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboTableList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboTableList.Sorted = false;
			this.cboTableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboTableList.TabStop = true;
			this.cboTableList.Visible = true;
			this.cboTableList.Name = "cboTableList";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "Close";
			this.cmdClose.Size = new System.Drawing.Size(134, 25);
			this.cmdClose.Location = new System.Drawing.Point(333, 655);
			this.cmdClose.TabIndex = 1;
			this.cmdClose.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.TabStop = true;
			this.cmdClose.Name = "cmdClose";
			this.tabFields.Size = new System.Drawing.Size(862, 608);
			this.tabFields.Location = new System.Drawing.Point(7, 38);
			this.tabFields.TabIndex = 0;
			this.tabFields.ItemSize = new System.Drawing.Size(42, 22);
			this.tabFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.tabFields.Name = "tabFields";
			this._tabFields_TabPage0.Text = "Fields";
			this.cmdAddField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddField.Text = "Add";
			this.cmdAddField.Size = new System.Drawing.Size(53, 75);
			this.cmdAddField.Location = new System.Drawing.Point(133, 522);
			this.cmdAddField.TabIndex = 4;
			this.cmdAddField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddField.CausesValidation = true;
			this.cmdAddField.Enabled = true;
			this.cmdAddField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddField.TabStop = true;
			this.cmdAddField.Name = "cmdAddField";
			dbgFieldList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgFieldList.OcxState");
			this.dbgFieldList.Size = new System.Drawing.Size(827, 475);
			this.dbgFieldList.Location = new System.Drawing.Point(18, 40);
			this.dbgFieldList.TabIndex = 7;
			this.dbgFieldList.Name = "dbgFieldList";
			this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEdit.Text = "Edit";
			this.cmdEdit.Size = new System.Drawing.Size(53, 75);
			this.cmdEdit.Location = new System.Drawing.Point(20, 522);
			this.cmdEdit.TabIndex = 5;
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
			this.cmdDelete.Size = new System.Drawing.Size(53, 25);
			this.cmdDelete.Location = new System.Drawing.Point(80, 570);
			this.cmdDelete.TabIndex = 6;
			this.cmdDelete.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelete.CausesValidation = true;
			this.cmdDelete.Enabled = true;
			this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelete.TabStop = true;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdChangeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeStatus.Text = "Change Status";
			this.cmdChangeStatus.Size = new System.Drawing.Size(164, 25);
			this.cmdChangeStatus.Location = new System.Drawing.Point(389, 572);
			this.cmdChangeStatus.TabIndex = 8;
			this.cmdChangeStatus.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeStatus.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeStatus.CausesValidation = true;
			this.cmdChangeStatus.Enabled = true;
			this.cmdChangeStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeStatus.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeStatus.TabStop = true;
			this.cmdChangeStatus.Name = "cmdChangeStatus";
			this.cmdUpdateDEA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUpdateDEA.Text = "Update Data Entry Actions";
			this.cmdUpdateDEA.Size = new System.Drawing.Size(198, 25);
			this.cmdUpdateDEA.Location = new System.Drawing.Point(188, 572);
			this.cmdUpdateDEA.TabIndex = 9;
			this.cmdUpdateDEA.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdUpdateDEA.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdateDEA.CausesValidation = true;
			this.cmdUpdateDEA.Enabled = true;
			this.cmdUpdateDEA.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdateDEA.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdateDEA.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdateDEA.TabStop = true;
			this.cmdUpdateDEA.Name = "cmdUpdateDEA";
			this.cmdMoveDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveDown.Text = "Move Down";
			this.cmdMoveDown.Size = new System.Drawing.Size(102, 25);
			this.cmdMoveDown.Location = new System.Drawing.Point(638, 570);
			this.cmdMoveDown.TabIndex = 10;
			this.cmdMoveDown.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveDown.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveDown.CausesValidation = true;
			this.cmdMoveDown.Enabled = true;
			this.cmdMoveDown.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveDown.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveDown.TabStop = true;
			this.cmdMoveDown.Name = "cmdMoveDown";
			this.cmdMoveUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveUp.Text = "Move Up";
			this.cmdMoveUp.Size = new System.Drawing.Size(74, 25);
			this.cmdMoveUp.Location = new System.Drawing.Point(558, 570);
			this.cmdMoveUp.TabIndex = 11;
			this.cmdMoveUp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveUp.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveUp.CausesValidation = true;
			this.cmdMoveUp.Enabled = true;
			this.cmdMoveUp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveUp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveUp.TabStop = true;
			this.cmdMoveUp.Name = "cmdMoveUp";
			rdcTableList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcTableList.OcxState");
			this.rdcTableList.Size = new System.Drawing.Size(197, 28);
			this.rdcTableList.Location = new System.Drawing.Point(10, 714);
			this.rdcTableList.Visible = false;
			this.rdcTableList.Name = "rdcTableList";
			rdcFieldList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcFieldList.OcxState");
			this.rdcFieldList.Size = new System.Drawing.Size(195, 28);
			this.rdcFieldList.Location = new System.Drawing.Point(210, 715);
			this.rdcFieldList.Visible = false;
			this.rdcFieldList.Name = "rdcFieldList";
			rdcValDynFields.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcValDynFields.OcxState");
			this.rdcValDynFields.Size = new System.Drawing.Size(194, 28);
			this.rdcValDynFields.Location = new System.Drawing.Point(589, 714);
			this.rdcValDynFields.Visible = false;
			this.rdcValDynFields.Name = "rdcValDynFields";
			rdcFieldReqVal.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcFieldReqVal.OcxState");
			this.rdcFieldReqVal.Size = new System.Drawing.Size(203, 28);
			this.rdcFieldReqVal.Location = new System.Drawing.Point(10, 744);
			this.rdcFieldReqVal.Visible = false;
			this.rdcFieldReqVal.Name = "rdcFieldReqVal";
			this.Label1.Text = "Tables:";
			this.Label1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label1.Size = new System.Drawing.Size(80, 19);
			this.Label1.Location = new System.Drawing.Point(189, 9);
			this.Label1.TabIndex = 3;
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
			((System.ComponentModel.ISupportInitialize)this.rdcFieldReqVal).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValDynFields).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcFieldList).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcTableList).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgFieldList).EndInit();
			this.Controls.Add(cboTableList);
			this.Controls.Add(cmdClose);
			this.Controls.Add(tabFields);
			this.Controls.Add(rdcTableList);
			this.Controls.Add(rdcFieldList);
			this.Controls.Add(rdcValDynFields);
			this.Controls.Add(rdcFieldReqVal);
			this.Controls.Add(Label1);
			this.tabFields.Controls.Add(_tabFields_TabPage0);
			this._tabFields_TabPage0.Controls.Add(cmdAddField);
			this._tabFields_TabPage0.Controls.Add(dbgFieldList);
			this._tabFields_TabPage0.Controls.Add(cmdEdit);
			this._tabFields_TabPage0.Controls.Add(cmdDelete);
			this._tabFields_TabPage0.Controls.Add(cmdChangeStatus);
			this._tabFields_TabPage0.Controls.Add(cmdUpdateDEA);
			this._tabFields_TabPage0.Controls.Add(cmdMoveDown);
			this._tabFields_TabPage0.Controls.Add(cmdMoveUp);
			this.tabFields.ResumeLayout(false);
			this._tabFields_TabPage0.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
