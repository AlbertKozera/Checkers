using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Warcaby.Forms
{
    public static class Extend
    {
        public static bool IsNullOrEmpty(this IList List)
        {
            return (List == null || List.Count < 1);
        }
        public static bool IsNullOrEmpty(this IDictionary Dictionary)
        {
            return (Dictionary == null || Dictionary.Count < 1);
        }

        public static PictureBox GetFieldByIndex(int index)
        {
            return (PictureBox)Application.OpenForms["MainStage"].Controls.Find("field_" + index, true)[0];
        }

        public static int GetIndexFromField(PictureBox field)
        {
            return Int16.Parse(field.Tag.ToString());
        }

        public static string GetEnemyPlayerColor(string color)
        {
            return color.Equals(Constant.WHITE) ? Constant.RED : Constant.WHITE;
        }

        public static Image GetDameImage(string color)
        {
            return color.Equals(Constant.WHITE) ? new Bitmap(Properties.Resources.dame_white) : new Bitmap(Properties.Resources.dame_red);
        }
    }
}
