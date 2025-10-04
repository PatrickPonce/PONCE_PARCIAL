using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PONCE_PARCIAL.Data;
using PONCE_PARCIAL.Models;

namespace PONCE_PARCIAL.Controllers
{
    public class CursosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? nombre, int? creditosMin, int? creditosMax, TimeSpan? horaInicio, TimeSpan? horaFin)
        {
            var cursos = _context.Cursos.Where(c => c.Activo);

            if (!string.IsNullOrEmpty(nombre))
                cursos = cursos.Where(c => c.Nombre.Contains(nombre));

            if (creditosMin.HasValue)
                cursos = cursos.Where(c => c.Creditos >= creditosMin);

            if (creditosMax.HasValue)
                cursos = cursos.Where(c => c.Creditos <= creditosMax);

            if (horaInicio.HasValue)
                cursos = cursos.Where(c => c.HorarioInicio >= horaInicio);

            if (horaFin.HasValue)
                cursos = cursos.Where(c => c.HorarioFin <= horaFin);

            var lista = await cursos.OrderBy(c => c.Nombre).ToListAsync();
            return View(lista);
        }

        public async Task<IActionResult> Detalle(int id)
        {
            var curso = await _context.Cursos.FirstOrDefaultAsync(c => c.Id == id && c.Activo);
            if (curso == null) return NotFound();
            return View(curso);
        }
    }
}
