using System;
using System.IO;
using System.Windows.Forms;
using Warcaby.CSharp.Service;

namespace Warcaby.CSharp.Forms
{
    public partial class UCOptions : UserControl
    {
        OptionsService optionsService = new OptionsService();
        string filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

        public UCOptions()
        {
            InitializeComponent();
            filePath = optionsService.CreateFileAndGetPath(filePath).ToString();
        }
        private void backToMenu(object sender, EventArgs e)
        {
            Controls.Clear();
            UCMainMenu ucMainMenu = new UCMainMenu();
            Controls.Add(ucMainMenu);
            ucMainMenu.Show();
        }
        private void checkBoxThreadYes_CheckedChanged(object sender, EventArgs e)
        {
            optionsService.CheckBoxMultiThreading(checkBoxThread ,filePath);
        }
        private void UCOptions_Load(object sender, EventArgs e)
        {
            optionsService.LoadCheckBoxes(checkBoxThread, checkBoxStartingGame, filePath);
        }
        private void CheckBoxStartingGame_CheckedChanged(object sender, EventArgs e)
        {
            optionsService.ChangeBoxStartingGame(checkBoxStartingGame, filePath);
        }
    }
}
