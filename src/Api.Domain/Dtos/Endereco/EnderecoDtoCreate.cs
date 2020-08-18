using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Endereco
{
    public class EnderecoDtoCreate
    {
        [Required(ErrorMessage = "CEP é campo obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Logradouro é campo obrigatório")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Logradouro deve ter no máximo {1} caracteres!")]
        public string Logradouro { get; set; }

        [StringLength(40, MinimumLength = 5, ErrorMessage = "Bairro deve ter no máximo {1} caracteres!")]
        public string Bairro { get; set; }
        public string Numero { get; set; }

        [Required(ErrorMessage = "Municipio é campo obrigatório")]
        public Guid MunicipioId { get; set; }
    }
}
