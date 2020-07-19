using System;
using System.Windows.Forms;

namespace Warcaby.CSharp.Forms
{
    public partial class UCTypeOfGame : UserControl
    {
        public UCTypeOfGame()
        {
            InitializeComponent();
        }

        private void GoToNewGame()
        {
            Controls.Clear();
            UCNewGame ucNewGame = new UCNewGame();
            Controls.Add(ucNewGame);
            ucNewGame.Show();
        }

        private void ButtonComputerVSComputer_Click(object sender, EventArgs e)
        {
            GoToNewGame();
        }

        private void ButtonPlayerVSComputer_Click(object sender, EventArgs e)
        {
            GoToNewGame();
        }

        private void ButtonPlayerVSPlayer_Click(object sender, EventArgs e)
        {
            GoToNewGame();
        }

        private void UCTypeOfGame_Load(object sender, EventArgs e)
        {

        }

        private void backToMenu(object sender, EventArgs e)
        {
            Controls.Clear();
            UCMainMenu ucMainMenu = new UCMainMenu();
            Controls.Add(ucMainMenu);
            ucMainMenu.Show();
        }
    }
}
