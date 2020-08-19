using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cliente;
using Api.Domain.Interfaces.Services.Cliente;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cliente.QuandoRequisitarCreate
{
    public class Retorno_Created
    {
        private ClientesController _controller;
        [Fact(DisplayName = "É possível Realizar o Created.")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<IClienteService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Post(It.IsAny<ClienteDtoCreate>())).ReturnsAsync(
                new ClienteDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = nome,
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new ClientesController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var ClienteDtoCreate = new ClienteDtoCreate
            {
                Nome = nome
            };

            var result = await _controller.Post(ClienteDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as ClienteDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(ClienteDtoCreate.Nome, resultValue.Nome);

        }
    }
}
