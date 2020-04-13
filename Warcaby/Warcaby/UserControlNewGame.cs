using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warcaby
{
    public partial class UserControlNewGame : UserControl
    {
        public UserControlNewGame()
        {
            InitializeComponent();
        }

        private void backToMenu(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
