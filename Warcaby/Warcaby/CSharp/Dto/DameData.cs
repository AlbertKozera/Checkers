using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby.CSharp.Dto
{
    public class DameData
    {
        public List<int> freeFieldsList { get; set; }
        public Dictionary<int, List<int>> anyBeating { get; set; }


        public DameData(List<int> freeFieldsList, Dictionary<int, List<int>> anyBeating)
        {
            this.freeFieldsList = freeFieldsList;
            this.anyBeating = anyBeating;
        }

        
    }
}
