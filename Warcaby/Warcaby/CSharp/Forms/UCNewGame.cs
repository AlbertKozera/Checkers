using System;
using System.Windows.Forms;
using Warcaby.CSharp.Game.Context.Impl;
using Warcaby.CSharp.Service;
using Warcaby.Forms;
using Warcaby.Service.Context;


namespace Warcaby.CSharp.Forms
{
    public partial class UCNewGame : UserControl
    {
        GameService gameService = new GameService();
        LoggerService logger = new LoggerService();
        System.Diagnostics.Stopwatch watchRed;
        System.Diagnostics.Stopwatch watchWhite;
        int i = 0;
        int j = 0;
        int typeOfGame;



        public UCNewGame(int typeOfGame)
        {
            InitializeComponent();
            this.typeOfGame = typeOfGame;
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
            ClientStage.SendMessageToServer("Player " + ClientStage.myColor + " disconnected");
            ClientStage.client.Disconnect();
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
            //gameService.GameChooser(fieldFrom, fieldTo, typeOfGame);

            string[] dataArray = new string[2];
            dataArray[0] = Extend.GetIndexByFieldName(fieldFrom.Name);
            dataArray[1] = Extend.GetIndexByFieldName(fieldTo.Name);
            ClientStage.SendDataToServer(dataArray);
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
