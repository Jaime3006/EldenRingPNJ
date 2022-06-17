using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace EldenRing.Model.Models
{
    public class Classes:Personaje
    {
        public int Id { get; set; }
        public string IdClasses { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "jsonb")]
        public Stats Stats { get; set; }
        public Classes(int id,string IdClasses,string Name,string Image,string Description, Stats stats){
         this.Id = id;
         this.IdClasses = IdClasses;
            this.Name = Name;
            this.Image = Image;
            this.Description = Description;
            this.Stats = stats;

        }
    }
}
