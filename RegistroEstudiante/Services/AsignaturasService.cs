using Microsoft.EntityFrameworkCore;
using RegistroEstudiante.Contexto;
using RegistroEstudiante.Models;

namespace RegistroEstudiante.Services;

public class AsignaturasService
{
    private readonly EstudiantesContext _context;

    public AsignaturasService(EstudiantesContext context)
    {
        _context = context;
    }


    public async Task<List<Asignatura>> ListarAsync()
    {
        return await _context.Asignaturas.ToListAsync();
    }

 
    public async Task<Asignatura?> BuscarAsync(int id)
    {
        return await _context.Asignaturas.FindAsync(id);
    }

    
    public async Task<bool> ExisteNombreAsync(string nombre, int idActual = 0)
    {
        return await _context.Asignaturas.AnyAsync(a =>
            a.Nombre.ToLower() == nombre.ToLower()
            && a.AsignaturaId != idActual);
    }

    
    public async Task GuardarAsync(Asignatura asignatura)
    {
        if (await ExisteNombreAsync(asignatura.Nombre, asignatura.AsignaturaId))
            throw new Exception("Ya existe una asignatura con ese nombre.");

        if (asignatura.AsignaturaId == 0)
            _context.Asignaturas.Add(asignatura);
        else
            _context.Asignaturas.Update(asignatura);

        await _context.SaveChangesAsync();
    }

    public async Task EliminarAsync(int id)
    {
        var asignatura = await BuscarAsync(id);
        if (asignatura != null)
        {
            _context.Asignaturas.Remove(asignatura);
            await _context.SaveChangesAsync();
        }
    }
}
