using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.CSharp.Dto
{
    public class Player
    {
        public string id { get; set; }
        public string color { get; set; }

        public Player(string id, string color)
        {
            this.id = id;
            this.color = color;
        }
    }
}
