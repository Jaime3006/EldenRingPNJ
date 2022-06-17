using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRing.Model.Models
{
    public class Spirits
    {
        public int Id { get; set; }
        public string IdSpirits { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description {get; set; }
        public int FpCost { get; set; }
        public int HpCost { get; set; }
        public string Effects { get; set; }
    }
}
