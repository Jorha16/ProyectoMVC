﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoMVC.Models;
using ProyectoMVC.Models.TableViewModels;
using ProyectoMVC.Models.ViewModels;

namespace ProyectoMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModels> lst = null;
            using (cursomvcEntities db = new cursomvcEntities())
            {
                lst = (from d in db.user
                       where d.idState == 1
                       orderby d.email
                       select new UserTableViewModels
                       {
                           Id = d.id,
                           Email = d.email,
                           Edad = d.edad
                       }).ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new cursomvcEntities())
            {
                user oUser = new user();
                oUser.idState = 1;
                oUser.email = model.Email;
                oUser.edad = model.Edad;
                oUser.password = model.Password;

                db.user.Add(oUser);

                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new cursomvcEntities())
            {
                var oUser = db.user.Find(Id);
                model.Edad = (int)oUser.edad;
                model.Email = oUser.email;
                model.Id = oUser.id;

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new cursomvcEntities())
            {
                var oUser = db.user.Find(model.Id);
                oUser.edad = model.Edad;
                oUser.email = model.Email;

                if(model.Password!=null && model.Password.Trim()!= "")
                {
                    oUser.password = model.Password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

                return Redirect(Url.Content("~/User/"));
        }


        [HttpPost]
        public ActionResult Delete(int Id)
        {

            using (var db = new cursomvcEntities())
            {
                var oUser = db.user.Find(Id);
                oUser.idState = 3; //Eliminaremos

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }

    }
}