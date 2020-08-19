using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Endereco;
using Api.Domain.Interfaces.Services.Endereco;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Endereco.QuandoRequisitarCreate
{
    public class Retorno_Created
    {
        private EnderecosController _controller;

        [Fact(DisplayName = "É possível Realizar o Created.")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<IEnderecoService>();
            serviceMock.Setup(m => m.Post(It.IsAny<EnderecoDtoCreate>())).ReturnsAsync(
                new EnderecoDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Cep = "24858552",
                    Logradouro = "Teste de Rua",
                    Bairro = "Centro",
                    Numero = "123",
                    CreateAt = DateTime.UtcNow,
                    MunicipioId = Guid.NewGuid()
                }
            );

            _controller = new EnderecosController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var enderecoDtoCreate = new EnderecoDtoCreate
            {
                Cep = "24858552",
                Logradouro = "Teste",
                Bairro = "Centro",
                Numero = "123",
                MunicipioId = Guid.NewGuid()
            };

            var result = await _controller.Post(enderecoDtoCreate);
            Assert.True(result is CreatedResult);

        }
    }
}

