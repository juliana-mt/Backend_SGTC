namespace TreinamentosCorp.API.Domain.Entities
{
    public class Pergunta
    {
        public int Id { get; private set; }
        public string Texto { get; private set; } = string.Empty;
        public List<string> Opcoes { get; private set; } = new();
        public int RespostaCorreta { get; private set; }

        // Construtor sem parâmetros para o EF
        private Pergunta() { }

        public Pergunta(string texto, List<string> opcoes, int respostaCorreta)
        {
            Texto = texto;
            Opcoes = opcoes;
            RespostaCorreta = respostaCorreta;
        }
    }
}
