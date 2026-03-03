using System.ComponentModel.DataAnnotations;

namespace Juan_AmparoAP2_P2.Models;

public class ViajesEspaciales
{
    [Key]
    public int ViajeId { get; set; }

    [Required(ErrorMessage = "El nombre del viaje es obligatorio.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Range(0.1, double.MaxValue, ErrorMessage = "El costo debe ser mayor a 0.")]
    public decimal Costo { get; set; }
}