using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PONCE_PARCIAL.Models;

namespace PONCE_PARCIAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Curso>().ToTable(tb =>
            {
                tb.HasCheckConstraint("CK_Creditos_Pos", "Creditos > 0");
                tb.HasCheckConstraint("CK_Horario_Valido", "HorarioInicio < HorarioFin");
            });

            builder.Entity<Curso>()
                .HasIndex(c => c.Codigo)
                .IsUnique();
        }


    }
}
