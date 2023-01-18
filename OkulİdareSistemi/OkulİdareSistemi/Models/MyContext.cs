using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OkulİdareSistemi.Models
{
    public class MyContext:DbContext
    {
        public DbSet<Ogrenci> Ogrencis { get; set; }
        public DbSet<OkulYonetim> OkulYonetims { get; set; }
        public DbSet<Ders> Derss { get; set; }
        public DbSet<OgrenciDers> OgrenciDerss { get; set; }
    }
}