using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace COP2001
{
    class RadInputBox
    {
        public static string Show(string Prompt, string Title, string DefaultResponse = "")
        {
            RadInputBoxInternal inputBox = new RadInputBoxInternal();
            inputBox.StartPosition = FormStartPosition.CenterParent;
            inputBox.LabelQuestion.Text = Prompt;
            inputBox.Text = Title;

            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                return inputBox.TextBoxInput.Text;
            }
            else
            {
                return DefaultResponse;
            }
        }

        private class RadInputBoxInternal : Telerik.WinControls.UI.RadForm
        {

            internal RadInputBoxInternal()
            {
                Shown += RadForm1_Shown;
                this.InitializeComponent();
            }

            [System.Diagnostics.DebuggerNonUserCode()]
            protected override void Dispose(bool disposing)
            {
                try
                {
                    if (disposing && components != null)
                    {
                        components.Dispose();
                    }
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }

            private System.ComponentModel.IContainer components;

            [System.Diagnostics.DebuggerStepThrough()]
            private void InitializeComponent()
            {
                this.ButtonOk = new Telerik.WinControls.UI.RadButton();
                this.ButtonCancel = new Telerik.WinControls.UI.RadButton();
                this.TextBoxInput = new Telerik.WinControls.UI.RadTextBox();
                this.LabelQuestion = new Telerik.WinControls.UI.RadLabel();
                ((System.ComponentModel.ISupportInitialize)this.ButtonOk).BeginInit();
                ((System.ComponentModel.ISupportInitialize)this.ButtonCancel).BeginInit();
                ((System.ComponentModel.ISupportInitialize)this.TextBoxInput).BeginInit();
                ((System.ComponentModel.ISupportInitialize)this.LabelQuestion).BeginInit();
                ((System.ComponentModel.ISupportInitialize)this).BeginInit();
                this.SuspendLayout();
                //
                //ButtonOk
                //
                this.ButtonOk.Location = new System.Drawing.Point(342, 12);
                this.ButtonOk.Name = "ButtonOk";
                this.ButtonOk.Size = new System.Drawing.Size(97, 24);
                this.ButtonOk.TabIndex = 0;
                this.ButtonOk.Text = "Ok";
                //
                //ButtonCancel
                //
                this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.ButtonCancel.Location = new System.Drawing.Point(342, 42);
                this.ButtonCancel.Name = "ButtonCancel";
                this.ButtonCancel.Size = new System.Drawing.Size(97, 24);
                this.ButtonCancel.TabIndex = 1;
                this.ButtonCancel.Text = "Cancel";
                //
                //TextBoxInput
                //
                this.TextBoxInput.Location = new System.Drawing.Point(13, 87);
                this.TextBoxInput.Name = "TextBoxInput";
                this.TextBoxInput.Size = new System.Drawing.Size(426, 20);
                this.TextBoxInput.TabIndex = 2;
                this.TextBoxInput.TabStop = false;
                //
                //LabelQuestion
                //
                this.LabelQuestion.AutoSize = false;
                this.LabelQuestion.Location = new System.Drawing.Point(13, 12);
                this.LabelQuestion.Name = "LabelQuestion";
                this.LabelQuestion.Size = new System.Drawing.Size(323, 69);
                this.LabelQuestion.TabIndex = 3;
                this.LabelQuestion.Text = "text";
                //
                //RadForm1
                //
                this.AcceptButton = this.ButtonOk;
                this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.CancelButton = this.ButtonCancel;
                this.ClientSize = new System.Drawing.Size(451, 119);
                this.Controls.Add(this.LabelQuestion);
                this.Controls.Add(this.TextBoxInput);
                this.Controls.Add(this.ButtonCancel);
                this.Controls.Add(this.ButtonOk);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "RadInputInternal";
                //
                //
                //
                this.RootElement.ApplyShapeToControl = true;
                this.Text = "RadInputInternal";
                ((System.ComponentModel.ISupportInitialize)this.ButtonOk).EndInit();
                ((System.ComponentModel.ISupportInitialize)this.ButtonCancel).EndInit();
                ((System.ComponentModel.ISupportInitialize)this.TextBoxInput).EndInit();
                ((System.ComponentModel.ISupportInitialize)this.LabelQuestion).EndInit();
                ((System.ComponentModel.ISupportInitialize)this).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();

            }
            private Telerik.WinControls.UI.RadButton withEventsField_ButtonOk;
            internal Telerik.WinControls.UI.RadButton ButtonOk
            {
                get { return withEventsField_ButtonOk; }
                set
                {
                    if (withEventsField_ButtonOk != null)
                    {
                        withEventsField_ButtonOk.Click -= ButtonOk_Click;
                    }
                    withEventsField_ButtonOk = value;
                    if (withEventsField_ButtonOk != null)
                    {
                        withEventsField_ButtonOk.Click += ButtonOk_Click;
                    }
                }
            }
            private Telerik.WinControls.UI.RadButton withEventsField_ButtonCancel;
            internal Telerik.WinControls.UI.RadButton ButtonCancel
            {
                get { return withEventsField_ButtonCancel; }
                set
                {
                    if (withEventsField_ButtonCancel != null)
                    {
                        withEventsField_ButtonCancel.Click -= ButtonCancel_Click;
                    }
                    withEventsField_ButtonCancel = value;
                    if (withEventsField_ButtonCancel != null)
                    {
                        withEventsField_ButtonCancel.Click += ButtonCancel_Click;
                    }
                }
            }
            internal Telerik.WinControls.UI.RadTextBox TextBoxInput;
            internal Telerik.WinControls.UI.RadLabel LabelQuestion;

            private void RadForm1_Shown(Object sender, EventArgs e)
            {
                this.TextBoxInput.SelectionLength = 0;
                this.TextBoxInput.Focus();
            }

            private void ButtonCancel_Click(Object sender, EventArgs e)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }

            private void ButtonOk_Click(Object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
