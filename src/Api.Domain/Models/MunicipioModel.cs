using System;

namespace Api.Domain.Models
{
    public class MunicipioModel : BaseModel
    {
        public string Cidade { get; set; }
        public Guid UfId { get; set; }
    }
}
