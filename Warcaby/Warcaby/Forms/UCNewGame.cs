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
    public partial class UCNewGame : UserControl
    {
        public Dictionary<int, Field> gameBoard = new Dictionary<int, Field>();
        public UCNewGame()
        {
            InitializeComponent();
            // Loading white pawns
            for(int i = 2; i <= 24; i +=2)
            {
                gameBoard.Add(i, new Field(false, true, false, "white"));
                if (i == 8) i--;
                if (i == 15) i++;
            }
            // Loading empty fields
            for (int i = 25; i <= 40; i += 2)
            {
                gameBoard.Add(i, new Field(true, false, false, null));
                if (i == 31) i++;
            }
            // Loading red pawns
            for (int i = 41; i <= 63; i += 2)
            {
                gameBoard.Add(i, new Field(false, true, false, "red"));
                if (i == 47) i++;
                if (i == 56) i--;
            }
        }

        private void UCNewGame_Load(object sender, EventArgs e)
        {
            for(int i = 0; i <= 31; i++)
            {
                fieldsContainer.Controls[i].AllowDrop = true;
            }
        }

        private void backToMenu(object sender, EventArgs e)
        {
            Controls.Clear();
            UCMainMenu ucMainMenu = new UCMainMenu();
            Controls.Add(ucMainMenu);
            ucMainMenu.Show();
        }

        private void DragDrop(object sender, DragEventArgs e)
        {
            PictureBox field = (PictureBox)sender;
            field.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
         
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            // if ---> isPawn isDame / odpowiedni kolor / brak przymusowego bicia
            PictureBox field = (PictureBox)sender;
            field.DoDragDrop(field_18.Image, DragDropEffects.Move);    
    
        }

        private void DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

    }
}
