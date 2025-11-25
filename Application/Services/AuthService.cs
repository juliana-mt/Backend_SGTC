using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;
using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace TreinamentosCorp.API.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<AuthResult> RegisterAsync(UsuarioRegisterDTO dto)
        {
            var exists = await _usuarioRepository.GetByEmailAsync(dto.Email);
            if (exists != null)
                return new AuthResult { Sucesso = false, Mensagem = "Email já cadastrado." };

            var senhaHash = HashPassword(dto.Senha);
            var usuario = new Usuario(dto.Nome, dto.Email, "Padrão", senhaHash);

            await _usuarioRepository.CriarAsync(usuario);

            return new AuthResult { Sucesso = true, Mensagem = "Usuário registrado com sucesso." };
        }

        public async Task<AuthResult> LoginAsync(LoginDTO dto)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(dto.Email);
            if (usuario == null)
                return new AuthResult { Sucesso = false, Mensagem = "Usuário não encontrado." };

            if (!VerifyPassword(dto.Senha, usuario.SenhaHash))
                return new AuthResult { Sucesso = false, Mensagem = "Senha incorreta." };

            return new AuthResult { Sucesso = true, Mensagem = "Login realizado com sucesso." };
        }

        private string HashPassword(string senha)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(senha);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private bool VerifyPassword(string senhaDigitada, string senhaHash)
        {
            return HashPassword(senhaDigitada) == senhaHash;
        }
    }
}
