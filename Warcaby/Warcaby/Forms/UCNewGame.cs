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
        public List<Tuple<int, int, int>> forcedBeatingForPawnList;
        public Dictionary<int, Field> gameBoard = new Dictionary<int, Field>();
        CheckerLogic checkerLogic = new CheckerLogic();
        Boolean isDragDropEndSucces = false;
        Boolean round = true;
        int beatenPawnPosition;
        public UCNewGame()
        {
            InitializeComponent();
            // Loading white pawns
            for (int i = 2; i <= 24; i += 2)
            {
                gameBoard.Add(i, new Field(false, true, false, "white"));
                if (i == 8) i--;
                if (i == 15) i++;
            }
            // Loading empty fields
            for (int i = 25; i <= 40; i += 2)
            {
                gameBoard.Add(i, new Field(true, false, false, ""));
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
            PictureBox fieldTo = (PictureBox)sender;
            int indexTo = Int16.Parse(fieldTo.Tag.ToString());
            MyDraggedData data = (MyDraggedData)e.Data.GetData(typeof(MyDraggedData));
            PictureBox fieldFrom = (PictureBox)data.Data;
            int indexFrom = Int16.Parse(fieldFrom.Tag.ToString());

            // sprawdzamy czy pole na które chcemy postwić pionek jest puste
            if (gameBoard[indexTo].isEmptyField)
            {
                if (gameBoard[indexFrom].color.Equals("white") && round)
                {
                    //ustawiamy odpowiednią bitmape && rusza się biały
                    forcedBeatingForPawnList = checkerLogic.DoesPawnHaveAnyBeating(gameBoard, "white");
                    if (Extend.IsNullOrEmpty(forcedBeatingForPawnList) && (indexTo == indexFrom + 7 || indexTo == indexFrom + 9))
                    {
                        fieldTo.Image = fieldFrom.Image;
                        gameBoard[indexTo] = Constant.PAWN_WHITE;
                        isDragDropEndSucces = true;
                        round = false;
                    }
                    else if (indexTo == indexFrom - 14 || indexTo == indexFrom - 18 || indexTo == indexFrom + 14 || indexTo == indexFrom + 18)
                    {
                        forcedBeatingForPawnList.ForEach(delegate (Tuple<int, int, int> forcedBeatingForPawnTuple)
                        {
                            if (forcedBeatingForPawnTuple.Item2 == indexTo) //sprawdzenie czy biały pionek zbił przeciwny pionek - przymusowe bicie
                            {
                                beatenPawnPosition = forcedBeatingForPawnTuple.Item3;
                                fieldTo.Image = fieldFrom.Image;
                                gameBoard[indexTo] = Constant.PAWN_WHITE;
                                isDragDropEndSucces = true;
                            }
                        });
                        forcedBeatingForPawnList.Clear();
                    }
                }
                else if (gameBoard[indexFrom].color.Equals("red") && !round)
                {
                    //ustawiamy odpowiednią bitmape && rusza się biały
                    forcedBeatingForPawnList = checkerLogic.DoesPawnHaveAnyBeating(gameBoard, "red");
                    if (Extend.IsNullOrEmpty(forcedBeatingForPawnList) && (indexTo == indexFrom - 7 || indexTo == indexFrom - 9))
                    {
                        fieldTo.Image = fieldFrom.Image;
                        gameBoard[indexTo] = Constant.PAWN_RED;
                        isDragDropEndSucces = true;
                        round = true;
                    }
                    else if (indexTo == indexFrom - 14 || indexTo == indexFrom - 18 || indexTo == indexFrom + 14 || indexTo == indexFrom + 18)
                    {
                        forcedBeatingForPawnList.ForEach(delegate (Tuple<int, int, int> forcedBeatingForPawnTuple)
                        {
                            if (forcedBeatingForPawnTuple.Item2 == indexTo)
                            {
                                beatenPawnPosition = forcedBeatingForPawnTuple.Item3;
                                fieldTo.Image = fieldFrom.Image;
                                gameBoard[indexTo] = Constant.PAWN_RED;
                                isDragDropEndSucces = true;
                            }
                        });
                        forcedBeatingForPawnList.Clear();
                    }
                }
            }
        }

        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
            beatenPawnPosition = 0;
            PictureBox fieldFrom = (PictureBox)sender;
            MyDraggedData data = new MyDraggedData();
            data.Data = fieldFrom;
            // sprawdzamy czy zakończyła się operacja drag drop, oraz czy jest możliwość postawienia pionka na wybranym przez nas polu
            if ((fieldFrom.DoDragDrop(data, DragDropEffects.Move) == DragDropEffects.Move) && isDragDropEndSucces == true)
            {
                int indexFrom = Int16.Parse(fieldFrom.Tag.ToString());
                fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
                gameBoard[indexFrom] = Constant.EMPTY_FIELD;
                isDragDropEndSucces = false;
                if (beatenPawnPosition != 0 && gameBoard[beatenPawnPosition].isPawn) //potem trzeba dodać damkę bo jest tylko dla pionka warunek
                {
                    Field tmp = gameBoard[beatenPawnPosition];
                    PictureBox beatenPawnField = (PictureBox)Controls.Find("field_" + beatenPawnPosition, true)[0];
                    beatenPawnField.Image = new Bitmap(Properties.Resources.empty_field);
                    gameBoard[beatenPawnPosition] = Constant.EMPTY_FIELD;
                    isDragDropEndSucces = false;

                    if (tmp.color.Equals("white"))
                    {
                        forcedBeatingForPawnList = checkerLogic.DoesPawnHaveAnyBeating(gameBoard, "red"); //Tą funkcję trzeba wywołać dla jednego pola
                        if (Extend.IsNullOrEmpty(forcedBeatingForPawnList))
                            round = true;
                        else
                            round = false;
                    }
                    else
                    {
                        forcedBeatingForPawnList = checkerLogic.DoesPawnHaveAnyBeating(gameBoard, "white"); //Tą funkcję trzeba wywołać dla jednego pola
                        if (Extend.IsNullOrEmpty(forcedBeatingForPawnList)) //jeśli nie ma bicia
                            round = false;
                        else
                            round = true;
                    }
                    forcedBeatingForPawnList.Clear();
                }
            }
        }

        private void DragEnteEvent(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }




    }
}
