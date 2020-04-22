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
    public partial class MenuControl : UserControl
    {
        public MenuControl()
        {
            InitializeComponent();
        }

        private void NewGameButtonEvent(object sender, EventArgs e)
        {
            Hide();
            NewGameControl newGameControl = new NewGameControl();
            Controls.Add(newGameControl);
            newGameControl.Show();
        }

        private void OptionsButtonEvent(object sender, EventArgs e)
        {
            Hide();
            OptionsControl optionsControl = new OptionsControl();
            Controls.Add(optionsControl);
            optionsControl.Show();
        }

        private void ExitButtonEvent(object sender, EventArgs e)
        {
            ((WarcabyForm)this.TopLevelControl).Close();
        }
    }
}
