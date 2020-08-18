using System;

namespace Api.Domain.Models
{
    public class EnderecoModel : BaseModel
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        private string _numero;
        public string Numero
        {
            get { return _numero; }
            set
            {
                _numero = string.IsNullOrEmpty(value) ? "S/N" : value;
            }
        }

        public Guid MunicipioId { get; set; }

    }
}
