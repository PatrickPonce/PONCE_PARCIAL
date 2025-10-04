using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PONCE_PARCIAL.Data;

namespace PONCE_PARCIAL.Controllers
{
    public class CursosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cursos = await _context.Cursos
                .Where(c => c.Activo)
                .ToListAsync();
            return View(cursos);
        }
    }
}
