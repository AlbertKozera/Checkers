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

namespace Warcaby.Forms
{
    public partial class UCOptions : UserControl
    {
        public UCOptions()
        {
            InitializeComponent();
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
            if (checkBoxThread.Checked)
            {
                string filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                filePath = Directory.GetParent(Directory.GetParent(filePath).FullName).FullName;
                filePath += @"\Resources\threadOption.txt";
                TextWriter text = new StreamWriter(filePath);
                text.WriteLine("Tak");
                text.Close();
            } 
            else 
            {
                string filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                filePath = Directory.GetParent(Directory.GetParent(filePath).FullName).FullName;
                filePath += @"\Resources\threadOption.txt";
                TextWriter text = new StreamWriter(filePath);
                text.WriteLine("Nie");
                text.Close();
            }
        }

        private void UCOptions_Load(object sender, EventArgs e)
        {
            string filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            filePath = Directory.GetParent(Directory.GetParent(filePath).FullName).FullName;
            filePath += @"\Resources\threadOption.txt";
            string readText = File.ReadLines(filePath).First();
            if (readText == "Tak")
            {
                checkBoxThread.Checked = true;
            } if(readText == "Nie")
            {
                checkBoxThread.Checked = false;
            }

        }

        
    }
}
