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
	partial class OlddlgCreateCat
	{
		#region "Windows Form Designer generated code "
		[DebuggerNonUserCode()]
		public OlddlgCreateCat() : base()
		{
			Load += dlgCreateCat_Load;
			//This call is required by the Windows Form Designer.
			InitializeComponent();
		}
//Form overrides dispose to clean up the component list.
		[DebuggerNonUserCode()]
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
		public ToolTip ToolTip1;
		public ComboBox cboType;
		public TextBox txtCatID;
		public TextBox txtCatDesc;
		private Button withEventsField_CancelButton_Renamed;
		public Button CancelButton_Renamed
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
		private Button withEventsField_OKButton;
		public Button OKButton
        {
			get { return withEventsField_OKButton; }
			set
            {
				if (withEventsField_OKButton != null)
                {
					withEventsField_OKButton.Click -= OKButton_Click;
				}
				withEventsField_OKButton = value;
				if (withEventsField_OKButton != null)
                {
					withEventsField_OKButton.Click += OKButton_Click;
				}
			}
		}
		public Label Label3;
		public Label Label2;
		public Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OlddlgCreateCat));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new ToolTip(components);
			this.cboType = new ComboBox();
			this.txtCatID = new TextBox();
			this.txtCatDesc = new TextBox();
			this.CancelButton_Renamed = new Button();
			this.OKButton = new Button();
			this.Label3 = new Label();
			this.Label2 = new Label();
			this.Label1 = new Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.Text = "Create New Measure Category";
			this.ClientSize = new Size(503, 132);
			this.Location = new Point(230, 313);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = FormStartPosition.CenterParent;
			this.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0));
			this.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.Control;
			this.ControlBox = true;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = Cursors.Default;
			this.RightToLeft = RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = FormWindowState.Normal;
			this.Name = "dlgCreateCat";
			this.cboType.Size = new Size(102, 27);
			this.cboType.Location = new Point(90, 90);
			this.cboType.Items.AddRange(new object[] {"RA", "CI"});
			this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cboType.TabIndex = 2;
			this.cboType.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0));
			this.cboType.BackColor = SystemColors.Window;
			this.cboType.CausesValidation = true;
			this.cboType.Enabled = true;
			this.cboType.ForeColor = SystemColors.WindowText;
			this.cboType.IntegralHeight = true;
			this.cboType.Cursor = Cursors.Default;
			this.cboType.RightToLeft = RightToLeft.No;
			this.cboType.Sorted = false;
			this.cboType.TabStop = true;
			this.cboType.Visible = true;
			this.cboType.Name = "cboType";
			this.txtCatID.AutoSize = false;
			this.txtCatID.Size = new Size(52, 32);
			this.txtCatID.Location = new Point(90, 10);
			this.txtCatID.TabIndex = 0;
			this.txtCatID.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0));
			this.txtCatID.AcceptsReturn = true;
			this.txtCatID.TextAlign = HorizontalAlignment.Left;
			this.txtCatID.BackColor = SystemColors.Window;
			this.txtCatID.CausesValidation = true;
			this.txtCatID.Enabled = true;
			this.txtCatID.ForeColor = SystemColors.WindowText;
			this.txtCatID.HideSelection = true;
			this.txtCatID.ReadOnly = false;
			this.txtCatID.MaxLength = 0;
			this.txtCatID.Cursor = Cursors.IBeam;
			this.txtCatID.Multiline = false;
			this.txtCatID.RightToLeft = RightToLeft.No;
			this.txtCatID.ScrollBars = ScrollBars.None;
			this.txtCatID.TabStop = true;
			this.txtCatID.Visible = true;
			this.txtCatID.BorderStyle = BorderStyle.Fixed3D;
			this.txtCatID.Name = "txtCatID";
			this.txtCatDesc.AutoSize = false;
			this.txtCatDesc.Size = new Size(282, 32);
			this.txtCatDesc.Location = new Point(90, 50);
			this.txtCatDesc.TabIndex = 1;
			this.txtCatDesc.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0));
			this.txtCatDesc.AcceptsReturn = true;
			this.txtCatDesc.TextAlign = HorizontalAlignment.Left;
			this.txtCatDesc.BackColor = SystemColors.Window;
			this.txtCatDesc.CausesValidation = true;
			this.txtCatDesc.Enabled = true;
			this.txtCatDesc.ForeColor = SystemColors.WindowText;
			this.txtCatDesc.HideSelection = true;
			this.txtCatDesc.ReadOnly = false;
			this.txtCatDesc.MaxLength = 0;
			this.txtCatDesc.Cursor = Cursors.IBeam;
			this.txtCatDesc.Multiline = false;
			this.txtCatDesc.RightToLeft = RightToLeft.No;
			this.txtCatDesc.ScrollBars = ScrollBars.None;
			this.txtCatDesc.TabStop = true;
			this.txtCatDesc.Visible = true;
			this.txtCatDesc.BorderStyle = BorderStyle.Fixed3D;
			this.txtCatDesc.Name = "txtCatDesc";
			this.CancelButton_Renamed.TextAlign = ContentAlignment.MiddleCenter;
			this.CancelButton = this.CancelButton_Renamed;
			this.CancelButton_Renamed.Text = "Cancel";
			this.CancelButton_Renamed.Size = new Size(102, 32);
			this.CancelButton_Renamed.Location = new Point(390, 50);
			this.CancelButton_Renamed.TabIndex = 4;
			this.CancelButton_Renamed.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0));
			this.CancelButton_Renamed.BackColor = SystemColors.Control;
			this.CancelButton_Renamed.CausesValidation = true;
			this.CancelButton_Renamed.Enabled = true;
			this.CancelButton_Renamed.ForeColor = SystemColors.ControlText;
			this.CancelButton_Renamed.Cursor = Cursors.Default;
			this.CancelButton_Renamed.RightToLeft = RightToLeft.No;
			this.CancelButton_Renamed.TabStop = true;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.OKButton.TextAlign = ContentAlignment.MiddleCenter;
			this.OKButton.Text = "OK";
			this.AcceptButton = this.OKButton;
			this.OKButton.Size = new Size(102, 32);
			this.OKButton.Location = new Point(390, 10);
			this.OKButton.TabIndex = 3;
			this.OKButton.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0));
			this.OKButton.BackColor = SystemColors.Control;
			this.OKButton.CausesValidation = true;
			this.OKButton.Enabled = true;
			this.OKButton.ForeColor = SystemColors.ControlText;
			this.OKButton.Cursor = Cursors.Default;
			this.OKButton.RightToLeft = RightToLeft.No;
			this.OKButton.TabStop = true;
			this.OKButton.Name = "OKButton";
			this.Label3.TextAlign = ContentAlignment.TopRight;
			this.Label3.Text = "Type";
			this.Label3.Font = new Font("Arial", 8.25f, FontStyle.Bold | FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0));
			this.Label3.Size = new Size(52, 22);
			this.Label3.Location = new Point(30, 100);
			this.Label3.TabIndex = 7;
			this.Label3.BackColor = SystemColors.Control;
			this.Label3.Enabled = true;
			this.Label3.ForeColor = SystemColors.ControlText;
			this.Label3.Cursor = Cursors.Default;
			this.Label3.RightToLeft = RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = BorderStyle.None;
			this.Label3.Name = "Label3";
			this.Label2.TextAlign = ContentAlignment.TopRight;
			this.Label2.Text = "Desc";
			this.Label2.Font = new Font("Arial", 8.25f, FontStyle.Bold | FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.Size = new Size(52, 22);
			this.Label2.Location = new Point(30, 60);
			this.Label2.TabIndex = 6;
			this.Label2.BackColor = SystemColors.Control;
			this.Label2.Enabled = true;
			this.Label2.ForeColor = SystemColors.ControlText;
			this.Label2.Cursor = Cursors.Default;
			this.Label2.RightToLeft = RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = BorderStyle.None;
			this.Label2.Name = "Label2";
			this.Label1.TextAlign = ContentAlignment.TopRight;
			this.Label1.Text = "ID";
			this.Label1.Font = new Font("Arial", 8.25f, FontStyle.Bold | FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.Size = new Size(52, 22);
			this.Label1.Location = new Point(30, 20);
			this.Label1.TabIndex = 5;
			this.Label1.BackColor = SystemColors.Control;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = SystemColors.ControlText;
			this.Label1.Cursor = Cursors.Default;
			this.Label1.RightToLeft = RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = BorderStyle.None;
			this.Label1.Name = "Label1";
			this.Controls.Add(cboType);
			this.Controls.Add(txtCatID);
			this.Controls.Add(txtCatDesc);
			this.Controls.Add(CancelButton_Renamed);
			this.Controls.Add(OKButton);
			this.Controls.Add(Label3);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
