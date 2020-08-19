using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cliente;
using Api.Domain.Interfaces.Services.Cliente;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cliente.QuandoRequisitarGet
{
    public class Retorno_Get
    {
        private ClientesController _controller;

        [Fact(DisplayName = "É possível Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IClienteService>();
            var nome = Faker.Name.FullName();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                 new ClienteDto
                 {
                     Id = Guid.NewGuid(),
                     Nome = nome,
                     CreateAt = DateTime.UtcNow
                 }
            );

            _controller = new ClientesController(serviceMock.Object);
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
            var resultValue = ((OkObjectResult)result).Value as ClienteDto;
            Assert.NotNull(resultValue);
        }
    }
}
