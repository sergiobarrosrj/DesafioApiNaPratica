using System;
using System.ComponentModel.DataAnnotations;
using Api.Domain.CustomValidation;
using Api.Domain.Util;

namespace Api.Domain.CustomValidation
{

    internal class CustomValidationCPFAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
}

public class CustomValidationCPFAttribute : ValidationAttribute, IClientValidatable
{
    /// <summary>
    /// </summary>
    public CustomValidationCPFAttribute() { }

    /// <summary>
    /// Validação server
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public override bool IsValid(object value)
    {
        if (value == null || string.IsNullOrEmpty(value.ToString()))
            return true;

        bool valido = Function.ValidaCPF(value.ToString());
        return valido;
    }
}
