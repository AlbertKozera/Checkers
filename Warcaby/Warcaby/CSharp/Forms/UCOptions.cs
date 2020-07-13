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
            filePath += @"\Resources\OptionsState.txt";
        }
        private void EditLine(string newText, string fileName, int line) //Funkcja odpowiednia za edycje wskazanej linii
        {
            string[] readLine = File.ReadAllLines(fileName);
            readLine[line - 1] = newText;
            File.WriteAllLines(fileName, readLine);
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
                EditLine("Checked", filePath, 1);
            } else 
            {
                EditLine("False", filePath, 1);
            }
        }

        private void UCOptions_Load(object sender, EventArgs e)
        {
            string readFirstLine = File.ReadLines(filePath).First();
            if (readFirstLine == "Checked")
            {
                checkBoxThread.Checked = true;
            } 
            else
            {
                checkBoxThread.Checked = false;
            }
            string readSecondLine = File.ReadLines(filePath).Skip(1).First();
            if (readSecondLine == "Checked")
            {
                checkBoxStartingGame.Checked = true;
            } else
            {
                checkBoxStartingGame.Checked = false;
            }
        }

        private void CheckBoxStartingGame_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStartingGame.Checked)
            {
                EditLine("Checked", filePath, 2);
            } else
            {
                EditLine("Unchecked", filePath, 2);
            }
        }
    }
}
