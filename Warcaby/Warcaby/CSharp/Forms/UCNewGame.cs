using System;
using System.Windows.Forms;
using Warcaby.Service.Context;

namespace Warcaby.Forms
{
    public partial class UCNewGame : UserControl
    {
        GameService serviceTmp = new GameService();

        public UCNewGame()
        {
            
            InitializeComponent();
        }

        private void UCNewGame_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 31; i++)
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

        private void DragDropEvent(object sender, DragEventArgs e)
        {
            MyDraggedData data = (MyDraggedData)e.Data.GetData(typeof(MyDraggedData));
            PictureBox fieldTo = (PictureBox)sender;
            PictureBox fieldFrom = (PictureBox)data.Data;

            serviceTmp.GameChooser(fieldFrom, fieldTo);
        }

        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
            PictureBox fieldFrom = (PictureBox)sender;                    
            MyDraggedData data = new MyDraggedData();
            data.Data = fieldFrom;
            fieldFrom.DoDragDrop(data, DragDropEffects.Move);
        }

        private void DragEnteEvent(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
