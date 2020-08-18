using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class UfEntity : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public string Sigla { get; set; }

        [Required]
        [MaxLength(40)]
        public string Estado { get; set; }

        public IEnumerable<MunicipioEntity> Municipios { get; set; }
    }
}
