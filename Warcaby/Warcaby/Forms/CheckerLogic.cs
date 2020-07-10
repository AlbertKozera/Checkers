﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby.Forms
{
    class CheckerLogic
    {
        public List<Tuple<int, int, int>> anyBeating = new List<Tuple<int, int, int>>();

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
    }
}
