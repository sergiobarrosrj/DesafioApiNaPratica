using System;
using Api.Domain.Dtos.Uf;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDtoCompleto
    {
        public Guid Id { get; set; }
        public string Cidade { get; set; }
        public Guid UfId { get; set; }
        public UfDto Uf { get; set; }

    }
}
