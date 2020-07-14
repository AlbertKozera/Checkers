using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using Warcaby.CSharp.Service;

namespace Warcaby.Forms
{
    public partial class UCOptions : UserControl
    {
        OptionService optionService = new OptionService();
        string filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

        public UCOptions()
        {
            InitializeComponent();
            filePath = optionService.CreateFileAndGetPath(filePath).ToString();
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
            optionService.CheckBoxMultiThreading(checkBoxThread ,filePath);
        }
        private void UCOptions_Load(object sender, EventArgs e)
        {
            optionService.LoadCheckBoxes(checkBoxThread, checkBoxStartingGame, filePath);
        }
        private void CheckBoxStartingGame_CheckedChanged(object sender, EventArgs e)
        {
            optionService.ChangeBoxStartingGame(checkBoxStartingGame, filePath);
        }
    }
}
