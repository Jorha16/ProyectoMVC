﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (cursomvcEntities db = new cursomvcEntities())
                    {

                    var lst = from d in db.user
                              where d.email == user && d.password == password && d.idState == 1
                              select d;

                    if(lst.Count()>0)
                    {
                        var num = lst.Count();

                        user oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");

                    }
                    else
                    {
                        return Content("Usuario Invalido(*)");
                    }
                    
                }

                
            }
            catch(Exception ex)
            {
                return Content("Ocurrio un error :( "+ex.Message);
            }
        }
    }
}