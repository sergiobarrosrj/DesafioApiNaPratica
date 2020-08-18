using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Cliente
{
    public class ClienteDtoCreate
    {
        [Required(ErrorMessage = "Nome deve ser informado!")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Nome deve ter no máximo {1} caracteres!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CPF obrigatório")]
        //[Validation.CustomValidationCPF(ErrorMessage = "CPF inválido")]
        public string Cpf { get; set; }
        public string Rg { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Uma data válida deve ser informada!")]
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
    }
}

