using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class MunicipioEntity : BaseEntity
    {
        [Required]
        [MaxLength(40)]
        public string Cidade { get; set; }

        [Required]
        public Guid UfId { get; set; }
        public UfEntity Uf { get; set; }

        public IEnumerable<EnderecoEntity> Ceps { get; set; }
    }
}
