using Microsoft.EntityFrameworkCore;
using RegistroEstudiante.Models;

namespace RegistroEstudiante.Contexto;

public class EstudiantesContext : DbContext
{
    public EstudiantesContext(DbContextOptions<EstudiantesContext> options)
        : base(options)
    {
    }

    public DbSet<Estudiante> Estudiantes { get; set; }
}
