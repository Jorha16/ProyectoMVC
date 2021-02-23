using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoMVC.Models.ViewModels
{
    public class ArchivoViewModel
    {
        [Required]
        [DisplayName("Mi archivo1")]
        public HttpPostedFileBase Archivo1 { get; set; }

        [Required]
        [DisplayName("Mi archivo2")]
        public HttpPostedFileBase Archivo2 { get; set; }

        [Required]
        [DisplayName("Mi archivo")]
        public string cadena { get; set; }
    }
}