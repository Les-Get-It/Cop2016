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
	partial class frmFindAFile
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmFindAFile() : base()
		{
			Load += frmFindAFile_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdOk;
		public System.Windows.Forms.Button cmdOk {
			get { return withEventsField_cmdOk; }
			set {
				if (withEventsField_cmdOk != null) {
					withEventsField_cmdOk.Click -= cmdOK_Click;
				}
				withEventsField_cmdOk = value;
				if (withEventsField_cmdOk != null) {
					withEventsField_cmdOk.Click += cmdOK_Click;
				}
			}
		}
		private System.Windows.Forms.ComboBox withEventsField_cmbType;
		public System.Windows.Forms.ComboBox cmbType {
			get { return withEventsField_cmbType; }
			set {
				if (withEventsField_cmbType != null) {
					withEventsField_cmbType.SelectedIndexChanged -= cmbType_SelectedIndexChanged;
				}
				withEventsField_cmbType = value;
				if (withEventsField_cmbType != null) {
					withEventsField_cmbType.SelectedIndexChanged += cmbType_SelectedIndexChanged;
				}
			}
		}
		private Microsoft.VisualBasic.Compatibility.VB6.FileListBox withEventsField_fileList;
		public Microsoft.VisualBasic.Compatibility.VB6.FileListBox fileList {
			get { return withEventsField_fileList; }
			set {
				if (withEventsField_fileList != null) {
					withEventsField_fileList.SelectedIndexChanged -= fileList_SelectedIndexChanged;
				}
				withEventsField_fileList = value;
				if (withEventsField_fileList != null) {
					withEventsField_fileList.SelectedIndexChanged += fileList_SelectedIndexChanged;
				}
			}
		}
		private Microsoft.VisualBasic.Compatibility.VB6.DriveListBox withEventsField_drvList;
		public Microsoft.VisualBasic.Compatibility.VB6.DriveListBox drvList {
			get { return withEventsField_drvList; }
			set {
				if (withEventsField_drvList != null) {
					withEventsField_drvList.SelectedIndexChanged -= DrvList_SelectedIndexChanged;
				}
				withEventsField_drvList = value;
				if (withEventsField_drvList != null) {
					withEventsField_drvList.SelectedIndexChanged += DrvList_SelectedIndexChanged;
				}
			}
		}
		private Microsoft.VisualBasic.Compatibility.VB6.DirListBox withEventsField_dirList;
		public Microsoft.VisualBasic.Compatibility.VB6.DirListBox dirList {
			get { return withEventsField_dirList; }
			set {
				if (withEventsField_dirList != null) {
					withEventsField_dirList.Change -= dirList_Change;
				}
				withEventsField_dirList = value;
				if (withEventsField_dirList != null) {
					withEventsField_dirList.Change += dirList_Change;
				}
			}
		}
		public System.Windows.Forms.Label lblFile;
		public System.Windows.Forms.Label lblDrives;
		public System.Windows.Forms.Label lblTypes;
		public System.Windows.Forms.Label lblFileName;
		public System.Windows.Forms.Label lblDirectories;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFindAFile));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOk = new System.Windows.Forms.Button();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.fileList = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
			this.drvList = new Microsoft.VisualBasic.Compatibility.VB6.DriveListBox();
			this.dirList = new Microsoft.VisualBasic.Compatibility.VB6.DirListBox();
			this.lblFile = new System.Windows.Forms.Label();
			this.lblDrives = new System.Windows.Forms.Label();
			this.lblTypes = new System.Windows.Forms.Label();
			this.lblFileName = new System.Windows.Forms.Label();
			this.lblDirectories = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "File Search";
			this.ClientSize = new System.Drawing.Size(758, 243);
			this.Location = new System.Drawing.Point(235, 225);
			this.ControlBox = false;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmFindAFile";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(107, 34);
			this.cmdCancel.Location = new System.Drawing.Point(614, 62);
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdOk.Text = "&OK";
			this.cmdOk.Size = new System.Drawing.Size(105, 34);
			this.cmdOk.Location = new System.Drawing.Point(614, 17);
			this.cmdOk.TabIndex = 4;
			this.cmdOk.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdOk.BackColor = System.Drawing.SystemColors.Control;
			this.cmdOk.CausesValidation = true;
			this.cmdOk.Enabled = true;
			this.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdOk.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdOk.TabStop = true;
			this.cmdOk.Name = "cmdOk";
			this.cmbType.Size = new System.Drawing.Size(173, 27);
			this.cmbType.Location = new System.Drawing.Point(24, 207);
			this.cmbType.Items.AddRange(new object[] {
				"File (*.txt, *.csv)",
				"All Files (*.*)",
				"Excel (*.xls, *.xlsx)"
			});
			this.cmbType.TabIndex = 3;
			this.cmbType.Text = "Combo1";
			this.cmbType.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmbType.BackColor = System.Drawing.SystemColors.Window;
			this.cmbType.CausesValidation = true;
			this.cmbType.Enabled = true;
			this.cmbType.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbType.IntegralHeight = true;
			this.cmbType.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbType.Sorted = false;
			this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cmbType.TabStop = true;
			this.cmbType.Visible = true;
			this.cmbType.Name = "cmbType";
			this.fileList.Size = new System.Drawing.Size(347, 105);
			this.fileList.Location = new System.Drawing.Point(22, 70);
			this.fileList.Pattern = "*.txt,*.csv";
			this.fileList.TabIndex = 2;
			this.fileList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.fileList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.fileList.Archive = true;
			this.fileList.BackColor = System.Drawing.SystemColors.Window;
			this.fileList.CausesValidation = true;
			this.fileList.Enabled = true;
			this.fileList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fileList.Hidden = false;
			this.fileList.Cursor = System.Windows.Forms.Cursors.Default;
			this.fileList.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.fileList.Normal = true;
			this.fileList.ReadOnly = true;
			this.fileList.System = false;
			this.fileList.TabStop = true;
			this.fileList.TopIndex = 0;
			this.fileList.Visible = true;
			this.fileList.Name = "fileList";
			this.drvList.Size = new System.Drawing.Size(214, 27);
			this.drvList.Location = new System.Drawing.Point(394, 210);
			this.drvList.TabIndex = 1;
			this.drvList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.drvList.BackColor = System.Drawing.SystemColors.Window;
			this.drvList.CausesValidation = true;
			this.drvList.Enabled = true;
			this.drvList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.drvList.Cursor = System.Windows.Forms.Cursors.Default;
			this.drvList.TabStop = true;
			this.drvList.Visible = true;
			this.drvList.Name = "drvList";
			this.dirList.Size = new System.Drawing.Size(212, 139);
			this.dirList.Location = new System.Drawing.Point(390, 40);
			this.dirList.TabIndex = 0;
			this.dirList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.dirList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dirList.BackColor = System.Drawing.SystemColors.Window;
			this.dirList.CausesValidation = true;
			this.dirList.Enabled = true;
			this.dirList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.dirList.Cursor = System.Windows.Forms.Cursors.Default;
			this.dirList.TabStop = true;
			this.dirList.Visible = true;
			this.dirList.Name = "dirList";
			this.lblFile.BackColor = System.Drawing.Color.White;
			this.lblFile.Size = new System.Drawing.Size(348, 29);
			this.lblFile.Location = new System.Drawing.Point(19, 30);
			this.lblFile.TabIndex = 10;
			this.lblFile.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblFile.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblFile.Enabled = true;
			this.lblFile.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblFile.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblFile.UseMnemonic = true;
			this.lblFile.Visible = true;
			this.lblFile.AutoSize = false;
			this.lblFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblFile.Name = "lblFile";
			this.lblDrives.Text = "&Drives";
			this.lblDrives.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblDrives.Size = new System.Drawing.Size(218, 22);
			this.lblDrives.Location = new System.Drawing.Point(392, 185);
			this.lblDrives.TabIndex = 9;
			this.lblDrives.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblDrives.BackColor = System.Drawing.SystemColors.Control;
			this.lblDrives.Enabled = true;
			this.lblDrives.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDrives.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDrives.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDrives.UseMnemonic = true;
			this.lblDrives.Visible = true;
			this.lblDrives.AutoSize = false;
			this.lblDrives.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblDrives.Name = "lblDrives";
			this.lblTypes.Text = "List of &Types";
			this.lblTypes.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblTypes.Size = new System.Drawing.Size(174, 23);
			this.lblTypes.Location = new System.Drawing.Point(24, 180);
			this.lblTypes.TabIndex = 8;
			this.lblTypes.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblTypes.BackColor = System.Drawing.SystemColors.Control;
			this.lblTypes.Enabled = true;
			this.lblTypes.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTypes.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTypes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTypes.UseMnemonic = true;
			this.lblTypes.Visible = true;
			this.lblTypes.AutoSize = false;
			this.lblTypes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblTypes.Name = "lblTypes";
			this.lblFileName.Text = "File &Name";
			this.lblFileName.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblFileName.Size = new System.Drawing.Size(183, 19);
			this.lblFileName.Location = new System.Drawing.Point(20, 10);
			this.lblFileName.TabIndex = 7;
			this.lblFileName.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblFileName.BackColor = System.Drawing.SystemColors.Control;
			this.lblFileName.Enabled = true;
			this.lblFileName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblFileName.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblFileName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblFileName.UseMnemonic = true;
			this.lblFileName.Visible = true;
			this.lblFileName.AutoSize = false;
			this.lblFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblFileName.Name = "lblFileName";
			this.lblDirectories.Text = "&Directories";
			this.lblDirectories.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblDirectories.Size = new System.Drawing.Size(204, 24);
			this.lblDirectories.Location = new System.Drawing.Point(390, 18);
			this.lblDirectories.TabIndex = 6;
			this.lblDirectories.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblDirectories.BackColor = System.Drawing.SystemColors.Control;
			this.lblDirectories.Enabled = true;
			this.lblDirectories.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDirectories.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDirectories.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDirectories.UseMnemonic = true;
			this.lblDirectories.Visible = true;
			this.lblDirectories.AutoSize = false;
			this.lblDirectories.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblDirectories.Name = "lblDirectories";
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdOk);
			this.Controls.Add(cmbType);
			this.Controls.Add(fileList);
			this.Controls.Add(drvList);
			this.Controls.Add(dirList);
			this.Controls.Add(lblFile);
			this.Controls.Add(lblDrives);
			this.Controls.Add(lblTypes);
			this.Controls.Add(lblFileName);
			this.Controls.Add(lblDirectories);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
