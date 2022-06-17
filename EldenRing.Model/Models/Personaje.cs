using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRing.Model.Models
{
    public class Personaje
    {
        public string Name { get; set; } 
        public int Hp = 400;
        public int Fp = 80;
        public int Stamina = 100;
        public AttackPower[] attackPower;
    }
}
