using System;

namespace Api.Domain.Models
{
    public class ClienteModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
    }
}
