

namespace Warcaby.CSharp.Dto
{
    public class Move
    {
        public int indexFrom { get; set; }
        public int indexThrough { get; set; }
        public int indexTo { get; set; }
        public Field fieldFrom { get; set; }
        public Field fieldThrough { get; set; }
        public Field fieldTo { get; set; }

        public Move(int indexFrom, int indexTo, Field fieldFrom, Field fieldTo)
        {
            this.indexFrom = indexFrom;
            this.indexTo = indexTo;
            this.fieldFrom = fieldFrom;
            this.fieldTo = fieldTo;
        }

        public Move(int indexFrom, int indexThrough, int indexTo, Field fieldFrom, Field fieldThrough, Field fieldTo)
        {
            this.indexFrom = indexFrom;
            this.indexThrough = indexThrough;
            this.indexTo = indexTo;
            this.fieldFrom = fieldFrom;
            this.fieldThrough = fieldThrough;
            this.fieldTo = fieldTo;
        }
    }
}
