using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVC.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal
        public ActionResult Index()
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            using (Models.cursomvcEntities db = new Models.cursomvcEntities())
            {
                lst = (from d in db.animal_class
                       select new SelectListItem
                       {
                           Value = d.id.ToString(),
                           Text = d.name
                       }).ToList();
            }

            return View(lst);
        }

        [HttpGet]
        public JsonResult Animal(int IdAnimalClass)
        {
            List<ElementJsonIntKey> lst = new List<ElementJsonIntKey>();

            using(Models.cursomvcEntities db = new Models.cursomvcEntities())
            {
                lst = (from d in db.animals
                       where d.idAnimal_class == IdAnimalClass
                       select new ElementJsonIntKey
                       {
                           Value = d.id,
                           Text = d.name
                       }).ToList();
            }

            return Json(lst, JsonRequestBehavior.AllowGet);

        }

        public class ElementJsonIntKey
            {
                public int Value { get; set; }
                public string Text { get; set; }
            }
    }
}