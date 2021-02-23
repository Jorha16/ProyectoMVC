using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoMVC.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100,ErrorMessage ="El {0} debe tener al menos {1} caracters",MinimumLength =1)]
        [Display(Name ="Correo Electronico")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Contrasena")]
        public string Password { get; set; }
        [Display(Name ="Confirmar Contrasena")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Las contrasenas no son iguales")]
        public string ConfirmPassword { get; set; }
        [Required]
        public int Edad { get; set; }
    }


    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracters", MinimumLength = 1)]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contrasena")]
        public string Password { get; set; }

        [Display(Name = "Confirmar Contrasena")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contrasenas no son iguales")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int Edad { get; set; }
    }

}