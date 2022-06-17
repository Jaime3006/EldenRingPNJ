using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRing.Model.Models
{
    public class Incantations
    {
        public int Id { get; set; }
        public string IdIncantations { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Cost { get; set; }
        public int Slots { get; set; }
        public string Effects { get; set; }
        [Column(TypeName = "jsonb")]
        public RequiredAttributes Requires { get; set; }

    }
}
