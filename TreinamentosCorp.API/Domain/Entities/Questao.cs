namespace TreinamentosCorp.API.Domain.Entities
{
    public class Questao
    {
        public int Id { get; private set; }
        public int IdCurso { get; private set; }
        public string Enunciado { get; private set; }
        public string RespostaCorreta { get; private set; }

        public Questao(int idCurso, string enunciado, string respostaCorreta)
        {
            IdCurso = idCurso;
            Enunciado = enunciado;
            RespostaCorreta = respostaCorreta;
        }

        public bool VerificarResposta(string respostaUsuario)
        {
            return respostaUsuario.Trim().ToLower() == RespostaCorreta.Trim().ToLower();
        }
    }
}
