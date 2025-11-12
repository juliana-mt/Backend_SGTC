namespace TreinamentosCorp.API.Domain.Entities
{
    public class Pergunta
    {
        public int Id { get; private set; }
        public string Texto { get; private set; }
        public List<string> Opcoes { get; private set; } = new();
        public int RespostaCorreta { get; private set; }

        public Pergunta(string texto, List<string> opcoes, int respostaCorreta)
        {
            Texto = texto;
            Opcoes = opcoes;
            RespostaCorreta = respostaCorreta;
        }
    }
}
