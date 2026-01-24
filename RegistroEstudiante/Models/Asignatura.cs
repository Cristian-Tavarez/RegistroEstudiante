using System.ComponentModel.DataAnnotations;

namespace RegistroEstudiante.Models;

public class Asignatura
{
    [Key]
    public int AsignaturaId { get; set; }

    [Required(ErrorMessage = "El código es obligatorio")]
    public string Codigo { get; set; } = string.Empty;

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El aula es obligatoria")]
    public string Aula { get; set; } = string.Empty;

    [Required(ErrorMessage = "Los créditos son obligatorios")]
    [Range(1, 10, ErrorMessage = "Créditos inválidos")]
    public int Creditos { get; set; }
}
