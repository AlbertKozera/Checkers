using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warcaby.CSharp.Game.Rules
{
    public class Contest
    {
        public PictureBox fieldFrom;
        public PictureBox fieldTo;
        public int indexFrom;
        public int indexTo;
        public static int indexThrough;
        public static int indexWhichHaveMultipleBeats;
        public string COLOR;

        public Contest(PictureBox fieldFrom, PictureBox fieldTo, int indexFrom, int indexTo, string COLOR)
        {
            this.fieldFrom = fieldFrom;
            this.fieldTo = fieldTo;
            this.indexFrom = indexFrom;
            this.indexTo = indexTo;
            this.COLOR = COLOR;
        }
    }
}
