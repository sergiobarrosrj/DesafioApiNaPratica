using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cliente;
using Api.Domain.Interfaces.Services.Cliente;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cliente.QuandoRequisitarUpdate
{
    public class Retorno_BadRequest
    {
        private ClientesController _controller;

        [Fact(DisplayName = "É possível Realizar o Updated.")]
        public async Task E_Possivel_Invocar_a_Controller_Update()
        {
            var serviceMock = new Mock<IClienteService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Put(It.IsAny<ClienteDtoUpdate>())).ReturnsAsync(
                new ClienteDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = nome,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new ClientesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Email", "É um campo obrigatorio");

            var clienteDtoUpdate = new ClienteDtoUpdate
            {
                Id = Guid.NewGuid(),
                Nome = nome,
            };

            var result = await _controller.Put(clienteDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
