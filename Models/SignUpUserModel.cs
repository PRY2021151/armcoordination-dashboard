using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace armcoordination_dashboard.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Por favor, introduzca sus nombres")]
        [Display(Name = "Names")]
        public string Names { get; set; }

        [Required(ErrorMessage = "Por favor, introduzca su apellido")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Por favor, introduzca su correo electrónico")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Por favor, introduzca una dirección de correo electrónico válida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, introduzca una contraseña fuerte")]
        [Compare("ConfirmPassword", ErrorMessage = "La contraseña no coincide")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Por favor, confirme su contraseña")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
