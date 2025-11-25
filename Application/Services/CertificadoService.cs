using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;
using TreinamentosCorp.API.Infra.Pdf;

namespace TreinamentosCorp.API.Application.Services
{
    public class CertificadoService : ICertificadoService
    {
        private readonly ICertificadoRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IModuloRepository _moduloRepository;
        private readonly IProgressoCursoRepository _progressoRepository;
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public CertificadoService(
            ICertificadoRepository repository,
            IUsuarioRepository usuarioRepository,
            ICursoRepository cursoRepository,
            IModuloRepository moduloRepository,
            IProgressoCursoRepository progressoRepository,
            IAvaliacaoRepository avaliacaoRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _cursoRepository = cursoRepository;
            _moduloRepository = moduloRepository;
            _progressoRepository = progressoRepository;
            _avaliacaoRepository = avaliacaoRepository;
        }

        public async Task<CertificadoDTO> GerarAsync(CreateCertificadoDTO dto)
        {
            var codigo = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            var certificado = new Certificado(dto.IdUsuario, dto.IdCurso, codigo);

            await _repository.CreateAsync(certificado);

            return await MontarDto(certificado);
        }

        // Buscar por id (PDF)
        public async Task<CertificadoDTO?> BuscarPorIdAsync(int id)
        {
            var cert = await _repository.GetByIdAsync(id);
            if (cert == null)
                return null;

            return await MontarDto(cert);
        }

        public async Task<IEnumerable<CertificadoDTO>> ListarPorUsuarioAsync(int usuarioId)
        {
            var certificados = await _repository.GetByUsuarioAsync(usuarioId);
            var lista = new List<CertificadoDTO>();

            foreach (var cert in certificados)
                lista.Add(await MontarDto(cert));

            return lista;
        }

        // Gera progresso + nota mínima
        public async Task<CertificadoDTO?> GerarAutomaticoAsync(int usuarioId, int cursoId)
        {
            var existente = await _repository.GetByUsuarioCursoAsync(usuarioId, cursoId);
            if (existente != null)
                return await MontarDto(existente);

            var modulosCurso = (await _moduloRepository.ListarPorCursoAsync(cursoId)).ToList();
            var progresso = (await _progressoRepository.ListarPorUsuarioAsync(usuarioId)).ToList();

            bool concluiuTodos = modulosCurso.All(m => progresso.Any(p => p.IdModulo == m.Id));
            if (!concluiuTodos)
                return null;

            var curso = await _cursoRepository.ObterPorIdAsync(cursoId);
            if (curso == null) return null;

            var notaFinal = await _avaliacaoRepository.ObterNotaFinalAsync(usuarioId, cursoId);

            if (curso.NotaMinima > 0 && notaFinal.HasValue && notaFinal.Value < curso.NotaMinima)
                return null;

            var codigo = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            var certificado = new Certificado(usuarioId, cursoId, codigo);

            await _repository.CreateAsync(certificado);

            return await MontarDto(certificado);
        }

        // Gera PDF
        public byte[] GerarPDF(CertificadoDTO dto)
        {
            var pdf = new CertificadoPdfGenerator().Gerar(dto);
            return pdf;
        }

        
        private async Task<CertificadoDTO> MontarDto(Certificado cert)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(cert.IdUsuario);
            var curso = await _cursoRepository.ObterPorIdAsync(cert.IdCurso);

            return new CertificadoDTO
            {
                Id = cert.Id,
                IdUsuario = cert.IdUsuario,
                IdCurso = cert.IdCurso,
                DataEmissao = cert.DataEmissao,            
                CodigoValidacao = cert.CodigoValidacao,    

                NomeUsuario = usuario?.Nome ?? "Usuário",
                NomeCurso = curso?.Nome ?? "Curso",
                CargaHoraria = curso?.CargaHoraria ?? 0
            };
        }
    }
}
