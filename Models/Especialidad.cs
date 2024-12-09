using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Turnos.Models
{
public class Especialidad
    {
        [Key]
        public int IdEspecialidad {get; set;}

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}