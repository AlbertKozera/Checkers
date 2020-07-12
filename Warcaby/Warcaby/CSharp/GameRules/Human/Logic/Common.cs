using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Warcaby.CSharp.Dto;
using Warcaby.Service.Human;

namespace Warcaby.Forms
{
    public class Common
    {
        public List<Tuple<int, int, int>> anyBeating = new List<Tuple<int, int, int>>();


        public void CompleteTheDictionary()
        {
            TypeOfGame.gameBoard.Clear();
            // Loading white pawns
            for (int i = 2; i <= 24; i += 2)
            {
                TypeOfGame.gameBoard.Add(i, new Field(false, true, false, "white"));
                if (i == 8) i--;
                if (i == 15) i++;
            }
            // Loading empty fields
            for (int i = 25; i <= 40; i += 2)
            {
                TypeOfGame.gameBoard.Add(i, new Field(true, false, false, ""));
                if (i == 31) i++;
            }
            // Loading red pawns
            for (int i = 41; i <= 63; i += 2)
            {
                TypeOfGame.gameBoard.Add(i, new Field(false, true, false, "red"));
                if (i == 47) i++;
                if (i == 56) i--;
            }
        }

        public List<Tuple<int, int, int>> DoesPawnHaveAnyBeating(Dictionary<int, Field> gameBoard, string currentPawnColor)
        {
            anyBeating.Clear();
            string enemyPawnColor;

            if (currentPawnColor.Equals("white"))
                enemyPawnColor = "red";
            else
                enemyPawnColor = "white";

            Field fieldData;
            foreach (int i in gameBoard.Keys)
            {
                if (gameBoard.TryGetValue(i, out fieldData) && fieldData.color.Equals(currentPawnColor))
                {
                    if (gameBoard.TryGetValue(i + 7, out fieldData) && fieldData.color.Equals(enemyPawnColor)) //Lewy dolny róg
                    {
                        if (gameBoard.TryGetValue(i + 14, out fieldData) && fieldData.isEmptyField)
                        {
                            anyBeating.Add(new Tuple<int, int, int>(i, i + 14, i + 7));
                        }
                    }
                    if (gameBoard.TryGetValue(i - 7, out fieldData) && fieldData.color.Equals(enemyPawnColor)) //prawy górny róg
                    {
                        if (gameBoard.TryGetValue(i - 14, out fieldData) && fieldData.isEmptyField)
                        {
                            anyBeating.Add(new Tuple<int, int, int>(i, i - 14, i - 7));
                        }
                    }
                    if (gameBoard.TryGetValue(i + 9, out fieldData) && fieldData.color.Equals(enemyPawnColor)) //prawy dolny róg
                    {
                        if (gameBoard.TryGetValue(i + 18, out fieldData) && fieldData.isEmptyField)
                        {
                            anyBeating.Add(new Tuple<int, int, int>(i, i + 18, i + 9));
                        }
                    }
                    if (gameBoard.TryGetValue(i - 9, out fieldData) && fieldData.color.Equals(enemyPawnColor)) //lewy górny róg
                    {
                        if (gameBoard.TryGetValue(i - 18, out fieldData) && fieldData.isEmptyField)
                        {
                            anyBeating.Add(new Tuple<int, int, int>(i, i - 18, i - 9));
                        }
                    }
                }
            }
            return anyBeating;
        }

        public void MovingAPawnThatHasNoBeating(IPlayer player)
        {
            MovingDameThatHasNoBeating(TypeOfGame.gameBoard, 29);
            if (player.MovingAPawnThatHasNoBeating_Condition())
            {
                player.CheckerUpdateAfterMovingAPawn();
            }
        }

        public void MovingAPawnThatHasABeating(IPlayer player, int indexTo)
        {
            if (player.MovingAPawnThatHasABeating_Condition())
            {
                TypeOfGame.forcedBeatingForPawnList.ForEach(delegate (Tuple<int, int, int> forcedBeatingForPawnTuple)
                {
                    if (forcedBeatingForPawnTuple.Item2 == indexTo)
                    {
                        player.CheckerUpdateAfterBeatingAPawn(forcedBeatingForPawnTuple.Item3);
                    }
                });
                player.CheckForMoreBeating();
                TypeOfGame.forcedBeatingForPawnList.Clear();
            }
        }

