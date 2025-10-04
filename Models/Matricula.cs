using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PONCE_PARCIAL.Models
{
    public enum EstadoMatricula
    {
        Pendiente,
        Confirmada,
        Cancelada
    }

    public class Matricula
    {
        public int Id { get; set; }

        [Required]
        public int CursoId { get; set; }

        [Required]
        public string UsuarioId { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public EstadoMatricula Estado { get; set; } = EstadoMatricula.Pendiente;

        [ForeignKey(nameof(CursoId))]
        public Curso? Curso { get; set; }
    }
}
