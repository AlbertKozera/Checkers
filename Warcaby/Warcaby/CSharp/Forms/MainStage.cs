using System;
using System.Windows.Forms;


namespace Warcaby.CSharp.Forms
{
    public partial class MainStage : Form
    {
        public MainStage()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            ucMainMenu.Visible = true;
            ucNewGame.Visible = false;
            ucOptions.Visible = false;
            ucTypeOfGame.Visible = false;
        }
    }
}
