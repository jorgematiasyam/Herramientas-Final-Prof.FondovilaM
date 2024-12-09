using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Turnos.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }

        [Required (ErrorMessage="Debe ingresar un nombre")]
        public string Nombre { get; set; }

        [Required (ErrorMessage="Debe ingresar un Apellido")]
        public string Apellido { get; set; }

        [Required (ErrorMessage="Debe ingresar una dirección")]
        [Display(Name = "Dirección")]

        public string Direccion { get; set; }

        [Required (ErrorMessage="Debe ingresar un teléfono")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required (ErrorMessage="Debe ingresar un Email")]
        [EmailAddress(ErrorMessage="No es una dirección de email válida")]
        public string Email { get; set; }


        [Display(Name = "Horario Desde")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}, ApplyFormatInEditMode = true ")]
        public DateTime HorarioAtencionDesde { get; set; }

        [Display(Name = "Horario Hasta")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}, ApplyFormatInEditMode = true")]


        public DateTime HorarioAtencionHasta { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }

    }


}