using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OkulİdareSistemi.Models
{
    public class OkulYonetim
    {
        [Key]
        public int OkulYonetimId { get; set; }
        public string AdSoyad { get; set; }
        public string Gorevi { get; set; }
        public string YonetimTip { get; set; }
    }
}