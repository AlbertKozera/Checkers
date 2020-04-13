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
    public partial class UserControlOptions : UserControl
    {
        public UserControlOptions()
        {
            InitializeComponent();
        }

        private void backToManu(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
