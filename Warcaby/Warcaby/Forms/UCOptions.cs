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
        string filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                
        public UCOptions()
        {
            InitializeComponent();
            filePath = Directory.GetParent(Directory.GetParent(filePath).FullName).FullName;
            filePath += @"\Resources\threadOption.txt";
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
            TextWriter text = new StreamWriter(filePath);
            if (checkBoxThread.Checked)
            {
                text.WriteLine("Tak");
            } 
            else 
            {
                text.WriteLine("Nie");
            }
            text.Close();
        }

        private void UCOptions_Load(object sender, EventArgs e)
        {
            string readText = File.ReadLines(filePath).First();
            if (readText == "Tak")
            {
                checkBoxThread.Checked = true;
            } 
            else
            {
                checkBoxThread.Checked = false;
            }
        }      
        
    }
}
