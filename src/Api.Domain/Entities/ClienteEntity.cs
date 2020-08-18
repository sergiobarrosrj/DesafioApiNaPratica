using System;

namespace Api.Domain.Entities
{
    public class ClienteEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
    }
}
