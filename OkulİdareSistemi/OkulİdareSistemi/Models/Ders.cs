using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkulİdareSistemi.Models
{
    public class Ders
    {
        public int DersId { get; set; }
        public string DersAdi { get; set; }
        public int? Kredisi { get; set; }
        public int OkulYonetimId { get; set; }
        public virtual OkulYonetim OkulYonetim { get; set; }
    }
}