using System.ComponentModel.DataAnnotations;

namespace Juan_AmparoAP2_P2.Models
{
    public class AsignacionesPuntosDetalle
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdAsignacion { get; set; }
        [Required(ErrorMessage = "Seleccione un tipo de punto")]
        public int TipoPuntoId { get; set; }
        public int CantidadPuntos { get; set; }


    }
}

