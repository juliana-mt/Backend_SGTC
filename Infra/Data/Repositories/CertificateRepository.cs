using Microsoft.EntityFrameworkCore;
using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Infra.Data.Context;

public class CertificadoRepository : ICertificadoRepository
{
    private readonly DataContext _context;

    public CertificadoRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Certificado> CreateAsync(Certificado certificado)
    {
        _context.Certificados.Add(certificado);
        await _context.SaveChangesAsync();
        return certificado;
    }

    public async Task<IEnumerable<Certificado>> GetByUsuarioAsync(int usuarioId)
    {
        return await _context.Certificados
            .Where(c => c.IdUsuario == usuarioId)
            .ToListAsync();
    }

    public async Task<Certificado?> GetByIdAsync(int id)
    {
        return await _context.Certificados
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Certificado?> GetByUsuarioCursoAsync(int usuarioId, int cursoId)
    {
        return await _context.Certificados
            .FirstOrDefaultAsync(c =>
                c.IdUsuario == usuarioId &&
                c.IdCurso == cursoId
            );
    }
}
