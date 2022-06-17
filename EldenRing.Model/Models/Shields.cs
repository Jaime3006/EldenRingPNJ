using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRing.Model.Models
{
    public class Shields
    {
        public int Id { get; set; }
        public string IdShields { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Weight { get; set; }
        [Column(TypeName = "jsonb")]
        public Attack[] Attack { get; set; }
        [Column(TypeName = "jsonb")]
        public Defence[] Defence { get; set; }
        [Column(TypeName = "jsonb")]
        public RequiredAttributes[] RequiredAttributes { get; set; }
        [Column(TypeName = "jsonb")]
        public ScalesWith[] ScalesWith { get; set; }

        public Shields(int id, string idShields, string name, string image, string description, string category, string weight, Attack[] attack, Defence[] defence, RequiredAttributes[] requiredAttributes, ScalesWith[] scalesWith)
        {
            Id = id;
            IdShields = idShields;
            Name = name;
            Image = image;
            Description = description;
            Category = category;
            Weight = weight;
            Attack = attack;
            Defence = defence;
            RequiredAttributes = requiredAttributes;
            ScalesWith = scalesWith;
        }
    }
}
