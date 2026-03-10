using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Juan_AmparoAP2_P2.Models
{
    public class AsignacionesPuntos
    {
        [Key]
        public int IdAsignacion { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Debe seleccionar un estudiante")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un estudiante valido")]
        public int EstudianteId { get; set; }

        public int TotalPuntos { get; set; }

        [ForeignKey("EstudianteId")]
        public Estudiantes? Estudiante { get; set; }

        [ForeignKey("IdAsignacion")]
        public ICollection<AsignacionesPuntosDetalle> AsignacionesDetalle { get; set; } = new List<AsignacionesPuntosDetalle>();
    }
}



