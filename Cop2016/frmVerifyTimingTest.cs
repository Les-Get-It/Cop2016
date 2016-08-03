using System;
using System.Collections.Generic;
using System.Drawing;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmVerifyTimingTest : Telerik.WinControls.UI.RadForm
    {
        public frmVerifyTimingTest()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void frmVerifyTimingTest_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
