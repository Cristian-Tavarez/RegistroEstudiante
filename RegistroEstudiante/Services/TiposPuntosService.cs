using Microsoft.EntityFrameworkCore;
using RegistroEstudiante.Contexto;
using RegistroEstudiante.Models;

namespace RegistroEstudiante.Services;

public class TiposPuntosService
{
    private readonly EstudiantesContext _context;

    public TiposPuntosService(EstudiantesContext context)
    {
        _context = context;
    }

    public async Task<List<TipoPunto>> ListarAsync()
        => await _context.TiposPuntos.ToListAsync();

    public async Task<TipoPunto?> BuscarAsync(int id)
        => await _context.TiposPuntos.FindAsync(id);

    public async Task<bool> ExisteNombreAsync(string nombre, int? id = null)
    {
        return await _context.TiposPuntos
            .AnyAsync(t => t.Nombre.ToLower() == nombre.ToLower()
                        && (!id.HasValue || t.TipoId != id));
    }

    public async Task GuardarAsync(TipoPunto tipo)
    {
        if (await ExisteNombreAsync(tipo.Nombre))
            throw new Exception("Ya existe un tipo de punto con ese nombre.");

        _context.TiposPuntos.Add(tipo);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarAsync(TipoPunto tipo)
    {
        _context.TiposPuntos.Update(tipo);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarAsync(int id)
    {
        var tipo = await BuscarAsync(id);
        if (tipo != null)
        {
            _context.TiposPuntos.Remove(tipo);
            await _context.SaveChangesAsync();
        }
    }
}
