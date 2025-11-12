using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

public class MaterialService : IMaterialService
{
    private readonly IMaterialRepository _repository;
    private readonly IWebHostEnvironment _env;

    public MaterialService(IMaterialRepository repository, IWebHostEnvironment env)
    {
        _repository = repository;
        _env = env;
    }

    public async Task<MaterialDTO> UploadAsync(UploadMaterialDto dto)
    {
        // Caminho: wwwroot/uploads/materials
        var folder = Path.Combine(_env.WebRootPath, "uploads", "materials");

        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        var nomeArquivo = $"{Guid.NewGuid()}_{dto.Arquivo.FileName}";
        var caminhoArquivo = Path.Combine(folder, nomeArquivo);

        using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
        {
            await dto.Arquivo.CopyToAsync(stream);
        }

        var material = new Material(
            dto.IdCurso,
            nomeArquivo,
            caminhoArquivo,
            dto.Arquivo.ContentType
        );

        await _repository.CreateAsync(material);

        var url = $"/uploads/materials/{nomeArquivo}";

        return new MaterialDTO
        {
            Id = material.Id,
            IdCurso = material.IdCurso,
            NomeArquivo = material.NomeArquivo,
            Tipo = material.Tipo,
            DataUpload = material.DataUpload,
            Url = url
        };
    }

    public async Task<IEnumerable<MaterialDTO>> ListarPorCursoAsync(int cursoId)
    {
        var materiais = await _repository.GetByCursoAsync(cursoId);

        return materiais.Select(m => new MaterialDTO
        {
            Id = m.Id,
            IdCurso = m.IdCurso,
            NomeArquivo = m.NomeArquivo,
            Tipo = m.Tipo,
            DataUpload = m.DataUpload,
            Url = $"/uploads/materials/{m.NomeArquivo}"
        });
    }
}
