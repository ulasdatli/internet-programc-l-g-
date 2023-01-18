using OkulİdareSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OkulİdareSistemi.Controllers
{
    public class HomeController : Controller
    {

        //ANA SAYFA
        public ActionResult Index()
        {
            return View();
        }

        //ÖĞRENCİ LİSTELEME
        public ActionResult OgrenciList()
        {
            var context = new MyContext();
            var ogrenci = context.Ogrencis.ToList();
            return View(ogrenci);
        }


        //ÖĞRENCİ EKLEME
        [HttpGet]
        [ActionName("OgrenciAdd")]
        public ActionResult OgrenciAdd()
        {
            return View();
        }

        [HttpPost]
        [ActionName("OgrenciAdd")]
        public ActionResult OgrenciAdd(Ogrenci ogrenci)
        {
            var context = new MyContext();
            if (!ModelState.IsValid)
            {
                return View("OgrenciAdd");
            }
            UpdateModel(ogrenci);
            context.Ogrencis.Add(ogrenci);
            context.SaveChanges();
            return RedirectToAction("OgrenciList", "Home");
        }


        //ÖĞRENCİ GÜNCELLEME
        [HttpGet]
        [ActionName("OgrenciEdit")]
        public ActionResult OgrenciEdit(int? id)
        {
            var context = new MyContext();
            var model = context.Ogrencis.Find(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("OgrenciEdit")]
        public ActionResult OgrenciEdit(int? id, Ogrenci ogrenci)
        {
            var context = new MyContext();

            var model = context.Ogrencis.Find(id);
            model.AdSoyad = ogrenci.AdSoyad;
            UpdateModel(model);
            context.SaveChanges();
            return RedirectToAction("OgrenciList", "Home");

        }


        //ÖĞRENCİ SİLME
        public ActionResult OgrenciRemove(int? id)
        {
            var context = new MyContext();
            var model = context.Ogrencis.SingleOrDefault(x => x.OgrenciId == id);
            context.Ogrencis.Remove(model);
            context.SaveChanges();
            return RedirectToAction("OgrenciList", "Home");
        }


        //OKUL YÖNETİM LİSTELEME
        public ActionResult OkulYonetimList()
        {
            var context = new MyContext();
            var okulYonetim = context.OkulYonetims.ToList();
            return View(okulYonetim);
        }


        //OKUL YÖNETİM EKLEME
        [HttpGet]
        [ActionName("OkulYonetimAdd")]
        public ActionResult OkulYonetimAdd()
        {
            return View();
        }

        [HttpPost]
        [ActionName("OkulYonetimAdd")]
        public ActionResult OkulYonetimAdd(OkulYonetim okulYonetim)
        {
            var context = new MyContext();
            if (!ModelState.IsValid)
            {
                return View("OkulyonetimAdd");
            }
            UpdateModel(okulYonetim);
            context.OkulYonetims.Add(okulYonetim);
            context.SaveChanges();
            return RedirectToAction("OkulYonetimList", "Home");
        }


        //OKUL YÖNETİM GÜNCELLEME
        [HttpGet]
        [ActionName("OkulYonetimEdit")]
        public ActionResult OkulYonetimEdit(int? id)
        {
            var context = new MyContext();
            var model = context.OkulYonetims.Find(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("OkulYonetimEdit")]
        public ActionResult OkulYonetimEdit(int? id, OkulYonetim okulYonetim)
        {
            var context = new MyContext();

            var model = context.OkulYonetims.Find(id);
            model.AdSoyad = okulYonetim.AdSoyad;
            UpdateModel(model);
            context.SaveChanges();
            return RedirectToAction("OkulYonetimList", "Home");

        }


        //ÖĞRENCİ SİLME
        public ActionResult OkulYonetimRemove(int? id)
        {
            var context = new MyContext();
            var model = context.OkulYonetims.SingleOrDefault(x => x.OkulYonetimId == id);
            context.OkulYonetims.Remove(model);
            context.SaveChanges();
            return RedirectToAction("OkulYonetimList", "Home");
        }


        //DERS LİSTELEME
        public ActionResult DersList()
        {
            var context = new MyContext();
            var ders = context.Derss.ToList();
            return View(ders);
        }


        //DERS EKLEME
        [HttpGet]
        [ActionName("DersAdd")]
        public ActionResult DersAdd(Ders ders)
        {
            using (var context = new MyContext())
            {
                List<OkulYonetim> ogretmenler = context.OkulYonetims.ToList();
                ViewBag.DDLOgretmenler = new SelectList(ogretmenler, "OkulYonetimId", "AdSoyad");
                return View();
            }

        }


        [HttpPost]
        [ActionName("DersAdd")]
        public ActionResult DersAdd(FormCollection formData, HttpPostedFileBase file)
        {
            using (var context = new MyContext())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        string ogretmenId = formData["DDLOgretmenler"].ToString();
                        var ders = new Ders();
                        ders.OkulYonetimId = int.Parse(ogretmenId);
                        UpdateModel(ders);
                        context.Derss.Add(ders);
                        context.SaveChanges();
                        return RedirectToAction("DersList", "Home");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return View();
            }

        }


        //DERS GÜNCELLEME
        [HttpGet]
        [ActionName("DersEdit")]
        public ActionResult DersEdit(int? id)
        {
            var context = new MyContext();
            var model = context.Derss.Find(id);
            List<SelectListItem> ogretmenler = context.OkulYonetims.Select

                (
                x => new SelectListItem
                {
                    Text = x.AdSoyad,
                    Value = x.OkulYonetimId.ToString(),
                    Selected = x.OkulYonetimId == x.OkulYonetimId
                }

                ).ToList();
            ViewBag.DDLOgretmenler = ogretmenler;
            return View(model);
        }

        [HttpPost]
        [ActionName("DersEdit")]
        public ActionResult DersEdit(int? id, Ders ders)
        {
            var context = new MyContext();
            var model = context.Derss.Find(id);
            model.OkulYonetimId = ders.OkulYonetimId;
            UpdateModel(model);
            context.SaveChanges();
            return RedirectToAction("DersList", "Home");
        }

        //DERS SİLME
        public ActionResult DersRemove(int? id)
        {
            var context = new MyContext();
            var model = context.Derss.SingleOrDefault(x => x.DersId == id);
            context.Derss.Remove(model);
            context.SaveChanges();
            return RedirectToAction("DersList", "Home");
        }


        //DERSİ ALAN ÖĞRENCİ LİSTELEME
        public ActionResult OgrenciDersList()
        {
            var context = new MyContext();
            var ogrenciDers = context.OgrenciDerss.ToList();
            return View(ogrenciDers);
        }


        //DERSE ÖĞRENCİ EKLEME
        [HttpGet]
        [ActionName("OgrenciDersAdd")]
        public ActionResult OgrenciDersAdd()
        {
            using (var context = new MyContext())
            {
                List<Ogrenci> ogrenciler = context.Ogrencis.ToList();
                ViewBag.DDLOgrenciler = new SelectList(ogrenciler, "OgrenciId", "AdSoyad");

                List<Ders> dersler = context.Derss.ToList();
                ViewBag.DDLDersler = new SelectList(dersler, "DersId", "DersAdi");
                return View();
            }

        }


        [HttpPost]
        [ActionName("OgrenciDersAdd")]
        public ActionResult OgrenciDersAdd(FormCollection formData)
        {
            using (var context = new MyContext())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        string ogrenciId = formData["DDLOgrenciler"].ToString();
                        string dersId = formData["DDLDersler"].ToString();
                        var ogrenciDers = new OgrenciDers();
                        ogrenciDers.OgrenciId = int.Parse(ogrenciId);
                        ogrenciDers.DersId = int.Parse(dersId);
                        UpdateModel(ogrenciDers);
                        context.OgrenciDerss.Add(ogrenciDers);
                        context.SaveChanges();
                        return RedirectToAction("OgrenciDersList", "Home");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return View();
            }

        }


        //DERS ATAMASI GÜNCELLEME
        [HttpGet]
        [ActionName("OgrenciDersEdit")]
        public ActionResult OgrenciDersEdit(int? id)
        {
            var context = new MyContext();
            var model = context.Derss.Find(id);
            List<SelectListItem> dersler = context.Derss.Select

                (
                x => new SelectListItem
                {
                    Text = x.DersAdi,
                    Value = x.DersId.ToString(),
                    Selected = x.DersId == x.DersId
                }

                ).ToList();
            ViewBag.DDLDersler = dersler;

            List<SelectListItem> ogrenciler = context.Ogrencis.Select

               (
               x => new SelectListItem
               {
                   Text = x.AdSoyad,
                   Value = x.OgrenciId.ToString(),
                   Selected = x.OgrenciId == x.OgrenciId
               }

               ).ToList();
            ViewBag.DDLOgrenciler = ogrenciler;
            return View(model);
        }

        [HttpPost]
        [ActionName("OgrenciDersEdit")]
        public ActionResult OgrenciDersEdit(int? id, OgrenciDers ogrenciDers)
        {
            var context = new MyContext();
            var model = context.OgrenciDerss.Find(id);
            model.DersId = ogrenciDers.DersId;
            model.OgrenciId = ogrenciDers.OgrenciId;
            UpdateModel(model);
            context.SaveChanges();
            return RedirectToAction("OgrenciDersList", "Home");
        }


        //ATAMA SİLME
        public ActionResult OgrenciDersRemove(int? id)
        {
            var context = new MyContext();
            var model = context.OgrenciDerss.SingleOrDefault(x => x.OgrenciDersId == id);
            context.OgrenciDerss.Remove(model);
            context.SaveChanges();
            return RedirectToAction("OgrenciDersList", "Home");
        }
    }
}