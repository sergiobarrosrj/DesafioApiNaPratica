using System;
using Api.Domain.Dtos.Municipio;

namespace Api.Domain.Dtos.Endereco
{
    public class EnderecoDto
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public Guid MunicipioId { get; set; }
        public MunicipioDtoCompleto Municipio { get; set; }
    }
}
