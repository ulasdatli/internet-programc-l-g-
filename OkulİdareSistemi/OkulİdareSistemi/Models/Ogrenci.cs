using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OkulİdareSistemi.Models
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciId { get; set; }
        public string AdSoyad { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string OgrenciNo { get; set; }
        public string DogumTarihi { get; set; }
        public string Bolum { get; set; }
    }
}