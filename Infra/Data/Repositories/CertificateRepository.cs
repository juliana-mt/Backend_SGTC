using Microsoft.EntityFrameworkCore;
using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Infra.Data.Context;

public class CertificateRepository : ICertificateRepository
{
    private readonly DataContext _context;

    public CertificateRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Certificate> CreateAsync(Certificate certificado)
    {
        _context.Certificados.Add(certificado);
        await _context.SaveChangesAsync();
        return certificado;
    }

    public async Task<IEnumerable<Certificate>> GetByUserAsync(int idUser)
    {
        return await _context.Certificados
            .Where(c => c.IdUser == idUser)
            .ToListAsync();
    }

    public async Task<Certificate?> GetByIdAsync(int id)
    {
        return await _context.Certificados
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Certificate?> GetByUserCourseAsync(int usuarioId, int cursoId)
    {
        return await _context.Certificados
            .FirstOrDefaultAsync(c =>
                c.IdUser == usuarioId &&
                c.IdCourse == cursoId
            );
    }
}
