using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Endereco;
using Api.Domain.Interfaces.Services.Endereco;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Endereco.QuandoRequisitarUpdate
{
    public class Retorno_BadRequest
    {
        private EnderecosController _controller;

        [Fact(DisplayName = "É possível Realizar o Updated.")]
        public async Task E_Possivel_Invocar_a_Controller_Update()
        {
            var serviceMock = new Mock<IEnderecoService>();
            serviceMock.Setup(m => m.Put(It.IsAny<EnderecoDtoUpdate>())).ReturnsAsync(
                new EnderecoDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Cep = "24858552",
                    Logradouro = "Rua Alameda B.",
                    Bairro = "Marambaia",
                    Numero = "123",
                    MunicipioId = Guid.NewGuid(),
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new EnderecosController(serviceMock.Object);
            _controller.ModelState.AddModelError("Logradouro", "É um Campo Obrigatório");

            var enderecoDtoUpdate = new EnderecoDtoUpdate
            {
                Id = Guid.NewGuid(),
                Cep = "24858552",
                Logradouro = "Rua Alameda B.",
                Bairro = "Marambaia",
                Numero = "123",
                MunicipioId = Guid.NewGuid()
            };

            var result = await _controller.Put(enderecoDtoUpdate);
            Assert.True(result is BadRequestObjectResult);

        }

    }
}
