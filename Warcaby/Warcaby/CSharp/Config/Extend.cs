using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Warcaby.CSharp.Config;
using Warcaby.CSharp.Dto;
using Warcaby.CSharp.Game.Context;
using Warcaby.Service.Context;


namespace Warcaby.Forms
{
    public static class Extend
    {
        public static System.Timers.Timer timer;

        public static bool IsNullOrEmpty(this IList List)
        {
            return (List == null || List.Count < 1);
        }
        public static bool IsNullOrEmpty(this IDictionary Dictionary)
        {
            return (Dictionary == null || Dictionary.Count < 1);
        }

        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
        public static PictureBox GetFieldByIndex(int index)
        {
            return (PictureBox)Application.OpenForms["MainStage"].Controls.Find("field_" + index, true)[0];
        }

        public static Control GetControlByName(string name)
        {
            return Application.OpenForms["MainStage"].Controls.Find(name, true)[0];
        }

        public static int GetIndexFromField(PictureBox field)
        {
            return Int16.Parse(field.Tag.ToString());
        }

        public static string GetEnemyPlayerColor(string color)
        {
            return color.Equals(Constant.WHITE)
                ? Constant.RED
                : Constant.WHITE;
        }

        public static Field GetDameField(string color)
        {
            return color.Equals(Constant.WHITE)
                ? Constant.DAME_WHITE
                : Constant.DAME_RED;
        }

        public static Image GetDameImage(string color)
        {
            return color.Equals(Constant.WHITE)
                ? new Bitmap(Properties.Resources.dame_white)
                : new Bitmap(Properties.Resources.dame_red);
        }


        public static void ChangeImageOfTurn(string color)
        {
            PictureBox pictureBox = (PictureBox)GetControlByName("turn");
            if (color.Equals(Constant.WHITE))
                pictureBox.BackgroundImage = new Bitmap(Properties.Resources.pawn_red);
            else
                pictureBox.BackgroundImage = new Bitmap(Properties.Resources.pawn_white);
        }

        public static int GetNumberOfPawns(Dictionary<int, Field> gameBoard, string color)
        {
            int i = 0;
            foreach (Field field in gameBoard.Values)
            {
                if (field.isPawn && field.color.Equals(color))
                    i++;
            }
            return i;
        }

        public static int GetNumberOfDames(Dictionary<int, Field> gameBoard, string color)
        {
            int i = 0;
            foreach (Field field in gameBoard.Values)
            {
                if (field.isDame && field.color.Equals(color))
                    i++;
            }
            return i;
        }

        public static int GetNumberOfPieces(Dictionary<int, Field> gameBoard, string color)
        {
            return GetNumberOfPawns(gameBoard, color) + GetNumberOfDames(gameBoard, color);
        }

        public static void UpdateGuiCounters()
        {
            Label label;
            label = (Label)GetControlByName("numberOfPawnsForWhite");
            label.Text = GetNumberOfPawns(GameService.gameBoard, Constant.WHITE).ToString();
            label = (Label)GetControlByName("numberOfPawnsForRed");
            label.Text = GetNumberOfPawns(GameService.gameBoard, Constant.RED).ToString();
            label = (Label)GetControlByName("numberOfDamesForWhite");
            label.Text = GetNumberOfDames(GameService.gameBoard, Constant.WHITE).ToString();
            label = (Label)GetControlByName("numberOfDamesForRed");
            label.Text = GetNumberOfDames(GameService.gameBoard, Constant.RED).ToString();
        }

        public static Boolean CheckIfAnyoneAlreadyWon()
        {
            Label label = (Label)GetControlByName("winner");
            if (Rule.WhoIsTheWinner().Equals(Constant.WHITE))
            {
                label.Text = "WYGRYWA BIAŁY";
                label.Left = 79;
                label.BringToFront();
                return true;
            }
            else if (Rule.WhoIsTheWinner().Equals(Constant.RED))
            {
                label.Text = "WYGRYWA CZERWONY";
                label.Left = 9;
                label.BringToFront();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void FinishTheTurn(string color)
        {
            if (color.Equals(Constant.WHITE))
            {
                GameService.whiteTurn = false;
            }
            else
            {
                GameService.whiteTurn = true;
            }
            Extend.ChangeImageOfTurn(color);
        }

        public static void RepeatTheTurn(string color)
        {
            if (color.Equals(Constant.WHITE))
                GameService.whiteTurn = true;
            else
                GameService.whiteTurn = false;
        }

        public static Dictionary<int, Field> CloneGameBoard(Dictionary<int, Field> gameBoard)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(gameBoard);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, Field>>(json);
        }

        public static void printTimeOfBatch(long time)
        {
            Label label = (Label)GetControlByName("computersDuration");
            label.Text = "Czas trwania partii: " + time + "ms";
            label.BringToFront();
        }

        public static string GetIndexByFieldName(string fieldName)
        {
            return Regex.Match(fieldName, @"\d+").Value; 
        }
    }
}
