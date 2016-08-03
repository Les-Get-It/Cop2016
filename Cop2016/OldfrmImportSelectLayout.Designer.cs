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
	partial class OldfrmImportSelectLayout
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmImportSelectLayout() : base()
		{
			Load += frmImportSelectLayout_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdSelect;
		public System.Windows.Forms.Button cmdSelect {
			get { return withEventsField_cmdSelect; }
			set {
				if (withEventsField_cmdSelect != null) {
					withEventsField_cmdSelect.Click -= cmdSelect_Click;
				}
				withEventsField_cmdSelect = value;
				if (withEventsField_cmdSelect != null) {
					withEventsField_cmdSelect.Click += cmdSelect_Click;
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
		private System.Windows.Forms.Button withEventsField_cmdUpdate;
		public System.Windows.Forms.Button cmdUpdate {
			get { return withEventsField_cmdUpdate; }
			set {
				if (withEventsField_cmdUpdate != null) {
					withEventsField_cmdUpdate.Click -= cmdUpdate_Click;
				}
				withEventsField_cmdUpdate = value;
				if (withEventsField_cmdUpdate != null) {
					withEventsField_cmdUpdate.Click += cmdUpdate_Click;
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
		public System.Windows.Forms.TextBox txtNewImportLayout;
		public AxMSDBGrid.AxDBGrid dbgImportLayout;
		public AxMSRDC.AxMSRDC rdcImportLayout;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmImportSelectLayout));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdChangeStatus = new System.Windows.Forms.Button();
			this.cmdSelect = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.txtNewImportLayout = new System.Windows.Forms.TextBox();
			this.dbgImportLayout = new AxMSDBGrid.AxDBGrid();
			this.rdcImportLayout = new AxMSRDC.AxMSRDC();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.dbgImportLayout).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcImportLayout).BeginInit();
			this.Text = "Select the Layout";
			this.ClientSize = new System.Drawing.Size(607, 417);
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
			this.Name = "frmImportSelectLayout";
			this.cmdChangeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeStatus.Text = "Change Status";
			this.cmdChangeStatus.Size = new System.Drawing.Size(124, 25);
			this.cmdChangeStatus.Location = new System.Drawing.Point(332, 312);
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
			this.cmdSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSelect.Text = "Select";
			this.cmdSelect.Size = new System.Drawing.Size(99, 25);
			this.cmdSelect.Location = new System.Drawing.Point(22, 312);
			this.cmdSelect.TabIndex = 7;
			this.cmdSelect.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdSelect.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSelect.CausesValidation = true;
			this.cmdSelect.Enabled = true;
			this.cmdSelect.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSelect.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSelect.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSelect.TabStop = true;
			this.cmdSelect.Name = "cmdSelect";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "Delete";
			this.cmdDelete.Size = new System.Drawing.Size(99, 25);
			this.cmdDelete.Location = new System.Drawing.Point(228, 312);
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
			this.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUpdate.Text = "Update Desc.";
			this.cmdUpdate.Size = new System.Drawing.Size(99, 25);
			this.cmdUpdate.Location = new System.Drawing.Point(125, 312);
			this.cmdUpdate.TabIndex = 5;
			this.cmdUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdate.CausesValidation = true;
			this.cmdUpdate.Enabled = true;
			this.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdate.TabStop = true;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "Close";
			this.cmdClose.Size = new System.Drawing.Size(99, 27);
			this.cmdClose.Location = new System.Drawing.Point(225, 392);
			this.cmdClose.TabIndex = 4;
			this.cmdClose.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.TabStop = true;
			this.cmdClose.Name = "cmdClose";
			this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAdd.Text = "Add";
			this.cmdAdd.Size = new System.Drawing.Size(69, 27);
			this.cmdAdd.Location = new System.Drawing.Point(463, 345);
			this.cmdAdd.TabIndex = 3;
			this.cmdAdd.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdd.CausesValidation = true;
			this.cmdAdd.Enabled = true;
			this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdd.TabStop = true;
			this.cmdAdd.Name = "cmdAdd";
			this.txtNewImportLayout.AutoSize = false;
			this.txtNewImportLayout.Size = new System.Drawing.Size(330, 27);
			this.txtNewImportLayout.Location = new System.Drawing.Point(125, 348);
			this.txtNewImportLayout.TabIndex = 1;
			this.txtNewImportLayout.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtNewImportLayout.AcceptsReturn = true;
			this.txtNewImportLayout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtNewImportLayout.BackColor = System.Drawing.SystemColors.Window;
			this.txtNewImportLayout.CausesValidation = true;
			this.txtNewImportLayout.Enabled = true;
			this.txtNewImportLayout.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNewImportLayout.HideSelection = true;
			this.txtNewImportLayout.ReadOnly = false;
			this.txtNewImportLayout.MaxLength = 0;
			this.txtNewImportLayout.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtNewImportLayout.Multiline = false;
			this.txtNewImportLayout.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtNewImportLayout.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtNewImportLayout.TabStop = true;
			this.txtNewImportLayout.Visible = true;
			this.txtNewImportLayout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtNewImportLayout.Name = "txtNewImportLayout";
			dbgImportLayout.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgImportLayout.OcxState");
			this.dbgImportLayout.Size = new System.Drawing.Size(572, 278);
			this.dbgImportLayout.Location = new System.Drawing.Point(9, 20);
			this.dbgImportLayout.TabIndex = 0;
			this.dbgImportLayout.Name = "dbgImportLayout";
			rdcImportLayout.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcImportLayout.OcxState");
			this.rdcImportLayout.Size = new System.Drawing.Size(213, 28);
			this.rdcImportLayout.Location = new System.Drawing.Point(-17, 415);
			this.rdcImportLayout.Visible = false;
			this.rdcImportLayout.Name = "rdcImportLayout";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label1.Text = "New Layout (Desc.):";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.Size = new System.Drawing.Size(94, 48);
			this.Label1.Location = new System.Drawing.Point(29, 348);
			this.Label1.TabIndex = 2;
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
			this.Controls.Add(cmdChangeStatus);
			this.Controls.Add(cmdSelect);
			this.Controls.Add(cmdDelete);
			this.Controls.Add(cmdUpdate);
			this.Controls.Add(cmdClose);
			this.Controls.Add(cmdAdd);
			this.Controls.Add(txtNewImportLayout);
			this.Controls.Add(dbgImportLayout);
			this.Controls.Add(rdcImportLayout);
			this.Controls.Add(Label1);
			((System.ComponentModel.ISupportInitialize)this.rdcImportLayout).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgImportLayout).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
