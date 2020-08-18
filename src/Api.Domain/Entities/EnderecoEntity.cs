using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class EnderecoEntity : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string Cep { get; set; }

        [Required]
        [MaxLength(50)]
        public string Logradouro { get; set; }

        [MaxLength(10)]
        public string Numero { get; set; }

        [Required]
        [MaxLength(40)]
        public string Bairro { get; set; }

        [Required]
        public Guid MunicipioId { get; set; }

        public MunicipioEntity Municipio { get; set; }
    }
}
