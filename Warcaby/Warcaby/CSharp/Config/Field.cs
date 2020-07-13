using System;
using System.Collections.Generic;

namespace Warcaby.Forms
{
    public class Field : IEquatable<Field>
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

        public override bool Equals(object obj)
        {
            return Equals(obj as Field);
        }

        public bool Equals(Field other)
        {
            return other != null &&
                   isEmptyField == other.isEmptyField &&
                   isPawn == other.isPawn &&
                   isDame == other.isDame &&
                   color == other.color;
        }

        public override int GetHashCode()
        {
            var hashCode = -2113126407;
            hashCode = hashCode * -1521134295 + isEmptyField.GetHashCode();
            hashCode = hashCode * -1521134295 + isPawn.GetHashCode();
            hashCode = hashCode * -1521134295 + isDame.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(color);
            return hashCode;
        }
    }
}
