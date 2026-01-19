using Microsoft.EntityFrameworkCore;
using RegistroEstudiante.Contexto;
using RegistroEstudiante.Models;

namespace RegistroEstudiante.Services;

public class EstudiantesService
{
    private readonly EstudiantesContext _context;

    public EstudiantesService(EstudiantesContext context)
    {
        _context = context;
    }

    public async Task<List<Estudiante>> ListarAsync()
    {
        return await _context.Estudiantes.ToListAsync();
    }

    public async Task<List<Estudiante>> BuscarAsync(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            return await _context.Estudiantes.ToListAsync();

        texto = texto.ToLower();

        return await _context.Estudiantes
            .Where(e =>
                e.Nombres.ToLower().Contains(texto) ||
                e.Apellidos.ToLower().Contains(texto) ||
                e.Matricula.ToLower().Contains(texto)
            )
            .ToListAsync();
    }
    public async Task<Estudiante?> BuscarAsync(int id)
    {
        return await _context.Estudiantes.FindAsync(id);
    }

    public async Task GuardarAsync(Estudiante estudiante)
    {
        if (estudiante.EstudianteId == 0)
            _context.Estudiantes.Add(estudiante);
        else
            _context.Estudiantes.Update(estudiante);

        await _context.SaveChangesAsync();
    }

    public async Task EliminarAsync(int id)
    {
        var estudiante = await BuscarAsync(id);
        if (estudiante != null)
        {
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();
        }
    }
}
