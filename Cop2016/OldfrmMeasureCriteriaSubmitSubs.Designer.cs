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
	partial class OldfrmMeasureCriteriaSubmitSubs
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmMeasureCriteriaSubmitSubs() : base()
		{
			FormClosed += frmMeasureCriteriaSubmitSubs_FormClosed;
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
		private System.Windows.Forms.Button withEventsField_cmdRemoveSubmitSubsStep;
		public System.Windows.Forms.Button cmdRemoveSubmitSubsStep {
			get { return withEventsField_cmdRemoveSubmitSubsStep; }
			set {
				if (withEventsField_cmdRemoveSubmitSubsStep != null) {
					withEventsField_cmdRemoveSubmitSubsStep.Click -= cmdRemoveSubmitSubsStep_Click;
				}
				withEventsField_cmdRemoveSubmitSubsStep = value;
				if (withEventsField_cmdRemoveSubmitSubsStep != null) {
					withEventsField_cmdRemoveSubmitSubsStep.Click += cmdRemoveSubmitSubsStep_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdSubmitSubsStep;
		public System.Windows.Forms.Button cmdSubmitSubsStep {
			get { return withEventsField_cmdSubmitSubsStep; }
			set {
				if (withEventsField_cmdSubmitSubsStep != null) {
					withEventsField_cmdSubmitSubsStep.Click -= cmdSubmitSubsStep_Click;
				}
				withEventsField_cmdSubmitSubsStep = value;
				if (withEventsField_cmdSubmitSubsStep != null) {
					withEventsField_cmdSubmitSubsStep.Click += cmdSubmitSubsStep_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstSubmissionDef;
		public System.Windows.Forms.Button _cmdDelCriteria_0;
		public System.Windows.Forms.Button _cmdAddCriteria_0;
		public System.Windows.Forms.Button _cmdChangeAndOrCond_0;
		public System.Windows.Forms.Button _cmdChangeAddOrBetweenSets_0;
		public System.Windows.Forms.Button cmdModifyCriteriaField;
		public System.Windows.Forms.Button cmdModifyCriteriaOperator;
		public System.Windows.Forms.Button cmdModifyCriteriaValue;
		public System.Windows.Forms.Label lblIndicatorDesc;
		public System.Windows.Forms.Label lblMeasureStep;
		public System.Windows.Forms.Label _Label4_0;
		public Microsoft.VisualBasic.Compatibility.VB6.LabelArray Label4;
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdAddCriteria;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdAddCriteria {
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
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdChangeAddOrBetweenSets;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdChangeAddOrBetweenSets {
			get { return withEventsField_cmdChangeAddOrBetweenSets; }
			set {
				if (withEventsField_cmdChangeAddOrBetweenSets != null) {
					withEventsField_cmdChangeAddOrBetweenSets.Click -= cmdChangeAddOrBetweenSets_Click;
				}
				withEventsField_cmdChangeAddOrBetweenSets = value;
				if (withEventsField_cmdChangeAddOrBetweenSets != null) {
					withEventsField_cmdChangeAddOrBetweenSets.Click += cmdChangeAddOrBetweenSets_Click;
				}
			}
		}
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdChangeAndOrCond;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdChangeAndOrCond {
			get { return withEventsField_cmdChangeAndOrCond; }
			set {
				if (withEventsField_cmdChangeAndOrCond != null) {
					withEventsField_cmdChangeAndOrCond.Click -= cmdChangeAndOrCond_Click;
				}
				withEventsField_cmdChangeAndOrCond = value;
				if (withEventsField_cmdChangeAndOrCond != null) {
					withEventsField_cmdChangeAndOrCond.Click += cmdChangeAndOrCond_Click;
				}
			}
		}
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdDelCriteria;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdDelCriteria {
			get { return withEventsField_cmdDelCriteria; }
			set {
				if (withEventsField_cmdDelCriteria != null) {
					withEventsField_cmdDelCriteria.Click -= cmdDelCriteria_Click;
				}
				withEventsField_cmdDelCriteria = value;
				if (withEventsField_cmdDelCriteria != null) {
					withEventsField_cmdDelCriteria.Click += cmdDelCriteria_Click;
				}
			}
		}
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmMeasureCriteriaSubmitSubs));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdRemoveSubmitSubsStep = new System.Windows.Forms.Button();
			this.cmdSubmitSubsStep = new System.Windows.Forms.Button();
			this.lstSubmissionDef = new System.Windows.Forms.ListBox();
			this._cmdDelCriteria_0 = new System.Windows.Forms.Button();
			this._cmdAddCriteria_0 = new System.Windows.Forms.Button();
			this._cmdChangeAndOrCond_0 = new System.Windows.Forms.Button();
			this._cmdChangeAddOrBetweenSets_0 = new System.Windows.Forms.Button();
			this.cmdModifyCriteriaField = new System.Windows.Forms.Button();
			this.cmdModifyCriteriaOperator = new System.Windows.Forms.Button();
			this.cmdModifyCriteriaValue = new System.Windows.Forms.Button();
			this.lblIndicatorDesc = new System.Windows.Forms.Label();
			this.lblMeasureStep = new System.Windows.Forms.Label();
			this._Label4_0 = new System.Windows.Forms.Label();
			this.Label4 = new Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components);
			this.cmdAddCriteria = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.cmdChangeAddOrBetweenSets = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.cmdChangeAndOrCond = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.cmdDelCriteria = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.Label4).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdAddCriteria).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdChangeAddOrBetweenSets).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdChangeAndOrCond).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdDelCriteria).BeginInit();
			this.Text = "Criteria Step Substitution for Submission ";
			this.ClientSize = new System.Drawing.Size(784, 530);
			this.Location = new System.Drawing.Point(5, 38);
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
			this.Name = "frmMeasureCriteriaSubmitSubs";
			this.cmdRemoveSubmitSubsStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveSubmitSubsStep.Text = "Remove Substitution Step";
			this.cmdRemoveSubmitSubsStep.Size = new System.Drawing.Size(199, 23);
			this.cmdRemoveSubmitSubsStep.Location = new System.Drawing.Point(549, 67);
			this.cmdRemoveSubmitSubsStep.TabIndex = 12;
			this.cmdRemoveSubmitSubsStep.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveSubmitSubsStep.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveSubmitSubsStep.CausesValidation = true;
			this.cmdRemoveSubmitSubsStep.Enabled = true;
			this.cmdRemoveSubmitSubsStep.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveSubmitSubsStep.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveSubmitSubsStep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveSubmitSubsStep.TabStop = true;
			this.cmdRemoveSubmitSubsStep.Name = "cmdRemoveSubmitSubsStep";
			this.cmdSubmitSubsStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSubmitSubsStep.Text = "Create Substitution Step";
			this.cmdSubmitSubsStep.Size = new System.Drawing.Size(197, 23);
			this.cmdSubmitSubsStep.Location = new System.Drawing.Point(550, 38);
			this.cmdSubmitSubsStep.TabIndex = 11;
			this.cmdSubmitSubsStep.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdSubmitSubsStep.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSubmitSubsStep.CausesValidation = true;
			this.cmdSubmitSubsStep.Enabled = true;
			this.cmdSubmitSubsStep.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSubmitSubsStep.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSubmitSubsStep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSubmitSubsStep.TabStop = true;
			this.cmdSubmitSubsStep.Name = "cmdSubmitSubsStep";
			this.lstSubmissionDef.Size = new System.Drawing.Size(733, 302);
			this.lstSubmissionDef.Location = new System.Drawing.Point(25, 122);
			this.lstSubmissionDef.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstSubmissionDef.TabIndex = 9;
			this.lstSubmissionDef.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstSubmissionDef.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSubmissionDef.BackColor = System.Drawing.SystemColors.Window;
			this.lstSubmissionDef.CausesValidation = true;
			this.lstSubmissionDef.Enabled = true;
			this.lstSubmissionDef.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSubmissionDef.IntegralHeight = true;
			this.lstSubmissionDef.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSubmissionDef.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSubmissionDef.Sorted = false;
			this.lstSubmissionDef.TabStop = true;
			this.lstSubmissionDef.Visible = true;
			this.lstSubmissionDef.MultiColumn = false;
			this.lstSubmissionDef.Name = "lstSubmissionDef";
			this._cmdDelCriteria_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdDelCriteria_0.Text = "Delete Criteria";
			this._cmdDelCriteria_0.Size = new System.Drawing.Size(113, 22);
			this._cmdDelCriteria_0.Location = new System.Drawing.Point(29, 460);
			this._cmdDelCriteria_0.TabIndex = 6;
			this._cmdDelCriteria_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdDelCriteria_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdDelCriteria_0.CausesValidation = true;
			this._cmdDelCriteria_0.Enabled = true;
			this._cmdDelCriteria_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdDelCriteria_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdDelCriteria_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdDelCriteria_0.TabStop = true;
			this._cmdDelCriteria_0.Name = "_cmdDelCriteria_0";
			this._cmdAddCriteria_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdAddCriteria_0.Text = "Add Criteria";
			this._cmdAddCriteria_0.Size = new System.Drawing.Size(113, 22);
			this._cmdAddCriteria_0.Location = new System.Drawing.Point(29, 435);
			this._cmdAddCriteria_0.TabIndex = 5;
			this._cmdAddCriteria_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdAddCriteria_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdAddCriteria_0.CausesValidation = true;
			this._cmdAddCriteria_0.Enabled = true;
			this._cmdAddCriteria_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdAddCriteria_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdAddCriteria_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdAddCriteria_0.TabStop = true;
			this._cmdAddCriteria_0.Name = "_cmdAddCriteria_0";
			this._cmdChangeAndOrCond_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdChangeAndOrCond_0.Text = "Change And/Or of the Criteria Set(s)";
			this._cmdChangeAndOrCond_0.Size = new System.Drawing.Size(247, 22);
			this._cmdChangeAndOrCond_0.Location = new System.Drawing.Point(513, 434);
			this._cmdChangeAndOrCond_0.TabIndex = 4;
			this._cmdChangeAndOrCond_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdChangeAndOrCond_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdChangeAndOrCond_0.CausesValidation = true;
			this._cmdChangeAndOrCond_0.Enabled = true;
			this._cmdChangeAndOrCond_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdChangeAndOrCond_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdChangeAndOrCond_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdChangeAndOrCond_0.TabStop = true;
			this._cmdChangeAndOrCond_0.Name = "_cmdChangeAndOrCond_0";
			this._cmdChangeAddOrBetweenSets_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdChangeAddOrBetweenSets_0.Text = "Change And/Or Between Sets in Step";
			this._cmdChangeAddOrBetweenSets_0.Size = new System.Drawing.Size(247, 22);
			this._cmdChangeAddOrBetweenSets_0.Location = new System.Drawing.Point(513, 460);
			this._cmdChangeAddOrBetweenSets_0.TabIndex = 3;
			this._cmdChangeAddOrBetweenSets_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdChangeAddOrBetweenSets_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdChangeAddOrBetweenSets_0.CausesValidation = true;
			this._cmdChangeAddOrBetweenSets_0.Enabled = true;
			this._cmdChangeAddOrBetweenSets_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdChangeAddOrBetweenSets_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdChangeAddOrBetweenSets_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdChangeAddOrBetweenSets_0.TabStop = true;
			this._cmdChangeAddOrBetweenSets_0.Name = "_cmdChangeAddOrBetweenSets_0";
			this.cmdModifyCriteriaField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdModifyCriteriaField.Text = "Modify Criteria Field";
			this.cmdModifyCriteriaField.Size = new System.Drawing.Size(247, 22);
			this.cmdModifyCriteriaField.Location = new System.Drawing.Point(209, 435);
			this.cmdModifyCriteriaField.TabIndex = 2;
			this.cmdModifyCriteriaField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdModifyCriteriaField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdModifyCriteriaField.CausesValidation = true;
			this.cmdModifyCriteriaField.Enabled = true;
			this.cmdModifyCriteriaField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdModifyCriteriaField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdModifyCriteriaField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdModifyCriteriaField.TabStop = true;
			this.cmdModifyCriteriaField.Name = "cmdModifyCriteriaField";
			this.cmdModifyCriteriaOperator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdModifyCriteriaOperator.Text = "Modify Criteria Operator";
			this.cmdModifyCriteriaOperator.Size = new System.Drawing.Size(247, 24);
			this.cmdModifyCriteriaOperator.Location = new System.Drawing.Point(209, 462);
			this.cmdModifyCriteriaOperator.TabIndex = 1;
			this.cmdModifyCriteriaOperator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdModifyCriteriaOperator.BackColor = System.Drawing.SystemColors.Control;
			this.cmdModifyCriteriaOperator.CausesValidation = true;
			this.cmdModifyCriteriaOperator.Enabled = true;
			this.cmdModifyCriteriaOperator.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdModifyCriteriaOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdModifyCriteriaOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdModifyCriteriaOperator.TabStop = true;
			this.cmdModifyCriteriaOperator.Name = "cmdModifyCriteriaOperator";
			this.cmdModifyCriteriaValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdModifyCriteriaValue.Text = "Modify Criteria Value";
			this.cmdModifyCriteriaValue.Size = new System.Drawing.Size(247, 23);
			this.cmdModifyCriteriaValue.Location = new System.Drawing.Point(209, 490);
			this.cmdModifyCriteriaValue.TabIndex = 0;
			this.cmdModifyCriteriaValue.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdModifyCriteriaValue.BackColor = System.Drawing.SystemColors.Control;
			this.cmdModifyCriteriaValue.CausesValidation = true;
			this.cmdModifyCriteriaValue.Enabled = true;
			this.cmdModifyCriteriaValue.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdModifyCriteriaValue.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdModifyCriteriaValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdModifyCriteriaValue.TabStop = true;
			this.cmdModifyCriteriaValue.Name = "cmdModifyCriteriaValue";
			this.lblIndicatorDesc.Text = "Label2";
			this.lblIndicatorDesc.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblIndicatorDesc.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.lblIndicatorDesc.Size = new System.Drawing.Size(717, 28);
			this.lblIndicatorDesc.Location = new System.Drawing.Point(32, 7);
			this.lblIndicatorDesc.TabIndex = 10;
			this.lblIndicatorDesc.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblIndicatorDesc.BackColor = System.Drawing.SystemColors.Control;
			this.lblIndicatorDesc.Enabled = true;
			this.lblIndicatorDesc.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblIndicatorDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblIndicatorDesc.UseMnemonic = true;
			this.lblIndicatorDesc.Visible = true;
			this.lblIndicatorDesc.AutoSize = false;
			this.lblIndicatorDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblIndicatorDesc.Name = "lblIndicatorDesc";
			this.lblMeasureStep.Text = "The Steps in Verification process";
			this.lblMeasureStep.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblMeasureStep.ForeColor = System.Drawing.Color.Blue;
			this.lblMeasureStep.Size = new System.Drawing.Size(489, 22);
			this.lblMeasureStep.Location = new System.Drawing.Point(28, 33);
			this.lblMeasureStep.TabIndex = 8;
			this.lblMeasureStep.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblMeasureStep.BackColor = System.Drawing.SystemColors.Control;
			this.lblMeasureStep.Enabled = true;
			this.lblMeasureStep.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblMeasureStep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblMeasureStep.UseMnemonic = true;
			this.lblMeasureStep.Visible = true;
			this.lblMeasureStep.AutoSize = false;
			this.lblMeasureStep.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblMeasureStep.Name = "lblMeasureStep";
			this._Label4_0.Text = "The Step will been substitued with the following criteria in the Submission process";
			this._Label4_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._Label4_0.ForeColor = System.Drawing.Color.Blue;
			this._Label4_0.Size = new System.Drawing.Size(653, 22);
			this._Label4_0.Location = new System.Drawing.Point(24, 95);
			this._Label4_0.TabIndex = 7;
			this._Label4_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label4_0.BackColor = System.Drawing.SystemColors.Control;
			this._Label4_0.Enabled = true;
			this._Label4_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label4_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label4_0.UseMnemonic = true;
			this._Label4_0.Visible = true;
			this._Label4_0.AutoSize = false;
			this._Label4_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label4_0.Name = "_Label4_0";
			this.Label4.SetIndex(_Label4_0, Convert.ToInt16(0));
			this.cmdAddCriteria.SetIndex(_cmdAddCriteria_0, Convert.ToInt16(0));
			this.cmdChangeAddOrBetweenSets.SetIndex(_cmdChangeAddOrBetweenSets_0, Convert.ToInt16(0));
			this.cmdChangeAndOrCond.SetIndex(_cmdChangeAndOrCond_0, Convert.ToInt16(0));
			this.cmdDelCriteria.SetIndex(_cmdDelCriteria_0, Convert.ToInt16(0));
			((System.ComponentModel.ISupportInitialize)this.cmdDelCriteria).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmdChangeAndOrCond).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmdChangeAddOrBetweenSets).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmdAddCriteria).EndInit();
			((System.ComponentModel.ISupportInitialize)this.Label4).EndInit();
			this.Controls.Add(cmdRemoveSubmitSubsStep);
			this.Controls.Add(cmdSubmitSubsStep);
			this.Controls.Add(lstSubmissionDef);
			this.Controls.Add(_cmdDelCriteria_0);
			this.Controls.Add(_cmdAddCriteria_0);
			this.Controls.Add(_cmdChangeAndOrCond_0);
			this.Controls.Add(_cmdChangeAddOrBetweenSets_0);
			this.Controls.Add(cmdModifyCriteriaField);
			this.Controls.Add(cmdModifyCriteriaOperator);
			this.Controls.Add(cmdModifyCriteriaValue);
			this.Controls.Add(lblIndicatorDesc);
			this.Controls.Add(lblMeasureStep);
			this.Controls.Add(_Label4_0);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
