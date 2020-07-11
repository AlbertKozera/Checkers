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
        Boolean round = true;


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
                if (round)
                {
                    //ustawiamy odpowiednią bitmape && rusza się biały
                    forcedBeatingForPawnList = checkerLogic.DoesPawnHaveAnyBeating(gameBoard, "white");
                    if (Extend.IsNullOrEmpty(forcedBeatingForPawnList) && (indexTo == indexFrom + 7 || indexTo == indexFrom + 9))
                    {
                        
                        
                        // aktualizacja dokąd
                        fieldTo.Image = fieldFrom.Image;
                        gameBoard[indexTo] = Constant.PAWN_WHITE;
                        round = false;

                        // aktualizacja skąd
                        fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
                        gameBoard[indexFrom] = Constant.EMPTY_FIELD;




                    }
                    else if (indexTo == indexFrom - 14 || indexTo == indexFrom - 18 || indexTo == indexFrom + 14 || indexTo == indexFrom + 18)
                    {
                        forcedBeatingForPawnList.ForEach(delegate (Tuple<int, int, int> forcedBeatingForPawnTuple)
                        {
                            if (forcedBeatingForPawnTuple.Item2 == indexTo) 
                            {                             
                                // aktualizacja dokąd
                                fieldTo.Image = fieldFrom.Image;
                                gameBoard[indexTo] = Constant.PAWN_WHITE;

                                // aktualizacja skąd
                                fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
                                gameBoard[indexFrom] = Constant.EMPTY_FIELD;

                                // aktualizacja zbitego pionka
                                PictureBox beatenPawnField = (PictureBox)Controls.Find("field_" + forcedBeatingForPawnTuple.Item3, true)[0];
                                beatenPawnField.Image = new Bitmap(Properties.Resources.empty_field);
                                gameBoard[forcedBeatingForPawnTuple.Item3] = Constant.EMPTY_FIELD;                                                           
                            }
                        });                        
                        
                        forcedBeatingForPawnList = checkerLogic.DoesPawnHaveAnyBeating(gameBoard, "white"); //Tą funkcję trzeba wywołać dla jednego pola
                        if (Extend.IsNullOrEmpty(forcedBeatingForPawnList)) //jeśli nie ma bicia
                            round = false;
                        else
                            round = true;

                        forcedBeatingForPawnList.Clear();
                    }
                }
                else if (!round)
                {
                    //ustawiamy odpowiednią bitmape && rusza się czerwony
                    forcedBeatingForPawnList = checkerLogic.DoesPawnHaveAnyBeating(gameBoard, "red");
                    if (Extend.IsNullOrEmpty(forcedBeatingForPawnList) && (indexTo == indexFrom - 7 || indexTo == indexFrom - 9))
                    {
                        fieldTo.Image = fieldFrom.Image;
                        gameBoard[indexTo] = Constant.PAWN_RED;
                        round = true;



                            // aktualizacja skąd
                        fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
                        gameBoard[indexFrom] = Constant.EMPTY_FIELD;
                    }
                    else if (indexTo == indexFrom - 14 || indexTo == indexFrom - 18 || indexTo == indexFrom + 14 || indexTo == indexFrom + 18)
                    {
                        forcedBeatingForPawnList.ForEach(delegate (Tuple<int, int, int> forcedBeatingForPawnTuple)
                        {
                            if (forcedBeatingForPawnTuple.Item2 == indexTo)
                            {
                                
                                // aktualizacja dokąd
                                fieldTo.Image = fieldFrom.Image;
                                gameBoard[indexTo] = Constant.PAWN_RED;

                                // aktualizacja skąd
                                fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
                                gameBoard[indexFrom] = Constant.EMPTY_FIELD;

                                // aktualizacja zbitego pionka
                                PictureBox beatenPawnField = (PictureBox)Controls.Find("field_" + forcedBeatingForPawnTuple.Item3, true)[0];
                                beatenPawnField.Image = new Bitmap(Properties.Resources.empty_field);
                                gameBoard[forcedBeatingForPawnTuple.Item3] = Constant.EMPTY_FIELD;



                                
                            }
                        });
                        
                        
                        forcedBeatingForPawnList = checkerLogic.DoesPawnHaveAnyBeating(gameBoard, "red"); //Tą funkcję trzeba wywołać dla jednego pola
                        if (Extend.IsNullOrEmpty(forcedBeatingForPawnList))
                            round = true;
                        else
                            round = false;

                        forcedBeatingForPawnList.Clear();
                    }
                }
            }
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




    }
}
