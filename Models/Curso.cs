using System.ComponentModel.DataAnnotations;

namespace PONCE_PARCIAL.Models
{
    public class Curso
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Codigo { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Range(1, 20, ErrorMessage = "Los créditos deben ser mayores que 0")]
        public int Creditos { get; set; }

        [Range(1, 200)]
        public int CupoMaximo { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan HorarioInicio { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan HorarioFin { get; set; }

        public bool Activo { get; set; }
    }
}
