using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Endereco;
using Api.Domain.Interfaces.Services.Endereco;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Endereco.QuandoRequisitarGetById
{
    public class Retorno_OK
    {
        private EnderecosController _controller;

        [Fact(DisplayName = "É possível Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IEnderecoService>();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                 new EnderecoDto
                 {
                     Id = Guid.NewGuid(),
                     Cep = "24858552",
                     Logradouro = "Rua Alameda B",
                     Bairro = "Marambaia",
                     Numero = "123",
                     MunicipioId = Guid.NewGuid(),
                     Municipio = null
                 }
            );

            _controller = new EnderecosController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

        }
    }
}
