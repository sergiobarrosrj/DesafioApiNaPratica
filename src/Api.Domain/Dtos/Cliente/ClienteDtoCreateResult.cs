using System;

namespace Api.Domain.Dtos.Cliente
{
    public class ClienteDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
