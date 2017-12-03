﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.ENT.Model
{
    [Table("Uye")]
    public class Uye :BaseModel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public virtual List<Odunc> Odunc { get; set; } = new List<Odunc>();
    }
}
