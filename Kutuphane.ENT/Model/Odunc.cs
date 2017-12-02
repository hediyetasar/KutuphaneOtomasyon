﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.ENT.Model
{
    public class Odunc : BaseModel
    {
        public DateTime AlisTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; }
        [Required]
        public int KitapID { get; set; }
        [Required]
        public int UyeID { get; set; }
        [Required]
        public int KullaniciID { get; set; }

        [ForeignKey("KitapID")]
        public virtual Kitap Kitap { get; set; }

        //[ForeignKey("UyeID")] //Uyeleri bağla
        //[ForeignKey("KullaniciID")] //kullanıcıları bağla
    }
}
