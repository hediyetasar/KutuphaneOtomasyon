﻿using Kutuphane.BL.AccountRepository;
using Kutuphane.ENT.IdentityModel;
using Kutuphane.ENT.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.MVC.Controllers
{
    public class HesapController : Controller
    {
        // GET: Hesap
        public ActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
 
            var userManager = MemberShipTools.NewUserManager();

            var roleManager = MemberShipTools.NewRoleManager();
            var checkUser = userManager.FindByName(model.TCNo);

            const string roleName = "Admin";
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new Rol() { Name="Admin", Aciklama="Site Yöneticisi"};
                roleManager.Create(role);
            }
            const string roleName2 = "User";
            role = roleManager.FindByName(roleName2);
            if (role == null)
            {
                role = new Rol() { Name = "User"};
                roleManager.Create(role);
            }
            const string roleName3 = "Passive";
            role = roleManager.FindByName(roleName3);
            if (role == null)
            {
                role = new Rol() { Name = "Passive"};
                roleManager.Create(role);
            }


            if (checkUser!=null)
            {
                ModelState.AddModelError(string.Empty, "Bu TC No sistemde kayıtlı");
                return View(model);
            }

            checkUser = userManager.FindByEmail(model.Email);
            if (checkUser!=null)
            {
                ModelState.AddModelError(string.Empty, "Bu mail adresi sistemde kayıtlı");
                return View(model);
            }

            var user = new Kullanici()
            {
                Ad=model.Ad,
                Soyad=model.Soyad,
                Email=model.Email,
                UserName=model.TCNo,        
            };

            var response = userManager.Create(user, model.Sifre);

            if (response.Succeeded)
            {
                if (userManager.Users.ToList().Count() == 1)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
                else
                {
                    userManager.AddToRole(user.Id, "Passive");
                }
                return RedirectToAction("Login", "Hesap");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kayıt işleminde bir hata oluiştu");
                return View(model);
            }
        }


        public ActionResult Login()
        {
            return View();
        }

    }
}