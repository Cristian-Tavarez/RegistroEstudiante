using System.ComponentModel.DataAnnotations;
namespace RegistroEstudiante.Models;

public class Estudiante
{
    [Key]
    public int EstudianteId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombres { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido es obligatorio")]
    public string Apellidos { get; set; } = string.Empty;

    [Required]
    public string Matricula { get; set; } = string.Empty;

    [Required]
    public string Carrera { get; set; } = string.Empty;

    public DateTime FechaIngreso { get; set; } = DateTime.Now;
}