using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
            IdCurso = material.IdCourse,
            NomeArquivo = material.FileName,
            Tipo = material.Type,
            DataUpload = material.DateUpload,
            Url = url
        };
    }

    public async Task<IEnumerable<MaterialDTO>> GetAllAsync()
    {
        var materiais = await _repository.GetAllAsync();

        return materiais.Select(m => new MaterialDTO
        {
            Id = m.Id,
            IdCurso = m.IdCourse,
            NomeArquivo = m.FileName,
            Tipo = m.Type,
            DataUpload = m.DateUpload,
            Url = $"/uploads/materials/{m.FileName}"
        });
    }

    public async Task<MaterialDTO> CreateAsync(CreateMaterialDTO dto)
    {
        var material = new Material(
            dto.CursoId,
            dto.Titulo,
            dto.Url,
            "tipo" // Ajuste conforme necessidade
        );

        await _repository.CreateAsync(material);

        return new MaterialDTO
        {
            Id = material.Id,
            IdCurso = material.IdCourse,
            NomeArquivo = material.FileName,
            Tipo = material.Type,
            DataUpload = material.DateUpload,
            Url = material.Path // ou dto.Url
        };
    }

    public async Task<MaterialDTO?> GetByIdAsync(int id)
    {
        var material = await _repository.GetByIdAsync(id);
        if (material == null)
            return null;

        return new MaterialDTO
        {
            Id = material.Id,
            IdCurso = material.IdCourse,
            NomeArquivo = material.FileName,
            Tipo = material.Type,
            DataUpload = material.DateUpload,
            Url = $"/uploads/materials/{material.FileName}"
        };
    }

    public async Task<IEnumerable<MaterialDTO>> ListarPorCursoAsync(int idCurso)
    {
        var materiais = await _repository.GetByCourseAsync(idCurso);

        // Conversão manual sem usar AutoMapper
        return materiais.Select(m => new MaterialDTO
        {
            Id = m.Id,
            IdCurso = m.IdCourse,
            NomeArquivo = m.FileName,
            Tipo = m.Type,
            DataUpload = m.DateUpload,
            Url = $"/uploads/materials/{m.FileName}"
        });
    }
}
