using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PONCE_PARCIAL.Models;

namespace PONCE_PARCIAL.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (!context.Cursos.Any())
            {
                context.Cursos.AddRange(
                    new Curso { Codigo = "CS101", Nombre = "Programación I", Creditos = 4, CupoMaximo = 30, HorarioInicio = new TimeSpan(8, 0, 0), HorarioFin = new TimeSpan(10, 0, 0), Activo = true },
                    new Curso { Codigo = "CS102", Nombre = "Base de Datos", Creditos = 3, CupoMaximo = 25, HorarioInicio = new TimeSpan(10, 0, 0), HorarioFin = new TimeSpan(12, 0, 0), Activo = true },
                    new Curso { Codigo = "CS103", Nombre = "Ingeniería de Software", Creditos = 4, CupoMaximo = 20, HorarioInicio = new TimeSpan(14, 0, 0), HorarioFin = new TimeSpan(16, 0, 0), Activo = true }
                );
                await context.SaveChangesAsync();
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync("Coordinador"))
                await roleManager.CreateAsync(new IdentityRole("Coordinador"));

            string email = "coordinador@univ.edu";
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new IdentityUser { UserName = email, Email = email, EmailConfirmed = true };
                await userManager.CreateAsync(user, "Password123!");
                await userManager.AddToRoleAsync(user, "Coordinador");
            }
        }
    }
}
