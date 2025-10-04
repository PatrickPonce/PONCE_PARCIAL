using System.ComponentModel.DataAnnotations;

namespace PONCE_PARCIAL.Models
{
    public class Curso
    {
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string Codigo { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Range(1, 20)]
        public int Creditos { get; set; }

        [Range(1, 100)]
        public int CupoMaximo { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan HorarioInicio { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan HorarioFin { get; set; }

        public bool Activo { get; set; } = true;

        public ICollection<Matricula>? Matriculas { get; set; }
    }
}
