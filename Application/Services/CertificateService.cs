using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;
using TreinamentosCorp.API.Infra.Pdf;

namespace TreinamentosCorp.API.Application.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepository _repository;
        private readonly IUserRepository _usuarioRepository;
        private readonly ICourseRepository _cursoRepository;
        private readonly IModuleRepository _moduloRepository;
        private readonly IProgressoCursoRepository _progressoRepository;
        private readonly IAssessmentRepository _avaliacaoRepository;

        public CertificateService(
            ICertificateRepository repository,
            IUserRepository usuarioRepository,
            ICourseRepository cursoRepository,
            IModuleRepository moduloRepository,
            IProgressoCursoRepository progressoRepository,
            IAssessmentRepository avaliacaoRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _cursoRepository = cursoRepository;
            _moduloRepository = moduloRepository;
            _progressoRepository = progressoRepository;
            _avaliacaoRepository = avaliacaoRepository;
        }

        public async Task<CertificateDTO> GerarAsync(CreateCertificateDTO dto)
        {
            var codigo = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            var certificado = new Certificate(dto.IdUsuario, dto.IdCurso, codigo);

            await _repository.CreateAsync(certificado);

            return await MontarDto(certificado);
        }

        // Buscar por id (PDF)
        public async Task<CertificateDTO?> BuscarPorIdAsync(int id)
        {
            var cert = await _repository.GetByIdAsync(id);
            if (cert == null)
                return null;

            return await MontarDto(cert);
        }

        public async Task<IEnumerable<CertificateDTO>> ListarPorUsuarioAsync(int usuarioId)
        {
            var certificados = await _repository.GetByUserAsync(usuarioId);
            var lista = new List<CertificateDTO>();

            foreach (var cert in certificados)
                lista.Add(await MontarDto(cert));

            return lista;
        }

        // Gera progresso + nota mínima
        public async Task<CertificateDTO?> GerarAutomaticoAsync(int usuarioId, int cursoId)
        {
            var existente = await _repository.GetByUserCourseAsync(usuarioId, cursoId);
            if (existente != null)
                return await MontarDto(existente);

            var modulosCurso = (await _moduloRepository.ListByCourseAsync(cursoId)).ToList();
            var progresso = (await _progressoRepository.ListByUserAsync(usuarioId)).ToList();

            bool concluiuTodos = modulosCurso.All(m => progresso.Any(p => p.IdModule == m.Id));
            if (!concluiuTodos)
                return null;

            var curso = await _cursoRepository.GetByIdAsync(cursoId);
            if (curso == null) return null;

            var notaFinal = await _avaliacaoRepository.GetFinalNoteAsync(usuarioId, cursoId);

            if (curso.MinimumNote > 0 && notaFinal.HasValue && notaFinal.Value < curso.MinimumNote)
                return null;

            var codigo = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            var certificado = new Certificate(usuarioId, cursoId, codigo);

            await _repository.CreateAsync(certificado);

            return await MontarDto(certificado);
        }

        // Gera PDF
        public byte[] GerarPDF(CertificateDTO dto)
        {
            var pdf = new CertificatePdfGenerator().Gerar(dto);
            return pdf;
        }

        
        private async Task<CertificateDTO> MontarDto(Certificate cert)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(cert.IdUser);
            var curso = await _cursoRepository.GetByIdAsync(cert.IdCourse);

            return new CertificateDTO
            {
                Id = cert.Id,
                IdUsuario = cert.IdUser,
                IdCurso = cert.IdCourse,
                DataEmissao = cert.Date,            
                CodigoValidacao = cert.ValidationCode,    

                NomeUsuario = usuario?.Name ?? "Usuário",
                NomeCurso = curso?.Name ?? "Curso",
                CargaHoraria = curso?.CargaHoraria ?? 0
            };
        }
    }
}
