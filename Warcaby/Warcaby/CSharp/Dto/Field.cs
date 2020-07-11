

namespace Warcaby.Forms
{
    public class Field
    {
        public bool isEmptyField { get; set; }
        public bool isPawn { get; set; }
        public bool isDame { get; set; }
        public string color { get; set; }


        public Field(bool isEmptyField, bool isPawn, bool isDame, string color)
        {
            this.isEmptyField = isEmptyField;
            this.isPawn = isPawn;
            this.isDame = isDame;
            this.color = color;
        }
    }
}
