using System;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Cidade { get; set; }
        public Guid UfId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
