using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warcaby.Forms;

namespace Warcaby.CSharp.Service
{
    public class OptionsService
    {

        public string CreateFileAndGetPath(string optionFilePath)
        {
            optionFilePath = Directory.GetParent(Directory.GetParent(optionFilePath).FullName).FullName;
            optionFilePath += @"\Resources\OptionsState.txt";
            if (!File.Exists(optionFilePath))
            {
                File.Create(optionFilePath).Dispose();
                using (TextWriter textWriter = new StreamWriter(optionFilePath))
                {
                    textWriter.WriteLine("Unchecked");
                    textWriter.WriteLine("Unchecked");
                }
            }
            return optionFilePath;
        }

        private void EditLine(string newText, string fileName, int line) //Funkcja odpowiedzialna za edycje wskazanej linii w pliku
        {
            string[] readLine = File.ReadAllLines(fileName);
            readLine[line - 1] = newText;
            File.WriteAllLines(fileName, readLine);
        }

        public void LoadCheckBoxes(CheckBox checkBoxThread, CheckBox checkBoxStartingGame, string optionFilePath)
        {
            string readFirstLine = File.ReadLines(optionFilePath).First();
            if (readFirstLine == "Checked")
            {
                checkBoxThread.Checked = true;
            }
            else
            {
                checkBoxThread.Checked = false;
            }
            string readSecondLine = File.ReadLines(optionFilePath).Skip(1).First();
            if (readSecondLine == "Checked")
            {
                checkBoxStartingGame.Checked = true;
            }
            else
            {
                checkBoxStartingGame.Checked = false;
            }
        }

        public void CheckBoxMultiThreading(CheckBox checkBoxThread, string optionFilePath)
        {
            if (checkBoxThread.Checked)
            {
                EditLine("Checked", optionFilePath, 1);
            }
            else
            {
                EditLine("Unchecked", optionFilePath, 1);
            }
        }

        public void ChangeBoxStartingGame(CheckBox checkBoxStartingGame, string optionFilePath)
        {
            if (checkBoxStartingGame.Checked)
            {
                EditLine("Checked", optionFilePath, 2);
            }
            else
            {
                EditLine("Unchecked", optionFilePath, 2);
            }
        }
    }
}
