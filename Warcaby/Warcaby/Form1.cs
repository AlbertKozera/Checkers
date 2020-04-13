using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warcaby
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newGameButton(object sender, EventArgs e)
        {
            userControlNewGame1.Visible = true;
            userControlOptions1.Visible = false;
        }

        private void optionsButton(object sender, EventArgs e)
        {
            userControlNewGame1.Visible = false;
            userControlOptions1.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userControlNewGame1.Visible = false;
            userControlOptions1.Visible = false;
        }
    }
}
