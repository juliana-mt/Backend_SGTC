namespace TreinamentosCorp.API.Domain.Entities
{
    public class Question
    {
        public int Id { get; private set; }
        public string Text { get; private set; } = string.Empty;
        public List<string> Options { get; private set; } = new();
        public int CorrectAnswer { get; private set; }

        // Construtor sem parâmetros para o EF
        private Question() { }

        public Question(string text, List<string> options, int correctAnswer)
        {
            Text = text;
            Options = options;
            CorrectAnswer = correctAnswer;
        }
    }
}
