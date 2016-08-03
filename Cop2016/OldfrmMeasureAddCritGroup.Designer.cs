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
	partial class OldfrmMeasureAddCritGroup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmMeasureAddCritGroup() : base()
		{
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
		private System.Windows.Forms.Button withEventsField_cmdRemoveSet;
		public System.Windows.Forms.Button cmdRemoveSet {
			get { return withEventsField_cmdRemoveSet; }
			set {
				if (withEventsField_cmdRemoveSet != null) {
					withEventsField_cmdRemoveSet.Click -= cmdRemoveSet_Click;
				}
				withEventsField_cmdRemoveSet = value;
				if (withEventsField_cmdRemoveSet != null) {
					withEventsField_cmdRemoveSet.Click += cmdRemoveSet_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstSelectedSetList;
		private System.Windows.Forms.ComboBox withEventsField_cboGroup;
		public System.Windows.Forms.ComboBox cboGroup {
			get { return withEventsField_cboGroup; }
			set {
				if (withEventsField_cboGroup != null) {
					withEventsField_cboGroup.SelectedIndexChanged -= cboGroup_SelectedIndexChanged;
				}
				withEventsField_cboGroup = value;
				if (withEventsField_cboGroup != null) {
					withEventsField_cboGroup.SelectedIndexChanged += cboGroup_SelectedIndexChanged;
				}
			}
		}
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
		public System.Windows.Forms.ListBox lstSetList;
		public System.Windows.Forms.Label _Label1_1;
		public System.Windows.Forms.Label lblJoinOperator;
		public System.Windows.Forms.Label _Label1_0;
		public System.Windows.Forms.Label lblColName;
		public System.Windows.Forms.Label lblSet;
		public Microsoft.VisualBasic.Compatibility.VB6.LabelArray Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmMeasureAddCritGroup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdAddSet = new System.Windows.Forms.Button();
			this.cmdRemoveSet = new System.Windows.Forms.Button();
			this.lstSelectedSetList = new System.Windows.Forms.ListBox();
			this.cboGroup = new System.Windows.Forms.ComboBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cboJoinOperator = new System.Windows.Forms.ComboBox();
			this.lstSetList = new System.Windows.Forms.ListBox();
			this._Label1_1 = new System.Windows.Forms.Label();
			this.lblJoinOperator = new System.Windows.Forms.Label();
			this._Label1_0 = new System.Windows.Forms.Label();
			this.lblColName = new System.Windows.Forms.Label();
			this.lblSet = new System.Windows.Forms.Label();
			this.Label1 = new Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components);
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.Label1).BeginInit();
			this.Text = "Group Sets in Step";
			this.ClientSize = new System.Drawing.Size(738, 422);
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
			this.Name = "frmMeasureAddCritGroup";
			this.cmdAddSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddSet.Text = "==>>";
			this.cmdAddSet.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddSet.Size = new System.Drawing.Size(59, 30);
			this.cmdAddSet.Location = new System.Drawing.Point(340, 190);
			this.cmdAddSet.TabIndex = 10;
			this.cmdAddSet.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddSet.CausesValidation = true;
			this.cmdAddSet.Enabled = true;
			this.cmdAddSet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddSet.TabStop = true;
			this.cmdAddSet.Name = "cmdAddSet";
			this.cmdRemoveSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveSet.Text = "<<==";
			this.cmdRemoveSet.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveSet.Size = new System.Drawing.Size(58, 30);
			this.cmdRemoveSet.Location = new System.Drawing.Point(340, 240);
			this.cmdRemoveSet.TabIndex = 9;
			this.cmdRemoveSet.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveSet.CausesValidation = true;
			this.cmdRemoveSet.Enabled = true;
			this.cmdRemoveSet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveSet.TabStop = true;
			this.cmdRemoveSet.Name = "cmdRemoveSet";
			this.lstSelectedSetList.Size = new System.Drawing.Size(317, 269);
			this.lstSelectedSetList.Location = new System.Drawing.Point(410, 120);
			this.lstSelectedSetList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstSelectedSetList.TabIndex = 8;
			this.lstSelectedSetList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstSelectedSetList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSelectedSetList.BackColor = System.Drawing.SystemColors.Window;
			this.lstSelectedSetList.CausesValidation = true;
			this.lstSelectedSetList.Enabled = true;
			this.lstSelectedSetList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSelectedSetList.IntegralHeight = true;
			this.lstSelectedSetList.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSelectedSetList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSelectedSetList.Sorted = false;
			this.lstSelectedSetList.TabStop = true;
			this.lstSelectedSetList.Visible = true;
			this.lstSelectedSetList.MultiColumn = false;
			this.lstSelectedSetList.Name = "lstSelectedSetList";
			this.cboGroup.Size = new System.Drawing.Size(92, 27);
			this.cboGroup.Location = new System.Drawing.Point(30, 60);
			this.cboGroup.TabIndex = 3;
			this.cboGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboGroup.BackColor = System.Drawing.SystemColors.Window;
			this.cboGroup.CausesValidation = true;
			this.cboGroup.Enabled = true;
			this.cboGroup.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGroup.IntegralHeight = true;
			this.cboGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboGroup.Sorted = false;
			this.cboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboGroup.TabStop = true;
			this.cboGroup.Visible = true;
			this.cboGroup.Name = "cboGroup";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(80, 24);
			this.cmdCancel.Location = new System.Drawing.Point(559, 390);
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
			this.cboJoinOperator.Location = new System.Drawing.Point(400, 60);
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
			this.lstSetList.Size = new System.Drawing.Size(317, 269);
			this.lstSetList.Location = new System.Drawing.Point(5, 120);
			this.lstSetList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstSetList.TabIndex = 0;
			this.lstSetList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstSetList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSetList.BackColor = System.Drawing.SystemColors.Window;
			this.lstSetList.CausesValidation = true;
			this.lstSetList.Enabled = true;
			this.lstSetList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSetList.IntegralHeight = true;
			this.lstSetList.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSetList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSetList.Sorted = false;
			this.lstSetList.TabStop = true;
			this.lstSetList.Visible = true;
			this.lstSetList.MultiColumn = false;
			this.lstSetList.Name = "lstSetList";
			this._Label1_1.Text = "Selected Sets for Group";
			this._Label1_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._Label1_1.ForeColor = System.Drawing.Color.Blue;
			this._Label1_1.Size = new System.Drawing.Size(287, 17);
			this._Label1_1.Location = new System.Drawing.Point(410, 100);
			this._Label1_1.TabIndex = 11;
			this._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_1.BackColor = System.Drawing.SystemColors.Control;
			this._Label1_1.Enabled = true;
			this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_1.UseMnemonic = true;
			this._Label1_1.Visible = true;
			this._Label1_1.AutoSize = false;
			this._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_1.Name = "_Label1_1";
			this.lblJoinOperator.Text = "Group Join Type:";
			this.lblJoinOperator.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblJoinOperator.ForeColor = System.Drawing.Color.Blue;
			this.lblJoinOperator.Size = new System.Drawing.Size(132, 22);
			this.lblJoinOperator.Location = new System.Drawing.Point(400, 40);
			this.lblJoinOperator.TabIndex = 7;
			this.lblJoinOperator.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblJoinOperator.BackColor = System.Drawing.SystemColors.Control;
			this.lblJoinOperator.Enabled = true;
			this.lblJoinOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblJoinOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblJoinOperator.UseMnemonic = true;
			this.lblJoinOperator.Visible = true;
			this.lblJoinOperator.AutoSize = false;
			this.lblJoinOperator.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblJoinOperator.Name = "lblJoinOperator";
			this._Label1_0.Text = "Available Sets for Group";
			this._Label1_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._Label1_0.ForeColor = System.Drawing.Color.Blue;
			this._Label1_0.Size = new System.Drawing.Size(287, 17);
			this._Label1_0.Location = new System.Drawing.Point(5, 100);
			this._Label1_0.TabIndex = 6;
			this._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_0.BackColor = System.Drawing.SystemColors.Control;
			this._Label1_0.Enabled = true;
			this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_0.UseMnemonic = true;
			this._Label1_0.Visible = true;
			this._Label1_0.AutoSize = false;
			this._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_0.Name = "_Label1_0";
			this.lblColName.Text = "Set up Sets for";
			this.lblColName.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblColName.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.lblColName.Size = new System.Drawing.Size(797, 20);
			this.lblColName.Location = new System.Drawing.Point(2, 0);
			this.lblColName.TabIndex = 5;
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
			this.lblSet.Text = "Group #:";
			this.lblSet.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblSet.ForeColor = System.Drawing.Color.Blue;
			this.lblSet.Size = new System.Drawing.Size(72, 22);
			this.lblSet.Location = new System.Drawing.Point(30, 40);
			this.lblSet.TabIndex = 4;
			this.lblSet.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblSet.BackColor = System.Drawing.SystemColors.Control;
			this.lblSet.Enabled = true;
			this.lblSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblSet.UseMnemonic = true;
			this.lblSet.Visible = true;
			this.lblSet.AutoSize = false;
			this.lblSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblSet.Name = "lblSet";
			this.Controls.Add(cmdAddSet);
			this.Controls.Add(cmdRemoveSet);
			this.Controls.Add(lstSelectedSetList);
			this.Controls.Add(cboGroup);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cboJoinOperator);
			this.Controls.Add(lstSetList);
			this.Controls.Add(_Label1_1);
			this.Controls.Add(lblJoinOperator);
			this.Controls.Add(_Label1_0);
			this.Controls.Add(lblColName);
			this.Controls.Add(lblSet);
			this.Label1.SetIndex(_Label1_1, Convert.ToInt16(1));
			this.Label1.SetIndex(_Label1_0, Convert.ToInt16(0));
			((System.ComponentModel.ISupportInitialize)this.Label1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
