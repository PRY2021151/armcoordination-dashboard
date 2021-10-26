using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace armcoordination_dashboard.Models
{
    public class ChildModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Por favor, introduzca sus nombres")]
        [Display(Name = "Names")]
        public string names { get; set; }

        [Required(ErrorMessage = "Por favor, introduzca su apellido")]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }

        [Required(ErrorMessage = "Por favor, introduzca la fecha de nacimiento")]
        [Display(Name = "Date of birth")]
        [DataType(DataType.DateTime)]
        public DateTime date_of_birth { get; set; }

        [Required(ErrorMessage = "Por favor, introduzca el género")]
        [Display(Name = "Gender")]
        public string gender { get; set; }

    }
}
