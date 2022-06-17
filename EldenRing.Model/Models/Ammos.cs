using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRing.Model.Models
{
    public class Ammos 
    { 
        public int Id { get; set; }
        
        public string IdAmmos { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Passive { get; set; }
        [Column(TypeName = "jsonb")]
        public AttackPower[] AtackPower { get; set; }


    }
}
