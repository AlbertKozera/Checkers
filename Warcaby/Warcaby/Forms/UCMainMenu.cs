using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warcaby.Forms
{
    public partial class UCMainMenu : UserControl
    {
        public UCMainMenu()
        {
            InitializeComponent();
        }

        private void TypeOfGameEvent(object sender, EventArgs e)
        {
            Controls.Clear();
            UCTypeOfGame ucTypeOfGame = new UCTypeOfGame();
            Controls.Add(ucTypeOfGame);
            ucTypeOfGame.Show();
        }

        private void OptionsEvent(object sender, EventArgs e)
        {
            Controls.Clear();
            UCOptions ucOptions = new UCOptions();
            Controls.Add(ucOptions);
            ucOptions.Show();
        }

        private void ExitEvent(object sender, EventArgs e)
        {
            ((MainStage)this.TopLevelControl).Close();
        }
    }
}
