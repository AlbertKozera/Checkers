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

        private void newGameEvent(object sender, EventArgs e)
        {
            Controls.Clear();
            UCNewGame ucNewGame = new UCNewGame();
            Controls.Add(ucNewGame);
            ucNewGame.Show();
        }

        private void optionsEvent(object sender, EventArgs e)
        {
            Controls.Clear();
            UCOptions ucOptions = new UCOptions();
            Controls.Add(ucOptions);
            ucOptions.Show();
        }

        private void exitEvent(object sender, EventArgs e)
        {
            ((MainStage)this.TopLevelControl).Close();
        }
    }
}
