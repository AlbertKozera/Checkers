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
        Boolean flaga = false;

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

        public class MyDraggedData
        {
            public object Data { get; set; }
        }
                
        private void DragDrop(object sender, DragEventArgs e)
        {
            PictureBox fieldTo = (PictureBox)sender;              
            int indexTo = Int16.Parse(fieldTo.Tag.ToString());
            MyDraggedData data = (MyDraggedData)e.Data.GetData(typeof(MyDraggedData));
            PictureBox fieldFrom = new PictureBox();
            fieldFrom = (PictureBox)data.Data;

            
            // sprawdzamy czy można postawić pionek
            if (gameBoard[indexTo].isEmptyField) {
                // ustawiamy odpowiednią bitmape
                fieldTo.Image = fieldFrom.Image;                                
                int indexFrom = Int16.Parse(fieldFrom.Tag.ToString());
                gameBoard[indexTo].isPawn = true;
                gameBoard[indexTo].isEmptyField = false;
                gameBoard[indexTo].isDame = false;
                gameBoard[indexTo].color = gameBoard[indexFrom].color;
                flaga = true;
            }                  
        }
        
        private void MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox fieldFrom = (PictureBox)sender;
            MyDraggedData data = new MyDraggedData();
            data.Data = fieldFrom;
                       
            // sprawdzamy czy zakończyła się operacja drag drop, oraz czy jest możliwość postawienia pionka na wybranym przez nas polu
            if ((fieldFrom.DoDragDrop(data, DragDropEffects.Move) == DragDropEffects.Move) && flaga == true)
            {
                int indexFrom = Int16.Parse(fieldFrom.Tag.ToString());
                fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
                gameBoard[indexFrom].isEmptyField = true;
                gameBoard[indexFrom].isPawn = false;
                gameBoard[indexFrom].isDame = false;
                flaga = false;
            }

        }

        private void DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

    }
}