        public void UpdateFieldFrom(PictureBox fieldFrom, int indexFrom)
        {
            fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
            TypeOfGame.gameBoard[indexFrom] = Constant.EMPTY_FIELD;
        }

        public void UpdateFieldThrough(PictureBox fieldThrough, int indexThrough)
        {
            fieldThrough.Image = new Bitmap(Properties.Resources.empty_field);
            TypeOfGame.gameBoard[indexThrough] = Constant.EMPTY_FIELD;
        }

        public void UpdateFieldTo(PictureBox fieldTo, PictureBox fieldFrom, int indexTo, int indexFrom)
        {
            fieldTo.Image = fieldFrom.Image;
            TypeOfGame.gameBoard[indexTo] = TypeOfGame.gameBoard[indexFrom];
        }

        public DameData MovingDameThatHasNoBeating(Dictionary<int, Field> gameBoard, int indexFrom)
        {

            List<int> freeFieldsList = new List<int>();
            Dictionary<int, List<int>> anyBeating = new Dictionary<int, List<int>>();
            Field fieldData;
            int freeFields = indexFrom;
            while (gameBoard.TryGetValue(freeFields += 7, out fieldData)) {
                if (fieldData.isEmptyField)
                    freeFieldsList.Add(freeFields);
                else if ((fieldData.isPawn || fieldData.isDame) && fieldData.color.Equals("red"))
                {
                    int tmp = freeFields;
                    List<int> tmpList = new List<int>();
                    while (gameBoard.TryGetValue(freeFields += 7, out fieldData) && fieldData.isEmptyField)
                    {
                        tmpList.Add(freeFields);
                    }
                    anyBeating.Add(tmp, tmpList);
                    break;
                }
            }

            freeFields = indexFrom;

            while (gameBoard.TryGetValue(freeFields += 9, out fieldData))
            {
                if (fieldData.isEmptyField)
                    freeFieldsList.Add(freeFields);
                else if ((fieldData.isPawn || fieldData.isDame) && fieldData.color.Equals("red"))
                {
                    int tmp = freeFields;
                    List<int> tmpList = new List<int>();
                    while (gameBoard.TryGetValue(freeFields += 9, out fieldData) && fieldData.isEmptyField)
                    {
                        tmpList.Add(freeFields);
                    }
                    anyBeating.Add(tmp, tmpList);
                    break;
                }
                    
            }

            freeFields = indexFrom;

            while (gameBoard.TryGetValue(freeFields -= 7, out fieldData))
            {
                if (fieldData.isEmptyField)
                    freeFieldsList.Add(freeFields);
                else if ((fieldData.isPawn || fieldData.isDame) && fieldData.color.Equals("red"))
                {
                    int tmp = freeFields;
                    List<int> tmpList = new List<int>();
                    while (gameBoard.TryGetValue(freeFields -= 7, out fieldData) && fieldData.isEmptyField)
                    {
                        tmpList.Add(freeFields);
                    }
                    anyBeating.Add(tmp, tmpList);
                    break;
                }
            }

            freeFields = indexFrom;

            while (gameBoard.TryGetValue(freeFields -= 9, out fieldData))
            {
                if (fieldData.isEmptyField)
                    freeFieldsList.Add(freeFields);
                else if ((fieldData.isPawn || fieldData.isDame) && fieldData.color.Equals("red"))
                {
                    int tmp = freeFields;
                    List<int> tmpList = new List<int>();
                    while (gameBoard.TryGetValue(freeFields -= 9, out fieldData) && fieldData.isEmptyField)
                    {
                        tmpList.Add(freeFields);
                    }
                    anyBeating.Add(tmp, tmpList);
                    break;
                }
            }
            return new DameData(freeFieldsList, anyBeating);
        }
    }
}
