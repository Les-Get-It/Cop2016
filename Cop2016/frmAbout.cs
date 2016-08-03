using System;
using System.Collections.Generic;
using System.Drawing;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmAbout : Telerik.WinControls.UI.RadForm
    {
        public frmAbout()
        {
            InitializeComponent();this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true; this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
