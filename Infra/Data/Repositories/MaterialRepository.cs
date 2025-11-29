using Microsoft.EntityFrameworkCore;
using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Infra.Data.Context;

public class MaterialRepository : IMaterialRepository
{
    private readonly DataContext _context;

    public MaterialRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Material> CreateAsync(Material material)
    {
        _context.Materiais.Add(material);
        await _context.SaveChangesAsync();
        return material;
    }

    public async Task<IEnumerable<Material>> GetByCourseAsync(int idCourse)
    {
        return await _context.Materiais
            .Where(m => m.IdCourse == idCourse)
            .ToListAsync();
    }

    public async Task<Material?> GetByIdAsync(int id)
    {
        return await _context.Materiais
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Material>> GetAllAsync()
    {
        return await _context.Materiais.ToListAsync();
    }
}
