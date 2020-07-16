using System;
using System.Globalization;
using System.Windows.Forms;
using Warcaby.CSharp.Game.Context;
using Warcaby.CSharp.Service;
using Warcaby.Service.Context;

namespace Warcaby.Forms
{
    public partial class UCNewGame : UserControl
    {
        GameService gameService = new GameService();
        LoggerService logger = new LoggerService();
        System.Diagnostics.Stopwatch watchRed;
        System.Diagnostics.Stopwatch watchWhite;
        int i = 0;
        int j = 0;

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
            gameService.GameChooser(fieldFrom, fieldTo);
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

        private void TimerTurnEvent(object sender, EventArgs e)
        {
            i++;
            if (i < 2 && !GameService.whiteTurn)
            {
                watchRed = System.Diagnostics.Stopwatch.StartNew();
            }
            if (i > 1 && GameService.whiteTurn)
            {
                watchRed.Stop();
                LoggerService.timer = watchRed.ElapsedMilliseconds;
                logger.WriteLogger(GameService.whiteTurn, GameService.indexFrom, GameLogic.indexThrough, GameService.indexTo, GameService.fieldFrom, GameService.fieldTo);
                i = 0;
                watchWhite = System.Diagnostics.Stopwatch.StartNew();
            }

            j++;
            if (j > 1 && !GameService.whiteTurn)
            {
                watchWhite.Stop();
                LoggerService.timer = watchWhite.ElapsedMilliseconds;
                logger.WriteLogger(GameService.whiteTurn, GameService.indexFrom, GameLogic.indexThrough, GameService.indexTo, GameService.fieldFrom, GameService.fieldTo);
                j = 0;
            }
        }
    }
}
