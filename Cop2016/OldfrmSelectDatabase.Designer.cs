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
	partial class OldfrmSelectDatabase
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmSelectDatabase() : base()
		{
			Load += frmSelectDatabase_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdConnect;
		public System.Windows.Forms.Button cmdConnect {
			get { return withEventsField_cmdConnect; }
			set {
				if (withEventsField_cmdConnect != null) {
					withEventsField_cmdConnect.Click -= cmdConnect_Click;
				}
				withEventsField_cmdConnect = value;
				if (withEventsField_cmdConnect != null) {
					withEventsField_cmdConnect.Click += cmdConnect_Click;
				}
			}
		}
		public System.Windows.Forms.RadioButton optIHHA;
		public System.Windows.Forms.RadioButton optArchive;
		public System.Windows.Forms.RadioButton optCurrent;
		public System.Windows.Forms.GroupBox Frame1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmSelectDatabase));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdConnect = new System.Windows.Forms.Button();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.optIHHA = new System.Windows.Forms.RadioButton();
			this.optArchive = new System.Windows.Forms.RadioButton();
			this.optCurrent = new System.Windows.Forms.RadioButton();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Select Database";
			this.ClientSize = new System.Drawing.Size(390, 235);
			this.Location = new System.Drawing.Point(5, 29);
			this.ControlBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
			this.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Enabled = true;
			this.KeyPreview = false;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmSelectDatabase";
			this.cmdConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdConnect.Text = "Connect";
			this.cmdConnect.Size = new System.Drawing.Size(142, 32);
			this.cmdConnect.Location = new System.Drawing.Point(130, 190);
			this.cmdConnect.TabIndex = 3;
			this.cmdConnect.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdConnect.BackColor = System.Drawing.SystemColors.Control;
			this.cmdConnect.CausesValidation = true;
			this.cmdConnect.Enabled = true;
			this.cmdConnect.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdConnect.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdConnect.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdConnect.TabStop = true;
			this.cmdConnect.Name = "cmdConnect";
			this.Frame1.Text = "Select a database to connect to:";
			this.Frame1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame1.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.Frame1.Size = new System.Drawing.Size(272, 122);
			this.Frame1.Location = new System.Drawing.Point(70, 10);
			this.Frame1.TabIndex = 0;
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.optIHHA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optIHHA.Text = "IHHA (To accept new changes)";
			this.optIHHA.Size = new System.Drawing.Size(245, 32);
			this.optIHHA.Location = new System.Drawing.Point(17, 27);
			this.optIHHA.TabIndex = 4;
			this.optIHHA.Checked = true;
			this.optIHHA.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optIHHA.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optIHHA.BackColor = System.Drawing.SystemColors.Control;
			this.optIHHA.CausesValidation = true;
			this.optIHHA.Enabled = true;
			this.optIHHA.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optIHHA.Cursor = System.Windows.Forms.Cursors.Default;
			this.optIHHA.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optIHHA.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optIHHA.TabStop = true;
			this.optIHHA.Visible = true;
			this.optIHHA.Name = "optIHHA";
			this.optArchive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optArchive.Text = "Archive ";
			this.optArchive.Size = new System.Drawing.Size(172, 32);
			this.optArchive.Location = new System.Drawing.Point(17, 85);
			this.optArchive.TabIndex = 2;
			this.optArchive.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optArchive.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optArchive.BackColor = System.Drawing.SystemColors.Control;
			this.optArchive.CausesValidation = true;
			this.optArchive.Enabled = true;
			this.optArchive.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optArchive.Cursor = System.Windows.Forms.Cursors.Default;
			this.optArchive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optArchive.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optArchive.TabStop = true;
			this.optArchive.Checked = false;
			this.optArchive.Visible = true;
			this.optArchive.Name = "optArchive";
			this.optCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optCurrent.Text = "Current (To process hospital data)";
			this.optCurrent.Size = new System.Drawing.Size(230, 32);
			this.optCurrent.Location = new System.Drawing.Point(17, 55);
			this.optCurrent.TabIndex = 1;
			this.optCurrent.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optCurrent.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optCurrent.BackColor = System.Drawing.SystemColors.Control;
			this.optCurrent.CausesValidation = true;
			this.optCurrent.Enabled = true;
			this.optCurrent.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optCurrent.Cursor = System.Windows.Forms.Cursors.Default;
			this.optCurrent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optCurrent.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optCurrent.TabStop = true;
			this.optCurrent.Checked = false;
			this.optCurrent.Visible = true;
			this.optCurrent.Name = "optCurrent";
			this.Controls.Add(cmdConnect);
			this.Controls.Add(Frame1);
			this.Frame1.Controls.Add(optIHHA);
			this.Frame1.Controls.Add(optArchive);
			this.Frame1.Controls.Add(optCurrent);
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
