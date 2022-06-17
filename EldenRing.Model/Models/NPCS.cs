﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRing.Model.Models
{
    public class NPCS
    {
        public int Id { get; set; }
        public string IdNpcs { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Quote { get; set; }
        public string Location { get; set; }
        public string Role { get; set; }
    }
}
