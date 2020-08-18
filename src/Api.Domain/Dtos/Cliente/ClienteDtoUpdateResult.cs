using System;

namespace Api.Domain.Dtos.Cliente
{
    public class ClienteDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
