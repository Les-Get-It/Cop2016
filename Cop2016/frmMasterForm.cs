using System;
using System.Collections.Generic;
using System.Drawing;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmMasterForm : Telerik.WinControls.UI.RadForm
    {
        public frmMasterForm()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";

            //Turns the radForm into a parent MDI form
            this.IsMdiContainer = true;
        }

        private void frmMasterForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
