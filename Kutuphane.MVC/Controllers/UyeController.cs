﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.MVC.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Liste()
        {
            return View();
        }

        public ActionResult Detay()
        {
            return View();
        }

        public ActionResult Ekle()
        {
            return View();
        }

        public ActionResult Sil()
        {
            return RedirectToAction("Listele");
        }

        public ActionResult Guncelle()
        {
            return View();
        }
    }
}