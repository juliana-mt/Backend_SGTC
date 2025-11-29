using System;

namespace TreinamentosCorp.API.Domain.Entities
{
    public class Course
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public bool Active { get; private set; }
        public int MinimumNote { get; private set; } = 60;
        public int CargaHoraria { get; private set; }


        public Course(string nome, string descricao)
        {
            Name = nome;
            Description = descricao;
            Active = true;
        }

        public void Atualizar(string nome, string descricao)
        {
            Name = nome;
            Description = descricao;
        }

        public void Ativar() => Active = true;
        public void Desativar() => Active = false;
    }
}
