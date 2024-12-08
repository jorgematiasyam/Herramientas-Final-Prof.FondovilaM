using Microsoft.AspNetCore.Mvc;
using Turnos.Models;
using System.Linq;
namespace Turnos.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context)
        {
            _context = context; //inicializo context
        }

        public IActionResult Index()
        {

            return View(_context.Especialidad.ToList());
        }
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var especialidad = _context.Especialidad.Find(id);

            if(especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

[HttpPost] //Este edit graba
        public IActionResult Edit(int id, [Bind("IdEspecialidad, Descripcion")] Especialidad especialidad)
        {
            if(id!=especialidad.IdEspecialidad)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Update(especialidad);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }


            return View(especialidad);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var especialidad = _context.Especialidad.FirstOrDefault(e => e.IdEspecialidad == id);
            return View();
        }


    }
}