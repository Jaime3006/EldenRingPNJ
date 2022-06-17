using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRing.Model.Models
{
    public class Stats
    {
        public string Mind { get; set; }
        public string Faith { get; set; }
        public string Level { get; set; }
        public string Vigor { get; set; }
        public string Arcane { get; set; }
        public string Strength { get; set; }
        public string Dexterity { get; set; }
        public string Endurance { get; set; }
        public string Intelligence { get; set; }
     
   
       public Stats(string level,string vigor, string mind, string endurance,string strength,string dexterity, string intelligence, string faith,string arcane) {
            this.Mind = mind;
            this.Faith = faith;
            this.Level = level;
            this.Vigor = vigor;
            this.Arcane = arcane;
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Endurance = endurance;
          this.Intelligence=intelligence;
           

          
        
        
        }
    }
}
