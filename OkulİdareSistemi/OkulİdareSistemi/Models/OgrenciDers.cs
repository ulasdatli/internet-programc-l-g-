using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OkulİdareSistemi.Models
{
    public class OgrenciDers
    {
        [Key]
        public int OgrenciDersId { get; set; }
        public int DersId { get; set; }
        public int OgrenciId { get; set; }
        public virtual Ders Ders { get; set; }
        public virtual Ogrenci Ogrenci { get; set; }
    }
}