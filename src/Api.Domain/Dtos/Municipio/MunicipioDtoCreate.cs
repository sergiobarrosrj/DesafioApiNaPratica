using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDtoCreate
    {

        [StringLength(40, ErrorMessage = "Nome da Cidade deve ter no máximo {1} caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Código de UF é campo Obrigatorio")]
        public Guid UfId { get; set; }
    }
}
